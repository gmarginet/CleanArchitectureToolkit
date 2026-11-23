---
name: cat-add-gateway
description: Set up a gateway host and describe the services behind it with Cat.Api.Gateway, for a solution that does not use the solution template. Use when the developer wants a single entry point, token checks, routing to services, or says "add a gateway".
---

# Add a gateway

The gateway is the front door. It checks the token and sends each call to the service behind it. It holds no business logic.

## Before you start
1. Check whether the solution has a gateway already. A system made with `cat-new-system` has one, `Name.Api.Gateway`. Add services to its `appsettings.json` and stop here.
2. Read the chapters "Set up a gateway host", "Describe your services", "Check the token", "Make endpoints public" and "Choose how services trust the gateway" in the readme of `Cat.Api.Gateway`. The readme is `modules/Cat.Api.Gateway/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.api.gateway/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask for the services behind the gateway, with their names and addresses, and for the identity provider: the authority and the audience of the tokens.
2. Run `dotnet new cat-gateway --help`, then run the template in the folder of the solution, with `--Framework`. Add the project to the solution with `dotnet sln add`. The package version of `Cat.Api.Gateway` must be in `Directory.Packages.Cat.props`.
3. Fill in the `CatGateway` section of `appsettings.json`: the authentication, and one entry per service with its address. The routes follow by convention. Check whether the prefix of the service is stripped, as the readme says.
4. Make only the endpoints public that the developer names, as "Make endpoints public" shows. The gateway is closed by default, and every call needs a token until then.
5. Decide how the services trust the gateway. Read "Choose how services trust the gateway" and ask. Never pick it for the developer.
6. Run `dotnet build`. Run the gateway and the services and call a route with and without a token, when the developer wants it.

## Rules
- The gateway is closed by default. Keep it that way. Never open an endpoint the developer did not name.
- Never put a secret in `appsettings.json`. Use the configuration of the environment.
