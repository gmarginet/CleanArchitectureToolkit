---
name: cat-add-validator
description: Add validation rules for a request or model in a Clean Architecture Toolkit service, with error codes and messages. Use when the developer wants to validate input, check a request, or says "add a validator".
---

# Add a validator

A validator holds the rules of one request. The module finds it and runs it before the handler.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Write a validator", "Rules" and "Validate service requests automatically" in the readme of `Cat.Validators`. The readme is `modules/Cat.Validators/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.validators/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask which request or model the validator checks, and the rules in plain words.
2. Run `dotnet new cat-validator --help`, then run the template from the folder of the solution. The name is the name of the request, and `--ServiceName` is the full name of the service. A target in another namespace goes in with `--TargetNamespace`. The template writes a test that the module finds the validator.
3. Write the rules with the rules of the chapter "Rules". Give every rule an error code from the error definitions of the service, see `cat-error-codes`, and a message a caller can read.
4. Add a test for a valid and an invalid request next to the generated one.
5. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- A validator checks the shape of the input. A rule that needs the database belongs in the handler, which returns an error response.
- Never register the validator by hand. The module finds it.
