# Plans for Cat.Telemetry

Shared tracing and metrics setup for all services.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

With many small services, one slow order can touch five of them. Without traces and metrics nobody can follow it. Every service needs the same setup, with the same names, so the pieces fit together.

`Cat.Telemetry` is that shared setup, for projects that do not use Aspire. A project that uses Aspire already has it in `ServiceDefaults` and does not need this module, except to extend it.

## What we already know

From the existing modules:

- `Cat.ServiceRequests.Decorators.ActivitySource` already traces every service request. The wildcard source `Cat.*` picks up the traces of the CAT modules, including the workflows.
- The logging decorators of `Cat.Commands`, `Cat.Queries` and `Cat.ServiceRequests` log the handlers.

From the demo plan and the Aspire plan:

- The demo case is tracing one order across all services.
- `Aspire ServiceDefaults` sets up logs, metrics and traces with OpenTelemetry, a readiness and a liveness check, and the resilience handler. It exports through OTLP when `OTEL_EXPORTER_OTLP_ENDPOINT` is set.
- That overlaps with this module on purpose. CAT is a toolbox, so the developer picks what to use. A project with Aspire uses `ServiceDefaults`. A project without Aspire uses this module.
- `Cat.Telemetry` must work in projects that do not use Aspire. Modules must not depend on Aspire or on `ServiceDefaults`.
- In the demo, ServiceDefaults covers the basics, and the CAT modules add what it does not, such as the decorators on service requests.
- The health checks of `ServiceDefaults` only say the process runs. They check no database yet.

From the saga plan:

- Save the trace context in a stored workflow instance, so the second half of a workflow joins the same trace.
- Tracing across the gap of a message needs the trace context in the message properties.

From the architecture:

- Everything runs as containers in Azure Container Apps.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Independence | Works without Aspire. |
| Overlap | With Aspire, use `ServiceDefaults` and skip this module. The module exists for projects without Aspire. It may also hold extensions of `ServiceDefaults`, so they are useful outside the demo. |
| Existing tracing | The `Cat.*` activity sources stay as they are. |

### Open

- **Is it a module at all?** What does it add beyond a few lines of OpenTelemetry setup? Maybe naming rules, metric definitions and the propagation over messages. It could also become documentation.
- **Foundation.** OpenTelemetry only, or other backends too?
- **Exporters.** OTLP, and Azure Monitor or Application Insights for Container Apps? Which are built in, and which is the application's choice?
- **Metrics.** Which ones, for which parts? Counts and durations per service request, per command, per query, per workflow, or only what is asked for?
- **Naming.** One naming scheme for activity sources, meters, tags and span names. The `Cat.*` prefix is the start.
- **Propagation.** Who carries the trace context over the Service Bus: this module or `Cat.Messaging`?
- **Logs.** Correlation ids and the link between logs and traces.
- **Sampling.** Defaults and configuration.
- **Health checks.** In scope or not? ServiceDefaults has them today.
- **Privacy.** Do not put personal data in tags. A guideline or a filter?

## Questions before building

1. The module is for projects without Aspire. What is the minimum setup it must give them, and what only extends `ServiceDefaults`?
2. Which telemetry backend will you really use in Azure: Application Insights, Grafana, something else?
3. Which metrics matter to you first?
4. Does this module own the trace propagation over messages, or `Cat.Messaging`?
5. Should it add health checks, or leave that out?
6. Do we also adopt `ServiceDefaults` tracing filters, such as the `/health` paths, in the module?
7. How much of the OpenTelemetry API do we hide, and how much do we expose?
8. Should existing activity sources move into this module, or stay in their own decorators?
9. Do you want a rule for personal data in telemetry?
10. In the demo, how do we show "one order across all services" before Inventory and Notifications exist?
