using System.Diagnostics;
using System.Diagnostics.Metrics;
using Cat.UnitTesting.NUnit;
using Cat.ServiceRequests.Abstractions;
using Cat.ServiceRequests.Decorators.ActivitySource.Extensions;
using Cat.ServiceRequests.Extensions;
using Cat.ServiceRequests.Tests.Helpers;
using Cat.UnitTesting.Responses.NUnit;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.ServiceRequests.Tests;

[TestFixture]
public class ActivitySourceDecoratorTests : UnitTestBase
{
    private const string SourceName = "Cat.ServiceRequests";

    private ActivityListener _listener = null!;
    private readonly List<Activity> _started = [];
    private readonly List<Activity> _stopped = [];

    private ICatServiceRequestProcessor Processor => ServiceProvider.GetRequiredService<ICatServiceRequestProcessor>();

    protected override void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<RequestRecorder>();
        services.AddScoped<ScopedMarker>();
        services.AddCatServiceRequestsModule(typeof(CreateOrderRequestHandler));
    }

    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        ServiceProvider.AddCatServiceRequestsModuleActivitySourceDecorator();
    }

    [SetUp]
    public void SetUp()
    {
        _started.Clear();
        _stopped.Clear();

        _listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == SourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStarted = activity => { lock (_started) _started.Add(activity); },
            ActivityStopped = activity => { lock (_stopped) _stopped.Add(activity); }
        };
        ActivitySource.AddActivityListener(_listener);
    }

    [TearDown]
    public void TearDown()
    {
        _listener.Dispose();
    }

    [Test]
    public async Task Request_StartsAndStopsOneActivity()
    {
        await Processor.ProcessAsync(new CreateOrderRequest("book"));

        Assert.That(_started, Has.Count.EqualTo(1));
        Assert.That(_stopped, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task Request_TheActivityIsNamedAfterTheRequest()
    {
        await Processor.ProcessAsync(new CreateOrderRequest("book"));

        Assert.That(_started.Single().DisplayName, Is.EqualTo("Start handling ServiceRequest CreateOrderRequest"));
    }

    [Test]
    public async Task Request_TheActivityHasTheRequestTypeAsATag()
    {
        await Processor.ProcessAsync(new CreateOrderRequest("book"));

        Assert.That(_started.Single().GetTagItem("cat.service_requests.type"), Is.EqualTo("CreateOrderRequest"));
    }

    [Test]
    public async Task Request_TheActivityIsAClientActivity()
    {
        await Processor.ProcessAsync(new CreateOrderRequest("book"));

        Assert.That(_started.Single().Kind, Is.EqualTo(ActivityKind.Client));
    }

    [Test]
    public async Task RequestWithPayload_StartsAndStopsOneActivityWithTheSameName()
    {
        await Processor.ProcessAsync(new GetOrderRequest(5));

        Assert.That(_started, Has.Count.EqualTo(1));
        Assert.That(_stopped, Has.Count.EqualTo(1));
        Assert.That(_started.Single().DisplayName, Is.EqualTo("Start handling ServiceRequest GetOrderRequest"));
        Assert.That(_started.Single().GetTagItem("cat.service_requests.type"), Is.EqualTo("GetOrderRequest"));
    }

    [Test]
    public async Task TheHandlerThrows_TheActivityIsStillStopped()
    {
        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new CreateOrderRequest("throw")));

        Assert.That(_stopped, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task TheDecorator_ReturnsTheResponseOfTheHandlerUntouched()
    {
        var response = await Processor.ProcessAsync(new GetOrderRequest(404));

        Assert.That(response, CatIs.Failed);
        Assert.That(response.ErrorList.Single().Code, Is.EqualTo("ORD-404"));
    }

    [Test]
    public async Task WithoutAListener_TheRequestStillWorks()
    {
        _listener.Dispose();

        var response = await Processor.ProcessAsync(new CreateOrderRequest("book"));

        Assert.That(response, CatIs.Succeeded);
        Assert.That(_started, Is.Empty);
    }

    private sealed record Measured(string Instrument, string Type, string Outcome, double Value);

    private static List<Measured> Listen(out MeterListener listener)
    {
        var measured = new List<Measured>();
        var meterListener = new MeterListener
        {
            InstrumentPublished = (instrument, l) =>
            {
                if (instrument.Meter.Name == SourceName)
                {
                    l.EnableMeasurementEvents(instrument);
                }
            }
        };
        meterListener.SetMeasurementEventCallback<long>((instrument, value, tags, _) => Add(measured, instrument, value, tags));
        meterListener.SetMeasurementEventCallback<double>((instrument, value, tags, _) => Add(measured, instrument, value, tags));
        meterListener.Start();
        listener = meterListener;
        return measured;
    }

    private static void Add(List<Measured> measured, Instrument instrument, double value, ReadOnlySpan<KeyValuePair<string, object?>> tags)
    {
        string? type = null;
        string? outcome = null;
        foreach (var tag in tags)
        {
            if (tag.Key == "type") type = (string?)tag.Value;
            if (tag.Key == "outcome") outcome = (string?)tag.Value;
        }

        lock (measured) measured.Add(new Measured(instrument.Name, type ?? "", outcome ?? "", value));
    }

    [Test]
    public async Task ASucceededRequest_IsCountedAndTimedWithTheTypeAndTheOutcome()
    {
        var measured = Listen(out var listener);
        using (listener)
        {
            await Processor.ProcessAsync(new CreateOrderRequest("book"));
        }

        Assert.That(measured.Count(m => m.Instrument == "cat.service_requests.calls" && m.Type == "CreateOrderRequest" && m.Outcome == "success" && m.Value == 1), Is.EqualTo(1));
        Assert.That(measured.Count(m => m.Instrument == "cat.service_requests.duration" && m.Type == "CreateOrderRequest" && m.Outcome == "success" && m.Value >= 0), Is.EqualTo(1));
    }

    [Test]
    public async Task AFailedResponse_HasTheOutcomeFailed()
    {
        var measured = Listen(out var listener);
        using (listener)
        {
            await Processor.ProcessAsync(new GetOrderRequest(404));
        }

        Assert.That(measured.Count(m => m.Instrument == "cat.service_requests.calls" && m.Type == "GetOrderRequest" && m.Outcome == "failed"), Is.EqualTo(1));
    }

    [Test]
    public async Task AHandlerThatThrows_HasTheOutcomeException()
    {
        var measured = Listen(out var listener);
        using (listener)
        {
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await Processor.ProcessAsync(new CreateOrderRequest("throw")));
        }

        Assert.That(measured.Count(m => m.Instrument == "cat.service_requests.calls" && m.Type == "CreateOrderRequest" && m.Outcome == "exception"), Is.EqualTo(1));
    }
}