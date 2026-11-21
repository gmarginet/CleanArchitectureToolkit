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

# Plans for `Cat.Outbox` <!-- omit in toc -->  

<!-- region start: FirstStableVersion-->
**First stable version:** not reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 2](#phase-2)
<!-- region end: Phases-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
A message keeps the trace context of its caller, also when it goes through the outbox, so one order is one trace across all services. This phase came over from the plan of `Cat.Messaging`.

#### Background
From the code:
- `CatServiceBusMessageMapper` of `Cat.Messaging.AzureServiceBus` adds no trace context. The Service Bus SDK puts its `Diagnostic-Id` on a message when it sends.
- With the outbox, a background service sends the message later. At that moment the context of the caller is gone, and the outbox row does not save it. A message through the outbox starts a new trace.
- The listener of `Cat.EventProcessor` continues the trace from the `Diagnostic-Id` of the message.
- To check when building: whether the Service Bus SDK only traces with a switch of the Azure SDK, such as `Azure.Experimental.EnableActivitySource`.

From the other plans:
- The saga plan: tracing across the gap of a message needs the trace context in the message properties.
- The demo shows "one order across all services" in the Aspire dashboard, see the [module readme of Cat.Telemetry](../modules/Cat.Telemetry/README.md#set-up-the-telemetry-of-a-service).

#### Decided
- **Who carries it.** The outbox carries the trace context of a message that goes through it. Without the outbox, `Cat.Messaging` leaves it to the SDK as today. `Cat.Telemetry` only lists the `Cat.Messaging` source, so no module depends on it (owner, 2026-11-21).
- **How.** The row saves the W3C `traceparent` of the caller (`Activity.Current.Id`), and the background service sends the message with that context as its `Diagnostic-Id`. `CatOutbox` gets one more column, with a migration (owner, 2026-11-21).

#### Integration tests
The outbox with the new column on SQL Server and on PostgreSQL, in `integrationtests/`: a message saved inside an activity is sent with the `traceparent` of that activity. The outbox is plain EF Core, so PostgreSQL needs no separate code.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->