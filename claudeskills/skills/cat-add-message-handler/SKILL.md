---
name: cat-add-message-handler
description: Add a handler for a received message, with its registration and subscription, using Cat.EventProcessor. Use when the developer wants a service to react to an event or command from Azure Service Bus, or says "add a message handler".
---

# Add a message handler

A handler runs when a message arrives. The event processor finds the handler, creates the subscription in development and settles the message.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Declare the message types", "Write the handler", "Register the module", "Settings per message type" and "The inbox" in the readme of `Cat.EventProcessor`. The readme is `modules/Cat.EventProcessor/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.eventprocessor/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask which message the service receives, and where its type lives. The type comes from the `Contracts` of the sender, or from a message made with `cat-add-message`.
2. A service made with `--Messages true` has the wiring already, in `MessageHandlerExtensions.cs` in the `Api` project. A service without it gets the wiring from the chapter "Register the module", as an extension file of its own, in the style of the other registration files. Tell the developer that it needs the connection string `messaging`, and that the service throws at start without it. That also stops `dotnet ef`, so a migration needs the value set, for example in the environment variable `ConnectionStrings__messaging`. A dummy value is enough for a migration.
3. Add `Cat.Messaging.Abstractions` to the core service when it is missing. See `cat-add-module`.
4. Run `dotnet new cat-message-handler --help`, then run the template. `--MessageNamespace` is the namespace of the message type. It writes the handler and a test.
5. Add a `Receive` of the message to the event processor registration, in the extension file, and turn the inbox on for it when the handler must run once. Follow the line of the example message.
6. Fill in the handler. A handler that writes to the database saves through its context, because the inbox row is saved in the same `SaveChanges`. The chapter "The inbox" explains.
7. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- The sender creates the topic. In development the service creates its own subscription only.
- Never swallow an exception in a handler. Return the failure as the readme says, so the message is settled the right way.
