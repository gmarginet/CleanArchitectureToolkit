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

# Plans for `Cat.Messaging` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![NOT STARTED](https://img.shields.io/badge/Status-NOT%20STARTED-blue)](#plans-for-catmessaging)
<!-- region end: StatusBadge-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
- [Phase 3](#phase-3)
<!-- region end: Phases-->

<!-- region start: Phase 3-->
## Phase 3

### Description
<!-- region start: PhaseDescription-->
#### Goal
Let a developer override every Azure Service Bus option of the Azure project. The Microsoft defaults stay the convention of CAT, and the module sets only what it needs.

#### What exists today
- The module builds the objects with the Microsoft defaults. It sets the connection string on `ServiceBusClient` and on `ServiceBusAdministrationClient`, and `RequiresSession` on a queue it creates. The topics it creates get no setting.
- A developer can replace the client or the administration client by registering their own before the module, because the module uses `TryAddSingleton`. Nothing else can be changed.
- The processors of the event processor set `AutoCompleteMessages = false` and the concurrency. See [Cat.EventProcessor.md](Cat.EventProcessor.md).

#### Decided
- **Convention.** The defaults of Azure Service Bus are the defaults of CAT. A developer can override every option.
- **Callbacks.** `CatServiceBusOptions` gets one callback per SDK object: the client, the administration client, a queue, a topic, a subscription and a processor. The module builds the SDK object with its own values, then calls the callback, so the developer can change anything.
- **Values the module owns.** The module sets `AutoCompleteMessages` and `RequiresSession` after the callback runs, so a callback cannot break how the module settles messages or how sessions work. The module readme lists these values.
- **Scope.** The client, the administration client, the queues and the topics are in `Cat.Messaging.AzureServiceBus`. The processors and the subscriptions are in `Cat.EventProcessor.AzureServiceBus`, see [Cat.EventProcessor.md](Cat.EventProcessor.md).
- **Client retry options.** They are part of the client callback. The SDK defaults are 3 retries, exponential back-off, a base delay of 0.8 seconds and a maximum delay of 60 seconds. They cover failed calls to the bus, and not the redelivery of a message, see the module readme of `Cat.Messaging`.

#### What to build
- The callbacks on `CatServiceBusOptions`, used where the module creates the SDK objects, with tests that a callback changes an option and that the module values win.
- The module readme chapter with the callbacks, an example of a retry override, and the list of values the module owns.

#### Still to check
- The names of the callbacks.
- Whether the processor callback runs for every message type or per message type.

#### Can the phase be built?
Yes, after the names are chosen.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 3-->