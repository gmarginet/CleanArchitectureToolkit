---
name: cat-internal-create-readme
description: Create and update the readme in the root of the repository from readme.template.md. Keeps the repo overview table in sync with the modules, the demo, the tooling and the plans, finds a chapter by its region, and updates the readme after the template changed. Use when a module, the demo or a tooling item is added, removed or changes status or description, when a plan is added or removed, when the owner asks to change or look at a chapter of the readme, or when the owner changes the readme template.
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
The `RepoOverview` region holds one table with a row for everything in the repository. The columns are `Name`, `Type`, a status column without a header text, `Priority` and `Description`.

Rows, in this order. Inside a group, sort by name.
1. **Modules.** One row per module. Type `Module`.
2. **Demo.** One row, `Cat.Demo`. Type `Demo`.
3. **Tooling.** Things that help a developer use the toolkit and that are not a module, such as `Cat.Skills` and `Cat.Templates`. Type `Tooling`.

Name column:
- A module that is built links to its module readme, `./modules/[[Name]]/README.md`.
- `Cat.Demo` links to the demo readme, `./demo/README.md`.
- An item that is not built yet links to its plan, `./plans/[[PlanFile]]`.

Status column, from two facts: is the item built, and does it still have a plan in `plans/`.
- Not built: the `NewBadge` template. The badge links to the plan.
- Built, and the plan file exists: the `InDevelopmentBadge` template. The badge links to the plan. Breaking changes are possible.
- Built, and no plan file: the `StableBadge` template. The badge links to the readme of the item, the same target as the name link.
- A plan goes only when the owner agrees. That is the moment an item becomes stable.

A module is built when its folder exists in `modules/`. The demo is built from the first stage on. A tooling item is built when its files exist.

Priority column: a whole number for every item that is not stable, and empty for a stable item. 1 is the highest priority. The numbers are unique, so there is one order of work.
- Rank first the items that are easy to finish or to build, even when the demo does not need them. A built item whose plan only has a small closing step is the easiest.
- Then rank the items the demo needs, in the order of the phases of `plans/Demo.md`. The plan and the phase of the demo lead.
- Then rank the rest. Within a group, the item with fewer open questions and a smaller scope comes first.
- Recalculate the priorities every time a plan changes, an open question is answered, a plan is created or removed, or a build is finished. A stable item leaves the order, and the numbers after it move up.
- The owner decides the order. Propose the new numbers with the reason when the order changes, and wait for the owner before you write them.

Description column: one short sentence about what the item is used for. For a module, base it on the intro of the module readme.

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
4. Check that every module folder and every plan has exactly one row, that the order is right, that every status badge matches the two facts, and that the priorities are up to date.
5. Run the `cat-internal-verify-docs` skill.

When a future module is started with the `cat-internal-create-module` skill, the row stays and its status and name link change. When a plan is removed, the status becomes stable. The `cat-internal-create-plan` skill describes where a plan is linked.

## Updating the readme after the template changed
Use this when the owner changes the template and asks to update the readme.
1. Work out from the change what differs between the old and the new template.
2. Apply that change to the readme with an edit.
3. Never change the text the owner wrote.
4. For the header, follow the `cat-internal-create-header` skill.
5. Run the `cat-internal-verify-docs` skill.

## Placeholders
- [[Name]]: The name of the item, such as `Cat.Queries`, `Cat.Demo` or `Cat.Skills`.
- [[NameLink]]: Where the name links to, see the name column above.
- [[Type]]: `Module`, `Demo` or `Tooling`.
- [[StatusBadge]]: The `NewBadge`, `InDevelopmentBadge` or `StableBadge` template.
- [[Priority]]: The priority of the item, see the priority column above. Empty for a stable item.
- [[Description]]: One short sentence about what the item is used for.
- [[PlanFile]]: The file name of the plan in `plans/`, such as `Cat.Messaging.md` or `Demo.md`.
- [[RootPath]]: The relative path to the root of the repository, used by the header. It is `.` for the readme.
