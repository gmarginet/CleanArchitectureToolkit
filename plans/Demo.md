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
- [Phase 1](#phase-1)
- [Phase 2](#phase-2)
- [Phase 3](#phase-3)
- [Phase 4](#phase-4)
- [Phase 5](#phase-5)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
Messaging. `Cat.Messaging` and `Cat.EventProcessor`, the Service Bus emulator in the AppHost, and the `OrderPlaced` bridge in Orders.

#### Background
- Every phase of this plan ends in a working demo. A phase is done when its "Done when" is true, the demo readme and the drawing are current (the `cat-internal-create-demo-readme` skill) and the tests pass.
- The demo uses the Azure Service Bus emulator. It runs in Docker, so it fits the Aspire setup. The AppHost starts it next to SQL Server when `Cat.Messaging` arrives.
- Orders publishes `OrderPlaced`. Inventory and Notifications consume it.
- Orders keeps announcing facts inside the service with `Cat.EventAggregators`. A subscriber bridges an event to the bus. The event aggregator itself is in-process only and cannot carry a message to another service.
- Inventory came before messaging on purpose. Reserving stock needs an answer, and a message gives none. So Orders calls Inventory over HTTP, and messages tell Inventory about the order afterwards.
- The modules come from working code. The module is designed from what the demo shows, the way `CatalogPriceProvider` came before `Cat.Api.Client`.
- The modules must not depend on Aspire.

#### What exists today
- The Service Bus emulator is not in the AppHost, and the box in the drawing is hatched. The demo readme lists it as planned.
- Orders publishes no `OrderPlaced`. Its event subscribers handle the order events inside the service: the status update, the audit record and the stock release.
- Inventory has no message listener. The demo readme says it does not listen to `OrderPlaced` yet.
- `Cat.Messaging` and `Cat.EventProcessor` do not exist yet. Their plans are [Cat.Messaging.md](Cat.Messaging.md) and [Cat.EventProcessor.md](Cat.EventProcessor.md).

#### Needs
The module plans [Cat.Messaging.md](Cat.Messaging.md) and [Cat.EventProcessor.md](Cat.EventProcessor.md) answered and built.

#### Done when
Orders publishes `OrderPlaced` and Inventory consumes it. The emulator box in the drawing is solid.

#### Decided
- **Messaging.** The Azure Service Bus emulator, started by the AppHost.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
What do the ERDs in the demo readme show? The three ERDs (Catalog, Orders, Inventory) in `demo/README.md` were checked against the entity classes, the `DbContext` indexes, the EF migration and the Inventory SQL scripts. Tables, columns, types and relations all match. One fix is done: `OrderStatus.Code` has a unique index in `OrderDbContext`, so the Orders ERD marks it `UK`. Three points are left for the owner to decide.

##### Question 1.1
Do we keep the `BookPrice` validity columns in the ERD? The Catalog ERD shows `ValidFrom` and `ValidUntil` on `BookPrice`. They are columns in the database but not properties of the class yet, because the class gets them after the release of EF Core 11. The ERD shows the database, so they stay. Keep it that way, or show only the properties of the class?

##### Question 1.2
Do we make the composite unique constraints in Inventory visible? The scripts have two: `(WarehouseId, Isbn)` on `StockItem` and `(StockItemId, OrderNumber)` on `StockReservation`. The second one makes a repeated reserve call safe. An ERD cannot mark a composite key with `UK`. Do we add a comment on the entity to make it visible?

##### Question 1.3
Do we show nullability in the ERDs? `Payment.PaidAt` is nullable in the class. The ERD does not show nullability for any column.
<!-- region end: Question 1-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
Notifications and scheduling. The Notifications service, `Cat.Scheduling` and `Cat.Localizations` for the texts. The nightly clean up of the order counters, the cancel of unpaid orders and a nightly low stock report.

#### Background
- Notifications sends the order confirmed and order shipped messages. It also runs the scheduled jobs. It consumes `OrderPlaced`.
- The scheduled jobs of the demo:
  - Clean up the daily order counters every night, shortly after midnight UTC.
  - Cancel unpaid orders after 24 hours.
  - A nightly low stock report.
- `Cat.Localizations` writes the texts in the language of the customer: category names, order statuses and email texts in a few languages.
- Work without a user, such as the Scheduler, uses a client credentials token.
- The Scheduler is the worker of a service, as the readme describes it. In debug mode the API has a development endpoint group with a sub group per worker.

#### What exists today
- The Notifications service does not exist. The demo readme lists it as planned, and the box in the drawing is hatched.
- The `CleanUpOrderCounters` service request exists in Orders, with its handler and tests. The development endpoint `POST /development/scheduler/clean-up-order-counters` triggers it, in the Development environment only. Orders has no `Scheduler` project yet.
- The Keycloak realm has the clients `cat-demo-web` and `cat-demo-cli` only. It has no client for a client credentials token.
- Catalog does not use `Cat.Localizations`, so category names are plain text. Showing them in several languages waits until the module is stable.
- `Cat.Scheduling` does not exist yet. Its plan is [Cat.Scheduling.md](Cat.Scheduling.md). The plan recommends that a one-off timeout, such as the cancel after 24 hours, goes through a scheduled message of the bus and not through the Scheduler.

#### Needs
Phase 1. The module plan [Cat.Scheduling.md](Cat.Scheduling.md) answered and built. A decision on where Notifications stores its data.

#### Done when
An order confirmed mail is written in the language of the customer. The nightly jobs run from the Scheduler, and the development endpoint can go.

#### Decided
- **Counter cleanup.** The Scheduler runs the `CleanUpOrderCounters` service request every night. Until the Scheduler exists, the development endpoint triggers it.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
How is Notifications built, and where does it store its data? The decision is made once the Scheduling module is designed. It is not decided yet whether the service has a database, or whether it is built code first or database first.
<!-- region end: Question 1-->
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
- `Cat.Auditing`: who changed a price or cancelled an order.
- `Cat.Authorization`: customers see their own orders, and admins edit the catalog.
- `Cat.Sagas`: a payment over messages.
- `Cat.UnitTesting`: the unit tests of the demo.

Every module is designed from what the demo shows, and the module plan of each is built first.

#### What exists today
- None of these modules exists yet. Each has a plan with the same name in this folder, such as [Cat.Caching.md](Cat.Caching.md).
- Orders has an event subscriber, `OrderAuditSubscriber`, that writes an audit record when an order event happens. It is a first sketch of what `Cat.Auditing` could replace.
- Catalog keeps every old price in a temporal table, which answers "what was the price then". It does not say who changed it.
- Ownership of orders is a filter in the queries, and the demo has its own `ICurrentUser` in the core service of Orders.
- The Catalog save endpoint requires the `admin` policy. A decorator on `BookSaveRequest` and a test that a user who is not an admin gets a 403 in `CoreService` do not exist yet.
- Inventory reads through the EF Core scaffold only.
- A cancelled order keeps its `Approved` payment, because there is no refund step yet.
- The unit tests of the demo have their own copies of the fake command and query processors.

#### Needs
The module plan of each showcase, built first.

#### Done when
Per module: the demo uses it and the readme says where.

#### Decided
- **Current user.** The business logic only knows `ICurrentUser`. The interface moves to `Cat.Authorization.Abstractions` and is renamed `ICatUser` when that project exists. Until then the demo keeps `ICurrentUser`. See [Cat.Authorization.md](Cat.Authorization.md).
- **Inventory data access.** The EF Core scaffold only for now. Dapper waits for the `Cat.Dapper` module.
- **Payment over messages.** A saga style payment over messages comes later, see [Cat.Sagas.md](Cat.Sagas.md). Until then the payment is an interface behind a generated client, and Orders keeps its state in the order status.

#### Known gaps for these showcases
- **Admin check on the Catalog save.** Consider an admin check as a decorator on `BookSaveRequest` over `ICurrentUser`, so the rule lives in `CoreService` and is testable without HTTP. Add a test that a user who is not an admin gets a 403 on the save. This goes with `Cat.Authorization`.
- **No refund for a cancelled order.** Add a refund when payment becomes a message flow, see [Cat.Sagas.md](Cat.Sagas.md):
  - A `Refunded` payment status, and an `IPaymentProvider` refund call.
  - `OrderCancelledEvent` gets a subscriber that refunds an approved payment.
  - Cancelling a confirmed order is then only done when the refund succeeded or is on its way.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
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
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Does the sign-in page show the demo users `alice`, `bob` and `admin`, and where do they come from? The passwords are in the demo readme today.
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
<!-- region start: Question 1-->
#### Question 1
When does the demo use `Cat.Resilience`: never, or in a part that runs without Aspire? The demo readme says the demo does not use `Cat.Resilience`, because `ServiceDefaults` covers it.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
What if the demo treats payment as a service we do not control, like a real payment provider? The answers from the code:
- **`ServiceDefaults`.** It is a project in our own solution. A service we do not control does not use it, and does not have to. What matters is the caller. Orders calls `AddServiceDefaults`, so every `HttpClient` in Orders gets the resilience handler, service discovery and the HTTP client tracing, whoever answers. We are not obliged to implement anything in the outside service.
- **Tracing.** The call shows as a client span in the trace of Orders, with its duration and status. The outside service joins the trace only when it understands the W3C `traceparent` header. A real provider often does not, so the trace stops at the edge. That is realistic and worth showing.
- **Resilience and tracing with CAT modules.** Yes, this is a good showcase, because retry, timeout and circuit breaker matter most for a service we cannot fix. The payment service would then run without `ServiceDefaults`, and Orders would swap the `ServiceDefaults` handler for `Cat.Resilience` on that one client. `UseFastFailResilience` in Orders already removes the default handler, so the spot exists.
- **`Cat.Api.Client`.** Yes, with limits. `AddCatApiClient` takes any address as a plain string, and the generated client needs only the OpenAPI document of the provider. Three things change. The call would not go through our gateway, so the rule "services never call each other directly" needs an exception for outside services. The error body of an outside service is not `CatErrorResponse`, so the helper keeps the status code but loses the error codes and arguments. The token of the user must not be forwarded to a third party. A provider key or its own token is used instead.

The options:
- **A.** Keep payment as it is, a service of ours behind the gateway.
- **B.** Make payment outside: no `ServiceDefaults`, no gateway, its own error format, and Orders uses `Cat.Resilience` and `Cat.Telemetry` for that call.
- **C.** Do B later as a second payment provider next to the first, selected by configuration.

Recommendation: C. The `IPaymentProvider` interface already hides the provider, so a second one costs little. The first provider stays as it is and keeps working. The outside variant becomes the showcase for `Cat.Resilience` and `Cat.Telemetry` once those modules exist. It also answers the question above on when the demo uses `Cat.Resilience`.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
What do we do about the development certificate? The dashboard says "No trusted development certificate was found" when the machine has not run `dotnet dev-certs https --trust`. It is harmless now, because the AppHost, the dashboard and the services all run on HTTP. It matters once something uses HTTPS. Do the run steps of the demo readme then tell a developer to trust the certificate, and does the AppHost keep `ASPIRE_ALLOW_UNSECURED_TRANSPORT`?
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Do all three failure switches of the payment service hold when the call goes through the gateway? The outage was tried live: with it on, the order ended after about 9 seconds. As far as we know, the latency and the error percentage were not tried through the gateway. Test them with one order each, and check that the gateway does not add its own timeout or retry that changes the result. Where do we write down the outcome: in the payment chapter of the demo readme?
<!-- region end: Question 4-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 5-->