using Cat.Decorators.Abstractions;
using Cat.NUnit;
using Cat.Queries.Abstractions;
using Cat.Queries.Extensions;
using Cat.Queries.Tests.Helpers;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.Queries.Tests;

[TestFixture]
public class QueryProcessorTests : UnitTestBase
{
    private ICatQueryProcessor Processor => ServiceProvider.GetRequiredService<ICatQueryProcessor>();

    private QueryRecorder Recorder => ServiceProvider.GetRequiredService<QueryRecorder>();

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton<QueryRecorder>();
        services.AddScoped<ScopedMarker>();
        services.AddSingleton<LogCollector>();
        services.AddSingleton(typeof(ILogger<>), typeof(CollectingLogger<>));
        services.AddCatQueriesModule(typeof(GetUserQueryHandler));
    }

    [SetUp]
    public void SetUp()
    {
        Recorder.Calls.Clear();
    }

    #region Processing

    [Test]
    public async Task ProcessAsync_RunsTheHandlerAndReturnsTheValue()
    {
        var response = await Processor.ProcessAsync(new GetUserQuery("anna"));

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.Value, Is.EqualTo("user:anna"));
        Assert.That(Recorder.Calls.Select(c => c.Name), Is.EqualTo(new[] { "anna" }));
    }

    [Test]
    public async Task ProcessAsync_TwoQueryTypes_EachGoToTheirOwnHandler()
    {
        var user = await Processor.ProcessAsync(new GetUserQuery("anna"));
        var count = await Processor.ProcessAsync(new GetCountQuery());

        Assert.That(user.Value, Is.EqualTo("user:anna"));
        Assert.That(count.Value, Is.EqualTo(3));
    }

    [Test]
    public async Task ProcessAsync_AFailedResponse_IsReturnedWithItsErrors()
    {
        var response = await Processor.ProcessAsync(new GetUserQuery("missing"));

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.NotFound>());
        Assert.That(response.ErrorList.Single().Code, Is.EqualTo("USR-404"));
        Assert.That(response.Value, Is.Null);
    }

    [Test]
    public async Task ProcessAsync_PassesTheCancellationTokenToTheHandler()
    {
        using var source = new CancellationTokenSource();

        await Processor.ProcessAsync(new GetUserQuery("anna"), source.Token);

        Assert.That(Recorder.Calls.Single().Token, Is.EqualTo(source.Token));
    }

    [Test]
    public void ProcessAsync_TheHandlerThrows_TheExceptionReachesTheCaller()
    {
        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new GetUserQuery("throw")));

        Assert.That(exception!.Message, Is.EqualTo("boom"));
    }

    [Test]
    public void ProcessAsync_NoHandlerIsRegistered_Throws()
    {
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new UnhandledQuery()));
    }

    [Test]
    public void Process_RunsTheHandlerAndWaitsForIt()
    {
        var response = Processor.Process(new GetUserQuery("anna"));

        Assert.That(response.Value, Is.EqualTo("user:anna"));
    }

    [Test]
    public void Process_NoHandlerIsRegistered_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => Processor.Process(new UnhandledQuery()));
    }

    #endregion Processing

    #region Scopes

    [Test]
    public async Task ProcessAsync_EachCallRunsInItsOwnScope()
    {
        await Processor.ProcessAsync(new GetUserQuery("one"));
        await Processor.ProcessAsync(new GetUserQuery("two"));

        var scopeIds = Recorder.Calls.Select(c => c.ScopeId).ToList();
        Assert.That(scopeIds[1], Is.Not.EqualTo(scopeIds[0]));
    }

    [Test]
    public async Task ProcessAsync_CallsAtTheSameTime_DoNotShareAScope()
    {
        await Task.WhenAll(Enumerable.Range(0, 20)
            .Select(i => Processor.ProcessAsync(new GetUserQuery("q" + i))));

        Assert.That(Recorder.Calls.Select(c => c.ScopeId).Distinct().Count(), Is.EqualTo(20));
    }

    #endregion Scopes

    #region Registration

    [Test]
    public void AddCatQueriesModule_RegistersTheProcessorAsScoped()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatQueriesModule(typeof(GetUserQueryHandler));

        var descriptor = services.Single(s => s.ServiceType == typeof(ICatQueryProcessor));

        Assert.That(descriptor.Lifetime, Is.EqualTo(ServiceLifetime.Scoped));
    }

    [Test]
    public void AddCatQueriesModule_RegistersTheHandlersAsScoped()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatQueriesModule(typeof(GetUserQueryHandler));

        var descriptor = services.Single(s => s.ServiceType == typeof(ICatQueryHandler<GetUserQuery, string>));

        Assert.That(descriptor.Lifetime, Is.EqualTo(ServiceLifetime.Scoped));
        Assert.That(descriptor.ImplementationType, Is.EqualTo(typeof(GetUserQueryHandler)));
    }

    [Test]
    public void AddCatQueriesModule_SkipsGenericHandlers()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatQueriesModule(typeof(GetUserQueryHandler));

        Assert.That(services.Any(s => s.ImplementationType == typeof(GenericQueryHandler<>)), Is.False);
    }

    [Test]
    public void AddCatQueriesModule_AlsoRegistersTheDecoratorsModule()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatQueriesModule(typeof(GetUserQueryHandler));

        Assert.That(services.Any(s => s.ServiceType == typeof(ICatDecoratorFactory)), Is.True);
        Assert.That(services.Any(s => s.ServiceType == typeof(ICatDecoratorFactoryBuilder)), Is.True);
    }

    [Test]
    public void AddCatQueriesModule_WhenTheDecoratorsModuleIsAlreadyThere_DoesNotRegisterItAgain()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        Cat.Decorators.Extensions.ServiceCollectionExtensions.AddCatDecoratorsModule(services);

        services.AddCatQueriesModule(typeof(GetUserQueryHandler));

        Assert.That(services.Count(s => s.ServiceType == typeof(ICatDecoratorFactory)), Is.EqualTo(1));
    }

    #endregion Registration
}
