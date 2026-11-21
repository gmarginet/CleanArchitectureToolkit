using System.Diagnostics;
using Cat.Telemetry.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Cat.Telemetry.Tests;

[TestFixture]
public class AddCatTelemetryTests
{
    private sealed class CollectingExporter : BaseExporter<Activity>
    {
        public List<string> Paths { get; } = [];

        public override ExportResult Export(in Batch<Activity> batch)
        {
            foreach (var activity in batch)
            {
                if (activity.GetTagItem("url.path") is string path)
                {
                    lock (Paths) Paths.Add(path);
                }
            }

            return ExportResult.Success;
        }
    }

    private static async Task<List<string>> CallAsync(Action<CatTelemetryOptions>? configure, Dictionary<string, string?>? settings, params string[] paths)
    {
        var exporter = new CollectingExporter();
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        builder.Configuration.AddInMemoryCollection(settings ?? []);
        builder.AddCatTelemetry(configure, tracing: tracer => tracer.AddProcessor(new SimpleActivityExportProcessor(exporter)));
        await using var app = builder.Build();
        app.MapGet("/{**path}", () => "ok");
        await app.StartAsync();
        var address = app.Services.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>()!.Addresses.First();

        using var client = new HttpClient { BaseAddress = new Uri(address) };
        foreach (var path in paths)
        {
            await client.GetAsync(path);
        }

        await app.StopAsync();
        app.Services.GetRequiredService<TracerProvider>().ForceFlush();
        return exporter.Paths;
    }

    [Test]
    public async Task TheHealthPathsAreLeftOutOfTheTracesByDefault()
    {
        var paths = await CallAsync(null, null, "/orders", "/health", "/alive", "/health/ready");

        Assert.That(paths, Is.EqualTo(new[] { "/orders" }));
    }

    [Test]
    public async Task TheListOfIgnoredPathsComesFromTheConfiguration()
    {
        var paths = await CallAsync(null, new() { ["Cat:Telemetry:IgnoredPaths:0"] = "/healthz" }, "/orders", "/health", "/healthz");

        Assert.That(paths, Is.EqualTo(new[] { "/orders", "/health" }));
    }

    [Test]
    public async Task TheCallbackCanChangeTheIgnoredPaths()
    {
        var paths = await CallAsync(options => options.IgnoredPaths = ["/orders"], null, "/orders", "/health");

        Assert.That(paths, Is.EqualTo(new[] { "/health" }));
    }

    [TestCase("Cat.EventProcessor")]
    [TestCase("Cat.FluentWorkflows")]
    [TestCase("Cat.Scheduling")]
    [TestCase("Cat.ServiceRequests")]
    public void TheSourcesOfTheModulesAreListened(string sourceName)
    {
        var builder = Host.CreateEmptyApplicationBuilder(new HostApplicationBuilderSettings());
        builder.AddCatTelemetry();
        using var host = builder.Build();
        host.Start();
        using var source = new ActivitySource(sourceName);

        Assert.That(source.HasListeners(), Is.True);
    }

    [Test]
    public void ASourceOfAnotherNameIsNotListened()
    {
        var builder = Host.CreateEmptyApplicationBuilder(new HostApplicationBuilderSettings());
        builder.AddCatTelemetry();
        using var host = builder.Build();
        host.Start();
        using var source = new ActivitySource("Some.Other.Source");

        Assert.That(source.HasListeners(), Is.False);
    }

    [Test]
    public void ASourceThatTheDeveloperAddsInTheCallbackIsListened()
    {
        var builder = Host.CreateEmptyApplicationBuilder(new HostApplicationBuilderSettings());
        builder.AddCatTelemetry(tracing: tracer => tracer.AddSource("My.Own.Source"));
        using var host = builder.Build();
        host.Start();
        using var source = new ActivitySource("My.Own.Source");

        Assert.That(source.HasListeners(), Is.True);
    }

    [Test]
    public void TheNamesOfTheModulesMatchTheSourcesTheModulesPublish()
    {
        Assert.That(CatTelemetryNames.Modules, Is.EquivalentTo(new[]
        {
            "Cat.EventProcessor", "Cat.FluentWorkflows", "Cat.Messaging", "Cat.Scheduling", "Cat.ServiceRequests", "Cat.Sql.Cdc"
        }));
    }
}
