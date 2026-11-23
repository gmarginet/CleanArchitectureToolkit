---
name: cat-add-entity
description: Add an entity on the Cat.EFCore base classes with its configuration and migration, or a table in a database first service, for SQL Server or PostgreSQL. Use when the developer wants a new table, an entity, a database model, or says "add an entity".
---

# Add an entity

The service is code first or database first. The skill follows the one the service uses.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the readme of `Cat.EFCore`, the chapters "Use PostgreSQL", "When to use `CatReferenceEntityBase`" and the chapter about the base classes. The readme is `modules/Cat.EFCore/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.efcore/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.
4. Find out the approach. A `*.Database` project, or a `Scripts` folder, means database first. Otherwise the service is code first.

## Steps for code first
1. Ask for the name, the properties and the relations in plain words.
2. Run `dotnet new cat-entity --help`, then run the template with `--Database SqlServer` or `--Database PostgreSQL`, the database of the service. It writes the entity in `DataModels` and its configuration in `Infrastructure`.
3. Fill in the properties. Add the `DbSet` to the context of the service, and call the `Configure<Name>()` extension that the template wrote from `OnModelCreating` of that context.
4. Add the migration: `dotnet ef migrations add <Name> --project <Infrastructure project> --startup-project <Api project>`. Read the migration before you accept it.
5. Run `dotnet build`. Fix what fails.

## Steps for database first
1. Run `dotnet new cat-table --help`, then run the template with `--Database`. On SQL Server the file goes in the SQL project, and on PostgreSQL in the scripts folder.
2. Fill in the columns. Write the table as SQL, the way the other table files do.
3. Tell the developer to deploy the schema to the database. Never deploy it yourself. After that, run the scaffold command from the readme of the service, `dotnet ef dbcontext scaffold ...`, and check the diff of the entities.
4. The tables of the inbox, the outbox and the scheduler are table files too, from the `Cat.Inbox`, `Cat.Outbox` and `Cat.Scheduling` readmes.

## Rules
- Database first has no migrations. Never add one there.
- Never edit a migration that was applied. Add a new one.
