---
name: cat-internal-create-plan
description: Create, build and update a plan in the plans folder from plan.template.md. Handles the phases, the open questions and their answers, the status badge, converting an old plan, and updating plans after the template changed. Use when a plan is created, when the owner asks to build a phase, answers an open question, asks to convert an old plan, or changes the plan template.
argument-hint: "[create|build|answer|convert|update] [plan name]"
---

# Plans

A plan describes what we are going to build in phases, with the open questions per phase. This skill creates plans, keeps them up to date and builds their phases.

Load the `cat-internal-template-concepts` skill first. It explains regions, templates and placeholders.

## Files
- [plan.template.md](plan.template.md): the start of every new plan. Copy it as it is and replace the placeholders.
- [plan.parts.template.md](plan.parts.template.md): the small templates, such as the badges, a phase and a question. Read it when you add one of them.
- The header comes from the `cat-internal-create-header` skill.

## Creating a plan
1. Check that no plan exists yet. Check the name against the folders in `modules/`, the files in `plans/` and the repo overview table of the readme.
2. Read the sources, see [Where the facts come from](#where-the-facts-come-from). Search them for the module name and its idea.
3. Copy `plan.template.md` to `plans/<PlanName>.md`. The plan file is named after the plan, such as `Cat.Messaging.md` or `Demo.md`.
4. Replace `[[PlanName]]`.
5. Fill the `Header` region by following the `cat-internal-create-header` skill.
6. Fill the `StatusBadge` region with the `NotStartedBadge` template.
7. Add phase 1 with the `Phase` template, at the end of the file, and its `PhaseListLine` in the `Phases` region. Put what you found in the `PhaseDescription` region and the unknowns in numbered open questions.
8. Link the plan from the readme, see [Where a module plan is linked](#where-a-module-plan-is-linked).
9. Run the `cat-internal-verify-docs` skill.

## Rules for the content
- `Decided` in a phase description holds only what the owner decided, or what the existing docs state. Name the document when it comes from one. Everything else is an open question. Never invent a decision.
- Facts in the description come from documents and code that you read. Do not add facts you did not check. Mark a guess as something to check.
- One decision per open question, answerable in a sentence. Put the blocking questions first.
- A plan never says a module "will" exist in a certain version or on a date. It only says what is decided.
- Follow the style rules in CLAUDE.md.

## Where the facts come from
Read these before you write, and search them for the module name:
- the readme: the application architecture, the service project structure and the module tables,
- the other plans in `plans/`,
- the readmes of the existing modules that the plan touches,
- the demo code in `demo/` and `demo/README.md`, with the Roslyn tools for symbols and references.

## Where a module plan is linked
Only plans of modules (`plans/Cat.*.md`) are linked from the readme. `Demo.md` and `Skills.md` are not.
- Every plan has a row in the repo overview table of the readme. `Demo.md` belongs to the row `Cat.Demo` and `Skills.md` to the row `Cat.Skills`.
- An item that is not built yet has the New badge and its name links to the plan. A built item with a plan has the In development badge. The badge links to the plan in both cases. The `cat-internal-create-readme` skill covers the table.
- When a future module is started with the `cat-internal-create-module` skill, its row changes from New to In development and its name links to the module readme.
- Keep the plan until the module has done everything in it and the owner agrees that it can go. When the plan goes, remove its link from the readme too.
- A module readme never links to the plan. Only the readme does. A module readme grows until it holds everything about how the module works and how to use it, so the plan can be removed.
- The `cat-internal-verify-docs` skill checks that every module plan has exactly one place in the readme.

## Keeping the other documents in step
Use this when an answer or a decision changes more than one plan, and when a module is renamed, merged or dropped.
1. Search every plan, the readme, `demo/README.md` and the module readmes for the module name and for the topic. Use `git grep --untracked -l`, without the generated `namespaces` pages.
2. Fix what no longer matches. A single decision often touches several plans, for example who owns the outbox or where an interface lives.
3. When a module is renamed, merged or dropped: rename or delete the plan file with `git mv` or `git rm`, fix the README tables, fix the links in the other plans and say so in the plan that took over.
4. Run the `cat-internal-verify-docs` skill.

## Phases
- Every plan has at least one phase. Every phase gets its own chapter and number.
- A new phase is always added at the end of the file.
- When Claude adds a phase, it also adds its `PhaseListLine` to the `Phases` region.
- Removing a phase removes the line and updates the status badge.

## Building a phase
- When the owner asks Claude to build the next phase of a plan, Claude first double-checks that everything is clear and answered in that phase.
- If not, Claude creates one or more open questions for the phase and puts the plan in the `PlanningBadge` status.
- If the check finds nothing open, Claude puts the plan in the `ReadyToStartBuildingBadge` status before the build starts.
- When new questions come in view during the build, Claude adds them to the phase it is building and puts the plan back in the `PlanningBadge` status.
- When the phase is fully built, Claude does the following in this order:
  1. Update the README of the module or demo the plan belongs to, using the `cat-internal-create-module-readme` or `demo-readme` skill, so it incorporates all the info from the phase description.
  2. Search the other markdown files for mentions of what the phase changed (`git grep --untracked -l`, without the generated `namespaces` pages) and update the READMEs and plans that are now out of date.
  3. Remove the phase.
- If no phases are left after removing a phase that was built, Claude can ask if it can remove the plan file.

## Regions
- `Header`: The header of the plan, filled by the `cat-internal-create-header` skill.
- `TemplateSkill`: Points to this skill. The text in it is how Claude finds every plan that was made with this template.
- `StatusBadge`: Always contains one of the badges from the badge templates.
  - A plan that is just created gets the badge from the `NotStartedBadge` template.
  - A plan without open questions stays on `NotStartedBadge` until the owner asks Claude to build a phase.
  - Once the first phase in the plan has open questions, use the badge from the `PlanningBadge` template.
  - Once the last open question of the first phase is closed, use the badge from the `ReadyToStartBuildingBadge` template.
  - We always use the first phase to determine the status. When a phase gets deleted, the next phase becomes the first one and the badge is set again from that phase, following these rules.
  - If no phases are left, Claude can ask if it can remove the plan file.
- `Phases`: A list of all the phases of the plan.
  - Use the `PhaseListLine` template to add a line to the list.
- `PhaseDescription`: A detailed description of what we are going to build and how it is going to be used.
  - It can start as a short idea and grow into a full description as questions get answered.
  - A big phase can use sub chapters, but that is not required.
- `PhaseOpenQuestions`: A list of open questions about the building of the phase.
  - To add a question, use the `OpenQuestion` template.
  - The owner answers a question by creating a new chapter at the end of the question region, with a title like the `AnswerTitle` template.
  - When Claude processes the answer there are 3 possible outcomes:
    - A. The answer closes the question.
    - B. The answer is not clear enough and results in a sub question.
    - C. The owner asks to move this to another phase.
  - Use the answer process flow below to continue.

## Answer process flow
These rules apply to every question region:
- Everything about one question stays inside its `Question N` region, in the order it happens, so the region holds the full history.
- A new question or answer is always added at the end of the region, just before the end marker.
- Sub questions and their answers get the numbers N.1, N.1.1 and so on, all with the same heading level as the first answer.
- Never change or remove an answer while the question is open.
- If an answer is not enough, always add a sub question for the open part.

The outcomes of the answer:
- A. The answer closes the question, including all the sub questions.
  - Incorporate the outcome of the question into the description of the phase, in the `PhaseDescription` region of the phase the question belongs to.
  - Then remove the question chapter that is now fully answered.
- B. The answer is not clear enough and results in a sub question.
  - Create one or more sub questions by using the `SubQuestion` template.
  - The owner answers a sub question by creating a new chapter at the end of the question region, with a title like the `SubAnswerTitle` template.
  - When Claude processes this answer there are the same 3 possible outcomes: A, B and C. Use this answer process flow to continue.
- C. The owner asks to move this to another phase.
  - If the phase the owner asks to move it to does not exist, first create the phase as described above.
  - Then look at what is still open in the question region.
  - If nothing is answered yet, copy the full question region, including all the sub questions and keeping its number, to that phase. Then remove it from the current phase.
  - If part is answered:
    - Incorporate the answered parts into the description of the current phase, like outcome A.
    - The answer says what to do with the rest: add it to the description of the other phase, or add it as an open question of the other phase.
    - An open question gets a new number and the `OpenQuestion` template, and must make sense on its own.
    - Then remove the original question region from the current phase.

## Updating plans after the template changed
Use this when the owner changes `plan.template.md` or `plan.parts.template.md` and asks to update the plans.
1. Find the plans with `git grep --untracked -l "cat-internal-create-plan skill to update this plan"`. Skip the `.claude` folder.
2. Work out from the change what differs between the old and the new template. Apply that change to each plan with an edit.
3. Never change the content of a phase, such as its description or its questions.
4. For the header, follow the `cat-internal-create-header` skill.
5. Run the `cat-internal-verify-docs` skill.

<!-- region start: PlanConversion-->
## Converting an old plan
This chapter is only needed while we convert the plans from before this template.
Once all plans are converted, remove this whole `PlanConversion` region from this skill.
- Before Claude starts converting the old plan, it first verifies that everything is clear for the conversion. If not, it asks the owner what to do before it starts.
- When the owner asks Claude to convert a plan, create a new file with the module name followed by a 2, such as `Cat.Messaging2.md` for `Cat.Messaging.md`.
- Keep the old file until the owner has checked the new one.
- When the owner says the new file is ok, remove the old file and give the new file the original name, such as `Cat.Messaging.md`.
  - `git mv` only works on a file that git tracks, and the new file is untracked.
  - So remove the old file with `git rm` (add `-f` when the old file has uncommitted edits, after you checked that the new file already holds them), move the new file to the original name with a plain move, and unstage the deletion with `git reset -q <file>`. Git then shows the plan as a modified file.
  - If the new file is already tracked, use `git mv` as usual.
- The new file is a plan made with this skill. The old plan becomes phase 1 of it.
- The plan name in the new file stays the module name, so without the 2.
- The open questions of the old plan become open questions of phase 1, with sub questions where the old plan already has several levels.
- All other info goes into the description of phase 1.
- Do not copy and paste it. Write a clear description, with structure where needed, that is easy to read and makes it easy to check what will be built and how it will be used.
- When the plan is converted, Claude compares the description of phase 1 with the README of the module or demo and with the code.
  - If parts of the description are already built, Claude notifies the owner with detailed info about what is built and where.
  - The owner can then ask Claude to update the description of phase 1, so it only mentions what still needs to be built.
<!-- region end: PlanConversion-->

## Placeholders
- [[PlanName]]: The name of the plan.
  - For a module plan that is the module name, for the demo plan that is Demo, and so on.
  - The plan file is named after the plan, such as `Cat.Messaging.md` or `Demo.md`.
- [[PlanAnchorName]]: The name of the plan, transformed to lowercase with all punctuation marks and spaces removed.
- [[PhaseNumber]]: The number of a phase.
  - It is a unique number within the plan file.
  - This number never changes, so even if a phase gets deleted after it gets built, all following phases keep their number.
  - The first phase of a plan gets number 1.
  - A new phase gets the highest phase number in the file plus 1.
- [[QuestionNumber]]: The number of a question.
  - It is a unique number within the plan file.
  - This number never changes, so even if a question gets deleted after it is answered, all other questions keep their number.
  - The first question of a plan gets number 1.
  - A new question gets the highest question number in the file plus 1.
- [[Question]]: The actual question.
- [[SubQuestionNumber]]: The number of a sub question.
  - It is the number of the question the sub question belongs to, concatenated with a dot and then a number that is unique within the question it belongs to.
  - That number never changes, so even if a question gets deleted after it is answered, all other questions keep their number.
  - A new sub question gets the highest sub question number within its question plus 1.
