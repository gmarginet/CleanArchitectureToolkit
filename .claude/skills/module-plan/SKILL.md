---
name: module-plan
description: Create, update or check a module plan in plans/. Starts a plan from the template using what the docs and code already say, records decisions, keeps the README tables and the other plans in sync, and runs a check script. Use when a future module gets a plan, when a decision about a module is made, or when a module is added, renamed, merged or dropped.
argument-hint: "[create|update|check] [ModuleName] [what changed]"
---

# Module plans

A module plan collects what we know about a module before it is built. It holds the idea, the decisions, the open questions and the questions to ask the owner. The plans of the demo (`Demo.md`, `DemoAspire.md`) are free-form and are not covered by this skill. The `demo-readme` skill covers the demo.

## Rules for a plan
- File: `plans/<ModuleName>.md`, named exactly like the module. An existing module gets a plan too when it has future work.
- Header: the file starts with the header of the root `README.md` (the `link` and `table` elements), with the paths for the `plans/` folder. It is the same in every plan, so copy it from the template. It gives the navigation links.
- Main title, right below the header: `Plans for <ModuleName>`.
- Start from [ModulePlanTemplate.md](ModulePlanTemplate.md).
- Required chapters: `The idea`, `Decisions and open questions` with `### Decided` and `### Open`, and `Questions before building`. `What we already know` is expected. Keep the `Contents` list in step with the headings.
- `Decided` holds only what the owner decided, or what the existing docs state. Name the document when it comes from one. Everything else is `Open`. Never invent a decision.
- Facts in `What we already know` come from documents and code that you read. Group them by source. Do not add facts you did not check. Mark a guess as something to check.
- Questions before building: numbered, one decision per question, answerable in a sentence, the blocking ones first.
- Follow the style rules in CLAUDE.md: plain and direct, short sentences, active voice, no long dashes, no ellipses.
- A plan never says the module "will" exist in a certain version or on a date. It only says what is decided.

## Where the plan is linked
- A module that does not exist yet: a row in the Future modules table of the root `README.md`. The module name in the row links to `plans/<ModuleName>.md`, written as `[Cat.X](./plans/Cat.X.md)`. Put no backticks around the name. A code span inside a link does not look like a link on the published site.
- A module that exists: the Plans column of its row in the module overview, `[Plans](./plans/<ModuleName>.md)`. The `root-module-table` skill covers that column. The row must not be in the Future modules table.
- When a future module is started with the `new-module` skill, move it: remove the row from the Future modules table and add the Plans link to the module overview. Keep the plan until the module has done everything in it.

## Where the facts come from
Read these before you write, and search them for the module name:
- the root `README.md`: the application architecture, the service project structure and the module tables,
- `plans/Demo.md` and `plans/DemoAspire.md`, and the other module plans,
- the readmes of the existing modules that the new one touches,
- the demo code in `demo/`, with the Roslyn tools for symbols and references.

## Create
1. Check that no plan exists yet. Check the name against the folders in `modules/` and the Future modules table.
2. Copy the template to `plans/<ModuleName>.md` and fill it in. Search all the documents above for the module name and for its idea.
3. Put the unknowns under `Open` and turn them into numbered questions.
4. Add the README link as described above.
5. Run the check.

## Update
Use this when a decision is made, a module is renamed, merged or dropped, or the owner answers questions.
1. Move the answered item from `Open` to `Decided` and remove the question from `Questions before building`. Renumber the questions.
2. Search every plan, the root `README.md`, `demo/README.md` and `plans/Demo.md` for the module name and for the topic. Fix what no longer matches. A single decision often touches several plans, for example who owns the outbox or where an interface lives.
3. When a module is renamed, merged or dropped: rename or delete the plan file, fix the README tables, fix the links in the other plans and say so in the plan that took over.
4. Run the check.

## Check
Run the script and fix every error. Read the warnings.

```
powershell.exe -NoProfile -ExecutionPolicy Bypass -File .claude/skills/module-plan/check-plans.ps1
```

It reports errors for:
- wrong or missing links in the Future modules table and the Plans column,
- a module that is in both places,
- a missing header, a wrong title, a missing required chapter, or a table of contents entry without a heading.

It reports warnings for:
- a Cat module name that is not a module folder, a plan or a known name,
- a long dash or an ellipsis outside code,
- a missing `What we already know` chapter.

Some warnings are on purpose, such as a plan that says a module was renamed or merged. Leave those.

## Not covered
The script cannot tell whether a decision is right or a fact is true. Read the plan again before you hand it over.
