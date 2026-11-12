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
[![NOT STARTED](https://img.shields.io/badge/Status-NOT%20STARTED-blue)](#plans-for-cateventprocessor)
<!-- region end: StatusBadge-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
- [Phase 2](#phase-2)
  - [Description](#description)
    - [Goal](#goal)
    - [What exists today](#what-exists-today)
    - [Decided](#decided)
    - [What is not built](#what-is-not-built)
    - [Still to check](#still-to-check)
  - [Open Questions](#open-questions)
- [Phase 3](#phase-3)
  - [Description](#description-1)
    - [Goal](#goal-1)
    - [What exists today](#what-exists-today-1)
    - [Decided](#decided-1)
  - [Open Questions](#open-questions-1)
<!-- region end: Phases-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
Finish `Cat.EventProcessor`: the identity from the token of the message, and the checks against a real bus.

#### What exists today
Phase 1 is built. The module readme `modules/Cat.EventProcessor/README.md` holds how it works: the message types as service requests, the listener, the failure table, the development endpoint, the health check and the inbox per message type. This phase holds only what is left.

#### Decided
- **Token lifetime.** The listener checks the signature, the issuer and the audience, and that the token was valid when the bus received the message. The bus sets the arrival time itself, so the sender cannot fake it. For a message with a `scheduledAt` the emulator sets the scheduled time, see "Scheduled messages". The gateway and the services validate the user token with the standard JWT bearer authentication, which checks the current time and allows a clock skew of 5 minutes by default. The rule of the receiver is a deliberate difference, because a message can be hours old when it is handled. The gateway assertion is a different check, for calls from the gateway only, and has no part in this.
- **Scheduled messages.** A message with a `scheduledAt` carries the token of the sending system, not of the user. It is work without a user, as in the identity rule below. The sender passes what the handler needs in the message, because the user is not known there. The owner decided this. The receiver skips the lifetime check for a message that has a scheduled time, because the token of the system is made when the message is sent and is expired at the scheduled time. It still checks the signature, the issuer and the audience. The cost is that a copied system token stays valid for scheduled messages as long as its signing key is valid. The owner decided this.
- **Token at rest.** The token stays in the message, so it is in the queue, the dead letter queue and the outbox table. The risk is kept small with short lived tokens, the lifetime check above, no message bodies in the logs and small rights on the queues. These rules go in the readme of the module. Azure Service Bus encrypts the data at rest with Microsoft-managed keys by default. Customer-managed keys are optional and need the Premium tier, Azure Key Vault and a namespace that is still empty. A person with receive rights on a queue still sees the token in clear, so the small rights stay important. A person who knows security looks at the result before the module is used in production.
- **User.** The receiver builds the `ICatUser` of the request from the token and sets it with `ICatUserAccessor` of `Cat.Users`. Work without a token runs as the anonymous user, see "Message without a token".
- **Identity.** It depends on the context of the sender. A message sent for a user carries the token of that user. A message sent without a user, such as one from the scheduler, carries the token of the sending system. Every system that sends messages without a user has its own token.
- **Token in the message.** The token travels in a message property named `Authorization`, with the value `Bearer <token>`, as in HTTP. It is not part of the message body, so the contracts stay clean. The receiver reads it from `CatIncomingMessage.Properties`.
- **Token on the sending side.** A small interface `ICatTokenProvider`, implemented by the host, gives the token. The sender calls it when it builds the message, and puts the result in the `Authorization` property. A host can read the header of the current request. A system sender, such as the scheduler, returns its own token from the same interface. `ICatUser` stays free of a token.
- **Message without a token.** The receiver runs it as the anonymous user, so a policy that needs a login denies it, and the setting for entrances without a rule of Phase 3 decides about message types without a policy. A token that fails the validation is dead lettered, as in the failure table.
- **Validation settings.** The receiver reuses the JWT bearer options of the service, the `TokenValidationParameters` of a named scheme (`Bearer` by default), so one setup serves both entrances. The optional project of this module depends on the JwtBearer package for this. A service that uses it registers the scheme, also when it has no HTTP authentication.
- **One optional project.** The receiving side lives in the optional authorization project of Phase 3, one project for the token, the user and the policy check. A developer who wants only the user still gets the policy code. The contract lives in the abstractions, so the project can be split later without a break.

#### What is not built
- **Identity from the token.** `Cat.Users` exists now, but `Cat.Messaging` does not attach a token to a message yet, and the receiver does not read one. A handler that runs for a message has no current user. The readme of the module says so.
- **Tests against a real bus.** The listener host and the development endpoint have no tests of their own. The emulator tests of the Azure project are in `tests/Cat.Messaging.Tests/EmulatorTests.cs`, see the module readme of `Cat.Messaging`. The demo already runs `OrderConfirmed` through the emulator, but that was checked by hand.

#### Still to check
- Which arrival time the real service sets for a scheduled message. The documentation does not say. The emulator test below shows the emulator behavior, and the real service must be checked once before production use, because it may differ. The rule for a scheduled message, see "Scheduled messages", does not depend on it.
- The encryption at rest of the documentation was not checked for changes since it was written, such as the Premium rule for customer-managed keys.

#### Checked
- Emulator, version 2.0.0, tested on 2026-11-12: a message that was sent at 23:43:58 with a scheduled time of 23:44:13 got `EnqueuedTime` 23:44:13.093. So the emulator sets the arrival time to the scheduled time, not to the send time.
- `MaxConcurrentCalls` is the number of sessions at the same time for a message type that needs sessions. The SDK default for the calls per session is 1, so the setting still means the number of messages at the same time. The default number of sessions of the SDK is 8. The module readme says that the setting counts sessions for a session type.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->

<!-- region start: Phase 3-->
## Phase 3

### Description
<!-- region start: PhaseDescription-->
#### Goal
Let a developer protect one message type with an authorization policy, at the entrance where the message is received.

#### What exists today
The receiver `CatMessageReceiver` opens one DI scope per message and handles the message in it. The settings of a message type live on `CatReceiveOptions`, set in code and overridable from the configuration. The inbox setting `UseInbox` works this way. The receiver builds no identity yet, see Phase 2.

#### Decided
The owner decided this in [Cat.Users.md](Cat.Users.md): authorization is done at the entrance of the service, and for a message that is the receiving side.
- **Policy system.** The module reuses the ASP.NET Core policy system, so one set of policies serves the endpoints and the messages. The receiver builds a `ClaimsPrincipal` from the token of the message and asks `IAuthorizationService` for the policy of the message type.
- **Per message type.** The policy name is a setting on `CatReceiveOptions`, set in code as `Receive<TMessage>(options => ...)`. The configuration of the service can change it, like the other settings.
- **Inline rule.** Besides the policy name, a message type can state a simple rule inline, such as a required role, so a developer does not have to define a policy by name first. It uses `IAuthorizationService` behind the scenes, so there is still one policy system. The owner chose to build it. The shortcut is one callback that takes the `AuthorizationPolicyBuilder` of ASP.NET Core, such as `options.Require(policy => policy.RequireRole("admin"))`, so every rule of ASP.NET Core works and we write no rule API of our own. The `Require` method is an extension method in the optional authorization project. `CatReceiveOptions` in the abstractions keeps the rules as a neutral list, so the abstractions stay free of ASP.NET Core.
- **Contract.** `Cat.EventProcessor.Abstractions` holds a small contract that the receiver calls before the handler runs.
- **Optional project.** An optional project implements the contract with `IAuthorizationService`. A developer who does not use it pulls in nothing. A message type with a policy and no implementation fails at startup, as for the inbox. It is a project of this module, such as `Cat.EventProcessor.Authorization`, next to the inbox project. The owner decided this in [Cat.Users.md](Cat.Users.md).
- **Entrances without a rule.** The listener logs the message types without a policy at startup, and a setting makes the receiver deny them. The setting is off by default, so existing services keep working. The owner decided this in [Cat.Users.md](Cat.Users.md). The receiver does not retry a message that fails the check. It dead letters the message, because retrying gives the same answer.
- **Policy before the inbox.** The policy check runs before the inbox check. A message that is not allowed leaves no trace in the inbox. The check runs again for a repeated message, which is cheap.
- **Needs Phase 2.** The token of the message and the identity built from it come from Phase 2.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 3-->
