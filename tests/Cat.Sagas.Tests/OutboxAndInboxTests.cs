using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Inbox.EFCore;
using Cat.EventProcessor.Inbox.EFCore.Extensions;
using Cat.FluentWorkflows.Extensions;
using Cat.Messaging.Extensions;
using Cat.Messaging.Outbox.EFCore;
using Cat.Messaging.Outbox.EFCore.Extensions;
using Cat.Messaging.Outbox.Extensions;
using Cat.Sagas.Abstractions;
using Cat.Sagas.EFCore.Extensions;
using Cat.Sagas.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Sagas.Tests;

/// <summary>
/// The saga on the real outbox and the real inbox, in one SQLite database and one context per scope.
/// </summary>
[TestFixture]
public class OutboxAndInboxTests
{
    private SqliteConnection _connection = null!;
    private ServiceProvider _provider = null!;

    [SetUp]
    public void SetUp()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var services = new ServiceCollection();
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddDbContext<SagaDbContext>(options => options.UseSqlite(_connection));
        services.AddCatFluentWorkflowsModule();
        services.AddCatFluentWorkflowsFlows(typeof(PaymentFlow));
        services.AddCatMessagingModule();
        services.AddCatMessagingOutboxEfCore<SagaDbContext>();
        services.AddCatMessagingOutbox();
        services.AddCatEventProcessorInbox<SagaDbContext>();
        services.AddCatSagasModule();
        services.AddCatSagasOutbox();
        services.AddCatSagasEFCore<SagaDbContext>();
        services.AddCatSaga<PaymentFlow, OrderState>();
        services.AddCatSagaAnswer<PaymentTaken>();
        _provider = services.BuildServiceProvider();

        using var scope = _provider.CreateScope();
        scope.ServiceProvider.GetRequiredService<SagaDbContext>().Database.EnsureCreated();
    }

    [TearDown]
    public void TearDown()
    {
        _provider.Dispose();
        _connection.Dispose();
    }

    private async Task<CatSagaResult> StartAsync(Guid? id = null)
    {
        using var scope = _provider.CreateScope();
        return await scope.ServiceProvider.GetRequiredService<ICatSagaRunner>()
            .StartAsync<PaymentFlow, OrderState>(new OrderState { OrderId = Guid.NewGuid() }, id);
    }

    private async Task<int> CountAsync<TRow>() where TRow : class
    {
        using var scope = _provider.CreateScope();
        return await scope.ServiceProvider.GetRequiredService<SagaDbContext>().Set<TRow>().CountAsync();
    }

    [Test]
    public async Task Start_WithTheOutbox_CommitsTheInstanceAndTheRequestTogether()
    {
        var result = await StartAsync();

        Assert.That(result.Status, Is.EqualTo(CatSagaStatus.Waiting));
        Assert.That(await CountAsync<CatSagaInstance>(), Is.EqualTo(1));
        Assert.That(await CountAsync<CatOutboxMessage>(), Is.EqualTo(1));
        using var scope = _provider.CreateScope();
        var row = await scope.ServiceProvider.GetRequiredService<SagaDbContext>().Set<CatOutboxMessage>().SingleAsync();
        Assert.That(row.CorrelationId, Is.EqualTo(result.InstanceId));
        Assert.That(row.SentAt, Is.Null);
    }

    [Test]
    public async Task Start_WhenTheInstanceCannotBeSaved_LeavesNoRequestInTheOutbox()
    {
        var first = await StartAsync();

        await Assert.ThrowsAsync<CatSagaConcurrencyException>(() => StartAsync(first.InstanceId));

        Assert.That(await CountAsync<CatSagaInstance>(), Is.EqualTo(1));
        Assert.That(await CountAsync<CatOutboxMessage>(), Is.EqualTo(1));
    }

    [Test]
    public async Task Answer_WithTheInbox_SavesTheInboxRowWithTheInstanceUpdate()
    {
        var started = await StartAsync();
        var answer = new PaymentTaken { CorrelationId = started.InstanceId };

        using (var scope = _provider.CreateScope())
        {
            // The same two steps the receiver does for a message type with UseInbox on.
            var inbox = scope.ServiceProvider.GetRequiredService<ICatInboxStore>();
            inbox.Add(answer.MessageId.ToString(), nameof(PaymentTaken));
            await scope.ServiceProvider.GetRequiredService<ICatSagaDispatcher>().ResumeAsync(started.InstanceId, answer);
        }

        using var readScope = _provider.CreateScope();
        var inboxStore = readScope.ServiceProvider.GetRequiredService<ICatInboxStore>();
        Assert.That(await inboxStore.ExistsAsync(answer.MessageId.ToString()), Is.True);
        var saved = (await readScope.ServiceProvider.GetRequiredService<ICatSagaStore>().FindAsync(started.InstanceId))!;
        Assert.That(saved.Status, Is.EqualTo(CatSagaStatus.Completed));
    }

    [Test]
    public async Task Answer_WhenTheInstanceChangedMeanwhile_LeavesNoInboxRow()
    {
        var started = await StartAsync();
        var answer = new PaymentTaken { CorrelationId = started.InstanceId };

        using (var racer = _provider.CreateScope())
        {
            // Another message wins the race and moves the version on, after our scope loaded the instance.
            using var scope = _provider.CreateScope();
            var inbox = scope.ServiceProvider.GetRequiredService<ICatInboxStore>();
            inbox.Add(answer.MessageId.ToString(), nameof(PaymentTaken));
            var store = scope.ServiceProvider.GetRequiredService<ICatSagaStore>();
            var loaded = (await store.FindAsync(started.InstanceId))!;

            var other = (await racer.ServiceProvider.GetRequiredService<ICatSagaStore>().FindAsync(started.InstanceId))!;
            await racer.ServiceProvider.GetRequiredService<ICatSagaStore>().UpdateAsync(other);

            await Assert.ThrowsAsync<CatSagaConcurrencyException>(() => store.UpdateAsync(loaded));
        }

        using var readScope = _provider.CreateScope();
        Assert.That(await readScope.ServiceProvider.GetRequiredService<ICatInboxStore>().ExistsAsync(answer.MessageId.ToString()), Is.False);
    }
}
