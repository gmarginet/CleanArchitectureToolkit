---
name: cat-upgrade
description: Help move a solution to a new version of the Clean Architecture Toolkit modules, by comparing the module readmes of the old and the new version and updating the code. Use when the developer wants to upgrade CAT, bump the CAT version, or asks what changed between versions.
---

# Upgrade the CAT version

The toolkit has no release notes. The module readme that ships inside every package shows the usage of its version, so the difference between two readmes is the difference in usage.

## Before you start
1. Find the version in use: `CatVersion` in `Directory.Packages.Cat.props`, or the `Version` of the CAT packages in `Directory.Packages.props`. A project that references the modules as projects has no version. Say so and stop, because there is nothing to upgrade.
2. Ask for the target version, or find the newest one: `dotnet package search gmarginet.Cat.Commands --exact-match`.
3. Start from a clean working tree, or tell the developer to commit first. The upgrade changes many files.

## Steps
1. Change the version in the one place that holds it. Run `dotnet restore`. The packages of both versions are then in `~/.nuget/packages/gmarginet.<module in lower case>/<version>/`, and each has a `README.md`.
2. For each CAT module the solution uses, compare the readme of the old version with the one of the new version. A command that works is `git diff --no-index --stat <old>/README.md <new>/README.md`, then the full diff for the readmes that changed. Skip the table of namespaces and the dependency table.
3. Build the list of changes that touch the code of the developer: a renamed call, a new registration, a changed option, a moved namespace.
4. Run `dotnet build`. The compiler finds what the readmes miss. Fix each error with the new usage.
5. Apply the changes from the list to the code, one module at a time. Show the developer the list before you edit the code.
6. Run `dotnet build` and `dotnet test`. Fix what fails.
7. Report what changed in the code, what is new and optional, and what you could not decide.

## Rules
- A change that the readme does not show is missed. Say that in the report, and rely on the build and the tests to find the rest.
- Never change the version of a module alone, because all CAT packages must have the same version.
- A readme gives the new usage and not the reason. When a change looks breaking, ask before you apply it.
