---
name: cat-internal-create-readme
description: Create and update the readme in the root of the repository from readme.template.md. Keeps the module overview, the Future modules table and the Other future things table in sync, finds a chapter by its region, and updates the readme after the template changed. Use when a module is added, removed or changes status or description, when a future module or idea is added or removed, when the owner asks to change or look at a chapter of the readme, or when the owner changes the readme template.
argument-hint: "[modules|future|chapter|update] [name]"
---

# Readme

The readme is `README.md` in the root of the repository. It holds the chapters that describe the toolkit, the module overview and the tables of future work. This skill keeps the tables in sync and updates the readme after the template changed.

Load the `cat-internal-template-concepts` skill first. It explains regions, templates and placeholders.

## Files
- [readme.template.md](readme.template.md): the skeleton of the readme. It holds the chapters, the regions and the empty tables. It holds no static text. The static text lives in the readme only.
- [readme.parts.template.md](readme.parts.template.md): the small templates, such as a table row and the badge. Read it when you add one of them.
- The header comes from the `cat-internal-create-header` skill, with `RootPath` `.`.

## Creating the readme
The readme exists. Use this only when it is lost.
1. Copy `readme.template.md` to `README.md` in the root of the repository.
2. Fill the `Header` region by following the `cat-internal-create-header` skill.
3. Fill the regions from the history of the repository, then fill the tables.
4. Run the `cat-internal-verify-docs` skill.

## Regions
A region marks a chapter, so the owner can ask Claude to look at or change one part of the readme.

Regions with static text. The text lives in the readme and the owner decides it.
- `TableOfContents`: The list of links to the chapters. Update it by hand when a heading changes.
- `GettingStarted`: The badges and the short introduction.
- `AboutThisProject`: The note from the owner and the links to the websites.
- `Demo`: A short description of the demo and the link to the demo readme.
- `ApplicationArchitecture`: The application architecture chapter with its drawing and sub chapters.
- `ServiceProjectStructure`: The service project structure chapter with its drawing and sub chapters.

Regions with tables that this skill keeps in sync.
- `ModuleOverview`: The note about the status and the module overview table.
- `FutureModules`: The introduction and the Future modules table.
- `OtherFutureThings`: The introduction and the table of ideas that are not modules.

Regions that every template has.
- `Header`: The banner and the navigation bar, filled by the `cat-internal-create-header` skill.
- `TemplateSkill`: Points to this skill. The text in it is how Claude finds the files that were made with this template.

Edit only inside a region. Never remove a region marker. A change to a heading changes the anchor, so search the old anchor with `git grep` and fix every link.

## Module overview
Keep the table in the `ModuleOverview` region in sync with the folders in `modules/`.

- Never remove the note above the table. It says that modules with the status in development will probably have breaking changes.
- The header row is `| Module | | Description | Plans |`. The status column has no header text.
- One row per folder in `modules/`, sorted by name. Ignore files in `modules/`.
- Use the `ModuleRow` template for a row.
- The link always points to the module readme, also for a module that is still in development.
- `[[PlansLink]]` is the `PlansLink` template when the file `plans/[[ModuleName]].md` exists. Otherwise the cell stays empty.
- `[[ModuleDescription]]` is one short sentence about what the module is used for. Base it on the intro of the module readme.
- A module in development gets the `InDevelopmentBadge` template in the status cell. A stable module has an empty status cell. To put a module in development, add the badge. To make it stable, empty the cell.
- Keep a blank line between the last table row and the end of the region. Without it Jekyll treats the table as part of the HTML comment and shows plain text.

Steps:
1. List the folders in `modules/`.
2. Read the intro of each module readme that needs a new or changed row.
3. Edit the rows. Keep the existing rows untouched when nothing changed.
4. Check that the table has exactly one row per module folder, sorted by name, and check the Plans cell of every row against the files in `plans/`.
5. Run the `cat-internal-verify-docs` skill.

## Future modules
The `FutureModules` region holds a table of modules that do not exist in `modules/` yet.
- Use the `FutureModuleRow` template for a row. The module name links to its plan.
- Put no backticks around the module name. A code span inside a link does not look like a link on the published site.
- Every row links to its own plan, and a module is never in this table and in the module overview.
- When a future module is started with the `cat-internal-create-module` skill, remove its row here and add the row to the module overview.
- The `cat-internal-create-plan` skill describes where a module plan is linked.

## Other future things
The `OtherFutureThings` region holds a table of ideas that are not modules.
- Use the `OtherFutureRow` template for a row.
- A row links to a plan in `plans/`.

## Updating the readme after the template changed
Use this when the owner changes the template and asks to update the readme.
1. Work out from the change what differs between the old and the new template.
2. Apply that change to the readme with an edit.
3. Never change the text the owner wrote.
4. For the header, follow the `cat-internal-create-header` skill.
5. Run the `cat-internal-verify-docs` skill.

## Placeholders
- [[ModuleName]]: The name of a module, such as `Cat.Queries`.
- [[StatusBadge]]: The `InDevelopmentBadge` template, or nothing for a stable module.
- [[ModuleDescription]]: One short sentence about what the module is used for.
- [[PlansLink]]: The `PlansLink` template, or nothing when the module has no plan.
- [[ModuleIdea]]: One sentence about the idea of a future module.
- [[ItemName]]: The name of an item in the Other future things table.
- [[PlanFile]]: The file name of the plan of the item, such as `Skills.md`.
- [[ItemIdea]]: One sentence about the idea of the item.
- [[RootPath]]: The relative path to the root of the repository, used by the header. It is `.` for the readme.
