using Cat.Expressions.Extensions;
using Cat.NUnit;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.ServiceRequests.Decorators.Validation.Extensions;
using Cat.ServiceRequests.Extensions;
using Cat.ServiceRequests.Tests.Helpers;
using Cat.Validators.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.ServiceRequests.Tests;

/// <summary>
/// Validation is optional here: a request without a validator goes straight to its handler.
/// </summary>
[TestFixture]
public class ValidationDecoratorTests : UnitTestBase
{
    private ICatServiceRequestProcessor Processor => ServiceProvider.GetRequiredService<ICatServiceRequestProcessor>();

    private RequestRecorder Recorder => ServiceProvider.GetRequiredService<RequestRecorder>();

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton<RequestRecorder>();
        services.AddScoped<ScopedMarker>();
        services.AddCatCompiledMemberExpressionCache();
        services.AddCatValidatorsModule(typeof(CreateOrderRequestValidator));
        services.AddCatServiceRequestsModule(typeof(CreateOrderRequestHandler));
    }

    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        ServiceProvider.AddCatServiceRequestsModuleValidationDecorator();
    }

    [SetUp]
    public void SetUp()
    {
        Recorder.Calls.Clear();
    }

    #region Requests without a payload

    [Test]
    public async Task ValidRequest_GoesToTheHandler()
    {
        var response = await Processor.ProcessAsync(new CreateOrderRequest("book"));

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(Recorder.Calls, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task InvalidRequest_NeverReachesTheHandler()
    {
        var response = await Processor.ProcessAsync(new CreateOrderRequest(""));

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.BadRequest>());
        Assert.That(Recorder.Calls, Is.Empty);
    }

    [Test]
    public async Task InvalidRequest_ReturnsTheValidationErrors()
    {
        var response = await Processor.ProcessAsync(new CreateOrderRequest(""));

        var error = response.ErrorList.Single();
        Assert.That(error.Code, Is.EqualTo("CAT-VAL-1003"));
        Assert.That(error.Arguments[0], Is.EqualTo("Name"));
    }

    [Test]
    public async Task RequestWithoutAValidator_GoesToTheHandler()
    {
        var response = await Processor.ProcessAsync(new NoValidatorRequest());

        Assert.That(response.IsSucceeded, Is.True);
    }

    [Test]
    public async Task ValidRequest_AFailureOfTheHandlerIsStillReturned()
    {
        var response = await Processor.ProcessAsync(new CreateOrderRequest("fail"));

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.ErrorList.Single().Code, Is.EqualTo("ORD-1"));
    }

    #endregion Requests without a payload

    #region Requests with a payload

    [Test]
    public async Task ValidRequestWithPayload_GoesToTheHandler()
    {
        var response = await Processor.ProcessAsync(new GetOrderRequest(5));

        Assert.That(response.Value, Is.EqualTo("order:5"));
        Assert.That(Recorder.Calls, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task InvalidRequestWithPayload_NeverReachesTheHandler()
    {
        var response = await Processor.ProcessAsync(new GetOrderRequest(0));

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.BadRequest>());
        Assert.That(response.Value, Is.Null);
        Assert.That(Recorder.Calls, Is.Empty);
    }

    [Test]
    public async Task InvalidRequestWithPayload_ReturnsTheValidationErrors()
    {
        var response = await Processor.ProcessAsync(new GetOrderRequest(0));

        var error = response.ErrorList.Single();
        Assert.That(error.Code, Is.EqualTo("CAT-VAL-1014"));
        Assert.That(error.Arguments[0], Is.EqualTo("Id"));
    }

    [Test]
    public async Task RequestWithPayloadWithoutAValidator_GoesToTheHandler()
    {
        var response = await Processor.ProcessAsync(new NoValidatorTypedRequest());

        Assert.That(response.Value, Is.EqualTo("no validator"));
    }

    #endregion Requests with a payload
}

/// <summary>
/// Validation is required here: a request without a validator is an error.
/// </summary>
[TestFixture]
public class ValidationRequiredDecoratorTests : UnitTestBase
{
    private ICatServiceRequestProcessor Processor => ServiceProvider.GetRequiredService<ICatServiceRequestProcessor>();

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton<RequestRecorder>();
        services.AddScoped<ScopedMarker>();
        services.AddCatCompiledMemberExpressionCache();
        services.AddCatValidatorsModule(typeof(CreateOrderRequestValidator));
        services.AddCatServiceRequestsModule(typeof(CreateOrderRequestHandler));
    }

    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        ServiceProvider.AddCatServiceRequestsModuleValidationDecorator(validationRequired: true);
    }

    [Test]
    public void RequestWithoutAValidator_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => Processor.Process(new NoValidatorRequest()));
    }

    [Test]
    public void RequestWithPayloadWithoutAValidator_Throws()
    {
        Assert.ThrowsAsync<InvalidOperationException>(async () => await Processor.ProcessAsync(new NoValidatorTypedRequest()));
    }

    [Test]
    public async Task RequestWithAValidator_StillWorks()
    {
        var response = await Processor.ProcessAsync(new CreateOrderRequest("book"));

        Assert.That(response.IsSucceeded, Is.True);
    }

    [Test]
    public void AddCatServiceRequestsModuleValidationDecorator_ReturnsTheServiceProvider()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatServiceRequestsModule(typeof(CreateOrderRequestHandler));
        using var provider = services.BuildServiceProvider();

        var returned = provider.AddCatServiceRequestsModuleValidationDecorator(validationRequired: true);

        Assert.That(returned, Is.SameAs(provider));
    }
}
