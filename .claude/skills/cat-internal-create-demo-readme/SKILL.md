---
name: cat-internal-create-demo-readme
description: Create and update demo/README.md from demo-readme.template.md and keep the demo architecture drawing in sync with the demo app. Finds a chapter by its region, adds a block chapter, switches the boxes of the drawing between hatched (not built) and solid (built), and updates the readme after the template changed. Use whenever the demo app changes, a demo block is built, or the demo readme is edited.
argument-hint: "[what changed in the demo, or leave empty to resync]"
---

# Demo readme

`demo/README.md` is the front door of the demo. It describes the demo as it is now. It holds no status, no plans and no future items. What we are going to build, change or add belongs to `plans/Demo.md`, and the `cat-internal-create-plan` skill owns that plan.

The direction is one way. When a demo phase is built, the plan skill uses this skill to bring the demo readme up to date. Updating the demo readme never changes a plan, and never triggers a plan step.

The drawing is the only exception. It shows hatched boxes for blocks that are not built yet, because the plan has no pictures.

Load the `cat-internal-template-concepts` skill first. It explains regions, templates and placeholders.

## Files
- [demo-readme.template.md](demo-readme.template.md): the skeleton of the demo readme. It holds the chapters, the regions and the empty overview table. The static text lives in the demo readme only.
- [demo-readme.parts.template.md](demo-readme.parts.template.md): the small templates, such as a block chapter, a module row and an overview row. Read it when you add one of them.
- [demo-blocks.json](demo-blocks.json): the blocks of the drawing, their elements, their chapters and the rule that says a block is built.
- [sync-demo-architecture.ps1](sync-demo-architecture.ps1): switches the boxes of the drawing between hatched and solid.
- The header comes from the `cat-internal-create-header` skill, with `RootPath` `..`.

## Creating the demo readme
The demo readme exists. Use this only when it is lost.
1. Copy `demo-readme.template.md` to `demo/README.md`.
2. Fill the `Header` region by following the `cat-internal-create-header` skill.
3. Fill the regions from the code of the demo.
4. Run the `cat-internal-verify-docs` skill.

## Regions
A region marks a part of the demo readme, so the owner can ask Claude to look at or change one part. Edit only inside a region. Never remove a region marker. A change to a heading changes the anchor, so search the old anchor with `git grep` and fix every link.

Regions of every template:
- `Header`: The banner and the navigation bar, filled by the `cat-internal-create-header` skill.
- `TemplateSkill`: Points to this skill. The text in it is how Claude finds the files that were made with this template.

Chapters, with static text that the owner decides:
- `Intro`: The line under the title.
- `TableOfContents`: The links to the chapters and the block chapters. Update it by hand when a heading changes.
- `WhatTheBookshopDoes`: The functional description. Plain words, no project, module or HTTP names.
- `Architecture`: The intro, the drawing and the sub chapters. Its sub regions are `HowThePiecesFit`, `HowARequestFlowsThroughAService`, `SharingContracts`, `LoginAndTokens`, `EventsAndInterfaces` and `WhereTheCatModulesSit`.
- `HowToRun`: Everything for a person who just cloned the repository. Its sub regions are `Prerequisites`, `RunWithAspire`, `SqlServerModes`, `DockerMemory`, `RunOneService`, `ThingsToKnow`, `HealthChecks`, `ThingsToKnowAboutTheDashboard` and `RunTheTests`.

Building blocks:
- `BlockOverview`: The intro line and the overview table. It is kept in sync with the block chapters.
- One region per block chapter, named after the block: `ReactClient`, `AspireAppHostAndDashboard`, `ApiGateway`, `Keycloak`, `ServiceBusEmulator`, `CatalogService`, `OrdersService`, `InventoryService`, `NotificationsService`, `AspireServiceDefaults` and `PaymentService`.

The sub regions and the block regions live in the demo readme only. The template holds the chapter regions.

## Blocks
The block chapters follow the `BlockChapter` template of the parts file, in this order:
- **What it is.** Two or three sentences.
- **How it works.** The flow, the main types, the endpoints. Enough to find the code.
- **Database.** For a service with a database, the `DatabasePart` template: which database, how it is created and the ERD. Use the `cat-internal-create-mermaid` skill for the ERD. It matches the entities in the code.
- **CAT modules.** A table with the `ModuleRow` template. Name only modules the block really references.
- **Pros.** What the modules give here.
- **Cons.** What it costs: more dependencies, more ceremony, limits. Be honest, a demo that only praises helps nobody.
- **More.** Links to the code folder.

A block chapter describes what exists. It has no status line and no future text. A block that is not built has no chapter. Its box in the drawing is hatched, and its entry in [demo-blocks.json](demo-blocks.json) has `"chapter": null`. The chapter comes when the block is built, see [Adding a block](#blocks).

Adding a block:
1. Add the chapter with the `BlockChapter` template, after the last block chapter. Name the region after the block.
2. Add a row with the `BlockOverviewRow` template to the `BlockOverview` region, and an entry with the `TocBlockEntry` template to the `TableOfContents` region.
3. Add the block to [demo-blocks.json](demo-blocks.json), see [The drawing](#the-drawing).

## The drawing
`../resources/schemas/CatDemoArchitecture.excalidraw.svg` shows the blocks and how they talk to each other. A box is solid when its block is built and hatched when it is not. The background color never changes, only the fill style. A dotted arrow is a connection that does not exist yet.

- The rules that say a block is built are in [demo-blocks.json](demo-blocks.json): a folder that exists, optionally with a text that must appear in its code.
- Never edit the fill styles by hand. Run the script and let the code decide.

```
powershell.exe -NoProfile -ExecutionPolicy Bypass -File .claude/skills/cat-internal-create-demo-readme/sync-demo-architecture.ps1 -WorkDir <scratchpad path>
```

- Add `-Check` to see what is out of date without changing anything. It exits with 1 when the drawing is stale.
- The script updates the scene inside the SVG and redraws only the fill of the boxes that change. The picture of a changed box is clean, not hand-drawn. Mention that to the owner when it matters.
- Render a preview afterwards, as the [cat-internal-create-excalidraw](../cat-internal-create-excalidraw/SKILL.md) skill describes, and look at it.

Not done by the script:
- The "(later)" line in the label of a box. Remove it with the `cat-internal-create-excalidraw` skill when the block is built.
- Dotted arrows. Make them solid with the `cat-internal-create-excalidraw` skill when the connection works.
- The legend text at the bottom of the drawing.
- A new block. Add the box with the `cat-internal-create-excalidraw` skill, then add it to [demo-blocks.json](demo-blocks.json) with its element id (decode the scene to find it) and a detect rule.

## Updating the demo readme
1. Read `demo/README.md` and, for the changed block, the code. Check facts in the code. Use the Roslyn tools for symbols and references. Do not read the plan for facts.
2. Run the sync script with `-Check`, then without it. Read the table it prints.
3. Update the chapters the change touches: the functional description, the architecture details, how to run and the block chapters. A new feature goes in the functional description in plain words and in the block chapter in technical words.
4. Check the how to run steps against reality: ports, connection strings, commands, users.
5. Run the `cat-internal-verify-code` skill when code or XML docs changed too.
6. Run the `cat-internal-verify-docs` skill.

## Writing rules
Follow the style rules in CLAUDE.md: plain and direct, short sentences, active voice, no long dashes, no ellipses, no decorative markdown. Use backticks for code names. Write to a reader who knows .NET but has never seen this repository. Write only what works today.

## Keeping it current
Run this skill at the end of any task that:
- adds, removes or renames a service, project, endpoint or feature in `demo/`,
- changes how the demo is started, configured or tested,
- builds a block of the drawing,
- changes which CAT modules a block uses.

## Updating the demo readme after the template changed
Use this when the owner changes the template and asks to update the demo readme.
1. Work out from the change what differs between the old and the new template.
2. Apply that change to the demo readme with an edit.
3. Never change the text the owner wrote.
4. For the header, follow the `cat-internal-create-header` skill.
5. Run the `cat-internal-verify-docs` skill.

## Placeholders
- [[BlockName]]: The name of the block, such as `Orders service`.
- [[BlockRegion]]: The name of the region of the block, such as `OrdersService`.
- [[BlockAnchor]]: The anchor of the block heading, such as `orders-service`.
- [[WhatItIs]]: Two or three sentences about the block. The overview row holds the first sentence.
- [[HowItWorks]]: One bullet about how the block works.
- [[Pro]]: One advantage of the block.
- [[Con]]: One cost of the block.
- [[More]]: The links to the code folder.
- [[DatabaseDescription]]: Which database the block owns and how it is created.
- [[EntityName]]: The name of an entity in the ERD.
- [[ModuleName]]: The name of a CAT module, such as `Cat.Queries`.
- [[Where]]: Where the block uses the module.
- [[Why]]: Why the block uses the module.
- [[RootPath]]: The relative path to the root of the repository, used by the header. It is `..` for the demo readme.
