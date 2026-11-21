<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: .. -->
<link href="../resources/styles/style.css" rel="stylesheet" />
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
            <img src='../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-plan skill to update this plan.-->
<!-- region end: TemplateSkill-->

# Plans for `Cat.Telemetry` <!-- omit in toc -->  

<!-- region start: FirstStableVersion-->
**First stable version:** not reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 1](#phase-1)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
A new module, `Cat.Telemetry`, with a shared tracing and metrics setup for all services.

#### The idea
With many small services, one slow order can touch five of them. Without traces and metrics nobody can follow it. Every service needs the same setup, with the same names, so the pieces fit together.

`Cat.Telemetry` is that shared setup, for every project. The demo `ServiceDefaults` calls it, and a project without Aspire calls it in its `Program`.

#### Background
From the existing modules:
- `Cat.ServiceRequests.Decorators.ActivitySource` already traces every service request. The wildcard source `Cat.*` picks up the traces of the CAT modules, including the workflows.
- The logging decorators of `Cat.Commands`, `Cat.Queries` and `Cat.ServiceRequests` log the handlers.

From the demo plan and the Aspire plan:
- The demo case is tracing one order across all services.
- `Aspire ServiceDefaults` sets up logs, metrics and traces with OpenTelemetry, a readiness and a liveness check, and the resilience handler. It exports through OTLP when `OTEL_EXPORTER_OTLP_ENDPOINT` is set.
- None of that needs Aspire. `ServiceDefaults` calls the OpenTelemetry SDK, its instrumentation and the OTLP exporter, which are plain .NET packages.
- `Cat.Telemetry` must work in projects that do not use Aspire. Modules must not depend on Aspire or on `ServiceDefaults`.
- In the demo, the CAT modules add what OpenTelemetry does not, such as the decorators on service requests.

From the discussion with the owner (2026-11-20):
- The payment service becomes an outside provider, called directly from the infrastructure of Orders, see [Demo.md](Demo.md#phase-17). No trace headers should go to a third party, while Orders still records the call as a span.
- Trace headers are written in the innermost handler, after every `DelegatingHandler`. A boundary for one client therefore sets the propagator of its primary handler, for example to `DistributedContextPropagator.CreateNoOutputPropagator()`. The property for that, `SocketsHttpHandler.ActivityHeadersPropagator`, does not exist in `netstandard2.0`.

From the packages (read in the local NuGet cache, 2026-11-21):
- `OpenTelemetry.Extensions.Hosting`, `OpenTelemetry.Instrumentation.AspNetCore` and `OpenTelemetry.Instrumentation.Http` 1.21.0 target `netstandard2.0`, `net10.0` and `net11.0`. `Directory.Packages.props` pins them at 1.21.0.

From the resilience plan:
- `Cat.Resilience` uses the metrics of Polly on the meter `Polly`, with no meter of its own, and `Cat.Telemetry` lists that meter. See the [module readme of Cat.Resilience](../modules/Cat.Resilience/README.md). It is the one meter in the list with a name outside the naming scheme in the Decided list.

From the saga plan:
- Save the trace context in a stored workflow instance, so the second half of a workflow joins the same trace.
- Tracing across the gap of a message needs the trace context in the message properties.

From the architecture:
- Everything runs as containers in Azure Container Apps.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- The activity sources of the modules exist: `Cat.ServiceRequests` in the service request decorator and `Cat.FluentWorkflows` in the workflow processor.
- `ConfigureOpenTelemetry` in the demo `ServiceDefaults` sets up logs, metrics and traces.
  - Tracing adds the application name and the `Cat.*` sources, plus ASP.NET Core and `HttpClient` instrumentation.
  - Tracing leaves out the `/health` and `/alive` paths.
  - Metrics cover ASP.NET Core, `HttpClient` and the runtime.
  - The OTLP exporter switches on when `OTEL_EXPORTER_OTLP_ENDPOINT` is set.
- The health checks of `ServiceDefaults` only say the process runs. They check no database yet.
- `Cat.Messaging` leaves the trace context to the Service Bus SDK, which puts its `Diagnostic-Id` on a message when it sends. A message that goes through the outbox is sent later by a background service, so it loses the context of the caller. The listener of `Cat.EventProcessor` continues the trace from the `Diagnostic-Id`.

#### Decided
- **Independence.** The module works without Aspire.
- **Role next to `ServiceDefaults`.** The module is the base for every project. It holds the telemetry setup, and the demo `ServiceDefaults` calls it. A project without Aspire makes the same call in its `Program`. The dependency goes from `ServiceDefaults` to the module, never back (owner, 2026-11-20).
- **A real module.** One extension method, `AddCatTelemetry`, sets up traces, metrics and logs with the `Cat.*` sources, the filters and the exporter. It follows from the role above, which needs the whole setup in the module (owner, 2026-11-20).
- **Without Aspire.** The module readme gets a chapter "Without Aspire" with the calls a `Program` makes in place of `ServiceDefaults`, and a note that the telemetry goes over OTLP to any collector. There is no second demo application without Aspire (owner, 2026-11-20).
- **One project.** `Cat.Telemetry`, with no Abstractions project, like `Cat.Api.Client` and `Cat.Minimal.Api`. Only the host and the infrastructure call it, and each module keeps its own source names. It targets `netstandard2.0;net10.0;net11.0`, because the trace boundary needs `net10.0` or later. It drops `netstandard2.0` when the ASP.NET Core instrumentation does not build for it (owner, 2026-11-21).
- **Trace boundary.** `AddCatTelemetryBoundary()` on `IHttpClientBuilder` sets the no-output propagator on the primary handler of that client, so no `traceparent`, `tracestate` or `baggage` leaves, and the call is still a span in Orders. It exists only in the `net10.0` and `net11.0` builds. It configures the handler that ends up as primary and never creates one of its own, so a primary handler that the developer set, such as one with a client certificate, stays. A test covers that order. The infrastructure of Orders calls it on the client of the payment provider, next to the external profile of `Cat.Resilience` (owner, 2026-11-21).
- **Foundation.** OpenTelemetry, with nothing hidden. The modules trace with `ActivitySource` and `Meter` of `System.Diagnostics`. `AddCatTelemetry` sets up the OpenTelemetry SDK and takes callbacks with the OpenTelemetry builders, so a developer adds instrumentation, sources or exporters there. Other backends plug in as OpenTelemetry exporters (owner, 2026-11-21).
- **Exporters.** OTLP is built in and switched on by `OTEL_EXPORTER_OTLP_ENDPOINT`, as in `ServiceDefaults` today. Every other exporter is the developer's choice, added in the callback. There is no Azure Monitor project in the module. To check: Azure Container Apps has a managed OpenTelemetry agent that takes OTLP and forwards it to Application Insights, Datadog or any OTLP endpoint (owner, 2026-11-21).
- **Backend.** The toolkit picks no telemetry backend. The developer chooses it, and the module readme only shows how OTLP reaches one. The demo never runs on Azure, so it uses the Aspire dashboard only (owner, 2026-11-21).
- **Naming scheme.** The source and the meter of a module equal the module name, as they already do: `Cat.FluentWorkflows`, `Cat.Messaging`, `Cat.Scheduling`, `Cat.ServiceRequests` and `Cat.Sql.Cdc`. Span tags use `cat.<module>.<name>` in lowercase snake case, such as `cat.scheduling.job`. Metric tags stay short, such as `job` and `table`, because the meter already names the module. The module readme lists every name. Existing names that do not fit are renamed, such as `ServiceRequestType` to `cat.service_requests.type`. The toolkit is in alpha and the demo is the only user, so a rename breaks nothing outside the repository (owner, 2026-11-21).
- **Trace context over the Service Bus.** `Cat.Messaging` leaves it to the Service Bus SDK, and `Cat.Outbox` carries it for a message that goes through the outbox, see [Cat.Outbox.md](Cat.Outbox.md#phase-2). `Cat.Telemetry` only lists the `Cat.Messaging` source (owner, 2026-11-21).
- **Logs and traces.** The OpenTelemetry logging provider links every log record to the trace and the span that run, with no code. The listener of `Cat.EventProcessor` also adds the `CorrelationId` of a message to the log scope, as the gateway does for a request, so all logs of one business flow can be found, also across a trace that broke. See [Cat.EventProcessor.md](Cat.EventProcessor.md#phase-2) (owner, 2026-11-21).
- **Sampling.** Every trace is kept by default. With a ratio set, the first service keeps that part of the traces and every service after it follows the choice of its caller (a parent based ratio sampler), so a trace is always whole or gone. To check when building: whether the OpenTelemetry SDK for .NET reads `OTEL_TRACES_SAMPLER` and `OTEL_TRACES_SAMPLER_ARG`. If it does, the module uses those variables and adds no setting of its own. If not, the setting is `Cat:Telemetry:SamplingRatio` (owner, 2026-11-21).
- **Tracing filters.** The module drops the traces of the health endpoints, as `ServiceDefaults` does. The paths are a setting, with `/health` and `/alive` as the defaults, so a developer with other paths, such as `/healthz`, changes the list (owner, 2026-11-21).
- **Personal data.** The module readme has a guideline: personal data stays out of tags and span names. The tags the toolkit sets itself carry ids, never names or email addresses. The module adds no filter on tag names. The readme shows how a developer adds an OpenTelemetry processor of their own in the callback. To check when building: whether the ASP.NET Core instrumentation hides query strings by default (owner, 2026-11-21).
- **Metrics.** `Cat.Telemetry` adds no metrics of its own. It lists the meters of the modules, plus the ASP.NET Core, `HttpClient` and runtime metrics, as `ServiceDefaults` does. As part of this phase, the service request decorator of `Cat.ServiceRequests` gets the meter `Cat.ServiceRequests`, with a count and a duration per call and the tags `type` and `outcome`. Commands and queries get no meter until a real case asks for one (owner, 2026-11-21).
- **Health checks.** Out of scope, because they are not telemetry. The chapter "Without Aspire" of the module readme shows the plain ASP.NET Core lines for `/health` and `/alive`. A module that has something to check offers its own `IHealthCheck`, as `Cat.EventProcessor` does (owner, 2026-11-21).
- **Existing tracing.** Each module keeps its own activity source and meter, with the names of the naming scheme. `Cat.Telemetry` only lists them in `AddCatTelemetry`. Nothing moves into this module, so no module depends on it, and a developer with an own OpenTelemetry setup adds the sources by name (owner, 2026-11-21).
- **Trace story in the demo.** The demo shows "one order across all services" now, with the trace of a place order call in the Aspire dashboard, and a section in the demo readme with the steps. `ServiceDefaults` already does the HTTP part. Still to check: whether the message hops of `Cat.Messaging` and the Notifications service join the same trace. A hop that does not join is written down in the demo readme as a known gap. The fix for the outbox belongs to `Cat.Outbox`, see the decision on the trace context above (owner, 2026-11-21).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->