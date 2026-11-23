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

# Cat.Inbox <!-- omit in toc -->

<!-- region start: Intro-->
Cat.Inbox skips work that was handled before. It remembers the id of a handled message or call in the service database, in the same `SaveChanges` as the work, so a repeat finds the id and is skipped. It serves a message from the bus and an inbound HTTP call, such as a webhook.

A payment provider sends a webhook at least once, and often twice. A handler that cannot run twice, such as one that books a refund in a ledger, needs to skip the second one. The module is split in an abstractions project, the EF Core store and the ASP.NET Core endpoint filter, so a service picks the parts it needs. A service with a webhook and no bus pulls in no event processor.
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Set up the store](#set-up-the-store)
  - [Skip a repeated webhook](#skip-a-repeated-webhook)
  - [Skip a repeated bus message](#skip-a-repeated-bus-message)
  - [Clean the inbox](#clean-the-inbox)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Inbox.Abstractions)](#nuget-packages)

| Package | Role | Targets | Install | Downloads |
|---------|------|---------|---------|-----------|
| [Cat.Inbox.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Inbox.Abstractions/) | Contracts | netstandard2.0 | `dotnet add package gmarginet.Cat.Inbox.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Inbox.Abstractions)](https://www.nuget.org/packages/gmarginet.Cat.Inbox.Abstractions/) |
| [Cat.Inbox.AspNetCore](https://www.nuget.org/packages/gmarginet.Cat.Inbox.AspNetCore/) | Endpoint filter for inbound HTTP calls | net10.0, net11.0 | `dotnet add package gmarginet.Cat.Inbox.AspNetCore` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Inbox.AspNetCore)](https://www.nuget.org/packages/gmarginet.Cat.Inbox.AspNetCore/) |
| [Cat.Inbox.EFCore](https://www.nuget.org/packages/gmarginet.Cat.Inbox.EFCore/) | Inbox storage for EF Core | net10.0, net11.0 | `dotnet add package gmarginet.Cat.Inbox.EFCore` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Inbox.EFCore)](https://www.nuget.org/packages/gmarginet.Cat.Inbox.EFCore/) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Inbox.Abstractions](namespaces/Cat.Inbox.Abstractions/index.md) | The contract of the inbox store. |
| [Cat.Inbox.AspNetCore](namespaces/Cat.Inbox.AspNetCore/index.md) | The endpoint filter that skips an inbound HTTP call that was handled before. |
| [Cat.Inbox.EFCore](namespaces/Cat.Inbox.EFCore/index.md) | The inbox table and its store for EF Core. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

Cat.Inbox has no dependencies on other CAT modules.

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Set up the store

Map the table in the context that the handlers use, register the store and add a migration, so the `CatInbox` table exists.

```csharp
using Cat.Inbox.EFCore;
using Cat.Inbox.EFCore.Extensions;

public class OrdersDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddCatInbox();
    }
}

builder.Services.AddCatInboxEfCore<OrdersDbContext>();
```

The store is plain EF Core, so it works on SQL Server and on PostgreSQL with the same code. `ICatInboxStore` lives in `Cat.Inbox.Abstractions`, so you can register a store of your own.

### Skip a repeated webhook

Put `WithCatInbox` on the endpoint. It needs `Cat.Inbox.AspNetCore`, and the namespace `Cat.Inbox.AspNetCore.Extensions`. The id of the call is the value of a header, or a value that you read from an argument the endpoint already bound.

```csharp
using Cat.Inbox.AspNetCore.Extensions;

// The provider sends its event id in a header.
app.MapPost("/webhooks/refund", HandleRefund).WithCatInbox(header: "webhook-id");

// The provider sends it in the body.
app.MapPost("/webhooks/refund", HandleRefund).WithCatInbox((RefundEvent e) => e.EventId);
```

What to know:
- **One save with the work.** The filter adds a row to the `DbContext` of the request scope, and the work saves it in its own `SaveChanges`. A call that fails saves nothing, so the provider can send it again.
- **Save through the context of the endpoint scope.** Use the `DbContext` of the request, or `ICatCurrentScopeCommandProcessor` of `Cat.Commands`. `ICatCommandProcessor` opens a new scope and saves with another context, so the row is never saved. After the endpoint, the filter checks that its row was saved and logs an error when it was not.
- **The answer to a repeat.** The filter skips the work and answers `200 OK` with no body. Pass another status per endpoint, such as `.WithCatInbox("webhook-id", StatusCodes.Status204NoContent)`. The inbox saves no answer of the first call, because a webhook provider only looks at the status.
- **A call without an id.** It is handled without the inbox, as a bus message without an id is. The filter logs a warning with the route and where it looked for the id, so a wrong header name or a provider that sends no id shows up.
- **Two copies at the same moment.** The second one fails on the key of the table and answers an error. The provider sends it again, and the inbox then skips it.
- **The argument overload.** The filter finds the argument by its type, so the endpoint needs exactly one argument of that type.
- **No signature check.** The module does not check the signature of a webhook. Use the SDK of the provider, and let the signature check run before the inbox, as the policy check runs before the inbox on the bus. The Standard Webhooks specification names the headers `webhook-id`, `webhook-timestamp` and `webhook-signature`. Many providers send an event id with every webhook.
- **A webhook that resumes a saga.** It needs no inbox. `ICatSagaDispatcher.ResumeAsync` of `Cat.Sagas` ignores an answer for an instance that is not waiting any more.

### Skip a repeated bus message

The receiver of `Cat.EventProcessor` uses the inbox for the message types that have `UseInbox` on. The project `Cat.EventProcessor.Inbox` is the bridge, and `Cat.EventProcessor` never references this module. See [The inbox](../Cat.EventProcessor/README.md#the-inbox) in the module readme of `Cat.EventProcessor`.
### Clean the inbox

The table grows by one row for every message of a type that has `UseInbox` on, and for every call of an endpoint with `WithCatInbox`. `Cat.Sagas` adds one row for every answer of a saga too. The module does not delete rows by itself, so you run a job that does.

`ICatInboxStore` has a method for it:

```csharp
var deleted = await inboxStore.DeleteOlderThanAsync(DateTimeOffset.UtcNow.AddDays(-30), cancellationToken);
```

What to know:
- **How long a row must live.** A row only matters while the bus or the provider can still deliver the same message again. For the bus, keep it at least as long as the time to live of the queue or subscription, and add a margin. A message that fails too often goes to the dead letter queue, so keep the rows longer when you resubmit dead lettered messages. For a webhook, keep it as long as the provider keeps sending a call again.
- **It runs at once.** The method deletes the rows right away, with its own statement, and does not wait for a `SaveChanges`. Call it from a scope of its own, such as a job or a worker.
- **Your own job.** You schedule the call. Any scheduler works, and `Cat.Scheduling` can run it, but the module does not need it.
- **Other stores.** A store of your own implements the method too.
### Tests

The store is plain EF Core, so a test runs it against SQLite in memory. Map the table with `AddCatInbox`, register the store with `AddCatInboxEfCore`, and deliver the same id twice, each time in a scope of its own, as the bus does.

```csharp
var connection = new SqliteConnection("DataSource=:memory:");
await connection.OpenAsync();

var services = new ServiceCollection();
services.AddDbContext<OrdersDbContext>(options => options.UseSqlite(connection));
services.AddCatInboxEfCore<OrdersDbContext>();
var provider = services.BuildServiceProvider();

using (var scope = provider.CreateScope())
{
    await scope.ServiceProvider.GetRequiredService<OrdersDbContext>().Database.EnsureCreatedAsync();
}

for (var delivery = 0; delivery < 2; delivery++)
{
    using var scope = provider.CreateScope();
    var handler = scope.ServiceProvider.GetRequiredService<RefundHandler>();

    await handler.HandleAsync("evt-1");
}

// The work ran once, and the table has one row.
```

Keep the connection open for the whole test, because SQLite in memory drops the database when the last connection closes. A test with an id that differs must run the work again. The tests of this module hold the example in `InboxHandlingTests`.

SQLite cannot translate the comparison of a `DateTimeOffset` in a query, so `DeleteOlderThanAsync` throws there. A test of the cleanup needs a real SQL Server or PostgreSQL.
<!-- region end: Usage-->
