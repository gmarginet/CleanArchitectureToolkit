---
name: cat-add-cdc
description: Map a SQL Server table to a message with change data capture using Cat.Sql.Cdc. Use when the developer wants to publish a message for every change of a table, or capture inserts, updates and deletes from SQL Server, or says "add CDC".
---

# Add change data capture

`Cat.Sql.Cdc` reads the change tables of SQL Server and hands each change to a sink, such as a message on the bus. It works on SQL Server only.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Check the database. When the service uses PostgreSQL, stop. The module works on SQL Server only, and the readme says to use `Cat.Outbox` there. Offer `cat-add-outbox`.
3. Read the chapters "Enable change data capture", "Register the reader", "Settings", "Map a table to a message", "Send the changes to Cat.Messaging" and "Delivery guarantees" in the readme of `Cat.Sql.Cdc`. The readme is `modules/Cat.Sql.Cdc/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.sql.cdc/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.

## Steps
1. Ask which table to capture and which message it becomes. A table without a mapping gives a general change message.
2. Capture needs the SQL Server Agent, or a managed service that runs the capture job. Tell the developer, and tell them that they run `sys.sp_cdc_enable_db` and `sys.sp_cdc_enable_table` once. The module never switches capture on. Write the script and let the developer run it.
3. Add the packages and register the reader with `AddCatSqlCdc`, the table with its capture instance name, and the sink. The message sink needs `Cat.Messaging`, see `cat-add-message`.
4. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`, and run it only when the developer says yes. Then run `dotnet new cat-cdc-mapping -n <Table> -S <Service>`. It writes the typed message, the mapping and a test. Change the properties and the column names to the table, and register the mapping with `AddTable` as "Map a table to a message" shows. A mapped message inherits from the event message base.
5. Fill in the `CatSqlCdc` section of the settings. The connection needs the rights to create the schema `catcdc` and to read the change tables.
6. The receiver needs the inbox, because delivery is at least once. See `cat-add-inbox`.
7. Run `dotnet build` and `dotnet test`. A real test needs SQL Server with the agent, so say if you did not run one.

## Rules
- The same change always gets the same message id, so a receiver can skip a repeat. Never replace it with a new id.
- Read "Gaps in the change tables" before the developer goes live. A reader that is down longer than the retention loses changes.
