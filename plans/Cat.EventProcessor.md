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
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-cateventprocessor)
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
Remove old rows from the inbox, so the table does not grow forever.

#### What exists today
- The inbox lives in this module. `ICatInboxStore` is in `Cat.EventProcessor.Abstractions`, and the table and the store for EF Core are in `Cat.EventProcessor.Inbox.EFCore`.
- A row holds `MessageId` (the key), `MessageType` and `HandledAt`. The receiver adds one row for every message of a type that has `UseInbox` on.
- Nothing removes a row. There is no cleanup, no retention setting and no purge method, in the code or in the docs.
- `Cat.Sagas` uses the inbox for the answers of a saga, so a service with a saga gets one row per answer.
- A row is only needed as long as the bus can still deliver the same message again. The Service Bus keeps a message for its time to live, and a message that fails too often goes to the dead letter queue.
- The same gap exists in the outbox of `Cat.Messaging`, see [Cat.Messaging.md](Cat.Messaging.md).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
How does a developer clean the inbox? The options:
- **Document only.** The module readme says the table grows and the developer deletes old rows with their own job. Cost: nothing to build, but every developer writes the same job.
- **A cleanup method on the store.** `ICatInboxStore` gets a method that deletes the rows older than a given time. The developer calls it from their own job. Cost: a new member on the interface, a small change for a custom store, and the developer still schedules the call.
- **A retention setting with a cleanup service.** The module deletes old rows by itself, with a setting like `InboxRetention`. Cost: a background service in the module, or an optional extra project, and a default that fits nobody exactly.

Recommendation: the cleanup method on the store, plus a readme chapter that explains how long a row must live. It solves the problem and forces no other module on the developer, since a module never forces another one. An optional extra project that calls it on a schedule through `Cat.Scheduling` can come later.
<!-- region end: Question 1-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->
