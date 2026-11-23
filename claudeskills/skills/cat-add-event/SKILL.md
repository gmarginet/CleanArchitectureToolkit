---
name: cat-add-event
description: Add an in-process event and its subscriber with the Clean Architecture Toolkit event aggregator. Use when the developer wants parts of a service to react to something that happened, a domain event inside one service, or says "add an event".
---

# Add an event

An event aggregator event stays inside one process. Use `cat-add-message` for an event that leaves the service.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Define an event and a subscriber" and "Subscribe and publish" in the readme of `Cat.EventAggregators`. The readme is `modules/Cat.EventAggregators/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.eventaggregators/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask what happened and who reacts. Name the event for the past, such as `OrderPlaced`.
2. Add `Cat.EventAggregators.Abstractions` to the core service, and `Cat.UnitTesting.EventAggregators` to the test project, when they are missing. The template needs both. See `cat-add-module`.
3. Run `dotnet new cat-event --help`, then run the template from the folder of the solution: `dotnet new cat-event -n <Name> --ServiceName <full name of the service>`. It writes the event, its subscriber and a test.
4. Fill in the subscriber. Publish the event from the handler that causes it, as "Subscribe and publish" shows.
5. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- An event stays in the process. Never send it to another service. A message does that, see `cat-add-message`.
- A subscriber that fails must not break the publisher. The chapter "Errors and exceptions" says how the module handles it.
