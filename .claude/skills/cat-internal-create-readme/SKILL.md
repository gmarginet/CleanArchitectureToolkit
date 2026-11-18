---
name: cat-internal-create-readme
description: Update the readme (README.md in the root) and its repo overview table, with the status badges and the phase columns. Use when a module, plan, tooling item or the demo is added, removed or changes, when a chapter of the readme is changed, or after the readme template changed.
argument-hint: "[overview|chapter|update] [name]"
---

# Readme

The readme is `README.md` in the root of the repository. It holds the chapters that describe the toolkit and the repo overview, the one table that shows the status of everything in the repository. This skill keeps the table in sync and updates the readme after the template changed.

Load the `cat-internal-template-concepts` skill first. It explains regions, templates and placeholders.

## Files
- [readme.template.md](readme.template.md): the skeleton of the readme. It holds the chapters, the regions and the empty table. It holds no static text. The static text lives in the readme only.
- [readme.parts.template.md](readme.parts.template.md): the small templates, such as a table row and the badges. Read it when you add one of them.
- The header comes from the `cat-internal-create-header` skill, with `RootPath` `.`.

## Creating the readme
The readme exists. Use this only when it is lost.
1. Copy `readme.template.md` to `README.md` in the root of the repository.
2. Fill the `Header` region by following the `cat-internal-create-header` skill.
3. Fill the regions from the history of the repository, then fill the table.
4. Run the `cat-internal-verify-docs` skill.

## Regions
A region marks a chapter, so the owner can ask Claude to look at or change one part of the readme.

Regions with static text. The text lives in the readme and the owner decides it.
- `TableOfContents`: The list of links to the chapters. Update it by hand when a heading changes.
- `GettingStarted`: The badges and the short introduction.
- `AboutThisProject`: The note from the owner and the links to the websites.
- `ApplicationArchitecture`: The application architecture chapter with its drawing and sub chapters.
- `ServiceProjectStructure`: The service project structure chapter with its drawing and sub chapters.

Region with the table that this skill keeps in sync.
- `RepoOverview`: The note about the statuses and the repo overview table.

Regions that every template has.
- `Header`: The banner and the navigation bar, filled by the `cat-internal-create-header` skill.
- `TemplateSkill`: Points to this skill. The text in it is how Claude finds the files that were made with this template.

Edit only inside a region. Never remove a region marker. A change to a heading changes the anchor, so search the old anchor with `git grep` and fix every link.

## Repo overview
The `RepoOverview` region holds one table with a row for everything in the repository. The columns are `Name`, `Description` and three columns without a header. The three columns hold one line for each phase of the plan: the priority of the phase, the phase number with the link to the plan, and the number of open questions. The `Description` cell starts with the type badge and the status badge, then a `<br>`, then the description. The badges sit in the wide column, because a badge in a narrow column is scaled down until it is unreadable.

Rows, in this order. Inside a group, sort by name.
1. **Modules.** One row per module. Type `Module`.
2. **Demo.** One row, `Cat.Demo`. Type `Demo`.
3. **Tooling.** Things that help a developer use the toolkit and that are not a module, such as `Cat.Skills` and `Cat.Templates`. Type `Tooling`.

Name column: the name is plain text, `[[Name]]`, and not a link. The anchor sits in the `Description` cell, in front of the type badge, `<a id="[[Anchor]]"></a>`. The name cell is centered vertically, so an anchor there scrolls the badges out of view. The anchor is the name in lowercase with the dots turned into hyphens, such as `cat-minimal-api`. A link without a target makes GitHub open a blank page, so the badges that have no other target link to this anchor and the reader stays where they are.

Type badge: the `TypeBadge` template, with the type of the row. It comes first in the `Description` cell. It links to the anchor of the row, for every row.

Status badge, from three facts: is the item built, does it still have a plan in `plans/`, and does the plan say that the first stable version is reached. The plan says it in the line `**First stable version:**` of its `FirstStableVersion` region. The status badge comes after the type badge.
Every status badge links to the anchor of the row. The plan is linked from the phase number in the three phase columns.
- Not built: the `NewBadge` template.
- Built, the plan file exists and the first stable version is not reached: the `BuildingBadge` template. Breaking changes are possible.
- Built, the plan file exists and the first stable version is reached: the `GrowingBadge` template. The item is stable, and the plan holds extra features. Breaking changes are not expected.
- Built, and no plan file: the `StableBadge` template.
- The owner decides when the first stable version is reached. Change the line in the plan and the badge together.

Readme badge and read more link: a row of a built item gets the `ReadmeBadge` template after the status badge, and the `ReadMoreLink` template at the end of the description. Both link to the readme of the item: `./modules/[[Name]]/README.md` for a module and `./demo/README.md` for `Cat.Demo`. A row of an item that is not built has neither, because there is no readme to open. Leave the placeholders out and keep no stray space.

A module is built when its folder exists in `modules/`. The demo is built from the first stage on. A tooling item is built when its files exist.

Phase columns: one line for each phase of the plan of the item, ordered by the priority C. Column 1 holds the priority C, column 2 the phase number A as a link to the plan and column 3 the number of open questions B. A stable item has empty cells. Read [phases-column.md](phases-column.md) for the format, the ranking rules and when to recalculate. The owner decides the order, so propose new numbers and wait.

Description: one short sentence about what the item is used for. For a module, base it on the intro of the module readme.

Other rules:
- Use the `RepoRow` template for a row.
- Never remove the note above the table.
- Every plan in `plans/` has exactly one row, and the plan file name is the name of the row plus `.md`. `Demo.md` belongs to `Cat.Demo` and `Skills.md` to `Cat.Skills`.
- Put no backticks around a name in a link. A code span inside a link does not look like a link on the published site.
- Keep a blank line between the last table row and the end of the region. Without it Jekyll treats the table as part of the HTML comment and shows plain text.

Steps:
1. List the folders in `modules/` and the files in `plans/`.
2. Read the intro of each module readme that needs a new or changed row.
3. Edit the rows. Keep the existing rows untouched when nothing changed.
4. Check that every module folder and every plan has exactly one row, that the order is right, that every status badge matches the three facts, and that the lines of the three phase columns are up to date.
5. Run the `cat-internal-verify-docs` skill.

When a future module is started with the `cat-internal-create-module` skill, the row stays and its status and its readme links change. When a plan is removed, the status becomes stable. The `cat-internal-create-plan` skill describes where a plan is linked.

## Updating the readme after the template changed
Use this when the owner changes the template and asks to update the readme.
1. Work out from the change what differs between the old and the new template.
2. Apply that change to the readme with an edit.
3. Never change the text the owner wrote.
4. For the header, follow the `cat-internal-create-header` skill.
5. Run the `cat-internal-verify-docs` skill.

## Placeholders
- [[Name]]: The name of the item, such as `Cat.Queries`, `Cat.Demo` or `Cat.Skills`.
- [[Anchor]]: The anchor of the row, see the name column above.
- [[ReadmePath]]: The path of the readme of a built item, `./modules/[[Name]]/README.md` or `./demo/README.md`.
- [[Type]]: `Module`, `Demo` or `Tooling`.
- [[TypeBadge]]: The TypeBadge template.
- [[StatusBadge]]: The `NewBadge`, `BuildingBadge`, `GrowingBadge` or `StableBadge` template.
- [[ReadmeBadge]]: The `ReadmeBadge` template. Empty for an item that is not built.
- [[ReadMoreLink]]: The `ReadMoreLink` template. Empty for an item that is not built.
- [[Priorities]], [[PhaseLinks]], [[OpenQuestions]]: The three phase columns, one line for each phase, joined with `<br>`, see [phases-column.md](phases-column.md). Empty for a stable item.
- [[Description]]: One short sentence about what the item is used for.
- [[PlanFile]]: The file name of the plan in `plans/`, such as `Cat.Messaging.md` or `Demo.md`.
- [[RootPath]]: The relative path to the root of the repository, used by the header. It is `.` for the readme.
