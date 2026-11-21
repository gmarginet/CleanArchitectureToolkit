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

# Cat.Outbox <!-- omit in toc -->

<!-- region start: Intro-->
Cat.Outbox saves outgoing messages in the same unit of work as your data, and sends them to the bus later. A crash between saving the data and sending the message no longer loses the message.

The module plugs into `Cat.Messaging` through the sink seam `ICatOutgoingMessageSink`, so the code that sends a message does not change. `Cat.Messaging` never references the outbox. The store for EF Core is a project of its own, so a service picks the storage it needs.
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Turn the outbox on](#turn-the-outbox-on)
  - [Clean the outbox](#clean-the-outbox)
  - [Keep the trace of the caller](#keep-the-trace-of-the-caller)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Outbox)](#nuget-packages)

| Package | Role | Targets | Install | Downloads |
|---------|------|---------|---------|-----------|
| [Cat.Outbox.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Outbox.Abstractions/) | Contracts | netstandard2.0 | `dotnet add package gmarginet.Cat.Outbox.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Outbox.Abstractions)](https://www.nuget.org/packages/gmarginet.Cat.Outbox.Abstractions/) |
| [Cat.Outbox](https://www.nuget.org/packages/gmarginet.Cat.Outbox/) | Implementation | netstandard2.0 | `dotnet add package gmarginet.Cat.Outbox` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Outbox)](https://www.nuget.org/packages/gmarginet.Cat.Outbox/) |
| [Cat.Outbox.EFCore](https://www.nuget.org/packages/gmarginet.Cat.Outbox.EFCore/) | Outbox storage for EF Core | net10.0, net11.0 | `dotnet add package gmarginet.Cat.Outbox.EFCore` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Outbox.EFCore)](https://www.nuget.org/packages/gmarginet.Cat.Outbox.EFCore/) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Outbox.Abstractions](namespaces/Cat.Outbox.Abstractions/index.md) | The contract of the outbox store and the item it hands to the sender. |
| [Cat.Outbox](namespaces/Cat.Outbox/index.md) | The sink, the background sender and the options. |
| [Cat.Outbox.EFCore](namespaces/Cat.Outbox.EFCore/index.md) | The outbox table and store for EF Core. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

| Module | Why Cat.Outbox needs it |
|--------|-------------------------|
| [Cat.Messaging](../Cat.Messaging/README.md) | It stores a `CatOutgoingMessage` and plugs into the sender through `ICatOutgoingMessageSink` of `Cat.Messaging.Abstractions`. |

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Turn the outbox on

Without the outbox, a message is sent at once. When the service crashes between saving the data and sending the message, the message is lost. The outbox closes that gap. The message is saved in the same `SaveChanges` as the data, and a background service sends it afterwards.

Add the `Cat.Outbox` and `Cat.Outbox.EFCore` packages. Map the table in your context and register the outbox after the module:

```csharp
using Cat.Outbox.EFCore;
using Cat.Outbox.EFCore.Extensions;
using Cat.Outbox.Extensions;

public class OrdersDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddCatOutbox();
    }
}

builder.Services.AddCatMessagingModule();
builder.Services.AddCatMessagingAzureServiceBus(options => options.ConnectionString = connectionString);
builder.Services.AddCatOutboxEfCore<OrdersDbContext>();
builder.Services.AddCatOutbox(options => options.PollInterval = TimeSpan.FromSeconds(2));
```

Add a migration afterwards, so the `CatOutbox` table exists. Your code does not change: `ICatMessageSender` now stores the message, and your own `SaveChanges` saves it with the entities.

What to know:
- The sender marks a message as sent only after the bus accepted it. A crash in between sends the message twice, never zero times. A receiver must handle a message more than once.
- A scheduled message keeps its `scheduledAt` in the outbox and goes to the bus when the sender picks it up.
- The sender stops at the first message that fails, so the order of the others is kept.
- **Growth.** The sender never deletes a sent row. See [Clean the outbox](#clean-the-outbox).

### Clean the outbox

The table grows by one row for every message. A row holds the whole message, with its body and its token, so it is bigger than an inbox row. The module does not delete rows by itself, so you run a job that does.

`ICatOutboxStore` of `Cat.Outbox.Abstractions` has a method for it:

```csharp
var deleted = await outboxStore.DeleteOlderThanAsync(DateTimeOffset.UtcNow.AddDays(-30), cancellationToken);
```

What to know:
- **Only sent rows.** The method deletes the rows with a `SentAt` before the time limit. A row that is not sent yet stays, however old it is.
- **How long a row must live.** A sent row only helps you find a message that went missing. Keep it as long as you want that trace, and know that its token stays in the table for as long as the row does.
- **It runs at once.** The method deletes the rows right away, with its own statement, and does not wait for a `SaveChanges`. Call it from a scope of its own, such as a job or a worker.
- **Your own job.** You schedule the call. Any scheduler works, and `Cat.Scheduling` can run it, but the module does not need it.
- **Other stores.** A store of your own implements the method too.

### Keep the trace of the caller

A message that goes through the outbox keeps the trace of the code that sent it. When the message is stored, the store saves the W3C `traceparent` of the running activity in the column `TraceParent`. When the background service sends the message, the store puts that value on it as the property `Diagnostic-Id`. A receiver that reads `Diagnostic-Id` can continue the trace of the caller. The receiver of `Cat.EventProcessor` does that, see [Traces](../Cat.EventProcessor/README.md#traces).

What to know:
- **New column.** `CatOutbox` has the column `TraceParent`, `nvarchar(55)` and nullable. Add a migration for it. A row that is already stored has no trace and is sent as before.
- **No activity, no property.** A message stored with no running activity gets no `Diagnostic-Id`, and the Service Bus SDK puts its own on it.
- **Your own `Diagnostic-Id` wins.** The store never replaces a `Diagnostic-Id` that you put in the properties of the message.
- **Without the outbox.** `Cat.Messaging` leaves the trace to the Service Bus SDK, as before.
<!-- region end: Usage-->
