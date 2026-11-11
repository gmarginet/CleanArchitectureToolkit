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

# Plans for `Cat.EventProcessor` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![READY TO START BUILDING](https://img.shields.io/badge/Status-READY%20TO%20START%20BUILDING-green)](#plans-for-cateventprocessor)
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
A new module, `Cat.EventProcessor`, with worker support that turns incoming messages into service requests.

#### The idea
Not all work comes in over HTTP. A message on Azure Service Bus is work that starts on its own. The service project structure has a place for it: the optional `ServiceName.EventProcessor` project.

`Cat.EventProcessor` is the code behind that project. It listens to the bus. Every incoming message becomes a service request that the core handles. The worker holds no business logic.

#### Background
From the readme:
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

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- The demo has no message listener. The Orders `DevelopmentEndpoints` has a group for the Scheduler, `/development/scheduler`. It has no group for an event processor.
- The service request handler interfaces and the logging, validation and tracing decorators of `Cat.ServiceRequests` exist.
- `Cat.Responses` has the outcomes the failure table uses: `BadRequest`, `NotFound`, `Conflict`, `Forbidden`, `Unauthorized` and `InternalServerError`.
- `Cat.Messaging` exists, see [Cat.Messaging.md](Cat.Messaging.md). This module depends on it for the message types, the serializer, the name convention and the topology. It has the sending side only, so a processor must be added here.

#### Decided
- **Hosting.** A worker that runs inside the API of the service.
- **Work.** One incoming message becomes one service request.
- **Business logic.** None in the worker.
- **Testing.** A development endpoint simulates a message, in debug mode only.
- **Mapping.** The message type is the service request type.
- **Contract.** The message becomes the service request itself. There is no mapping step. The message type implements `ICatServiceRequest` and the messaging base type together. The `Contracts` project of the sender references `Cat.Messaging.Abstractions` and `Cat.ServiceRequests.Abstractions`, and every receiving service writes its own `ICatServiceRequestHandler` for the message type.
- **Registration.** The developer still creates an `EventProcessor` project in the service. In it the developer declares the message types the service wants to receive, in a way like defining endpoints in an API or the routes of the API gateway.
- **Configuration.** The module works like the API gateway. The API project of the service calls extension methods: an `Add` method that registers the processors and the settings, and a `Map` method for the development endpoint in debug mode. The message types are declared in code. The settings per message type, such as concurrency, the maximum number of deliveries and the override of the failure table, can also be set in configuration, and the configuration wins.
- **Inside.** One hosted service that starts one Azure Service Bus processor per declared message type, and stops them together. The developer does not see it.
- **Token lifetime.** The listener checks the signature, the issuer and the audience, and that the token was valid when the bus received the message. The bus sets the arrival time itself, so the sender cannot fake it. Which time the bus sets for a message with a `scheduledAt` is still to check. The rules follow the API gateway, which is also still to check.
- **Token at rest.** The token stays in the message, so it is in the queue, the dead letter queue and the outbox table. The risk is kept small with short lived tokens, the lifetime check above, no message bodies in the logs and small rights on the queues. These rules go in the readme of the module. That the bus encrypts the data at rest is still to check. A person who knows security looks at the result before the module is used in production.
- **User.** The listener builds the `ICatUser` of the request from the token. This is open in [Cat.Authorization.md](Cat.Authorization.md) as "No user".
- **Concurrency.** By convention, with an override by the developer. The defaults of Azure Service Bus apply.
- **Scope.** One DI scope per message.
- **Duplicates.** Handlers are idempotent. The sender sets the `MessageId`, and the duplicate detection of the queue or topic drops a repeated message, which belongs in the topology of `Cat.Messaging`. For handlers that cannot be idempotent there is an optional inbox project in the first phase, like the outbox. It stores the IDs of the handled messages in the service database, in the same `SaveChanges` as the work of the handler, so a repeated message hits a unique key and is skipped. It needs EF Core, so a developer can leave it out.
- **Shutdown.** The listener finishes the messages that are running. This is a convention, and the developer can override it.
- **Tracing.** The trace of the sender continues, using the message properties.
- **Identity.** It depends on the context of the sender. A message sent for a user carries the token of that user. A message sent without a user, such as one from the scheduler, carries the token of the sending system. Every system that sends messages without a user has its own token.
- **Failure.** The developer is responsible, from the handler. The listener turns the response into an action on the message with a table. A succeeded response completes the message. `BadRequest`, `NotFound`, `Conflict`, `Forbidden` and `Unauthorized` dead letter it at once, with the error codes as the reason. `InternalServerError` or an exception abandons it, so the bus delivers it again and dead letters it after the maximum number of deliveries. The developer can override the table per message type in the registration of the `EventProcessor` project.
- **Retry.** The bus alone retries, with its default count and no delay in the first version, and the module has no retry loop of its own. The owner remembers that a delay between deliveries is a setting of the queue or topic, set when it is created. That is still to check.
- **Health check.** An optional `IHealthCheck` that the developer adds. It says unhealthy when a processor has stopped, and degraded while it restarts.
- **Competing consumers.** A given. The module never assumes one instance. The order of messages is not guaranteed, unless sessions are on.
- **Development endpoint.** One generic endpoint, such as `POST /dev/event-processor/{messageType}`. It takes the JSON of the message and runs it through the same pipeline as a real message, in debug mode only. A list of the declared message types helps the developer pick one.
- **Pause and stop.** No way to pause or stop a listener while it runs in the first version.
- **Sagas.** This module does only what is the same for every message: find the handler, run it and settle the message. The answer to a waiting workflow is a message, so a service request. A handler from `Cat.Sagas` finds, locks, resumes and saves the instance, see [Cat.Sagas.md](Cat.Sagas.md).
- **Two modules.** `Cat.EventProcessor` and `Cat.Messaging` are two modules. For the demo they are built in one phase, and `Cat.Messaging` can be built independently of this module, see [Cat.Messaging.md](Cat.Messaging.md).

#### Can the module be built?
Yes, together with `Cat.Messaging`, which is built already. It depends on that module for the message types, the serializer, the name convention, the topology and the Azure Service Bus project.

What can be built:
1. `Cat.EventProcessor`: the declaration of the message types, in the style of the endpoints of the API.
2. One hosted service with a processor per message type, one DI scope per message and the trace continued from the message.
3. The identity from the token of the message.
4. Convention plus override for the concurrency and for the shutdown.
5. The failure table, the optional health check and the development endpoint.
6. The optional inbox project for EF Core.

Still to check while building: which arrival time the bus sets for a scheduled message, how the API gateway validates tokens, whether the bus encrypts data at rest, and whether a delay between redeliveries is a setting of the queue or topic. The user behind a token (ICatUser) is an open question in [Cat.Authorization.md](Cat.Authorization.md).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->