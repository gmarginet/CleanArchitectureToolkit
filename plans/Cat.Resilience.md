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

<!-- region start: FirstStableVersion-->
**First stable version:** not reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 1](#phase-1)
- [Phase 2](#phase-2)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
A new module, `Cat.Resilience`, with named resilience profiles: an internal profile for calls to our own services and an external profile for calls to an outside provider. A profile goes on an `HttpClient`, or around one call that is not HTTP.

#### The idea
Calls to other services and to external systems fail now and then. A retry fixes a short glitch. A circuit breaker stops hammering something that is down. This phase puts both on `HttpClient`, with a profile per client, and around one call that is not HTTP. A retry around a whole handler comes later, in [Phase 2](#phase-2).

#### Background
From the readme:
- External integrations, like an email provider or a storage account, live in the infrastructure project. The core never calls them. It sends a query or a command, and a handler talks to the integration.
- A call to another service goes through the API gateway.
- A slow or unavailable service must not bring down the caller.

From the demo plan:
- The payment service becomes a stand-in for an outside payment provider, a plain REST API with no CAT modules. Orders calls it directly from its infrastructure, and the provider answers in the call. See the Decided list of [Demo.md](Demo.md#phase-17).
- `Aspire ServiceDefaults` adds the standard resilience handler of `Microsoft.Extensions.Http.Resilience` to every `HttpClient` today: retries, timeouts and a circuit breaker. That package is plain .NET and does not need Aspire.
- The future module must not depend on Aspire or on `ServiceDefaults`.

From the discussion with the owner (2026-11-20):
- A call to an outside provider needs other rules than a call to our own services: no blind retry of an unsafe method such as a payment `POST`, an idempotency key, `Retry-After` on `429`, and other timeouts.
- An external profile on one client must replace the default pipeline of that client, not stack on top of it.

From the packages (read in the local NuGet cache, 2026-11-21):
- `Microsoft.Extensions.Http.Resilience` 11.0.0 targets `netstandard2.0`, `net8.0`, `net9.0`, `net10.0` and `net11.0`. It has `RemoveAllResilienceHandlers`, and its retry options have `ShouldRetryAfterHeader`. Version 10.11.0 has the same targets except `net11.0`, and both members.
- `Directory.Packages.props` pins it at 11.0.0 for `net11.0` today. The `netstandard2.0` and `net10.0` group does not have it yet.
- `RemoveAllResilienceHandlers` is marked experimental by Microsoft (`EXTEXP0001`). `UseFastFailResilience` in Orders already uses it with the warning switched off.
- `Polly.Core` 8.7.0 targets `netstandard2.0`.
- `Microsoft.Extensions.Http.Resilience` is built on `Microsoft.Extensions.Resilience`, which offers named pipelines for any call. Versions 10.11.0 and 11.0.0 of it target `netstandard2.0`.

From the Aspire plan:
- The `CatalogPriceProvider` gets its retries from the `HttpClient` handler. `Cat.Api.Client` has to work together with this module.

From the module conventions:
- Handlers of `Cat.Commands`, `Cat.Queries` and `Cat.ServiceRequests` run through decorators from `Cat.Decorators`. `AddDecorator` wraps every closed type of an open generic service type, so a decorator wraps every handler. The retry around a whole handler in [Phase 2](#phase-2) wraps the processors instead.
- A failed message handler is delivered again by the bus, see the [module readme of Cat.EventProcessor](../modules/Cat.EventProcessor/README.md). A call that is not HTTP inside a message handler, such as the SMTP mail of Notifications, already gets a retry that way.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- The demo uses the standard resilience handler of `ServiceDefaults` for its `HttpClient` calls. The demo readme says it does not use this module for now.
- The separate payment service exists as `Cat.Demo.PaymentService`. Its configuration has a latency, an error percentage and an outage setting, so it can fail on purpose.
- Orders replaces the standard handler on some clients with a shorter one in `UseFastFailResilience`, and `FastFailResilienceTests` covers it, see [Demo.md](Demo.md#phase-11).

#### Decided
- **Independence.** The module works without Aspire and never references it.
- **Role next to `ServiceDefaults`.** The module is the base for every project. It holds the resilience setup, and the demo `ServiceDefaults` calls it, for example `AddCatResilience(CatResilienceProfile.Internal)` on every `HttpClient`. A project without Aspire makes the same call in its `Program`. One module owns the pipeline of a client, so a client never gets two retry layers. The dependency goes from `ServiceDefaults` to the module, never back (owner, 2026-11-20).
- **Without Aspire.** The module readme gets a chapter "Without Aspire" with the calls a `Program` makes in place of `ServiceDefaults`. There is no second demo application without Aspire (owner, 2026-11-20).
- **Demo stand-in.** The payment call in the demo goes to an outside, flaky payment provider, so the module has something to show. See [Demo.md](Demo.md#phase-17) (owner, 2026-11-20).
- **Scope of this phase.** `HttpClient` profiles, an internal and an external one, and the pipelines for one call below. The external profile replaces the default pipeline of its client. No retry around a whole handler in this phase, see [Phase 2](#phase-2) (owner, 2026-11-21).
- **`Cat.Api.Client`.** A developer adds the `HttpClient` helper to the `IHttpClientBuilder` that `AddCatApiClient` returns. The code confirms that it returns one (owner, 2026-11-21).
- **Foundation.** The profiles build on `Microsoft.Extensions.Http.Resilience`, with `AddResilienceHandler` and `RemoveAllResilienceHandlers`, behind our own settings classes such as `CatRetryOptions`. No Polly types show in the public API. The package comes per target framework from `Directory.Packages.props`. `RemoveAllResilienceHandlers` is experimental (`EXTEXP0001`), and the module switches the warning off where it calls it, as Orders does today (owner, 2026-11-21).
- **Projects.** `Cat.Resilience.Abstractions` holds the profile names and the settings classes. `Cat.Resilience` holds `AddCatResilience` on `IHttpClientBuilder` and the pipelines for one call. Both target `netstandard2.0`. `Microsoft.Extensions.Http.Resilience` goes into both groups of `Directory.Packages.props` (owner, 2026-11-21).
- **Unsafe methods in the external profile.** A `POST`, `PUT`, `PATCH` or `DELETE` is retried only when the request carries an idempotency key. The caller sets the key from a business id that survives a restart, such as the saga id. The profile never makes a key itself. The header name is a setting of the profile, `Idempotency-Key` by default. Safe methods such as `GET` and `HEAD` are retried as usual (owner, 2026-11-21).
- **Named profiles.** `Internal` and `External` have code defaults. A developer adds a profile by name in configuration, such as `Cat:Resilience:Profiles:FastFail`, or in code at the registration, and configuration wins over code. The registration refers to a profile by name, such as `AddCatResilience("FastFail")`. A name that no profile has fails at startup. The fast fail of Orders becomes the profile `FastFail` (owner, 2026-11-21).
- **Strategies.** A profile holds the same five strategies as the standard handler of `Microsoft.Extensions.Http.Resilience`: a rate limiter, a total timeout, a retry, a circuit breaker and a timeout per try, with our own defaults per profile. No fallback. A switch of `ServiceDefaults` from the standard handler to the module keeps the behaviour of every service (owner, 2026-11-21).
- **Circuit per client.** The circuit breaker state is kept per registered `HttpClient` and per process, the default of the package with no pipeline selector. Every call to our own services goes through the gateway, so a state per authority would let one failing service open the circuit for the others. The `SelectPipelineByAuthority()` call and its comment in the demo `ServiceDefaults` go away when the demo switches to the module (owner, 2026-11-21).
- **Time.** The profiles use the `TimeProvider` of the service provider, so a test registers `FakeTimeProvider` and moves it forward. To check when building: whether `Microsoft.Extensions.Http.Resilience` takes the `TimeProvider` from the service provider by itself. If not, the module passes it in (owner, 2026-11-21).
- **Telemetry.** The module uses the logs and metrics that Polly already gives through `Microsoft.Extensions.Http.Resilience`, on the meter `Polly`, and adds the profile name as a tag when the package allows it. No own meter, so nothing is counted twice. `Cat.Telemetry` lists the `Polly` meter. To check when building: the meter name and the tag hook (owner, 2026-11-21).
- **Pipelines for one call.** The module also offers a pipeline from the same named profiles, which a handler runs around one call that is not HTTP, such as `_pipelines.Get("blob-upload").ExecuteAsync(...)`. Our own type, such as `ICatResiliencePipelines`, hides the Polly type. It covers only that call and never a database write of the handler. The module readme says that the call inside must be safe to repeat (owner, 2026-11-21).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
A retry and circuit breaker around a whole command or query, for a developer who wants it on a whole handler.

#### Background
- `AddDecorator` of `Cat.Decorators` wraps every closed type of an open generic service type, so a decorator wraps every handler. A decorator runs inside the scope of the handler. See the [module readme of Cat.Decorators](../modules/Cat.Decorators/README.md).
- A handler that wrote to the database and failed leaves its tracked entities in the `DbContext` of its scope. A retry in the same scope runs on that context.
- `CatCommandProcessor` and `CatQueryProcessor` open a new scope for every call. `ICatCurrentScopeCommandProcessor` runs in the current scope on purpose, see the [module readme of Cat.EventProcessor](../modules/Cat.EventProcessor/README.md).
- A failed message handler is delivered again by the bus, so a retry inside a message handler multiplies with the deliveries of the bus.

#### Needs
[Phase 1](#phase-1), built first.

#### Decided
- **Later, not in the first version.** The phase is built only when a real case needs it (owner, 2026-11-21).
- **Opt in per type.** The retry only acts for the request types a developer lists, such as `options.Retry<GetPriceQuery>()`. Nothing is retried by default, also no query. Every other handler is called once. It is the same pattern as `UseInbox` of `Cat.EventProcessor` (owner, 2026-11-21).
- **A fresh scope for every try.** A retry never runs on the scope of the try that failed (owner, 2026-11-21).
- **Around the processors.** The retry wraps `ICatCommandProcessor` and `ICatQueryProcessor` in the container. For a listed type, every try calls the inner processor again, which opens a new scope. Every other type passes straight through. It is not a decorator of `Cat.Decorators`, and `Cat.Decorators` stays unchanged. `ICatCurrentScopeCommandProcessor` gets no retry, and the module readme says why (owner, 2026-11-21).
- **Which failures count.** The same table as the event processor, see "What happens to a message" in the [module readme of Cat.EventProcessor](../modules/Cat.EventProcessor/README.md). `InternalServerError` and an exception are tried again. `BadRequest`, `NotFound`, `Conflict`, `Forbidden` and `Unauthorized` come back at once. An override per type changes the table, like `FailureOverrides` of the event processor (owner, 2026-11-21).
- **Retry on retry.** The module readme states one layer per call: the client profile for HTTP, the retry around the processor for a whole handler with no HTTP retry inside. It shows the example of a retried command whose client also retries, and the multiplication by the deliveries of the bus. The module does not detect it and adds no marker (owner, 2026-11-21).
- **Registration order.** The retry replaces the single scoped registration of `ICatCommandProcessor` and of `ICatQueryProcessor` with a wrapper that builds the original processor as its inner one. `Cat.Decorators` is not used, because it only wraps open generic types. The setup throws an `InvalidOperationException` at once when a listed command type has no command processor registered yet, or a listed query type no query processor. The check runs per kind, so a developer who lists only queries needs only `Cat.Queries`. The message names the call that is missing. A unit test with `FakeCommandProcessor` or `FakeQueryProcessor` gets no retry, and the module readme says so (owner, 2026-11-21).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->