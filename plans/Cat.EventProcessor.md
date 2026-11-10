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

# Plans for Cat.EventProcessor

Worker support that turns incoming messages into service requests.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Can the module be built?](#can-the-module-be-built)
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
| Mapping | The message type is the service request type. |
| Contract | The message becomes the service request itself. There is no mapping step. See the open point on how a message type can be a service request. |
| Registration | The user still creates an `EventProcessor` project in the service. In it the user declares the message types the service wants to receive, in a way like defining endpoints in an API or the routes of the API gateway. |
| Concurrency | By convention, with an override by the user. The defaults of Azure Service Bus apply. |
| Scope | One DI scope per message. |
| Duplicates | Handlers are idempotent. See the open point for users who cannot do that. |
| Shutdown | The listener finishes the messages that are running. This is a convention, and the user can override it. |
| Tracing | The trace of the sender continues, using the message properties. |
| Identity | It depends on the context of the sender. A message sent for a user carries the token of that user. A message sent without a user, such as one from the scheduler, carries the token of the sending system. Every system that sends messages without a user has its own token. |
| Failure | The developer is responsible, from the handler. See the open point on how that could look. |

### Open

- **How can a message type be a service request?** The handler interface requires it: `ICatServiceRequestHandler<TRequest>` has `where TRequest : class, ICatServiceRequest`. And the message type lives in the `Contracts` project of the sending service, see [Cat.Messaging.md](Cat.Messaging.md). So the message type must implement `ICatServiceRequest` and the messaging base type together. Three ways:
  - **A. The message type implements both.** The `Contracts` project of the sender references `Cat.Messaging.Abstractions` and `Cat.ServiceRequests.Abstractions`. Both are small and target `netstandard2.0`. Every receiving service writes its own `ICatServiceRequestHandler<OrderPlaced>`, and an event with several receivers works, because every service has its own handlers. Cost: the sender's contract carries an interface that only the receivers use.
  - **B. A bridge project.** An optional project, such as `Cat.EventProcessor.Abstractions` or `Cat.Messaging.ServiceRequests`, holds ready base types that do both, such as `CatEventServiceRequest`. Cost: one more project, and the same references as A for the user of it.
  - **C. A wrapper.** The listener wraps the message in a generic request, `MessageRequest<TMessage>`. The contract stays clean. Cost: it is not what you answered. The handler receives a wrapper and not the message type.
  - **Recommendation.** A, with B as a convenience later. It follows your answer, and it keeps one handler type. Neither module forces the other, because the interface sits on the type the user writes. If you prefer a clean contract, C is the alternative.
- **Failure.** You said it is the job of the handler. The handler can only say it with the response it returns, so a proposal for how the listener turns a response into an action on the message:

  | The handler returns | What the listener does | Why |
  |---|---|---|
  | Succeeded | Completes the message. | Done. |
  | `BadRequest`, `NotFound`, `Conflict`, `Forbidden` or `Unauthorized` | Dead letters it at once, with the error codes as the reason. | Trying again gives the same answer. |
  | `InternalServerError`, or an exception | Abandons it, so the bus delivers it again. After the maximum number of deliveries the bus dead letters it. | The cause may go away, such as a database that is down for a moment. |

  Two ways for the handler to change this: a setting per message type in the registration of the `EventProcessor` project, such as "a `NotFound` completes the message", or a response type that says what is meant. The first needs no change in `Cat.Responses`. Recommendation: the table as the default, and the override in the registration, so the choice sits in the one place where the message types are declared. Cost: the user must know the table.
- **Retries.** Who retries, the bus or the module? My suggestion: the bus, and the module adds no retry loop of its own in the first version. Azure Service Bus redelivers an abandoned message up to its maximum delivery count, which is 10 by default (to check), and then dead letters it. The user can change the count in the configuration of the service, as decided for the failures in the messaging plan. Two retry layers multiply, as the plan of [Cat.Resilience.md](Cat.Resilience.md) says about HTTP. One cost: the bus redelivers at once and with no delay by default, so a failing dependency gets hit ten times in a second. Waiting between tries needs a delay, which can come later, for example by resending the message with a scheduled time.
- **Duplicates, for handlers that cannot be idempotent.** What to foresee:
  - **The sender side.** The sender sets the `MessageId`, and Azure Service Bus can drop a repeated message with the same ID inside a time window. That removes the duplicates of the outbox sending a row twice. It is a setting on the queue or topic, so it belongs in the topology of `Cat.Messaging`.
  - **An inbox.** An optional project that stores the IDs of the handled messages in the service database. The ID is saved in the same `SaveChanges` as the work of the handler, so a repeated message hits a unique key and is skipped. It needs EF Core, like the outbox, so it is a separate project that a user can leave out.
  - **Recommendation.** Idempotent handlers as the rule, the setting on the sender side as the default, and the inbox only when a team asks for it.
- **Hosting inside.** You answered how the user declares the messages. My question was only about the inside: one `IHostedService` per subscription, or one for all. The user does not see it. Recommendation: one hosted service that starts one Azure Service Bus processor per declared message type, and stops them together.
- **Health.** What I meant: a health check tells the platform (Azure Container Apps, Aspire, a probe) whether the service is fine. Today the check of `ServiceDefaults` only says the process runs. A listener can stop because of a fatal error, such as a lost connection, a deleted queue or a missing permission, while the API still answers. Nobody notices, and messages pile up. A health check of the module could say unhealthy when a processor has stopped, and degraded while it restarts. Recommendation: yes, as an optional `IHealthCheck` the user adds. Cost: a reference to the health checks package.
- **The token in the message.** It is decided that the token travels with the message. Things to settle:
  - **Expiry.** A message can wait longer than the life of a token. A listener that checks the lifetime would reject it. Recommendation: check the signature, the issuer and the audience, and skip the lifetime check, because the message waits. Check with how the gateway validates tokens.
  - **Where a token rests.** The token sits in the queue, in the dead letter queue and in the outbox table of the sender. Anyone who reads those can read a token. Options: accept it, since it is short lived, or send only the claims of the user and trust the sender. The first is simpler. This is a security question for you to decide.
  - **Where the user comes from.** The listener builds the `ICatUser` of the request from the token. See [Cat.Authorization.md](Cat.Authorization.md), where the same question is open as "No user".
- **Competing consumers.** Several instances of the same service listen to the same subscription, and the bus gives a message to one of them. Is that a given? Recommendation: yes, the module must never assume one instance. It also means the order of messages is not guaranteed, unless sessions are on, and sessions are off by convention.
- **The development endpoint.** A generic one or one per message? Recommendation: one generic endpoint, such as `POST /dev/event-processor/{messageType}`, which takes the JSON of the message and runs it through the same pipeline as a real message, in debug mode only. A list of the declared message types helps the developer pick one.
- **Pause and stop.** Does the module need a way to pause or stop a listener while it runs? Recommendation: not in the first version.
- **Saga dispatcher.** Which parts belong here and which in `Cat.Sagas`? Recommendation: this module only does what is the same for every message: find the handler, run it and settle the message. The answer to a waiting workflow is a message, and so a service request. A handler from `Cat.Sagas` finds, locks, resumes and saves the instance. See [Cat.Sagas.md](Cat.Sagas.md).

## Can the module be built?

Not alone. It depends on `Cat.Messaging`, because it receives what that module defines: the message types, the serializer, the name convention, the topology and the Azure Service Bus project. The two ship together or this one follows.

Settled enough to start, once the messaging abstractions exist:

1. `Cat.EventProcessor`: the declaration of the message types, in the style of the endpoints of the API.
2. One hosted service with a processor per message type, one DI scope per message and the trace continued from the message.
3. The identity from the token of the message.
4. Convention plus override for the concurrency and for the shutdown.

Needs an answer first: how a message type becomes a service request, the failure table, and the token questions.

## Questions before building

1. Do we build this together with `Cat.Messaging`, and is it one module with two packages or two modules? This is the same question as in the messaging plan.
2. How does a message type implement `ICatServiceRequest`: both interfaces on the type, a bridge project or a wrapper?
3. Is the table for a failed response a good default, with an override in the registration?
4. Does the bus alone retry, with the default count and no delay in the first version?
5. Is "idempotent handlers, the sender setting and an optional inbox" enough for duplicates?
6. Do we add a health check, as an option?
7. How do we treat the token in a message: skip the lifetime check, and accept that a token rests in the queue?
8. Is a generic development endpoint right?
9. Is the split with `Cat.Sagas` right: this module settles messages, the saga handler resumes the workflow?
10. Is a competing consumer setup a given?
