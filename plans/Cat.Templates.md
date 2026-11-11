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

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-cattemplates)
<!-- region end: StatusBadge-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
- [Phase 1](#phase-1)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
`dotnet new` templates that create a new service with the project structure of the toolkit.

#### The idea
Every service in the architecture is built from the same set of projects, wired the same way. Making a new service by hand means creating up to nine projects, setting the references right and writing the same startup code. A `dotnet new` template does it in one command.

#### Background
From the readme:
- The service project structure has these projects: Api (required), Scheduler (optional), EventProcessor (optional), CoreService (required), Infrastructure (required), Contracts (required), DataModels (required), Infrastructure.DataAccessTooling (optional) and CoreService.Tests (optional).
- The reference rules: dependencies point inwards, the core only references the abstractions of the CAT modules, the API is the only place where everything is wired together, and Contracts stays small.
- A service is either code first (hand written entities, migrations in Infrastructure) or database first (scaffolded entities and context through the DataAccessTooling project).
- The Api has a development endpoint group in debug mode, with a sub group per worker.
- `Cat.Demo.CatalogService` is a small working example of the structure.

From the repository:
- The `cat-internal-create-demo-unit` skill describes the folder and solution rules for demo services, including `CleanArchitectureToolkit.slnx`.
- `demo/Directory.Build.props` sets the language version and nullable context.
- The demo services show the startup wiring: `AddServiceDefaults`, `AddCatMinimalApiModule`, `AddCatServiceRequestsModule` with the decorators, queries, commands, validators and the database registration.

From the demo plan:
- Orders adds workflows and event subscribers, Inventory is database first, and Notifications needs workers. These are the variations a template needs.
- The AppHost references the Api project of each service, so a new service also needs a line there.

#### What exists today
- The templates do not exist yet. They are listed in the repo overview of the readme as tooling with the status New.
- The repository has no template project and no `template.json`. The demo services are the working examples to build from.
- The `Skills` plan asks who scaffolds a new service, the template or a skill. See [Skills.md](Skills.md).

#### Decided
- **Form.** `dotnet new` templates.
- **Content.** The service project structure of the readme.
- **Optional parts.** Scheduler, EventProcessor, DataAccessTooling and Tests stay optional.
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
Which options matter most? The parameters under discussion are the service name, code first or database first, include scheduler, include event processor, include tests, and include a first example request. The options for the first version:
- **Service name, data approach and tests.** The workers need modules that do not exist yet (`Cat.Scheduling`, `Cat.EventProcessor`). Cost: no worker options until those exist.
- **All of them from the start.** Cost: the worker options would produce projects that cannot do anything.

Recommendation: service name, code first or database first, include tests, and an include-example flag. Add the scheduler and event processor options when their modules are built. The example request is useful, because it proves the template builds and runs.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Do we want the template to wire in all the usual modules, or only the minimum? Modules registered in `Program.cs` depend on the options. The options:
- **The minimum:** Minimal API, service requests, responses and validators. Cost: a developer adds the rest, with the future skill (see [Skills.md](Skills.md)).
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

Recommendation: yes, from Catalog, with the book parts replaced by one generic example request. Catalog has a code first structure, so the database first variant needs Inventory as a second source.
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

Recommendation: the readme and the `.http` file, which the demo already has. Leave the Dockerfile and deployment out, because they depend on how the developer deploys, and health endpoints come with `ServiceDefaults` or the developer's own setup.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Do we also need templates for single parts, such as a new service request with its handler and validator? The options:
- **Yes, item templates** (`dotnet new cat-command`). Cost: more templates, and they overlap with the skills.
- **No,** the skills handle single parts (see [Skills.md](Skills.md)). Cost: it needs Claude.

Recommendation: no, for now. A skill can add a part to an existing project, which is something a template cannot do well, so the service template and the skills split the work: template for the whole, skills for the parts.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Should the template wait until most of the other future modules exist, so it can include them? The options:
- **Build now** with the modules that exist (commands, queries, responses, validators, service requests, Minimal API) and add options later. Cost: updates of the template pack.
- **Wait.** Cost: no template for a long time, while the structure is stable already.

Recommendation: build now. The service structure is decided in the readme, and the options of question 2 let the template grow with the modules.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
The template references the published NuGet packages of the CAT modules. Which version, and how does the template stay current? The options:
- **A floating version** (`10.*` or the latest). Cost: a surprise when a new alpha is published.
- **The version at the time of the template release,** and a new template pack per module release. Cost: a template release each time, which the release workflow can do.
- **Central package management** with a `Directory.Packages.props` in the generated solution. Cost: one more file, but it gives the developer one place to update.

Recommendation: central package management with the version of the day, and the template pack built from the same tag in the release workflow. A developer then updates versions in one file.
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
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->