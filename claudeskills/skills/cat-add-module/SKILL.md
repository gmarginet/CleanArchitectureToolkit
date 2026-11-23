---
name: cat-add-module
description: Add a Clean Architecture Toolkit module to a service, with the right packages, the registration call and the project references. Use when the developer wants to use a CAT module, such as caching, resilience, messaging or telemetry, or asks which package to add.
---

# Add a module to a service

A CAT module is a toolbox part. Add only the module the developer asked for, and never one that it needs without being asked.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Find the readme of the module. It is `modules/<Module>/README.md` when the solution references the module as a project. It is `README.md` in `~/.nuget/packages/gmarginet.<module in lower case>/<version>/` when the solution references the package. The version is `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.

## Steps
1. Read the chapters "Register the module" and the first usage chapter of the readme. Read the table of projects too. A module has an `Abstractions` project, an implementation and sometimes optional projects such as decorators.
2. Add the package versions to `Directory.Packages.Cat.props` when they are missing, with `$(CatVersion)`. Package versions follow the packages that exist for the version in use. Never invent a package name.
3. Put the references in the right project.
   - The core service, `*.CoreService`, references only the `Abstractions` project.
   - The implementation and the registration go in the `Api` project or in `Infrastructure`.
4. Add the registration where the service registers its modules. The service already has the place, so follow the lines around it. Use the call the readme shows.
5. Run `dotnet build`. Fix what fails.
6. Say what the module gives now and which skill uses it next. For example `cat-cache-query` for caching, `cat-add-resilience` for a profile on an `HttpClient`.

## Rules
- The core service never references an implementation project.
- A module never forces another module on the developer. Add a second module only when the readme says that the first one cannot work without it, and say so.
- The skills for a single task, such as `cat-add-job` or `cat-add-inbox`, do this and more for their module. Use them when one fits.
