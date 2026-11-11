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
What is audited: use cases, entity changes or both? Where do we hook in: a decorator on commands, a decorator on service requests, a `SaveChanges` interceptor in EF Core, or an event subscriber? Each sees something different.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Do we want old and new values, or only the fact? Is it only the fact ("order 123 cancelled by Alice"), or the changed fields with old and new values?
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Where should the trail live: in each service database or in one central place? Options are a table in the database of the service, a separate store, or messages to a central audit service.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Is it fine that this module references `Cat.Authorization.Abstractions` for `ICatUser`, without the rest of the authorization module? Is a dependency on a package called Authorization acceptable for developers who only want auditing? Which members of `ICatUser` does auditing need?
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
How long must the trail be kept, and are there privacy rules we must follow? Names, emails and addresses are personal data. What is left out?
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Is an audit failure allowed to fail the business action? If writing the audit record fails, does the change fail too?
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
How do we mark what to audit? Is everything audited, or only what is marked? If marked, how: an attribute, a registration or an interface?
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
What should be recorded when there is no user, for example for a scheduled job or a message handler?
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Do we need to read the trail in the demo, and through which endpoint? Does the module offer a query to read the trail, or is that the job of the service?
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Does `OrderAuditSubscriber` in the demo stay as an example of the event approach, or does the module replace it?
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Temporal tables already keep history for some entities. Does the module use them or stay apart?
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Does the trail need to be append only, so it is tamper evident?
<!-- region end: Question 12-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->