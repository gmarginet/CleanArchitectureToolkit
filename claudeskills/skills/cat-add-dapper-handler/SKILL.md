---
name: cat-add-dapper-handler
description: Add a query or command handler that uses Dapper, with the SQL in a .sql file, using Cat.Dapper. Use when the developer wants raw SQL, a fast read model, bulk operations, or says "add a Dapper handler".
---

# Add a Dapper handler

A Dapper handler runs SQL with the session of the scope. The SQL lives in a `.sql` file next to the handler.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Register the module", "Write a query handler", "Keep the SQL in .sql files", "Write a command handler with a transaction", "Keep the SQL safe" and "Test the handlers" in the readme of `Cat.Dapper`. The readme is `modules/Cat.Dapper/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.dapper/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask whether it reads or writes, and which database the service uses. SQL Server, PostgreSQL and MySQL have their own project. Only SQL Server and PostgreSQL have a template database option, so check `--help`.
2. Add `Cat.Dapper` and `Cat.Dapper.SqlFiles` to `Infrastructure`, and the line `<AdditionalFiles Include="**/*.sql" />` to its project file, when they are missing. Register the module with the call for the database, as "Register the module" shows. The core service stays on the abstractions.
3. Run `dotnet new cat-dapper-query --help` or `dotnet new cat-dapper-command --help`, then run the template. It writes the query or command, its partial handler and its `.sql` file.
4. Write the SQL in the file. Pass values as parameters. Never build the SQL with string concatenation.
5. A command that changes several tables uses the transaction of the chapter "Write a command handler with a transaction".
6. Add a test as "Test the handlers" shows. A real database test is worth it for SQL.
7. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- SQL Server SQL has no promise to work on PostgreSQL. Write for the database of the service and say so.
- Never read a `.sql` file at run time by hand. The generator makes the `Sql` property.
