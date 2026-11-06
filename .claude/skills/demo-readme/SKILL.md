---
name: demo-readme
description: Keep demo/README.md and the demo architecture drawing in sync with the demo app. Switches the boxes of the drawing between hatched (not built) and solid (built), and updates the functional description, architecture, how to run and building block chapters. Use whenever the demo app changes, a demo block is started or finished, or the demo readme is edited.
argument-hint: "[what changed in the demo, or leave empty to resync]"
---

# Demo readme

`demo/README.md` is the front door of the demo. It must always describe the demo as it is now, not as planned. The plan lives in `plans/Demo.md`.

## Chapters of demo/README.md
Keep this order. Each chapter below the table of contents has a table of contents entry.

1. **What the bookshop does.** The functional description. What the app is, what a person can do with it, which features it has. Nothing technical: no project names, no module names, no HTTP details. Write only what works today. List what comes later in a short closing bullet list.
2. **Architecture.** A short intro, then the drawing `../resources/schemas/CatDemoArchitecture.excalidraw.svg`, then the details: how a request flows, how services talk to each other, how data is stored, where the CAT modules sit. Say that hatched boxes are not built yet.
3. **How to run.** Every step for a person who just cloned the repo, in order, copy and paste ready. Prerequisites first. Only describe what works now. When the AppHost arrives, it becomes the main route and the per service routes move to a short "Run one service" part.
4. **Building blocks.** One overview table (block, status, chapter), then one chapter per block of the drawing. The list of blocks and their chapter names is in [demo-blocks.json](demo-blocks.json). A database has no chapter of its own. It sits in the chapter of the service that uses it, as a **Database** part with its Mermaid ERD (use the `mermaid-diagram` skill). The ERD matches the entities in the code, or the plan for a planned service.

### Block chapter template
Every block chapter has the same parts, in this order:

- **Status:** `Built` or `Planned`. It must match the box in the drawing, also for the database box of a service.
- **What it is.** Two or three sentences.
- **How it works.** The flow, the main types, the endpoints. Enough to find the code.
- **Database.** For a service with a database: which database, how it is created, and the ERD.
- **CAT modules.** A table: module, where it is used, why. Name only modules the block really references. For a planned block, say which modules it will use and mark the table as planned.
- **Pros.** What the modules give here.
- **Cons.** What it costs: more dependencies, more ceremony, limits. Be honest, a demo that only praises helps nobody.
- **More.** Links to the code folder and the plan.

A planned block may be short. Say what it will do, which modules it will use and why, and link the plan. Do not invent details that the plan does not have.

## Hatched and solid boxes
- A box is **solid** when its block is built and **hatched** when it is not. The background color never changes, only the fill style.
- The rules that say a block is built are in [demo-blocks.json](demo-blocks.json): a folder that exists, optionally with a text that must appear in its code.
- Never edit the fill styles by hand. Run the script and let the code decide.

```
powershell.exe -NoProfile -ExecutionPolicy Bypass -File .claude/skills/demo-readme/sync-demo-architecture.ps1 -WorkDir <scratchpad path>
```

- Add `-Check` to see what is out of date without changing anything. It exits with 1 when the drawing is stale.
- The script updates the scene inside the SVG and redraws only the fill of the boxes that change. The picture of a changed box is clean, not hand-drawn. Mention that to the owner when it matters.
- Render a preview afterwards, as the [excalidraw-svg](../excalidraw-svg/SKILL.md) skill describes, and look at it.

### Not done by the script
- The "(later)" line in the label of a box. Remove it with the excalidraw-svg skill when the block is built.
- Dotted arrows. They mean a connection that does not exist yet. Make them solid with the excalidraw-svg skill when the connection works.
- The legend text at the bottom of the drawing.
- A new block. Add the box with the excalidraw-svg skill, then add it to [demo-blocks.json](demo-blocks.json) with its element id (decode the scene to find it) and a detect rule.

## Steps
1. Read `demo/README.md`, `plans/Demo.md` and, for the changed block, the code. Check facts in the code, not in the plan. Use the Roslyn tools for symbols and references.
2. Run the sync script with `-Check`, then without it. Read the table it prints.
3. Update the **Status** line of every block chapter and the overview table so they match the script.
4. Update the chapters the change touches: functional description, architecture details, how to run, block chapters. A new feature goes in the functional description in plain words and in the block chapter in technical words.
5. Check the how to run steps against reality: ports, connection strings, commands, users. When the AppHost, Docker or Keycloak arrive, the steps change.
6. Update `plans/Demo.md` if a decision changed.
7. Run `cat-verify` when code or XML docs changed too.

## Writing rules
Follow the style rules in CLAUDE.md: plain and direct, short sentences, active voice, no long dashes, no ellipses, no decorative markdown. Use backticks for code names. Write to a reader who knows .NET but has never seen this repository.

## Keeping it current
Run this skill at the end of any task that:
- adds, removes or renames a service, project, endpoint or feature in `demo/`,
- changes how the demo is started, configured or tested,
- finishes or starts a block of the drawing,
- changes which CAT modules a block uses.
