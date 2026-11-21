using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Cat.Telemetry.Extensions;

/// <summary>
/// Sets up the telemetry of a host.
/// </summary>
public static class HostApplicationBuilderExtensions
{
    /// <summary>
    /// Sets up logs, metrics and traces with OpenTelemetry. It works with or without Aspire.
    /// </summary>
    /// <remarks>
    /// The traces hold the sources of the CAT modules, ASP.NET Core and <c>HttpClient</c>, and leave out the health paths of
    /// <see cref="CatTelemetryOptions.IgnoredPaths"/>. The metrics hold the meters of the CAT modules, Polly, ASP.NET Core,
    /// <c>HttpClient</c> and the runtime. The logs carry the trace and the span that run when the record is written.
    /// The data goes to an OTLP endpoint when <c>OTEL_EXPORTER_OTLP_ENDPOINT</c> is set. Any other exporter, source or meter
    /// goes in the callbacks. The sampler follows the standard variables <c>OTEL_TRACES_SAMPLER</c> and <c>OTEL_TRACES_SAMPLER_ARG</c>.
    /// </remarks>
    /// <param name="builder">The builder of the host or the web application.</param>
    /// <param name="configure">Changes the settings. The configuration section <c>Cat:Telemetry</c> is read first.</param>
    /// <param name="tracing">Adds to the traces, for example another source or exporter.</param>
    /// <param name="metrics">Adds to the metrics, for example another meter or exporter.</param>
    /// <typeparam name="TBuilder">The type of the builder.</typeparam>
    /// <returns>The same builder, for chaining.</returns>
    public static TBuilder AddCatTelemetry<TBuilder>(
        this TBuilder builder,
        Action<CatTelemetryOptions>? configure = null,
        Action<TracerProviderBuilder>? tracing = null,
        Action<MeterProviderBuilder>? metrics = null)
        where TBuilder : IHostApplicationBuilder
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var options = new CatTelemetryOptions();
        builder.Configuration.GetSection(CatTelemetryOptions.SectionName).Bind(options);
        configure?.Invoke(options);
        var ignoredPaths = options.EffectiveIgnoredPaths().Select(path => new PathString(path)).ToArray();

        builder.Logging.AddOpenTelemetry(logging =>
        {
            logging.IncludeFormattedMessage = true;
            logging.IncludeScopes = true;
        });

        var openTelemetry = builder.Services.AddOpenTelemetry();
        openTelemetry
            .WithMetrics(meterProvider =>
            {
                foreach (var name in CatTelemetryNames.Modules)
                {
                    meterProvider.AddMeter(name);
                }

                meterProvider.AddMeter(CatTelemetryNames.Polly)
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation();
                metrics?.Invoke(meterProvider);
            })
            .WithTracing(tracerProvider =>
            {
                tracerProvider.AddSource(string.IsNullOrWhiteSpace(options.ServiceName)
                    ? builder.Environment.ApplicationName
                    : options.ServiceName!);
                foreach (var name in CatTelemetryNames.Modules)
                {
                    tracerProvider.AddSource(name);
                }

                tracerProvider
                    .AddAspNetCoreInstrumentation(aspNet =>
                        aspNet.Filter = context => !ignoredPaths.Any(path => context.Request.Path.StartsWithSegments(path)))
                    .AddHttpClientInstrumentation();
                tracing?.Invoke(tracerProvider);
            });

        if (!string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]))
        {
            openTelemetry.UseOtlpExporter();
        }

        return builder;
    }
}
