using System.Text.Json;
using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Extensions;
using Cat.EventProcessor.Inbox.EFCore;
using Cat.EventProcessor.Inbox.EFCore.Extensions;
using Cat.FluentWorkflows.Extensions;
using Cat.Messaging.Extensions;
using Cat.Messaging.Outbox.EFCore.Extensions;
using Cat.Messaging.Outbox.Extensions;
using Cat.Sagas.Abstractions;
using Cat.Sagas.EFCore.Extensions;
using Cat.Sagas.Extensions;
using Cat.ServiceRequests.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Sagas.Tests;

/// <summary>
/// An answer through the real receiver, the real service request processor and the real inbox, in one SQLite database.
/// The inbox row must be saved with the saga instance, which only works when the handler runs in the scope of the receiver.
/// </summary>
[TestFixture]
public class ReceiverInboxTests
{
    private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

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
        services.AddCatMessagingModule();
        services.AddCatMessagingOutboxEfCore<SagaDbContext>();
        services.AddCatMessagingOutbox();
        services.AddCatEventProcessorInbox<SagaDbContext>();
        services.AddCatSagasModule();
        services.AddCatSagasOutbox();
        services.AddCatSagasEFCore<SagaDbContext>();
        services.AddCatSaga<PaymentFlow, OrderState>();
        services.AddCatSagaAnswer<PaymentTaken>();
        services.AddCatServiceRequestsModule(typeof(PaymentFlow));
        services.AddCatEventProcessor(new ConfigurationBuilder().Build(), processor => processor
            .Receive<PaymentTaken>(options => options.UseInbox = true));
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

    private async Task<CatSagaResult> StartAsync()
    {
        using var scope = _provider.CreateScope();
        return await scope.ServiceProvider.GetRequiredService<ICatSagaRunner>()
            .StartAsync<PaymentFlow, OrderState>(new OrderState { OrderId = Guid.NewGuid() });
    }

    private async Task<CatSettlementResult> ReceiveAsync(Guid instanceId, string messageId)
    {
        var answer = new PaymentTaken { CorrelationId = instanceId };
        var message = new CatIncomingMessage
        {
            Body = JsonSerializer.SerializeToUtf8Bytes(answer, Json),
            ContentType = "application/json",
            MessageId = messageId
        };

        return await _provider.GetRequiredService<ICatMessageReceiver>().ReceiveAsync(typeof(PaymentTaken), message);
    }

    private async Task<int> InboxRowsAsync()
    {
        using var scope = _provider.CreateScope();
        return await scope.ServiceProvider.GetRequiredService<SagaDbContext>().Set<CatInboxMessage>().CountAsync();
    }

    private async Task<CatSagaStatus> StatusAsync(Guid instanceId)
    {
        using var scope = _provider.CreateScope();
        return (await scope.ServiceProvider.GetRequiredService<ICatSagaStore>().FindAsync(instanceId))!.Status;
    }

    [Test]
    public async Task Receive_SavesTheInboxRowWithTheInstanceUpdate()
    {
        var started = await StartAsync();

        var result = await ReceiveAsync(started.InstanceId, "answer-1");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
            Assert.That(await StatusAsync(started.InstanceId), Is.EqualTo(CatSagaStatus.Completed));
            Assert.That(await InboxRowsAsync(), Is.EqualTo(1));
        }
    }

    [Test]
    public async Task Receive_OfTheSameMessageTwice_RunsTheHandlerOnce()
    {
        var started = await StartAsync();

        await ReceiveAsync(started.InstanceId, "answer-1");
        var second = await ReceiveAsync(started.InstanceId, "answer-1");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(second.Settlement, Is.EqualTo(CatSettlement.Complete));
            Assert.That(await InboxRowsAsync(), Is.EqualTo(1));
        }
    }
}
