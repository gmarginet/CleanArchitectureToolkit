---
name: cat-internal-template-concepts
description: The basic concepts of CAT templates, such as regions, template markers, placeholders and indentation. Load it first whenever you use or create a template, or run a skill that works with a template file.
---

# Template concepts

A template is a markdown file that Claude copies to create a new file. These are the rules every template skill shares. A skill that works with a template loads this skill first.

## Regions
- A region marks a part of a template file or of a created file, so Claude can find and change it.
- A region starts with an HTML comment that holds the words `region start`, a colon and the region name: `<!-- region start: Name-->`.
- A region ends with an HTML comment that holds the words `region end`, a colon and the same name: `<!-- region end: Name-->`.
- Always match the complete marker, because one name can be the start of another (`Phase 1` and `Phases`).
- The region markers stay in the created file. They are how Claude finds the part later.

## Templates
- A template is a piece of content in a template file that Claude copies to the created file when the content is needed. A phase of a plan is an example.
- A template starts with `<!-- ==================== template start: Name ====================-->` and ends with `<!-- ==================== template end: Name ====================-->`. The `=` signs make a template marker easy to tell from a region marker, which is also used inside the templates.
- Match the name between `template start:` and the closing `=` signs, as for regions.
- When Claude uses a template, he copies the content and never the template markers.
- Replace every placeholder the template contains.
- The content of a template is not indented. Claude follows the indentation of the place where the content gets copied to.

## Placeholders
- A placeholder is written as `[[Name]]`. Claude replaces it with the real value.
- The `SKILL.md` of the skill that owns the template lists every placeholder with its meaning.

## What the template files hold
- A skill has one `<name>.template.md` that is exactly the start of the created file, with placeholders. Claude copies it as it is. It holds the regions that must exist in the created file.
- A skill that needs small templates, such as a badge or a phase, keeps them in `<name>.parts.template.md`. Claude reads that file only when it adds one of them.
- No instructions. The instructions are in the `SKILL.md` of the skill that owns the files.
- A created file starts with an empty `Header` region. The `cat-internal-create-header` skill fills it.
