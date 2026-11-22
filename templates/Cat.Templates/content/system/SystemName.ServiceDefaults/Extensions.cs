using Cat.Resilience.Abstractions;
using Cat.Resilience.Extensions;
using Cat.Telemetry.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace SystemName.ServiceDefaults;

/// <summary>
/// Adds the shared defaults of the services of the system: telemetry, health checks, service discovery and resilient HTTP clients.
/// The CAT modules never reference this project.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Adds telemetry, health checks, service discovery and the CAT resilience profile to every <see cref="System.Net.Http.HttpClient"/>.
    /// </summary>
    /// <param name="builder">The application builder of the service.</param>
    /// <typeparam name="TBuilder">The type of the application builder.</typeparam>
    /// <returns>The same builder, for chaining.</returns>
    public static TBuilder AddServiceDefaults<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        // Cat.Telemetry sets up logs, metrics and traces. The data goes to the OTLP endpoint that the AppHost sets.
        builder.AddCatTelemetry();

        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

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
    /// Maps <c>/health</c> for readiness and <c>/alive</c> for liveness.
    /// Both answer with a plain <c>Healthy</c> or <c>Unhealthy</c> and no details.
    /// </summary>
    /// <param name="app">The web application of the service.</param>
    /// <returns>The same application, for chaining.</returns>
    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        app.MapHealthChecks("/health");
        app.MapHealthChecks("/alive", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("live")
        });

        return app;
    }
}
