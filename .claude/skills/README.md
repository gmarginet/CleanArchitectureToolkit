# Skills

Skills are small instruction sets for tasks we repeat in this repo. Claude loads one only when it is needed, so CLAUDE.md stays short.

## How to use a skill
- Type `/` followed by the skill name, for example `/cat-internal-create-module-readme Cat.EFCore`.
- Or just ask in plain words, for example "update the readme of Cat.EFCore". Claude picks the skill that fits.
- Type `/` on its own to see all skills with their descriptions.
- The full rules of a skill live in its `SKILL.md`. This page is only the overview.

## Overview

| Skill | Use it for | Example |
|-------|------------|---------|
| [cat-internal-create-module-readme](cat-internal-create-module-readme/SKILL.md) | Create or update a module readme from the module readme template. | `/cat-internal-create-module-readme Cat.EFCore` |
| [cat-internal-create-readme](cat-internal-create-readme/SKILL.md) | Keep the repo overview table in the readme in sync, and find a chapter by its region. | `/cat-internal-create-readme overview Cat.EFCore` |
| [cat-internal-create-excalidraw](cat-internal-create-excalidraw/SKILL.md) | Create or edit an editable Excalidraw drawing in `resources/schemas`. | `/cat-internal-create-excalidraw add a drawing of the demo security setup` |
| [cat-internal-create-mermaid](cat-internal-create-mermaid/SKILL.md) | Write or update an ERD, class or sequence diagram as inline Mermaid. | `/cat-internal-create-mermaid ERD for the Catalog service` |
| [cat-internal-create-demo-unit](cat-internal-create-demo-unit/SKILL.md) | Add or restructure a service, client or Aspire project in `demo/`. | `/cat-internal-create-demo-unit service Orders` |
| [cat-internal-commit](cat-internal-commit/SKILL.md) | Commit the changes in logical blocks, with `(skip-pub)` when no code in `modules/` changed. Stops after a commit that publishes. Never pushes. | `/cat-internal-commit` |
| [cat-internal-verify-docs](cat-internal-verify-docs/SKILL.md) | Check all markdown locally: links, anchors, letter case, code fences, markers and forbidden punctuation. | `/cat-internal-verify-docs` |
| [cat-internal-create-demo-readme](cat-internal-create-demo-readme/SKILL.md) | Create and update `demo/README.md` from its template, and keep the demo architecture drawing in sync with the demo app. | `/cat-internal-create-demo-readme Inventory service built` |
| [cat-internal-verify-code](cat-internal-verify-code/SKILL.md) | Build, test, check the regenerated namespaces pages and the error code areas, and deploy a changed generator. | `/cat-internal-verify-code` |
| [cat-internal-template-concepts](cat-internal-template-concepts/SKILL.md) | The basic concepts of CAT templates: regions, template markers, placeholders. Other template skills load it first. | `/cat-internal-template-concepts` |
| [cat-internal-create-header](cat-internal-create-header/SKILL.md) | Create or update the header of a template-based markdown file, and update every file that uses it. | `/cat-internal-create-header update` |
| [cat-internal-create-plan](cat-internal-create-plan/SKILL.md) | Create, build and update a plan in `plans/` from the plan template. | `/cat-internal-create-plan create Cat.Caching` |
| [cat-internal-create-template](cat-internal-create-template/SKILL.md) | Create a new template and the skill that uses it, from two skeletons. | `/cat-internal-create-template Cat.Report a module report` |
| [cat-internal-verify-site](cat-internal-verify-site/SKILL.md) | Crawl the published site for broken links. Only on request. | `/cat-internal-verify-site --external` |
| [cat-internal-create-module](cat-internal-create-module/SKILL.md) | Start a new module with projects, tests, readme and table row. | `/cat-internal-create-module Cat.Caching` |

## Skills in detail

### cat-internal-create-module-readme
- **What it does:** Fills the module readme template `cat-internal-create-module-readme/module-readme.template.md`. It reads the projects, namespace summaries and project references to build the NuGet, Namespaces and Dependencies tables with the small templates of `module-readme.parts.template.md`, and keeps the table of contents up to date. It also updates the readmes after the template changed.
- **How to use it:** Give it the module name. It keeps your intro and usage text unless you ask for a change.
- **When:** After adding a project to a module, changing dependencies, writing a new readme, or changing the template.
- **Note:** The header comes from `cat-internal-create-header`, with `RootPath` `../..`.

### cat-internal-create-readme
- **What it does:** Keeps the readme in sync with `readme.template.md`. The repo overview table has one row per module, the demo and the tooling, with a New, Building or Stable badge that follows from the plans. Every item that is not stable also has a priority, which Claude recalculates when plans or builds change. The chapters with static text have their own region, so you can ask Claude to look at or change one chapter.
- **How to use it:** Give it an item such as a module, or run it without arguments to resync the table. Name a chapter to look at or change it.
- **When:** After adding or removing a module, a plan or a tooling item, changing a module intro, or changing the readme template.

### cat-internal-create-excalidraw
- **What it does:** Builds a `*.excalidraw.svg` in the house style, with the scene embedded so you can open it in Excalidraw and edit it. It renders a preview with headless Chrome to check the result.
- **How to use it:** Describe what the drawing should show. Name an existing drawing to change it.
- **When:** When a diagram is added or changed.
- **Note:** `cat-internal-create-excalidraw/excalidraw-payload.ps1` reads and writes the embedded scene. Claude runs it from the repo, and keeps its own generator scripts in the scratchpad.

### cat-internal-create-mermaid
- **What it does:** Writes or updates a Mermaid ERD, class or sequence diagram as a fenced block inside the markdown file that needs it. It applies the house rules: no custom colors or themes, C# style names and types, foreign key columns named after the full table name plus `Id`, and no foreign keys between services unless they share a database.
- **How to use it:** Describe the diagram and name the file or service it belongs to.
- **When:** When a data model, class or sequence diagram is added or changed. Architecture and flow drawings use `cat-internal-create-excalidraw`.

### cat-internal-create-demo-unit
- **What it does:** Applies the demo folder rules: one folder per deployable unit, one subfolder per project, and a matching solution folder in `CleanArchitectureToolkit.slnx`.
- **How to use it:** Give it the kind of unit (`service`, `client`, `apphost` or `servicedefaults`) and a name.
- **When:** When a demo project is added, moved or renamed.

### cat-internal-commit
- **What it does:** Splits the working tree into logical blocks and commits each one with a plain subject line. It runs `cat-internal-commit/commit-info.ps1` to group the changes by area and to decide per commit whether the subject must end with ` (skip-pub)`. That is the case when no code in `modules/` and no build file changed, so the build workflow does not publish NuGet packages. It never pushes, amends or rebases. After a commit without ` (skip-pub)` it stops and asks whether to push first, because only the newest commit of a push decides if the packages are published. It makes an empty commit when you ask for one, for example to start a publish.
- **How to use it:** Ask for a commit. Add a hint if you want a certain split or wording.
- **When:** Only when you ask for a commit.
- **Note:** It runs `cat-internal-verify-docs` first when markdown changed, and it keeps generated, private and scratch files out of commits.

### cat-internal-verify-docs
- **What it does:** Runs `cat-internal-verify-docs/check-docs.ps1` over all markdown, locally and without web requests. It reports broken relative links, wrong letter case in paths, anchors without a heading, unclosed code fences, a Header region that differs from the header template, a module plan without its place in the readme tables, a lost readme marker, skills missing from this overview and forbidden punctuation. It skips the generated namespaces pages unless asked.
- **How to use it:** Run it without arguments. Add a folder or file to limit the check while you work.
- **When:** At the end of a task that changed markdown, a heading or a file name, and after every rename or move.
- **Note:** `cat-internal-verify-site` is the slow crawl of the published site with external links, and runs only on request.

### cat-internal-create-demo-readme
- **What it does:** Keeps `demo/README.md` current, from `demo-readme.template.md`. The readme describes only what exists, with no status and no plans. It has a region for every chapter, sub chapter and block, so you can ask Claude to look at or change one part. It runs `cat-internal-create-demo-readme/sync-demo-architecture.ps1`, which switches the boxes of the drawing to hatched (not built) or solid (built) by checking what exists in `demo/`. The drawing is the only place with status.
- **How to use it:** Describe what changed, or run it without arguments to resync.
- **When:** After any change to the demo app, and when a block of the drawing is built. The `cat-internal-create-plan` skill uses it when a demo phase is built. It never changes a plan.
- **Note:** `cat-internal-create-demo-readme/demo-blocks.json` lists the blocks, their drawing elements and the rule that says a block is built. Add new blocks there.

### cat-internal-verify-code
- **What it does:** Runs the Cake `Debug` build, which regenerates the namespaces pages, and the tests, then checks the diff of the regenerated `namespaces/` pages. It also runs `check-error-areas.ps1`, which fails when two modules use the same error code prefix, like `CAT-VAL`. It reports passed and failed items and unexpected changes. It never edits generated files and never commits.
- **How to use it:** Run it without arguments at the end of a task.
- **When:** After changing code, XML docs, the documentation generator or a readme.

### cat-internal-verify-site
- **What it does:** Runs `cat-internal-verify-site/check-links.mjs` against the published GitHub Pages and groups broken pages, files and anchors.
- **How to use it:** Run `/cat-internal-verify-site`, and add `--external` to check external links too. Claude never starts this skill by itself.
- **When:** Only when you ask. It sends thousands of requests and needs the latest push to be published first.

### cat-internal-create-module
- **What it does:** Creates the module projects, the test project and the solution entries, then runs `cat-internal-create-module-readme`, `cat-internal-create-readme` and `cat-internal-verify-code`. A new module that defines error codes gets its own `CAT-<AREA>` prefix, which `cat-internal-verify-code` checks. A new module starts as Building.
- **How to use it:** Give it the module name and a short description. It asks about anything it cannot decide.
- **When:** When a new CAT module is started.
### cat-internal-template-concepts
- **What it does:** Explains the shared concepts of CAT templates: regions, template markers, placeholders and indentation. It holds no task of its own.
- **How to use it:** You do not run it. Every skill that works with a template file loads it first.
- **When:** Whenever a template is used or created.
- **Note:** Skills for the owner of the toolkit start with `cat-internal-`. Skills for developers who use the toolkit start with `cat-`.

### cat-internal-create-header
- **What it does:** Fills the `Header` region of a new file from `cat-internal-create-header/header.template.md`. When the header template changes, it finds every file that uses it and replaces their `Header` regions. It also covers the generated pages and the `#repo-overview` anchor.
- **How to use it:** Ask for a header for a new file, or ask to update all files that use the header template after you changed it.
- **When:** When a template-based file is created, and after a change to the header template.
- **Note:** `cat-internal-verify-docs` reports every `Header` region that differs from the template.
### cat-internal-create-plan
- **What it does:** Creates a plan from `cat-internal-create-plan/plan.template.md`, adds phases and open questions from `plan.parts.template.md`, keeps the status badge right and processes the answers to open questions. It also builds a phase, links a module plan from the readme, keeps the other plans and readmes in step and updates plans after the template changed.
- **How to use it:** Ask for a new plan, to build the next phase of a plan, or to update the plans after you changed the template.
- **When:** When a plan is created, built or answered, and after a change to the plan template.
- **Note:** The header comes from `cat-internal-create-header`. The instructions live in the `SKILL.md`, so the template files hold only what ends up in a plan.
### cat-internal-create-template
- **What it does:** Creates a new template together with the skill that uses it. It copies `BaseTemplate.template.md` to the main template file and `BaseSkill.template.md` to the `SKILL.md`, and adds a parts file when the template needs small templates.
- **How to use it:** Say what kind of file the template should create. It asks about the name, the regions and the small templates before it starts.
- **When:** When a new kind of file gets a template.
- **Note:** It follows the rules of `cat-internal-template-concepts`: instructions in the `SKILL.md`, only the start of the created file in the template.

## Adding or changing a skill
- A skill is a folder in `.claude/skills/` with a `SKILL.md`. The front matter holds the `name`, a `description` that says when to use it, and optionally an `argument-hint`.
- Keep the `description` specific. Claude uses it to decide when the skill applies.
- Add or update the table row and the entry above in the same change. CLAUDE.md has the rule.
- Helper scripts that a skill needs every time can live in the skill folder. Temporary scripts go in the scratchpad.
