---
name: cat-add-saga
description: Add a saga with its messages, workflow, instance store and test using Cat.Sagas. Use when the developer wants a process that spans services and waits for answers, a long running flow, compensation, or says "add a saga".
---

# Add a saga

A saga is a workflow that sends messages and waits for the answers. It keeps its instances in the database of the service.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Write the messages", "Write the workflow", "Keep the instances in your database", "Start a saga", "Answer from another service", "Rules to follow" and "Test a saga" in the readme of `Cat.Sagas`. The readme is `modules/Cat.Sagas/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.sagas/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask for the steps of the process, the messages each step sends, the answer it waits for and what happens when the answer fails or does not come.
2. Add `Cat.Sagas` and `Cat.Messaging.Abstractions` to the core service, and `Cat.UnitTesting.Messaging` to the test project, when they are missing. See `cat-add-module`.
3. Run `dotnet new cat-saga --help`, then run the template. It writes the state, the workflow, the request and the answer message and a test with the in-memory store.
4. Fill in the workflow and the messages. Name the compensation steps for a failure. Time out a wait that must not last forever, as "Time out a wait" shows.
5. Register the modules in the order of "Register the module": `AddCatFluentWorkflowsModule`, the messaging module, `AddCatSagasModule`, then the instance store of the service, with the database table the readme names. Without the workflows module the service fails at start, because the saga needs `ICatWorkflowProcessor`. Then add every saga and every answer message, and a `Receive` for each answer. Use the outbox for the messages when the service has it. See `cat-add-outbox`.
6. The service that answers needs `cat-add-message-handler` for the request, and a way to send the answer back.
7. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- Follow the chapter "Rules to follow". A saga handler must be safe to run twice, so skip a repeated answer.
- A flow in one process that never waits for another service is a plain workflow. Offer `cat-add-workflow`.
