using Cat.Commands.Abstractions;
using Cat.Commands.Extensions;
using Cat.Commands.Tests.Helpers;
using Cat.Decorators.Abstractions;
using Cat.NUnit;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.Commands.Tests;

[TestFixture]
public class CommandProcessorTests : UnitTestBase
{
    private ICatCommandProcessor Processor => ServiceProvider.GetRequiredService<ICatCommandProcessor>();

    private CommandRecorder Recorder => ServiceProvider.GetRequiredService<CommandRecorder>();

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton<CommandRecorder>();
        services.AddScoped<ScopedMarker>();
        services.AddSingleton<LogCollector>();
        services.AddSingleton(typeof(ILogger<>), typeof(CollectingLogger<>));
        services.AddCatCommandsModule(typeof(RegisterUserCommandHandler));
    }

    [SetUp]
    public void SetUp()
    {
        Recorder.Calls.Clear();
    }

    #region Processing

    [Test]
    public async Task ProcessAsync_RunsTheHandlerAndReturnsItsResponse()
    {
        var response = await Processor.ProcessAsync(new RegisterUserCommand("anna"));

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(Recorder.Calls.Select(c => c.Name), Is.EqualTo(new[] { "anna" }));
    }

    [Test]
    public async Task ProcessAsync_AFailedResponse_IsReturnedWithItsErrors()
    {
        var response = await Processor.ProcessAsync(new RegisterUserCommand("fail"));

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.BadRequest>());
        Assert.That(response.ErrorList.Select(e => e.Code), Is.EqualTo(new[] { "USR-1", "USR-2" }));
    }

    [Test]
    public async Task ProcessAsync_PassesTheCancellationTokenToTheHandler()
    {
        using var source = new CancellationTokenSource();

        await Processor.ProcessAsync(new RegisterUserCommand("anna"), source.Token);

        Assert.That(Recorder.Calls.Single().Token, Is.EqualTo(source.Token));
    }

    [Test]
    public void ProcessAsync_TheHandlerThrows_TheExceptionReachesTheCaller()
    {
        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new RegisterUserCommand("throw")));

        Assert.That(exception!.Message, Is.EqualTo("boom"));
    }

    [Test]
    public void ProcessAsync_NoHandlerIsRegistered_Throws()
    {
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new UnhandledCommand()));
    }

    [Test]
    public void Process_RunsTheHandlerAndWaitsForIt()
    {
        var response = Processor.Process(new RegisterUserCommand("anna"));

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(Recorder.Calls, Has.Count.EqualTo(1));
    }

    [Test]
    public void Process_AFailedResponse_IsReturned()
    {
        var response = Processor.Process(new RegisterUserCommand("fail"));

        Assert.That(response.IsFailed, Is.True);
    }

    [Test]
    public void Process_NoHandlerIsRegistered_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => Processor.Process(new UnhandledCommand()));
    }

    #endregion Processing

    #region Scopes

    [Test]
    public async Task ProcessAsync_EachCallRunsInItsOwnScope()
    {
        await Processor.ProcessAsync(new RegisterUserCommand("one"));
        await Processor.ProcessAsync(new RegisterUserCommand("two"));

        var scopeIds = Recorder.Calls.Select(c => c.ScopeId).ToList();
        Assert.That(scopeIds, Has.Count.EqualTo(2));
        Assert.That(scopeIds[1], Is.Not.EqualTo(scopeIds[0]));
    }

    [Test]
    public async Task ProcessAsync_CallsAtTheSameTime_DoNotShareAScope()
    {
        await Task.WhenAll(Enumerable.Range(0, 20)
            .Select(i => Processor.ProcessAsync(new RegisterUserCommand("c" + i))));

        Assert.That(Recorder.Calls.Select(c => c.ScopeId).Distinct().Count(), Is.EqualTo(20));
    }

    #endregion Scopes

    #region Registration

    [Test]
    public void AddCatCommandsModule_RegistersTheProcessorAsScoped()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatCommandsModule(typeof(RegisterUserCommandHandler));

        var descriptor = services.Single(s => s.ServiceType == typeof(ICatCommandProcessor));

        Assert.That(descriptor.Lifetime, Is.EqualTo(ServiceLifetime.Scoped));
    }

    [Test]
    public void AddCatCommandsModule_RegistersTheHandlersAsScoped()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatCommandsModule(typeof(RegisterUserCommandHandler));

        var descriptor = services.Single(s => s.ServiceType == typeof(ICatCommandHandler<RegisterUserCommand>)
                                              && s.ImplementationType == typeof(RegisterUserCommandHandler));

        Assert.That(descriptor.Lifetime, Is.EqualTo(ServiceLifetime.Scoped));
    }

    [Test]
    public void AddCatCommandsModule_SkipsGenericHandlers()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatCommandsModule(typeof(RegisterUserCommandHandler));

        Assert.That(services.Any(s => s.ImplementationType == typeof(GenericCommandHandler<>)), Is.False);
    }

    [Test]
    public void AddCatCommandsModule_AlsoRegistersTheDecoratorsModule()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatCommandsModule(typeof(RegisterUserCommandHandler));

        Assert.That(services.Any(s => s.ServiceType == typeof(ICatDecoratorFactory)), Is.True);
        Assert.That(services.Any(s => s.ServiceType == typeof(ICatDecoratorFactoryBuilder)), Is.True);
    }

    [Test]
    public void AddCatCommandsModule_WhenTheDecoratorsModuleIsAlreadyThere_DoesNotRegisterItAgain()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        Cat.Decorators.Extensions.ServiceCollectionExtensions.AddCatDecoratorsModule(services);

        services.AddCatCommandsModule(typeof(RegisterUserCommandHandler));

        Assert.That(services.Count(s => s.ServiceType == typeof(ICatDecoratorFactory)), Is.EqualTo(1));
    }

    #endregion Registration
}
