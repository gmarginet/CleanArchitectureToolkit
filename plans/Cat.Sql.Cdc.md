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
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- Nothing in the code or the demo uses CDC. No other readme or plan mentions it.
- `Cat.Messaging` and `Cat.EventProcessor` exist now.
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
Does the module depend on `Cat.Messaging`, or does it only define an abstraction for "send this change" and leave the sending to a separate bridge project? The options:
- **Depend on `Cat.Messaging`.** Simple. Cost: a developer who wants the changes on another bus, or in a log, gets Service Bus whether they want it or not. This breaks the toolbox rule.
- **An abstraction in `Cat.Sql.Cdc.Abstractions`** (`ICatChangeSink`), and a bridge project `Cat.Sql.Cdc.Messaging` that sends through `Cat.Messaging`. Cost: one more project.

Recommendation: the abstraction and the bridge project. It follows the module rules (an `Abstractions` project and optional parts), and the bridge is small.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Does it run as a hosted service inside a service, or as a separate worker? The options:
- **A hosted service inside the service.** Simple to start, and it follows the worker idea of the readme (a worker inside the API). Cost: with several instances, every instance reads the same changes, so it needs a lock (see question 4).
- **A separate worker host.** The reading is apart from the service. Cost: an executable the readme does not have in its structure, and one more thing to deploy.

Recommendation: a hosted service inside the service, as the other workers do, and a claim in the database so only one instance reads. This is the same approach as question 4 in [Cat.Scheduling.md](Cat.Scheduling.md).
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
How does it read the changes? The options:
- **Poll the CDC functions** (the `cdc.fn_cdc_get_all_changes` functions) on a timer, with Dapper or plain ADO.NET. Cost: a delay of one poll interval, and a little database load.
- **A library that wraps CDC.** Cost: to be checked first (what exists, is it maintained, which licence), and it brings its own concepts.
- **Change Tracking or Debezium instead.** Cost: a different feature, or an external service to run, which is not what this module is about.

Recommendation: poll the CDC functions ourselves. It is a small amount of code, and no dependency is needed. Check once whether a maintained library exists before we start.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Where does the reader store the last LSN it handled? This decides if a restart loses or repeats changes. The options:
- **A table in the same database** as the captured tables. Cost: a table the module creates, but the position and the work are in one place.
- **In the own database of the service,** when that differs. Cost: two databases to keep consistent.
- **Not stored** (in memory). Cost: a restart repeats or loses changes.

Recommendation: a small table in the captured database, in a schema of the module, written after the changes were handed to the sink. This gives at least once delivery (question 5), which is the honest guarantee.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Who removes duplicates? CDC and the bus are two systems. The module gives at least once delivery unless it does more. The options:
- **The receiver is idempotent,** as the event processor plan says. Cost: the developer's job.
- **An inbox in `Cat.Messaging`.** Cost: not decided yet, see question 4 in [Cat.EventProcessor.md](Cat.EventProcessor.md).
- **The LSN as the message ID,** so the bus drops a repeat inside its window. Cost: only works inside the duplicate detection window.

Recommendation: the LSN (with the operation and the position in the transaction) as the `MessageId`, plus idempotent receivers. It needs no extra part.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
What does a message look like? The options for the three points:
- **Granularity:** one message per row change, or one per transaction. Per row is simple and what CDC gives. Per transaction keeps related changes together but needs more code. Recommendation: per row, with the transaction id in the message.
- **Values:** old and new, or only the new ones. Old and new is more useful (CDC can give it for updates with the right function) and costs more space. Recommendation: both for an update, and the key and values for an insert or delete.
- **Shape:** the CDC column names, or a type the developer maps to. Recommendation: a type the developer maps to, with a default of a dictionary of column names, so the contract is the developer's.
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
How does a developer say "changes of table X become message Y"? The options:
- **Code configuration,** such as `AddCdcTable<BookPrice, BookPriceChanged>()`. Cost: none.
- **Attributes on the entity or message.** Cost: the type depends on this module.
- **A convention** (table name equals message name). Cost: hidden rules.

Recommendation: code configuration in the registration. It matches the style of the other modules and keeps the types free of the module.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
Where do the message types live? The readme says sharing a `Contracts` project is the choice of the developer. The options:
- **In the `Contracts` project of the service that owns the database.** This is what [Cat.Messaging.md](Cat.Messaging.md) decided for messages. Cost: none.
- **In the project of the module registration.** Cost: other services cannot reference them without the service.

Recommendation: in the `Contracts` project of the service that owns the database, as decided for all messages.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Who runs `sys.sp_cdc_enable_table`: the module, a script or the developer? The demo applies SQL scripts at start. The options:
- **The module,** at startup. Cost: it needs a high database right (db_owner), which production setups often do not give.
- **A script** that the developer owns, as the demo does for its tables. Cost: a script to write, but it fits the deployment of the database.
- **The module offers a ready script** in its readme or as a resource. Cost: a script to keep up to date.

Recommendation: a script owned by the developer, with the ready script as a sample in the module readme. This is the same idea as dropping the creation of the topology at startup, see [Cat.Messaging.md](Cat.Messaging.md).
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
What does the reader do when it finds that the retention period removed changes it never saw? The options:
- **Fail loudly** (an error, a metric and an unhealthy state). Cost: a person must act, but nothing is lost silently.
- **Skip to the oldest available change and log a warning.** Cost: changes are lost silently.
- **A setting for each,** with fail as the default.

Recommendation: a setting, with fail loudly as the default. The point of the module is not to miss a change, so a gap must be seen.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Which table in which demo service shows the module? The options:
- **The stock table in Inventory.** It already changes with every reservation, and the database exists as scripts. Cost: Inventory does the writes itself, so the CDC case is artificial.
- **The price history in Catalog** (`BookPrice`). Cost: Catalog uses a temporal table, so CDC adds a second history of the same data.
- **A table that another system changes,** such as a small import table. Cost: a new table in the demo only for this.

Recommendation: Inventory stock, as "tell Orders or Notifications when stock is low". It is a real reaction to a change. Check this against [Demo.md](Demo.md) when this module gets close.
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Do we need to support databases other than SQL Server? The options:
- **SQL Server only.** The name `Cat.Sql.Cdc` already says so. Cost: none.
- **An abstraction for other change feeds later.** This is question 1 (the sink) in the other direction: a source abstraction. Cost: a design for databases we do not use.

Recommendation: SQL Server only. `Cat.EFCore` already ties the demo to it, and another database can get its own module.
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
Does the audit trail of `Cat.Auditing` use this module, or stay apart? CDC does not record the user (see the background), and [Cat.Auditing.md](Cat.Auditing.md) recommends the command decorator first. The options:
- **Stay apart.** Cost: changes made outside our code are not in the trail.
- **Use CDC as an extra source** for changes made outside our code, marked "unknown user". Cost: a dependency in one direction, and more work.

Recommendation: stay apart. Audit answers "who", and CDC cannot.
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
Should the first version ship before or together with `Cat.Messaging`? This is the blocking question, since it decides question 1. The options:
- **After `Cat.Messaging`.** The bridge project can then use the real sender. Cost: this module waits, and it is the last on the priority list anyway.
- **Together.** Cost: two designs move at once.
- **Before, with only the reader and an abstraction.** Cost: a reader that sends nowhere is of no use in the demo.

Recommendation: after `Cat.Messaging` and `Cat.EventProcessor`. It is the lowest priority of the modules in the repo overview, and nothing in the demo needs it before messaging works.
<!-- region end: Question 14-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->