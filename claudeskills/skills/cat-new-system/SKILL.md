---
name: cat-new-system
description: Create a whole system with the Clean Architecture Toolkit solution template, with an Aspire AppHost, ServiceDefaults, a gateway and a first service. Use when the developer wants to start a new application or a multi service system with CAT, or asks how to begin a system like the demo.
---

# Create a system

The `cat-system` template makes the AppHost, the `ServiceDefaults`, a YARP gateway and a first service in one command. `cat-new-service` adds another service to it later.

## Before you start
1. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write the files of the system by hand.
2. Run `dotnet new cat-system --help`. It lists the options with their defaults. Read them from there.
3. The template runs `dotnet new cat-service` as a post action, which needs the .NET 10 SDK or newer and the option `--allow-scripts yes`. Docker must run for the AppHost.

## Steps
1. Ask for the name of the system, such as `Contoso.Shop`, and the short name of the first service, such as `Orders`.
2. Ask only for the options that change the shape: the database, the approach (`CodeFirst` or `DatabaseFirst`), `--Messages` and `--Jobs`. Accept the defaults for the rest. Say that the AppHost follows `--Framework`.
3. Run the template: `dotnet new cat-system -n <Name> --FirstService <Short> --allow-scripts yes`, with the options. Use `--GitIgnore false` in a folder that has a `.gitignore`, and add the line `cat-service*.rsp` to it by hand.
4. Run `dotnet build`. Fix what fails.
5. Explain the next steps, short:
   - The gateway is closed. Fill in the authority and the audience of the identity provider in the `appsettings.json` of the gateway, as the readme of the system says. Every call is rejected until then.
   - `dotnet run` in the AppHost starts the system, with the containers of the options.
   - The first service has an example request. Replace it with the requests of the service, with `cat-add-command`, `cat-add-query` and `cat-add-service-request`.
   - Add another service with `cat-new-service`, from the folder of the system.

## Rules
- The system has no web client. The front end is the choice of the developer.
- The file `cat-service.rsp` stays in the folder of the system. A template cannot delete its own files, and the `.gitignore` of the system ignores it.
