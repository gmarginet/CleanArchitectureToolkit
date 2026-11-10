---
name: [[SkillName]]
description: [[Description]]
argument-hint: "[[ArgumentHint]]"
---

# [[Title]]

[[Intro]]

Load the `cat-internal-template-concepts` skill first. It explains regions, templates and placeholders.

## Files
- [[[TemplateFile]]]([[TemplateFile]]): the start of every new [[FileKind]]. Copy it as it is and replace the placeholders.
- The header comes from the `cat-internal-create-header` skill.

## Creating a [[FileKind]]
1. Copy `[[TemplateFile]]` to the place where the new [[FileKind]] belongs.
2. Replace the placeholders.
3. Fill the `Header` region by following the `cat-internal-create-header` skill.
4. Run the `docs-check` skill.

## Regions
- `Header`: The header of the [[FileKind]], filled by the `cat-internal-create-header` skill.
- `TemplateSkill`: Points to this skill. The text in it is how Claude finds every [[FileKind]] that was made with this template.

## Updating files after the template changed
Use this when the owner changes the template and asks to update the files that use it.
1. Find the files with `git grep --untracked -l "[[SkillName]] skill to update this [[FileKind]]"`. Skip the `.claude` folder.
2. Work out from the change what differs between the old and the new template. Apply that change to each file with an edit.
3. Never change the content the owner wrote.
4. For the header, follow the `cat-internal-create-header` skill.
5. Run the `docs-check` skill.

## Placeholders
