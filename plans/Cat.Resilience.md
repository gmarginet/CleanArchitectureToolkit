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

# Plans for `Cat.Resilience` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catresilience)
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
A new module, `Cat.Resilience`, with retry and circuit breaker for calls to other services and integrations.

#### The idea
Calls to other services and to external systems fail now and then. A retry fixes a short glitch. A circuit breaker stops hammering something that is down. A decorator could add both to a handler without touching its code, but whether decorators are the way is still open, see question 12.

#### Background
From the readme:
- External integrations, like an email provider or a storage account, live in the infrastructure project. The core never calls them. It sends a query or a command, and a handler talks to the integration.
- A call to another service goes through the API gateway.
- A slow or unavailable service must not bring down the caller.

From the demo plan:
- The demo case is retry and circuit breaker on the payment call. The payment call goes to a separate `Cat.Demo.PaymentService` that can fail on purpose. See the payment provider decision in [Demo.md](Demo.md#phase-5).
- `Aspire ServiceDefaults` already adds the standard resilience handler to every `HttpClient`: retries, timeouts and a circuit breaker.
- That overlaps with the future `Cat.Resilience` and `Cat.Telemetry` modules on purpose. CAT is a toolbox, so the developer picks what to use.
- The future module must work in projects that do not use Aspire, and must not depend on Aspire or on `ServiceDefaults`.
- The rule: a project with Aspire uses `ServiceDefaults` and does not need this module. The module exists for projects without Aspire. The only reason to use both is to extend `ServiceDefaults`, and then the extension can live in the module.

From the Aspire plan:
- The `CatalogPriceProvider` gets its retries from the `HttpClient` handler. `Cat.Api.Client` has to work together with this module.

From the module conventions:
- Handlers of `Cat.Commands`, `Cat.Queries` and `Cat.ServiceRequests` run through decorators from `Cat.Decorators`. Whether resilience uses them is open, see question 12.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- The demo uses the standard resilience handler of `ServiceDefaults` for its `HttpClient` calls. The demo readme says it does not use this module for now.
- The separate payment service exists as `Cat.Demo.PaymentService`. Its configuration has a latency and an outage setting, so it can fail on purpose.
- The Orders tests include `FastFailResilienceTests`.

#### Decided
- **Independence.** The module works without Aspire and never references it.
- **Overlap.** With Aspire, use `ServiceDefaults` and skip this module. The module exists for projects without Aspire. It may also hold extensions of `ServiceDefaults`.
- **Demo stand-in.** The payment call in the demo goes to a separate, flaky `Cat.Demo.PaymentService`, so the module has something to show.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
The module is for projects without Aspire. May we depend on Polly for that? This is the blocking question, and questions 4, 6, 8 and 11 follow from it. `Microsoft.Extensions.Http.Resilience`, which `ServiceDefaults` uses, is built on Polly v8 already, and `Polly.Core` targets `netstandard2.0` (to verify when the project is added). The options:
- **Polly v8 (`Polly.Core`) directly.** The standard, well known, supports retry, circuit breaker, timeout and fallback as one pipeline. Cost: a dependency, and its API leaks into any extension point we expose.
- **`Microsoft.Extensions.Resilience`** (Polly with the .NET registration and telemetry). Cost: the latest .NET, and a bigger set of packages.
- **Our own small policies.** Cost: a lot of subtle code (jitter, breaker states) that Polly already solved.

Recommendation: Polly v8 behind our own small settings classes, so the decorators expose `CatRetryOptions` and not Polly types. The toolbox rule is satisfied because a developer who does not use the module pulls in nothing.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Do we want the decorators on handlers, on `HttpClient`, or both? The options:
- **On handlers** (query and command handlers in the infrastructure, which is where integrations live). Cost: a retry of a whole handler, which may include a database write.
- **On service requests.** Cost: too coarse, because a request can contain several calls.
- **On `HttpClient`** (a message handler). Cost: only covers HTTP, and it is what `ServiceDefaults` does already.
- **Both handlers and `HttpClient`.** Cost: the retry on retry problem (question 5).

Recommendation: decorators on query and command handlers in the infrastructure, which is the layer that talks to integrations, and an optional `HttpClient` helper in a separate project for projects without Aspire. Nothing on service requests.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
How should a command say it is safe to retry? A retried command may run twice. Only queries and idempotent commands may be retried. The options:
- **A marker on the command,** such as `ICatRetryable`. Cost: the command depends on this module, or on a shared abstraction.
- **A registration,** such as `AddRetry<PaymentCommand>()`. Cost: the rule is away from the command, but the core stays free of the module.
- **Queries only.** Cost: a command to an unreliable service gets no retry.

Recommendation: the registration, and queries by default. A command is never retried unless a developer lists it, which is the safe default, and it follows the rule that the core knows no modules.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Which failures count: exceptions, failed responses, or specific error codes? A 404 should not be retried. The options:
- **Exceptions only.** Cost: a failed `ICatResponse` such as `InternalServerError` is not retried, though it is often transient.
- **Exceptions and the failed response types that are transient** (`InternalServerError` and a gateway timeout, not `NotFound`, `BadRequest`, `Conflict`). Cost: a table to document, like the one in the [module readme of Cat.EventProcessor](../modules/Cat.EventProcessor/README.md) for failed messages.
- **A predicate per policy.** Cost: more code per policy.

Recommendation: exceptions plus `InternalServerError`, with a predicate override. It matches the table of the event processor plan, so a developer learns one rule for "which failures are transient".
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
How do we prevent retries on retries with the `ServiceDefaults` handler? The `HttpClient` handler retries, and this decorator retries on top. Three times three is nine calls. The options:
- **Document it.** One layer per call: with Aspire use the handler of `ServiceDefaults`, without Aspire use this module. Cost: a developer can still mix them.
- **Detect it.** The module checks whether the `HttpClient` has the standard handler and warns at startup. Cost: it must know about `Microsoft.Extensions.Http.Resilience`.
- **A shared "already retried" marker** on the request. Cost: a convention across layers.

Recommendation: document it, plus a startup warning when the module is registered next to the standard handler. This follows the rule in the Decided list (with Aspire skip the module).
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Do we need fallbacks and timeouts in the first version, or only retry and circuit breaker? The options:
- **Retry and circuit breaker only,** as the goal says. Cost: a developer adds a timeout with the framework.
- **Add a timeout.** Cost: small, and Polly has it as a strategy.
- **Add a fallback too.** Cost: a fallback is business logic (what is a good default?), so it needs a design.

Recommendation: retry, circuit breaker and timeout. A call without a timeout is not safe to retry, and Polly makes it small. Leave the fallback out.
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
Where do policies live: attributes, code or `appsettings`? Is there one default, named policies, or a policy per handler type? The options:
- **Code in the registration,** with defaults. Cost: a change needs a deploy.
- **`appsettings` with named policies,** and the registration refers to a name. Cost: a settings class and names to keep in step.
- **Attributes on the handler.** Cost: the handler depends on this module.

Recommendation: one default policy, named policies in `appsettings`, and the registration says which name a handler uses. This is the same pattern as the schedule settings in [Cat.Scheduling.md](Cat.Scheduling.md) (code default, configuration override).
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
Does the module tell `Cat.Telemetry` about every retry and break? Retries and breaker changes are logged. Metrics and traces depend on `Cat.Telemetry`. The options:
- **Log only.** Cost: no numbers.
- **Metrics through `System.Diagnostics.Metrics`** with the source name `Cat.Resilience`, no dependency on `Cat.Telemetry`. Cost: a small meter class.

Recommendation: logs plus the metrics, and no dependency on `Cat.Telemetry`. Any OpenTelemetry setup picks them up, as in the plans of `Cat.Messaging` and `Cat.Caching`.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
`Cat.Api.Client` stays with the `HttpClient` handler of `ServiceDefaults` for now, see the [Resilience chapter](../modules/Cat.Api.Client/README.md#resilience) of the readme of `Cat.Api.Client`. How does a project without Aspire use this module with that client? The options:
- **The `HttpClient` helper of question 2.** The developer adds it to the builder that `AddCatApiClient` returns. Cost: it needs `AddCatApiClient` to return the `IHttpClientBuilder` (check this).
- **A decorator on the handler that uses the client.** Cost: a retry of the whole handler.

Recommendation: the `HttpClient` helper. It is the same place `ServiceDefaults` hooks in, so the project without Aspire gets the same shape.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
What is the scope of the circuit breaker state: per process, per handler or per target? Shared across instances is probably not needed. The options:
- **Per target** (a service address or integration name). A failing service opens its own circuit and the others stay closed. This is how `ServiceDefaults` works too (see [Demo.md](Demo.md#phase-5)). Cost: a key to define.
- **Per handler type.** Cost: two handlers that call the same service have separate circuits.
- **Per process, one for all.** Cost: one failing service opens the circuit for all.

Recommendation: per target, per process. It fits what `ServiceDefaults` does, and sharing across instances is not needed for a first version.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Tests need to move time. How do we support `TimeProvider`? The options:
- **Pass the `TimeProvider` into the Polly pipeline** (Polly v8 supports it). Tests use `FakeTimeProvider`. Cost: none.
- **Not supported.** Cost: tests wait for real delays.

Recommendation: pass it in. It is the same answer as the decision on time in [Cat.Scheduling.md](Cat.Scheduling.md), and `Cat.UnitTesting` points to the Microsoft `FakeTimeProvider`.
<!-- region end: Question 11-->
<!-- region start: Question 12-->
#### Question 12
Are decorators the way to apply retry and circuit breaker? The owner is not sure, for the same reason as the inbox of `Cat.EventProcessor`: a decorator wraps every handler of a service type, so it is all or nothing, and a retry on a handler that does not call another service is useless. Questions 2 and 5 assume decorators, so look at them again after this answer. The options:
- **A. A decorator with a lookup per handler or request type.** It wraps every handler and passes the call on when the type has no resilience setting. Cost: every handler is wrapped, and the decorator needs a number in the order of `Cat.Decorators`.
- **B. A decorator that a developer switches on per handler.** It needs a condition in `Cat.Decorators`. Cost: a change in another module.
- **C. No decorator. The handler runs the call inside a pipeline from the module.** Cost: the handler code changes, but the retry covers only the call that needs it and not a database write, which answers the worry in question 2.
- **D. Only an `HttpClient` helper.** Cost: it covers HTTP only, which is what `ServiceDefaults` does already.

Recommendation: C. The retry belongs around one call to another service and not around a whole handler, so the handler decides where it starts and ends. This is the owner's call, and the discussion stays open.
<!-- region end: Question 12-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->