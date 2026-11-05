# Plans for Cat.Authorization

A decorator that checks permissions before a service request runs.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Who may do what is a business rule, and it should live in the core service, where it can be tested without HTTP. A decorator on service requests can check the rule before the handler runs. A caller without permission gets a clear response, and the handler never starts.

## What we already know

From the demo plan:

- Authentication is OpenID Connect with Keycloak. The gateway and the services validate the same JWT. Services authorize on the claims.
- Catalog reads are public. Orders needs a login. Admins edit the catalog through a role claim.
- The demo has an `ICurrentUser` in `CoreService`. It is the starting point of the shared `ICatUser` of this module. It exposes `UserId`, `Name`, `Email` and `IsAdmin`. The business logic never sees `HttpContext`. The Api project implements it from the claims. A development stub reads the `X-Demo-User` header for `alice`, `bob` and `admin`.
- Until this module exists, ownership is a filter in the queries. The queries get the external id of the customer, or none for an admin. The orders of others come back as not found, so nothing leaks.
- Known gap in Catalog: `POST /catalog/books` has no authorization yet. The plan sketches a `CatalogAdmin` policy and `RequireAuthorization` on the endpoint. It also suggests an admin check as a decorator on `BookSaveRequest` over `ICurrentUser`, so the rule is testable in `CoreService`, plus a test that a non admin gets a 403.
- The gateway rejects an unauthenticated save as well, and the service checks the token again.

From the module conventions:

- `Cat.ServiceRequests` runs handlers through decorators for logging, tracing and validation. Authorization would be another one.
- `Cat.Minimal.Api` documents the responses of an endpoint. Orders endpoints already declare `CatResponseType.Unauthorized`.
- The `Contracts` project stays small and free of service internals, so a permission attribute on a request needs a home that Contracts can reference.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Place | A decorator on service requests. |
| Identity | The business logic only knows the user abstraction, never `HttpContext`. |
| User abstraction | `ICatUser` lives in `Cat.Authorization.Abstractions`, renamed from the demo's `ICurrentUser`. This module owns it. `Cat.Auditing` and other modules reference that project. The core service may reference it, because it only references abstractions. `Contracts` does not. |
| Two layers | The gateway and the service both validate the token. |
| Until the module exists | The demo keeps its own `ICurrentUser` and an owner filter in the queries. When `Cat.Authorization.Abstractions` exists, the demo switches to `ICatUser`. |

### Open

- **Members of `ICatUser`.** The demo has `UserId`, `Name`, `Email` and `IsAdmin`. `IsAdmin` is a demo rule. A general interface needs roles (`IsInRole`) or claims, and an `IsAuthenticated` flag. Is the id a string? Keycloak's `sub` is a string, and the demo stores it in `Customer.ExternalId`.
- **Package name.** `Cat.Auditing` references `Cat.Authorization.Abstractions` only to know who the user is. That is fine while the project stays tiny. If it grows, a neutral name may be better.
- **No user.** Scheduler runs and message handlers have no HTTP user. Does `ICatUser` return an unauthenticated user, or a named system user?
- **Implementation.** The demo implements it in the Api project from the claims. Does the module ship an ASP.NET Core implementation in its own project, so the abstractions stay free of ASP.NET, or only document it? Workers need a way to set the user in a scope.
- **Build order.** The abstractions project is small. Build it first, before the decorator, so the demo, `Cat.Auditing` and `Cat.UnitTesting` can use it early.
- **Policy model.** Roles only, permissions, claims based rules or ownership rules?
- **Declaring a rule.** An attribute on the request type, a registration per request, or a policy class per request?
- **Contracts.** If the rule is an attribute on the request, where does the attribute type live so `Contracts` stays light?
- **Two kinds of check.** A check before the handler ("may you save a book?") and a data level filter ("only your orders"). Does the module cover both, or only the first?
- **Responses.** Which `ICatResponse` for no login (401) and for no permission (403)? `Cat.Responses` has both `Unauthorized` (401) and `Forbidden` (403), and `Cat.Minimal.Api` maps them. Do we need anything more?
- **ASP.NET Core.** The framework has its own authorization with `RequireAuthorization`. Do we complement it, replace it, or wrap it?
- **No user.** Background work (scheduler, messages) has no person. What does it get?
- **Claims mapping.** Keycloak puts roles in its own claim shape. Who maps them?
- **Tests.** A fake `ICatUser` for unit tests. That may belong to `Cat.UnitTesting`.

## Questions before building

1. Which members does `ICatUser` get? Roles or claims instead of `IsAdmin`, an authenticated flag, a string id?
2. Do we build `Cat.Authorization.Abstractions` first, ahead of the decorator, so the demo and `Cat.Auditing` can use `ICatUser` early?
3. What does `ICatUser` return when there is no user, such as in a scheduled job or a message handler?
4. Does the module ship an ASP.NET Core implementation of `ICatUser`, or only the abstraction?
5. Do you want roles, permissions or both?
6. How should a request declare what it needs: attribute, registration or policy class?
7. Do we cover only the check before the handler, or also the owner filter in queries?
8. Do the existing `Unauthorized` and `Forbidden` responses cover 401 and 403, or is something missing?
9. Do we depend on ASP.NET Core authorization, or stay free of it?
10. What are the rules for background work that has no user?
11. Is Keycloak the only identity provider we design for?
12. Do we build this before the demo gets Keycloak, or after, with the real claims?
13. Does the Catalog admin save become the first use case?
