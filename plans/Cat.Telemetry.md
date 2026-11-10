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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

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
- The module does not exist yet. It is listed under the future modules in the readme.
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
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Is it a module at all? What does it add beyond a few lines of OpenTelemetry setup? Maybe naming rules, metric definitions and the propagation over messages. It could also become documentation. The module is for projects without Aspire. What is the minimum setup it must give them, and what only extends `ServiceDefaults`?
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
What is the foundation: OpenTelemetry only, or other backends too? How much of the OpenTelemetry API do we hide, and how much do we expose?
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Which exporters do we support: OTLP, and Azure Monitor or Application Insights for Container Apps? Which are built in, and which is the application's choice? Which telemetry backend will you really use in Azure: Application Insights, Grafana, something else?
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Which metrics, for which parts? Counts and durations per service request, per command, per query, per workflow, or only what is asked for? Which metrics matter to you first?
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Do we want one naming scheme for activity sources, meters, tags and span names? The `Cat.*` prefix is the start.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Who carries the trace context over the Service Bus: this module or `Cat.Messaging`?
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
How do logs relate to traces? Think of correlation ids and the link between logs and traces.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
What are the defaults and the configuration for sampling?
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Are health checks in scope or not? `ServiceDefaults` has them today. Should the module add them, or leave them out?
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Do we want a rule for personal data in telemetry? Personal data must stay out of tags. Is that a guideline or a filter?
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Do we also adopt the tracing filters of `ServiceDefaults`, such as the `/health` paths, in the module?
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Should the existing activity sources move into this module, or stay in their own decorators?
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
In the demo, how do we show "one order across all services" before every service exists? Catalog, Orders, Payment and Inventory exist today. Notifications does not.
<!-- region end: Question 13-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->