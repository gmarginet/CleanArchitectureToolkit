---
name: cat-add-decorator
description: Add an open generic decorator with its registration and order number to a Clean Architecture Toolkit service, for commands, queries or service requests. Use when the developer wants behavior around every handler, such as logging, timing or a transaction, or says "add a decorator".
---

# Add a decorator

A decorator wraps every handler of a kind, such as all commands. Several decorators run in the order of their numbers.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Write a decorator", "Add a decorator" and "Decorator order" in the readme of `Cat.Decorators`. The readme is `modules/Cat.Decorators/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.decorators/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask what the decorator does and for which kind of handler: commands, queries or service requests.
2. Add `Cat.Decorators.Abstractions` to the core service when it is missing. See `cat-add-module`.
3. Run `dotnet new cat-decorator --help`, then run the template from the folder of the solution. `--For` picks the kind of handler. The template writes the decorator and a test.
4. Register the decorator with the call of "Add a decorator", and give it an order number. Read the order numbers of the decorators that exist, and pick a place that fits the chapter "Decorator order". The logging decorator of the module has a number too.
5. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- Check the order, because a decorator that runs too early or too late changes what the others see. Say which number you chose and why.
- Never register a decorator without an order number.
