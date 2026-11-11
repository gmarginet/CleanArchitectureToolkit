---
name: cat-internal-create-module
description: Scaffold a new module end to end. Creates the projects in modules/, the test project, the solution entries, the module readme and the readme row. Use when a new CAT module is started.
argument-hint: "[ModuleName] [short description]"
---

# New module

Set up a new module so it matches the others. New modules start with the status in development.

## Before you start
- Ask the owner for anything you cannot decide yourself: the module name, what it is for, and which projects it needs.
- Look at a module of the same shape for the project layout. For example `modules/Cat.Queries` has `Cat.Queries.Abstractions`, `Cat.Queries` and `Cat.Queries.Decorators.Logging`.
- Never create a git branch on your own. Work on the branch that is checked out.

## Steps
1. **Modules folder.** Create `modules/<ModuleName>/` with one subfolder per project. Typical projects:
   - `<ModuleName>.Abstractions` for the contracts.
   - `<ModuleName>` for the implementation.
   - `<ModuleName>.Decorators.<Name>` for optional decorators.
2. **Project files.** Copy the `.csproj` of a similar project and adjust it. Library projects target `netstandard2.0` and reference the `DefaultDocumentation` package, as the other modules do. Package versions come from `Directory.Packages.props`. The package id is set in `Directory.Build.props` (`gmarginet.$(MSBuildProjectName)`).
   Every project also gets `DefaultDocumentation/NamespaceDoc.cs`, an internal static class in the root namespace of the project. Its XML summary is the description of the namespace in the generated pages. Copy one from another project, such as `modules/Cat.Responses/Cat.Responses/DefaultDocumentation/NamespaceDoc.cs`, and write a summary that fits.
3. **Test project.** Create `tests/<ModuleName>.Tests/<ModuleName>.Tests.csproj` like `tests/Cat.Queries.Tests`. It references the module projects and `tests/Cat.NUnit`. Add at least one real test.
4. **Solution file.** Update `CleanArchitectureToolkit.slnx`:
   - Add `<Folder Name="/modules/<ModuleName>/">` with `<File Path="modules/<ModuleName>/README.md" />` and one `<Project>` entry per project. Keep the folders sorted by name.
   - Add the test project to the `/tests/` folder, sorted by name.
5. **Module readme.** Run the `cat-internal-create-module-readme` skill for the new module.
6. **Readme table.** Run the `readme-module-table` skill. Add the row with the In development badge. If the module had a row in the Future modules table of the readme, remove that row and put the Plans link in the new row. The `cat-internal-create-plan` skill describes this.
7. **Verify.** Run the `cat-internal-verify-code` skill. The build generates the `namespaces/` pages for the new projects.
8. **Check the generated pages.** They should appear in `modules/<ModuleName>/namespaces/`. If you need to change them, change the XML docs in the code and build again.

## Done when
- All projects and the test project build and the tests pass.
- The module has a readme with all blocks filled and a correct table of contents.
- The readme has a row for the module with the In development badge.
- The solution file lists the folder, the readme, the projects and the test project.

Do not commit unless the owner asks for it.
