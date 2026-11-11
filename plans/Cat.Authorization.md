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

# Plans for `Cat.Authorization` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catauthorization)
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
A new module, `Cat.Authorization`, with a decorator that checks permissions before a service request runs. It also owns the shared user abstraction `ICatUser`, in `Cat.Authorization.Abstractions`.

#### The idea
Who may do what is a business rule, and it should live in the core service, where it can be tested without HTTP. A decorator on service requests can check the rule before the handler runs. A caller without permission gets a clear response, and the handler never starts.

#### Background
From the demo plan:
- Authentication is OpenID Connect with Keycloak. The gateway and the services validate the same JWT. Services authorize on the claims.
- Catalog reads are public. Orders needs a login. Admins edit the catalog through a role claim.
- The demo has an `ICurrentUser` in the `CoreService` project of Orders. It is the starting point of the shared `ICatUser` of this module. It exposes `UserId`, `Name`, `Email` and `IsAdmin`. The business logic never sees `HttpContext`.
- Until this module exists, ownership is a filter in the queries. The queries get the external id of the customer, or none for an admin. The orders of others come back as not found, so nothing leaks.
- The gateway rejects an unauthenticated save as well, and the service checks the token again.
- The demo plan sketches an admin check on the Catalog save as a decorator on `BookSaveRequest` over the current user, so the rule is testable in `CoreService`, plus a test that a user who is not an admin gets a 403.

From the module conventions:
- `Cat.ServiceRequests` runs handlers through decorators for logging, tracing and validation. Authorization would be another one.
- `Cat.Minimal.Api` documents the responses of an endpoint. Orders endpoints already declare `CatResponseType.Unauthorized`.
- The `Contracts` project stays small and free of service internals, so a permission attribute on a request needs a home that `Contracts` can reference.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- Keycloak runs in the demo, started by the AppHost. `AddDemoJwtAuthentication` in `ServiceDefaults` adds JWT bearer authentication when `Authentication:Authority` is set. The role claim is `roles`, and the `admin` policy requires the `admin` role.
- `ICurrentUser` lives in `Cat.Demo.OrderService.CoreService`, with two implementations in the Api project:
  - `TokenCurrentUser` reads the user from the claims of the token. It is used when authentication is on.
  - `DevelopmentCurrentUser` is a stub that reads the `X-Demo-User` header for `alice`, `bob` and `admin`. It is used without an authority.
- The Orders handlers use `ICurrentUser` and the owner filter in the queries. `FakeCurrentUser` exists in the Orders tests.
- The Catalog save endpoint requires the `admin` policy. That check sits in the endpoint, so it is not testable in `CoreService`. A decorator on `BookSaveRequest` does not exist yet.
- Catalog and Inventory have no `ICurrentUser`.
- `Cat.Responses` has `Unauthorized` (401) and `Forbidden` (403), and `Cat.Minimal.Api` maps them.
- The validation decorator of `Cat.ServiceRequests` is the precedent for a decorator that wraps every handler. It has a `validationRequired` flag that decides what a missing validator means.
- No `ICatUser`, no `Cat.Authorization.Abstractions` and no authorization decorator exist.

#### Decided
- **Place.** A decorator on service requests.
- **Identity.** The business logic only knows the user abstraction, never `HttpContext`.
- **User abstraction.** `ICatUser` lives in `Cat.Authorization.Abstractions`, renamed from `ICurrentUser` of the demo. This module owns it. `Cat.Auditing` and other modules reference that project. The core service may reference it, because it only references abstractions. `Contracts` does not.
- **Two layers.** The gateway and the service both validate the token.
- **Until the module exists.** The demo keeps its own `ICurrentUser` and an owner filter in the queries. When `Cat.Authorization.Abstractions` exists, the demo switches to `ICatUser`.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Which members does `ICatUser` get? This is the blocking question, because `Cat.Auditing`, `Cat.UnitTesting`, the demo and the event processor all build on it. The demo has `UserId`, `Name`, `Email` and `IsAdmin`. `IsAdmin` is a demo rule. The `sub` of Keycloak is a string, and the demo stores it in `Customer.ExternalId`. The options:
- **A small fixed set:** `UserId` (string), `Name`, `IsAuthenticated` and `IsInRole(string)`. Cost: no access to other claims, so a rule on a custom claim cannot be written.
- **The small set plus `Claims`** (a read only list of claims). Cost: the abstraction exposes the claim concept of .NET, and a rule can depend on a claim name, which makes it less portable.
- **The demo set as it is,** with `Email` and `IsAdmin`. Cost: `IsAdmin` is a demo rule, and `Email` is personal data that auditing does not want.

Recommendation: the small set plus `Claims`. `Email` and `IsAdmin` stay as extension methods or demo code (`IsInRole("admin")`). The id is a string, because identity providers use strings.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
`Cat.Auditing` references `Cat.Authorization.Abstractions` only to know who the user is. That is fine while the project stays tiny. If it grows, a neutral name may be better. The options:
- **Keep the name.** The toolbox rule says a shared abstraction lives in the `Abstractions` project of the module that owns it, and this module owns `ICatUser`. Cost: a reader may think a package called Authorization is heavy.
- **A neutral project, such as `Cat.Users.Abstractions`.** Cost: a new module just for one interface, and it breaks the rule above.

Recommendation: keep the name. It is already decided that this module owns `ICatUser`, and the abstractions project is separate from the implementation, so nobody pulls in the decorator.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
What does `ICatUser` return when there is no user, such as in a scheduled job or a message handler? What are the rules for background work that has no user? Decided elsewhere: a message sent for a user carries the token of that user, and a message sent by a system without a user carries the token of that system, see [Cat.EventProcessor.md](Cat.EventProcessor.md). For the scheduler, the recommendation is a named system user, see [Cat.Scheduling.md](Cat.Scheduling.md). What is open is what `ICatUser` returns when no token comes with the work at all. The options:
- **An unauthenticated user** (`IsAuthenticated` false, no id). Cost: every rule must handle it, and auditing gets an empty id.
- **A named system user,** such as the service name, with `IsAuthenticated` true and a `system` role. Cost: a rule can let a system through by accident, so the role must be explicit.
- **Throw.** Cost: background work cannot run without a user at all.

Recommendation: a named system user whenever the worker has set one (the scheduler and the event processor do), and an unauthenticated user otherwise. Both are always safe: the first has an id for auditing, and the second is denied by any rule that needs a login.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
The demo implements `ICurrentUser` in the Api project from the claims. Does the module ship an ASP.NET Core implementation of `ICatUser` in its own project, so the abstractions stay free of ASP.NET, or only document it? Workers need a way to set the user in a scope. The options:
- **A project `Cat.Authorization.AspNetCore`** with the claims implementation and its registration. It targets the latest .NET. Cost: one more project to keep.
- **Only document it,** with the demo as the example. Cost: every developer writes the same 30 lines.
- **A scope setter in the abstractions** (`ICatUserAccessor` with a setter) for workers, and the ASP.NET Core project for the web. Cost: a mutable member in the abstractions.

Recommendation: the ASP.NET Core project, plus a small accessor that a worker uses to set the user in its scope. Developers need both, and the demo's `TokenCurrentUser` is the starting point.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
The abstractions project is small. Do we build it first, before the decorator, so the demo, `Cat.Auditing` and `Cat.UnitTesting` can use it early? The options:
- **Yes, first.** `Cat.Authorization.Abstractions` with `ICatUser` alone, and the demo switches to it. Cost: the module is half built for a while, which is fine for a toolbox.
- **Together with the decorator.** Cost: three other plans wait for it.

Recommendation: yes, first. It depends on question 1 only, and it unblocks three plans.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
What is the policy model? The options:
- **Roles only.** Simple, and enough for the demo (admin and customer). Cost: no fine grained permissions.
- **Permissions** (such as `catalog.edit`) that roles map to. Cost: a mapping to maintain, and the identity provider must carry it.
- **Claims based rules.** A rule can read any claim. Cost: the rules depend on the identity provider.
- **Ownership rules** (a user may only touch their own data). Cost: needs the data, which is question 9.

Recommendation: the rule class of question 7 can check anything, so the module needs no policy model of its own. Offer a role check as the shortcut, and leave permissions and claims to the rule class. Ownership belongs to question 9.
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
How does a request say what it needs? The owner noted that only some requests need an authorization check. The factory of `Cat.Decorators` wraps every handler of a service type, so the authorization decorator would surround every service request handler. The owner could not see how to select the requests, and asked for a suggestion.

What the code says:
- **The decorator is open over the request.** `AddDecorator` only accepts open generic types, such as `ICatServiceRequestHandler<>`. A decorator cannot be switched on for one closed request type. It can only decide for itself, at run time, whether to do anything.
- **There is a precedent.** The validation decorator of `Cat.ServiceRequests` wraps every handler too. It asks the validator processor for a validator of the request, runs it when there is one, and passes the request on when there is none. A flag, `validationRequired`, decides what a missing validator means. The same shape fits authorization: wrap everything, look up the rule of the request, check it when it exists.
- **The cost of "wrap everything" is small.** One lookup per request that returns nothing for a request without a rule.
- **Where the rule can live.** The `Contracts` project may not reference `Cat.Authorization.Abstractions`, as decided. So an attribute on the request type has no home. The rule has to sit in the core service or in the registration, next to the handlers and the tests.

Options for selecting the requests:
- **A. A rule class per request.** The module has an interface, for example `ICatAuthorizationRule<TRequest>`, with one method that gets the request and the `ICatUser` and returns an `ICatResponse`. The rule lives in the core, and the handlers and rules are found by scanning the assembly. The decorator asks the container for the rules of `TRequest`. No rule means no check. Cost: a class per protected request, even for a simple role check.
- **B. A registration per request.** `options.Require<BookSaveRequest>(user => user.IsInRole("admin"))`, in one place in the core or the API. The decorator reads the registry. Short for simple rules, and all rules are visible in one list. Cost: the rule is away from the handler, and a long registry grows unwieldy.
- **C. An attribute.** On the request type: not possible in `Contracts`. On the handler class: the decorator does not see the handler class when another decorator sits between, because it only gets the next handler in the chain. So the order of the decorators would matter. Not recommended.
- **D. A change in `Cat.Decorators`.** The factory gets a condition per decorator, such as "only when the request type has a rule". Cost: a change in another module for a gain that the small lookup cost does not justify.

Recommendation: A and B together, one mechanism with two ways to fill it. The rule class is the real thing, and the registration with a lambda is a shortcut that creates one. The decorator wraps every handler and passes the request on when there is no rule. Leave out the attribute and the change in `Cat.Decorators`.

The position of the decorator is set in [Cat.Decorators.md](Cat.Decorators.md), where the proposal puts authorization after tracing and logging and before validation.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
Does a request without a rule fail open or fail closed? With option A or B of question 7 a request without a rule is open, so a forgotten rule means an unprotected request. The validation decorator has a flag for this. The options:
- **Open, as it is.** Cost: a forgotten rule means an unprotected request.
- **An `authorizationRequired` flag.** When it is on, a request with no rule, and not marked as public, fails with `Forbidden`. A marker for public requests then needs a home, and it cannot be in `Contracts` either. Cost: a public list to maintain, for example in the registration.
- **A startup log of requests without a rule.** Cost: nobody may read the log.

Recommendation: offer the flag, off by default, and log the requests without a rule at startup. A developer sees the list, and a unit test can check it.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
There are two kinds of check: a check before the handler ("may you save a book?") and a data level filter ("only your orders"). Does the module cover both, or only the first? The options:
- **Only the first.** The decorator checks the request. Filters stay in the queries, as in Orders today. Cost: the owner filter is repeated per query.
- **Both.** The module also offers a filter helper, for example an extension on `IQueryable` that adds the owner condition. Cost: it needs EF Core, so it is a separate project, and it can hide a query rule.

Recommendation: only the first for now. A data filter depends on the data model, and the Orders filter works. A helper can follow when two services repeat the same filter.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Which `ICatResponse` do we use for no login (401) and for no permission (403)? `Cat.Responses` has both `Unauthorized` and `Forbidden`, and `Cat.Minimal.Api` maps them. The options:
- **Use them as they are.** `Unauthorized` when `IsAuthenticated` is false, and `Forbidden` when the rule says no. Cost: none.
- **Add error codes** under a module area such as `CAT-AUT-` (see [the error code convention](../modules/Cat.Responses/README.md#the-error-code-convention)). Cost: a short list of codes to document, and a clearer message for the client.

Recommendation: use them as they are, with the codes `CAT-AUT-1000` and `CAT-AUT-1001` so a client can match on them like on other errors. This follows the convention of the responses plan.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
The framework has its own authorization with `RequireAuthorization`. Do we complement it, replace it, or wrap it? Do we depend on ASP.NET Core authorization, or stay free of it? The options:
- **Complement.** The endpoint still requires a login (the policy), and the decorator checks the business rule. The core stays free of ASP.NET Core. Cost: two places to look, but they do different jobs.
- **Replace.** Only the decorator checks. Cost: the gateway and the endpoint lose the cheap early rejection.
- **Wrap.** The decorator calls `IAuthorizationService`. Cost: the core depends on ASP.NET Core, which the rules forbid.

Recommendation: complement. The two layers are already decided (the gateway and the service). The endpoint keeps "must be logged in", and the decorator holds the business rules.
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Keycloak puts roles in its own claim shape (the demo reads the `roles` claim). Who maps them to `ICatUser`? The options:
- **The ASP.NET Core project of question 4,** with a configurable role claim name. Cost: a setting.
- **The identity provider is made to emit a flat `roles` claim** (a Keycloak mapper in the realm). Cost: a setup step in the realm, and the demo already does it.
- **A mapper interface** that the developer implements. Cost: more code for the common case.

Recommendation: the setting with the claim name `roles` as the default. Document the Keycloak mapper in the demo readme.
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
Tests need a fake `ICatUser`. Does that belong to this module or to `Cat.UnitTesting`? The options:
- **`Cat.UnitTesting.Authorization`.** The list of doubles in [Cat.UnitTesting.md](Cat.UnitTesting.md) already has it. Cost: none.
- **In this module.** Cost: test code in a production package.

Recommendation: `Cat.UnitTesting.Authorization`. It is in the list of doubles, and it waits for this module's abstractions (question 5).
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
Is Keycloak the only identity provider we design for? The options:
- **Keycloak only.** Cost: a developer on another provider has no tested path.
- **Any OpenID Connect provider,** with Keycloak as the demo. Cost: nothing in code, since the module reads claims and does not talk to a provider, but the claim names must be settings.

Recommendation: any OpenID Connect provider. The module reads a token and makes no call to the provider, so this is free if the claim names (question 12) are settings.
<!-- region end: Question 14-->

<!-- region start: Question 15-->
#### Question 15
Do we build the module against the real Keycloak claims now? Keycloak and real claims are in the demo now (see "What exists today"), so the old question whether to wait for them is answered. What is left is the order of work. The options:
- **Now, abstractions first** (question 5), then the decorator, using Keycloak in the demo as the test bed. Cost: none.
- **Wait for the decorators plan** ([Cat.Decorators.md](Cat.Decorators.md)), since the order mechanism changes how the decorator is added. Cost: the decorator waits.

Recommendation: now, abstractions first. The decorator can use the current order of adding and take the new mechanism when it exists.
<!-- region end: Question 15-->

<!-- region start: Question 16-->
#### Question 16
Does the Catalog admin save become the first use case? The endpoint already requires the `admin` policy. The open part is the decorator on `BookSaveRequest` and a test that a user who is not an admin gets a 403 in `CoreService`. The options:
- **Yes.** It is small and testable, and it is in the demo plan as a known gap. Cost: Catalog needs an `ICatUser` too, since it has none today.
- **Start with the Orders ownership rules.** Cost: bigger, and they are data filters (question 9).

Recommendation: yes. It is the smallest case that shows the rule class, the decorator and the test without HTTP.
<!-- region end: Question 16-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->