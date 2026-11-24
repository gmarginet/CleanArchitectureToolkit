---
name: cat-internal-create-module
description: Scaffold a new module end to end. Creates the projects in modules/, the test project, the solution entries, the module readme and the readme row. Use when a new CAT module is started.
argument-hint: "[ModuleName] [short description]"
---

# New module

Set up a new module so it matches the others. New modules start with the status Building.

## Before you start
- Ask the owner for anything you cannot decide yourself: the module name, what it is for, and which projects it needs.
- Look at a module of the same shape for the project layout. For example `modules/Cat.Queries` has `Cat.Queries.Abstractions`, `Cat.Queries` and `Cat.Queries.Decorators.Logging`.
- Never create a git branch on your own. Work on the branch that is checked out.

## Steps
1. **Modules folder.** Create `modules/<ModuleName>/` with one subfolder per project. Typical projects:
   - `<ModuleName>.Abstractions` for the contracts.
   - `<ModuleName>` for the implementation.
   - `<ModuleName>.Decorators.<Name>` for optional decorators.
2. **Project files.** Copy the `.csproj` of a similar project and adjust it. Library projects target `netstandard2.0` as much as possible. A project that needs more, such as one that uses ASP.NET Core or EF Core, targets `net10.0;net11.0` with `TargetFrameworks`. Check this for every project you add. Projects reference the `DefaultDocumentation` package, as the other modules do. Package versions come from `Directory.Packages.props`. Versions that follow the release of .NET are listed there once for `net10.0` and `netstandard2.0` (10.0) and once for `net11.0` (11.0), so add a new package to both groups. A test project targets `net10.0;net11.0` when every project it references does. The package id is set in `Directory.Build.props` (`gmarginet.$(MSBuildProjectName)`).
   Every project also gets `DefaultDocumentation/NamespaceDoc.cs`, an internal static class in the root namespace of the project. Its XML summary is the description of the namespace in the generated pages. Copy one from another project, such as `modules/Cat.Responses/Cat.Responses/DefaultDocumentation/NamespaceDoc.cs`, and write a summary that fits.
3. **Test project.** Create `tests/<ModuleName>.Tests/<ModuleName>.Tests.csproj` like `tests/Cat.Queries.Tests`. It references the module projects and `modules/Cat.UnitTesting/Cat.UnitTesting.NUnit`. Add at least one real test.
4. **Solution file.** Update `CleanArchitectureToolkit.slnx`:
   - Add `<Folder Name="/modules/<ModuleName>/">` with one `<Project>` entry per project. Keep the folders sorted by name.
   - Add the test project to the `/tests/` folder, sorted by name.
5. **Error code area.** If the module defines error codes, give it a prefix `CAT-<AREA>` with a 3 letter acronym of the module name, in one definitions class with a constant that ends with `ErrorCodePrefix`. No other module may use the same area. The check is in the `cat-internal-verify-code` skill.
6. **Verify.** Run the `cat-internal-verify-code` skill. The build generates the `namespaces/` pages for the new projects, and the check of the error code areas runs.
7. **Check the generated pages.** They should appear in `modules/<ModuleName>/namespaces/`. If you need to change them, change the XML docs in the code and build again.
8. **Module readme.** Run the `cat-internal-create-module-readme` skill for the new module. It reads the generated namespace summaries, so it comes after the build. Then add `<File Path="modules/<ModuleName>/README.md" />` to the module folder in the solution file.
9. **Readme table.** Run the `cat-internal-create-readme` skill. The row of the module in the repo overview already exists when the module has a plan, so change its status and add the Readme badge and the Read more link to the module readme. A new module without a plan gets a new row. Recalculate the priorities too, as that skill describes.
10. **Issue forms.** Add the module name to the `Module` dropdown of `.github/ISSUE_TEMPLATE/bug_report.yml` and `.github/ISSUE_TEMPLATE/feature_request.yml`, in alphabetical order. A module that is renamed or removed changes the same two lists.

## Done when
- All projects and the test project build and the tests pass.
- The module has a readme with all blocks filled and a correct table of contents.
- The readme has a row for the module with the Building badge.
- The solution file lists the folder, the readme, the projects and the test project.
- The module is in the `Module` dropdown of both issue forms.

Do not commit unless the owner asks for it.
