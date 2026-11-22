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
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
`dotnet new` templates that create a new service with the project structure of the toolkit, and the single parts of a service that the skills of [Cat.Skills.md](Cat.Skills.md#phase-1) use.

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
- **Optional parts.** The tests project stays optional, and the workers are an option of the Api host. There is no DataAccessTooling project (owner, 2026-11-21).
- **Database first.** It has the same projects as code first. The scaffolded entities live in DataModels, as the hand written entities of code first do. The schema lives in an SDK-style SQL project of the service with the `Microsoft.Build.Sql` SDK, such as `Cat.Demo.InventoryService.Database` in the demo (owner, 2026-11-22).
- **The skills use the templates.** Every file that a skill for developers creates comes from a `dotnet new` template, see [Cat.Skills.md](Cat.Skills.md#phase-1). A skill does what a template cannot: pick the project and the folder, change existing files such as the registration in `Program.cs`, add the test, run the build and explain the next step (owner, 2026-11-21).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->

<!-- region start: Question 1-->
#### Question 1
Should it be one template with options, or separate templates? This is the blocking question. Questions 2, 3 and 9 follow from it. The options:
- **One service template with options** (code first or database first, workers, tests). Cost: a more complex `template.json`, with conditions in the files.
- **Separate templates** for code first and database first. Cost: two copies of the common parts that drift apart.
- **One template for the common core and add on templates for the parts** (a worker, a data access tooling project). Cost: more templates to install and to explain.

Recommendation: one template with options. `dotnet new` supports conditional content and parameters, and the structure is the same for every service. The differences (code first or database first) are small and map to one choice parameter.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Which options matter most? The parameters under discussion are the service name, code first or database first, include scheduled jobs, include message handlers, include tests, and include a first example request. The workers run in the Api host, and `Cat.Scheduling` and `Cat.EventProcessor` exist. The options for the first version:
- **Service name, data approach and tests.** Cost: a developer adds the workers to the Api host by hand or with a skill.
- **All of them from the start.** Cost: more conditions in the template, and the build test of question 13 runs for more combinations.

Recommendation: all of them. The worker modules exist, a worker option only adds code to the Api host and no project, and the example request proves that the template builds and runs.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Do we want the template to wire in all the usual modules, or only the minimum? Modules registered in `Program.cs` depend on the options. The options:
- **The minimum:** Minimal API, service requests, responses and validators. Cost: a developer adds the rest, with the future skill (see [Cat.Skills.md](Cat.Skills.md#phase-1)).
- **All the usual ones:** also commands, queries, decorators and logging. Cost: a developer who does not want a module has to remove it, which goes against the toolbox rule.
- **A parameter per module.** Cost: a lot of conditions in the template.

Recommendation: the minimum that the example request needs, plus commands and queries, since the structure has an Infrastructure project for the handlers. Everything else is an add by the developer or by a skill.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Which Aspire parts, if any, may the template include? The modules never depend on Aspire, so the template would only do it as an option. The options:
- **None.** The template creates the service only. Cost: a developer adds `ServiceDefaults` and the AppHost line by hand.
- **An option `--aspire`** that references an existing `ServiceDefaults` project and adds a line in an existing AppHost. Cost: a template cannot edit an AppHost safely, so it can only print what to add.
- **An option that also creates a `ServiceDefaults` project.** Cost: the template then holds Aspire code that has to stay current.

Recommendation: none in the first version, and a readme in the generated service with the three lines to add. The `cat-internal-create-demo-unit` skill does the same by hand for the demo, which shows how much the wiring varies.

`Cat.Resilience` and `Cat.Telemetry` are the base that `ServiceDefaults` calls, and a project without Aspire calls them in its `Program`, see the [module readme of Cat.Resilience](../modules/Cat.Resilience/README.md#without-aspire) and the [module readme of Cat.Telemetry](../modules/Cat.Telemetry/README.md#without-aspire). A template without Aspire could add those two calls.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
How do we keep the template and the Catalog demo in sync? The demo and the template can drift apart. The options:
- **Generate the template from the Catalog demo.** A build step copies the demo and replaces names. Cost: a generator to build, and the demo must stay generic.
- **Test it in the build.** The template is hand made, and a test creates a service and builds it (see question 13). Cost: it catches breaks, not drift.
- **Both.** Cost: the most work, with the most safety.

Recommendation: the test in the build first (question 13), because it is the cheapest and catches the most painful failure. A generator can follow if drift shows up.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Do we build it from the demo, as the first working example? The options:
- **Yes, from `Cat.Demo.CatalogService`.** The modules came from working code, and this is the same idea. Cost: the template carries the demo's choices (names, a book example).
- **From scratch,** guided by the readme. Cost: a new design with no proof that it works.

Recommendation: yes, from Catalog, with the book parts replaced by one generic example request. Catalog has a code first structure on SQL Server, so the database first variant needs Inventory as a second source, and the PostgreSQL variant of question 17 needs Notifications.
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
Should it create the solution file too, and in which format? The options:
- **Create a `.slnx` only.** It is the new format, and this repository uses it. Cost: older tools may not read it.
- **Both `.sln` and `.slnx`.** Cost: two files to keep in step.
- **Do not create one,** and add to an existing solution if one is given. Cost: `dotnet new` can run `dotnet sln add` as a post action, which needs a file to exist.

Recommendation: a parameter with the default of creating a `.slnx`, and a post action that adds to an existing solution when the developer asks. Check the support of `.slnx` in `dotnet new` before building.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
Do we include a Dockerfile and deployment files for Azure Container Apps? Other extras to consider are health endpoints, an `.http` file and a readme. The options:
- **A readme and an `.http` file only.** Cost: no deployment help.
- **Plus a Dockerfile.** Cost: one more file that depends on the .NET version and the repository layout.
- **Plus deployment files** (Bicep or `azd`). Cost: this is the platform of the developer, not of the toolkit.

Recommendation: the readme and the `.http` file, which the demo already has, plus `/health` and `/alive` with the database check that every demo service has, because `Cat.Telemetry` leaves health checks to the service. Leave the Dockerfile and deployment out, because they depend on how the developer deploys.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Which single parts get an item template? The skills create every file through a template, so each part that a skill adds needs one, such as `dotnet new cat-command`. The options:
- **The parts of the first skills,** a command, a query, a service request and a validator, each with its handler and test. More follow with each new skill. Cost: a template per part, each with the build test of question 13.
- **One item template with a choice parameter** for the kind of part. Cost: one large template with many conditions.

Recommendation: one item template per part, starting with the parts of the first skills of [Cat.Skills.md](Cat.Skills.md#phase-1). A small template is easy to test, and a skill calls exactly the one it needs.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Should the template wait until most of the other future modules exist, so it can include them? The options:
- **Build now** with the modules that exist (see the Background) and add options later. Cost: updates of the template pack.
- **Wait.** Cost: no template for a long time, while the structure is stable already.

Recommendation: build now. The service structure is decided in the readme, and the options of question 2 let the template grow with the modules.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
The template references the published NuGet packages of the CAT modules. Which version, and how does the template stay current? The options:
- **A floating version** (`10.*` or the latest). Cost: a surprise when a new alpha is published.
- **The version at the time of the template release,** and a new template pack per module release. Cost: a template release each time, which the release workflow can do.
- **Central package management** with a `Directory.Packages.props` in the generated solution. Cost: one more file, but it gives the developer one place to update.

Recommendation: central package management with the version of the day, with one group per target framework as in `Directory.Packages.props` of this repository (see question 16), and the template pack built from the same tag in the release workflow. A developer then updates versions in one file.
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Is the company or product prefix a parameter? Do names follow `ServiceName.Api` exactly? The options:
- **A single `name` parameter** that becomes `Name.Api`, `Name.CoreService` and so on, with the readme's structure. Cost: a developer who wants `Company.Product.Service.Api` types the whole prefix as the name.
- **Separate prefix and service parameters.** Cost: one more parameter to explain.

Recommendation: one name parameter, because `dotnet new` already replaces its source name everywhere, and a prefix can be part of it (`Company.Product.Orders`). It follows the structure of the readme exactly.
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
How do we test the template itself? The options:
- **A build test** that creates a service from the template in a temp folder and compiles it (and runs the generated unit tests). Cost: slower tests, and it needs the packages of the modules, so it runs after a build.
- **A manual check at release.** Cost: easy to forget.

Recommendation: the build test. Cake can run it as a target next to the tests, and it is the main protection against drift (question 5). `tests/` holds module tests, so it can live there as a test project that is skipped without the packages.
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
How is the template distributed? One idea is a NuGet template pack. What are the package id and the install command? The options:
- **A NuGet template pack** such as `Cat.Templates`, installed with `dotnet new install Cat.Templates`. Cost: none, the release workflow already publishes packages (a template pack has its own packing, to check).
- **A git repository** that a developer clones. Cost: no versioning, no update command.

Recommendation: a NuGet template pack, with the package id `Cat.Templates`, and the short name `cat-service`. Check that the release workflow can pack it without publishing every module package again.
<!-- region end: Question 14-->

<!-- region start: Question 15-->
#### Question 15
Do we also want a solution template, a whole system with a gateway and a first service? The options:
- **Yes.** A system in one command, as the demo is. Cost: it needs Aspire, the gateway and a lot of decisions that depend on the developer's situation.
- **No,** only the service template. Cost: a developer builds the system around it, as the readme describes.

Recommendation: no, for now. It is a bigger version of question 4 (Aspire) and question 3 (which modules), and those are not answered. Revisit after the service template exists.
<!-- region end: Question 15-->

<!-- region start: Question 16-->
#### Question 16
Which target framework does a generated service get? The modules support .NET 10 and .NET 11, see the target framework rule in `CLAUDE.md`, and the demo stays on .NET 11. The options:
- **`net11.0` only.** Cost: a developer on the .NET 10 LTS release edits every project file after the template ran.
- **A choice parameter,** `net10.0` or `net11.0`, with the package versions of question 11 per choice. Cost: the template holds both sets of versions, and the build test of question 13 runs for both.

Recommendation: a choice parameter with `net11.0` as the default, because the modules support both and a template that forces one framework puts the work on the developer.
<!-- region end: Question 16-->

<!-- region start: Question 17-->
#### Question 17
Which database does a generated service use? The SQL Server code of the toolkit has a PostgreSQL counterpart, except temporal tables and `Cat.Sql.Cdc`, and the demo runs Notifications on PostgreSQL. The options:
- **A choice parameter,** SQL Server or PostgreSQL, with SQL Server as the default. Cost: the build test of question 13 runs for both.
- **SQL Server only.** Cost: a developer on PostgreSQL changes the provider and the packages by hand.

Recommendation: the choice parameter. The toolkit supports both, so the template should not force one.
<!-- region end: Question 17-->

<!-- region start: Question 18-->
#### Question 18
Does the template create an `Api.Client` project, which other services use to call the new service? Catalog and Inventory have one, and the readme structure lists it as an optional project. The options:
- **An option, off by default.** Cost: one more condition.
- **Always.** Cost: a project that a service nobody calls does not need.
- **Never.** Cost: a developer adds it by hand when another service starts to call this one.

Recommendation: an option, off by default. A new service often has no callers yet, and the option gives the same project as in the demo when it does.
<!-- region end: Question 18-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->