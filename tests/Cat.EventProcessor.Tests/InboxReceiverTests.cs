using Azure.Messaging.ServiceBus;
using Cat.EventProcessor.AzureServiceBus;
using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Extensions;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class InboxReceiverTests
{
    private FakeServiceRequestProcessor _processor = null!;
    private FakeInboxStore _store = null!;

    [SetUp]
    public void SetUp()
    {
        _processor = new FakeServiceRequestProcessor();
        _store = new FakeInboxStore();
    }

    private ServiceProvider Build(Action<CatReceiveOptions>? configure, bool withStore = true, Dictionary<string, string?>? settings = null)
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddScoped<ICatServiceRequestProcessor>(_ => _processor);
        if (withStore)
        {
            services.AddScoped<ICatInboxStore>(_ => _store);
        }

        var configuration = new ConfigurationBuilder().AddInMemoryCollection(settings ?? new Dictionary<string, string?>()).Build();
        services.AddCatEventProcessor(configuration, builder => builder.Receive<OrderPlaced>(configure));
        return services.BuildServiceProvider();
    }

    private static CatIncomingMessage MessageOf(string id = "message-1") => new()
    {
        Body = Json.Of(new { orderNumber = "ORD-1" }),
        ContentType = "application/json",
        MessageId = id
    };

    private static Task<CatSettlementResult> ReceiveAsync(ServiceProvider provider, CatIncomingMessage message) =>
        provider.GetRequiredService<ICatMessageReceiver>().ReceiveAsync(typeof(OrderPlaced), message);

    [Test]
    public async Task Receive_RunsTheHandlerAndAddsTheRowForANewMessage()
    {
        using var provider = Build(options => options.UseInbox = true);

        var result = await ReceiveAsync(provider, MessageOf());

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
        Assert.That(_processor.SeenRequest, Is.Not.Null);
        Assert.That(_store.Added, Is.EqualTo(new[] { ("message-1", "OrderPlaced") }));
    }

    [Test]
    public async Task Receive_SkipsARepeatedMessageWithoutRunningTheHandler()
    {
        _store.Known.Add("message-1");
        using var provider = Build(options => options.UseInbox = true);

        var result = await ReceiveAsync(provider, MessageOf());

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
        Assert.That(_processor.SeenRequest, Is.Null);
        Assert.That(_store.Added, Is.Empty);
    }

    [Test]
    public async Task Receive_IgnoresTheInboxForAMessageTypeWithoutTheSetting()
    {
        _store.Known.Add("message-1");
        using var provider = Build(null);

        await ReceiveAsync(provider, MessageOf());

        Assert.That(_processor.SeenRequest, Is.Not.Null);
        Assert.That(_store.Added, Is.Empty);
    }

    [Test]
    public async Task Receive_SwitchesTheInboxOnFromTheConfiguration()
    {
        _store.Known.Add("message-1");
        using var provider = Build(null, settings: new Dictionary<string, string?> { ["CatEventProcessor:Messages:OrderPlaced:UseInbox"] = "true" });

        await ReceiveAsync(provider, MessageOf());

        Assert.That(_processor.SeenRequest, Is.Null);
    }

    [Test]
    public async Task Receive_SwitchesTheInboxOffFromTheConfiguration()
    {
        _store.Known.Add("message-1");
        using var provider = Build(options => options.UseInbox = true,
            settings: new Dictionary<string, string?> { ["CatEventProcessor:Messages:OrderPlaced:UseInbox"] = "false" });

        await ReceiveAsync(provider, MessageOf());

        Assert.That(_processor.SeenRequest, Is.Not.Null);
    }

    [Test]
    public async Task Listener_FailsAtStartupWhenTheInboxIsOnAndNoStoreIsRegistered()
    {
        using var provider = Build(options => options.UseInbox = true, withStore: false);

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => CreateListener(provider).StartAsync(CancellationToken.None));

        Assert.That(exception!.Message, Does.Contain("OrderPlaced").And.Contain("ICatInboxStore"));
    }

    private static ServiceBusListener CreateListener(ServiceProvider provider) => new(
        new ServiceBusClient("Endpoint=sb://unused.servicebus.windows.net/;SharedAccessKeyName=a;SharedAccessKey=YQ=="),
        provider.GetRequiredService<ICatReceiveRegistry>(), null!, provider.GetRequiredService<ICatMessageReceiver>(),
        Options.Create(new CatEventProcessorServiceBusOptions()), new ListenerStatus(), NullLogger<ServiceBusListener>.Instance,
        provider.GetRequiredService<IServiceProviderIsService>());

    private sealed class FakeInboxStore : ICatInboxStore
    {
        public HashSet<string> Known { get; } = new();
        public List<(string Id, string Type)> Added { get; } = new();

        public Task<bool> ExistsAsync(string messageId, CancellationToken cancellationToken = default) =>
            Task.FromResult(Known.Contains(messageId));

        public void Add(string messageId, string messageType) => Added.Add((messageId, messageType));
    }
}
