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
- The `demo-structure` skill describes the folder and solution rules for demo services, including `CleanArchitectureToolkit.slnx`.
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
Should it be one template with options, or separate templates? For example one service template with options, or separate ones for code first and database first.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Which options matter most: workers, code first or database first, tests? The parameters under discussion are the service name, code first or database first, include scheduler, include event processor, include tests, and include a first example request.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Do we want the template to wire in all the usual modules, or only the minimum? Modules registered in `Program.cs` depend on the options.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Which Aspire parts, if any, may the template include? Can it optionally add the service to an AppHost and use ServiceDefaults? The modules never depend on Aspire, so the template would only do it as an option.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
How do we keep the template and the Catalog demo in sync? The demo and the template can drift apart. Do we generate the template from the Catalog demo, or test it in the build?
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Do we build it from the demo, as the first working example?
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
Should it create the solution file too, and in which format? Does it create a solution file or add to an existing one? Both `.sln` and `.slnx`?
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
Do we include a Dockerfile and deployment files for Azure Container Apps? Other extras to consider are health endpoints, an `.http` file and a readme.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Do we also need templates for single parts, such as a new service request with its handler and validator?
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Should the template wait until most of the other future modules exist, so it can include them?
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
The template references the published NuGet packages of the CAT modules. Which version, and how does the template stay current?
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Is the company or product prefix a parameter? Do names follow `ServiceName.Api` exactly?
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
How do we test the template itself? One idea is a build test that creates a service from the template and compiles it.
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
How is the template distributed? One idea is a NuGet template pack. What are the package id and the install command?
<!-- region end: Question 14-->

<!-- region start: Question 15-->
#### Question 15
Do we also want a solution template, a whole system with a gateway and a first service?
<!-- region end: Question 15-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->