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
- **No user.** Scheduler runs and message handlers have no HTTP user. Does `ICatUser` return an unauthenticated user, or a named system user? Decided elsewhere, for the messages: a message sent for a user carries the token of that user, and a message sent by a system without a user carries the token of that system, see [Cat.EventProcessor.md](Cat.EventProcessor.md). For the scheduler, the recommendation is a named system user, see [Cat.Scheduling.md](Cat.Scheduling.md). What is still open is what `ICatUser` returns when no token comes with the work at all.
- **Implementation.** The demo implements it in the Api project from the claims. Does the module ship an ASP.NET Core implementation in its own project, so the abstractions stay free of ASP.NET, or only document it? Workers need a way to set the user in a scope.
- **Build order.** The abstractions project is small. Build it first, before the decorator, so the demo, `Cat.Auditing` and `Cat.UnitTesting` can use it early.
- **Policy model.** Roles only, permissions, claims based rules or ownership rules?
- **Only some requests need authorization (the note of the owner).** The factory of `Cat.Decorators` wraps every handler of a service type, so the authorization decorator would surround every service request handler. But only some need a check. You do not see how to select them, and asked for a suggestion.

  What the code says, checked for this note:

  - **The decorator is open over the request.** `AddDecorator` only accepts open generic types, such as `ICatServiceRequestHandler<>`. A decorator cannot be switched on for one closed request type. It can only decide for itself, at run time, whether to do anything.
  - **There is a precedent.** The validation decorator of `Cat.ServiceRequests` wraps every handler too. It asks the validator processor for a validator of the request, runs it when there is one, and passes the request on when there is none. A flag, `validationRequired`, decides what a missing validator means. The same shape fits authorization: wrap everything, look up the rule of the request, check it when it exists.
  - **The cost of "wrap everything" is small.** One lookup per request that returns nothing for a request without a rule.
  - **Where the rule can live.** The `Contracts` project may not reference `Cat.Authorization.Abstractions`, as decided. So an attribute on the request type has no home. The rule has to sit in the core service or in the registration, next to the handlers and the tests.

  Options for selecting the requests:

  - **A. A rule class per request.** The module has an interface, for example `ICatAuthorizationRule<TRequest>`, with one method that gets the request and the `ICatUser` and returns an `ICatResponse`. The rule lives in the core, and the handlers and rules are found by scanning the assembly. The decorator asks the container for the rules of `TRequest`. No rule means no check. Cost: a class per protected request, even for a simple role check.
  - **B. A registration per request.** `options.Require<BookSaveRequest>(user => user.IsInRole("admin"))`, in one place in the core or the API. The decorator reads the registry. Short for simple rules, and all rules are visible in one list. Cost: the rule is away from the handler, and a long registry grows unwieldy.
  - **C. An attribute.** On the request type: not possible in `Contracts`. On the handler class: the decorator does not see the handler class when another decorator sits between, because it only gets the next handler in the chain. So the order of the decorators would matter. Not recommended.
  - **D. A change in `Cat.Decorators`.** The factory gets a condition per decorator, such as "only when the request type has a rule". Cost: a change in another module for a gain that the small lookup cost does not justify.
  - **Fail open or fail closed.** With A or B a request without a rule is open. A forgotten rule means an unprotected request. The validation decorator has the flag for this. Option: `authorizationRequired`. When it is on, a request with no rule, and not marked as public, fails with `Forbidden`. A marker for public requests then needs a home, and it cannot be in `Contracts` either. Alternatively the module logs the requests without a rule at startup, so a developer sees the list, and a unit test can check the list.
  - **Recommendation.** A and B together, one mechanism with two ways to fill it: the rule class is the real thing, and the registration with a lambda is a shortcut that creates one. The decorator wraps every handler and passes the request on when there is no rule. Leave out the attribute and the change in `Cat.Decorators`. Offer the fail closed flag as an option that is off by default, and log the requests without a rule at startup. The position of the decorator is set in [Cat.Decorators.md](Cat.Decorators.md), where the proposal puts authorization after tracing and logging and before validation.
- **Declaring a rule.** Answered by the point above, as a recommendation. Waiting for your answer on question 6.
- **Contracts.** Answered by the point above: no attribute in `Contracts`, so the rule lives in the core or in the registration.
- **Two kinds of check.** A check before the handler ("may you save a book?") and a data level filter ("only your orders"). Does the module cover both, or only the first?
- **Responses.** Which `ICatResponse` for no login (401) and for no permission (403)? `Cat.Responses` has both `Unauthorized` (401) and `Forbidden` (403), and `Cat.Minimal.Api` maps them. Do we need anything more?
- **ASP.NET Core.** The framework has its own authorization with `RequireAuthorization`. Do we complement it, replace it, or wrap it?
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
14. Do we offer a flag that fails a request without a rule, and how does a request say it is public?
