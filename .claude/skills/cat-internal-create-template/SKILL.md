---
name: cat-internal-create-template
description: Create a new template and the skill that uses it, from the two skeletons BaseTemplate.template.md and BaseSkill.template.md. Use when the owner wants a new kind of file that Claude creates from a template, such as a plan.
argument-hint: "[template name] [what it creates]"
---

# Create a template

A template is a markdown file that Claude copies to create a new file. Every template lives in its own skill folder, next to a `SKILL.md` that holds the instructions. This skill creates both together, so every template follows the same structure.

Load the `cat-internal-template-concepts` skill and the `cat-internal-create-header` skill first. The first explains regions, templates and placeholders. The second explains the header.

## Files
- [BaseTemplate.template.md](BaseTemplate.template.md): the skeleton of the main template file.
- [BaseSkill.template.md](BaseSkill.template.md): the skeleton of the `SKILL.md` of the new skill.

## What goes where
- The main template file, `<name>.template.md`, is exactly the start of the created file. Claude copies it as it is.
- A template that needs small templates, such as a badge or a phase, keeps them in `<name>.parts.template.md`. Claude reads that file only when it adds one of them.
- The instructions never go into a template file. They go into the `SKILL.md`.
- The `SKILL.md` documents every region, every small template and every placeholder that the template files use.
- The skill folder is `.claude/skills/<SkillName>/`. Use the `cat-internal-` prefix for a skill for the owner of the toolkit and the `cat-` prefix for a skill for developers who use the toolkit.

## Create
1. Ask the owner for anything you cannot read from the request: the name of the skill, what the created file is, where it lives, and which regions and small templates it needs. Do not decide these yourself. Check that the name does not clash with an existing skill.
2. Create the folder `.claude/skills/<SkillName>/`.
3. Copy `BaseTemplate.template.md` to `<name>.template.md` in that folder. Replace `[[SkillName]]` and `[[FileKind]]`, and replace `[[Body]]` with the content the created file starts with. Mark every part that Claude must find later as a region. Keep the `Header` and `TemplateSkill` regions.
4. If the created file needs small templates, create `<name>.parts.template.md`. Put one template per part between template markers, as described in the concepts skill. Do not indent the content.
5. Copy `BaseSkill.template.md` to `SKILL.md` in that folder and fill it in:
   - the front matter and the title,
   - the chapters about the files, creating, regions and updating,
   - a chapter for every task the skill must do, such as building a part of the created file,
   - the placeholders, one entry for each.
6. Run through the checklist below.
7. Add a table row and an entry for the skill in `.claude/skills/README.md`.
8. Run the `cat-internal-verify-docs` skill.

## Checklist
- Every region in the template files is described in the `SKILL.md`.
- Every small template is named in the `SKILL.md`, with the moment to use it.
- Every placeholder in the template files is listed in the `SKILL.md`.
- The template files hold no instructions.
- The `TemplateSkill` comment names the new skill, so the files that use the template can be found with `git grep`.
- The text follows the style rules in `CLAUDE.md`: plain and direct, short sentences, no long dashes, no ellipses.
- Nothing in the skill is a decision the owner did not make. Open points are questions for the owner.

## Placeholders
- [[SkillName]]: The name of the skill, such as `cat-internal-create-plan`.
- [[FileKind]]: What the created file is called in text, such as `plan`.
- [[Body]]: The content the created file starts with, after the header and the `TemplateSkill` region.
- [[Description]]: The description of the skill. It says what the skill does and when to use it.
- [[ArgumentHint]]: The hint for the arguments of the skill, such as `[create|update] [name]`.
- [[Title]]: The main title of the `SKILL.md`.
- [[Intro]]: One short paragraph about what the skill does.
- [[TemplateFile]]: The file name of the main template file, such as `plan.template.md`.
