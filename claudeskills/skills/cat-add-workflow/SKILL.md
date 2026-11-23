---
name: cat-add-workflow
description: Add a fluent workflow with its state and steps to a Clean Architecture Toolkit service. Use when the developer wants a multi step process, steps that run in order, a flow with branches, or says "add a workflow".
---

# Add a workflow

A workflow runs steps in order over one state, with `Cat.FluentWorkflows`.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "The building blocks", "Write a workflow", "Run a workflow" and "How a step decides what happens next" in the readme of `Cat.FluentWorkflows`. The readme is `modules/Cat.FluentWorkflows/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.fluentworkflows/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask for the steps in plain words, what each one reads and changes, and where the flow branches or waits.
2. Add the package `Cat.FluentWorkflows` to the core service when it is not there, with `cat-add-module`. The template needs it.
3. Run `dotnet new cat-workflow --help`, then run the template from the folder of the solution: `dotnet new cat-workflow -n <Name> --ServiceName <full name of the service>`. It writes the state, the workflow and a test.
4. Fill in the state and the steps. Use the built-in steps of the chapter "Built-in steps" before a step of your own. A flow that waits for another service uses `cat-add-saga`.
5. Run the workflow from a handler, as "Run a workflow" shows.
6. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- Keep the state a plain class that holds only what the steps need.
- A flow that survives a restart or waits for a message is a saga. Say so, and offer `cat-add-saga`.
