---
name: cat-internal-create-module-readme
description: Create or update the README.md of a module in modules/ from module-readme.template.md. Use when a module readme is added or changed, when projects or dependencies of a module change, when the table of contents, NuGet table, namespaces table or dependencies table of a module readme needs a refresh, or when the owner changes the readme template.
argument-hint: "[module name, for example Cat.EFCore]"
---

# Module readme

Create or update `modules/<ModuleName>/README.md` from the template.

Load the `cat-internal-template-concepts` skill first. It explains regions, templates and placeholders.

## Files
- [module-readme.template.md](module-readme.template.md): the start of every new module readme. Copy it as it is and replace the placeholders.
- [module-readme.parts.template.md](module-readme.parts.template.md): the small templates, such as a table row. Read it when you add one of them.
- The header comes from the `cat-internal-create-header` skill. The `RootPath` of a module readme is `../..`.

## Before you start
- Read the latest template files. Never work from memory.
- Read the existing readme of the module, if there is one. Keep the intro and usage text unless the owner asks to change them.
- List the projects in the module folder (one `.csproj` per project). The root namespace of a project is its project name.
- Read the namespace summaries in `modules/<ModuleName>/namespaces/<NamespaceName>/index.md` for the descriptions. These files are generated. Read them only.
- Read the `ProjectReference` entries in the `.csproj` files. A reference to a project of another module is a dependency.

## Creating a readme
1. Copy `module-readme.template.md` to `modules/<ModuleName>/README.md`.
2. Replace `[[ModuleName]]` and `[[MainPackageName]]`.
3. Fill the `Header` region by following the `cat-internal-create-header` skill, with `RootPath` `../..`.
4. Write the `Intro` region.
5. Add a row to the `NuGet` region with the `NuGetRow` template and one to the `Namespaces` region with the `NamespaceRow` template, for every project.
6. Fill the `Dependencies` region: a row with the `DependencyRow` template for every dependency, or the `NoDependencies` template instead of the table.
7. Write the `Usage` region. Add the chapters of the usage to the table of contents.
8. Run the `cat-internal-verify-docs` skill.

## Plans
- Never link to `plans/` from a module readme. Only the readme links to a plan.
- The readme must in the end hold everything about how the module works and how to use it, so that the plan can be removed. When the plan holds a decision that a developer needs to know, write it in the readme.

## Regions
- `Header`: The header of the readme, filled by the `cat-internal-create-header` skill.
  - Keep the Markdown menu line and the closing `</td>`, `</tr>` and `</table>` tags at column 0. Indented tags show up as text in some previewers.
- `TemplateSkill`: Points to this skill. The text in it is how Claude finds every module readme that was made with this template.
- `Intro`: A brief overview of the module, ending with two trailing spaces.
- `NuGet`: The version badge and the table of packages.
  - Start with one version badge for the main package, the package named like the module. If no project is named like the module, use the first project. All packages of a module share the same version.
  - Wrap the badge in a link to `#nuget-packages`.
  - The table has the columns `Package`, `Role`, `Install` and `Downloads`, one row per project. Every project has a package named `gmarginet.` followed by its root namespace.
- `Namespaces`: A table with the columns `Namespace` and `What it holds`, one row per project.
- `Dependencies`: A table with the columns `Module` and `Why [[ModuleName]] needs it`, one row per dependency. No dependencies? Replace the table with the `NoDependencies` template.
- `Usage`: Code examples and the explanation of how to use the module.

## Rules
- Always wrap a badge in a link to a heading anchor on the same page (`#nuget-packages`, `#getting-started` or `#repo-overview`). An unlinked image becomes a link to a blank page with only the badge.
- Always leave a blank line between a region marker and the table or text below it, and between the last table row and the end marker of the region. Without the blank lines Jekyll shows the table as plain text.
- Keep the table of contents up to date with the chapters that exist in the readme. Ignore the chapters marked with `<!-- omit in toc -->`.
- Follow the documentation style in CLAUDE.md: plain and direct, short sentences, no long dashes, no ellipses.

## Updating readmes after the template changed
Use this when the owner changes `module-readme.template.md` or `module-readme.parts.template.md` and asks to update the readmes.
1. Find the readmes with `git grep --untracked -l "cat-internal-create-module-readme skill to update this readme"`. Skip the `.claude` folder.
2. Work out from the change what differs between the old and the new template. Apply that change to each readme with an edit.
3. Never change the intro or the usage text.
4. For the header, follow the `cat-internal-create-header` skill.
5. Run the `cat-internal-verify-docs` skill.

## Afterwards
- Check that every project in the module has a row in the NuGet and Namespaces tables.
- If the module is new or its description changed, run the `cat-internal-create-readme` skill so the readme row matches the intro.
- Check that the module folder has its `README.md` in `CleanArchitectureToolkit.slnx`.

## Placeholders
- [[ModuleName]]: The name of the module folder, such as `Cat.EFCore`.
- [[MainPackageName]]: The name of the main package without the `gmarginet.` prefix. It is the project named like the module, or the first project if there is none.
- [[NamespaceName]]: The root namespace of a project. One row per project.
- [[PackageRole]]: A short label such as `Contracts`, `Implementation` or `Optional decorator`.
- [[NamespaceDescription]]: One short sentence, based on the namespace summary.
- [[DependentModuleName]]: The module that is depended on. One row per dependency.
- [[DependencyReason]]: One short reason why the module needs it.
