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

# Plans for Cat.Api.Client

Typed API clients that call other services through the API gateway.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

A service sometimes needs data or an action from another service, and it needs the answer to go on. The architecture says that call always goes through the API gateway. Writing a plain `HttpClient` call every time means repeating the same work: the address, the token, the error mapping and the retries.

`Cat.Api.Client` gives a typed client for that call. It returns an `ICatResponse`, like everything else in the toolkit, so a failed call looks like any other failed use case.

## What we already know

From the root readme:

- Services never call each other directly. The call goes through the API gateway.
- A service only needs to know the gateway address.
- The `Contracts` project of a service has almost no dependencies, so other services and clients can reference it. Sharing it is a choice of the developer, not a rule.

From the demo plan and the Aspire plan:

- Orders needs the current price of every book. `IPriceProvider` hides that behind an interface in the core. Today a fake sits behind it.
- The first real version is a plain `HttpClient` class, `CatalogPriceProvider`, in `Orders.Infrastructure`. It calls `GET /catalog/books/prices?bookIds=<id>`.
- Build this module from that working code, not up front. Then the design follows what we learned: how a client is declared, how the token is forwarded, how error responses map to `ICatResponse` and how it works with `Cat.Resilience`.
- When the module exists, only the registration in `Orders.Infrastructure` changes. `IPriceProvider`, the workflow step and the tests stay.
- Orders does not reference `Catalog.Contracts`. It reads the response into a small model that belongs to Orders. That is a choice for this call, as the demo plan explains. A later demo call shares contracts, to show the other option.
- The mapping table of the Aspire plan is a start for the error mapping: 200 gives an Ok response, 404 a failed response, 400 and other statuses an error response, a network error or timeout an error response.
- Catalog reads are public. Once Keycloak arrives, the call forwards the token of the caller. Calls without a user use a client credentials token.
- The standard resilience handler from `ServiceDefaults` already adds retries and a circuit breaker to every `HttpClient`.

From the module conventions:

- `Cat.Minimal.Api` maps service requests to endpoints and documents the responses. A client could be the mirror image: a service request type goes in, an HTTP call is made, a response comes out.
- Infrastructure treats an integration like a database. The core never calls it directly. It sends a query or a command, and a handler calls the other service.

From the code of the demo, checked while preparing this plan:

- `CatalogPriceProvider` works, but it calls Catalog directly, at `https+http://catalog`. That breaks the rule that services go through the gateway. The registration is in `Orders.Infrastructure`.
- The gateway routed `catalog` and `orders` only when this plan was written. Orders called the payment service directly, and it had no login. Both are done now, see the decision on the payment call.
- Catalog reads, such as the price endpoint, are public at the gateway. The realm has no client for calls without a user.
- `CatProblemDetails` is the error body of every service. It lives in `Cat.Minimal.Api`, which targets `net10.0`. It derives from the ASP.NET Core `ProblemDetails`, and its errors are `ICatError` interfaces that a client cannot deserialize. So a `netstandard2.0` client needs a plain class of its own for that shape.
- `Cat.Responses` and `Cat.Api.Gateway.Abstractions` already target `netstandard2.0`.
- `ServiceDefaults` adds the standard resilience handler, with retries and a circuit breaker, to every `HttpClient`. `Cat.Resilience` is only a plan.
- The AppHost makes the gateway wait for Orders. Orders must not wait for the gateway, or both wait forever. The gateway has a fixed port, so Orders can also get the address from configuration.
- The React client generates its types from a saved OpenAPI document of each service, in its `api/` folder, and a script refreshes the copy from the running AppHost. The services only publish the document in Development.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Route | Calls go through the API gateway. |
| Result | The client returns an `ICatResponse`. |
| Order of work | The module is built from the working `HttpClient` code of Orders. The owner wants it before the Inventory stage of the demo. |
| Aspire | The module never references Aspire. |
| What matters | The client has no references except the module. It is easy to set up. A caller references the client and sets the address of the gateway. |
| Declaration | The clients are generated with NSwag from a saved OpenAPI document. The generated code is checked in, so a fresh clone builds without the generator. |
| Generation project | None. NSwag reads the saved document, so no project needs a reference to the API project. |
| Layout | A service that offers a client gets a `ServiceName.Api.Client` project. It references the module and nothing else. The saved OpenAPI document and the NSwag settings sit with it. |
| Errors | The generated code throws on a failed call. The module turns that into an `ICatResponse` in one place, so the generated code stays as it is. |
| Models | By default the client has its own generated models. Sharing the `Contracts` project of the service is the choice of the developer, see the root readme. |
| Shared Contracts | The generated class and its methods are the same with and without shared `Contracts`. When the developer shares `Contracts`, the generator skips the models and imports the namespace of `Contracts`, and the client project references `Contracts`. The module is referenced in both cases, because it holds the base class, the exception type, the wrapper to `ICatResponse` and the NSwag settings template. To check before this variant is relied on: that NSwag skips the models and finds the `Contracts` types without a name mismatch. The first client, for Catalog, uses its own models, so this does not block the build. |
| Token | The client forwards the token of the caller. A client credentials token waits until a call needs it, because the realm has no client for that. |
| Error class | The error body shape for clients is a plain class, for example `CatErrorResponse`, in `Cat.Api.Client`. Only the client uses it, so it is not shared and needs no project of its own. It has the same JSON shape as `CatProblemDetails` and a concrete error item. `CatProblemDetails` stays in `Cat.Minimal.Api`, because it needs the ASP.NET Core `ProblemDetails` base. A test keeps the two shapes equal. The wrapper of the module reads the body text of a failed call into the class, so it does not depend on the generated models. |
| Address | The address of the gateway can come from configuration or from service discovery. Both work, and the module works without Aspire. |
| Serializer | The generated code uses System.Text.Json, so the client has no extra package. |
| Resilience | For now the client relies on the `HttpClient` handler from `ServiceDefaults`. Later, a developer who does not use Aspire should be able to use `Cat.Resilience` instead. That is looked at together with the plan of that module, see [Cat.Resilience](Cat.Resilience.md). |
| Refresh | A script refreshes the saved OpenAPI document and runs the generation, like `api:refresh` of the React client. The output is checked in. Other ways, such as an MSBuild step, can come later. |
| Use | The typed client is used inside a query or command handler in the infrastructure, as the readmes describe the architecture. A developer who wants to use it directly from a request handler can do so. The module does not forbid it. |
| Tracing | The trace continues across the call. Whether the `HttpClient` instrumentation is enough for that is checked when the first call works. |
| First version | No versioned APIs. JSON with GET and POST only, without file uploads and streaming. |
| First client | Catalog, for the price call of Orders. |
| Direct calls | Services never call each other directly, the payment service included. Every call goes through the gateway. The drawing of the demo shows this. |
| Order of the calls | The call to Catalog came first. The payment call followed. |
| Payment call | Orders calls the payment service through the gateway, with a generated client like the Catalog one. The gateway has a restricted route for `payment`, so a token is needed. Orders forwards the token of the user with a handler of its own, and the payment service validates the same token. Client credentials are not built, because no call without a user exists yet. |
| Audience | The clients are for .NET code. The React client does not use the module. It generates TypeScript from the same OpenAPI documents. |

### Open

The numbers match the questions below. A number stays with its question, so an answered question leaves a gap. Recommendations are marked. They are not decisions.

- **Is the module stable?** The module is built and 27 tests pass. Orders uses it for three generated clients (Catalog, payment and Inventory). Two things from the decisions are still unchecked, so I did not call it stable and I did not touch the badge, the roadmap or this plan. Your call once these are settled:
  - **Shared Contracts variant.** The decision says to check that NSwag skips the models and imports the namespace of `Contracts`. Nothing in the demo does it yet, and the readme only describes the default.
  - **Tracing.** The decision says to check that the trace continues across the call. Check it in the Aspire dashboard with one placed order.
- **What the readme lacks from this plan.** The readme covers the layout, the NSwag settings, the call helper, the registration, the error mapping and resilience. These decisions are not in it yet:
  - The token. The module does not forward it. The demo does that with its own `ForwardBearerTokenHandler` in Orders. A reader needs to know that, and how to add such a handler.
  - The refresh script that downloads the OpenAPI document and runs the generation, such as `Refresh-CatalogClient.ps1`.
  - The first version limits: no versioned APIs, GET and POST with JSON only, no uploads or streaming.
  - The audience: the clients are for .NET code, and the React client generates TypeScript from the same documents.
  - The shared `Contracts` variant, once it is checked.
- **If both are settled.** Then the readme gets these chapters, the roadmap stage 3b is marked done (it is not yet), the in development badge leaves the module overview, and the plan file and its links go. Links to remove: the Plans column of the module row in the root `README.md`, `plans/Demo.md` (stage 3b and the notes), `plans/Cat.Resilience.md` and `plans/Cat.Telemetry.md` if they link it. The header line "Status: not started" in this plan is out of date as well.

## Questions before building

The numbers are the numbers of the open points above.

None at the moment.
