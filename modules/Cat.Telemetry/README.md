<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: ../.. -->
<link href="../../resources/styles/style.css" rel="stylesheet" />
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-module-readme skill to update this readme.-->
<!-- region end: TemplateSkill-->

# Cat.Telemetry <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Telemetry sets up traces, metrics and logs for a service with one call. It uses OpenTelemetry, so the data goes to any backend that speaks OTLP.

The call adds the activity sources and the meters of the CAT modules, the instrumentation of ASP.NET Core and `HttpClient`, the runtime metrics, and the OTLP exporter. It also holds a trace boundary for a client that calls a third party.

The module is plain .NET. It never references Aspire.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Set up the telemetry of a service](#set-up-the-telemetry-of-a-service)
  - [Without Aspire](#without-aspire)
  - [Names of the sources, the meters and the tags](#names-of-the-sources-the-meters-and-the-tags)
  - [Add your own source, meter or exporter](#add-your-own-source-meter-or-exporter)
  - [Leave the health paths out](#leave-the-health-paths-out)
  - [Keep the trace out of a third party](#keep-the-trace-out-of-a-third-party)
  - [Sampling](#sampling)
  - [Logs and traces](#logs-and-traces)
  - [Personal data](#personal-data)
  - [Tests](#tests)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Telemetry)](#nuget-packages)

| Package | Role | Targets | Install | Downloads |
|---------|------|---------|---------|-----------|
| [Cat.Telemetry](https://www.nuget.org/packages/gmarginet.Cat.Telemetry/) | Implementation | net10.0, net11.0 | `dotnet add package gmarginet.Cat.Telemetry` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Telemetry)](https://www.nuget.org/packages/gmarginet.Cat.Telemetry/) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Telemetry](namespaces/Cat.Telemetry/index.md) | The setup of the telemetry, its settings and the names of the sources and meters of the CAT modules. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

Cat.Telemetry has no dependencies on other CAT modules.  

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Set up the telemetry of a service
Call `AddCatTelemetry` on the builder of the host, in `Program.cs`.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.AddCatTelemetry();
```

It sets up:
- **Traces.** The sources of the CAT modules, the application name, the incoming requests of ASP.NET Core and the outgoing calls of `HttpClient`.
- **Metrics.** The meters of the CAT modules, the meter of Polly that `Cat.Resilience` uses, ASP.NET Core, `HttpClient` and the runtime.
- **Logs.** The OpenTelemetry logging provider, with the formatted message and the scopes.
- **Export.** OTLP, switched on when the variable `OTEL_EXPORTER_OTLP_ENDPOINT` is set.

The module targets `net10.0` and `net11.0`, because the OpenTelemetry packages need `Microsoft.Extensions` 11.0 on `netstandard2.0`.

### Without Aspire
Aspire is not needed. Aspire only sets `OTEL_EXPORTER_OTLP_ENDPOINT` for you. Without it, point the variable at your own collector, or at the managed OpenTelemetry agent of Azure Container Apps. A collector forwards the data to Application Insights, Datadog or any other backend.

```
OTEL_EXPORTER_OTLP_ENDPOINT=http://my-collector:4317
OTEL_SERVICE_NAME=orders
```

The toolkit picks no backend. The health endpoints are not telemetry, so the module does not map them. In plain ASP.NET Core:

```csharp
builder.Services.AddHealthChecks();
app.MapHealthChecks("/health");
app.MapHealthChecks("/alive", new HealthCheckOptions { Predicate = check => check.Tags.Contains("live") });
```

A module that has something to check offers its own `IHealthCheck`, as `Cat.EventProcessor` does.

### Names of the sources, the meters and the tags
Every CAT module that traces or measures uses its own name for the source and for the meter. `CatTelemetryNames` holds the names, so a project that does not use `AddCatTelemetry` adds them by name.

| Name | Module | Holds |
|------|--------|-------|
| `Cat.EventProcessor` | `Cat.EventProcessor` | Source. The span of the handling of a message, with the trace of the sender as its parent, and the tag `messaging.message.id`. |
| `Cat.FluentWorkflows` | `Cat.FluentWorkflows` | Source. A span for every run and every resume of a workflow. |
| `Cat.Messaging` | `Cat.Messaging` | Meter. `cat.messaging.dead_letters`, the dead letter messages per entity. |
| `Cat.Scheduling` | `Cat.Scheduling` | Source and meter. The span of a run, with the tags `cat.scheduling.job` and `cat.scheduling.attempts`. The counter `cat.scheduling.runs` with the tags `job` and `status`, and the gauge `cat.scheduling.last_run`. |
| `Cat.ServiceRequests` | `Cat.ServiceRequests.Decorators.ActivitySource` | Source and meter. The span of a service request, with the tag `cat.service_requests.type`. The counter `cat.service_requests.calls` and the histogram `cat.service_requests.duration` with the tags `type` and `outcome` (`success`, `failed` or `exception`). |
| `Cat.Sql.Cdc` | `Cat.Sql.Cdc` | Meter. The counters `cat.sql.cdc.changes` and `cat.sql.cdc.errors` with the tags `table`, `operation` and `kind`. |
| `Polly` | `Cat.Resilience` | Meter of Polly. The module has no meter of its own. Its name is outside the naming scheme above. |

The naming scheme: the source and the meter equal the module name. A span tag is `cat.<module>.<name>` in lowercase snake case. A metric tag is short, such as `job` and `table`, because the meter already names the module.

One tag is shared by all modules: `cat.correlation_id`, with the id of the request or the message. The gateway sets it on the span of a request.

### Add your own source, meter or exporter
`AddCatTelemetry` takes a callback for the traces and one for the metrics. Both give you the OpenTelemetry builder, so anything OpenTelemetry offers works here.

```csharp
builder.AddCatTelemetry(
    tracing: tracing => tracing.AddSource("My.Own.Source").AddConsoleExporter(),
    metrics: metrics => metrics.AddMeter("My.Own.Meter"));
```

### Leave the health paths out
The traces of `/health` and `/alive` are dropped, because a probe calls them every few seconds. A path matches itself and everything below it. Change the list in configuration or in the callback. A list replaces the default, and an empty list drops nothing.

```json
{
  "Cat": {
    "Telemetry": {
      "IgnoredPaths": [ "/healthz" ]
    }
  }
}
```

```csharp
builder.AddCatTelemetry(options => options.IgnoredPaths = ["/healthz", "/ready"]);
```

### Keep the trace out of a third party
A call to a third party should not carry your trace ids. Put `AddCatTelemetryBoundary` on the client. No `traceparent`, `tracestate` or `baggage` header leaves, and the call is still a span in your own trace.

```csharp
services.AddHttpClient<IPaymentProviderClient, PaymentProviderClient>()
    .AddCatTelemetryBoundary();
```

The headers are written by the primary handler, after every delegating handler. The boundary therefore sets the propagator on the primary handler when the client is built, and it never creates a handler of its own. A primary handler that you set, with `ConfigurePrimaryHttpMessageHandler` and before or after this call, stays. Only a `SocketsHttpHandler` is changed, and a handler of a test is left alone.

### Sampling
Every trace is kept by default. The sampler follows the standard OpenTelemetry variables. To keep a tenth of the traces, and to let every service follow the choice of its caller, so a trace is always whole or gone:

```
OTEL_TRACES_SAMPLER=parentbased_traceidratio
OTEL_TRACES_SAMPLER_ARG=0.1
```

### Logs and traces
The OpenTelemetry logging provider links every log record to the trace and the span that run when it is written, with no code on your side. Open a trace in your backend and its logs are there.

### Personal data
Keep personal data out of tags and span names. The tags that the toolkit sets carry ids, never names or email addresses. The ASP.NET Core instrumentation hides the values of a query string by default. The module adds no filter on tag names. Add an OpenTelemetry processor of your own in the callback when you need one.

```csharp
builder.AddCatTelemetry(tracing: tracing => tracing.AddProcessor(new MyRedactionProcessor()));
```

### Tests
`tests/Cat.Telemetry.Tests` covers the listened sources, the health paths on a real Kestrel host and the trace boundary, with a raw TCP listener that reads the request headers.
<!-- region end: Usage-->
