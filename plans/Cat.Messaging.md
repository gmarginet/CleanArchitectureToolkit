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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Plans for Cat.Messaging

Publish and consume messages on Azure Service Bus with the same handler style as the other modules.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Services in the application architecture talk in two ways. A direct call goes through the API gateway. A message goes over Azure Service Bus. The architecture says to prefer messages, because they keep services loosely coupled.

Today the modules have nothing for the message side. `Cat.Messaging` fills that gap. A service publishes a message when something important happened, like `OrderPlaced`. Other services subscribe and react in their own time.

The module should feel like `Cat.Commands` and `Cat.Queries`: a message is a plain type, a handler handles it, a processor finds the handler, and decorators wrap it.

## What we already know

From the root readme:

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

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Transport | Azure Service Bus. |
| Style | The same handler, processor and decorator style as the other modules. |
| Demo hosting | The Service Bus emulator, started by the AppHost. |
| Aspire | The module never references Aspire. |
| Wait step | `Cat.Sagas` goes through the messaging abstractions, not through `Cat.EventAggregators`. |

### Open

- **Provider abstraction.** Is the module Azure Service Bus only, or does it hide the transport behind interfaces so another broker could follow?
- **Topology.** Queues, topics with subscriptions, or both? Who creates them: the AppHost, an admin script or the module at startup?
- **Message kinds.** Do we separate an event (something happened, many receivers) from a command message (do this, one receiver)?
- **Contracts.** Where do message types live? In the `Contracts` project of the sending service, in a shared project, or in a copy that the receiver owns? Sharing is the choice of the developer, as the root readme says, so the module should not force one.
- **Serialization.** `System.Text.Json` only, or pluggable?
- **Naming and routing.** How does a message type map to a topic or queue name and to subject, properties and a correlation id?
- **Delivery guarantees.** Service Bus delivers at least once. Does the module give an inbox for duplicate messages and an outbox for the send, or leave that to the transaction part of `Cat.EFCore`?
- **Failures.** What happens to a message that keeps failing? Dead letter after how many tries? Who looks at the dead letter queue?
- **Ordering and sessions.** Do we need ordered delivery or sessions in the first version?
- **Local emulator.** What does the emulator not support, and does that change the design? To check before the build.

## Questions before building

1. Is Azure Service Bus the only transport we want, now and later?
2. Should `Cat.Messaging` and `Cat.EventProcessor` be one module with two packages, or two modules?
3. Where do message contracts live by default, and does the module support both sharing them and copying them?
4. Do we want an outbox and an inbox in this module, or in `Cat.EFCore`?
5. How should a failed message end: retry, dead letter, or a failed `ICatResponse` that the handler decides on?
6. Do we publish from a command handler, from a service request handler or from an event subscriber? Which one is the preferred way?
7. Who creates topics and subscriptions in the demo and in production?
8. Which Azure Service Bus SDK version and features may we rely on, such as sessions and scheduled messages?
9. Is scheduled delivery through the bus ("deliver in 24 hours") in scope? It overlaps with `Cat.Scheduling`.
10. Should the first version ship before or together with `Cat.EventProcessor`?
