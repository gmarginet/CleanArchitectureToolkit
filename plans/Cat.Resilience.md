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

# Plans for `Cat.Resilience` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catresilience)
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
A new module, `Cat.Resilience`, with retry and circuit breaker decorators for calls to other services and integrations.

#### The idea
Calls to other services and to external systems fail now and then. A retry fixes a short glitch. A circuit breaker stops hammering something that is down. Decorators can add both to a handler without touching its code.

#### Background
From the root readme:
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
- Handlers of `Cat.Commands`, `Cat.Queries` and `Cat.ServiceRequests` run through decorators from `Cat.Decorators`.

#### What exists today
- The module does not exist yet. It is listed under the future modules in the root README.
- The demo uses the standard resilience handler of `ServiceDefaults` for its `HttpClient` calls. The demo readme says it does not use this module for now.
- The separate payment service exists as `Cat.Demo.PaymentService`. Its configuration has a latency and an outage setting, so it can fail on purpose.
- The Orders tests include `FastFailResilienceTests`.

#### Decided
- **Place.** Decorators on handlers that call other services and integrations.
- **Independence.** The module works without Aspire and never references it.
- **Overlap.** With Aspire, use `ServiceDefaults` and skip this module. The module exists for projects without Aspire. It may also hold extensions of `ServiceDefaults`.
- **Demo stand-in.** The payment call in the demo goes to a separate, flaky `Cat.Demo.PaymentService`, so the module has something to show.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
The module is for projects without Aspire. May we depend on Polly for that? The foundation can be Polly and `Microsoft.Extensions.Resilience`, or our own small policies. Polly is the standard, but it is a dependency.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Do we want the decorators on handlers, on `HttpClient`, or both? If on handlers: query and command handlers in the infrastructure, which is where integrations live, or service requests?
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
How should a command say it is safe to retry? A retried command may run twice. Only queries and idempotent commands may be retried.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Which failures count: exceptions, failed responses, or specific error codes? A 404 should not be retried.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
How do we prevent retries on retries with the `ServiceDefaults` handler? The `HttpClient` handler retries, and this decorator retries on top. Three times three is nine calls. Should the module detect it, or do we document it?
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Do we need fallbacks and timeouts in the first version, or only retry and circuit breaker?
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
Where do policies live: attributes, code or `appsettings`? Is there one default, named policies, or a policy per handler type?
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
Does the module tell `Cat.Telemetry` about every retry and break? Retries and breaker changes are logged. Metrics and traces depend on `Cat.Telemetry`.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
`Cat.Api.Client` stays with the `HttpClient` handler of `ServiceDefaults` for now, see [Cat.Api.Client.md](Cat.Api.Client.md). How does a project without Aspire use this module with that client?
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
What is the scope of the circuit breaker state: per process, per handler or per target? Shared across instances is probably not needed.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Tests need to move time. How do we support `TimeProvider`?
<!-- region end: Question 11-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->