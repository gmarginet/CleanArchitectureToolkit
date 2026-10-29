using Cat.Decorators.Abstractions;
using Cat.NUnit;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.ServiceRequests.Extensions;
using Cat.ServiceRequests.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.ServiceRequests.Tests;

[TestFixture]
public class ServiceRequestProcessorTests : UnitTestBase
{
    private ICatServiceRequestProcessor Processor => ServiceProvider.GetRequiredService<ICatServiceRequestProcessor>();

    private RequestRecorder Recorder => ServiceProvider.GetRequiredService<RequestRecorder>();

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton<RequestRecorder>();
        services.AddScoped<ScopedMarker>();
        services.AddCatServiceRequestsModule(typeof(CreateOrderRequestHandler));
    }

    [SetUp]
    public void SetUp()
    {
        Recorder.Calls.Clear();
    }

    #region Requests without a payload

    [Test]
    public async Task ProcessAsync_RunsTheHandlerAndReturnsItsResponse()
    {
        var response = await Processor.ProcessAsync(new CreateOrderRequest("book"));

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(Recorder.Calls.Select(c => c.Request), Is.EqualTo(new[] { "CreateOrderRequest:book" }));
    }

    [Test]
    public async Task ProcessAsync_AFailedResponse_IsReturnedWithItsErrors()
    {
        var response = await Processor.ProcessAsync(new CreateOrderRequest("fail"));

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.ErrorList.Single().Code, Is.EqualTo("ORD-1"));
    }

    [Test]
    public async Task ProcessAsync_PassesTheCancellationTokenToTheHandler()
    {
        using var source = new CancellationTokenSource();

        await Processor.ProcessAsync(new CreateOrderRequest("book"), source.Token);

        Assert.That(Recorder.Calls.Single().Token, Is.EqualTo(source.Token));
    }

    [Test]
    public void ProcessAsync_TheHandlerThrows_TheExceptionReachesTheCaller()
    {
        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new CreateOrderRequest("throw")));

        Assert.That(exception!.Message, Is.EqualTo("boom"));
    }

    [Test]
    public void ProcessAsync_NoHandlerIsRegistered_Throws()
    {
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new UnhandledRequest()));
    }

    [Test]
    public void Process_RunsTheHandlerAndWaitsForIt()
    {
        var response = Processor.Process(new CreateOrderRequest("book"));

        Assert.That(response.IsSucceeded, Is.True);
    }

    [Test]
    public void Process_NoHandlerIsRegistered_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => Processor.Process(new UnhandledRequest()));
    }

    #endregion Requests without a payload

    #region Requests with a payload

    [Test]
    public async Task ProcessAsyncWithPayload_RunsTheHandlerAndReturnsTheValue()
    {
        var response = await Processor.ProcessAsync(new GetOrderRequest(5));

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.Value, Is.EqualTo("order:5"));
    }

    [Test]
    public async Task ProcessAsyncWithPayload_AFailedResponse_IsReturnedWithItsErrors()
    {
        var response = await Processor.ProcessAsync(new GetOrderRequest(404));

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.NotFound>());
        Assert.That(response.ErrorList.Single().Code, Is.EqualTo("ORD-404"));
    }

    [Test]
    public async Task ProcessAsyncWithPayload_PassesTheCancellationTokenToTheHandler()
    {
        using var source = new CancellationTokenSource();

        await Processor.ProcessAsync(new GetOrderRequest(5), source.Token);

        Assert.That(Recorder.Calls.Single().Token, Is.EqualTo(source.Token));
    }

    [Test]
    public void ProcessAsyncWithPayload_TheHandlerThrows_TheExceptionReachesTheCaller()
    {
        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new GetOrderRequest(500)));

        Assert.That(exception!.Message, Is.EqualTo("boom"));
    }

    [Test]
    public void ProcessAsyncWithPayload_NoHandlerIsRegistered_Throws()
    {
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new UnhandledTypedRequest()));
    }

    [Test]
    public void ProcessWithPayload_RunsTheHandlerAndWaitsForIt()
    {
        var response = Processor.Process(new GetOrderRequest(7));

        Assert.That(response.Value, Is.EqualTo("order:7"));
    }

    [Test]
    public void ProcessWithPayload_NoHandlerIsRegistered_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => Processor.Process(new UnhandledTypedRequest()));
    }

    #endregion Requests with a payload

    #region Scopes

    [Test]
    public async Task ProcessAsync_EachCallRunsInItsOwnScope()
    {
        await Processor.ProcessAsync(new CreateOrderRequest("one"));
        await Processor.ProcessAsync(new GetOrderRequest(2));
        await Processor.ProcessAsync(new CreateOrderRequest("three"));

        Assert.That(Recorder.Calls.Select(c => c.ScopeId).Distinct().Count(), Is.EqualTo(3));
    }

    [Test]
    public async Task ProcessAsync_CallsAtTheSameTime_DoNotShareAScope()
    {
        await Task.WhenAll(System.Linq.Enumerable.Range(0, 20)
            .Select(i => Processor.ProcessAsync(new GetOrderRequest(i + 1))));

        Assert.That(Recorder.Calls.Select(c => c.ScopeId).Distinct().Count(), Is.EqualTo(20));
    }

    #endregion Scopes

    #region Registration

    [Test]
    public void AddCatServiceRequestsModule_RegistersTheProcessorAsScoped()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatServiceRequestsModule(typeof(CreateOrderRequestHandler));

        var descriptor = services.Single(s => s.ServiceType == typeof(ICatServiceRequestProcessor));

        Assert.That(descriptor.Lifetime, Is.EqualTo(ServiceLifetime.Scoped));
    }

    [Test]
    public void AddCatServiceRequestsModule_RegistersBothKindsOfHandlersAsScoped()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatServiceRequestsModule(typeof(CreateOrderRequestHandler));

        var withoutPayload = services.Single(s => s.ServiceType == typeof(ICatServiceRequestHandler<CreateOrderRequest>));
        var withPayload = services.Single(s => s.ServiceType == typeof(ICatServiceRequestHandler<GetOrderRequest, string>));

        Assert.That(withoutPayload.Lifetime, Is.EqualTo(ServiceLifetime.Scoped));
        Assert.That(withPayload.Lifetime, Is.EqualTo(ServiceLifetime.Scoped));
    }

    [Test]
    public void AddCatServiceRequestsModule_SkipsGenericHandlers()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatServiceRequestsModule(typeof(CreateOrderRequestHandler));

        Assert.That(services.Any(s => s.ImplementationType == typeof(GenericRequestHandler<>)), Is.False);
    }

    [Test]
    public void AddCatServiceRequestsModule_AlsoRegistersTheDecoratorsModule()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatServiceRequestsModule(typeof(CreateOrderRequestHandler));

        Assert.That(services.Any(s => s.ServiceType == typeof(ICatDecoratorFactory)), Is.True);
        Assert.That(services.Any(s => s.ServiceType == typeof(ICatDecoratorFactoryBuilder)), Is.True);
    }

    [Test]
    public void AddCatServiceRequestsModule_WhenTheDecoratorsModuleIsAlreadyThere_DoesNotRegisterItAgain()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        Cat.Decorators.Extensions.ServiceCollectionExtensions.AddCatDecoratorsModule(services);

        services.AddCatServiceRequestsModule(typeof(CreateOrderRequestHandler));

        Assert.That(services.Count(s => s.ServiceType == typeof(ICatDecoratorFactory)), Is.EqualTo(1));
    }

    #endregion Registration
}
