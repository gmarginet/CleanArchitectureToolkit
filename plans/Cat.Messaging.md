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
The culture of the sender travels with a message, so a handler works in the language of the user who started the work. For example, Notifications builds the order confirmed mail in Dutch for a user who ordered in Dutch.

#### What we want to build
- `Cat.Messaging` puts the culture of the sender on every message it sends, as a message property.
- The listener of `Cat.EventProcessor` reads the property and sets the culture for the handler, when the receiving service turns it on. This phase changes `Cat.EventProcessor` too.
- The module readmes of `Cat.Messaging` and `Cat.EventProcessor` explain it.

#### Background
- A message carries a `CorrelationId` on `ICatMessage`. `CatMessageSenderBase` copies it to `CatOutgoingMessage`, and the listener of `Cat.EventProcessor` adds it to the log scope of the handling.
- `CatOutgoingMessage` and `CatIncomingMessage` have a `Properties` dictionary. The sender puts the token of the caller in it under the key `CatMessageProperties.Authorization`, and the Azure Service Bus mappers copy every property to and from the application properties.
- The outbox stores the properties with the message, in `PropertiesJson` of `Cat.Outbox.EFCore`. A message through the outbox keeps its culture without a change in `Cat.Outbox`.
- `IStringLocalizer` reads `CultureInfo.CurrentUICulture`, see [Cat.Localizations.md](Cat.Localizations.md#phase-1).
- The toolkit is in alpha and the demo is the only user, so a breaking change is allowed (owner, 2026-11-21).

#### Decided
- **The culture is a message property.** `Cat.Messaging` carries the culture of the sender, like the `CorrelationId`, and the listener of `Cat.EventProcessor` sets `CurrentUICulture` for the handler. A developer gets it without `Cat.Localizations` (owner, 2026-11-21).
- **The plan lives here.** The property is useful for a developer who skips `Cat.Localizations`, so it belongs to the messaging modules (owner, 2026-11-21).
- **The sender takes `CultureInfo.CurrentUICulture` at the moment of the send.** It writes it to the properties of the message, under a key in `CatMessageProperties` next to `Authorization`. `ICatMessage` gets no new property. A message sent from a request gets the culture of the request, a message sent from a handler gets the culture the listener set, and a message sent from a job gets the default culture of `Program.cs`. A mail to another user in their own language needs a stored preference per user, which is outside this plan (owner, 2026-11-21).
- **The listener sets `CurrentUICulture` and `CurrentCulture`,** as ASP.NET Core request localization does. A handler then formats numbers and dates the way the request that started the work did, such as `12,50` for `nl-BE`. Code that passes `CultureInfo.InvariantCulture`, as `OrderConfirmedMailBuilder` does, is not affected (owner, 2026-11-21).
- **The sender always sends, the receiver opts in.** `Cat.Messaging` puts the culture on every message, with no setting. The listener applies it only when the receiving service turns it on, with one option when it registers `Cat.EventProcessor`. The receiving service is the one whose formatting changes, so it decides. Without the option, or for a message without the property, the handler runs on the default culture of its service. Demo Notifications turns it on (owner, 2026-11-21).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->

<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->
