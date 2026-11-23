---
name: cat-add-service-request
description: Add a service request with its handler and a test to a Clean Architecture Toolkit service, for a use case that calls several commands or queries. Use when the developer wants a new use case, an operation of the service, or says "add a service request".
---

# Add a service request

A service request is one use case of a service. Its handler calls commands and queries, and callers use the request from the `Contracts` project.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Define a request" and "Write a handler" in the readme of `Cat.ServiceRequests`. The readme is `modules/Cat.ServiceRequests/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.servicerequests/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask what the use case does and which commands and queries it needs. Name it for the use case, such as `OrderPlaceRequest`.
2. Run `dotnet new cat-service-request --help`, then run the template from the folder of the solution: `dotnet new cat-service-request -n <Name> --ServiceName <full name of the service>`. Add `--Tests false` when the service has no test project.
3. Fill in the request in `Contracts`, and the handler in the core service. The handler calls the commands and queries through their processors and returns the response of the work. It does no database work itself.
4. Add the commands and queries that the use case needs with `cat-add-command` and `cat-add-query`. The test of those sits with this request, so fill in the test of the request.
5. Run `dotnet build` and `dotnet test`. Fix what fails.
6. Say what to do next, such as `cat-add-endpoint` to expose the request.

## Rules
- Keep the request a plain class that callers can use. It sits in `Contracts`, so it never references the core service.
- Never register the handler by hand. The module finds it.
