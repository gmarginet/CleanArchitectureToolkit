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

# Plans for `Cat.Sql.Cdc` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![READY TO START BUILDING](https://img.shields.io/badge/Status-READY%20TO%20START%20BUILDING-green)](#plans-for-catsqlcdc)
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

From the dropped `Cat.Auditing` plan:
- Temporal tables answer "what was the price then" but not "who changed it". CDC has the same limit, since it does not record the user.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- Nothing in the code or the demo uses CDC. No other readme or plan mentions it.
- `Cat.Messaging` and `Cat.EventProcessor` exist now.
- The demo has two possible tables for a showcase. Catalog keeps the price history in a temporal table (`BookPrice`). Inventory has its own database project with SQL scripts.

#### Decided
- **Name.** The module is called `Cat.Sql.Cdc`.
- **Purpose.** The module translates SQL CDC changes to a service bus call.
- **Documentation.** The module readme links to the Microsoft page about change data capture.
- **Messaging.** The module does not depend on `Cat.Messaging`. `Cat.Sql.Cdc.Abstractions` holds an abstraction for "send this change" (`ICatChangeSink`), and a bridge project `Cat.Sql.Cdc.Messaging` sends through `Cat.Messaging`.
- **Reading.** The module polls the CDC functions itself, with no library. Check once whether a maintained library exists before the build starts.
- **Position.** The last LSN is stored in a small table in the captured database, in a schema of the module, written after the changes were handed to the sink. The guarantee is at least once delivery.
- **Duplicates.** The module does not remove duplicates. The developer chooses: an idempotent receiver, or an inbox, the same choice as in `Cat.Messaging`.
- **Mapping a table to a message.** Code configuration in the registration, such as `AddCdcTable<BookPrice, BookPriceChanged>()`. No attributes and no naming convention.
- **Message types.** They live in the `Contracts` project of the service that owns the database, as decided for all messages.
- **Enabling CDC.** The developer owns the script that runs `sys.sp_cdc_enable_table`. The module readme has a ready script as a sample. The module never enables CDC at startup.
- **Retention gaps.** A setting with two choices, fail loudly or skip to the oldest available change with a warning. Fail loudly is the default, an error, a metric and an unhealthy state.
- **Hosting.** A hosted service inside the API, set up the same way as the event processor and the scheduler: the module has extension methods that the API project calls to register the captured tables and do the configuration. "Add tables" means registering which CDC tables are captured and which message each one becomes, not creating tables in the database.
- **One reader.** Each module has its own claim so only one instance reads. The reader's claim is a row in its own LSN table. No shared claim project for now, see [Cat.Scheduling.md](Cat.Scheduling.md).
- **Message id.** The LSN, with the operation and the position in the transaction, is always the `MessageId`. Both choices of the developer need a stable id, and the bus can drop a repeat inside its window.
- **Message shape.** A type that the developer maps to, with a dictionary of column names as the default when no mapping is given. The transaction id stays in the message, because the per row choice loses the grouping otherwise.
- **Auditing.** `Cat.Auditing` is dropped, so the module has no link with an audit trail.
- **Granularity.** One message per row change.
- **Values.** An update carries the key and both the old and new values. An insert or a delete carries the key and the values.
- **Demo.** The Inventory stock table, as "tell Orders or Notifications when stock is low". Check this against [Demo.md](Demo.md) when the module gets close.
- **Databases.** SQL Server only. Another database gets its own module.
- **Order of work.** After `Cat.Messaging` and `Cat.EventProcessor`. It is the lowest priority of the modules in the repo overview.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->