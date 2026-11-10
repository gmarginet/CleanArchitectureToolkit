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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-plan skill to update this plan.-->
<!-- region end: TemplateSkill-->

# Plans for `Cat.Sql.Cdc` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catsqlcdc)
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
A new module, `Cat.Sql.Cdc`, that translates SQL Server change data capture (CDC) changes into calls on a service bus.

#### The idea
Some databases change without our code. Another system writes to them, or a script does. Nobody publishes a message when that happens.

`Cat.Sql.Cdc` reads the [change data capture](https://learn.microsoft.com/en-us/sql/relational-databases/track-changes/about-change-data-capture-sql-server?view=sql-server-ver17) tables of SQL Server. It turns each captured insert, update and delete into a call on a service bus. Other services can then react to the change.

It sits next to `Cat.Messaging`. That module sends the messages. This module finds out what changed.

#### Background
From Microsoft:
- CDC records insert, update and delete activity on a table.
- It reads the transaction log and writes the changes to change tables. Your own transactions are not slowed down by the capture.
- Each change carries a log sequence number (LSN), the operation and the column values.
- CDC is a SQL Server feature. Check the edition and agent requirements for the version we target.
- The change tables are cleaned up after a retention period, so a reader must keep up or remember its position.

From the readme:
- `Cat.Messaging` is the planned module that publishes and consumes messages on Azure Service Bus.
- `Cat.EventProcessor` is the planned worker support that turns incoming messages into service requests.

From the module conventions:
- A module splits into an `Abstractions` project, the implementation and optional parts.
- A module never forces another module on the developer.
- Modules never depend on Aspire or on the demo `ServiceDefaults`.
- Module projects target `netstandard2.0` as much as possible. A project that needs more targets the latest stable .NET.

From the `Cat.Auditing` plan:
- Temporal tables answer "what was the price then" but not "who changed it". CDC has the same limit, since it does not record the user.

#### What exists today
- The module does not exist yet. It is listed under the future modules in the readme.
- Nothing in the code or the demo uses CDC. No other readme or plan mentions it.
- `Cat.Messaging` and `Cat.EventProcessor` do not exist yet either.
- The demo has two possible tables for a showcase. Catalog keeps the price history in a temporal table (`BookPrice`). Inventory has its own database project with SQL scripts.

#### Decided
- **Name.** The module is called `Cat.Sql.Cdc`.
- **Purpose.** The module translates SQL CDC changes to a service bus call.
- **Documentation.** The module readme links to the Microsoft page about change data capture.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Does the module depend on `Cat.Messaging`, or does it only define an abstraction for "send this change" and leave the sending to a separate bridge project? The second keeps the toolbox rule, and costs one more project.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Does it run as a hosted service inside a service, or as a separate worker? A worker keeps the reading apart from the service. A hosted service is simpler to start.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
How does it read the changes? Poll the CDC functions on a timer, or use a library that wraps them? Polling is simple and needs no extra part. We could also check what exists before we write our own reader.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Where does the reader store the last LSN it handled? In a table in the same database, in the own database of the service, or elsewhere? This decides if a restart loses or repeats changes.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Who removes duplicates? CDC and the bus are two systems. The module gives at least once delivery unless it does more. Does the receiver remove duplicates, or an inbox in `Cat.Messaging`?
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
What does a message look like? One message per row change, or one per transaction? Does it carry the old and the new values, or only the new ones? Does it use the CDC column names, or a type the developer maps to?
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
How does a developer say "changes of table X become message Y"? Code configuration, attributes or a convention?
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
Where do the message types live? The readme says sharing a `Contracts` project is the choice of the developer.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Who runs `sys.sp_cdc_enable_table`: the module, a script or the developer? The demo applies SQL scripts at start, so a script may be enough.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
What does the reader do when it finds that the retention period removed changes it never saw?
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Which table in which demo service shows the module? Candidates are the price history in Catalog or the stock in Inventory. To check against [Demo.md](Demo.md).
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Do we need to support databases other than SQL Server? Is it SQL Server only, or an abstraction for other change feeds later? `Cat.EFCore` already ties the demo to SQL Server.
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
Does the audit trail of `Cat.Auditing` use this module, or stay apart?
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
Should the first version ship before or together with `Cat.Messaging`?
<!-- region end: Question 14-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->