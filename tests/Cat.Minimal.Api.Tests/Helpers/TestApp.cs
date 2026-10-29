using Cat.Minimal.Api.Extensions;
using Cat.ServiceRequests.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.Minimal.Api.Tests.Helpers;

/// <summary>
/// A real web server on a free local port, with the module set up and a few endpoints mapped.
/// </summary>
public sealed class TestApp : IAsyncDisposable
{
    private readonly WebApplication _app;

    private TestApp(WebApplication app, HttpClient client)
    {
        _app = app;
        Client = client;
    }

    public HttpClient Client { get; }

    public static async Task<TestApp> StartAsync(string environmentName = "Production")
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions { EnvironmentName = environmentName });
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        builder.Logging.ClearProviders();

        builder.Services.AddCatMinimalApiModule();
        builder.Services.AddCatServiceRequestsModule(typeof(EchoRequestHandler));

        var app = builder.Build();
        app.UseExceptionHandler();

        app.MapCatServiceRequest<EchoRequest, string>("/echo");
        app.MapCatServiceRequest<PositionalRequest, string>("/positional");
        app.MapCatServiceRequest<PingRequest>("/ping");

        await app.StartAsync();

        var address = app.Services.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>()!.Addresses.First();
        var client = new HttpClient { BaseAddress = new Uri(address) };

        return new TestApp(app, client);
    }

    public async ValueTask DisposeAsync()
    {
        Client.Dispose();
        await _app.StopAsync();
        await _app.DisposeAsync();
    }
}
