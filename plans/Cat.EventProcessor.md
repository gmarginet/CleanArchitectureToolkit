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
- [Phase 3](#phase-3)
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
- **Token lifetime.** The listener checks the signature, the issuer and the audience, and that the token was valid when the bus received the message. The bus sets the arrival time itself, so the sender cannot fake it. Which time the bus sets for a message with a `scheduledAt` is still to check. The rules follow the API gateway, which is also still to check.
- **Token at rest.** The token stays in the message, so it is in the queue, the dead letter queue and the outbox table. The risk is kept small with short lived tokens, the lifetime check above, no message bodies in the logs and small rights on the queues. These rules go in the readme of the module. That the bus encrypts the data at rest is still to check. A person who knows security looks at the result before the module is used in production.
- **User.** The listener builds the `ICatUser` of the request from the token. This is open in [Cat.Users.md](Cat.Users.md) as "No user".
- **Identity.** It depends on the context of the sender. A message sent for a user carries the token of that user. A message sent without a user, such as one from the scheduler, carries the token of the sending system. Every system that sends messages without a user has its own token.

#### What is not built
- **Identity from the token.** `ICatUser` and `Cat.Users` do not exist, and `Cat.Messaging` does not attach a token to a message yet. A handler that runs for a message has no current user. The readme of the module says so.
- **Tests against a real bus.** The listener host and the development endpoint have no tests of their own. The emulator tests of the Azure project are in `tests/Cat.Messaging.Tests/EmulatorTests.cs`, see the module readme of `Cat.Messaging`. The demo already runs `OrderConfirmed` through the emulator, but that was checked by hand.

#### Still to check
- Which arrival time the bus sets for a scheduled message.
- How the API gateway validates tokens.
- Whether the bus encrypts data at rest.
- `MaxConcurrentCalls` is the number of sessions at the same time for a message type that needs sessions. Check that this fits what a developer expects.
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
- **Inline rule.** Besides the policy name, a message type can state a simple rule inline, such as `options.RequireRole("admin")`, so a developer does not have to define a policy by name first. It uses `IAuthorizationService` behind the scenes, so there is still one policy system. The owner chose to build it.
- **Contract.** `Cat.EventProcessor.Abstractions` holds a small contract that the receiver calls before the handler runs.
- **Optional project.** An optional project implements the contract with `IAuthorizationService`. A developer who does not use it pulls in nothing. A message type with a policy and no implementation fails at startup, as for the inbox. It is a project of this module, such as `Cat.EventProcessor.Authorization`, next to the inbox project. The owner decided this in [Cat.Users.md](Cat.Users.md).
- **Entrances without a rule.** The listener logs the message types without a policy at startup, and a setting makes the receiver deny them. The setting is off by default, so existing services keep working. The owner decided this in [Cat.Users.md](Cat.Users.md). The receiver does not retry a message that fails the check. It dead letters the message, because retrying gives the same answer.
- **Needs Phase 2.** The token of the message and the identity built from it come from Phase 2.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Does the policy check run before or after the inbox check? The options:
- **Policy first.** A message that fails the check never gets a row in the inbox. Cost: the check runs again for every repeated message, and the check of a repeated message may fail even though the first one passed.
- **Inbox first.** A repeated message completes at once, without a check. Cost: a rejected message may get a row in the inbox, depending on when the row is saved.

Recommendation: policy first. A message that is not allowed must leave no trace in the inbox, and the extra check is cheap.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Which inline rules does the message setting offer? The owner chose to build the shortcut. The options:
- **A. Only a required role,** `RequireRole("admin")`. Cost: a rule on a claim still needs a named policy.
- **B. Role, claim and logged in,** `RequireRole`, `RequireClaim` and `RequireAuthenticatedUser`. Cost: more API to document and test.
- **C. A callback that builds the policy,** `options.Require(policy => policy.RequireRole("admin"))`, which takes the `AuthorizationPolicyBuilder` of ASP.NET Core. Cost: the options type depends on the ASP.NET Core policy builder.

Recommendation: C. It offers everything ASP.NET Core offers without a second API of our own. It needs the optional authorization project to hold the type, so the abstractions stay free of ASP.NET Core.
<!-- region end: Question 2-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 3-->
