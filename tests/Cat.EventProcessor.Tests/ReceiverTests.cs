using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Extensions;
using Cat.Responses;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class ReceiverTests
{
    private FakeServiceRequestProcessor _processor = null!;
    private ServiceProvider _provider = null!;

    [SetUp]
    public void SetUp()
    {
        _processor = new FakeServiceRequestProcessor();
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddScoped<ICatServiceRequestProcessor>(_ => _processor);
        services.AddCatEventProcessor(new ConfigurationBuilder().Build(), builder => builder.Receive<OrderPlaced>());
        _provider = services.BuildServiceProvider();
    }

    [TearDown]
    public void TearDown() => _provider.Dispose();

    private Task<CatSettlementResult> ReceiveAsync(CatIncomingMessage message) =>
        _provider.GetRequiredService<ICatMessageReceiver>().ReceiveAsync(typeof(OrderPlaced), message);

    private static CatIncomingMessage MessageOf(object body, string contentType = "application/json") => new()
    {
        Body = Json.Of(body),
        ContentType = contentType,
        MessageId = "message-1",
        DeliveryCount = 2
    };

    [Test]
    public async Task Receive_RunsTheMessageAsTheServiceRequestAndCompletesIt()
    {
        var result = await ReceiveAsync(MessageOf(new { orderNumber = "ORD-1" }));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
        Assert.That(_processor.SeenRequest, Is.InstanceOf<OrderPlaced>());
        Assert.That(((OrderPlaced)_processor.SeenRequest!).OrderNumber, Is.EqualTo("ORD-1"));
    }

    [Test]
    public async Task Receive_MakesTheMessageCurrentWhileTheHandlerRuns()
    {
        await ReceiveAsync(MessageOf(new { orderNumber = "ORD-1" }));

        Assert.That(_processor.SeenContext!.MessageId, Is.EqualTo("message-1"));
        Assert.That(_processor.SeenContext.DeliveryCount, Is.EqualTo(2));
        Assert.That(CatMessageContext.Current, Is.Null);
    }

    [Test]
    public async Task Receive_DeadLettersAtOnceForAFailureThatWillNotChange()
    {
        _processor.Respond = _ => CatResponse.NotFound(new FakeError("DEM-ORD-1001", "Order not found."));

        var result = await ReceiveAsync(MessageOf(new { orderNumber = "ORD-1" }));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.DeadLetter));
        Assert.That(result.Reason, Is.EqualTo("DEM-ORD-1001"));
        Assert.That(result.Description, Does.Contain("Order not found."));
    }

    [Test]
    public async Task Receive_AbandonsForAServerError()
    {
        _processor.Respond = _ => CatResponse.InternalServerError(new FakeError("DEM-ORD-2001", "The database is down."));

        var result = await ReceiveAsync(MessageOf(new { orderNumber = "ORD-1" }));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Abandon));
    }

    [Test]
    public async Task Receive_AbandonsWhenTheHandlerThrows()
    {
        _processor.Respond = _ => throw new InvalidOperationException("Boom");

        var result = await ReceiveAsync(MessageOf(new { orderNumber = "ORD-1" }));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Abandon));
        Assert.That(result.Reason, Is.EqualTo(nameof(InvalidOperationException)));
        Assert.That(result.Description, Is.EqualTo("Boom"));
    }

    [Test]
    public async Task Receive_DeadLettersABodyThatIsNotJson()
    {
        var result = await ReceiveAsync(new CatIncomingMessage { Body = "not json"u8.ToArray(), ContentType = "application/json" });

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.DeadLetter));
        Assert.That(result.Reason, Is.EqualTo("InvalidMessage"));
        Assert.That(_processor.SeenRequest, Is.Null);
    }

    [Test]
    public async Task Receive_DeadLettersAnUnsupportedContentType()
    {
        var result = await ReceiveAsync(MessageOf(new { orderNumber = "x" }, "application/xml"));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.DeadLetter));
        Assert.That(result.Reason, Is.EqualTo("UnsupportedContentType"));
    }

    [Test]
    public async Task Receive_TreatsAnEmptyContentTypeAsJson()
    {
        var result = await ReceiveAsync(MessageOf(new { orderNumber = "ORD-1" }, ""));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
    }
}
