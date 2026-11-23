---
name: cat-error-codes
description: Define error codes with a prefix and keep them unique in a Clean Architecture Toolkit service. Use when the developer wants new error codes, a list of errors for a service, or asks how to name an error.
---

# Define error codes

An error code has the form `<APPLICATION>-<AREA>-<number>`. A definitions class holds the errors of one area, such as `OrderErrorDefinitions`, and keeps its prefix in one constant.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Define and raise errors" and "The error code convention" in the readme of `Cat.Responses`. The readme is `modules/Cat.Responses/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.responses/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Find the definitions classes of the service, in the core service, such as `OrderErrorDefinitions`. To start an area, run `dotnet new cat-error-definitions --help`, then run the template. `--Prefix` sets the prefix of the area. It writes the class with one example error and a test that checks the prefix.
2. Check the prefix against every definitions class of the solution, so two areas never share a prefix. Search for the prefix before you accept it.
3. Add the new errors to the class of their area, with the next free number. Never reuse a number, also not one of a deleted error.
4. Use the errors in the handlers and the validators, as an error response. Never throw them.
5. Run `dotnet build` and `dotnet test`.

## Rules
- Never copy the prefix of the toolkit, such as `CAT`, for an error of a service.
- Keep the message in plain words for the caller. Never put personal data in it.
