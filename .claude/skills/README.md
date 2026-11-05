# Skills

Skills are small instruction sets for tasks we repeat in this repo. Claude loads one only when it is needed, so CLAUDE.md stays short.

## How to use a skill
- Type `/` followed by the skill name, for example `/module-readme Cat.EFCore`.
- Or just ask in plain words, for example "update the readme of Cat.EFCore". Claude picks the skill that fits.
- Type `/` on its own to see all skills with their descriptions.
- The full rules of a skill live in its `SKILL.md`. This page is only the overview.

## Overview

| Skill | Use it for | Example |
|-------|------------|---------|
| [module-readme](module-readme/SKILL.md) | Create or update a module readme from the template. | `/module-readme Cat.EFCore` |
| [root-module-table](root-module-table/SKILL.md) | Keep the module table in the root README in sync. | `/root-module-table Cat.EFCore stable` |
| [excalidraw-svg](excalidraw-svg/SKILL.md) | Create or edit an editable Excalidraw drawing in `resources/schemas`. | `/excalidraw-svg add a drawing of the demo security setup` |
| [mermaid-diagram](mermaid-diagram/SKILL.md) | Write or update an ERD, class or sequence diagram as inline Mermaid. | `/mermaid-diagram ERD for the Catalog service` |
| [demo-structure](demo-structure/SKILL.md) | Add or restructure a service, client or Aspire project in `demo/`. | `/demo-structure service Orders` |
| [git-commit](git-commit/SKILL.md) | Commit the changes in logical blocks, with `(skip-pub)` when no code in `modules/` changed. Never pushes. | `/git-commit` |
| [docs-check](docs-check/SKILL.md) | Check all markdown locally: links, anchors, letter case, code fences, markers and forbidden punctuation. | `/docs-check` |
| [module-plan](module-plan/SKILL.md) | Create, update or check a module plan in `plans/`. | `/module-plan update Cat.Messaging outbox decided` |
| [demo-readme](demo-readme/SKILL.md) | Keep `demo/README.md` and the demo architecture drawing in sync with the demo app. | `/demo-readme Inventory service started` |
| [cat-verify](cat-verify/SKILL.md) | Build, test and check the regenerated namespaces pages. | `/cat-verify` |
| [link-check](link-check/SKILL.md) | Crawl the published site for broken links. Only on request. | `/link-check --external` |
| [new-module](new-module/SKILL.md) | Start a new module with projects, tests, readme and table row. | `/new-module Cat.Caching` |

## Skills in detail

### module-readme
- **What it does:** Fills the module readme template. It reads the projects, namespace summaries and project references to build the NuGet, Namespaces and Dependencies tables, and keeps the table of contents up to date.
- **How to use it:** Give it the module name. It keeps your intro and usage text unless you ask for a change.
- **When:** After adding a project to a module, changing dependencies, or writing a new readme.

### root-module-table
- **What it does:** Keeps one row per module folder in the root README, sorted by name, with the In development badge where it applies.
- **How to use it:** Give it a module and a status (`stable` or `development`), or run it without arguments to resync everything.
- **When:** After adding or removing a module, changing a module intro, or changing a module status.

### excalidraw-svg
- **What it does:** Builds a `*.excalidraw.svg` in the house style, with the scene embedded so you can open it in Excalidraw and edit it. It renders a preview with headless Chrome to check the result.
- **How to use it:** Describe what the drawing should show. Name an existing drawing to change it.
- **When:** When a diagram is added or changed.
- **Note:** `excalidraw-svg/excalidraw-payload.ps1` reads and writes the embedded scene. Claude runs it from the repo, and keeps its own generator scripts in the scratchpad.

### mermaid-diagram
- **What it does:** Writes or updates a Mermaid ERD, class or sequence diagram as a fenced block inside the markdown file that needs it. It applies the house rules: no custom colors or themes, C# style names and types, foreign key columns named after the full table name plus `Id`, and no foreign keys between services unless they share a database.
- **How to use it:** Describe the diagram and name the file or service it belongs to.
- **When:** When a data model, class or sequence diagram is added or changed. Architecture and flow drawings use `excalidraw-svg`.

### demo-structure
- **What it does:** Applies the demo folder rules: one folder per deployable unit, one subfolder per project, and a matching solution folder in `CleanArchitectureToolkit.slnx`.
- **How to use it:** Give it the kind of unit (`service`, `client`, `apphost` or `servicedefaults`) and a name.
- **When:** When a demo project is added, moved or renamed.

### git-commit
- **What it does:** Splits the working tree into logical blocks and commits each one with a plain subject line. It runs `git-commit/commit-info.ps1` to group the changes by area and to decide per commit whether the subject must end with ` (skip-pub)`. That is the case when no code in `modules/` and no build file changed, so the build workflow does not publish NuGet packages. It never pushes, amends or rebases.
- **How to use it:** Ask for a commit. Add a hint if you want a certain split or wording.
- **When:** Only when you ask for a commit.
- **Note:** It runs `docs-check` first when markdown changed, and it keeps generated, private and scratch files out of commits.

### docs-check
- **What it does:** Runs `docs-check/check-docs.ps1` over all markdown, locally and without web requests. It reports broken relative links, wrong letter case in paths, anchors without a heading, unclosed code fences, a lost root README marker, skills missing from this overview and forbidden punctuation. It skips the generated namespaces pages unless asked.
- **How to use it:** Run it without arguments. Add a folder or file to limit the check while you work.
- **When:** At the end of a task that changed markdown, a heading or a file name, and after every rename or move.
- **Note:** `link-check` is the slow crawl of the published site with external links, and runs only on request.

### module-plan
- **What it does:** Starts a module plan from a template, using what the readmes, plans and demo code already say. It records decisions, moves answered questions from Open to Decided, and keeps the README tables and the other plans in sync. `module-plan/check-plans.ps1` checks links, titles, required chapters and the table of contents, and warns about unknown module names.
- **How to use it:** Give it the module name and what changed, or ask for a check.
- **When:** When a future module gets a plan, when a decision about a module is made, or when a module is added, renamed, merged or dropped.
- **Note:** The demo plans are not covered. Use `demo-readme` for the demo.

### demo-readme
- **What it does:** Keeps `demo/README.md` current: the functional description, the architecture, the how to run steps and one chapter per block of the architecture drawing. It runs `demo-readme/sync-demo-architecture.ps1`, which switches the boxes of the drawing to hatched (not built) or solid (built) by checking what exists in `demo/`.
- **How to use it:** Describe what changed, or run it without arguments to resync.
- **When:** After any change to the demo app, and when a block of the drawing is started or finished.
- **Note:** `demo-readme/demo-blocks.json` lists the blocks, their drawing elements and the rule that says a block is built. Add new blocks there.

### cat-verify
- **What it does:** Runs the Cake `Debug` build, which regenerates the namespaces pages, and the tests, then checks the diff of the regenerated `namespaces/` pages. It reports passed and failed items and unexpected changes. It never edits generated files and never commits.
- **How to use it:** Run it without arguments at the end of a task.
- **When:** After changing code, XML docs, the documentation generator or a readme.

### link-check
- **What it does:** Runs `link-check/check-links.mjs` against the published GitHub Pages and groups broken pages, files and anchors.
- **How to use it:** Run `/link-check`, and add `--external` to check external links too. Claude never starts this skill by itself.
- **When:** Only when you ask. It sends thousands of requests and needs the latest push to be published first.

### new-module
- **What it does:** Creates the module projects, the test project and the solution entries, then runs `module-readme`, `root-module-table` and `cat-verify`. A new module starts as In development.
- **How to use it:** Give it the module name and a short description. It asks about anything it cannot decide.
- **When:** When a new CAT module is started.

## Adding or changing a skill
- A skill is a folder in `.claude/skills/` with a `SKILL.md`. The front matter holds the `name`, a `description` that says when to use it, and optionally an `argument-hint`.
- Keep the `description` specific. Claude uses it to decide when the skill applies.
- Add or update the table row and the entry above in the same change. CLAUDE.md has the rule.
- Helper scripts that a skill needs every time can live in the skill folder. Temporary scripts go in the scratchpad.
