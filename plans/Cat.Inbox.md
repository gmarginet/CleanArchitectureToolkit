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

# Plans for `Cat.Inbox` <!-- omit in toc -->  

<!-- region start: FirstStableVersion-->
**First stable version:** not reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 1](#phase-1)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
A module of its own for the inbox. It skips work that was handled before, for a message from the bus and for an inbound HTTP call, such as a webhook.

#### The idea
A payment provider sends a webhook at least once, and often twice. A handler that cannot run twice, such as one that books a refund in a ledger, needs to skip the second one. The inbox already does that for bus messages, and a webhook needs the same. This plan took the inbox over from the plan of `Cat.EventProcessor`.

#### Background
From the code and the module readme:
- The inbox stores the ID of a handled message in the service database, in the same `SaveChanges` as the work of the handler. A repeated message hits the key of the table and is skipped. See the [module readme of Cat.EventProcessor](../modules/Cat.EventProcessor/README.md).
- The contract of the store, `ICatInboxStore`, lives in `Cat.EventProcessor.Abstractions`. `Cat.EventProcessor.Inbox.EFCore` holds the `CatInbox` table and its store.
- The inbox is switched on per message type with `UseInbox`. A message without an ID is handled without it. The policy check runs before the inbox.
- The inbox only works for messages from the bus. Nothing in the modules skips an HTTP call that was handled before.
- A webhook that resumes a saga needs none of this. `ICatSagaDispatcher.ResumeAsync` ignores an answer for an instance that is not waiting any more.
- Many providers send an event id with every webhook. The Standard Webhooks specification names the headers `webhook-id`, `webhook-timestamp` and `webhook-signature`. To check when building, since this was not read from the specification in this repository.

From the demo plan:
- The demo has no webhook. The payment provider answers in the call itself, see [Demo.md](Demo.md#phase-17). This phase makes a webhook possible for a developer, and the demo does not show it.

#### What exists today
- The inbox for bus messages lives in `Cat.EventProcessor`: `ICatInboxStore` and `UseInbox` on `CatReceiveOptions` in `Cat.EventProcessor.Abstractions`, and the table `CatInbox` with its store in `Cat.EventProcessor.Inbox.EFCore`.
- The receiver and the listener of `Cat.EventProcessor` call the store. The tests of `Cat.EventProcessor` and `Cat.Sagas`, and the integration tests `EfCoreStoreIntegrationTests` and `ReceiverInboxIntegrationTests`, use it.
- Orders in the demo uses the inbox in its `OrderDbContext` and cleans it up in `InboxCleanUpCommandHandler`.
- The store is plain EF Core, so the HTTP inbox needs no separate PostgreSQL code.
- The toolkit is in alpha and the demo is the only user, so a breaking change is allowed (owner, 2026-11-21).

#### Decided
- **Close the gap.** The modules get what a webhook needs, so a handler of a webhook that cannot run twice is safe (owner, 2026-11-20).
- **A module of its own.** `Cat.Inbox` holds the inbox. The store contract, the `CatInbox` table and its EF Core store move out of `Cat.EventProcessor`, and the HTTP inbox is part of this module. `Cat.EventProcessor` uses `Cat.Inbox` for bus messages. A developer with a webhook and no bus pulls in no event processor (owner, 2026-11-21).
- **Projects.** `Cat.Inbox.Abstractions` holds `ICatInboxStore` and targets `netstandard2.0`. `Cat.Inbox.EFCore` holds the `CatInbox` table and its store, and `Cat.Inbox.AspNetCore` the endpoint filter, both on `net10.0;net11.0`. The table keeps its name, so a database needs no migration (owner, 2026-11-21).
- **A bridge to the event processor.** `Cat.EventProcessor` never references `Cat.Inbox`. `Cat.EventProcessor.Abstractions` gets one narrow interface of its own for a message that was handled before, and the receiver asks the container for it, as it does for `ICatMessageAuthorizer`. A bridge project `Cat.EventProcessor.Inbox` in the module `Cat.EventProcessor` implements it with `ICatInboxStore`. `UseInbox` stays on `CatReceiveOptions`, so the setup of a developer does not change (owner, 2026-11-21).
- **The id of an HTTP call.** Two overloads of `WithCatInbox`. One takes the name of a header, such as `.WithCatInbox(header: "webhook-id")`. The other takes a function over the arguments the endpoint already bound, such as `.WithCatInbox((RefundEvent e) => e.EventId)`, for a provider with the id in the body. To check when building: whether an endpoint filter can reach the bound arguments by type (owner, 2026-11-21).
- **A call without an id.** It is handled without the inbox, the same as a bus message without an id, and the filter logs a warning with the route and the header name, so a wrong header name or a provider that sends no id shows up (owner, 2026-11-21).
- **One save with the work.** The same rule as the receiver. The filter adds the row to the `DbContext` of the request scope, and the work saves it in its own `SaveChanges`. A call that fails saves nothing. Of two copies at the same moment, the second fails on the key of the table and answers an error, so the provider sends it again and the inbox then skips it. The endpoint saves through the context of its own scope, such as with `ICatCurrentScopeCommandProcessor`. After the endpoint, the filter checks that its row was saved and logs an error when it was not, which catches an endpoint that used `ICatCommandProcessor` and its new scope (owner, 2026-11-21).
- **The answer to a repeat.** The filter skips the work and answers `200 OK` with no body. A developer can set another status per endpoint, such as `204`. The inbox saves no answer of the first call, because a webhook provider only looks at the status (owner, 2026-11-21).
- **No signature check.** The module does not check the signature of a webhook. The developer uses the SDK of the provider. The module readme shows the order: the signature check runs before the inbox, as the policy check does on the bus (owner, 2026-11-21).

#### Integration tests
- The existing inbox tests on SQL Server and on PostgreSQL move with the store and keep passing.
- An endpoint with the HTTP inbox and the EF Core store, on SQL Server and on PostgreSQL, in `integrationtests/`: the second call with the same id is skipped, and a call that fails leaves no row.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->