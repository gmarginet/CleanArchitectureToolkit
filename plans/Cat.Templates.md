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

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-plan skill to update this plan.-->
<!-- region end: TemplateSkill-->

# Plans for `Cat.Templates` <!-- omit in toc -->  

<!-- region start: FirstStableVersion-->
**First stable version:** not reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 1](#phase-1)
- [Phase 2](#phase-2)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
`dotnet new` templates that create a new service with the project structure of the toolkit, and the single parts of a service that the skills of [Cat.ClaudeSkills.md](Cat.ClaudeSkills.md#phase-1) use.

#### The idea
Every service in the architecture is built from the same set of projects, wired the same way. Making a new service by hand means creating several projects, setting the references right and writing the same startup code. A `dotnet new` template does it in one command. The skills for developers create every file through these templates, so the shape of a file has one source that the build tests.

In this plan, "template" always means a `dotnet new` template. The markdown templates of the owner skills are a different thing.

#### Background
From the readme:
- The service project structure lists `ServiceName.Api`, `ServiceName.CoreService`, `ServiceName.Infrastructure`, `ServiceName.Contracts` and `ServiceName.DataModels` as required, and `ServiceName.Api.Client` and `ServiceName.CoreService.Tests` as optional.
- `ServiceName.Api.Client` holds the generated client that other services use to call the service. It references only the `Cat.Api.Client` module.
- The Api is the host that handles HTTP requests and runs the background workers, when the service has them. In development, each worker has its own endpoint group.
- The reference rules: dependencies point inwards, the core only references the abstractions of the CAT modules, the API is the only place where everything is wired together, and Contracts stays small.

From the demo:
- The workers run in the Api host.
- Catalog is code first, with hand written entities in DataModels and migrations in Infrastructure.
- Inventory is database first. Its schema comes from SQL scripts in the folder `Cat.Demo.InventoryService.Database`, which is not a project, and the AppHost runs them. Its scaffolded entities live in `Cat.Demo.InventoryService.DataModels`, and its scaffolded `InventoryDbContext` in Infrastructure.
- Catalog and Inventory have an `Api.Client` project that Orders uses to call them through the gateway. The payment provider is outside the shop, so Orders calls it with its own client in Infrastructure. Sharing the `Contracts` of a service is the choice of the developer.
- Orders adds workflows, sagas, message handlers and scheduled jobs. Inventory has a scheduled job and turns stock changes into messages with `Cat.Sql.Cdc`. These are the variations a template needs.
- Catalog, Orders and Inventory run on SQL Server. Notifications is code first on PostgreSQL, with the same `Cat.EFCore` base entity and no temporal table.
- Every demo service adds a database check to its health check.
- The AppHost references the Api project of each service, so a new service also needs a line there.
- `demo/Directory.Build.props` sets the language version and nullable context.

From the repository:
- The modules that exist include `Cat.Commands`, `Cat.Queries`, `Cat.ServiceRequests`, `Cat.Responses`, `Cat.Validators`, `Cat.Minimal.Api`, `Cat.EFCore`, `Cat.Dapper`, `Cat.Messaging`, `Cat.Inbox`, `Cat.Outbox`, `Cat.EventProcessor`, `Cat.Scheduling`, `Cat.Sagas`, `Cat.Users`, `Cat.Api.Client`, `Cat.Resilience`, `Cat.Telemetry`, `Cat.Caching` and `Cat.Localizations`. The repo overview of the readme has the full list.
- Package versions that follow the release of .NET come per target framework from `Directory.Packages.props`, with one group for `netstandard2.0` and `net10.0` and one for `net11.0`, see `CLAUDE.md`.
- SQL Server code in a module gets a PostgreSQL counterpart with the same API, see `CLAUDE.md`. Features that PostgreSQL does not have, such as temporal tables and `Cat.Sql.Cdc`, stay SQL Server only.
- The `cat-internal-create-demo-unit` skill describes the folder and solution rules for demo services, including `CleanArchitectureToolkit.slnx`.

From the module readmes:
- Cat.Resilience and Cat.Telemetry are the base that `ServiceDefaults` calls. A project without Aspire calls them in its `Program`, see the [module readme of Cat.Resilience](../modules/Cat.Resilience/README.md#without-aspire) and the [module readme of Cat.Telemetry](../modules/Cat.Telemetry/README.md#without-aspire).
- Health checks are out of the scope of `Cat.Telemetry`. Its module readme shows the plain ASP.NET Core lines for `/health` and `/alive`, and the demo adds `AddDbContextCheck` per service, see the [demo readme](../demo/README.md).
- The toolkit is in alpha and the demo is the only user, so a breaking change is allowed (owner, 2026-11-21).

#### What exists today
- The templates do not exist yet. They are listed in the repo overview of the readme as tooling with the status New.
- The repository has no template project and no `template.json`. The demo services are the working examples to build from.

#### Needs
- The SQL project of Inventory, see [Cat.Demo.md](Cat.Demo.md#phase-2). The database first part of the template follows it.

#### Decided
- **Form.** `dotnet new` templates.
- **Content.** The service project structure of the readme.
- **One service template.** One template with options, such as code first or database first as one choice parameter, and the workers and the tests as flags. No separate templates per variant and no add on templates for parts of a service (owner, 2026-11-22).
- **Options of the first version.** The service name, code first or database first, scheduled jobs, message handlers, tests and a first example request. The worker options only add code to the Api host and no project. The example request proves that the generated service builds and runs (owner, 2026-11-22).
- **Api.Client project.** An option, off by default. It creates `Name.Api.Client`, the same project that Catalog and Inventory have in the demo, for a service that other services call (owner, 2026-11-22).
- **Wired modules.** `Program.cs` wires what the example request needs: `Cat.Minimal.Api`, `Cat.ServiceRequests`, `Cat.Responses` and `Cat.Validators`, plus `Cat.Commands` and `Cat.Queries` for the handlers in Infrastructure. The worker modules are wired only when their option is on. A developer or a skill adds every other module (owner, 2026-11-22).
- **No Aspire.** The template holds no Aspire code. `Program.cs` calls `Cat.Resilience` and `Cat.Telemetry` directly, as their module readmes show for a project without Aspire. A readme in the generated service shows the lines to add for `ServiceDefaults` and the AppHost (owner, 2026-11-22).
- **Drift from the demo.** The template is written by hand, and a build test protects it. No generator that copies the demo for now. A generator can follow if drift shows up (owner, 2026-11-22).
- **Built from the demo.** `Cat.Demo.CatalogService` is the base, with the book parts replaced by one generic example request. Database first comes from Inventory, and a PostgreSQL variant comes from Notifications (owner, 2026-11-22).
- **Solution file.** By default the template creates a new `.slnx`. A parameter points to an existing solution instead, and a post action adds the projects to it (owner, 2026-11-22). To check before the build: the support of `.slnx` in `dotnet new` and in `dotnet sln add`.
- **Extras.** A readme, an `.http` file for the Api, and `/health` and `/alive` with a database check, as every demo service has. No Dockerfile and no deployment files, because they depend on how the developer deploys (owner, 2026-11-22).
- **Item templates.** One item template per part, each with its handler and its test, such as `dotnet new cat-command`. This plan holds every template that the skills of [Cat.ClaudeSkills.md](Cat.ClaudeSkills.md#phase-1) need, so they all exist before the skills are built. A skill that only changes existing files needs no template (owner, 2026-11-22). The item templates (owner, 2026-11-22):
  - **Handlers:** `cat-command`, `cat-query`, `cat-service-request` and `cat-validator`, each with its test.
  - **Building blocks:** `cat-workflow`, `cat-event` with its subscriber, and `cat-decorator`.
  - **Data:** `cat-entity` with its configuration, for SQL Server or PostgreSQL, `cat-dapper-query` and `cat-dapper-command`, each with its `.sql` file, and `cat-error-definitions`, the static class with the error definitions of a service and its prefix, such as `OrderErrorDefinitions` in the demo.
  - **Messaging:** `cat-message`, `cat-message-handler` and `cat-saga`.
  - **Projects:** `cat-api-client` and `cat-gateway`, as project templates, because they add a project and not a file.
  - **No template, because the skill only changes existing files:** an endpoint is a `MapCat` line in the endpoints file of the service, such as `CatalogEndpoints.cs`. Caching a query, a translation and an own telemetry source are each a line in an existing registration.
  - **Reused templates:** a scheduled job is a service request plus a `scheduler.Job` line, so `cat-add-job` uses `cat-service-request`. A CDC mapping is an event message plus an `AddTable` line, so `cat-add-cdc` uses `cat-message`.
- **No wait for future modules.** The templates use the modules that exist now. New modules come in later as new options in an update of the template pack (owner, 2026-11-22).
- **Package versions.** The generated solution gets a `Directory.Packages.props` with the versions of the CAT packages of the release, and the versions of the packages that follow .NET for the chosen target framework, as in `Directory.Packages.props` of this repository. The release workflow builds the template pack from the same tag as the modules. A developer updates the versions in one file (owner, 2026-11-22).
- **Naming.** One name parameter, and the projects follow the service project structure of the readme exactly. A prefix is part of the name: `-n Contoso.Shop.Orders` gives `Contoso.Shop.Orders.Api`, `Contoso.Shop.Orders.CoreService` and so on (owner, 2026-11-22).
- **Build test.** A test project in `tests/` installs the template pack, creates a service for each combination of options in a temp folder, builds it and runs its generated tests. The item templates get the same test. It needs the packed module packages, so Cake runs it after the packages are packed, and it is skipped when they are missing (owner, 2026-11-22).
- **Database.** A choice parameter, SQL Server or PostgreSQL, with SQL Server as the default. The build test runs for both (owner, 2026-11-22).
- **Target framework.** A choice parameter, `net10.0` or `net11.0`, with `net11.0` as the default. `Directory.Packages.props` gets the package versions of the chosen framework, and the build test runs for both (owner, 2026-11-22).
- **Solution template.** A template for a whole system follows in [phase 2](#phase-2). This phase builds only the service template and the item templates (owner, 2026-11-22).
- **Distribution.** A NuGet template pack with the package id `gmarginet.Cat.Templates`, installed with `dotnet new install gmarginet.Cat.Templates`. It uses the same `gmarginet.` prefix as every module package, which `Directory.Build.props` sets. The service template has the short name `cat-service` (owner, 2026-11-22). To check before the build: that the release workflow can pack the template pack without publishing every module package again.
- **Optional parts.** The tests project stays optional, and the workers are an option of the Api host. There is no DataAccessTooling project (owner, 2026-11-21).
- **Database first.** It has the same projects as code first. The scaffolded entities live in DataModels, as the hand written entities of code first do. The schema lives in an SDK-style SQL project of the service with the `Microsoft.Build.Sql` SDK, such as `Cat.Demo.InventoryService.Database` in the demo (owner, 2026-11-22).
- **Database first on PostgreSQL.** The `Microsoft.Build.Sql` SDK only builds SQL Server schemas, so on PostgreSQL the schema lives in plain SQL scripts in a folder of the service. The developer runs them by hand, and the readme of the generated service shows the `psql` command. The generated service holds no code that applies schema changes (owner, 2026-11-22).
- **The skills use the templates.** Every file that a skill for developers creates comes from a `dotnet new` template, see [Cat.ClaudeSkills.md](Cat.ClaudeSkills.md#phase-1). A skill does what a template cannot: pick the project and the folder, change existing files such as the registration in `Program.cs`, add the test, run the build and explain the next step (owner, 2026-11-21).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
A `dotnet new` solution template that creates a whole system in one command, as the demo is.

#### Needs
- The service template, see [phase 1](#phase-1). The solution template creates its first service with `cat-service`.

#### Decided
- **A solution template.** Next to the service template, the pack gets a template for a whole system (owner, 2026-11-22).
- **Its own phase.** It is built after phase 1 and reuses every decision of `cat-service` (owner, 2026-11-22).
- **Parts.** An AppHost, `ServiceDefaults`, a YARP gateway like `Cat.Demo.Api.Gateway` in the demo, and a first service made with `cat-service`, wired into the AppHost and the gateway. No web client, because the front end is the choice of the developer. The template holds Aspire code, which is allowed because it is not a module (owner, 2026-11-22).
- **PostgreSQL scripts.** For a database first service on PostgreSQL, the AppHost runs the plain SQL scripts of the service, as the demo AppHost did for Inventory (owner, 2026-11-22).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->