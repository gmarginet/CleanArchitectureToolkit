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
- [Phase 1](#phase-1)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
A message that goes through the outbox continues the trace of its caller in the receiving service, so one order is one trace across the services.

#### Background
- The outbox saves the W3C `traceparent` of the caller in the column `TraceParent` and sends it as the property `Diagnostic-Id`, see the [module readme of Cat.Outbox](../modules/Cat.Outbox/README.md#keep-the-trace-of-the-caller). The integration tests on SQL Server and on PostgreSQL cover that.
- A live test on the AppHost showed that the receiving side still starts a new trace for `TakePayment`. The dashboard shows no span of the Azure Service Bus SDK at all, not on the sending side and not on the receiving side.
- Tried without success: the source `Azure.Messaging.ServiceBus` in the traces and the switch `Azure.Experimental.EnableActivitySource` set in code with `AppContext.SetSwitch`. Both were reverted, because they changed nothing.
- To check: how the SDK 7.21.0 and Azure.Core 1.62.0 turn on their activity source, and whether the switch must be set before the first use of Azure.Core, or as the environment variable `AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE`.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Who makes the receiving side continue the trace?
- **The SDK.** Find out how to switch the Azure activity source on, and where that setting lives. `Cat.Telemetry` can set it for every service, but it then depends on the SDK internals. It costs a dependency on an experimental switch.
- **The listener of `Cat.EventProcessor`.** The listener reads `Diagnostic-Id` itself and starts the activity of the handling with it as the parent. It costs a little code in the listener and no switch, and it works the same with another broker later.

Recommendation: the listener, because it does not depend on an experimental switch of the SDK and the `Diagnostic-Id` is already on the message.
<!-- region end: Question 1-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->