---
name: cat-add-command
description: Add a command with its handler, a validator and a unit test to a Clean Architecture Toolkit service. Use when the developer wants to create, update or delete data, a write operation, or says "add a command".
---

# Add a command

A command changes data. It is a class in the core service and its handler lives in `Infrastructure`.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Define a command", "Write a handler" and "Get a result from a command" in the readme of `Cat.Commands`. The readme is `modules/Cat.Commands/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.commands/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask what the command does, and name it for the action, such as `OrderPlace`.
2. Choose the form with the order of "Get a result from a command". Ask when it is not clear.
   - First: the caller supplies the IDs, so the command needs no result.
   - Second: a query after the command reads what it created.
   - Third: a typed command that returns the result.
3. Run `dotnet new cat-command --help`, then run the template from the folder of the solution: `dotnet new cat-command -n <Name> --ServiceName <full name of the service>`. Add `--Tests false` when the service has no test project.
4. Add the validator with `cat-add-validator` when the request needs rules.
5. Fill in the properties of the command and the body of the handler. Use the `DbContext` of `Infrastructure`. Return errors as responses, never as exceptions, as the chapter "Errors and exceptions" says.
6. The test of a command sits with the service request that uses it. When no service request uses the command yet, offer `cat-add-service-request`.
7. Run `dotnet build` and `dotnet test`. Fix what fails.
8. Say what to do next, such as `cat-add-endpoint` to expose it.

## Rules
- The core service never references an implementation project. A handler goes in `Infrastructure`, because it uses the database.
- Never register the handler by hand. The module finds it.
