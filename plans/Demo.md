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
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-demo)
<!-- region end: StatusBadge-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
- [Phase 2](#phase-2)
- [Phase 3](#phase-3)
- [Phase 4](#phase-4)
- [Phase 5](#phase-5)
- [Phase 6](#phase-6)
<!-- region end: Phases-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
Notifications and scheduling. The Notifications service and `Cat.Scheduling`. The nightly clean up of the order counters, the cancel of unpaid orders and a nightly low stock report.

#### Background
- Notifications sends the order confirmed and order shipped messages. It also runs the scheduled jobs. It consumes `OrderConfirmed`.
- The scheduled jobs of the demo:
  - Clean up the daily order counters every night, shortly after midnight UTC.
  - Cancel unpaid orders after 24 hours.
  - Cancel orders that stay Pending too long, the sweep. See Decided and [Question 15](#question-15).
  - A nightly low stock report.
- The mails are in English. Languages come in [Phase 6](#phase-6).
- Work without a user, such as the Scheduler, uses a client credentials token.
- The Scheduler is the worker of a service, as the readme describes it. In debug mode the API has a development endpoint group with a sub group per worker.

#### What exists today
- The Notifications service does not exist. The demo readme lists it as planned, and the box in the drawing is hatched.
- The `CleanUpOrderCounters` service request exists in Orders, with its handler and tests. The development endpoint `POST /development/scheduler/clean-up-order-counters` triggers it, in the Development environment only. Orders has no `Scheduler` project yet.
- The Keycloak realm has the clients `cat-demo-web` and `cat-demo-cli` only. It has no client for a client credentials token.
- `Cat.Scheduling` does not exist yet. Its plan is [Cat.Scheduling.md](Cat.Scheduling.md). The plan recommends that a one-off timeout, such as the cancel after 24 hours, goes through a scheduled message of the bus and not through the Scheduler.

#### Needs
The module plan [Cat.Scheduling.md](Cat.Scheduling.md) built.

#### Done when
An order confirmed mail is sent. The nightly jobs run from the Scheduler, and the development endpoint can go.

#### Decided
- **Counter cleanup.** The Scheduler runs the `CleanUpOrderCounters` service request every night. Until the Scheduler exists, the development endpoint triggers it.
- **Notifications data.** Notifications has a database, built code first with EF Core migrations, like Orders. A table of sent mails, keyed by order and kind, makes a repeated message safe and shows idempotent handling. The scheduler can use the same database for its claim table and run history, see [Cat.Scheduling.md](Cat.Scheduling.md).
- **Sweep of stuck orders.** The place order handler of Orders cancels the order when the caller gives up after the order is created, for example on a gateway timeout. That does not cover a crash of the service in the middle of the workflow. A scheduled job cancels the orders that stay Pending too long and covers the rest. A cancel through the sweep publishes the same cancelled event, so the stock is released too. How long an order may stay Pending, and whether this is the job that cancels unpaid orders, is [Question 15](#question-15).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 15-->
#### Question 15
How long may an order stay Pending before the sweep cancels it, and is the sweep the same job as the cancel of unpaid orders after 24 hours? The place order workflow takes the payment in the same request, so a Pending order is either in progress for a few seconds or stuck. The options:
- **One job with a short limit,** for example 15 minutes, that cancels every Pending order older than the limit. The "unpaid after 24 hours" job goes, because a Pending order is the only unpaid state the workflow has. Cost: a limit that is too short could cancel an order that is slow but alive, and the demo loses the 24 hour example of a one-off timeout.
- **Two jobs.** The sweep with a short limit, and the 24 hour cancel kept as the showcase of a scheduled bus message, as [Cat.Scheduling.md](Cat.Scheduling.md) recommends for a one-off timeout. Cost: two ways to cancel a Pending order, and the 24 hour job never finds an order that the sweep did not catch.

Recommendation: one job with a limit that is longer than the slowest normal order, such as 15 minutes. A Pending order older than that is stuck, and the 24 hour wait protects nobody. If the owner wants a showcase of the scheduled message, give it a real one-off timeout, such as a reminder mail for an unpaid order.
<!-- region end: Question 15-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->

<!-- region start: Phase 3-->
## Phase 3

### Description
<!-- region start: PhaseDescription-->
#### Goal
The other modules. One showcase at a time, each with its own plan.

#### Background
The showcases:
- `Cat.Caching`: cached catalog queries.
- `Cat.Dapper`: fast read-only order overview queries, next to EF Core for writes.
- `Cat.EFCore` transactions: saving an order and its lines in one go.
- `Cat.Sagas`: a payment over messages.
- `Cat.UnitTesting`: the unit tests of the demo.

Every module is designed from what the demo shows, and the module plan of each is built first.

#### What exists today
- None of these modules exists yet. Each has a plan with the same name in this folder, such as [Cat.Caching.md](Cat.Caching.md).
- `Cat.Users` is built and the demo uses it. The business logic of Orders asks for `ICatUser`, and Catalog sets `LastUpdatedBy` from it. The demo readme says where.
- Orders has an event subscriber, `OrderAuditSubscriber`, that writes an audit record when an order event happens. It stays as the example of an event subscriber. `Cat.Auditing` was dropped. A developer who wants to see who changed a row adds a `LastUpdatedBy` column to the temporal table.
- Catalog keeps every old price in a temporal table, which answers "what was the price then". `BookPrice` has a `LastUpdatedBy` column, so the history also says who set the price.
- Ownership of orders is a filter in the queries. The test doubles of Orders have `FakeUser`, which is an `ICatUser` and the small demo interface `IUserEmail` in one.
- The Catalog save endpoint requires the `admin` policy, and a test checks the 401 without a login and the 403 for a user who is not an admin. The check stays at the endpoint, see the [module readme of Cat.Users](../modules/Cat.Users/README.md).
- Inventory reads through the EF Core scaffold only.
- A cancelled order keeps its `Approved` payment, because there is no refund step yet.
- The unit tests of the demo have their own copies of the fake command and query processors.

#### Needs
The module plan of each showcase, built first.

#### Done when
Per module: the demo uses it and the readme says where.

#### Decided
- **System user for jobs.** A price changed by a job gets the named system user, `CatUser.System`, see the [module readme of Cat.Users](../modules/Cat.Users/README.md). The seed of Catalog already does this.
- **Inventory data access.** The EF Core scaffold only for now. Dapper waits for the `Cat.Dapper` module.
- **Payment over messages.** A saga style payment over messages comes later, see [Cat.Sagas.md](Cat.Sagas.md). Until then the payment is an interface behind a generated client, and Orders keeps its state in the order status.

#### Known gaps for these showcases
- **Refund.** Add a refund when payment becomes a message flow, see [Cat.Sagas.md](Cat.Sagas.md):
  - A `Refunded` payment status, and an `IPaymentProvider` refund call.
  - `OrderCancelledEvent` gets a subscriber that refunds an approved payment.
  - Cancelling a confirmed order is then only done when the refund succeeded or is on its way.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 10-->
#### Question 10
Do messages carry a token in the demo when `Cat.Users` exists? The [module readme of Cat.EventProcessor](../modules/Cat.EventProcessor/README.md) and the [module readme of Cat.Messaging](../modules/Cat.Messaging/README.md) say that a message sent for a user carries the token of that user, and a message with a scheduled time carries the token of the sending system. The listener then builds the `ICatUser` from the token. The modules do this now, when the host implements `ICatTokenProvider` and registers `AddCatEventProcessorAuthorization`. The demo does neither yet. The options:
- **Carry the token of the user,** and a client credentials token for the Scheduler, as decided. Cost: the token sits in the queue, the dead letter queue and the outbox table, so it needs short lived tokens, and a security review before production. The demo needs a client in the Keycloak realm for the system token.
- **No token in the demo messages.** Cost: the demo does not show the identity rule. A handler that needs a user cannot be shown.

Recommendation: carry the token, once `Cat.Users` and the sending side exist. It is the decided design, and the demo is the place that proves it. Until then, the handlers of the earlier phases need no user.

##### Answer 10
As recommended
<!-- region end: Question 10-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 3-->

<!-- region start: Phase 4-->
## Phase 4

### Description
<!-- region start: PhaseDescription-->
#### Goal
A sign-in page for the React client, so a person lands on a page of the demo before the login, instead of going straight to the Keycloak form.

#### What exists today
- The top bar of the React client has a Log in button that sends the browser to the Keycloak login. The basket sends a person who is not logged in to the login first and returns to the basket.
- The login uses authorization code with PKCE against the client `cat-demo-web`, and the person returns to the page they came from.
- The demo users `alice`, `bob` and `admin` are in the demo readme with their passwords. The client has no sign-in page.

#### Needs
The React client, which is built. The answer to the open question on what the page holds.

#### Done when
A visitor who is not signed in sees the sign-in page. The button starts the login against `cat-demo-web`, and the return goes back to the page the person came from.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
What should the sign-in page be?
- **A.** A page in the React app with a sign-in button that starts the Keycloak login. Cheap, and the app keeps the look.
- **B.** A themed Keycloak login form, so the form itself looks like the demo. More work in the realm.
- **C.** A form in the React app that takes the password itself. Not recommended, because the password would pass through the app and the authorization code flow with PKCE is lost.

Recommendation: A first, B later if the form should match.

##### Answer 1
As recommended
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Does the sign-in page show the demo users `alice`, `bob` and `admin`, and where do they come from? The passwords are in the demo readme today. It only matters for option A or B of question 1. The options:
- **Show them as buttons that fill the login hint.** A visitor picks a user and the Keycloak form opens with the name filled in. The list comes from the readme values, written into a constant of the app. Cost: the list and the realm can differ.
- **Show a text only.** The page says where to find the users, with a link to the demo readme. Cost: one more click for a visitor.
- **Show nothing.** Cost: a visitor must read the readme first.

Recommendation: show them as buttons, but only in the Development environment, because the passwords are known and public. Keep the readme as the source and add a test that the list matches the realm file.

##### Answer 2
Show nothing.
<!-- region end: Question 2-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 4-->

<!-- region start: Phase 5-->
## Phase 5

### Description
<!-- region start: PhaseDescription-->
#### Goal
Resilience and telemetry. Show `Cat.Resilience` and `Cat.Telemetry` in the demo, for code that runs without Aspire.

#### Background
- `Aspire ServiceDefaults` already gives every service telemetry, health checks and the standard resilience handler. The demo uses Aspire, so it does not use `Cat.Telemetry` or `Cat.Resilience` today.
- `Cat.Resilience` and `Cat.Telemetry` are meant for projects without Aspire. The rule: a project with Aspire uses `ServiceDefaults`, and a project without Aspire uses the modules. See [Cat.Resilience.md](Cat.Resilience.md) and [Cat.Telemetry.md](Cat.Telemetry.md).
- The demo case for `Cat.Resilience` is retry and circuit breaker on the payment call. The case for `Cat.Telemetry` is tracing one order across all services.

#### What exists today
- The payment service is a service of ours, behind the gateway, with `ServiceDefaults`. It can fail on purpose with the settings `PaymentFailures:Latency`, `PaymentFailures:ErrorPercentage` and `PaymentFailures:Outage`.
- Orders replaces the standard resilience handler of the clients for payment and Inventory with a shorter one in `UseFastFailResilience`: one retry after 500 ms, 5 seconds per try and 12 seconds in total. `FastFailResilienceTests` covers it.
- The `ServiceDefaults` pipeline is chosen per service address, so a failing service opens its own circuit.
- `Cat.Resilience` and `Cat.Telemetry` do not exist yet.

#### Needs
The module plans [Cat.Resilience.md](Cat.Resilience.md) and [Cat.Telemetry.md](Cat.Telemetry.md) answered first.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 2-->
#### Question 2
What if the demo treats payment as a service we do not control, like a real payment provider? This is the blocking question, because question 1 follows from it. The answers from the code:
- **`ServiceDefaults`.** It is a project in our own solution. A service we do not control does not use it, and does not have to. What matters is the caller. Orders calls `AddServiceDefaults`, so every `HttpClient` in Orders gets the resilience handler, service discovery and the HTTP client tracing, whoever answers. We are not obliged to implement anything in the outside service.
- **Tracing.** The call shows as a client span in the trace of Orders, with its duration and status. The outside service joins the trace only when it understands the W3C `traceparent` header. A real provider often does not, so the trace stops at the edge. That is realistic and worth showing.
- **Resilience and tracing with CAT modules.** Yes, this is a good showcase, because retry, timeout and circuit breaker matter most for a service we cannot fix. The payment service would then run without `ServiceDefaults`, and Orders would swap the `ServiceDefaults` handler for `Cat.Resilience` on that one client. `UseFastFailResilience` in Orders already removes the default handler, so the spot exists.
- **`Cat.Api.Client`.** Yes, with limits. `AddCatApiClient` takes any address as a plain string, and the generated client needs only the OpenAPI document of the provider. Three things change. The call would not go through our gateway, so the rule "services never call each other directly" needs an exception for outside services. The error body of an outside service is not `CatErrorResponse`, so the helper keeps the status code but loses the error codes and arguments. The token of the user must not be forwarded to a third party. A provider key or its own token is used instead.

The options:
- **A.** Keep payment as it is, a service of ours behind the gateway. Cost: the demo never shows `Cat.Resilience` or `Cat.Telemetry`, and phase 5 shrinks to documentation.
- **B.** Make payment outside: no `ServiceDefaults`, no gateway, its own error format, and Orders uses `Cat.Resilience` and `Cat.Telemetry` for that call. Cost: the first provider changes, and the error codes of payment are lost to the client.
- **C.** Do B later as a second payment provider next to the first, selected by configuration. Cost: a second provider to build and a switch to maintain.

Recommendation: C. The `IPaymentProvider` interface already hides the provider, so a second one costs little. The first provider stays as it is and keeps working. The outside variant becomes the showcase for `Cat.Resilience` and `Cat.Telemetry` once those modules exist.
<!-- region end: Question 2-->

<!-- region start: Question 1-->
#### Question 1
When does the demo use `Cat.Resilience`: never, or in a part that runs without Aspire? The demo readme says the demo does not use `Cat.Resilience`, because `ServiceDefaults` covers it. This follows from question 2: with option A the answer is never, with option C it is the outside payment provider. Answer question 2 and this one is closed. The demo readme then needs one sentence about it.
<!-- region end: Question 1-->

<!-- region start: Question 3-->
#### Question 3
What do we do about the development certificate? The dashboard says "No trusted development certificate was found" when the machine has not run `dotnet dev-certs https --trust`. It is harmless now, because the AppHost, the dashboard and the services all run on HTTP (the AppHost launch settings set `ASPIRE_ALLOW_UNSECURED_TRANSPORT`). It matters once something uses HTTPS. The options:
- **Keep HTTP and add one note.** The run steps of the demo readme say the warning is harmless. Cost: the demo shows no HTTPS.
- **Tell the developer to trust the certificate** (`dotnet dev-certs https --trust`) and move the demo to HTTPS. Cost: one more setup step, and the unsecured transport setting goes away.
- **Do nothing.** Cost: a new developer sees the warning and wonders.

Recommendation: keep HTTP with one note in the run steps. The warning goes away by itself when something needs HTTPS, and then the step moves to the run steps.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Do all three failure switches of the payment service hold when the call goes through the gateway? The outage was tried live: with it on, the order ended after about 9 seconds. As far as we know, the latency and the error percentage were not tried through the gateway. The work is one order each, and a check that the gateway does not add its own timeout or retry that changes the result. Where do we write down the outcome?
- **In the payment chapter of the demo readme.** Cost: the readme gets a table of results that can go out of date.
- **As a test.** An integration test through the gateway. Cost: it needs the AppHost, so it is slow.
- **Not at all.** Check once and move on. Cost: nobody knows later what was tried.

Recommendation: check once by hand, and write the three results as one line each in the payment chapter of the demo readme. This needs the owner to run the AppHost, as Claude does not start it.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Should the health checks of the services cover their databases? Today every service answers `/health` (ready) and `/alive` (running) from one check, `self`, in `ServiceDefaults`, and that check is always healthy. The AppHost and the gateway watch `/health`, so a service with a database that is down still looks healthy. The options:
- **Add a database check per service,** on the ready endpoint only. Cost: a package per service (`AspNetCore.HealthChecks.SqlServer` or the EF Core check), and the services restart or stay out of the gateway while the database starts.
- **Add one check in `ServiceDefaults` that takes any `DbContext`.** Cost: `ServiceDefaults` must know about EF Core, and Inventory is built database first.
- **Keep it as it is.** Cost: a service shows healthy while its database is down.

Recommendation: a database check per service on `/health` only, and keep `/alive` as it is. It is a real pattern for developers to copy, and it is small. Do it in this phase only if the owner wants it, since it does not need the modules.
<!-- region end: Question 5-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 5-->

<!-- region start: Phase 6-->
## Phase 6

### Description
<!-- region start: PhaseDescription-->
#### Goal
Languages. The demo works in more than one language: the client has a language selector, and the mails are translated. `Cat.Localizations` provides the texts.

#### Background
- The owner moved this out of [Phase 2](#phase-2). The client has no language support, so everything is in English, and translated mails alone would not show.
- `Cat.Localizations` looks up localized texts by key. Its open points about the culture, localized data and error messages are in [Cat.Localizations.md](Cat.Localizations.md).

#### What exists today
- The client and the mails of Notifications (Phase 2) are in English.
- Catalog does not use `Cat.Localizations`, so category names are plain text. Showing them in several languages waits until the module is stable.
- `ICatLocalizer` has no culture parameter, so a provider must find the culture itself.

#### Needs
[Phase 2](#phase-2), for the Notifications service. The module plan [Cat.Localizations.md](Cat.Localizations.md) answered and built.

#### Done when
A user picks a language in the client, and the order confirmed mail arrives in that language.

#### Decided
- **Scope.** The phase supports translated mails and a client where the user selects the language.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 11-->
#### Question 11
Which languages does the demo support? Each one needs texts in the client, in the mails and in the Catalog data.
- **Two,** English and one more, for example Dutch. Cost: the least work, and it shows the idea.
- **Three or more.** Cost: more texts to write and keep in step, with little more to show.

Recommendation: two. It proves the mechanism, and a third language adds work and nothing to learn.

##### Answer 11
As recommended, English as the default language, Dutch as the extra language
<!-- region end: Question 11-->

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
<!-- region end: Phase 6-->