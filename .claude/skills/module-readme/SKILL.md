---
name: module-readme
description: Create or update the README.md of a module in modules/. Use when a module readme is added or changed, when projects or dependencies of a module change, or when the table of contents, NuGet table, namespaces table or dependencies table of a module readme needs a refresh.
argument-hint: "[module name, for example Cat.EFCore]"
---

# Module readme

Create or update `modules/<ModuleName>/README.md` from the template.

## Before you start
- Read the latest `modules/CatModuleReadmeTemplate.md`. Never work from memory.
- Read the existing readme of the module, if there is one. Keep the intro and usage text unless the user asks to change them.
- List the projects in the module folder (one `.csproj` per project). The root namespace of a project is its project name.
- Read the namespace summaries in `modules/<ModuleName>/namespaces/<NamespaceName>/index.md` for the descriptions. These files are generated. Read them only.
- Read the `ProjectReference` entries in the `.csproj` files. A reference to a project of another module is a dependency.

## Fill the template
Replace these placeholders. Keep every block marker comment.

| Placeholder | Fill with |
|-------------|-----------|
| `[[ModuleName]]` | The name of the module folder. |
| `[[Intro]]` | A brief overview, between `<!-- Intro start-->` and `<!-- Intro end-->`. |
| `[[Usage]]` | Code examples, between `<!-- Usage start-->` and `<!-- Usage end-->`. |
| `[[NamespaceName]]` | The root namespace of a project. One row per project. |
| `[[PackageRole]]` | A short label such as `Contracts`, `Implementation` or `Optional decorator`. |
| `[[NamespaceDescription]]` | One short sentence, based on the namespace summary. |
| `[[DependentModuleName]]` | The module that is depended on. One row per dependency. |
| `[[DependencyReason]]` | One short reason why the module needs it. |

## Rules
- Copy the header table from the template unchanged. Its links and image path already fit the module folder depth.
- In the header table, keep the Markdown menu line and the closing `</td>`, `</tr>` and `</table>` tags at column 0. Indented tags show up as text in some previewers.
- Every project has a package named `gmarginet.` followed by its root namespace.
- NuGet block:
  - Start with one version badge for the main package, the package named like the module. If no project is named like the module, use the first project. All packages of a module share the same version.
  - Wrap the badge in a link to `#nuget-packages`.
  - Add a table with the columns `Package`, `Role`, `Install` and `Downloads`, one row per project.
  - Row format: ``| [[[NamespaceName]]](https://www.nuget.org/packages/gmarginet.[[NamespaceName]]/) | [[PackageRole]] | `dotnet add package gmarginet.[[NamespaceName]]` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.[[NamespaceName]])](#nuget-packages) |``
- Namespaces block:
  - A table with the columns `Namespace` and `What it holds`, one row per project.
  - Row format: `| [[[NamespaceName]]](namespaces/[[NamespaceName]]/index.md) | [[NamespaceDescription]] |`
- Dependencies block:
  - A table with the columns `Module` and `Why [[ModuleName]] needs it`, one row per dependency.
  - Row format: `| [[[DependentModuleName]]](../[[DependentModuleName]]/README.md) | [[DependencyReason]] |`
  - No dependencies? Skip the table and write `[[ModuleName]] has no dependencies on other CAT modules.` followed by two trailing spaces.
- Always wrap a badge in a link to a heading anchor on the same page (`#nuget-packages`, `#getting-started` or `#module-overview`). An unlinked image becomes a link to a blank page with only the badge.
- Always leave a blank line between a block marker comment and the table or text below it, and between the last table row and the closing marker comment. Without the blank lines Jekyll shows the table as plain text.
- Keep the table of contents up to date with the chapters that exist in the readme. Ignore the chapters marked with `<!-- omit in toc -->`.
- Follow the documentation style in CLAUDE.md: plain and direct, short sentences, no long dashes, no ellipses.

## Afterwards
- Check that every project in the module has a row in the NuGet and Namespaces tables.
- If the module is new or its description changed, run the `root-module-table` skill so the root README row matches the intro.
- Check that the module folder has its `README.md` in `CleanArchitectureToolkit.slnx`.
