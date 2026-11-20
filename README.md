<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: . -->
<link href="./resources/styles/style.css" rel="stylesheet" />
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
            <img src='./resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](./README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](./README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](./demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-readme skill to update this readme.-->
<!-- region end: TemplateSkill-->

# Clean Architecture Toolkit for .NET <!-- omit in toc -->  

## Table of contents <!-- omit in toc -->  
<!-- region start: TableOfContents-->
- [Getting Started](#getting-started)
- [About this project](#about-this-project)
- [Repo overview](#repo-overview)
- [Application Architecture](#application-architecture)
  - [Clients](#clients)
  - [API gateway](#api-gateway)
  - [Services](#services)
  - [Communication between services](#communication-between-services)
  - [Database](#database)
  - [How a request flows through the system](#how-a-request-flows-through-the-system)
  - [Design principles](#design-principles)
  - [How the modules fit in](#how-the-modules-fit-in)
- [Service Project structure](#service-project-structure)
  - [Overview](#overview)
  - [ServiceName.Api](#servicenameapi)
  - [ServiceName.CoreService](#servicenamecoreservice)
  - [ServiceName.Infrastructure](#servicenameinfrastructure)
  - [ServiceName.Contracts](#servicenamecontracts)
  - [ServiceName.DataModels](#servicenamedatamodels)
  - [ServiceName.CoreService.Tests](#servicenamecoreservicetests)
  - [Reference rules](#reference-rules)
<!-- region end: TableOfContents-->

## Getting Started
<!-- region start: GettingStarted-->

[![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/gmarginet/CleanArchitectureToolkit/build.yml)](#getting-started) 
[![nuget](https://img.shields.io/nuget/v/gmarginet.Cat.ServiceRequests)](#getting-started) 
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](./MIT-License.md)  

The `Clean Architecture Toolkit for .NET` contains a set of modules.  
Most of the modules can be used independently.  
Some modules depend on other modules, in the documentation of each module you can find the list of the dependencies.  
A package targets `netstandard2.0` where possible and otherwise `net10.0` and `net11.0`. The package table of each module shows which. EF Core 10 and 11 are supported, and the demo runs on .NET 11.  
<!-- region end: GettingStarted-->

## About this project
<!-- region start: AboutThisProject-->

> <img src="https://github.com/gmarginet.png?size=120" alt="Gert Marginet" width="120" align="right" style="border-radius: 50%; margin: 13px 0 10px 15px;" />
> <div style="height: 16px;"></div>
>
> **A note from the author**  
> I build the Clean Architecture Toolkit in my free time.  
> Did you find an issue? Please [create an issue](https://github.com/gmarginet/CleanArchitectureToolkit/issues) on GitHub.  
> I will do my best to fix it as soon as possible, but I can not guarantee a due date.  
>
> **About me**  
> I'm Gert Marginet, a .NET software architect from Geraardsbergen, Belgium.  
> I have over twenty years of experience in software development, architecture and team leading.  
> I studied electronics and started out as a software engineer in 1997. Since then I have designed custom architectures and application frameworks for .NET.  
> Outside of work you find me hiking in nature or keeping ants, where I design and 3D-print their nests and outworlds myself.  
>
> [Project Website](https://gmarginet.github.io/CleanArchitectureToolkit/) &#124; [Personal Website](https://gert.marginet.be/) &#124; [LinkedIn](https://www.linkedin.com/in/gertmarginet/) &#124; [GitHub](https://github.com/gmarginet)
> <div style="height: 1px;"></div>
<!-- region end: AboutThisProject-->

## Repo overview
<!-- region start: RepoOverview-->

> #### Module statuses
> - **<ins>New</ins>**: not started yet.  
> - **<ins>Building</ins>**: building has started but the first stable version is not reached. <sup>(Breaking changes are possible.)</sup>  
> - **<ins>Growing</ins>**: the first stable version is reached, and extra features are planned. <sup>(Breaking changes are not expected.)</sup>  
> - **<ins>Stable</ins>**: fully built.  

| Name | Description |  |  |  |
|------|-------------|:-:|:-:|:-:|
| Cat.Api.Client | <a id="cat-api-client"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-api-client) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-api-client) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Api.Client/README.md)<br>Call another service through the API gateway with a typed client, and get the outcome back as a response. [Read more](./modules/Cat.Api.Client/README.md) |  |  |  |
| Cat.Api.Gateway | <a id="cat-api-gateway"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-api-gateway) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-api-gateway) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Api.Gateway/README.md)<br>The single front door of an application. It routes the calls of clients and services to the right service, checks the token in one place and builds on YARP. [Read more](./modules/Cat.Api.Gateway/README.md) |  |  |  |
| Cat.Caching | <a id="cat-caching"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-caching) [![New](https://img.shields.io/badge/status-New-blue)](#cat-caching)<br>A caching decorator for queries. | 10 | [1](./plans/Cat.Caching.md#phase-1) | 16 |
| Cat.Commands | <a id="cat-commands"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-commands) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-commands) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Commands/README.md)<br>Change state through one entry point. Describe a change as a command, write one handler for it, and let the processor find the handler. [Read more](./modules/Cat.Commands/README.md) |  |  |  |
| Cat.Dapper | <a id="cat-dapper"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-dapper) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-dapper) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Dapper/README.md)<br>Write query and command handlers with plain SQL and Dapper, with one connection and one transaction for each scope. [Read more](./modules/Cat.Dapper/README.md) |  |  |  |
| Cat.Db.Errors | <a id="cat-db-errors"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-db-errors) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-db-errors) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Db.Errors/README.md)<br>Recognize database errors by their number or code, one project per database, shared by the EF Core and Dapper modules. [Read more](./modules/Cat.Db.Errors/README.md) |  |  |  |
| Cat.Decorators | <a id="cat-decorators"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-decorators) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-decorators) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Decorators/README.md)<br>Wrap handlers in decorators for cross-cutting work like logging, validation or tracing. [Read more](./modules/Cat.Decorators/README.md) |  |  |  |
| Cat.EFCore | <a id="cat-efcore"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-efcore) [![Growing](https://img.shields.io/badge/status-Growing-yellowgreen)](#cat-efcore) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.EFCore/README.md)<br>Configure Entity Framework Core entities the same way every time, and write query and command handlers on top of them with a base class. [Read more](./modules/Cat.EFCore/README.md) | 14 | [3](./plans/Cat.EFCore.md#phase-3) | 0 |
| Cat.EventAggregators | <a id="cat-eventaggregators"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-eventaggregators) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-eventaggregators) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.EventAggregators/README.md)<br>Let parts of your app talk to each other through in-process events, without direct dependencies. [Read more](./modules/Cat.EventAggregators/README.md) |  |  |  |
| Cat.EventProcessor | <a id="cat-eventprocessor"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-eventprocessor) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-eventprocessor) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.EventProcessor/README.md)<br>Worker support that turns incoming messages into service requests. [Read more](./modules/Cat.EventProcessor/README.md) |  |  |  |
| Cat.Expressions | <a id="cat-expressions"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-expressions) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-expressions) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Expressions/README.md)<br>Compile member access expressions once and reuse them, so repeated calls stay fast. [Read more](./modules/Cat.Expressions/README.md) |  |  |  |
| Cat.Extensions | <a id="cat-extensions"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-extensions) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-extensions) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Extensions/README.md)<br>Small extension method libraries for enumerables, expressions, objects, service collections and strings. [Read more](./modules/Cat.Extensions/README.md) |  |  |  |
| Cat.FluentWorkflows | <a id="cat-fluentworkflows"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-fluentworkflows) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-fluentworkflows) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.FluentWorkflows/README.md)<br>Describe a business process as a list of steps in plain C#. [Read more](./modules/Cat.FluentWorkflows/README.md) |  |  |  |
| Cat.IntegrationTesting | <a id="cat-integrationtesting"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-integrationtesting) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-integrationtesting) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.IntegrationTesting/README.md)<br>Integration tests that run on a real SQL Server, PostgreSQL or MySQL in a container, apart from the unit tests. [Read more](./modules/Cat.IntegrationTesting/README.md) |  |  |  |
| Cat.Localizations | <a id="cat-localizations"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-localizations) [![New](https://img.shields.io/badge/status-New-blue)](#cat-localizations)<br>Look up localized strings by key, without tying your app to one localization provider. | 1 | [1](./plans/Cat.Localizations.md#phase-1) | 4 |
| Cat.Messaging | <a id="cat-messaging"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-messaging) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-messaging) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Messaging/README.md)<br>Send messages to other services over Azure Service Bus, with an optional outbox so a message is never lost. [Read more](./modules/Cat.Messaging/README.md) |  |  |  |
| Cat.Minimal.Api | <a id="cat-minimal-api"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-minimal-api) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-minimal-api) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Minimal.Api/README.md)<br>Map service requests to minimal API endpoints that document the responses they return and share one error shape. [Read more](./modules/Cat.Minimal.Api/README.md) |  |  |  |
| Cat.Queries | <a id="cat-queries"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-queries) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-queries) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Queries/README.md)<br>Read data through one entry point. Describe a read as a query, write one handler for it, and let the processor find the handler. [Read more](./modules/Cat.Queries/README.md) |  |  |  |
| Cat.Resilience | <a id="cat-resilience"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-resilience) [![New](https://img.shields.io/badge/status-New-blue)](#cat-resilience)<br>Retry and circuit breaker decorators for calls to other services and integrations. | 4 | [1](./plans/Cat.Resilience.md#phase-1) | 12 |
| Cat.Responses | <a id="cat-responses"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-responses) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-responses) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Responses/README.md)<br>Return the outcome of an operation as a response, either succeeded with a value or failed with errors. [Read more](./modules/Cat.Responses/README.md) |  |  |  |
| Cat.Sagas | <a id="cat-sagas"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-sagas) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-sagas) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Sagas/README.md)<br>Long running workflows that send a message, wait for the answer and carry on. [Read more](./modules/Cat.Sagas/README.md) |  |  |  |
| Cat.Scheduling | <a id="cat-scheduling"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-scheduling) [![Growing](https://img.shields.io/badge/status-Growing-yellowgreen)](#cat-scheduling) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Scheduling/README.md)<br>Worker support that turns schedules into service requests. [Read more](./modules/Cat.Scheduling/README.md) | 5 | [2](./plans/Cat.Scheduling.md#phase-2) | 1 |
| Cat.ServiceRequests | <a id="cat-servicerequests"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-servicerequests) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-servicerequests) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.ServiceRequests/README.md)<br>Run application use cases through one entry point, with validation, logging and tracing decorators. [Read more](./modules/Cat.ServiceRequests/README.md) |  |  |  |
| Cat.Sql.Cdc | <a id="cat-sql-cdc"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-sql-cdc) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-sql-cdc) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Sql.Cdc/README.md)<br>Turns SQL Server change data capture changes into service bus calls. [Read more](./modules/Cat.Sql.Cdc/README.md) |  |  |  |
| Cat.Telemetry | <a id="cat-telemetry"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-telemetry) [![New](https://img.shields.io/badge/status-New-blue)](#cat-telemetry)<br>Shared tracing and metrics setup for all services. | 7 | [1](./plans/Cat.Telemetry.md#phase-1) | 12 |
| Cat.UnitTesting | <a id="cat-unittesting"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-unittesting) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-unittesting) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.UnitTesting/README.md)<br>Helpers for unit tests, like test doubles for processors and responses, in small projects you pick from. [Read more](./modules/Cat.UnitTesting/README.md) |  |  |  |
| Cat.Users | <a id="cat-users"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-users) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-users) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Users/README.md)<br>The shared user abstraction, the user from the claims of a token, and a way for a worker to set the user. [Read more](./modules/Cat.Users/README.md) |  |  |  |
| Cat.Validators | <a id="cat-validators"></a>[![Module](https://img.shields.io/badge/type-Module-yellow)](#cat-validators) [![Stable](https://img.shields.io/badge/status-Stable-green)](#cat-validators) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./modules/Cat.Validators/README.md)<br>Check a model against fluent rules and get every problem back in one response. [Read more](./modules/Cat.Validators/README.md) |  |  |  |
| Cat.Demo | <a id="cat-demo"></a>[![Demo](https://img.shields.io/badge/type-Demo-yellow)](#cat-demo) [![Growing](https://img.shields.io/badge/status-Growing-yellowgreen)](#cat-demo) [![Readme](https://img.shields.io/badge/docs-Readme-lightgrey)](./demo/README.md)<br>A small bookshop with a Catalog service and an Order service. Run it locally and read the code as a working example of the modules. [Read more](./demo/README.md) | 2<br>6<br>8<br>11<br>12<br>13 | [10](./plans/Demo.md#phase-10)<br>[11](./plans/Demo.md#phase-11)<br>[12](./plans/Demo.md#phase-12)<br>[9](./plans/Demo.md#phase-9)<br>[13](./plans/Demo.md#phase-13)<br>[16](./plans/Demo.md#phase-16) | 3<br>4<br>1<br>0<br>0<br>1 |
| Cat.Skills | <a id="cat-skills"></a>[![Tooling](https://img.shields.io/badge/type-Tooling-yellow)](#cat-skills) [![New](https://img.shields.io/badge/status-New-blue)](#cat-skills)<br>Claude Code skills, shipped as a plugin, that teach Claude the CAT conventions in the projects of the developers who use the toolkit. | 3 | [1](./plans/Skills.md#phase-1) | 10 |
| Cat.Templates | <a id="cat-templates"></a>[![Tooling](https://img.shields.io/badge/type-Tooling-yellow)](#cat-templates) [![New](https://img.shields.io/badge/status-New-blue)](#cat-templates)<br>`dotnet new` templates that create a new service with this project structure. | 9 | [1](./plans/Cat.Templates.md#phase-1) | 16 |

<!-- region end: RepoOverview-->

## Application Architecture
<!-- region start: ApplicationArchitecture-->

The modules are built with a certain application architecture in mind.  
It is a set of small services behind one entry point, talking to each other through messages.  
Every service has a clear job, owns its data and keeps its business logic apart from the technology around it.  

You are not required to follow this architecture to use the modules!  
Take what fits your application and leave the rest.  

![Application Architecture](./resources/schemas/CatArchitecture.excalidraw.svg)

The diagram shows the building blocks and how they talk to each other.  

### Clients

Clients are the applications people use, like a web app, a mobile app or a desktop app.  
They know nothing about the services behind the gateway.  

- Clients only talk to the API gateway.  
- Clients never call a service directly.  
- Clients never touch the database.  

### API gateway

The API gateway is the single front door of the application.  
It receives every request from the clients, and every call between services, and forwards it to the right service.  

- Clients need to know one address, not one per service.  
- Cross-cutting concerns like authentication and routing live in one place.  
- The gateway holds no business logic. It only routes.  

### Services

A service is a small, independently deployable application with one clear responsibility.  
Services are where the business logic lives.  

- Each service is built, deployed and scaled on its own.  
- Each service owns its data and decides how it is stored. No other service reads or writes it directly.  
- Services expose their functionality through an API.  
- Services handle use cases as service requests, and split reads (queries) from writes (commands).  

The [Service Project structure](#service-project-structure) chapter explains how the projects of a single service are organized.  

### Communication between services

Services talk to each other in two ways.  

**Synchronous**  
A service calls another service and waits for the answer.  
Use it when the caller needs the result to continue.  

- Services never call each other directly. The call always goes through the API gateway.  
- The gateway is the single front door for clients and for services alike.  
- A service only needs to know the gateway address, not where the other service runs.  

**Asynchronous**  
A service publishes a message on Azure Service Bus. Other services subscribe and react in their own time.  
Use it when the sender should not wait, or when more than one service is interested in what happened.  

- The sender does not know who receives the message.  
- A slow or unavailable service does not block the sender.  
- Messages are kept on the bus until a consumer handles them.  

Prefer messages when you can. They keep the services loosely coupled.  

### Database

Every service owns its data.  
The database is an implementation detail of the service, not a shared integration point.  

- Only the owning service accesses its data.  
- Other services get at the data through the API or through messages.  
- A change to the data model never breaks another service.  

### How a request flows through the system

1. A client sends a request to the API gateway.  
2. The gateway forwards it to the right service.  
3. The service turns the request into a service request and processes it.  
4. A query reads data from the database. A command changes it.  
5. If the service needs data or an action from another service, it sends a request to the API gateway. The gateway forwards it to that service, and the answer comes back the same way.  
6. The service returns a response to the client, through the gateway.  
7. When something important happened, the service also publishes a message on Azure Service Bus. Other services pick it up and do their own work.  

### Design principles

- **Clear boundaries:** Each part has one job and a well-defined contract.  
- **Loose coupling:** Services depend on APIs and messages, not on each other's internals.  
- **Separation of concerns:** Business logic does not depend on infrastructure like the database or the message bus.  
- **Independent deployment:** Each service can be changed, released and scaled without touching the others.  
- **Pluggable design:** Cross-cutting work like validation, logging and tracing is added through decorators, not mixed into the business logic.  

### How the modules fit in

The modules support the building blocks of a service.  

| Concern                              | Modules                                                          |
|--------------------------------------|------------------------------------------------------------------|
| Handling a use case                  | [Cat.ServiceRequests](./modules/Cat.ServiceRequests/README.md)   |
| Writing data                         | [Cat.Commands](./modules/Cat.Commands/README.md)                 |
| Reading data                         | [Cat.Queries](./modules/Cat.Queries/README.md)                   |
| Consistent outcomes and errors       | [Cat.Responses](./modules/Cat.Responses/README.md)               |
| Checking input                       | [Cat.Validators](./modules/Cat.Validators/README.md)             |
| Cross-cutting work                   | [Cat.Decorators](./modules/Cat.Decorators/README.md)             |
| Business processes as steps          | [Cat.FluentWorkflows](./modules/Cat.FluentWorkflows/README.md)   |
| In-process events                    | [Cat.EventAggregators](./modules/Cat.EventAggregators/README.md) |

<!-- region end: ApplicationArchitecture-->

## Service Project structure
<!-- region start: ServiceProjectStructure-->

Every service in the [application architecture](#application-architecture) is built from the same set of projects.  
Each project has one job, and the references between them keep the business logic free of technology.  

Again you are not obliged to follow this structure to use the modules!  
The `Cat.Demo.CatalogService` projects in the `demo` folder are a small working example of it.  

![Service Project structure](./resources/schemas/CatServiceProjectStructure.excalidraw.svg)

The diagram uses `ServiceName` as a placeholder for the name of your service.  

### Overview

| Project                                       | Purpose                                              | Required |
|-----------------------------------------------|------------------------------------------------------|----------|
| `ServiceName.Api`                             | Host that handles HTTP requests and runs the workers | Yes      |
| `ServiceName.CoreService`                     | Business logic                                       | Yes      |
| `ServiceName.Infrastructure`                  | Database and external integrations                   | Yes      |
| `ServiceName.Contracts`                       | Service requests, contract models and enums          | Yes      |
| `ServiceName.DataModels`                      | Entities and query result models                     | Yes      |
| `ServiceName.Infrastructure.DataAccessTooling`| Generates the entities from an existing database     | Optional |
| `ServiceName.CoreService.Tests`               | Unit tests of the business logic                     | Optional |

### ServiceName.Api

The API is the one and only host of the service.  
It is the executable, and every service has one.  

The API contains no business logic.  
It sets up the application, registers the modules in the DI container and passes the work on to the core.  

- Exposes the service over HTTP.  
- Maps each endpoint to a service request, for example with [Cat.Minimal.Api](./modules/Cat.Minimal.Api/README.md).  
- Receives its calls from the API gateway.  
- Runs the background workers, when the service has them.  
- Registers the `Infrastructure` project in the DI container at startup. That is the only reason it references it.  

The API references the `CoreService`, `Contracts` and `Infrastructure` projects.  

**Development endpoints**  
In debug mode the API has an extra development endpoint group.  
It lets you try out the service without the real triggers.  

- Only available in debug mode. They are never exposed in a release build.  
- Inside the development group, each background worker has its own endpoint group.  
- Those endpoints simulate a request from the scheduler or from the event processor.  
- Call one and the service handles it as if the worker triggered it.  

**Scheduler**  
- Runs work on a schedule, like a nightly cleanup or a periodic import.  
- Every run triggers a service request.  
- The API registers it with the extension methods of [Cat.Scheduling](./modules/Cat.Scheduling/README.md).  

**Event processor**  
- Listens to Azure Service Bus.  
- Every incoming message triggers a service request.  
- The API registers it with the extension methods of [Cat.EventProcessor](./modules/Cat.EventProcessor/README.md).  

### ServiceName.CoreService

The core is the heart of the service. It holds the business logic.  

- Contains the service request handlers.  
- Contains the definitions of the queries and commands the handlers use.  
- Contains the validators of the service requests, built with the [Cat.Validators](./modules/Cat.Validators/README.md) module. They are server side, so clients that reference the contracts do not need the validation code.  
- Maps the entities and query result models to the contract models. We suggest the [Mapperly](https://mapperly.riok.app/) NuGet package for this. It is a good mapper, so CAT has no module for mapping.  
- Knows nothing about the database or any other technology. It only references the abstractions of the [Cat.Queries](./modules/Cat.Queries/README.md) and [Cat.Commands](./modules/Cat.Commands/README.md) modules, and the [Cat.Validators](./modules/Cat.Validators/README.md) module for the validators.  
- Is the only project the unit tests need to reference.  

A handler never talks to the database itself.  
It sends a query or a command to its processor, and the infrastructure does the rest.  

The core references the `Contracts` and `DataModels` projects.  

### ServiceName.Infrastructure

The infrastructure is everything the core should not know about.  

- Contains the query handlers and the command handlers.  
- Contains the data access code, like the database context.  
- Contains the extension method that registers all of this in the DI container.  
- Holds the migrations when the service uses a code first approach.  

External integrations, like an email provider or a storage account, live here too.  
Treat them like a database. The core never calls them directly. It sends a query or a command and a handler talks to the integration.  

The infrastructure references the `CoreService` and `DataModels` projects.  
That way the dependency points inwards. The core defines the queries and commands, the infrastructure implements the handlers.  

### ServiceName.Contracts

The contracts project holds the contract of the service, the way the outside world talks to it.  

- **ServiceRequests:** The requests that callers send to the service, and the responses they get back.  
- **Models:** The contract models that the requests and responses use. They are the public shape of your data, not the entities from the `DataModels` project.  
- **Enums:** Enumerations that the requests and the contract models use. Callers need them, so they live in the contract.  

It has almost no dependencies, so it is easy to share. Sharing it is a choice, not a rule.  

**Share it or not**  
A caller of the service, whether another service or a client, can use the contract in two ways.  

- **Reference the project.** The caller reuses the request, model and enum types. There is no duplicate code, and a breaking change shows up at compile time. The price is coupling. The caller depends on your types and on your release rhythm.  
- **Keep its own models.** The caller declares only what it needs, often generated from the OpenAPI document of the service. The services stay independent. The price is duplicate types, and a change only shows up at runtime.  

Both are fine. Decide per situation, and per caller. A .NET client and a service that change together can share. A client in another technology, or a service owned by another team, probably should not. You can mix both in one application.  

### ServiceName.DataModels

The data models project holds the data classes that come out of the database.  

- **Entities:** Classes that map to a table or another store. The infrastructure reads and writes them.  
- **Results:** Classes that hold the result of a query when that result does not match an entity, for example an overview that combines fields from several entities.  
- **Enums:** Enumerations used by the entities and the results. Keeping them here means the entities and the results share one definition.  

Both the `CoreService` and the `Infrastructure` project use them.  
They are internal to the service. Never hand them out through the API. Map them to a contract model first. We suggest the [Mapperly](https://mapperly.riok.app/) NuGet package for this.  

### ServiceName.CoreService.Tests

This project holds the unit tests of the business logic.  

- Tests the service request handlers in the core.  
- Replaces the queries and commands with test doubles, so no database is needed.  
- References the `CoreService` project.  

### Reference rules

- Dependencies point inwards. The API and the infrastructure depend on the core. The core depends on neither of them.  
- The core only references the abstractions of the CAT modules.  
- The API is the only place where everything is wired together.  
- The `Contracts` project stays small and free of service internals.  
<!-- region end: ServiceProjectStructure-->
