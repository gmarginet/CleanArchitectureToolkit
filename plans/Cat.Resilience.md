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

# Plans for Cat.Resilience

Retry and circuit breaker decorators for calls to other services and integrations.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Calls to other services and to external systems fail now and then. A retry fixes a short glitch. A circuit breaker stops hammering something that is down. Decorators can add both to a handler without touching its code.

## What we already know

From the root readme:

- External integrations, like an email provider or a storage account, live in the infrastructure project. The core never calls them. It sends a query or a command, and a handler talks to the integration.
- A call to another service goes through the API gateway.
- A slow or unavailable service must not bring down the caller.

From the demo plan:

- The demo case is retry and circuit breaker on the payment call. The provider is a fake today, so the module needs something to protect. `FakePaymentProvider` always answers.
- `Aspire ServiceDefaults` already adds the standard resilience handler to every `HttpClient`: retries, timeouts and a circuit breaker.
- That overlaps with the future `Cat.Resilience` and `Cat.Telemetry` modules on purpose. CAT is a toolbox, so the developer picks what to use.
- The future module must work in projects that do not use Aspire, and must not depend on Aspire or on `ServiceDefaults`.
- The rule: a project with Aspire uses `ServiceDefaults` and does not need this module. The module exists for projects without Aspire. The only reason to use both is to extend `ServiceDefaults`, and then the extension can live in the module.

From the Aspire plan:

- The `CatalogPriceProvider` gets its retries from the `HttpClient` handler. `Cat.Api.Client` has to work together with this module.

From the module conventions:

- Handlers of `Cat.Commands`, `Cat.Queries` and `Cat.ServiceRequests` run through decorators from `Cat.Decorators`.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Place | Decorators on handlers that call other services and integrations. |
| Independence | The module works without Aspire and never references it. |
| Overlap | With Aspire, use `ServiceDefaults` and skip this module. The module exists for projects without Aspire. It may also hold extensions of `ServiceDefaults`. |

### Open

- **Foundation.** Build on Polly and `Microsoft.Extensions.Resilience`, or write our own small policies? Polly is the standard, but it is a dependency.
- **What gets decorated.** Query and command handlers in the infrastructure, which is where integrations live? Or service requests?
- **Policy.** One default, named policies, or a policy per handler type? Declared by attribute, registration or configuration?
- **Retry safety.** A retried command may run twice. Only queries and idempotent commands may be retried. How does a handler say it is safe?
- **Failures.** What is a failure: an exception, a failed `ICatResponse`, or certain error codes only? A 404 should not be retried.
- **Double retry.** The `HttpClient` handler retries, and this decorator retries on top. Three times three is nine calls. How do we avoid that?
- **State of the breaker.** Per process, per handler or per target? Shared across instances is probably not needed.
- **Fallback and timeout.** In scope, or only retry and circuit breaker?
- **Visibility.** Log retries and breaker changes. Metrics and traces depend on `Cat.Telemetry`.
- **Testing.** Tests need to move time. `TimeProvider` support is needed.

## Questions before building

1. The module is for projects without Aspire. May we depend on Polly for that?
2. Do you want the decorators on handlers, on `HttpClient`, or both?
3. How should a command say it is safe to retry?
4. Which failures count: exceptions, failed responses, or specific error codes?
5. How do we prevent retries on retries with the `ServiceDefaults` handler? Should the module detect it, or do we document it?
6. Do we need fallbacks and timeouts in the first version?
7. Where do policies live: attributes, code or `appsettings`?
8. Should the payment call in the demo get a real, flaky stand-in so the module has something to show?
9. Does the module tell `Cat.Telemetry` about every retry and break?
10. Does `Cat.Api.Client` use this module internally, or stay with the `HttpClient` handler?
