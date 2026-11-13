<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: ../.. -->
<link href="../../resources/styles/style.css" rel="stylesheet" />
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
            <img src='../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-module-readme skill to update this readme.-->
<!-- region end: TemplateSkill-->

# Cat.Sql.Cdc <!-- omit in toc -->  

<!-- region start: Intro-->
Turn SQL Server change data capture into messages.  
A background service reads the change tables you pick, in order, and hands every change to a sink.  
The position is kept in your own database, so a restart carries on where it stopped.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Enable change data capture](#enable-change-data-capture)
  - [Register the reader](#register-the-reader)
  - [Settings](#settings)
  - [Map a table to a message](#map-a-table-to-a-message)
  - [Send the changes to Cat.Messaging](#send-the-changes-to-catmessaging)
  - [Write your own sink](#write-your-own-sink)
  - [Delivery guarantees](#delivery-guarantees)
  - [Several instances](#several-instances)
  - [Gaps in the change tables](#gaps-in-the-change-tables)
  - [Health check and telemetry](#health-check-and-telemetry)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Sql.Cdc)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Sql.Cdc.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Sql.Cdc.Abstractions/) | Change type and sink contract | `dotnet add package gmarginet.Cat.Sql.Cdc.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Sql.Cdc.Abstractions)](#nuget-packages) |
| [Cat.Sql.Cdc](https://www.nuget.org/packages/gmarginet.Cat.Sql.Cdc/) | Reader, position store and health check | `dotnet add package gmarginet.Cat.Sql.Cdc` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Sql.Cdc)](#nuget-packages) |
| [Cat.Sql.Cdc.Messaging](https://www.nuget.org/packages/gmarginet.Cat.Sql.Cdc.Messaging/) | Sink that sends changes through Cat.Messaging | `dotnet add package gmarginet.Cat.Sql.Cdc.Messaging` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Sql.Cdc.Messaging)](#nuget-packages) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Sql.Cdc.Abstractions](namespaces/Cat.Sql.Cdc.Abstractions/index.md) | The change, its operation and the sink that receives it. |
| [Cat.Sql.Cdc](namespaces/Cat.Sql.Cdc/index.md) | The reader service, the settings, the table builder and the health check. |
| [Cat.Sql.Cdc.Messaging](namespaces/Cat.Sql.Cdc.Messaging/index.md) | The sink that publishes changes as event messages, and the default change message. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

| Module | Why Cat.Sql.Cdc needs it |
|--------|--------------------------|
| [Cat.Messaging](../Cat.Messaging/README.md) | Only `Cat.Sql.Cdc.Messaging` needs it. Its sink sends changes through `ICatMessageSender`. |

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
Pick the projects you need. The core only knows the `ICatChangeSink` contract, so it works with any sink.  
`Cat.Sql.Cdc.Messaging` is one sink. You can write another.

### Enable change data capture
The module never switches change data capture on. You do that, once per table, with `sys.sp_cdc_enable_table`.  
The capture instance name is `<schema>_<table>` unless you set another one. You pass that name to the reader.

```sql
EXEC sys.sp_cdc_enable_db;

EXEC sys.sp_cdc_enable_table
    @source_schema = N'dbo',
    @source_name   = N'BookPrice',
    @role_name     = NULL,
    @supports_net_changes = 0;
```

Change data capture needs the SQL Server Agent, or a managed service that runs the capture job for you.  
More on this in the [Microsoft documentation](https://learn.microsoft.com/en-us/sql/relational-databases/track-changes/about-change-data-capture-sql-server).

### Register the reader
Register the reader, the tables and a sink.

```csharp
builder.Services.AddCatSqlCdc(builder.Configuration, cdc =>
{
    cdc.AddTable("dbo_BookPrice");
});

builder.Services.AddCatSqlCdcMessaging();
```

The reader is a hosted service with one loop per table.  
On the first start it creates the schema `catcdc` and the table `catcdc.Position` in your database. The connection needs the rights to do that, and to read the change tables.

### Settings
The settings come from the section `CatSqlCdc`.

| Setting | Default | What it does |
|---------|---------|--------------|
| `ConnectionString` | none | The database that has change data capture enabled. Required. |
| `PollInterval` | `00:00:01` | How long a loop waits when there was nothing to read. |
| `BatchSize` | `1000` | The most changes one round reads and sends. Must be at least 1. |
| `Schema` | `catcdc` | The schema of the position table. |
| `ClaimLease` | `00:00:30` | How long an instance owns a table before another one may take over. |
| `OnRetentionGap` | `Fail` | What to do when the change tables lost changes you did not read yet. See [Gaps in the change tables](#gaps-in-the-change-tables). |

```json
{
  "CatSqlCdc": {
    "ConnectionString": "Server=...;Database=Bookshop;...",
    "PollInterval": "00:00:02",
    "OnRetentionGap": "Fail"
  }
}
```

### Map a table to a message
Without a mapping the sink gets the `CatChange` itself. `Cat.Sql.Cdc.Messaging` turns it into a `CatCdcChangeMessage` that holds the keys, the old values and the new values as dictionaries.  
Give a table a mapping to get a typed message instead.

```csharp
cdc.AddTable<BookPriceChanged>("dbo_BookPrice", t => t.Map(change => new BookPriceChanged
{
    MessageId = change.MessageId,
    Isbn = (string)change.Keys["Isbn"]!,
    OldPrice = (decimal?)change.Old?["Price"],
    NewPrice = (decimal?)change.New?["Price"]
}));
```

A `CatChange` holds:
- `Table`, `Operation` (`Insert`, `Update` or `Delete`) and `TransactionId`.
- `TransactionTime`. It uses the current UTC offset of the server, so it can be off by an hour around a daylight saving change.
- `Keys`, `Old` and `New`. An insert has no `Old`, a delete has no `New`.
- `Lsn` and `SequenceValue`, the position of the change in the log.
- `MessageId`, a stable id made from the position and the operation. The same change always gets the same id.

### Send the changes to Cat.Messaging
`AddCatSqlCdcMessaging` registers a sink that publishes every message as an event with `ICatMessageSender`. A mapped message must inherit from `CatEventMessage`.  
The sink gives the message the `MessageId` of the change. A consumer that drops messages with an id it has seen gets exactly-once handling on top of the at-least-once delivery.  
The sink sends directly. It does not use an outbox. If the bus is down, the round fails and the next round reads the same changes again.

### Write your own sink
Implement `ICatChangeSink` and register it as a singleton instead of `AddCatSqlCdcMessaging`.

```csharp
public class ConsoleSink : ICatChangeSink
{
    public Task SendAsync(CatChange change, object message, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"{change.Table} {change.Operation}");
        return Task.CompletedTask;
    }
}

builder.Services.AddSingleton<ICatChangeSink, ConsoleSink>();
```

### Delivery guarantees
The reader keeps its position in `catcdc.Position`, in the same database. It saves the position only after the sink took every change of the round.
- Delivery is at least once. A crash between the send and the save sends the changes again.
- Order is kept per table, in the order of the log.
- A failing sink never moves the position. The loop reports the failure, waits and tries again.

The first time a table is read, the reader starts at the oldest change that is still available.

### Several instances
Run as many instances of a service as you like. An instance claims a table with a lease on its row in `catcdc.Position`. Only the owner reads.  
When the owner stops or dies, another instance takes over after `ClaimLease`. A reader that lost its claim stops before it saves, so two instances never write the same position.

### Gaps in the change tables
SQL Server removes old changes with a cleanup job. If the reader was away longer than the retention, the changes it did not read are gone.
- `Fail` stops the loop of that table with a `CatCdcGapException` and makes the health check unhealthy. You decide what to do. This is the default.
- `SkipToOldest` logs a warning, jumps to the oldest change that is left and goes on. You lose the changes in between.

### Health check and telemetry
Add the health check to see a stopped or failing table.

```csharp
builder.Services.AddHealthChecks().AddCatSqlCdcHealthCheck();
```

- Unhealthy: a table stopped reading, for example after a gap.
- Degraded: the last poll of a table failed. It recovers by itself.

The module publishes metrics on the meter `Cat.Sql.Cdc`.
<!-- region end: Usage-->
