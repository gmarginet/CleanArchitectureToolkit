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
| [cat-internal-run-apphost](cat-internal-run-apphost/SKILL.md) | Start, check and stop the Aspire AppHost of the demo with the Aspire CLI, without breaking Docker Desktop. | `/cat-internal-run-apphost start` |
| [cat-internal-verify-code](cat-internal-verify-code/SKILL.md) | Build, test, check the regenerated namespaces pages, the error code areas and the integration tests of database code, and deploy a changed generator. | `/cat-internal-verify-code` |
| [cat-internal-template-concepts](cat-internal-template-concepts/SKILL.md) | The basic concepts of CAT templates: regions, template markers, placeholders. Other template skills load it first. | `/cat-internal-template-concepts` |
| [cat-internal-create-header](cat-internal-create-header/SKILL.md) | Create or update the header of a template-based markdown file, and update every file that uses it. | `/cat-internal-create-header update` |
| [cat-internal-create-plan](cat-internal-create-plan/SKILL.md) | Create, build and update a plan in `plans/` from the plan template. | `/cat-internal-create-plan create Cat.Localizations` |
| [cat-internal-create-template](cat-internal-create-template/SKILL.md) | Create a new template and the skill that uses it, from two skeletons. | `/cat-internal-create-template Cat.Report a module report` |
| [cat-internal-verify-site](cat-internal-verify-site/SKILL.md) | Crawl the published site for broken links. Only on request. | `/cat-internal-verify-site --external` |
| [cat-internal-create-module](cat-internal-create-module/SKILL.md) | Start a new module with projects, tests, readme and table row. | `/cat-internal-create-module Cat.Localizations` |

## Adding or changing a skill
- A skill is a folder in `.claude/skills/` with a `SKILL.md`. The front matter holds the `name`, a `description` that says when to use it, and optionally an `argument-hint`.
- Keep the `description` specific. Claude uses it to decide when the skill applies.
- Add or update the table row above in the same change. CLAUDE.md has the rule.
- Helper scripts that a skill needs every time can live in the skill folder. Temporary scripts go in the scratchpad.
- A skill loads in full each time it runs. Put rules that are needed only now and then in a separate file in the skill folder and link it from the `SKILL.md`, such as `cat-internal-create-plan/answer-flow.md`. Claude reads it only when needed.
- A script that prints a short summary saves tokens over a full log, such as `cat-internal-verify-code/run-cake.ps1`.
