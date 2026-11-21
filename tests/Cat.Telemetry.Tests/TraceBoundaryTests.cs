using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Cat.Telemetry.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Telemetry.Tests;

[TestFixture]
public class TraceBoundaryTests
{
    private ActivityListener _listener = null!;
    private ActivitySource _source = null!;

    [SetUp]
    public void SetUp()
    {
        _listener = new ActivityListener
        {
            ShouldListenTo = _ => true,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded
        };
        ActivitySource.AddActivityListener(_listener);
        _source = new ActivitySource("Cat.Telemetry.Tests");
    }

    [TearDown]
    public void TearDown()
    {
        _source.Dispose();
        _listener.Dispose();
    }

    /// <summary>Starts a server that reads one request, answers 200 and returns the text of the request.</summary>
    private static (Uri Address, Task<string> Request) StartServer()
    {
        var tcp = new TcpListener(IPAddress.Loopback, 0);
        tcp.Start();
        var address = new Uri($"http://127.0.0.1:{((IPEndPoint)tcp.LocalEndpoint).Port}/");
        var request = Task.Run(async () =>
        {
            using var connection = await tcp.AcceptTcpClientAsync();
            var stream = connection.GetStream();
            var buffer = new byte[8192];
            var text = new StringBuilder();
            while (!text.ToString().Contains("\r\n\r\n"))
            {
                var read = await stream.ReadAsync(buffer);
                if (read == 0) break;
                text.Append(Encoding.ASCII.GetString(buffer, 0, read));
            }

            await stream.WriteAsync(Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r\nContent-Length: 0\r\nConnection: close\r\n\r\n"));
            tcp.Stop();
            return text.ToString();
        });
        return (address, request);
    }

    private async Task<string> SendAsync(Action<IHttpClientBuilder>? configure)
    {
        var (address, request) = StartServer();
        var services = new ServiceCollection();
        var clientBuilder = services.AddHttpClient("provider", client => client.BaseAddress = address);
        configure?.Invoke(clientBuilder);
        await using var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<IHttpClientFactory>().CreateClient("provider");

        // A trace is running, as it is in a handler of Orders.
        using var activity = _source.StartActivity("call");
        await client.GetAsync("/charges");
        return await request;
    }

    [Test]
    public async Task WithoutABoundary_TheTraceHeadersLeave()
    {
        var request = await SendAsync(null);

        Assert.That(request.ToLowerInvariant(), Does.Contain("traceparent:"));
    }

    [Test]
    public async Task WithABoundary_NoTraceHeaderLeaves()
    {
        var request = (await SendAsync(client => client.AddCatTelemetryBoundary())).ToLowerInvariant();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(request, Does.Not.Contain("traceparent:"));
            Assert.That(request, Does.Not.Contain("tracestate:"));
            Assert.That(request, Does.Not.Contain("baggage:"));
        }
    }

    [Test]
    public async Task AHandlerThatTheDeveloperSetsAfterTheBoundary_KeepsTheBoundary()
    {
        var request = (await SendAsync(client => client
            .AddCatTelemetryBoundary()
            .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler { MaxConnectionsPerServer = 3 }))).ToLowerInvariant();

        Assert.That(request, Does.Not.Contain("traceparent:"));
    }

    [Test]
    public async Task AHandlerThatTheDeveloperSetsBeforeTheBoundary_KeepsTheBoundary()
    {
        var request = (await SendAsync(client => client
            .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler { MaxConnectionsPerServer = 3 })
            .AddCatTelemetryBoundary())).ToLowerInvariant();

        Assert.That(request, Does.Not.Contain("traceparent:"));
    }

    [Test]
    public async Task ABoundaryOnOneClient_LeavesAnotherClientAlone()
    {
        var (address, request) = StartServer();
        var services = new ServiceCollection();
        services.AddHttpClient("provider", client => client.BaseAddress = address).AddCatTelemetryBoundary();
        services.AddHttpClient("ours", client => client.BaseAddress = address);
        await using var provider = services.BuildServiceProvider();

        using var activity = _source.StartActivity("call");
        await provider.GetRequiredService<IHttpClientFactory>().CreateClient("ours").GetAsync("/");

        Assert.That((await request).ToLowerInvariant(), Does.Contain("traceparent:"));
    }
}
