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

<!-- region start: FirstStableVersion-->
**First stable version:** reached
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
Remove sent rows from the outbox, so the table does not grow forever.

#### What exists today
- The outbox lives in this module. `ICatOutboxStore` is in `Cat.Messaging.Outbox`, and the table and the store for EF Core are in `Cat.Messaging.Outbox.EFCore`.
- The sender sets `SentAt` on a row after the bus took the message. It never deletes the row. The store has `AddAsync`, `GetPendingAsync` and `MarkSentAsync`, and no cleanup.
- The table has an index on `SentAt` and `CreatedAt`, so a cleanup of sent rows can find them quickly.
- A row holds the whole message, with its body and the token of the message. That makes a kept row bigger than an inbox row, and the token stays in the table for as long as the row does.
- The same gap exists in the inbox of `Cat.EventProcessor`, see [Cat.EventProcessor.md](Cat.EventProcessor.md).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
How does a developer clean the outbox? The options:
- **Document only.** The module readme says the table grows and the developer deletes sent rows with their own job. Cost: nothing to build, but every developer writes the same job.
- **A cleanup method on the store.** `ICatOutboxStore` gets a method that deletes the sent rows older than a given time. The developer calls it from their own job. Cost: a new member on the interface, a small change for a custom store, and the developer still schedules the call.
- **Delete the row when it is sent.** `MarkSentAsync` removes the row instead of setting `SentAt`. Cost: no trace of what was sent, which hurts when someone looks for a lost message, and a breaking change of the table.
- **A retention setting for the background sender.** The sender removes old sent rows by itself, with a setting like `SentRetention`. Cost: more work in the sender and a default that fits nobody exactly.

Recommendation: the cleanup method on the store, with the same shape as the one planned for the inbox, see [Cat.EventProcessor.md](Cat.EventProcessor.md). A developer then learns one pattern for both tables. Keeping sent rows for a while is useful when a message goes missing, so deleting at once is the weaker choice.
<!-- region end: Question 1-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->
