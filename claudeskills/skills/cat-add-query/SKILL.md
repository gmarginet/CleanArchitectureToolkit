---
name: cat-add-query
description: Add a query with its handler and a unit test to a Clean Architecture Toolkit service. Use when the developer wants to read data, a lookup, a list or a search, or says "add a query".
---

# Add a query

A query reads data and changes nothing. It is a class in the core service and its handler lives in `Infrastructure`.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Define a query" and "Write a handler" in the readme of `Cat.Queries`. The readme is `modules/Cat.Queries/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.queries/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask what the query reads and what it returns. Name it for the question, such as `OrderGet`.
2. Run `dotnet new cat-query --help`, then run the template from the folder of the solution: `dotnet new cat-query -n <Name> --ServiceName <full name of the service>`. A result type that already exists goes in with `--Result` and `--ResultNamespace`. Add `--Tests false` when the service has no test project.
3. Fill in the properties of the query and the body of the handler. Use the `DbContext` of `Infrastructure`. Return a response, and return the error for a missing item, as the chapter "Errors and exceptions" says.
4. When the service reads with Dapper and SQL files, use `cat-add-dapper-handler` instead.
5. The test of a query sits with the service request that uses it. When none does, offer `cat-add-service-request`.
6. Run `dotnet build` and `dotnet test`. Fix what fails.
7. Say what to do next, such as `cat-add-endpoint` to expose it, or `cat-cache-query` to cache it.

## Rules
- A query never changes data. Use `cat-add-command` for that.
- Never register the handler by hand. The module finds it.
