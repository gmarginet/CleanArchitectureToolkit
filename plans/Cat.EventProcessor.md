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
<!-- region end: Phases-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
Finish `Cat.EventProcessor`: the identity from the token of the message, and the checks against a real bus.

#### What exists today
Phase 1 is built. The module readme `modules/Cat.EventProcessor/README.md` holds how it works: the message types as service requests, the listener, the failure table, the development endpoint, the health check and the inbox. This phase holds only what is left.

#### Decided
- **Token lifetime.** The listener checks the signature, the issuer and the audience, and that the token was valid when the bus received the message. The bus sets the arrival time itself, so the sender cannot fake it. Which time the bus sets for a message with a `scheduledAt` is still to check. The rules follow the API gateway, which is also still to check.
- **Token at rest.** The token stays in the message, so it is in the queue, the dead letter queue and the outbox table. The risk is kept small with short lived tokens, the lifetime check above, no message bodies in the logs and small rights on the queues. These rules go in the readme of the module. That the bus encrypts the data at rest is still to check. A person who knows security looks at the result before the module is used in production.
- **User.** The listener builds the `ICatUser` of the request from the token. This is open in [Cat.Authorization.md](Cat.Authorization.md) as "No user".
- **Identity.** It depends on the context of the sender. A message sent for a user carries the token of that user. A message sent without a user, such as one from the scheduler, carries the token of the sending system. Every system that sends messages without a user has its own token.

#### What is not built
- **Identity from the token.** `ICatUser` and `Cat.Authorization` do not exist, and `Cat.Messaging` does not attach a token to a message yet. A handler that runs for a message has no current user. The readme of the module says so.
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