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

<!-- region start: FirstStableVersion-->
**First stable version:** reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 9](#phase-9)
- [Phase 10](#phase-10)
- [Phase 11](#phase-11)
- [Phase 12](#phase-12)
- [Phase 13](#phase-13)
- [Phase 16](#phase-16)
<!-- region end: Phases-->

<!-- region start: Phase 9-->
## Phase 9

### Description
<!-- region start: PhaseDescription-->
#### Goal
Show `Cat.Caching`: cached catalog queries.

#### What exists today
- `Cat.Caching` does not exist yet. Its plan is [Cat.Caching.md](Cat.Caching.md).

#### Needs
Phase 1 of the module plan [Cat.Caching.md](Cat.Caching.md#phase-1), built first.

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
Phase 1 of the module plan [Cat.Localizations.md](Cat.Localizations.md#phase-1), answered and built.

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
Phase 1 of the module plan [Cat.Resilience.md](Cat.Resilience.md#phase-1), answered first.
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

<!-- region start: Question 15-->
#### Question 15
Orders takes the payment over messages now and no longer calls Payment over HTTP, see the demo readme. The Payment service keeps its HTTP endpoint and its generated client. This phase and its questions 1, 2 and 4 describe a retry and a circuit breaker on the payment call from Orders, and the failure settings act on the HTTP path. What does the showcase of `Cat.Resilience` call once Orders no longer calls Payment over HTTP?
- **Another call that Orders still makes over HTTP.** For example Catalog prices or Inventory reservations. Cost: the failure settings of the Payment service no longer serve the showcase, so Catalog or Inventory needs its own switches.
- **A second, outside payment provider next to the saga.** It is the variant of question 2, option C, called over HTTP from a separate step or from a small service. Cost: a second provider to build, and it sits outside the saga path.
- **The Payment endpoint called directly, for example by a test or a tool.** Cost: it shows the module on a call that the order flow never makes.

Recommendation: the first option. Orders still calls Inventory and Catalog over HTTP, and Inventory already sits in the order flow, so the showcase stays on the real path. Answer it together with question 2.
<!-- region end: Question 15-->
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
- The demo stays on HTTP. The owner tested it live: `dotnet dev-certs https --trust` is optional and clears the dashboard notification "No trusted development certificate was found" on HTTP. The demo readme describes it, with the command that undoes it.

#### Needs
Phase 1 of the module plan [Cat.Telemetry.md](Cat.Telemetry.md#phase-1), answered first. [Question 2](#question-2) of [Phase 11](#phase-11) answered.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
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
The PostgreSQL showcase. The Notifications service moves from SQL Server to PostgreSQL, and shows that the modules work on another database.

#### Background
- A showcase on PostgreSQL needs the Npgsql EF Core provider. The demo is on EF Core 11. The provider has no stable release for EF Core 11 yet. The latest is `11.0.0-rc.3`, pinned to a release candidate of EF Core 11. The facts were read on 2026-11-19 from nuget.org through a web search, and nobody has tested them against this code. Check the NuGet page before pinning a version.
- The Aspire client package for PostgreSQL, `Aspire.Npgsql.EntityFrameworkCore.PostgreSQL`, depends on Npgsql 10.0.3 or higher. Nobody has tested it with Npgsql 11.
- The demo stays on `net11.0` and EF Core 11, while the modules support .NET 10 and EF Core 10 as well, see the target framework rule in `CLAUDE.md`. The PostgreSQL project of the modules can be proved on EF Core 10 before the demo moves, see question 2 of [Cat.EFCore.md](Cat.EFCore.md#phase-2).
- `Cat.Db.Errors` has checks for SQL Server and MySQL, see the [module readme of Cat.Db.Errors](../modules/Cat.Db.Errors/README.md). The PostgreSQL checks are built in `Cat.Db.Errors.PostgreSQL`, see the same readme. Notifications needs them when a handler maps a database error, to check when building.
- The module work that is left is in [Cat.EFCore.md](Cat.EFCore.md), for a provider neutral `Cat.EFCore.Extensions`.
- Temporal tables and `Cat.Sql.Cdc` are SQL Server only. The PostgreSQL service must not use them.

#### What exists today
- Every service runs on SQL Server, and the AppHost starts it with `AddSqlServer`.
- The outbox, the inbox and the scheduler claim store are plain EF Core code. They are not tested on PostgreSQL.

#### Needs
- A stable Npgsql EF Core provider for EF Core 11, with an Aspire PostgreSQL package that accepts it.
- Phase 2 of the module plan [Cat.EFCore.md](Cat.EFCore.md#phase-2), built first.

#### Done when
Notifications runs on a PostgreSQL container that the AppHost starts. The outbox, the inbox and the scheduler claim store work there, and the readme says where the demo uses PostgreSQL.

#### Decided
- **Database.** PostgreSQL is the second database of the showcase, and not MySQL (owner, 2026-11-20).
- **Provider.** The demo waits for a stable Npgsql provider for EF Core 11, so the Aspire integration stays. A release candidate is not used (owner, 2026-11-20).
- **Which service.** Notifications moves to PostgreSQL after it is built on SQL Server.
- **Entities.** Notifications uses the CAT base entities and `ConfigureCatEntity`, with no temporal tables and no raw SQL Server code. The move waits for the neutral `Cat.EFCore.Extensions` of [Cat.EFCore.md](Cat.EFCore.md), and that change must keep these calls source compatible.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 13-->

<!-- region start: Phase 16-->
## Phase 16

### Description
<!-- region start: PhaseDescription-->
#### Goal
Refund a payment that answers after the payment timeout, so the money does not stay taken when the order is already cancelled.

#### What exists today
- The place order saga waits for `PaymentProcessed` for `Orders:PaymentTimeoutSeconds` (2 minutes by default). When the timeout comes first, the workflow cancels the order with the reason `PaymentUnavailable` and ends. Nothing is saved for the payment.
- Payment keeps a `TakePayment` request in its queue while it is down or busy. It can take the payment long after the order was cancelled, and then it publishes `PaymentProcessed`.
- The saga ignores an answer for an instance that is not waiting any more. Orders never saves that payment, so there is no `Payment` row to refund.
- The refund of a cancelled order works for a payment that Orders saved with the status `Approved`. `PaymentRefundSubscriber` finds no such payment after a `PaymentUnavailable` cancel, so it sends nothing.
- Payment remembers its payments and its refunds in memory. A `RefundPayment` for an order number it has no payment for answers `Refunded` false, and remembers nothing.
- The demo readme lists this under the Orders cons.

#### Done when
A payment that answers after the order was cancelled for `PaymentUnavailable` is refunded, and the demo readme says where.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 18-->
#### Question 18
How does the money of a late payment come back? The options:
- **Orders reacts to the late answer.** Orders receives the late `PaymentProcessed`, saves the payment and sends `RefundPayment`. Cost: the saga already receives this message type, so it needs checking whether a message type can have a second receiver next to the saga answer. If not, the late answer needs another route, such as a second message type.
- **Orders asks for the refund when the timeout cancels the order.** The `PaymentUnavailable` cancel sends `RefundPayment`, and Payment keeps a note for an order number it has not charged, so it declines a later `TakePayment` for that number. Cost: Payment needs a small rule that it does not have today, and the demo has to say that a refund can come before the payment. The two queues have no fixed order, so without the note a refund that arrives first finds nothing to give back.

Recommendation: ask for the refund at the timeout. It is the smaller change, it keeps the saga untouched, and the money is never taken when the note arrives first. A payment that was taken just before the note arrives is refunded by the same `RefundPayment`.
<!-- region end: Question 18-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 16-->
