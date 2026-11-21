using System.Diagnostics;
using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Extensions;
using Cat.Responses;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class TraceTests
{
    private const string TraceId = "0af7651916cd43dd8448eb211c80319c";
    private const string SpanId = "b7ad6b7169203331";

    private ActivityListener _listener = null!;
    private List<Activity> _started = null!;
    private List<Activity?> _currentDuringHandling = null!;
    private ServiceProvider _provider = null!;

    [SetUp]
    public void SetUp()
    {
        _started = [];
        _currentDuringHandling = [];
        _listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == CatEventProcessorTelemetry.SourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            ActivityStarted = activity => _started.Add(activity)
        };
        ActivitySource.AddActivityListener(_listener);

        var services = new ServiceCollection();
        services.AddScoped<ICatServiceRequestProcessor>(_ => new FakeServiceRequestProcessor
        {
            Respond = _ =>
            {
                _currentDuringHandling.Add(Activity.Current);
                return CatResponse.Ok();
            }
        });
        services.AddCatEventProcessor(new ConfigurationBuilder().Build(), builder => builder.Receive<OrderPlaced>());
        _provider = services.BuildServiceProvider();
    }

    [TearDown]
    public void TearDown()
    {
        _listener.Dispose();
        _provider.Dispose();
    }

    private Task<CatSettlementResult> ReceiveAsync(string? diagnosticId)
    {
        var message = new CatIncomingMessage
        {
            Body = Json.Of(new { orderNumber = "ORD-1" }),
            ContentType = "application/json",
            MessageId = "message-1"
        };
        if (diagnosticId != null)
        {
            message.Properties[CatEventProcessorTelemetry.DiagnosticIdProperty] = diagnosticId;
        }

        return _provider.GetRequiredService<ICatMessageReceiver>().ReceiveAsync(typeof(OrderPlaced), message);
    }

    [Test]
    public async Task Receive_ContinuesTheTraceOfTheSenderFromTheDiagnosticId()
    {
        await ReceiveAsync($"00-{TraceId}-{SpanId}-01");

        Assert.That(_started, Has.Count.EqualTo(1));
        var activity = _started[0];
        Assert.That(activity.TraceId.ToString(), Is.EqualTo(TraceId));
        Assert.That(activity.ParentSpanId.ToString(), Is.EqualTo(SpanId));
        Assert.That(activity.Kind, Is.EqualTo(ActivityKind.Consumer));
        Assert.That(activity.OperationName, Is.EqualTo("Cat.EventProcessor.Receive OrderPlaced"));
        Assert.That(_currentDuringHandling.Single(), Is.SameAs(activity));
        Assert.That(Activity.Current, Is.Null);
    }

    [Test]
    public async Task Receive_StartsARootActivityWhenTheMessageHasNoDiagnosticId()
    {
        await ReceiveAsync(null);

        Assert.That(_started, Has.Count.EqualTo(1));
        Assert.That(_started[0].ParentId, Is.Null);
    }

    [Test]
    public async Task Receive_StartsARootActivityWhenTheDiagnosticIdIsNotATraceParent()
    {
        await ReceiveAsync("not-a-traceparent");

        Assert.That(_started, Has.Count.EqualTo(1));
        Assert.That(_started[0].ParentId, Is.Null);
    }

    [Test]
    public async Task Receive_StartsNothingWhenTheCurrentActivityAlreadyBelongsToTheTraceOfTheSender()
    {
        using var source = new ActivitySource("Test.Sdk");
        using var sdkListener = new ActivityListener
        {
            ShouldListenTo = s => s.Name == "Test.Sdk",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData
        };
        ActivitySource.AddActivityListener(sdkListener);
        var parent = ActivityContext.Parse($"00-{TraceId}-{SpanId}-01", null);
        using var sdkActivity = source.StartActivity("sdk", ActivityKind.Consumer, parent);

        await ReceiveAsync($"00-{TraceId}-{SpanId}-01");

        Assert.That(_started, Is.Empty);
        Assert.That(_currentDuringHandling.Single(), Is.SameAs(sdkActivity));
    }

    [Test]
    public async Task Receive_StartsNothingWhenNobodyListensToTheSource()
    {
        _listener.Dispose();

        await ReceiveAsync($"00-{TraceId}-{SpanId}-01");

        Assert.That(_started, Is.Empty);
        Assert.That(_currentDuringHandling.Single(), Is.Null);
    }
}
