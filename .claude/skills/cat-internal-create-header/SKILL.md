---
name: cat-internal-create-header
description: Create or update the header of a template-based markdown file (stylesheet link, banner table and navigation bar) from header.template.md. Updates every file that uses the header when the header template changes. Use when a new file gets its header, or when the owner changes the header template.
argument-hint: "[create|update] [file]"
---

# Header

The header is the banner and the navigation bar at the top of the markdown files that are created from a template, such as the plans. It is written once in [header.template.md](header.template.md), so no template repeats it.

Load the `cat-internal-template-concepts` skill first. It explains regions and placeholders.

## Rules
- A template that wants the header holds an empty `Header` region at the top of the file that it creates.
- The template file holds the `Header` region. Its first line is the comment line that names the template and the `RootPath`. The comment line stays in the created file. It is how Claude finds every file that uses the header.
- A new template that wants the header only needs the empty `Header` region and a pointer to this skill.

## Create
1. Open [header.template.md](header.template.md) and copy the whole `Header` region, including the region markers and the comment line.
2. Replace `[[RootPath]]` everywhere in the copy with the relative path from the new file to the repository root.
3. Put the copy in the empty `Header` region at the top of the new file.
4. Run the `docs-check` skill.

## Update
Use this when the owner changes the header template and asks to update the files that use it.
1. Find the files with `git grep --untracked -l "Header template: @"`. Skip the files in the `.claude` folder. They only describe the header.
2. Read the `RootPath` from the comment line of each file.
3. Replace the whole `Header` region with the `Header` region of the template, using that `RootPath`.
4. Run the `docs-check` skill. It reports every `Header` region that differs from the template.

## Placeholders
- [[RootPath]]: The relative path from the file to the root of the repository.
  - It is `..` for a file in the `plans` folder.
  - It never ends with a slash.
