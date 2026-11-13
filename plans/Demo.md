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

# Plans for `Demo` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![NOT STARTED](https://img.shields.io/badge/Status-NOT%20STARTED-blue)](#plans-for-demo)
<!-- region end: StatusBadge-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 6](#phase-6)
- [Phase 7](#phase-7)
- [Phase 8](#phase-8)
- [Phase 9](#phase-9)
- [Phase 10](#phase-10)
- [Phase 11](#phase-11)
- [Phase 12](#phase-12)
- [Phase 13](#phase-13)
<!-- region end: Phases-->

<!-- region start: Phase 6-->
## Phase 6

### Description
<!-- region start: PhaseDescription-->
#### Goal
Show `Cat.UnitTesting`: the unit tests of the demo.

#### What exists today
- `Cat.UnitTesting` does not exist yet. Its plan is [Cat.UnitTesting.md](Cat.UnitTesting.md).
- The unit tests of the demo have their own copies of the fake command and query processors.
- The test doubles of Orders have `FakeUser`, which is an `ICatUser` and the small demo interface `IUserEmail` in one.

#### Needs
The module plan [Cat.UnitTesting.md](Cat.UnitTesting.md), built first.

#### Done when
The demo uses the module, and the readme says where.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 6-->

<!-- region start: Phase 7-->
## Phase 7

### Description
<!-- region start: PhaseDescription-->
#### Goal
Show `Cat.Sagas`: a payment over messages.

#### What exists today
- `Cat.Sagas` does not exist yet. Its plan is [Cat.Sagas.md](Cat.Sagas.md).
- `Cat.Users` is built and the demo uses it. The business logic of Orders asks for `ICatUser`, and Catalog sets `LastUpdatedBy` from it. The demo readme says where.
- Orders has an event subscriber, `OrderAuditSubscriber`, that writes an audit record when an order event happens. It stays as the example of an event subscriber. `Cat.Auditing` was dropped. A developer who wants to see who changed a row adds a `LastUpdatedBy` column to the temporal table.
- Ownership of orders is a filter in the queries.
- The Catalog save endpoint requires the `admin` policy, and a test checks the 401 without a login and the 403 for a user who is not an admin. The check stays at the endpoint, see the [module readme of Cat.Users](../modules/Cat.Users/README.md).
- A cancelled order keeps its `Approved` payment, because there is no refund step yet.

#### Needs
The module plan [Cat.Sagas.md](Cat.Sagas.md), built first.

#### Done when
The payment runs as a saga over messages, and the readme says where.

#### Decided
- **Payment over messages.** A saga style payment over messages comes with this phase, see [Cat.Sagas.md](Cat.Sagas.md). Until then the payment is an interface behind a generated client, and Orders keeps its state in the order status.
- **Messages carry a token.** A message sent for a user carries the token of that user, and the Scheduler sends with a client credentials token, as the [module readme of Cat.EventProcessor](../modules/Cat.EventProcessor/README.md) and the [module readme of Cat.Messaging](../modules/Cat.Messaging/README.md) describe. The demo host implements `ICatTokenProvider` and registers `AddCatEventProcessorAuthorization`, so a listener builds the `ICatUser` from the token. This comes once `Cat.Users` and the sending side exist, and the demo is the place that proves the rule. The costs:
  - The token sits in the queue, the dead letter queue and the outbox table, so it needs short lived tokens and a security review before production.
  - The Keycloak realm already has the client `cat-demo-orders` for the system token, so the realm needs no new client.

#### Known gaps for this showcase
- **Refund.** Add a refund when payment becomes a message flow, see [Cat.Sagas.md](Cat.Sagas.md):
  - A `Refunded` payment status, and an `IPaymentProvider` refund call.
  - `OrderCancelledEvent` gets a subscriber that refunds an approved payment.
  - Cancelling a confirmed order is then only done when the refund succeeded or is on its way.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 7-->

<!-- region start: Phase 8-->
## Phase 8

### Description
<!-- region start: PhaseDescription-->
#### Goal
Show `Cat.Dapper`: fast read-only order overview queries, next to EF Core for writes.

#### What exists today
- `Cat.Dapper` does not exist yet. Its plan is [Cat.Dapper.md](Cat.Dapper.md).
- Inventory reads through the EF Core scaffold only.

#### Needs
The module plan [Cat.Dapper.md](Cat.Dapper.md), built first.

#### Done when
The demo uses the module, and the readme says where.

#### Decided
- **Inventory data access.** The EF Core scaffold only for now. Dapper waits for the `Cat.Dapper` module.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 8-->

<!-- region start: Phase 9-->
## Phase 9

### Description
<!-- region start: PhaseDescription-->
#### Goal
Show `Cat.Caching`: cached catalog queries.

#### What exists today
- `Cat.Caching` does not exist yet. Its plan is [Cat.Caching.md](Cat.Caching.md).

#### Needs
The module plan [Cat.Caching.md](Cat.Caching.md), built first.

#### Done when
The demo uses the module, and the readme says where.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 9-->

<!-- region start: Phase 10-->
## Phase 10

### Description
<!-- region start: PhaseDescription-->
#### Goal
Languages. The demo works in more than one language: the client has a language selector, and the mails are translated. `Cat.Localizations` provides the texts.

#### Background
- The owner moved this out of phase 2, the Notifications service. The client has no language support, so everything is in English, and translated mails alone would not show.
- `Cat.Localizations` looks up localized texts by key. Its open points about the culture, localized data and error messages are in [Cat.Localizations.md](Cat.Localizations.md).

#### What exists today
- The client and the mails of Notifications are in English.
- Catalog does not use `Cat.Localizations`, so category names are plain text. Showing them in several languages waits until the module is stable.
- `ICatLocalizer` has no culture parameter, so a provider must find the culture itself.

#### Needs
The Notifications service, which is built. The module plan [Cat.Localizations.md](Cat.Localizations.md) answered and built.

#### Done when
A user picks a language in the client, and the order confirmed mail arrives in that language.

#### Decided
- **Scope.** The phase supports translated mails and a client where the user selects the language.
- **Languages.** Two: English as the default language and Dutch as the extra language. Two prove the mechanism, and a third adds work and nothing to learn.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 12-->
#### Question 12
How does the mail find the language of the customer? The `OrderConfirmed` message carries no language today.
- **The language in the message.** Orders puts the language of the request in `OrderConfirmed`. Cost: the message grows a field, and Orders must know the language.
- **A stored preference per user.** Notifications or another service keeps the language of each user. Cost: a place to store it. It also works for mails that no request triggers, such as the nightly jobs.
- **Always English for jobs, the request language for mails.** Cost: two rules.

Recommendation: the language in the message. The message is already the only link between the services, and it needs no new storage.
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
How does the client tell the services which language it wants?
- **The `Accept-Language` header,** sent by the client on every call and passed on by the gateway. Cost: the services must read it, and the gateway must not drop it.
- **A claim in the token.** Cost: a change needs a new login, and it ties the language to Keycloak.
- **A query parameter.** Cost: every call and every generated client method carries it.

Recommendation: the `Accept-Language` header. It is the standard way, and a service needs no extra contract.
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
Does the client remember the language choice, and where?
- **In the browser,** in local storage. Cost: the choice is lost on another device.
- **In the user profile of Keycloak.** Cost: more setup, and a call to save it.
- **Not at all.** The client starts in the language of the browser. Cost: a user picks the language again after each visit.

Recommendation: local storage, with the browser language as the first default. It is the smallest step.
<!-- region end: Question 14-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 10-->

<!-- region start: Phase 11-->
## Phase 11

### Description
<!-- region start: PhaseDescription-->
#### Goal
Show `Cat.Resilience` in the demo, for code that runs without Aspire.

#### Background
- `Aspire ServiceDefaults` already gives every service telemetry, health checks and the standard resilience handler. The demo uses Aspire, so it does not use `Cat.Resilience` today.
- `Cat.Resilience` is meant for projects without Aspire. The rule: a project with Aspire uses `ServiceDefaults`, and a project without Aspire uses the module. See [Cat.Resilience.md](Cat.Resilience.md).
- The demo case for `Cat.Resilience` is retry and circuit breaker on the payment call.

#### What exists today
- The payment service is a service of ours, behind the gateway, with `ServiceDefaults`. It can fail on purpose with the settings `PaymentFailures:Latency`, `PaymentFailures:ErrorPercentage` and `PaymentFailures:Outage`.
- Orders replaces the standard resilience handler of the clients for payment and Inventory with a shorter one in `UseFastFailResilience`: one retry after 500 ms, 5 seconds per try and 12 seconds in total. `FastFailResilienceTests` covers it.
- The `ServiceDefaults` pipeline is chosen per service address, so a failing service opens its own circuit.
- `Cat.Resilience` does not exist yet.

#### Needs
The module plan [Cat.Resilience.md](Cat.Resilience.md) answered first.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 2-->
#### Question 2
What if the demo treats payment as a service we do not control, like a real payment provider? This is the blocking question, because question 1 follows from it, and [Phase 12](#phase-12) uses the answer for tracing. The answers from the code:
- **`ServiceDefaults`.** It is a project in our own solution. A service we do not control does not use it, and does not have to. What matters is the caller. Orders calls `AddServiceDefaults`, so every `HttpClient` in Orders gets the resilience handler, service discovery and the HTTP client tracing, whoever answers. We are not obliged to implement anything in the outside service.
- **Tracing.** The call shows as a client span in the trace of Orders, with its duration and status. The outside service joins the trace only when it understands the W3C `traceparent` header. A real provider often does not, so the trace stops at the edge. That is realistic and worth showing.
- **Resilience and tracing with CAT modules.** Yes, this is a good showcase, because retry, timeout and circuit breaker matter most for a service we cannot fix. The payment service would then run without `ServiceDefaults`, and Orders would swap the `ServiceDefaults` handler for `Cat.Resilience` on that one client. `UseFastFailResilience` in Orders already removes the default handler, so the spot exists.
- **`Cat.Api.Client`.** Yes, with limits. `AddCatApiClient` takes any address as a plain string, and the generated client needs only the OpenAPI document of the provider. Three things change. The call would not go through our gateway, so the rule "services never call each other directly" needs an exception for outside services. The error body of an outside service is not `CatErrorResponse`, so the helper keeps the status code but loses the error codes and arguments. The token of the user must not be forwarded to a third party. A provider key or its own token is used instead.

The options:
- **A.** Keep payment as it is, a service of ours behind the gateway. Cost: the demo never shows `Cat.Resilience` or `Cat.Telemetry`, and the two phases shrink to documentation.
- **B.** Make payment outside: no `ServiceDefaults`, no gateway, its own error format, and Orders uses `Cat.Resilience` and `Cat.Telemetry` for that call. Cost: the first provider changes, and the error codes of payment are lost to the client.
- **C.** Do B later as a second payment provider next to the first, selected by configuration. Cost: a second provider to build and a switch to maintain.

Recommendation: C. The `IPaymentProvider` interface already hides the provider, so a second one costs little. The first provider stays as it is and keeps working. The outside variant becomes the showcase for `Cat.Resilience` and `Cat.Telemetry` once those modules exist.
<!-- region end: Question 2-->

<!-- region start: Question 1-->
#### Question 1
When does the demo use `Cat.Resilience`: never, or in a part that runs without Aspire? The demo readme says the demo does not use `Cat.Resilience`, because `ServiceDefaults` covers it. This follows from question 2: with option A the answer is never, with option C it is the outside payment provider. Answer question 2 and this one is closed. The demo readme then needs one sentence about it.
<!-- region end: Question 1-->

<!-- region start: Question 4-->
#### Question 4
Do all three failure switches of the payment service hold when the call goes through the gateway? The outage was tried live: with it on, the order ended after about 9 seconds. As far as we know, the latency and the error percentage were not tried through the gateway. The work is one order each, and a check that the gateway does not add its own timeout or retry that changes the result. Where do we write down the outcome?
- **In the payment chapter of the demo readme.** Cost: the readme gets a table of results that can go out of date.
- **As a test.** An integration test through the gateway. Cost: it needs the AppHost, so it is slow.
- **Not at all.** Check once and move on. Cost: nobody knows later what was tried.

Recommendation: check once by hand, and write the three results as one line each in the payment chapter of the demo readme. This needs the owner to run the AppHost, as Claude does not start it.
<!-- region end: Question 4-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 11-->

<!-- region start: Phase 12-->
## Phase 12

### Description
<!-- region start: PhaseDescription-->
#### Goal
Show `Cat.Telemetry` in the demo, for code that runs without Aspire.

#### Background
- `Aspire ServiceDefaults` already gives every service telemetry and health checks. The demo uses Aspire, so it does not use `Cat.Telemetry` today.
- `Cat.Telemetry` is meant for projects without Aspire. The rule: a project with Aspire uses `ServiceDefaults`, and a project without Aspire uses the module. See [Cat.Telemetry.md](Cat.Telemetry.md).
- The demo case for `Cat.Telemetry` is tracing one order across all services. It uses the answer to [Question 2](#question-2) of [Phase 11](#phase-11), which decides whether payment is an outside service.

#### What exists today
- Every service has telemetry from `ServiceDefaults`.
- `Cat.Telemetry` does not exist yet.

#### Needs
The module plan [Cat.Telemetry.md](Cat.Telemetry.md) answered first. [Question 2](#question-2) of [Phase 11](#phase-11) answered.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 3-->
#### Question 3
What do we do about the development certificate? The dashboard says "No trusted development certificate was found" when the machine has not run `dotnet dev-certs https --trust`. It is harmless now, because the AppHost, the dashboard and the services all run on HTTP (the AppHost launch settings set `ASPIRE_ALLOW_UNSECURED_TRANSPORT`). It matters once something uses HTTPS. The options:
- **Keep HTTP and add one note.** The run steps of the demo readme say the warning is harmless. Cost: the demo shows no HTTPS.
- **Tell the developer to trust the certificate** (`dotnet dev-certs https --trust`) and move the demo to HTTPS. Cost: one more setup step, and the unsecured transport setting goes away.
- **Do nothing.** Cost: a new developer sees the warning and wonders.

Recommendation: keep HTTP with one note in the run steps. The warning goes away by itself when something needs HTTPS, and then the step moves to the run steps.
<!-- region end: Question 3-->

<!-- region start: Question 5-->
#### Question 5
Should the health checks of the services cover their databases? Today every service answers `/health` (ready) and `/alive` (running) from one check, `self`, in `ServiceDefaults`, and that check is always healthy. The AppHost and the gateway watch `/health`, so a service with a database that is down still looks healthy. The options:
- **Add a database check per service,** on the ready endpoint only. Cost: a package per service (`AspNetCore.HealthChecks.SqlServer` or the EF Core check), and the services restart or stay out of the gateway while the database starts.
- **Add one check in `ServiceDefaults` that takes any `DbContext`.** Cost: `ServiceDefaults` must know about EF Core, and Inventory is built database first.
- **Keep it as it is.** Cost: a service shows healthy while its database is down.

Recommendation: a database check per service on `/health` only, and keep `/alive` as it is. It is a real pattern for developers to copy, and it is small. Do it in this phase only if the owner wants it, since it does not need the modules.
<!-- region end: Question 5-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 12-->

<!-- region start: Phase 13-->
## Phase 13

### Description
<!-- region start: PhaseDescription-->
#### Goal
The MySQL showcase. The Notifications service moves from SQL Server to MySQL, and shows that the modules work on another database.

#### Background
- A showcase on MySQL needs an EF Core provider for MySQL. The demo is on EF Core 11. The provider Pomelo has no release for EF Core 10 or 11 yet, and the Oracle provider is stable for EF Core 10 only and has an EF Core 11 preview. The facts were read on 2026-11-13 from a third-party article and from nuget.org, and nobody has tested them against this code.
- The Aspire client package for MySQL is built on Pomelo, so a stable Pomelo keeps the integration with Aspire.
- The module work is in two plans: [Cat.Db.Errors.md](Cat.Db.Errors.md) for the MySQL error numbers and [Cat.EFCore.md](Cat.EFCore.md) for a provider neutral `Cat.EFCore.Extensions`.
- Temporal tables and `Cat.Sql.Cdc` are SQL Server only. The MySQL service must not use them.

#### What exists today
- Every service runs on SQL Server, and the AppHost starts it with `AddSqlServer`.
- The outbox, the inbox and the scheduler claim store are plain EF Core code. They are not tested on MySQL.

#### Needs
- A stable Pomelo for EF Core 11, with an Aspire MySQL package that accepts it.
- The module plans [Cat.Db.Errors.md](Cat.Db.Errors.md) and [Cat.EFCore.md](Cat.EFCore.md), built first.
- The Notifications service, which is built.

#### Done when
Notifications runs on a MySQL container that the AppHost starts. The outbox, the inbox and the scheduler claim store work there, and the readme says where the demo uses MySQL.

#### Decided
- **Provider.** The demo waits for a stable Pomelo, so the Aspire integration stays. The Oracle preview is not used.
- **Which service.** Notifications moves to MySQL after it is built on SQL Server.
- **Entities.** Notifications uses the CAT base entities and `ConfigureCatEntity`, with no temporal tables and no raw SQL Server code. The move waits for the neutral `Cat.EFCore.Extensions` of [Cat.EFCore.md](Cat.EFCore.md), and that change must keep these calls source compatible.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 13-->
