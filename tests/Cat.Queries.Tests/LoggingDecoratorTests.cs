using Cat.NUnit;
using Cat.Queries.Abstractions;
using Cat.Queries.Decorators.Logging.Extensions;
using Cat.Queries.Extensions;
using Cat.Queries.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.Queries.Tests;

[TestFixture]
public class LoggingDecoratorTests : UnitTestBase
{
    private ICatQueryProcessor Processor => ServiceProvider.GetRequiredService<ICatQueryProcessor>();

    private LogCollector Logs => ServiceProvider.GetRequiredService<LogCollector>();

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton<QueryRecorder>();
        services.AddScoped<ScopedMarker>();
        services.AddSingleton<LogCollector>();
        services.AddSingleton(typeof(ILogger<>), typeof(CollectingLogger<>));
        services.AddCatQueriesModule(typeof(GetUserQueryHandler));
    }

    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        ServiceProvider.AddCatQueriesModuleLoggingDecorator();
    }

    [SetUp]
    public void SetUp()
    {
        Logs.Clear();
    }

    [Test]
    public async Task SucceededQuery_LogsTheStartAndTheEndAtDebugLevel()
    {
        await Processor.ProcessAsync(new GetUserQuery("anna"));

        var entries = Logs.Entries;
        Assert.That(entries.Select(e => e.Level), Is.All.EqualTo(LogLevel.Debug));
        Assert.That(entries.Select(e => e.Message), Is.EqualTo(new[]
        {
            "Start handling Query GetUserQuery",
            "Finished handling Query GetUserQuery"
        }));
    }

    [Test]
    public async Task FailedQuery_LogsTheStartAndTheErrors()
    {
        await Processor.ProcessAsync(new GetUserQuery("missing"));

        var entries = Logs.Entries;
        Assert.That(entries[0].Message, Is.EqualTo("Start handling Query GetUserQuery"));
        Assert.That(entries.Skip(1).Select(e => e.Level), Is.All.EqualTo(LogLevel.Error));
        Assert.That(entries.Any(e => e.Message.Contains("Error occurred during handling of Query GetUserQuery")), Is.True);
        Assert.That(entries.Any(e => e.Message.Contains("USR-404") && e.Message.Contains("User missing was not found")), Is.True);
        Assert.That(entries.Any(e => e.Message.StartsWith("Finished")), Is.False);
    }

    [Test]
    public async Task TheDecorator_ReturnsTheResponseOfTheHandlerUntouched()
    {
        var response = await Processor.ProcessAsync(new GetUserQuery("anna"));

        Assert.That(response.Value, Is.EqualTo("user:anna"));
    }

    [Test]
    public void TheHandlerThrows_TheExceptionIsNotSwallowed()
    {
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new GetUserQuery("throw")));
    }
}
