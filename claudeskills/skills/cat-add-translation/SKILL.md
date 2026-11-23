---
name: cat-add-translation
description: Mark an entity as translatable, map the translation table and read or save a text with Cat.Localizations. Use when the developer wants translated names or texts stored in the database, a multi language catalog, or says "add a translation".
---

# Add a translation

`Cat.Localizations` keeps the translations of entity fields in one table. The entity keeps its default text, and that text is the fallback.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Mark the entity", "Map the table", "Register the translator", "Read a text", "Save a translation", "Which culture is used" and "The default culture of background work" in the readme of `Cat.Localizations`. The readme is `modules/Cat.Localizations/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.localizations/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.

## Steps
1. Ask which entity and which fields get translations, and which cultures the service supports.
2. Mark the entity with `ICatTranslatable`. `DataModels` needs only `Cat.Localizations.Abstractions`, so add that one there.
3. Map the table in `OnModelCreating` of the context and register the translator, as the two chapters show. Both need `Cat.Localizations` in `Infrastructure`.
4. Add the translation table. A code first service gets it through a migration. A database first service gets a table file, see `cat-add-entity`, and it must match the model. Say that nothing compares the two.
5. Read the text in the handler through `ICatTranslator`, with the default text of the entity. Read many texts with one call, not one call per row.
6. Save a translation with `SetTextAsync` and the `SaveChanges` of the entity change, so both succeed or fail together.
7. A service with jobs or other background work sets the default culture once in `Program.cs`, as the readme shows.
8. Add a test for a translated and a missing text.
9. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- The entity keeps its default text. Never remove it, because it is the fallback.
- Never call `SetTextAsync` in a loop over a large set. Read the readme for the many-texts calls.
