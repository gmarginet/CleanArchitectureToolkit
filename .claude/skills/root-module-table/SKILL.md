---
name: root-module-table
description: Update the module table in the root README.md. Use when a module is added or removed, when a module description changes, or when a module goes in or out of development.
argument-hint: "[module name] [stable|development]"
---

# Root readme module table

Keep the module table in the root `README.md` in sync with the folders in `modules/`.

## Scope
- Edit only between `<!-- Modules start-->` and `<!-- Modules end-->`.
- Never remove the blockquote above the table. It says modules with the status in development will probably have breaking changes.
- Never remove the comment with the badge snippet, right after `<!-- Modules start-->`.

## Table format
- Header row: `| Module | | Description |`. The status column has no header text.
- Separator row: `|--------|--------|-------------|`
- One row per folder in `modules/`, sorted by name.
- Row format: `| [[[ModuleName]]](./modules/[[ModuleName]]/README.md) | [[StatusBadge]] | [[ModuleDescription]] |`
- The link always points to the module readme, also for modules that are still in development.
- `[[ModuleDescription]]` is one short sentence about what the module is used for. Base it on the intro of the module readme.
- Follow the documentation style in CLAUDE.md: plain and direct, no long dashes, no ellipses.

## Status
- A module in development gets this badge in the status cell of its row:
  `[![In development](https://img.shields.io/badge/status-in%20development-orange)](#module-overview)`
- A stable module has an empty status cell. Stable modules have no badge.
- To put a module in development, add the badge. To make it stable, empty the cell.

## Blank lines
- Keep a blank line between the badge snippet comment and the table.
- Keep a blank line between the last table row and `<!-- Modules end-->`.
- Without these blank lines Jekyll treats the table as part of the HTML comment and shows plain text.

## Steps
1. List the folders in `modules/`. Ignore files such as `CatModuleReadmeTemplate.md`.
2. Read the intro of each module readme that needs a new or changed row.
3. Edit the rows. Keep the existing rows untouched when nothing changed.
4. Check that the table has exactly one row per module folder and that it is sorted by name.
