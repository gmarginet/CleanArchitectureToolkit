---
name: cat-new-service
description: Create a new service with the Clean Architecture Toolkit template, in a new solution or in an existing one. Use when the developer wants to start a service, a microservice or a new API with CAT, or asks how to begin.
---

# Create a service

Create a service with the `cat-service` template of the pack `gmarginet.Cat.Templates`, then explain what to do next.

## Before you start
1. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write the files of the service by hand.
2. Run `dotnet new cat-service --help`. It lists every option with its default. The options can change between versions, so read them from there.

## Steps
1. Ask for the full name of the service, such as `Contoso.Shop.Orders`. The prefix is part of the name, and every project gets it.
2. Ask only for the options that matter, and accept the defaults for the rest. The ones that change the shape of the service are the database (`SqlServer` or `PostgreSQL`), the approach (`CodeFirst` or `DatabaseFirst`), `--Jobs` and `--Messages`.
3. Run the template.
   - New solution: `dotnet new cat-service -n <Name>`.
   - Existing solution: `dotnet new cat-service -n <Name> -o <folder> --NewSolution false --allow-scripts yes`. The template adds its projects to the `.slnx` solution at or above the folder, and a script merges its package versions into `Directory.Packages.Cat.props`. The script needs the .NET 10 SDK or newer. The solution needs one `Directory.Packages.props` line that imports that file, see the readme of the templates.
4. Run `dotnet build` in the new folder. Fix what fails before you go on.
5. Explain the next steps, short:
   - Fill the connection string `servicelower` in `appsettings.json` of the Api project. The name is the lower case name of the service.
   - Database first: create the tables of the Database project. Code first: add the first migration. With `--Messages true` the service throws at start without the connection string `messaging`, and that stops `dotnet ef` too. Set `ConnectionStrings__messaging` to a dummy value for the migration.
   - With Aspire, add the service to the AppHost. The readme of the service shows the line.
   - Add a first module with `cat-add-module`, or a first command with `cat-add-command`.

## Rules
- The templates write the structure. Do not add registrations, packages or endpoints in this skill. Other skills do that.
- Keep the answers of the developer. Do not choose the database or the approach for them.
