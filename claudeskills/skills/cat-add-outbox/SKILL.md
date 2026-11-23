---
name: cat-add-outbox
description: Turn the outbox on with Cat.Outbox, so a message is stored with the data change and sent after it commits, with the cleanup. Use when the developer needs a message that must not get lost or sent twice with a database change, or says "add an outbox".
---

# Add an outbox

The outbox saves the message in the same transaction as the data change. A worker sends it after the commit.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Turn the outbox on", "Clean the outbox", "Keep the trace of the caller" and "Tests" in the readme of `Cat.Outbox`, and the chapter "Use the outbox" in the readme of `Cat.Messaging`. The readme is `modules/Cat.Outbox/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.outbox/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.

## Steps
1. Check that the service has `Cat.Messaging` and an EF Core database. When it has no messaging, offer `cat-add-message` first.
2. Add the packages and turn the outbox on with the call of "Turn the outbox on", on the context of the service. Mind the namespaces: `AddCatOutbox()` on the `ModelBuilder` is in `Cat.Outbox.EFCore`, `AddCatOutboxEfCore` is in `Cat.Outbox.EFCore.Extensions`, and `AddCatOutbox(options)` on the services is in `Cat.Outbox.Extensions`.
3. Add the outbox table. A code first service gets it through a migration. A database first service gets the table file from `dotnet new cat-outbox-table --Database <SqlServer|PostgreSQL>`, run in the folder of the solution. Run `dotnet new list cat-` first. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`, and run it only when the developer says yes. Say that nothing compares the table with the model of the outbox.
4. Send the messages through the sender as before. With the outbox on, the sender stores the message with the next `SaveChanges`. Check that the handler calls `SaveChanges`, because nothing is sent before it.
5. Add the cleanup, as "Clean the outbox" shows.
6. Add a test that checks that the row exists after the save, as "Tests" shows.
7. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- The outbox gives at least once delivery. The receiver needs the inbox, see `cat-add-inbox`.
- Never publish a message and then fail the save, because the message would have gone without the data.
