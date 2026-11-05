# Plans for Cat.EventProcessor

Worker support that turns incoming messages into service requests.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Not all work comes in over HTTP. A message on Azure Service Bus is work that starts on its own. The service project structure has a place for it: the optional `ServiceName.EventProcessor` project.

`Cat.EventProcessor` is the code behind that project. It listens to the bus. Every incoming message becomes a service request that the core handles. The worker holds no business logic.

## What we already know

From the root readme:

- The event processor is a worker, not a host. It has no executable. It lives in its own project and runs inside the API.
- It listens to Azure Service Bus. Every incoming message triggers a service request.
- It is optional. A service adds it only when it needs it.
- Like the API, it contains no business logic. Every unit of work becomes a service request.
- In debug mode the API has a development endpoint group, with a sub group per worker. The event processor endpoint simulates an incoming message, and the service handles it as if the worker had received it.

From the demo plan:

- Inventory and Notifications consume `OrderPlaced`.
- The Orders `Api` project has a development group for the Scheduler today. A group for the event processor follows the same pattern.

From the saga plan:

- Answers to a waiting workflow come in through this module. A message finds the stored instance, loads it and runs it on.
- Handling is at least once, so a message can arrive twice. Two messages for the same instance can arrive at the same moment.

From the module conventions:

- The service request is the unit of work. Contracts hold the request types, and the core holds the handlers.
- Decorators from `Cat.ServiceRequests` already give logging, validation and tracing. The worker should reuse them and not add its own.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Hosting | A worker that runs inside the API of the service. |
| Work | One incoming message becomes one service request. |
| Business logic | None in the worker. |
| Testing | A development endpoint simulates a message, in debug mode only. |

### Open

- **Mapping.** How does a message type map to a service request type? A convention, a registration call, an attribute or a handler per message type?
- **Contract.** Does the message become the service request itself, or does a small mapping turn the message into a request?
- **Failure.** A failed `ICatResponse` means what for the message: abandon and retry, dead letter, or complete anyway? Can the request say which?
- **Retries.** Who decides how often a message is retried, the bus or the module?
- **Concurrency.** How many messages run at the same time per subscription? Is it configurable per message type?
- **Scope.** One DI scope per message, like one per HTTP request. Presumably yes, to confirm.
- **Duplicates.** Does the module remember handled message ids, or does every handler have to be idempotent?
- **Hosting.** An `IHostedService` per subscription, or one service for all?
- **Shutdown.** Finish the running messages on shutdown. How long do we wait?
- **Health.** Does the listener report to the health checks?
- **Tracing.** Continue the trace of the sender from the message properties.
- **Identity.** A message has no user. What does `ICatUser` return for work started by a message? A system user, like the client credentials token the demo plan mentions for the Scheduler?

## Questions before building

1. Do we build this together with `Cat.Messaging` or after it?
2. How should a message find its service request: by convention, by registration or by attribute?
3. What should a failed response do to the message? Is "retry a few times, then dead letter" a good default?
4. Do we want built-in duplicate detection, or do we tell handlers to be idempotent?
5. Who is the current user when a message starts the work?
6. Should one service be able to run more than one listener, for example for different topics?
7. Is a competing consumer setup (several instances of the same service) a given? That affects ordering.
8. What does the development endpoint look like? A generic one for any message type, or one per message?
9. Does the module need a way to pause or stop a listener at runtime?
10. Which parts of the saga dispatcher (find, lock, resume, save) belong here and which in `Cat.Sagas`?
