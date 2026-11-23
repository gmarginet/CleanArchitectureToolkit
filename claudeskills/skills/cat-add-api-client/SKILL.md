---
name: cat-add-api-client
description: Create and generate the client project of a service, and register it in a service that calls it, with Cat.Api.Client. Use when one service must call another, the developer wants a generated HTTP client, or says "add an API client".
---

# Add an API client

The service that is called offers a client project, `Name.Api.Client`. The service that calls it registers the client.

## Before you start
1. Find the service the developer means, and say whether it is the one that offers the client or the one that calls it. Ask when it is not clear.
2. Read the chapters "What a client project holds", "Start from the settings template", "Generate the client", "Call a service", "Register the client" and "Forward the token" in the readme of `Cat.Api.Client`. The readme is `modules/Cat.Api.Client/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.api.client/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps for the service that offers the client
1. A service made with `--ApiClient true` has the project already. Otherwise run `dotnet new cat-api-client --help`, then run the template in the folder of the solution, and add the project to the solution with `dotnet sln add`.
2. The package version of `Cat.Api.Client` must be in `Directory.Packages.Cat.props`. Add it with `$(CatVersion)` when it is missing.
3. Save the OpenAPI document of the service in the client project, and fill in the settings of `nswag.json`: the `json` file, the `className`, the `namespace` and the `output`. The first build copies the settings template to `nswag.json`.
4. Generate the client, as "Generate the client" says. The generated code is checked in.
5. Say whether the client shares the `Contracts` of the service or has its own models. That is the choice of the developer. The default is its own models.

## Steps for the service that calls it
1. Reference the client project. Add the models of the client to nothing else.
2. Register the client with `AddCatApiClient`, with the address of the gateway. When the route is not anonymous, add the handler that forwards the token, as "Forward the token" shows.
3. Call it from a handler in `Infrastructure` through `CatApiCall.ExecuteAsync`, so the caller gets a response and never catches the exception of the client. Add resilience with `cat-add-resilience`.
4. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- Never edit the generated code. Change the OpenAPI document or the settings, and generate again.
- The core service never references the client project. Only `Infrastructure` does.
