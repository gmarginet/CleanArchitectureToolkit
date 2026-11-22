<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: .. -->
<link href="../resources/styles/style.css" rel="stylesheet" />
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

# Cat.Templates <!-- omit in toc -->

`dotnet new` templates for a service of the Clean Architecture Toolkit and for the single parts of it. One command creates the projects of the [service project structure](../README.md#service-project-structure), wired the same way as the demo. The item templates add one part, such as a command with its handler and its test.

In this chapter, "template" always means a `dotnet new` template.

## Table of contents <!-- omit in toc -->
- [Install](#install)
- [Create a service](#create-a-service)
- [What the service holds](#what-the-service-holds)
- [Add a part to a service](#add-a-part-to-a-service)
- [Add a project](#add-a-project)
- [What a developer adds after the template](#what-a-developer-adds-after-the-template)
- [Package versions](#package-versions)
- [How the templates are tested](#how-the-templates-are-tested)

## Install
The templates ship as the NuGet template pack `gmarginet.Cat.Templates`. It has the same version as the modules.

```
dotnet new install gmarginet.Cat.Templates
```

## Create a service
The name is the full name of the service. A prefix is part of it: `-n Contoso.Shop.Orders` gives `Contoso.Shop.Orders.Api`, `Contoso.Shop.Orders.CoreService` and so on.

```
dotnet new cat-service -n Contoso.Shop.Orders
```

These are the options. Every one has a default.

| Option | Values | Default | What it does |
|--------|--------|---------|--------------|
| `--Framework` | `net11.0`, `net10.0` | `net11.0` | The target framework. `Contracts` and `Api.Client` always target `netstandard2.0`. |
| `--Database` | `SqlServer`, `PostgreSQL` | `SqlServer` | The database of the service. |
| `--Approach` | `CodeFirst`, `DatabaseFirst` | `CodeFirst` | Code first has hand written entities and EF Core migrations. Database first has a SQL schema, and the entities are scaffolded from it. |
| `--Tests` | `true`, `false` | `true` | Adds the project `Name.CoreService.Tests`. |
| `--ApiClient` | `true`, `false` | `false` | Adds the project `Name.Api.Client` for a service that other services call. |
| `--ExampleRequest` | `true`, `false` | `true` | Adds one example request with its handler, query, test and endpoint, so you see that the service builds and runs. |
| `--Jobs` | `true`, `false` | `false` | Adds the scheduler of `Cat.Scheduling` with one example job. |
| `--Messages` | `true`, `false` | `false` | Adds message handlers with `Cat.EventProcessor`, Azure Service Bus and the inbox, with one example message. |
| `--NewSolution` | `true`, `false` | `true` | `false` adds the projects to the `.slnx` solution at or above the output folder, and writes no solution file. |
| `--CatVersion` | a version | the version of the pack | The version of the CAT packages in `Directory.Packages.props`. |

Run `dotnet new cat-service --help` for the same list.

A service in an existing solution:

```
dotnet new cat-service -n Contoso.Shop.Orders -o src/Orders --NewSolution false
```

## What the service holds
The projects of the service project structure: `Api`, `CoreService`, `Infrastructure`, `Contracts` and `DataModels`, plus the optional `CoreService.Tests` and `Api.Client`. With database first on SQL Server it also has `Name.Database`, a SQL project with the `Microsoft.Build.Sql` SDK. With database first on PostgreSQL it has plain SQL scripts in the same folder, because that SDK only builds SQL Server schemas. The developer runs the scripts by hand, and the readme of the generated service shows the `psql` command.

`Program.cs` wires what the example request needs: `Cat.Minimal.Api`, `Cat.ServiceRequests`, `Cat.Responses` and `Cat.Validators`, plus `Cat.Commands` and `Cat.Queries` for the handlers in Infrastructure. The worker modules are wired only when their option is on. `Cat.Resilience` and `Cat.Telemetry` are called directly, as their module readmes show for a project without Aspire.

The service also gets:
- a `Directory.Packages.props` with the package versions, see [Package versions](#package-versions),
- a readme, an `.http` file for the Api, and `/health` and `/alive` with a database check,
- no Aspire code, no Dockerfile and no deployment files, because they depend on how the developer runs and deploys it. The readme of the generated service shows the lines to add for `ServiceDefaults` and the AppHost.

With `--Messages`, the connection string of the bus is empty in `appsettings.json`, so the host does not start until the developer fills it in. The readme of the generated service shows the Service Bus emulator and the AppHost line.

## Add a part to a service
Run an item template in the folder of the solution of the service. The name is the name of the part, and `--ServiceName` is the full name of the service.

```
dotnet new cat-command -n OrderPlace --ServiceName Contoso.Shop.Orders
```

Every template that writes a test takes `--Tests false` for a service without a test project. Item templates cannot add packages, so the table lists the packages that a template needs. Add them to the project with `dotnet add package`, with the version of `Directory.Packages.props`.

| Template | Writes | Parameters | Needs |
|----------|--------|------------|-------|
| `cat-service-request` | The request in Contracts, its handler and its test. | | |
| `cat-command` | The command in the core and its handler in Infrastructure. The test sits with the service request that uses it. | | |
| `cat-query` | The query in the core and its handler in Infrastructure. The test sits with the service request that uses it. | `--Result`, `--ResultNamespace` | |
| `cat-validator` | The validator of a request and a test that the module finds it. | `--TargetNamespace` | |
| `cat-error-definitions` | The static class with the error definitions of a service, such as `OrderErrorDefinitions`, and its test. | `--Prefix` | |
| `cat-workflow` | The state, the workflow and a test. | | `Cat.FluentWorkflows` in the core |
| `cat-event` | The event, its subscriber and a test. | | `Cat.EventAggregators.Abstractions` in the core, `Cat.UnitTesting.EventAggregators` in the tests |
| `cat-decorator` | A decorator for commands, queries or service requests and a test. | `--For` | `Cat.Decorators.Abstractions` in the core |
| `cat-entity` | The entity in DataModels and its configuration in Infrastructure, for the chosen database. | `--Database` | |
| `cat-table` | The `.sql` table file of a database first service. On SQL Server it goes in the SQL project, on PostgreSQL in the scripts folder. | `--Database` | |
| `cat-dapper-query` | A Dapper query with its handler and its `.sql` file. | | `Cat.Dapper` and `Cat.Dapper.SqlFiles` in Infrastructure, and `<AdditionalFiles Include="**/*.sql" />` in its project file |
| `cat-dapper-command` | A Dapper command with its handler and its `.sql` file. | | The same as `cat-dapper-query` |
| `cat-message` | A message in Contracts, an event or a command. | `--Kind` | `Cat.Messaging.Abstractions` in Contracts |
| `cat-message-handler` | The handler of a received message and a test. Add a `Receive` of the message to the event processor. | `--MessageNamespace` | `Cat.Messaging.Abstractions` in the core |
| `cat-saga` | The state, the workflow, the request and the answer message and a test with the in-memory store. | | `Cat.Sagas` and `Cat.Messaging.Abstractions` in the core, `Cat.UnitTesting.Messaging` in the tests |

Item templates write into the projects of an existing service, so they need the folder layout that `cat-service` makes.

## Add a project
Two templates add a project and not a file. They write the project folder in the folder of the solution. Add the project to the solution yourself with `dotnet sln add`.

| Template | Writes | Needs |
|----------|--------|-------|
| `cat-api-client` | `Name.Api.Client`, the project that holds the generated client of a service. The first build copies the NSwag settings to `nswag.json`. | The package version of `Cat.Api.Client` in `Directory.Packages.props` |
| `cat-gateway` | `Name.Api.Gateway`, the host of `Cat.Api.Gateway`, with a `CatGateway` section in `appsettings.json`. Takes `--Framework`. | The package version of `Cat.Api.Gateway` in `Directory.Packages.props` |

## What a developer adds after the template
The templates stay small on purpose. They do not write registrations in `Program.cs`, they do not add packages and they do not add an endpoint. A developer or a skill adds those. An endpoint is a `MapCat` line in the endpoints file of the service, and a registration is a line in the file where the service registers its modules.

## Package versions
The generated solution has a `Directory.Packages.props` with the versions of the CAT packages of the release, in the property `CatVersion`. It also has the versions of the packages that follow .NET, such as EF Core and ASP.NET Core, for the chosen target framework. A developer updates the versions in this one file.

## How the templates are tested
The test project `tests/Cat.Templates.TemplateTests` installs the pack into its own template hive and creates services in a temp folder. It builds them against the packed modules and runs their own tests.
- `ServiceTemplateTests` runs every combination of database, approach and framework with every option off, then all on, and each option on alone. It also checks the `--NewSolution false` case.
- `ItemTemplateTests` runs every item template in a service, checks the files, builds and runs the tests, for code first and database first on both databases and for a service without tests.

The tests need the packs that Cake makes, so they are skipped when the packs are missing. Run them with `dotnet cake --target=TemplateTest`. The target depends on `Pack`, and `Publish` depends on it, so a template that no longer builds against a changed module is never published.
