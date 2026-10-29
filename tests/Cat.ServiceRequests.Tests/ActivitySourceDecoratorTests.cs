using System.Diagnostics;
using Cat.NUnit;
using Cat.ServiceRequests.Abstractions;
using Cat.ServiceRequests.Decorators.ActivitySource.Extensions;
using Cat.ServiceRequests.Extensions;
using Cat.ServiceRequests.Tests.Helpers;
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

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
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

        Assert.That(_started.Single().GetTagItem("ServiceRequestType"), Is.EqualTo("CreateOrderRequest"));
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
        Assert.That(_started.Single().GetTagItem("ServiceRequestType"), Is.EqualTo("GetOrderRequest"));
    }

    [Test]
    public void TheHandlerThrows_TheActivityIsStillStopped()
    {
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new CreateOrderRequest("throw")));

        Assert.That(_stopped, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task TheDecorator_ReturnsTheResponseOfTheHandlerUntouched()
    {
        var response = await Processor.ProcessAsync(new GetOrderRequest(404));

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.ErrorList.Single().Code, Is.EqualTo("ORD-404"));
    }

    [Test]
    public async Task WithoutAListener_TheRequestStillWorks()
    {
        _listener.Dispose();

        var response = await Processor.ProcessAsync(new CreateOrderRequest("book"));

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_started, Is.Empty);
    }
}
