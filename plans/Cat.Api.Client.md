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

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Route | Calls go through the API gateway. |
| Result | The client returns an `ICatResponse`. |
| Order of work | The module is built from the working `HttpClient` code of Orders. |
| Aspire | The module never references Aspire. |

### Open

- **Contracts.** Sharing is a choice per call, so the module should work with both: a client built on the shared `Contracts` types, and a client with its own models. Which is the default, and does the module need to know which one is used?
- **Declaration.** How is a client declared? An interface with attributes, a service request type, a fluent registration, or generated from OpenAPI?
- **Generation.** Generate from the OpenAPI documents that `Cat.Minimal.Api` produces, or write by hand and keep it small?
- **Token.** Forward the token of the current user, use a client credentials token, or choose per call?
- **Error mapping.** Is the error shape the same everywhere? `Cat.Minimal.Api` says services share one error shape, so a client could turn it back into the original `ICatResponse` errors.
- **Resilience.** Does the client rely on the `HttpClient` handler from `ServiceDefaults`, on `Cat.Resilience`, or both? Two retry layers multiply.
- **Addresses.** The gateway address comes from configuration or Aspire service discovery. The module must work without Aspire.
- **Handler or client.** Is the typed client used inside a query or command handler in the infrastructure, as the architecture suggests?
- **Tracing.** Does the trace continue across the call? `HttpClient` instrumentation may be enough.

## Questions before building

1. Should the module work equally well with shared `Contracts` and with the caller's own models, and which one is the default?
2. Should the client be generated from OpenAPI, or written by hand from a request type?
3. Which token goes with the call by default?
4. May the module assume the shared error shape of `Cat.Minimal.Api` on the other side?
5. Where does retry live: `ServiceDefaults`, `Cat.Resilience` or this module?
6. How does a client find the gateway outside Aspire?
7. Do we need versioned APIs in the first version?
8. Should the first release wait until Orders has used `CatalogPriceProvider` for a while, as the Aspire plan suggests?
9. Is it enough for the module to cover GET and POST with JSON, or do we need file uploads and streaming?
10. Do we also want a `Cat.Api.Client` flavor for the React client, or is that out of scope?
