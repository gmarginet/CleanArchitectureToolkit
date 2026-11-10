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

# Plans for Cat.Sql.Cdc

Translates SQL Server change data capture (CDC) changes into calls on a service bus.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Some databases change without our code. Another system writes to them, or a script does. Nobody publishes a message when that happens.

`Cat.Sql.Cdc` reads the [change data capture](https://learn.microsoft.com/en-us/sql/relational-databases/track-changes/about-change-data-capture-sql-server?view=sql-server-ver17) tables of SQL Server. It turns each captured insert, update and delete into a call on a service bus. Other services can then react to the change.

It sits next to `Cat.Messaging`. That module sends the messages. This module finds out what changed.

## What we already know

From Microsoft:

- CDC records insert, update and delete activity on a table.
- It reads the transaction log and writes the changes to change tables. Your own transactions are not slowed down by the capture.
- Each change carries a log sequence number (LSN), the operation and the column values.
- CDC is a SQL Server feature. Check the edition and agent requirements for the version we target.
- The change tables are cleaned up after a retention period, so a reader must keep up or remember its position.

From the root readme:

- `Cat.Messaging` is the planned module that publishes and consumes messages on Azure Service Bus.
- `Cat.EventProcessor` is the planned worker support that turns incoming messages into service requests.

From the module conventions:

- A module splits into an `Abstractions` project, the implementation and optional parts.
- A module never forces another module on the developer.
- Modules never depend on Aspire or on the demo `ServiceDefaults`.
- Module projects target `netstandard2.0` as much as possible. A project that needs more targets the latest stable .NET.

From the Cat.Auditing plan:

- `plans/Cat.Auditing.md` says temporal tables answer "what was the price then" but not "who changed it". CDC has the same limit, since it does not record the user.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Name | The module is called `Cat.Sql.Cdc` (task from the owner). |
| Purpose | The module translates SQL CDC changes to a service bus call (task from the owner). |
| Documentation | The module readme links to the Microsoft page about change data capture (task from the owner). |

### Open

- **Bus dependency.** Does the module depend on `Cat.Messaging`, or does it only define an abstraction for "send this change" and leave the sending to a separate bridge project? The second keeps the toolbox rule, and costs one more project.
- **Where it runs.** A hosted service inside a service, or a separate worker? A worker keeps the reading apart from the service. A hosted service is simpler to start.
- **Reading method.** Poll the CDC functions on a timer, or use a library that wraps them? Polling is simple and needs no extra part. We could also check what exists before we write our own reader.
- **Position.** Where does the reader store the last LSN it handled? In a table in the same database, in the service's own database, or elsewhere? This decides if a restart loses or repeats changes.
- **Delivery.** CDC and the bus are two systems. The module gives at least once delivery unless it does more. Who removes duplicates: the receiver, or an inbox in `Cat.Messaging`?
- **Message shape.** One message per row change, or one per transaction? Does the message carry the old and the new values, or only the new ones? Does it use the CDC column names or a type the developer maps to?
- **Mapping.** How does a developer say "changes of table X become message Y"? Code configuration, attributes or a convention?
- **Contracts.** Where do the message types live? The root readme says sharing a `Contracts` project is the developer's choice.
- **Enabling CDC.** Who runs `sys.sp_cdc_enable_table`: the module, a script or the developer? The demo applies SQL scripts at start, so a script may be enough.
- **Cleanup and retention.** What does the reader do when it finds that the retention period removed changes it never saw?
- **Demo.** Which table in which demo service would show it? Candidates are the price history in Catalog or the stock in Inventory. To check against `Demo.md`.
- **Other databases.** SQL Server only, or an abstraction for other change feeds later? `Cat.EFCore` already ties the demo to SQL Server.
- **Overlap with `Cat.Auditing`.** Does the audit trail use this module, or stay apart?

## Questions before building

1. Does the module depend on `Cat.Messaging`, or only on an abstraction that a bridge implements?
2. Does it run as a hosted service or as a separate worker?
3. Where is the last handled LSN stored?
4. Do we send one message per row change or one per transaction?
5. Does the message carry the old and the new values?
6. How does a developer map a captured table to a message type?
7. Who enables CDC on a table: the module, a script or the developer?
8. Which demo table shows the module?
9. Do we need to support databases other than SQL Server?
10. Should the first version ship before or together with `Cat.Messaging`?
