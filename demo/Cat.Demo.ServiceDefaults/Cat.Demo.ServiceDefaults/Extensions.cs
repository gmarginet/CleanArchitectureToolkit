using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Cat.Resilience.Abstractions;
using Cat.Resilience.Extensions;
using Cat.Telemetry.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.ServiceDefaults;

/// <summary>
/// Adds the shared defaults of the demo services: telemetry, health checks, service discovery and resilient HTTP clients.
/// Only the demo uses this project. The CAT modules never reference it.
/// </summary>
public static class Extensions
{
    private const string HealthEndpointPath = "/health";
    private const string AlivenessEndpointPath = "/alive";

    /// <summary>
    /// Adds telemetry, health checks, service discovery and the standard resilience handler to every <see cref="System.Net.Http.HttpClient"/>.
    /// </summary>
    /// <param name="builder">The application builder of the service.</param>
    /// <typeparam name="TBuilder">The type of the application builder.</typeparam>
    /// <returns>The same builder, for chaining.</returns>
    public static TBuilder AddServiceDefaults<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        builder.ConfigureOpenTelemetry();
        builder.AddDefaultHealthChecks();

        builder.Services.AddServiceDiscovery();
        builder.Services.ConfigureHttpClientDefaults(http =>
        {
            // The resilience module owns the pipeline of every client. A client with its own profile replaces this one.
            http.AddCatResilience(CatResilienceProfile.Internal);
            http.AddServiceDiscovery();
        });

        return builder;
    }

    /// <summary>
    /// Sets up logs, metrics and traces with OpenTelemetry.
    /// <c>Cat.Telemetry</c> does the work, and the traces include the activity sources of the CAT modules.
    /// The data goes to an OTLP endpoint when <c>OTEL_EXPORTER_OTLP_ENDPOINT</c> is set, such as by the Aspire AppHost.
    /// </summary>
    /// <param name="builder">The application builder of the service.</param>
    /// <typeparam name="TBuilder">The type of the application builder.</typeparam>
    /// <returns>The same builder, for chaining.</returns>
    public static TBuilder ConfigureOpenTelemetry<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        // The module sets up logs, metrics and traces, with the sources of the CAT modules and the OTLP exporter.
        // The health paths are left out of the traces by default, and they are the paths MapDefaultEndpoints maps.
        builder.AddCatTelemetry();

        return builder;
    }

    /// <summary>
    /// Adds the <c>self</c> health check, which only says that the process is running.
    /// </summary>
    /// <param name="builder">The application builder of the service.</param>
    /// <typeparam name="TBuilder">The type of the application builder.</typeparam>
    /// <returns>The same builder, for chaining.</returns>
    public static TBuilder AddDefaultHealthChecks<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

        return builder;
    }

    /// <summary>
    /// Maps <c>/health</c> for readiness and <c>/alive</c> for liveness, in every environment.
    /// Orchestrators and load balancers probe them to restart a service or route traffic.
    /// Both answer with a plain <c>Healthy</c> or <c>Unhealthy</c> and no details.
    /// Keep it that way when you add checks, and think about who may call <c>/health</c> once it checks a database.
    /// </summary>
    /// <param name="app">The web application of the service.</param>
    /// <returns>The same application, for chaining.</returns>
    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        app.MapHealthChecks(HealthEndpointPath);
        app.MapHealthChecks(AlivenessEndpointPath, new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("live")
        });

        return app;
    }
}
