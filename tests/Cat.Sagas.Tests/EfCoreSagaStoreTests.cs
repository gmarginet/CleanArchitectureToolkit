using Cat.FluentWorkflows.Extensions;
using Cat.Messaging.Abstractions;
using Cat.Responses.Abstractions;
using Cat.Sagas.Abstractions;
using Cat.Sagas.EFCore;
using Cat.Sagas.EFCore.Extensions;
using Cat.Sagas.Extensions;
using Cat.ServiceRequests.Abstractions;
using Cat.UnitTesting.Responses.NUnit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Sagas.Tests;

public class SagaDbContext : DbContext
{
    public SagaDbContext(DbContextOptions<SagaDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddCatSagas();
        Cat.Messaging.Outbox.EFCore.ModelBuilderExtensions.AddCatOutbox(modelBuilder);
        Cat.EventProcessor.Inbox.EFCore.ModelBuilderExtensions.AddCatInbox(modelBuilder);
    }
}

[TestFixture]
public class EfCoreSagaStoreTests
{
    private SqliteConnection _connection = null!;
    private ServiceProvider _provider = null!;

    [SetUp]
    public void SetUp()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddDbContext<SagaDbContext>(options => options.UseSqlite(_connection));
        services.AddCatFluentWorkflowsModule();
        services.AddCatFluentWorkflowsFlows(typeof(PaymentFlow));
        services.AddCatSagasModule();
        services.AddCatSagasInMemoryStore();
        services.AddCatSagasEFCore<SagaDbContext>();
        services.AddSingleton<ICatMessageSender, Cat.UnitTesting.Messaging.FakeMessageSender>();
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

    private static CatSagaInstance NewInstance(Guid id) => new()
    {
        Id = id,
        WorkflowType = "Flow",
        State = "{}",
        Status = CatSagaStatus.Waiting,
        CreatedAt = DateTimeOffset.UtcNow,
        UpdatedAt = DateTimeOffset.UtcNow
    };

    [Test]
    public void AddCatSagasEFCore_ReplacesTheInMemoryStore()
    {
        using var scope = _provider.CreateScope();

        Assert.That(scope.ServiceProvider.GetRequiredService<ICatSagaStore>(), Is.TypeOf<EfCoreSagaStore<SagaDbContext>>());
    }

    [Test]
    public async Task Add_ThenFind_ReturnsTheSavedInstanceWithVersionOne()
    {
        var id = Guid.NewGuid();
        using (var scope = _provider.CreateScope())
        {
            await scope.ServiceProvider.GetRequiredService<ICatSagaStore>().AddAsync(NewInstance(id));
        }

        using var readScope = _provider.CreateScope();
        var found = await readScope.ServiceProvider.GetRequiredService<ICatSagaStore>().FindAsync(id);

        Assert.That(found, Is.Not.Null);
        Assert.That(found!.Version, Is.EqualTo(1));
        Assert.That(found.Status, Is.EqualTo(CatSagaStatus.Waiting));
    }

    [Test]
    public async Task Find_OfAnUnknownId_ReturnsNull()
    {
        using var scope = _provider.CreateScope();

        Assert.That(await scope.ServiceProvider.GetRequiredService<ICatSagaStore>().FindAsync(Guid.NewGuid()), Is.Null);
    }

    [Test]
    public async Task Add_OfAnExistingId_ThrowsAConcurrencyException()
    {
        var id = Guid.NewGuid();
        using var scope = _provider.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<ICatSagaStore>();
        await store.AddAsync(NewInstance(id));

        await Assert.ThrowsAsync<CatSagaConcurrencyException>(() => store.AddAsync(NewInstance(id)));
    }

    [Test]
    public async Task Update_RaisesTheVersionAndSavesTheChange()
    {
        var id = Guid.NewGuid();
        using (var scope = _provider.CreateScope())
        {
            await scope.ServiceProvider.GetRequiredService<ICatSagaStore>().AddAsync(NewInstance(id));
        }

        using (var scope = _provider.CreateScope())
        {
            var store = scope.ServiceProvider.GetRequiredService<ICatSagaStore>();
            var instance = (await store.FindAsync(id))!;
            instance.Status = CatSagaStatus.Completed;
            await store.UpdateAsync(instance);
            Assert.That(instance.Version, Is.EqualTo(2));
        }

        using var readScope = _provider.CreateScope();
        var saved = (await readScope.ServiceProvider.GetRequiredService<ICatSagaStore>().FindAsync(id))!;
        Assert.That(saved.Status, Is.EqualTo(CatSagaStatus.Completed));
        Assert.That(saved.Version, Is.EqualTo(2));
    }

    [Test]
    public async Task Update_OfAnInstanceThatChangedMeanwhile_ThrowsAndKeepsTheWinner()
    {
        var id = Guid.NewGuid();
        using (var scope = _provider.CreateScope())
        {
            await scope.ServiceProvider.GetRequiredService<ICatSagaStore>().AddAsync(NewInstance(id));
        }

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
        using var readScope = _provider.CreateScope();
        var saved = (await readScope.ServiceProvider.GetRequiredService<ICatSagaStore>().FindAsync(id))!;
        Assert.That(saved.State, Is.EqualTo("winner"));
        Assert.That(saved.Version, Is.EqualTo(2));
    }

    [Test]
    public async Task StartAndAnswer_RunThroughTheDatabase()
    {
        var orderId = Guid.NewGuid();
        Guid instanceId;
        using (var scope = _provider.CreateScope())
        {
            var result = await scope.ServiceProvider.GetRequiredService<ICatSagaRunner>()
                .StartAsync<PaymentFlow, OrderState>(new OrderState { OrderId = orderId });
            instanceId = result.InstanceId;
            Assert.That(result.Status, Is.EqualTo(CatSagaStatus.Waiting));
        }

        ICatResponse response;
        using (var scope = _provider.CreateScope())
        {
            response = await scope.ServiceProvider.GetRequiredService<ICatServiceRequestHandler<PaymentTaken>>()
                .HandleAsync(new PaymentTaken { CorrelationId = instanceId, OrderId = orderId });
        }

        Assert.That(response, CatIs.Succeeded);
        using var readScope = _provider.CreateScope();
        var instance = (await readScope.ServiceProvider.GetRequiredService<ICatSagaStore>().FindAsync(instanceId))!;
        Assert.That(instance.Status, Is.EqualTo(CatSagaStatus.Completed));
        var state = (OrderState)_provider.GetRequiredService<ICatSagaSerializer>().Deserialize(instance.State, typeof(OrderState));
        Assert.That(state.Log, Is.EqualTo(new[] { "started", "confirmed" }));
        Assert.That(state.Taken!.OrderId, Is.EqualTo(orderId));
    }
}
