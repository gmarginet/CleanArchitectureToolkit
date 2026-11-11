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
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catmessaging)
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
- **Topology.** Both queues and topics. They are created when a service starts.
- **Contracts.** Message types live in the `Contracts` project of the sending service. A service that receives the message references that `Contracts` project.
- **Naming.** By convention the queue, topic and subject use the message type name. The developer can override the name.
- **Message properties.** An abstract base class holds the properties the module needs. It is used in the `Contracts` project of the sending service to declare the message types.
- **Delivery guarantees.** This module is about sending, so it only looks at the outbox pattern.
- **Failures.** A message that keeps failing goes to the dead letter queue. By convention the defaults of Azure Service Bus apply, and the developer can override them in the configuration of the service. Looking at the dead letter queue is the job of who runs the service.
- **Dead letter visibility.** For developers who use Aspire it would be handy to see the dead letters on the Aspire dashboard. See Question 8.
- **Ordering and sessions.** The defaults of Azure Service Bus apply. Sessions are off by convention, and the developer can override that.
- **Open question order.** The check of the local emulator happens as soon as this module has no other open questions.

#### Can the module be built?
Not yet. The direction is clear, and most of it can start. Three open points block parts of it: the kinds of messages, the place of the outbox and the emulator check.

What can start after the answers on kinds and base class:
1. `Cat.Messaging.Abstractions`: the message base types, the publisher and sender interfaces and the handler interface, in the style of `Cat.Commands`. It targets `netstandard2.0`.
2. `Cat.Messaging`: the processor and the registration by scanning assemblies, with the decorators from `Cat.Decorators`.
3. `Cat.Messaging.AzureServiceBus`: sending, the topology at startup and the name convention with an override. It targets the latest stable .NET, because it uses the Azure SDK. Check this when the project is added.
4. The outbox projects, once their place is decided.

The consuming side is in [Cat.EventProcessor.md](Cat.EventProcessor.md). The first version of this module is not worth much without it, so they probably ship together. That is Question 10.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Do we split events and command messages? The owner asked for Claude's view. The view: separate them, but only at the type level, and keep one pipeline underneath.
- An **event** says something happened (`OrderPlaced`). Many services may listen, and the sender does not care if nobody does. That fits a **topic**, with a subscription per receiving service.
- A **command message** says do this (`ReserveStock`). One receiver must do it, and it must not get lost when the receiver is down. That fits a **queue**. A topic drops a message when no subscription exists, and a queue keeps it.
- Without a split the module cannot choose between a queue and a topic by convention. The developer would have to configure it for every message. The alternative is a topic for everything, and then a "command" with no subscription disappears.
- Cost of the split: two small base types, `CatEventMessage` and `CatCommandMessage`, and two send methods. The handler, the outbox, the serialization and the decorators stay the same for both.

Recommendation: split. It is the answer to "queue or topic" that follows from the decision to support both.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Do we keep `System.Text.Json` only, with a small seam inside the module? The repository was checked: `Cat.Api.Client`, `Cat.Api.Gateway` and the generated clients use `System.Text.Json`, and nothing uses Newtonsoft. So `System.Text.Json` is the standard already.
- Pros: part of .NET, fast, no extra package, source generators for trimming and AOT, and the same everywhere in the toolkit.
- Cons: stricter than Newtonsoft by default, so some contract shapes need attributes, such as polymorphism and private setters. It writes JSON only, so a binary format such as Protobuf or Avro does not fit.
- Would pluggable pay off? Only when a message must go to or come from a system that wants another format, or when a team has a rule for one. The cost is real: a serializer seam in every module that serializes, such as `Cat.Sagas` and `Cat.Caching`, and a test matrix. The owner said that if it is pluggable it must be everywhere.

Recommendation: not pluggable now. Messaging keeps one small internal seam for the serializer, with `System.Text.Json` behind it. The message carries a content type property, so a later change is possible without breaking old messages. Decide again when a real case asks for another format. The `Cat.Sagas` plan has the same question, see [Cat.Sagas.md](Cat.Sagas.md).
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Does the base class come with an `ICatMessage` interface? The base class lives in the `Contracts` project, so that project references the messaging abstractions. The readme wants `Contracts` to have almost no dependencies. An abstractions project is light and targets `netstandard2.0`, so it probably fits, but it is a dependency the owner accepts. An `ICatMessage` interface next to the base class lets a type that cannot inherit still be a message.

Recommendation: both.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Which properties does the base class hold? A first proposal: `MessageId` (Guid), `CorrelationId` (Guid) and `OccurredAt`. Nothing about the user or a token, because that is the job of the message headers, see [Cat.EventProcessor.md](Cat.EventProcessor.md).
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Must the correlation ID be a GUID, or is a string better? A GUID works, since Service Bus stores the correlation ID as a string. One thing to keep apart is the trace context. The Service Bus SDK already puts a `Diagnostic-Id` property on the message, and that is what continues the trace in the Aspire dashboard. The correlation ID is for own use, to follow a business flow in the logs across services. For an order, the order number may be easier to read in a log.

Recommendation: a GUID, created at the start of a flow and copied to every message that follows from it.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Does the outbox go in the first version, and where does it live? The outbox is a table in the service database. The sender writes a row in the same `SaveChanges` as the entities, and a background service sends the rows. That needs no transaction decorator, see the note in [Cat.EFCore.md](Cat.EFCore.md). The code needs EF Core, so the module cannot hold it in the abstractions project.

Proposal: `Cat.Messaging.Outbox` for the abstraction and the sender loop, and `Cat.Messaging.Outbox.EFCore` for the table and the writing. A developer who does not want an outbox leaves both out.

Recommendation: yes, in the first version, because without it the saga wait step has a hole, see [Cat.Sagas.md](Cat.Sagas.md).
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
Is creating the topology a setting that a team can turn off? The owner decided that queues and topics get created at startup. Two things to keep in mind. The identity of the service then needs the manage right on the namespace, and production setups often do not give that. And the Service Bus emulator may not allow creating entities at runtime. That was not checked. It is Question 9.

Recommendation: creating is a setting, on by default as decided, so a team can turn it off and create the entities with a script. A subscription belongs to the receiving service, so it is created by `Cat.EventProcessor` and the topic is created by the sender.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
Do we make dead letters visible, and when? The module must not reference Aspire. It could still publish a metric, for example the number of dead letters per queue or subscription, through `System.Diagnostics.Metrics` with the source name `Cat.Messaging`. The Aspire dashboard shows that metric without any Aspire code in the module, like the traces of the other modules. Cost: the sender needs a management client to ask for the counts, which needs the manage right again.

Recommendation: do it after the first version.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
What does the local emulator not support, and does that change the design? To check as soon as the other points are answered, as the owner said. Check at least: creating entities at runtime, topics with several subscriptions, dead letter queues and sessions.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Do `Cat.Messaging` and `Cat.EventProcessor` ship together, and are they one module with two packages or two modules?
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Do we publish from a command handler, from a service request handler or from an event subscriber? Which one is the preferred way?
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Which Azure Service Bus SDK version and features may we rely on, such as sessions and scheduled messages?
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
Is scheduled delivery through the bus ("deliver in 24 hours") in scope? It overlaps with `Cat.Scheduling`, see [Cat.Scheduling.md](Cat.Scheduling.md).
<!-- region end: Question 13-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->