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
- [Phase 2](#phase-2)
<!-- region end: Phases-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
Test the Azure Service Bus project against the Service Bus emulator, and change the code or the module readme where the emulator shows a problem. Also turn on duplicate detection in the topology helper.

#### What exists today
- Phase 1 is built: see the [module readme](../modules/Cat.Messaging/README.md). It was tested without the emulator.
- The demo AppHost starts the Service Bus emulator. Orders publishes `OrderConfirmed` through it, and Inventory receives it. The services create the topic and the subscription at startup, through the management port of the emulator. That flow was checked by hand, and it is not one of the tests below.

#### Decided
- **Emulator facts.** The official page (Microsoft Learn, "Overview of the Azure Service Bus emulator") says nothing about dead letter queues, sessions, scheduled messages or reading message counts. These four are still to test, now that the emulator is in the AppHost.
- **Duplicate detection.** `EnsureTopologyAsync` turns on duplicate detection on the queues and topics it creates, so the bus drops a repeated message with the same `MessageId` inside a time window. That removes the duplicates of an outbox that sends a row twice. It is decided in [Cat.EventProcessor.md](Cat.EventProcessor.md), and it is a setting that is made when the queue or topic is created.
- **Scope.** Only the Azure project is affected.
- **No redelivery delay.** The Azure Service Bus docs name no queue or topic setting for a delay between redeliveries. A failed message comes back at once, until `MaxDeliveryCount` is reached. The owner accepts this. `EnsureTopologyAsync` sets no delay, and the module readme says so in the chapter about the dead letters. The event processor adds no backoff, see [Cat.EventProcessor.md](Cat.EventProcessor.md).

#### What to test
1. A message that keeps failing reaches the dead letter queue.
2. A queue with sessions: `RequiresSession` and `ICatSessionMessage` work together.
3. A message with a `scheduledAt` is delivered at that moment.
4. The dead letter metric can read the counts of a queue and of a subscription.
5. A message with the same `MessageId` that is sent twice reaches the receiver once, on a queue and on a topic that `EnsureTopologyAsync` created.

#### What to build
- Duplicate detection in `ServiceBusTopology`, with a test of the creation options. The module readme says so in the chapter about creating the queues and topics, and the sample script gets the matching Azure CLI option.

#### Can the phase be built?
Yes. The emulator is in the AppHost, and nothing is open. Nothing in the docs rules out the five tests. The emulator keeps a message for 1 hour at most, so keep the duplicate detection window of the test under that.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->