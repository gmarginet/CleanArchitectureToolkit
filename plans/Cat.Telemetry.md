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

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-cattelemetry)
<!-- region end: StatusBadge-->

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

`Cat.Telemetry` is that shared setup, for projects that do not use Aspire. A project that uses Aspire already has it in `ServiceDefaults` and does not need this module, except to extend it.

#### Background
From the existing modules:
- `Cat.ServiceRequests.Decorators.ActivitySource` already traces every service request. The wildcard source `Cat.*` picks up the traces of the CAT modules, including the workflows.
- The logging decorators of `Cat.Commands`, `Cat.Queries` and `Cat.ServiceRequests` log the handlers.

From the demo plan and the Aspire plan:
- The demo case is tracing one order across all services.
- `Aspire ServiceDefaults` sets up logs, metrics and traces with OpenTelemetry, a readiness and a liveness check, and the resilience handler. It exports through OTLP when `OTEL_EXPORTER_OTLP_ENDPOINT` is set.
- That overlaps with this module on purpose. CAT is a toolbox, so the developer picks what to use. A project with Aspire uses `ServiceDefaults`. A project without Aspire uses this module.
- `Cat.Telemetry` must work in projects that do not use Aspire. Modules must not depend on Aspire or on `ServiceDefaults`.
- In the demo, `ServiceDefaults` covers the basics, and the CAT modules add what it does not, such as the decorators on service requests.

From the saga plan:
- Save the trace context in a stored workflow instance, so the second half of a workflow joins the same trace.
- Tracing across the gap of a message needs the trace context in the message properties.

From the architecture:
- Everything runs as containers in Azure Container Apps.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- The activity sources of the modules exist: `Cat.ServiceRequests` in the service request decorator and `Cat.FluentWorkFlows` in the workflow processor.
- `ConfigureOpenTelemetry` in the demo `ServiceDefaults` sets up logs, metrics and traces.
  - Tracing adds the application name and the `Cat.*` sources, plus ASP.NET Core and `HttpClient` instrumentation.
  - Tracing leaves out the `/health` and `/alive` paths.
  - Metrics cover ASP.NET Core, `HttpClient` and the runtime.
  - The OTLP exporter switches on when `OTEL_EXPORTER_OTLP_ENDPOINT` is set.
- The health checks of `ServiceDefaults` only say the process runs. They check no database yet.
- Nothing carries the trace context over the Service Bus yet.

#### Decided
- **Independence.** The module works without Aspire.
- **Overlap.** With Aspire, use `ServiceDefaults` and skip this module. The module exists for projects without Aspire. It may also hold extensions of `ServiceDefaults`, so they are useful outside the demo.
- **Existing tracing.** The `Cat.*` activity sources stay as they are.
- **Trace story in the demo.** The demo shows "one order across all services" now, with the trace of a place order call in the Aspire dashboard, and a section in the demo readme with the steps. `ServiceDefaults` already does the HTTP part. Still to check: whether the message hops of `Cat.Messaging` and the Notifications service join the same trace. A hop that does not join is written down in the demo readme as a known gap, and the fix belongs to this module.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Is it a module at all? This is the blocking question. What does it add beyond a few lines of OpenTelemetry setup? The module is for projects without Aspire, so it needs a minimum setup, and the rest only extends `ServiceDefaults`. The options:
- **A real module.** One extension method sets up traces, metrics and logs with the `Cat.*` sources, the filters and the exporter. Cost: it repeats what `ServiceDefaults` does, and has to keep up with OpenTelemetry versions.
- **A small module with only what Aspire lacks.** The naming constants, the trace context over messages (question 6), the personal data filter (question 10) and the `Cat.*` source list. The setup stays a few documented lines. Cost: the module is thin.
- **Documentation only.** A readme chapter with the setup. Cost: no code to reuse, and developers copy and paste.

Recommendation: the small module. The setup is a few lines that every developer knows from the OpenTelemetry docs, and the real value is the shared names and the propagation. It still gives one `AddCatTelemetry` call as a convenience.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
What is the foundation: OpenTelemetry only, or other backends too? How much of the OpenTelemetry API do we hide, and how much do we expose? The options:
- **OpenTelemetry only, nothing hidden.** The module uses `ActivitySource` and `Meter` from .NET and the OpenTelemetry SDK. Cost: none, and it is the standard.
- **Our own abstraction** over tracing. Cost: a lot of surface for no gain, since `System.Diagnostics` is already the abstraction.

Recommendation: OpenTelemetry only, with `System.Diagnostics` as the API in the modules. Other backends plug in as OpenTelemetry exporters.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Which exporters do we support, and which telemetry backend will you really use in Azure? The options:
- **OTLP only.** Every backend (Grafana, Aspire dashboard, Azure Monitor through a collector) takes OTLP. Cost: the developer sets up a collector for Azure Monitor.
- **OTLP plus the Azure Monitor exporter** as an optional project. Cost: one more project, and it targets the latest .NET.
- **Leave exporters to the application.** The module only sets up the sources. Cost: none, and it is what `ServiceDefaults` does with its OTLP switch.

Recommendation: OTLP built in (switched on by `OTEL_EXPORTER_OTLP_ENDPOINT`, like `ServiceDefaults`), the rest the application's choice. This needs the owner's answer for Azure: Application Insights, Grafana or something else decides whether the optional Azure project is worth it.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Which metrics, for which parts? The options:
- **Counts and durations per service request only,** since the service request decorator already has an activity.
- **Per command, query and workflow too.** Cost: more instruments and more cardinality.
- **Only on request by the developer,** with a switch per part. Cost: a setting per part.

Recommendation: counts, durations and failure counts per service request, and the same for command and query as an option in the registration. The owner decides which metrics matter first, and this is the recommended minimum.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Do we want one naming scheme for activity sources, meters, tags and span names? The `Cat.*` prefix is the start, and today it is not consistent: the workflow source is `Cat.FluentWorkFlows`, which is now `Cat.FluentWorkflows`, see the [module readme of Cat.FluentWorkflows](../modules/Cat.FluentWorkflows/README.md). The options:
- **Yes, one scheme:** source and meter names equal the module name (`Cat.Messaging`), tags in a `cat.` prefix (`cat.job.name`). Cost: a rename of a few existing names.
- **No scheme,** each module picks. Cost: a developer cannot predict names.

Recommendation: yes, the module name as the source and meter name, and a short tag list in the module readme. The rename of the workflow source goes with the FluentWorkflows answer.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Who carries the trace context over the Service Bus: this module or `Cat.Messaging`? The Service Bus SDK already puts the trace context (`Diagnostic-Id`) on a message, see [Cat.Messaging.md](../modules/Cat.Messaging/README.md). The options:
- **`Cat.Messaging`,** since the SDK does it and the module sets the properties. Cost: none for `Cat.Telemetry`.
- **This module** with a helper that writes and reads the context. Cost: messaging then depends on telemetry, which the toolbox rule does not like.

Recommendation: `Cat.Messaging`. `Cat.Telemetry` only makes sure the `Cat.Messaging` source is listed.
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
How do logs relate to traces? The options:
- **The built-in .NET link.** The logger adds the trace id and span id to every log record while an activity is on. Cost: none, if the OpenTelemetry logging provider is on.
- **A correlation id in every log scope too.** Cost: one more id to carry, and the `CorrelationId` of a message (see [Cat.Messaging.md](../modules/Cat.Messaging/README.md)) already covers a business flow.

Recommendation: the built-in link by default, and the correlation id of the message as a log scope in the event processor.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
What are the defaults and the configuration for sampling? The options:
- **Always on** (the default of OpenTelemetry in a demo). Cost: expensive in production.
- **A ratio based sampler,** configured in `appsettings`. Cost: a setting.
- **Left to the application.** Cost: none, but no default.

Recommendation: always on by default, with the ratio in a setting (`Cat:Telemetry:SamplingRatio`). A demo needs all traces, and a real service sets a ratio.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Are health checks in scope or not? `ServiceDefaults` has them today (the `self` check only). The options:
- **Out of scope.** They are not telemetry. Cost: a project without Aspire must write its own.
- **In scope** as an optional project with the readiness and liveness endpoints. Cost: scope creep, and it overlaps with the optional health check in the [module readme of Cat.EventProcessor](../modules/Cat.EventProcessor/README.md).

Recommendation: out of scope. The name is `Cat.Telemetry`, and a health check is a separate concern. Other modules offer their own `IHealthCheck`.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Do we want a rule for personal data in telemetry? Personal data must stay out of tags. The options:
- **A guideline in the readme.** Cost: nobody enforces it.
- **A filter** that removes known tags (such as `user.email`) before export. Cost: a list of names that is never complete.
- **Both.**

Recommendation: both, with a small filter on a short list of tag names.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Do we also adopt the tracing filters of `ServiceDefaults`, such as the `/health` paths, in the module? The options:
- **Yes, the same filters,** for health checks and alive endpoints. Cost: none, and the traces look the same in both setups.
- **No.** Cost: a project without Aspire gets noisy traces.

Recommendation: yes, the same filters, with the paths as a setting.
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Should the existing activity sources move into this module, or stay in their own decorators? The options:
- **Stay.** Each module owns its source, and this module only lists them. Cost: none.
- **Move.** Cost: every module that traces then depends on `Cat.Telemetry`, which breaks the toolbox rule.

Recommendation: stay. This module lists the `Cat.*` sources in one place and sets the naming scheme (question 5).
<!-- region end: Question 12-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->