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

# Plans for `Cat.Users` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![NOT STARTED](https://img.shields.io/badge/Status-NOT%20STARTED-blue)](#plans-for-catusers)
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
A new module, `Cat.Users`, that owns the shared user abstraction `ICatUser`, builds the user from the claims of a token and lets a worker set the user. It also helps the entrances of a service check permissions before any work starts, by reusing the ASP.NET Core policy system.

#### The idea
Authorization happens at the entrance of the service: on the endpoint for an HTTP call, and on the receiving side for a message. It does not happen on the service request. A caller without permission gets a clear response, and no handler starts.

#### Background
From the demo plan:
- Authentication is OpenID Connect with Keycloak. The gateway and the services validate the same JWT. Services authorize on the claims.
- Catalog reads are public. Orders needs a login. Admins edit the catalog through a role claim.
- The demo has an `ICurrentUser` in the `CoreService` project of Orders. It is the starting point of the shared `ICatUser` of this module. It exposes `UserId`, `Name`, `Email` and `IsAdmin`. The business logic never sees `HttpContext`.
- Until this module exists, ownership is a filter in the queries. The queries get the external id of the customer, or none for an admin. The orders of others come back as not found, so nothing leaks.
- The gateway rejects an unauthenticated save as well, and the service checks the token again.
- The demo plan has the admin check on the Catalog save at the endpoint, plus a test that a user who is not an admin gets a 403.

From the module conventions:
- `Cat.ServiceRequests` runs handlers through decorators for logging, tracing and validation. Authorization is not one of them, see "Decided".
- `Cat.Minimal.Api` documents the responses of an endpoint. Orders endpoints already declare `CatResponseType.Unauthorized`.
- The `Contracts` project stays small and free of service internals, so a permission attribute on a request needs a home that `Contracts` can reference.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- Keycloak runs in the demo, started by the AppHost. `AddDemoJwtAuthentication` in `ServiceDefaults` adds JWT bearer authentication when `Authentication:Authority` is set. The role claim is `roles`, and the `admin` policy requires the `admin` role.
- `ICurrentUser` lives in `Cat.Demo.OrderService.CoreService`, with two implementations in the Api project:
  - `TokenCurrentUser` reads the user from the claims of the token. It is used when authentication is on.
  - `DevelopmentCurrentUser` is a stub that reads the `X-Demo-User` header for `alice`, `bob` and `admin`. It is used without an authority.
- The Orders handlers use `ICurrentUser` and the owner filter in the queries. `FakeCurrentUser` exists in the Orders tests.
- The Catalog save endpoint requires the `admin` policy. That check sits in the endpoint, which is the entrance, so it stays there. A test for a user who is not an admin does not exist yet.
- Catalog and Inventory have no `ICurrentUser`.
- `Cat.Responses` has `Unauthorized` (401) and `Forbidden` (403), and `Cat.Minimal.Api` maps them.
- The validation decorator of `Cat.ServiceRequests` is the precedent for a decorator that wraps every handler. It has a `validationRequired` flag that decides what a missing validator means.
- No `ICatUser`, no user project and no authorization decorator exist.

#### Decided
- **Identity.** The business logic only knows the user abstraction, never `HttpContext`.
- **User abstraction.** `ICatUser` is renamed from `ICurrentUser` of the demo. It lives in `Cat.Users.Abstractions`, the abstractions project of the new module `Cat.Users`, and not in an authorization project. Other modules reference that project only to know who the user is. The core service may reference it, because it only references abstractions. `Contracts` does not. The owner chose a neutral name because the module holds the user and no authorization logic. The earlier idea of a module `Cat.Authorization` is dropped, because almost nothing of it is left: the policies are the ones of ASP.NET Core, and the policy check for messages lives in the event processor module.
- **Two layers.** The gateway and the service both validate the token.
- **Until the module exists.** The demo keeps its own `ICurrentUser` and an owner filter in the queries. When the user project exists, the demo switches to `ICatUser`.
- **Members of `ICatUser`.** A small fixed set: `UserId` (a string, because identity providers use strings), `Name`, `IsAuthenticated` and `IsInRole(string)`. It has no `Claims`, because the policy handlers of ASP.NET Core read any claim from the `ClaimsPrincipal`, and `Claims` can be added later without breaking anyone. `Email` and `IsAdmin` of the demo are not part of it. The demo keeps `IsAdmin` as an extension method over `IsInRole("admin")`, and keeps `Email` in a small demo interface that the Api project fills from the token.
- **No user.** Background work runs as a named system user when a worker has set one, such as the service name, with `IsAuthenticated` true and an explicit `system` role. The scheduler and the event processor set it. When no worker has set a user and no token came with the work, `ICatUser` is an unauthenticated user (`IsAuthenticated` false, no id), so a rule that needs a login denies it. Running as the system is a choice of the worker and never a default.
- **Implementation and workers.** The claims implementation of `ICatUser` and its registration live in a project of their own that targets the latest .NET, because it uses ASP.NET Core. The demo's `TokenCurrentUser` is the starting point. The user abstraction also holds a small accessor, `ICatUserAccessor` with a setter, so a worker can set the user in its scope.
- **Order of work.** The user project is not built first. It is built together with the rest: the claims implementation and the policy check for messages. The demo keeps its own `ICurrentUser` until then, and the other plans that need `ICatUser` wait for the whole piece.
- **Policy model.** The module has no policy model of its own. It is the one of ASP.NET Core, with roles, claims, custom requirements and resource checks. A message type names a policy, and it can also state a simple rule inline, such as a required role, so a developer does not have to define a policy by name first. The owner chose to build the inline shortcut. The endpoint needs none of this. The shortcut is a callback that takes the ASP.NET Core policy builder, and it is built in the optional authorization project of the event processor module, see the [module readme of Cat.EventProcessor](../modules/Cat.EventProcessor/README.md).
- **Checks on data.** The module does nothing for them. Filters stay in the queries, as in Orders today. A rule on a loaded resource goes through a small interface that the host implements, see "Core stays free of ASP.NET Core". A filter helper can follow when two services repeat the same filter.
- **Responses.** The framework answers as it is. An endpoint gets the standard 401 or 403 of ASP.NET Core, and no `ICatResponse` is involved. A message that fails the check is dead lettered with the reason `Unauthorized` or `Forbidden`, following the names of the failure table. A handler that checks a resource still returns `CatResponse.Forbidden` or `NotFound`. There is no `CAT-AUT` error area for now, and it can be added later without a break.
- **Core stays free of ASP.NET Core.** Handlers know only `ICatUser`, and the core service never references the ASP.NET Core authorization package. The entrances use the framework: the endpoint with its policies, and the receiver through the optional project. A resource check in a handler goes through a small interface that the host implements with `IAuthorizationService`. It is designed when the first resource check needs it.
- **Roles.** The claims project has a setting for the name of the claim that holds the roles, with `roles` as the default. The optional project `Cat.Users.JwtBearer` sets the role claim type of the JWT bearer validation to that value, so `IsInRole` and `RequireRole` read the same claim. It is a separate project, so `Cat.Users` does not pull in the JwtBearer package. The owner chose this. On the message side the receiver builds the identity with the same value and needs no JWT package. A developer on another provider changes the one value. The demo makes Keycloak send a flat `roles` claim with a mapper in the realm, and the demo readme documents it.
- **Fake user for tests.** The fake `ICatUser` lives in `Cat.UnitTesting`, not in a production package, as the list of doubles in [Cat.UnitTesting.md](Cat.UnitTesting.md) says. It waits for the user project.
- **Identity providers.** The module is designed for any OpenID Connect provider. It reads a token and makes no call to the provider, and the claim names are settings. Keycloak is the provider of the demo and the only one that is tested. The docs say so.
- **First use case.** The Catalog save of a book price by an admin. The 403 test proves the entrance: a user who is not an admin gets a 403 on the save, in an API test through the test host. The `LastUpdatedBy` column of `BookPrice` proves that the user reaches the handler: the entrance builds `ICatUser` from the claims and the command handler writes the user id. Catalog gets an `ICatUser` for this, see [Demo.md](Demo.md).
- **At the entrance.** Authorization is done at the entrance of the service, not on the service request and not in a decorator. The entrances are the endpoint and the receiving of a message. The owner decided this after the question whether a decorator is the way to apply it.
- **HTTP.** For an endpoint, the ASP.NET Core authorization system is used as it is: policies, `RequireAuthorization`, `IAuthorizationHandler` and `IAuthorizationService` for rules on data. The demo already works this way. `Cat.Minimal.Api` builds nothing for it.
- **Messages.** The event processor reuses the same ASP.NET Core policy system. The receiver builds a `ClaimsPrincipal` from the token of the message and asks `IAuthorizationService` for a policy that is set per message type, like the inbox setting. The owner chose to reuse it, so one policy system serves both entrances.
- **Where the pieces live.**
  - The user project holds `ICatUser` and the way to get the current user. The event processor and the minimal API module can reference it. It has no ASP.NET Core dependency.
  - `Cat.EventProcessor.Abstractions` gets a policy name on `CatReceiveOptions`, set in code and overridable from the configuration, and a small contract that the receiver calls before the handler runs.
  - An optional project of the event processor module, such as `Cat.EventProcessor.Authorization` next to `Cat.EventProcessor.Inbox.EFCore`, implements that contract with `IAuthorizationService`, so a developer who does not use it pulls in nothing. A missing implementation with a policy set fails at startup, as for the inbox. `Cat.Users` has no dependency on the event processor.
- **User in the handler.** A handler gets the current user as `ICatUser` from its scope, for example to fill a `LastUpdatedBy` column. The Catalog save does this in the demo. The entrance sets the user, from the claims for an endpoint and from the token for a message. A job without a user gets the named system user, see question 3. The receiver does not retry it, because retrying gives the same answer. It dead letters the message.
- **Failed check on a message.** The receiver does not retry it, because retrying gives the same answer. It dead letters the message.
- **Package of the message project.** The optional project of the event processor module references `Microsoft.AspNetCore.Authorization`, which targets `net10.0`, `netstandard2.0` and `net462` and does not pull in the ASP.NET Core shared framework. The authorization alone would let the project target `netstandard2.0`, but the project also validates the token with the JWT bearer package and uses `Cat.Users`, which target `net10.0`. So the built project targets `net10.0`. `IAuthorizationService.AuthorizeAsync` takes a `ClaimsPrincipal`, so a message can be checked without an `HttpContext`, and `AddAuthorizationCore` registers the services without the web host. A spike on 2026-11-12 confirmed this. A `netstandard2.0` library with the package version 10.0.14 builds, and the package brings only `Microsoft.Extensions.*` and `System.*` packages. `AuthorizeAsync` on a named role policy works without an `HttpContext`, and so does an inline rule that takes an `AuthorizationPolicyBuilder` with role, claim and authenticated-user rules. A principal whose identity does not name the claim as its role claim type is denied, so the receiver builds the identity with the role claim type of `CatUsersOptions`. A policy name that does not exist throws `InvalidOperationException`, which the startup check can catch. `AddAuthorizationCore` does not register logging, so the host must have it, as every host does, and tests need `AddLogging`. The spike did not test the JWT validation. A custom handler that needs the `HttpContext` does not work for a message.
- **Entrances without a rule.** For endpoints the plain ASP.NET Core way is used: a fallback policy that requires a login, with `AllowAnonymous` for an endpoint that is open on purpose. For messages the listener logs the message types without a policy at startup, and a setting makes the receiver deny them. The setting is off by default, so existing services keep working.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->