---
name: cat-add-inbox
description: Skip a repeated webhook or bus message with Cat.Inbox, with the store and the cleanup. Use when the developer needs idempotent handling, duplicate messages or webhooks that arrive twice, or says "add an inbox".
---

# Add an inbox

The inbox remembers the messages that were handled, so one that arrives twice runs once.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Set up the store", "Skip a repeated webhook", "Skip a repeated bus message" and "Clean the inbox" in the readme of `Cat.Inbox`. The readme is `modules/Cat.Inbox/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.inbox/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.

## Steps
1. Ask what repeats: a webhook from outside, or a bus message. The bus case has its own path through `Cat.EventProcessor`, see `cat-add-message-handler`, and its readme chapter "The inbox".
2. Add the packages and register the store with the call of "Set up the store". The store keeps its rows in the database of the service, in the table `CatInbox`.
3. Add the table. A code first service gets it through a migration. A database first service gets a table file, see `cat-add-entity`, and it must match the model of the inbox. Say that nothing compares the two.
4. For a webhook, wrap the handling as "Skip a repeated webhook" shows, with the id that the sender gives each delivery.
5. Add the cleanup, as "Clean the inbox" shows, so the table does not grow without end.
6. Add a test that sends the same message twice and checks that the work ran once.
7. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- The inbox row and the work commit together. A handler that writes to the database saves through its own context, and the row goes in the same `SaveChanges`.
- Use the id that the sender gives. Never invent an id on the receiving side, because a repeat would get a new one.
