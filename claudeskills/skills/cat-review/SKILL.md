---
name: cat-review
description: Check a Clean Architecture Toolkit service against the conventions of the toolkit, such as project references, registration and response handling, and report what is wrong. Use when the developer asks to review, audit or check a CAT service or a pull request that touches one.
---

# Review a service

Check the service and report. Change nothing unless the developer asks for the fixes.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one, or review them all.
2. Find out which CAT modules the service uses. Read its `*.csproj` files and `Directory.Packages.Cat.props`. For each module that matters to a finding, read its readme, which is `modules/<Module>/README.md` for a project reference, and `README.md` in `~/.nuget/packages/gmarginet.<module in lower case>/<version>/` for a package reference. The readme is the truth.

## What to check
1. **References.** The core service references only `Abstractions` projects of CAT modules. The two exceptions are `Cat.Validators` and `Cat.FluentWorkflows`, because validators and workflows are written in the core, and the template adds them. Any other package in the core is a finding, such as `Microsoft.EntityFrameworkCore`. No project of the core references `Infrastructure`, `Api` or a database package. `Contracts` references nothing of the service.
2. **Where code lives.** Handlers that use the database sit in `Infrastructure`. Entities sit in `DataModels`. Endpoints sit in `Api`, and hold no logic.
3. **Registration.** Each module the service uses has its registration call, and each registration has its package. A module that is registered and never used is a finding. So is a package that is referenced and never registered.
4. **Responses.** Handlers return responses and do not throw for an expected failure, such as a missing item. Errors come from the error definitions of the service, with a prefix that no other area uses.
5. **Validators and endpoints.** A request that takes input has a validator. An endpoint lists its response types and has a name.
6. **Decorators.** Every decorator has an order number, and no two share one by accident.
7. **Tests.** Each service request, validator, workflow and decorator has a test. The tests build and pass: run `dotnet build` and `dotnet test`.
8. **Versions.** All CAT packages have the same version, from `CatVersion`. A package with a version of its own is a finding.
9. **Database.** Code first services have migrations that match the model. Database first services have no migrations, and their tables match the entities.

## Report
Group the findings under the numbers above. For each finding give the file and line, what is wrong, and which skill fixes it, such as `cat-add-validator` for a missing validator. Put the severe ones first. Say what passed too, in one line, so the developer knows what you checked.

## Rules
- Do not report a style preference as a finding. Report what breaks a convention of a module readme.
- When you are not sure, say so and name the readme chapter that decides it.
