---
name: cat-add-message
description: Declare a message and send it to another service with Cat.Messaging, through the outbox when the service has one. Use when the developer wants to publish an event or send a command to another service over Azure Service Bus, or says "add a message".
---

# Add a message

A message leaves the service. An event goes to every subscriber of a topic, and a command goes to one queue.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Declare a message", "Register the module", "Send a message", "Where to publish from" and "Use the outbox" in the readme of `Cat.Messaging`. The readme is `modules/Cat.Messaging/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.messaging/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask whether it is an event or a command, what it carries, and who receives it. Name an event for the past, such as `OrderPlaced`, and a command for the action.
2. Add `Cat.Messaging.Abstractions` to `Contracts` when it is missing. See `cat-add-module`. The template needs it.
3. Run `dotnet new cat-message --help`, then run the template. `--Kind` picks event or command. It writes the message in `Contracts`, so the receiving service can share it.
4. Register `Cat.Messaging` in the service when it is not there, with the Azure Service Bus package, as "Register the module" says. The connection string `messaging` comes from the AppHost or the settings.
5. Send the message from the handler that causes it, with the sender of the module, as "Send a message" shows. When the service has the outbox, send through it, so the message and the data change commit together. See `cat-add-outbox`.
6. The queues and topics are created by a deployment step or a tool, not at start. The chapter "Create the queues and topics" shows how. In development the emulator is enough.
7. Run `dotnet build` and `dotnet test`. Fix what fails.
8. Say what to do next: the receiving service uses `cat-add-message-handler`.

## Rules
- Publish an event from the place the chapter "Where to publish from" names, and not from anywhere.
- Never put a secret or personal data in a message that other services read.
