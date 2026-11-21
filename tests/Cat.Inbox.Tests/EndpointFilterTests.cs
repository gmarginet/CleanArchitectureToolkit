using Cat.Inbox.Abstractions;
using Cat.Inbox.AspNetCore;
using Cat.Inbox.AspNetCore.Extensions;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.Inbox.Tests;

[TestFixture]
public class EndpointFilterTests
{
    private FakeStore _store = null!;
    private RecordingLogger _logger = null!;
    private ServiceProvider _provider = null!;

    [SetUp]
    public void SetUp()
    {
        _store = new FakeStore();
        _logger = new RecordingLogger();
        var services = new ServiceCollection();
        services.AddSingleton<ICatInboxStore>(_store);
        services.AddSingleton<ILoggerFactory>(new RecordingLoggerFactory(_logger));
        _provider = services.BuildServiceProvider();
    }

    [TearDown]
    public void TearDown() => _provider.Dispose();

    private async Task<(object? Result, int NextCalls)> RunAsync(Func<EndpointFilterInvocationContext, string?> readId, int repeatStatus = 200,
        object? endpointResult = null, bool endpointSaves = true, object?[]? arguments = null, Action? endpoint = null)
    {
        var http = new DefaultHttpContext { RequestServices = _provider };
        http.Request.Method = "POST";
        http.Request.Path = "/webhooks/refund";
        var context = new DefaultEndpointFilterInvocationContext(http, arguments ?? []);
        var calls = 0;
        var result = await CatInboxEndpointFilter.InvokeAsync(context, _ =>
        {
            calls++;
            endpoint?.Invoke();
            if (endpointSaves)
            {
                _store.SaveAdded();
            }

            return new ValueTask<object?>(endpointResult ?? Results.Ok());
        }, readId, "the test id", repeatStatus);
        return (result, calls);
    }

    [Test]
    public async Task AFirstCall_RunsTheEndpointAndAddsARowWithTheRouteAsItsType()
    {
        var (_, calls) = await RunAsync(_ => "evt-1");

        Assert.That(calls, Is.EqualTo(1));
        Assert.That(_store.Added, Is.EqualTo(new[] { ("evt-1", "POST /webhooks/refund") }));
        Assert.That(_logger.Entries, Is.Empty);
    }

    [Test]
    public async Task ARepeatedCall_IsSkippedAndAnswersTheRepeatStatusWithNoBody()
    {
        _store.Saved.Add("evt-1");

        var (result, calls) = await RunAsync(_ => "evt-1", repeatStatus: 204);

        Assert.That(calls, Is.EqualTo(0));
        Assert.That(result, Is.InstanceOf<IStatusCodeHttpResult>());
        Assert.That(((IStatusCodeHttpResult)result!).StatusCode, Is.EqualTo(204));
        Assert.That(_store.Added, Is.Empty);
    }

    [Test]
    public async Task ARepeatedCall_AnswersOkByDefault()
    {
        _store.Saved.Add("evt-1");

        var (result, _) = await RunAsync(_ => "evt-1");

        Assert.That(((IStatusCodeHttpResult)result!).StatusCode, Is.EqualTo(200));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    public async Task ACallWithoutAnId_IsHandledWithoutTheInboxAndLogsAWarning(string? id)
    {
        var (_, calls) = await RunAsync(_ => id);

        Assert.That(calls, Is.EqualTo(1));
        Assert.That(_store.Added, Is.Empty);
        Assert.That(_logger.Entries.Single(), Is.EqualTo((LogLevel.Warning, "The call POST /webhooks/refund has no inbox id in the test id, so it is handled without the inbox. Check the name of the header or the provider.")));
    }

    [Test]
    public async Task AnEndpointThatDoesNotSaveTheRow_LogsAnError()
    {
        await RunAsync(_ => "evt-1", endpointSaves: false);

        Assert.That(_logger.Entries.Single().Level, Is.EqualTo(LogLevel.Error));
        Assert.That(_logger.Entries.Single().Message, Does.Contain("evt-1").And.Contain("did not save its inbox row"));
    }

    [Test]
    public async Task AnEndpointThatAnswersAFailure_LogsNoErrorForTheMissingRow()
    {
        await RunAsync(_ => "evt-1", endpointResult: Results.BadRequest(), endpointSaves: false);

        Assert.That(_logger.Entries, Is.Empty);
    }

    [Test]
    public async Task AnEndpointThatThrows_LeavesNoSavedRow()
    {
        await Assert.ThatAsync(() => RunAsync(_ => "evt-1", endpointSaves: false, endpoint: () => throw new InvalidOperationException("boom")),
            Throws.InvalidOperationException);

        Assert.That(_store.Saved, Is.Empty);
    }

    private async Task<(WebApplication App, HttpClient Client)> StartAsync(Action<WebApplication> map)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        builder.Logging.ClearProviders();
        builder.Services.AddSingleton<ICatInboxStore>(_store);
        var app = builder.Build();
        map(app);
        await app.StartAsync();
        return (app, new HttpClient { BaseAddress = new Uri(app.Urls.Single()) });
    }

    [Test]
    public async Task TheHeaderOverload_SkipsTheSecondCallWithTheSameHeader()
    {
        var calls = 0;
        var (app, client) = await StartAsync(a => a.MapPost("/hook", () =>
        {
            calls++;
            _store.SaveAdded();
            return Results.Ok();
        }).WithCatInbox("webhook-id", StatusCodes.Status204NoContent));
        await using var appScope = app;
        using var clientScope = client;

        var first = await Post(client, "evt-7");
        var second = await Post(client, "evt-7");
        var other = await Post(client, "evt-8");

        Assert.That(first, Is.EqualTo(200));
        Assert.That(second, Is.EqualTo(204));
        Assert.That(other, Is.EqualTo(200));
        Assert.That(calls, Is.EqualTo(2));
        Assert.That(_store.Added.Select(added => added.Id), Is.EqualTo(new[] { "evt-7", "evt-8" }));
    }

    [Test]
    public async Task TheArgumentOverload_ReadsTheIdFromTheBoundBody()
    {
        var calls = 0;
        var (app, client) = await StartAsync(a => a.MapPost("/hook", (RefundEvent body) =>
        {
            calls++;
            _store.SaveAdded();
            return Results.Ok();
        }).WithCatInbox((RefundEvent e) => e.EventId));
        await using var appScope = app;
        using var clientScope = client;

        var first = await client.PostAsJsonAsync("/hook", new RefundEvent("evt-9"));
        var second = await client.PostAsJsonAsync("/hook", new RefundEvent("evt-9"));

        Assert.That((int)first.StatusCode, Is.EqualTo(200));
        Assert.That((int)second.StatusCode, Is.EqualTo(200));
        Assert.That(calls, Is.EqualTo(1));
        Assert.That(_store.Added.Single().Id, Is.EqualTo("evt-9"));
    }

    private static async Task<int> Post(HttpClient client, string id)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "/hook");
        request.Headers.Add("webhook-id", id);
        using var response = await client.SendAsync(request);
        return (int)response.StatusCode;
    }

    [Test]
    public void TheHeaderOverload_NeedsAHeaderName()
    {
        Assert.Throws<ArgumentException>(() => new NoOpBuilder().WithCatInbox(" "));
    }

    private sealed record RefundEvent(string EventId);

    private sealed class NoOpBuilder : IEndpointConventionBuilder
    {
        public void Add(Action<EndpointBuilder> convention)
        {
        }

        public void Finally(Action<EndpointBuilder> finallyConvention)
        {
        }
    }
    private sealed class FakeStore : ICatInboxStore
    {
        public HashSet<string> Saved { get; } = [];

        public List<(string Id, string Type)> Added { get; } = [];

        private readonly List<string> _pending = [];

        public Task<bool> ExistsAsync(string messageId, CancellationToken cancellationToken = default) => Task.FromResult(Saved.Contains(messageId));

        public void Add(string messageId, string messageType)
        {
            Added.Add((messageId, messageType));
            _pending.Add(messageId);
        }

        public void SaveAdded()
        {
            foreach (var id in _pending)
            {
                Saved.Add(id);
            }

            _pending.Clear();
        }

        public Task<int> DeleteOlderThanAsync(DateTimeOffset handledBefore, CancellationToken cancellationToken = default) => Task.FromResult(0);
    }

    private sealed class RecordingLogger : ILogger
    {
        public List<(LogLevel Level, string Message)> Entries { get; } = [];

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) =>
            Entries.Add((logLevel, formatter(state, exception)));
    }

    private sealed class RecordingLoggerFactory(RecordingLogger logger) : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {
        }

        public ILogger CreateLogger(string categoryName) => logger;

        public void Dispose()
        {
        }
    }
}