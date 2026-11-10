---
name: docs-check
description: Check the markdown of the repository locally and fast, with no web requests. Finds broken relative links, wrong letter case in paths, missing anchors, unclosed code fences, a lost readme marker, skills missing from the skills overview, and forbidden punctuation. Use at the end of a task that changed markdown, a link target, a heading or a file name, and after every rename or move.
argument-hint: "[folder or file to limit the check]"
---

# Docs check

A local check of all markdown. It takes a few seconds and sends no requests. The `link-check` skill is the slow crawl of the published site and runs only when the owner asks. This one runs whenever docs or file names change.

## Run

```
powershell.exe -NoProfile -ExecutionPolicy Bypass -File .claude/skills/docs-check/check-docs.ps1
```

- Add `-Path <file or folder>` to limit the check, for example `-Path plans`.
- Add `-IncludeGenerated` to include the generated pages in `modules/*/namespaces`. They are skipped by default, because they are generated and large.
- The exit code is 1 when there is an error. Warnings do not change it.
- Do not use `-Path` on the final run before you hand work over. A change in one file can break a link in another.

## What it checks
Errors, which you must fix:
- A relative link, image, `src` or `href` that points to a file or folder that does not exist.
- A path with the wrong letter case. The published site runs on Linux, where case matters, and Windows hides the mistake.
- A link to an anchor that no heading of the target markdown file has. Anchors follow the GitHub rules: lowercase, punctuation removed, spaces become hyphens, and a repeated heading gets `-1`, `-2`.
- A code fence that is never closed.
- A `Header` region that differs from the header template of the `cat-internal-create-header` skill, or that has no comment line with its `RootPath`. Template files (`*.template.md`) are skipped.
- A module plan in `plans/Cat.*.md` that has no place in the readme. A module that exists needs a `[Plans](./plans/Cat.X.md)` link in the module overview. A module that does not exist yet needs a `[Cat.X](./plans/Cat.X.md)` row in the Future modules table. A module is never in both, and a row never links to another plan.
- A missing or repeated `<!-- Modules start-->` or `<!-- Modules end-->` marker in the readme.
- A skill folder without `SKILL.md`, with a `name` that differs from the folder, or without a row and an entry in `.claude/skills/README.md`.

Warnings, which you should fix unless there is a reason:
- A long dash, `--` or an ellipsis in text. Code spans and code blocks are skipped. CLAUDE.md and template files are skipped.

## What it does not check
- External links. Use `link-check` for those, when the owner asks.
- Anchors of the Jekyll site. The check follows the GitHub rules. Jekyll can generate a different id for a heading with unusual characters.
- Whether the text is true or reads well.
- Mermaid syntax. Render it to be sure.

## After a rename or move
1. Use `git mv`.
2. Run `git grep` for the old name and fix every reference.
3. Run this check. It finds what the search missed, such as a link with a changed anchor.

## Fixing findings
- Fix the link or the heading, whichever is wrong. Do not delete a link only to make the check pass.
- A heading that changed breaks every link to its anchor. Search for the old anchor with `git grep`.
- Never edit the generated pages in `modules/*/namespaces` by hand.
