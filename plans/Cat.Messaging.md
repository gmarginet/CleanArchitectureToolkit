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
[![READY TO START BUILDING](https://img.shields.io/badge/Status-READY%20TO%20START%20BUILDING-green)](#plans-for-catmessaging)
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
A new module, `Cat.Messaging`, to publish and consume messages on Azure Service Bus with the same handler style as the other modules.

#### The idea
Services in the application architecture talk in two ways. A direct call goes through the API gateway. A message goes over Azure Service Bus. The architecture says to prefer messages, because they keep services loosely coupled.

Today the modules have nothing for the message side. `Cat.Messaging` fills that gap. A service publishes a message when something important happened, like `OrderPlaced`. Other services subscribe and react in their own time.

The module should feel like `Cat.Commands` and `Cat.Queries`: a message is a plain type, a handler handles it, a processor finds the handler, and decorators wrap it.

#### Background
From the readme:
- The sender does not know who receives the message.
- A slow or unavailable service does not block the sender.
- Messages stay on the bus until a consumer handles them.
- The bus runs in Azure. The services run as containers in Azure Container Apps.

From the demo plan:
- The demo uses the Azure Service Bus emulator. The AppHost starts it in Docker, next to SQL Server, when this module arrives.
- Orders publishes `OrderPlaced`. Inventory and Notifications consume it.
- Orders keeps announcing facts inside the service with `Cat.EventAggregators`. A subscriber bridges an event to the bus. The event aggregator itself is in-process only and cannot carry a message to another service.
- The modules must not depend on Aspire.

From the saga plan:
- The wait step of `Cat.Sagas` sends its request message through this module. It depends on the messaging abstractions.
- Saving the state and sending the message must be one unit. That needs an outbox, which the transaction part of `Cat.EFCore` may own.
- The trace context must travel with the message, so the second half of a workflow joins the same trace.

From the module conventions:
- A module has an abstractions project and an implementation project.
- Handlers are registered by scanning assemblies. Decorators come from `Cat.Decorators`.
- Outcomes are `ICatResponse` values from `Cat.Responses`.
- The processing side lives in `Cat.EventProcessor`, the worker of the service project structure. This module is the sending side and the shared contracts.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- The demo has no Service Bus emulator in the AppHost, no `OrderPlaced` message and no outbox. The demo readme says Inventory does not listen to `OrderPlaced` yet. That comes with the messaging stage.
- Orders announces facts inside the service with `Cat.EventAggregators`. `OrderAuditSubscriber` handles the order events. That is the place where a bridge to the bus would come.
- The comment on `IPaymentProvider` says the payment call may go over the Service Bus later.
- `System.Text.Json` is the serializer of the toolkit already. `Cat.Api.Client` uses it, and the generated clients use its attributes. Only the generator header of the generated clients mentions Newtonsoft.
- `Cat.Decorators`, `Cat.Responses` and `Cat.EventAggregators` exist. `Cat.Sagas` and `Cat.EventProcessor` do not.

#### Decided
- **Transport.** Azure Service Bus first.
- **Providers.** The first phase supports Azure Service Bus only. In the future the developer gets a choice, so a new broker must be possible to add. Every broker gets its own project in the module, such as `Cat.Messaging.AzureServiceBus` and `Cat.Messaging.RabbitMQ`.
- **Style.** The same handler, processor and decorator style as the other modules.
- **Demo hosting.** The Service Bus emulator, started by the AppHost.
- **Aspire.** The module never references Aspire.
- **Wait step.** `Cat.Sagas` goes through the messaging abstractions, not through `Cat.EventAggregators`.
- **Topology.** Both queues and topics. They are not created when a service starts. CAT provides an easy way to create them: a method in `Cat.Messaging.AzureServiceBus`, such as `EnsureTopologyAsync`, that the developer calls from a deployment step, a small tool or a test. It finds the message types by scanning assemblies, creates the queues, topics and subscriptions with the convention names and skips what exists. A subscription belongs to the receiving service, so `Cat.EventProcessor` knows its own subscriptions. The module readme also holds a sample script, so the developer can choose what to use.
- **Messages.** Events and command messages are separate types on one pipeline. `CatEventMessage` goes to a topic, with a subscription per receiving service. `CatCommandMessage` goes to a queue. There are two send methods, and the handler, the outbox, the serialization and the decorators are the same for both.
- **Base types.** The base classes implement an `ICatMessage` interface, so a type that cannot inherit can still be a message.
- **Base properties.** `MessageId` (Guid, copied to the Service Bus message ID), `CorrelationId` (Guid, created at the start of a flow and copied to every message that follows from it) and `OccurredAt`. A changing shape is handled by adding optional properties only. The trace context is not a property, the Service Bus SDK carries it.
- **Serializer.** `System.Text.Json` only, behind one small internal seam. It is not pluggable now. The message carries a content type property, so a later change does not break old messages. The saga plan follows this answer.
- **Outbox.** In the first version, in this module, as optional projects: `Cat.Messaging.Outbox` for the abstraction and the sender loop, and `Cat.Messaging.Outbox.EFCore` for the table and the writing. A developer who does not want an outbox leaves both out.
- **Scheduled delivery.** In scope, as an optional `scheduledAt` argument on the send methods. `Cat.Scheduling` and `Cat.Sagas` lean on it.
- **Two modules.** `Cat.Messaging` and `Cat.EventProcessor` stay two modules. For the demo they are built in one phase, and `Cat.Messaging` can be built independently of `Cat.EventProcessor`.
- **Contracts.** Message types live in the `Contracts` project of the sending service. A service that receives the message references that `Contracts` project.
- **Naming.** By convention the queue, topic and subject use the message type name. The developer can override the name.
- **Message properties.** An abstract base class holds the properties the module needs. It is used in the `Contracts` project of the sending service to declare the message types.
- **Delivery guarantees.** This module is about sending, so it only looks at the outbox pattern.
- **Failures.** A message that keeps failing goes to the dead letter queue. By convention the defaults of Azure Service Bus apply, and the developer can override them in the configuration of the service. Looking at the dead letter queue is the job of who runs the service.
- **Dead letter visibility.** Showing the dead letters is not a responsibility of CAT. The first version has a metric, the number of dead letters per queue or subscription, through `System.Diagnostics.Metrics` with the source name `Cat.Messaging`. The Aspire dashboard can show it without any Aspire code in the module. Reading the counts needs a management client, which needs the manage right on the namespace. So the metric is an option that the developer activates, and it is off by default.
- **Ordering and sessions.** The defaults of Azure Service Bus apply. Sessions are supported from day one, off by convention, and the developer can turn them on. Whether the emulator supports them is still to test, see the Emulator bullet.
- **Publishing places.** The command handler is the preferred place to publish a message, with the outbox. A service request handler may publish too, and is not recommended. An event subscriber of `Cat.EventAggregators` that bridges an in-process event to the bus is documented as the choice for a team that does not need the guarantee of the outbox. It is not known whether `Cat.EventAggregators` publishes before or after the save, so the subscriber is only safe with the outbox when it runs in the same unit of work as the command handler.
- **Emulator.** The official page (Microsoft Learn, "Overview of the Azure Service Bus emulator", updated 2026-09-19) says: partitioned entities and the JMS protocol are not supported, AMQP over TCP is the only transport, and entities and data do not persist after a container restart. Entities can be created with the administration client, but the settings in `config.json` override them at startup, and a change in the configuration file is not honored on the fly. The limits are 50 queues and topics per namespace and 50 subscriptions per topic. The page says nothing about dead letter queues, sessions, scheduled messages or reading message counts. These four are tested once the emulator is in the AppHost, and they only affect the Azure project. For the demo, the `config.json` of the emulator is the natural place to define the entities.

#### Can the module be built?
Yes. No open questions are left. One check remains for the build: dead letters, sessions, scheduled messages and the message counts against the emulator, see the Emulator bullet above. It only affects the Azure project.

What can start now:
1. `Cat.Messaging.Abstractions`: the message base types, the publisher and sender interfaces and the handler interface, in the style of `Cat.Commands`. It targets `netstandard2.0`.
2. `Cat.Messaging`: the processor and the registration by scanning assemblies, with the decorators from `Cat.Decorators`.
3. `Cat.Messaging.AzureServiceBus`: sending, the metric for dead letters and the name convention with an override. It targets the latest stable .NET, because it uses the Azure SDK. Check this when the project is added.
4. `Cat.Messaging.Outbox` and `Cat.Messaging.Outbox.EFCore`. The EF Core project targets the latest stable .NET.

The consuming side is in [Cat.EventProcessor.md](Cat.EventProcessor.md). The first version of this module is not worth much without it, so for the demo they are built in one phase.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->