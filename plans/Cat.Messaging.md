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

<!-- region start: FirstStableVersion-->
**First stable version:** not reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 1](#phase-1)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
A sender can ask for the system token for a message that is not scheduled. An entrance without a user, such as a webhook of a payment provider, can then hand its work off as a message.

#### The idea
A webhook arrives without a user. The endpoint checks the signature and wants to put the work on a queue, so it can answer the provider at once. Today that message goes out without a token, and a receiver with a policy that needs a login dead letters it.

#### Background
From the code and the module readmes:
- `CatMessageSender` asks `ICatTokenProvider` for `CatTokenSubject.System` only when the message has a scheduled time. Every other message asks for `CatTokenSubject.CurrentUser`.
- `ICatMessageSender` has `SendAsync` and `PublishAsync`, each with the message, an optional scheduled time and a cancellation token. The sender cannot choose the token.
- A message without a token runs as the anonymous user at the receiver, so a policy that needs a login denies it. See the [module readme of Cat.EventProcessor](../modules/Cat.EventProcessor/README.md).
- The receiver checks a normal message against the time the bus received it, and skips the lifetime check only for a scheduled message. A system token on a message that is not scheduled gets the normal check.

From the demo plan:
- The demo has no webhook. The payment provider answers in the call itself, see [Demo.md](Demo.md#phase-17). This phase makes a webhook possible for a developer, and the demo does not show it.

#### What exists today
- The token of a message comes from `ICatTokenProvider`, with the subject that `CatMessageSender` picks.
- The toolkit is in alpha and the demo is the only user, so a breaking change is allowed. The first stable version is not reached (owner, 2026-11-21).

#### Decided
- **Close the gap.** The modules get what a webhook needs, so a developer can hand a webhook off as a message (owner, 2026-11-20).
- **No default.** Running as the system is never a default. The sender asks for it on purpose (owner, from the authorization design of 2026-11-13).
- **A separate interface.** `ICatSystemMessageSender`, with `SendAsync` and `PublishAsync` like `ICatMessageSender`, always asks for `CatTokenSubject.System`. It is registered next to `ICatMessageSender`. Only the code that injects it can send as the system, so a handler that runs for a user cannot do it by accident, and a search for the type finds every place that does. `ICatMessageSender` stays as it is (owner, 2026-11-21).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->
