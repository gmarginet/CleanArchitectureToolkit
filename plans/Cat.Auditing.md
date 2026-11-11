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

# Plans for `Cat.Auditing` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catauditing)
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
A new module, `Cat.Auditing`, that records who changed what and when.

#### The idea
Some changes matter later: a price that was changed, an order that was cancelled. People ask who did it and when. An audit trail answers that without anyone writing log statements by hand.

`Cat.Auditing` records the change together with the user and the time. The business logic should not have to know about it.

#### Background
From the demo plan:
- The demo shows it with who changed a price, and who cancelled an order.
- Orders has an event subscriber, `OrderAuditSubscriber`, that writes an audit record when an order event happens. It is a first sketch of what the module could replace.
- Catalog keeps every old price in a temporal table, which already answers "what was the price then". It does not say who changed it.
- The demo gets the current user from its own `ICurrentUser`, with `UserId`, `Name`, `Email` and `IsAdmin`. It lives in the core service for now. It will become `ICatUser` in `Cat.Authorization.Abstractions`. A development stub reads the `X-Demo-User` header.
- Work without a user, like a scheduled job, has no person to record. The Scheduler uses a client credentials token.

From the module conventions:
- Cross-cutting work is added through decorators, not mixed into the business logic. `Cat.ServiceRequests`, `Cat.Commands` and `Cat.Queries` all run decorators from `Cat.Decorators`.
- Events inside a service go through `Cat.EventAggregators`. Subscribers cannot drive a process, and a failing subscriber throws.

From the architecture:
- Every service owns its data. An audit trail for a service belongs to that service, unless a central audit store is chosen.
- Important events also go out on the Service Bus.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- The demo has `OrderAuditSubscriber` in the core service of Orders, and its own `ICurrentUser`.
- `ICatUser` does not exist yet. It is planned in `Cat.Authorization.Abstractions`, see [Cat.Authorization.md](Cat.Authorization.md).
- `Cat.EFCore.Entities` has a temporal entity base class, which keeps the history of the entity.

#### Decided
- **Content.** Who, what and when.
- **Style.** Added through a decorator or an event subscriber, not in the business logic.
- **User.** The module gets the user from `ICatUser` in `Cat.Authorization.Abstractions`. `Cat.Authorization` owns that interface.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
What is audited, and where do we hook in? This is the blocking question, and questions 2, 7, 9 and 10 follow from it. Each hook sees something different:
- **A decorator on commands.** Sees the use case: "Alice cancelled order 123", and the command with its data. Cost: it does not see changes made outside commands, and it does not know the old values.
- **A decorator on service requests.** Sees the request from outside, with the user. Cost: a request can run several commands, so one audit row may cover several changes.
- **A `SaveChanges` interceptor in EF Core.** Sees every entity change with old and new values, whoever made it. Cost: it only knows entities, not the intention, and it ties the module to EF Core (a project that targets the latest .NET).
- **An event subscriber** (what `OrderAuditSubscriber` does). Sees the facts the business logic announces. Cost: it audits only what a developer remembered to announce, and a failing subscriber throws.

Recommendation: the command decorator as the first project, since it fits the style of the other modules and answers "who did what". A `SaveChanges` interceptor can come as a second project (`Cat.Auditing.EFCore`) for old and new values, see question 2. A developer picks one or both.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Do we want old and new values, or only the fact? The options:
- **Only the fact.** "Order 123 cancelled by Alice at 10:15". Cost: you cannot see what a price was before.
- **Changed fields with old and new values.** Cost: it needs the interceptor of question 1, a serializer, and privacy rules (question 5).
- **The fact by default, the values as an opt in** per entity. Cost: two modes to document.

Recommendation: only the fact in the first version. Catalog already has temporal tables for the old values of a price (question 11), so the demo case "who changed it" needs the fact plus the temporal history.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Where should the trail live: in each service database or in one central place? The architecture says every service owns its data. The options:
- **A table in the database of the service.** Cost: one table per service, no overview across services, and it needs EF Core or Dapper.
- **A separate store** such as a log or blob store. Cost: one more thing to run.
- **Messages to a central audit service.** Cost: it needs `Cat.Messaging`, an audit service in the demo, and a decision on who owns it.

Recommendation: a table in the database of the service, behind a small `IAuditStore` interface in `Cat.Auditing.Abstractions`. It follows the architecture and works without the messaging modules. A central store can be added as another implementation.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Is it fine that this module references `Cat.Authorization.Abstractions` for `ICatUser`, without the rest of the authorization module? The Decided list already says the module gets the user from `ICatUser`. What is left is how much of it auditing needs. The options:
- **Yes, take `ICatUser` as it is.** Cost: a package called Authorization for a developer who only wants auditing, though it is light and the abstractions are separate from the module.
- **Auditing defines its own small `IAuditUserProvider`.** Cost: a developer must wire it to `ICatUser`, which is a duplicate of the shared abstraction rule.

Recommendation: yes, take `ICatUser`. The toolbox rule says a shared abstraction lives in the `Abstractions` project of the module that owns it, and that is the point of the split. Auditing only needs `UserId` and `Name`. It does not need `Email`, which is also better for privacy.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
How long must the trail be kept, and are there privacy rules we must follow? Names, emails and addresses are personal data. The options:
- **The module decides nothing.** The developer owns retention and privacy. The module only offers a way to delete or anonymize rows. Cost: a developer can forget it.
- **A default retention setting** such as "keep for 2 years", with a cleanup job through `Cat.Scheduling`. Cost: a dependency on another module, and a number that is a legal question, not a technical one.
- **Store only the user ID, never the name or email.** Cost: the trail needs a lookup to show a name.

Recommendation: store the user ID only (and the name as an option), and leave retention to the developer with a documented way to delete. A retention period is a legal decision that depends on the developer's country and business.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Is an audit failure allowed to fail the business action? If writing the audit record fails, does the change fail too? The options:
- **Yes, the action fails too.** The audit is written in the same transaction. Cost: a broken audit store stops the business, but there are no unaudited changes.
- **No, log the failure and go on.** Cost: a change can exist without a record.
- **A setting per module registration,** with a default.

Recommendation: yes, fail, by default, and write the audit row in the same `SaveChanges` as the change when the store is in the same database (question 3). The point of an audit trail is that it is complete. A setting can switch it for developers who accept gaps.
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
How do we mark what to audit? Only relevant when the command decorator is used (question 1). The options:
- **Everything is audited.** Cost: a lot of noise, and queries and reads are included unless left out.
- **A marker interface on the command,** such as `ICatAuditedCommand`. Cost: the command carries an interface, which is a dependency of the `Contracts` or core on this module.
- **An attribute on the command.** Cost: the same dependency, and reflection.
- **A list in the registration,** such as `AddAudit<BookSaveCommand>()`. Cost: the list is far from the command, but the core stays free of the module.

Recommendation: the list in the registration. It keeps the core free of auditing, as the Decided list asks ("not in the business logic"). Commands only, never queries.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
What should be recorded when there is no user, for example for a scheduled job or a message handler? The options:
- **A named system user,** such as the service name. This is what the scheduling plan recommends for `ICatUser`, so the audit row always has a user. Cost: none, since `Cat.Authorization` supplies it.
- **No user recorded** (null). Cost: a row that does not say who did it.

Recommendation: the named system user. It needs no special case in the audit module, and it follows question 9 in [Cat.Scheduling.md](Cat.Scheduling.md).
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Do we need to read the trail in the demo, and through which endpoint? The options:
- **The module offers a query handler** that reads the trail by entity or by user, and the service exposes it. Cost: the module needs to know the store shape, and the read needs authorization.
- **Reading is the job of the service.** The module only writes and exposes the store interface. Cost: every service writes its own read query.
- **No read in the demo.** The trail is visible in the database only. Cost: the demo does not show the value of the module.

Recommendation: the service reads it. The module offers the store interface and a ready query handler as an optional project later. The demo shows it with one admin only endpoint, for example on Orders.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Does `OrderAuditSubscriber` in the demo stay as an example of the event approach, or does the module replace it? The options:
- **The module replaces it.** The demo then shows the module. Cost: the demo loses its example of an event subscriber, and `OrderAuditSubscriber` also does other things than audit if it does.
- **It stays.** Cost: the demo shows two ways to do audit, which can confuse a reader.
- **It stays, and the demo audits a different case with the module,** such as the price change in Catalog. The two then show the two approaches. Cost: the demo readme must explain why both exist.

Recommendation: the module replaces it in Orders (the cancel case), and Catalog shows the price case. The event subscriber approach stays in the demo through the status update and the stock release subscribers.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Temporal tables already keep history for some entities. Does the module use them or stay apart? The options:
- **Stay apart.** The trail says who and when, and the temporal table says the old values. Cost: two sources to join when a person asks "who changed the price from what to what".
- **Use them.** The module links an audit row to a temporal row by time. Cost: it is SQL Server specific, and it ties the module to `Cat.EFCore.Entities`.

Recommendation: stay apart, and show the join in the demo readme. This keeps the module independent of SQL Server, and it is what question 2 recommends.
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Does the trail need to be append only, so it is tamper evident? The options:
- **Append only by convention.** The store interface has an add method and no update or delete. Cost: someone with database access can still change rows.
- **Append only in the database.** A permission setup or a ledger table (SQL Server ledger). Cost: provider specific, and a database setup the module cannot do.
- **Not a goal.** Cost: the trail is not proof in a dispute.

Recommendation: append only by convention in the first version. A database level guarantee is a setup choice for the developer, and the readme can point to ledger tables.
<!-- region end: Question 12-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->