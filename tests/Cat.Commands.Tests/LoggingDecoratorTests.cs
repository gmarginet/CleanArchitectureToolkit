using Cat.Commands.Abstractions;
using Cat.Commands.Decorators.Logging.Extensions;
using Cat.Commands.Extensions;
using Cat.Commands.Tests.Helpers;
using Cat.NUnit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.Commands.Tests;

[TestFixture]
public class LoggingDecoratorTests : UnitTestBase
{
    private ICatCommandProcessor Processor => ServiceProvider.GetRequiredService<ICatCommandProcessor>();

    private LogCollector Logs => ServiceProvider.GetRequiredService<LogCollector>();

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton<CommandRecorder>();
        services.AddScoped<ScopedMarker>();
        services.AddSingleton<LogCollector>();
        services.AddSingleton(typeof(ILogger<>), typeof(CollectingLogger<>));
        services.AddCatCommandsModule(typeof(RegisterUserCommandHandler));
    }

    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        ServiceProvider.AddCatCommandsModuleLoggingDecorator();
    }

    [SetUp]
    public void SetUp()
    {
        Logs.Clear();
    }

    [Test]
    public async Task SucceededCommand_LogsTheStartAndTheEndAtDebugLevel()
    {
        await Processor.ProcessAsync(new RegisterUserCommand("anna"));

        var entries = Logs.Entries;
        Assert.That(entries.Select(e => e.Level), Is.All.EqualTo(LogLevel.Debug));
        Assert.That(entries.Select(e => e.Message), Is.EqualTo(new[]
        {
            "Start handling Command RegisterUserCommand",
            "Finished handling Command RegisterUserCommand"
        }));
    }

    [Test]
    public async Task FailedCommand_LogsTheStartAndTheErrors()
    {
        await Processor.ProcessAsync(new RegisterUserCommand("fail"));

        var entries = Logs.Entries;
        Assert.That(entries[0].Message, Is.EqualTo("Start handling Command RegisterUserCommand"));
        Assert.That(entries.Skip(1).Select(e => e.Level), Is.All.EqualTo(LogLevel.Error));
        Assert.That(entries.Any(e => e.Message.Contains("Error occurred during handling of Command RegisterUserCommand")), Is.True);
        Assert.That(entries.Any(e => e.Message.Contains("USR-1") && e.Message.Contains("Name fail is not allowed")), Is.True);
        Assert.That(entries.Any(e => e.Message.Contains("USR-2")), Is.True);
        Assert.That(entries.Any(e => e.Message.StartsWith("Finished")), Is.False);
    }

    [Test]
    public async Task TheDecorator_ReturnsTheResponseOfTheHandlerUntouched()
    {
        var response = await Processor.ProcessAsync(new RegisterUserCommand("fail"));

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.ErrorList, Has.Count.EqualTo(2));
    }

    [Test]
    public void TheHandlerThrows_TheExceptionIsNotSwallowed()
    {
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new RegisterUserCommand("throw")));
    }
}
