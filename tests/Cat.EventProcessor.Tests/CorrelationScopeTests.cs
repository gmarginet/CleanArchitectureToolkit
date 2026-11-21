using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Extensions;
using Cat.Responses;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class CorrelationScopeTests
{
    private ScopeRecordingLogger _logger = null!;
    private FakeServiceRequestProcessor _processor = null!;
    private ServiceProvider _provider = null!;
    private List<string> _scopesDuringHandling = null!;

    [SetUp]
    public void SetUp()
    {
        _logger = new ScopeRecordingLogger();
        _scopesDuringHandling = [];
        _processor = new FakeServiceRequestProcessor
        {
            Respond = _ =>
            {
                _scopesDuringHandling.AddRange(_logger.ActiveScopes);
                return CatResponse.Ok();
            }
        };
        var services = new ServiceCollection();
        services.AddSingleton<ILogger<CatMessageReceiver>>(_logger);
        services.AddScoped<ICatServiceRequestProcessor>(_ => _processor);
        services.AddCatEventProcessor(new ConfigurationBuilder().Build(), builder => builder.Receive<OrderPlaced>());
        _provider = services.BuildServiceProvider();
    }

    [TearDown]
    public void TearDown() => _provider.Dispose();

    private Task<CatSettlementResult> ReceiveAsync(string correlationId) =>
        _provider.GetRequiredService<ICatMessageReceiver>().ReceiveAsync(typeof(OrderPlaced), new CatIncomingMessage
        {
            Body = Json.Of(new { orderNumber = "ORD-1" }),
            ContentType = "application/json",
            MessageId = "message-1",
            CorrelationId = correlationId
        });

    [Test]
    public async Task Receive_OpensALogScopeWithTheCorrelationIdForTheWholeHandling()
    {
        await ReceiveAsync("3f1c2a10-0000-4000-8000-000000000001");

        Assert.That(_scopesDuringHandling, Is.EqualTo(new[] { "CorrelationId=3f1c2a10-0000-4000-8000-000000000001" }));
        Assert.That(_logger.ActiveScopes, Is.Empty);
    }

    [Test]
    public async Task Receive_OpensNoLogScopeWhenTheMessageHasNoCorrelationId()
    {
        await ReceiveAsync(string.Empty);

        Assert.That(_scopesDuringHandling, Is.Empty);
    }

    private sealed class ScopeRecordingLogger : ILogger<CatMessageReceiver>
    {
        public List<string> ActiveScopes { get; } = [];

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            var text = state is IEnumerable<KeyValuePair<string, object>> pairs
                ? string.Join(";", pairs.Select(pair => $"{pair.Key}={pair.Value}"))
                : state.ToString()!;
            ActiveScopes.Add(text);
            return new Remover(ActiveScopes, text);
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
        }

        private sealed class Remover(List<string> scopes, string text) : IDisposable
        {
            public void Dispose() => scopes.Remove(text);
        }
    }
}
