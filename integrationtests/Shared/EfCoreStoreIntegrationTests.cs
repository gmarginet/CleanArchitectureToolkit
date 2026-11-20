using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Inbox.EFCore;
using Cat.EventProcessor.Inbox.EFCore.Extensions;
using Cat.Messaging.Abstractions;
using Cat.Messaging.Outbox;
using Cat.Messaging.Outbox.EFCore;
using Cat.Messaging.Outbox.EFCore.Extensions;
using Cat.Sagas.Abstractions;
using Cat.Sagas.EFCore;
using Cat.Sagas.EFCore.Extensions;
using Cat.Scheduling.Abstractions;
using Cat.Scheduling.EFCore;
using Cat.Scheduling.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.EFCore.IntegrationTests;

/// <summary>
/// The tests of the outbox, the inbox and the scheduler claim store. Both database projects compile this file, so the same
/// tests run on SQL Server and on PostgreSQL. A project adds the other part of this class: the base class with its database, and the provider.
/// </summary>
public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Cat.Messaging.Outbox.EFCore.ModelBuilderExtensions.AddCatOutbox(modelBuilder);
        Cat.EventProcessor.Inbox.EFCore.ModelBuilderExtensions.AddCatInbox(modelBuilder);
        Cat.Scheduling.EFCore.ModelBuilderExtensions.AddCatScheduling(modelBuilder);
        Cat.Sagas.EFCore.ModelBuilderExtensions.AddCatSagas(modelBuilder);
    }
}

[TestFixture]
public partial class EfCoreStoreIntegrationTests
{
    private static readonly DateTimeOffset Due = new(2030, 1, 1, 8, 0, 0, TimeSpan.Zero);

    private static bool _created;
    private ServiceProvider _provider = null!;

    [SetUp]
    public async Task SetUp()
    {
        var services = new ServiceCollection();
        services.AddDbContext<StoreDbContext>(options => UseDatabase(options, ConnectionString));
        services.AddCatMessagingOutboxEfCore<StoreDbContext>();
        services.AddCatEventProcessorInbox<StoreDbContext>();
        services.AddCatSchedulingEFCore<StoreDbContext>();
        services.AddCatSagasEFCore<StoreDbContext>();
        _provider = services.BuildServiceProvider();

        using var scope = _provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
        if (!_created)
        {
            await context.Database.EnsureCreatedAsync();
            _created = true;
        }

        await context.Set<CatOutboxMessage>().ExecuteDeleteAsync();
        await context.Set<CatInboxMessage>().ExecuteDeleteAsync();
        await context.Set<CatJobRun>().ExecuteDeleteAsync();
        await context.Set<CatSagaInstance>().ExecuteDeleteAsync();
    }

    [TearDown]
    public async Task TearDown() => await _provider.DisposeAsync();

    private static CatOutgoingMessage NewMessage(string subject) => new()
    {
        EntityName = "orders",
        Kind = CatMessageKind.Event,
        Body = [1, 2, 3],
        ContentType = "application/json",
        MessageId = Guid.NewGuid(),
        CorrelationId = Guid.NewGuid(),
        Subject = subject,
        Properties = new Dictionary<string, string> { ["tenant"] = "acme" }
    };

    // The scope is the unit of work. Saving it writes what the stores added.
    private async Task InScopeAsync(Func<IServiceProvider, Task> work, bool save = false)
    {
        using var scope = _provider.CreateScope();
        await work(scope.ServiceProvider);
        if (save) await scope.ServiceProvider.GetRequiredService<StoreDbContext>().SaveChangesAsync();
    }

    [Test]
    public async Task Outbox_AddThenGetPending_ReturnsTheMessageWithItsContent()
    {
        var message = NewMessage("order.placed");
        await InScopeAsync(services => services.GetRequiredService<ICatOutboxStore>().AddAsync(message), save: true);

        await InScopeAsync(async services =>
        {
            var pending = await services.GetRequiredService<ICatOutboxStore>().GetPendingAsync(10);

            var item = pending.Single();
            Assert.That(item.Message.Subject, Is.EqualTo("order.placed"));
            Assert.That(item.Message.Body, Is.EqualTo(new byte[] { 1, 2, 3 }));
            Assert.That(item.Message.MessageId, Is.EqualTo(message.MessageId));
            Assert.That(item.Message.Kind, Is.EqualTo(CatMessageKind.Event));
            Assert.That(item.Message.Properties, Is.EqualTo(new Dictionary<string, string> { ["tenant"] = "acme" }));
        });
    }

    [Test]
    public async Task Outbox_GetPending_ReturnsTheOldestFirstAndHonoursTheLimit()
    {
        foreach (var subject in new[] { "first", "second", "third" })
        {
            await InScopeAsync(services => services.GetRequiredService<ICatOutboxStore>().AddAsync(NewMessage(subject)), save: true);
            await Task.Delay(20);
        }

        await InScopeAsync(async services =>
        {
            var pending = await services.GetRequiredService<ICatOutboxStore>().GetPendingAsync(2);

            Assert.That(pending.Select(item => item.Message.Subject), Is.EqualTo(new[] { "first", "second" }));
        });
    }

    [Test]
    public async Task Outbox_MarkSent_RemovesTheMessageFromThePendingList()
    {
        await InScopeAsync(services => services.GetRequiredService<ICatOutboxStore>().AddAsync(NewMessage("a")), save: true);
        await InScopeAsync(services => services.GetRequiredService<ICatOutboxStore>().AddAsync(NewMessage("b")), save: true);

        await InScopeAsync(async services =>
        {
            var store = services.GetRequiredService<ICatOutboxStore>();
            var first = (await store.GetPendingAsync(10)).First();
            await store.MarkSentAsync(first.Id);

            var pending = await store.GetPendingAsync(10);
            Assert.That(pending, Has.Count.EqualTo(1));
            Assert.That(pending.Single().Id, Is.Not.EqualTo(first.Id));
        });
    }

    [Test]
    public async Task Outbox_DeleteOlderThan_DeletesOnlyTheSentRowsBeforeTheLimit()
    {
        var oldSent = Guid.NewGuid();
        var newSent = Guid.NewGuid();
        var pending = Guid.NewGuid();
        await InScopeAsync(services =>
        {
            services.GetRequiredService<StoreDbContext>().Set<CatOutboxMessage>().AddRange(
                NewRow(oldSent, DateTimeOffset.UtcNow.AddDays(-10), DateTimeOffset.UtcNow.AddDays(-10)),
                NewRow(newSent, DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(-1)),
                NewRow(pending, DateTimeOffset.UtcNow.AddDays(-10), null));
            return Task.CompletedTask;
        }, save: true);

        int deleted = 0;
        await InScopeAsync(async services =>
            deleted = await services.GetRequiredService<ICatOutboxStore>().DeleteOlderThanAsync(DateTimeOffset.UtcNow.AddDays(-5)));

        Assert.That(deleted, Is.EqualTo(1));
        await InScopeAsync(async services =>
        {
            var ids = await services.GetRequiredService<StoreDbContext>().Set<CatOutboxMessage>().Select(row => row.Id).ToListAsync();
            Assert.That(ids, Is.EquivalentTo(new[] { newSent, pending }));
        });
    }

    private static CatOutboxMessage NewRow(Guid id, DateTimeOffset createdAt, DateTimeOffset? sentAt) => new()
    {
        Id = id,
        CreatedAt = createdAt,
        SentAt = sentAt,
        EntityName = "orders",
        ContentType = "application/json",
        Subject = "s"
    };

    [Test]
    public async Task Inbox_AddThenExists_FindsTheMessage()
    {
        await InScopeAsync(services => { services.GetRequiredService<ICatInboxStore>().Add("m1", "T"); return Task.CompletedTask; }, save: true);

        await InScopeAsync(async services =>
        {
            var store = services.GetRequiredService<ICatInboxStore>();
            Assert.That(await store.ExistsAsync("m1"), Is.True);
            Assert.That(await store.ExistsAsync("other"), Is.False);
        });
    }

    [Test]
    public async Task Inbox_AddOfTheSameMessageTwice_IsStoppedByTheKey()
    {
        await InScopeAsync(services => { services.GetRequiredService<ICatInboxStore>().Add("m1", "T"); return Task.CompletedTask; }, save: true);

        await Assert.ThrowsAsync<DbUpdateException>(() =>
            InScopeAsync(services => { services.GetRequiredService<ICatInboxStore>().Add("m1", "T"); return Task.CompletedTask; }, save: true));
    }

    [Test]
    public async Task Inbox_DeleteOlderThan_DeletesOnlyTheRowsHandledBeforeTheLimit()
    {
        await InScopeAsync(services =>
        {
            services.GetRequiredService<StoreDbContext>().Set<CatInboxMessage>().AddRange(
                new CatInboxMessage { MessageId = "old", MessageType = "T", HandledAt = DateTimeOffset.UtcNow.AddDays(-10) },
                new CatInboxMessage { MessageId = "new", MessageType = "T", HandledAt = DateTimeOffset.UtcNow.AddDays(-1) });
            return Task.CompletedTask;
        }, save: true);

        int deleted = 0;
        await InScopeAsync(async services =>
            deleted = await services.GetRequiredService<ICatInboxStore>().DeleteOlderThanAsync(DateTimeOffset.UtcNow.AddDays(-5)));

        Assert.That(deleted, Is.EqualTo(1));
        await InScopeAsync(async services =>
        {
            var store = services.GetRequiredService<ICatInboxStore>();
            Assert.That(await store.ExistsAsync("old"), Is.False);
            Assert.That(await store.ExistsAsync("new"), Is.True);
        });
    }

    [Test]
    public async Task ClaimStore_FirstClaimOfARun_Claims()
    {
        var store = _provider.GetRequiredService<ICatJobClaimStore>();

        var result = await store.TryClaimAsync("job", Due, Due, true, TimeSpan.FromMinutes(5));

        Assert.That(result.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
        Assert.That(result.Claim!.JobName, Is.EqualTo("job"));
        Assert.That(result.Claim.DueTime, Is.EqualTo(Due));
    }

    [Test]
    public async Task ClaimStore_SecondClaimOfTheSameRun_IsTakenByOther()
    {
        var store = _provider.GetRequiredService<ICatJobClaimStore>();
        await store.TryClaimAsync("job", Due, Due, true, TimeSpan.FromMinutes(5));

        var second = await store.TryClaimAsync("job", Due, Due, true, TimeSpan.FromMinutes(5));

        Assert.That(second.Status, Is.EqualTo(CatJobClaimStatus.TakenByOther));
    }

    [Test]
    public async Task ClaimStore_WhenARunIsStillRunningAndOverlapIsNotAllowed_IsBusy()
    {
        var store = _provider.GetRequiredService<ICatJobClaimStore>();
        await store.TryClaimAsync("job", Due, Due, false, TimeSpan.FromMinutes(5));

        var next = await store.TryClaimAsync("job", Due.AddMinutes(1), Due.AddMinutes(1), false, TimeSpan.FromMinutes(5));

        Assert.That(next.Status, Is.EqualTo(CatJobClaimStatus.Busy));
    }

    [Test]
    public async Task ClaimStore_WhenTheRunningClaimIsOlderThanTheDeadLimit_ClaimsAgain()
    {
        var store = _provider.GetRequiredService<ICatJobClaimStore>();
        await store.TryClaimAsync("job", Due, Due, false, TimeSpan.FromMinutes(5));

        var next = await store.TryClaimAsync("job", Due.AddMinutes(10), Due.AddMinutes(10), false, TimeSpan.FromMinutes(5));

        Assert.That(next.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
    }

    [Test]
    public async Task ClaimStore_Complete_SavesTheResultAndFreesTheJob()
    {
        var store = _provider.GetRequiredService<ICatJobClaimStore>();
        var claim = (await store.TryClaimAsync("job", Due, Due, false, TimeSpan.FromMinutes(5))).Claim!;

        await store.CompleteAsync(claim, new CatJobRunResult(CatJobRunStatus.Succeeded, null, 1), Due.AddSeconds(30));

        using var scope = _provider.CreateScope();
        var row = await scope.ServiceProvider.GetRequiredService<StoreDbContext>().Set<CatJobRun>().SingleAsync();
        Assert.That(row.Status, Is.EqualTo(CatJobRunStatus.Succeeded));
        Assert.That(row.Attempts, Is.EqualTo(1));
        Assert.That(row.FinishedAt, Is.Not.Null);
        var next = await store.TryClaimAsync("job", Due.AddMinutes(1), Due.AddMinutes(1), false, TimeSpan.FromMinutes(5));
        Assert.That(next.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
    }

    [Test]
    public async Task ClaimStore_GetLastDueTime_ReturnsTheLatestRunOfTheJob()
    {
        var store = _provider.GetRequiredService<ICatJobClaimStore>();
        Assert.That(await store.GetLastDueTimeAsync("job"), Is.Null);
        await store.TryClaimAsync("job", Due, Due, true, TimeSpan.FromMinutes(5));
        await store.TryClaimAsync("job", Due.AddHours(1), Due.AddHours(1), true, TimeSpan.FromMinutes(5));
        await store.TryClaimAsync("other", Due.AddHours(5), Due.AddHours(5), true, TimeSpan.FromMinutes(5));

        Assert.That(await store.GetLastDueTimeAsync("job"), Is.EqualTo(Due.AddHours(1)));
    }

    [Test]
    public async Task ClaimStore_ManyInstancesClaimingTheSameRun_OnlyOneWins()
    {
        var store = _provider.GetRequiredService<ICatJobClaimStore>();

        var results = await Task.WhenAll(Enumerable.Range(0, 8)
            .Select(_ => Task.Run(() => store.TryClaimAsync("job", Due, Due, true, TimeSpan.FromMinutes(5)))));

        Assert.That(results.Count(r => r.Status == CatJobClaimStatus.Claimed), Is.EqualTo(1));
        Assert.That(results.Count(r => r.Status == CatJobClaimStatus.TakenByOther), Is.EqualTo(7));
    }

    private static CatSagaInstance NewSaga(Guid id) => new()
    {
        Id = id,
        WorkflowType = "Flow",
        State = "{}",
        Status = CatSagaStatus.Waiting,
        CreatedAt = DateTimeOffset.UtcNow,
        UpdatedAt = DateTimeOffset.UtcNow
    };

    [Test]
    public async Task SagaStore_AddThenFind_ReturnsTheInstanceWithVersionOne()
    {
        var id = Guid.NewGuid();
        await InScopeAsync(services => services.GetRequiredService<ICatSagaStore>().AddAsync(NewSaga(id)));

        await InScopeAsync(async services =>
        {
            var found = await services.GetRequiredService<ICatSagaStore>().FindAsync(id);

            Assert.That(found, Is.Not.Null);
            Assert.That(found!.Version, Is.EqualTo(1));
            Assert.That(found.Status, Is.EqualTo(CatSagaStatus.Waiting));
        });
    }

    [Test]
    public async Task SagaStore_AddOfAnExistingId_ThrowsAConcurrencyException()
    {
        var id = Guid.NewGuid();
        using var scope = _provider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<ICatSagaStore>();
        await store.AddAsync(NewSaga(id));

        await Assert.ThrowsAsync<CatSagaConcurrencyException>(() => store.AddAsync(NewSaga(id)));
    }

    [Test]
    public async Task SagaStore_Update_RaisesTheVersionAndSavesTheChange()
    {
        var id = Guid.NewGuid();
        await InScopeAsync(services => services.GetRequiredService<ICatSagaStore>().AddAsync(NewSaga(id)));

        await InScopeAsync(async services =>
        {
            var store = services.GetRequiredService<ICatSagaStore>();
            var instance = (await store.FindAsync(id))!;
            instance.Status = CatSagaStatus.Completed;
            await store.UpdateAsync(instance);
            Assert.That(instance.Version, Is.EqualTo(2));
        });

        await InScopeAsync(async services =>
        {
            var saved = (await services.GetRequiredService<ICatSagaStore>().FindAsync(id))!;
            Assert.That(saved.Status, Is.EqualTo(CatSagaStatus.Completed));
            Assert.That(saved.Version, Is.EqualTo(2));
        });
    }

    [Test]
    public async Task SagaStore_UpdateOfAnInstanceThatChangedMeanwhile_ThrowsAndKeepsTheWinner()
    {
        var id = Guid.NewGuid();
        await InScopeAsync(services => services.GetRequiredService<ICatSagaStore>().AddAsync(NewSaga(id)));

        using var scopeA = _provider.CreateScope();
        using var scopeB = _provider.CreateScope();
        var storeA = scopeA.ServiceProvider.GetRequiredService<ICatSagaStore>();
        var storeB = scopeB.ServiceProvider.GetRequiredService<ICatSagaStore>();
        var a = (await storeA.FindAsync(id))!;
        var b = (await storeB.FindAsync(id))!;
        a.State = "winner";
        b.State = "loser";

        await storeA.UpdateAsync(a);
        await Assert.ThrowsAsync<CatSagaConcurrencyException>(() => storeB.UpdateAsync(b));

        Assert.That(b.Version, Is.EqualTo(1));
        await InScopeAsync(async services =>
        {
            var saved = (await services.GetRequiredService<ICatSagaStore>().FindAsync(id))!;
            Assert.That(saved.State, Is.EqualTo("winner"));
            Assert.That(saved.Version, Is.EqualTo(2));
        });
    }
}