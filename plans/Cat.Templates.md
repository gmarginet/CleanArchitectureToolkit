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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Plans for Cat.Templates

`dotnet new` templates that create a new service with this project structure.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Every service in the architecture is built from the same set of projects, wired the same way. Making a new service by hand means creating up to nine projects, setting the references right and writing the same startup code. A `dotnet new` template does it in one command.

## What we already know

From the root readme:

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

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Form | `dotnet new` templates. |
| Content | The service project structure of the root readme. |
| Optional parts | Scheduler, EventProcessor, DataAccessTooling and Tests stay optional. |

### Open

- **One template or several.** One service template with options, or separate ones for code first and database first?
- **Parameters.** Service name, code first or database first, include scheduler, include event processor, include tests, include a first example request?
- **Wiring.** How much startup code does it generate? Modules registered in `Program.cs` depend on the options.
- **Package versions.** Reference the published NuGet packages of the CAT modules. Which version, and how does the template stay current?
- **Staying in sync.** The demo and the template can drift apart. Do we generate the template from the Catalog demo, or test it in the build?
- **Naming.** Is the company or product prefix a parameter? Do names follow `ServiceName.Api` exactly?
- **Solution.** Create a solution file or add to an existing one? Both `.sln` and `.slnx`?
- **Aspire.** Optionally add the service to an AppHost and use ServiceDefaults? The modules never depend on Aspire, so the template would only do it as an option.
- **Extras.** A Dockerfile for Azure Container Apps, health endpoints, an `.http` file, a readme?
- **Tests of the template.** A build test that creates a service from the template and compiles it.
- **Distribution.** A NuGet template pack. Package id and install command.
- **Also a solution template.** A whole system with gateway and first service?

## Questions before building

1. Should it be one template with options, or separate templates?
2. Which options matter most: workers, code first or database first, tests?
3. Do you want the template to wire in all the usual modules, or only the minimum?
4. Which Aspire parts, if any, may the template include?
5. How do we keep the template and the Catalog demo in sync?
6. Do we build it from the demo, as the first working example?
7. Should it create the solution file too, and in which format?
8. Do we include a Dockerfile and deployment files for Azure Container Apps?
9. Do we also need templates for single parts, such as a new service request with its handler and validator?
10. Do you want the template to wait until most of the other future modules exist, so it can include them?
