using Cat.NUnit;
using Cat.ServiceRequests.Abstractions;
using Cat.ServiceRequests.Decorators.Logging.Extensions;
using Cat.ServiceRequests.Extensions;
using Cat.ServiceRequests.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.ServiceRequests.Tests;

[TestFixture]
public class LoggingDecoratorTests : UnitTestBase
{
    private ICatServiceRequestProcessor Processor => ServiceProvider.GetRequiredService<ICatServiceRequestProcessor>();

    private LogCollector Logs => ServiceProvider.GetRequiredService<LogCollector>();

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton<RequestRecorder>();
        services.AddScoped<ScopedMarker>();
        services.AddSingleton<LogCollector>();
        services.AddSingleton(typeof(ILogger<>), typeof(CollectingLogger<>));
        services.AddCatServiceRequestsModule(typeof(CreateOrderRequestHandler));
    }

    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        ServiceProvider.AddCatServiceRequestsModuleLoggingDecorator();
    }

    [SetUp]
    public void SetUp()
    {
        Logs.Clear();
    }

    [Test]
    public async Task SucceededRequest_LogsTheStartAndTheEndAtDebugLevel()
    {
        await Processor.ProcessAsync(new CreateOrderRequest("book"));

        var entries = Logs.Entries;
        Assert.That(entries.Select(e => e.Level), Is.All.EqualTo(LogLevel.Debug));
        Assert.That(entries.Select(e => e.Message), Is.EqualTo(new[]
        {
            "Start handling ServiceRequest CreateOrderRequest",
            "Finished handling ServiceRequest CreateOrderRequest"
        }));
    }

    [Test]
    public async Task FailedRequest_LogsTheStartAndTheErrors()
    {
        await Processor.ProcessAsync(new CreateOrderRequest("fail"));

        var entries = Logs.Entries;
        Assert.That(entries[0].Message, Is.EqualTo("Start handling ServiceRequest CreateOrderRequest"));
        Assert.That(entries.Skip(1).Select(e => e.Level), Is.All.EqualTo(LogLevel.Error));
        Assert.That(entries.Any(e => e.Message.Contains("Error occurred during handling of ServiceRequest CreateOrderRequest")), Is.True);
        Assert.That(entries.Any(e => e.Message.Contains("ORD-1") && e.Message.Contains("Order fail failed")), Is.True);
        Assert.That(entries.Any(e => e.Message.StartsWith("Finished")), Is.False);
    }

    [Test]
    public async Task SucceededRequestWithPayload_LogsTheStartAndTheEndAtDebugLevel()
    {
        await Processor.ProcessAsync(new GetOrderRequest(5));

        Assert.That(Logs.Entries.Select(e => e.Message), Is.EqualTo(new[]
        {
            "Start handling ServiceRequest GetOrderRequest",
            "Finished handling ServiceRequest GetOrderRequest"
        }));
    }

    [Test]
    public async Task FailedRequestWithPayload_LogsTheStartAndTheErrors()
    {
        await Processor.ProcessAsync(new GetOrderRequest(404));

        var entries = Logs.Entries;
        Assert.That(entries[0].Message, Is.EqualTo("Start handling ServiceRequest GetOrderRequest"));
        Assert.That(entries.Any(e => e.Level == LogLevel.Error && e.Message.Contains("ORD-404")), Is.True);
        Assert.That(entries.Any(e => e.Message.StartsWith("Finished")), Is.False);
    }

    [Test]
    public async Task TheDecorator_ReturnsTheResponseOfTheHandlerUntouched()
    {
        var response = await Processor.ProcessAsync(new GetOrderRequest(5));

        Assert.That(response.Value, Is.EqualTo("order:5"));
    }

    [Test]
    public void TheHandlerThrows_TheExceptionIsNotSwallowed()
    {
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Processor.ProcessAsync(new CreateOrderRequest("throw")));
    }
}
