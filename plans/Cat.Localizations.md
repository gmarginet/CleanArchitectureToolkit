# Plans for Cat.Localizations

Future work in the existing `Cat.Localizations` module: finish it and use it in the demo.  
Status: not started. `Cat.Localizations` itself exists and is marked in development. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

The module defines a contract to look up localized strings by key, so the rest of the app does not depend on one provider. It ships only a no-op implementation that returns the key. To be useful it needs a real provider, and the demo needs it for category names, order statuses and email texts.

## What we already know

From the module readme:

- It has `Cat.Localizations.Abstractions` with `ICatLocalizer`, and `Cat.Localizations` with the no-op localizer and the module registration.
- The no-op localizer returns the key itself. It fills in placeholders when the key contains them, in the order of the arguments.
- The root readme marks the module as in development.

From the demo:

- [Demo.md](Demo.md) wants categories, order statuses and email texts in a few languages.
- Category names are plain text today, because `Cat.Localizations` is not used yet.
- The demo waits until the module is stable.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Demo timing | The demo waits until the module is stable. See [Demo.md](Demo.md). |

### Open

- **Providers.** Which real implementation do we ship or document: resource files, `IStringLocalizer` from ASP.NET Core, or a database? Each one is a project a developer can pick or skip.
- **Culture.** Where does the current culture come from: the request, the user, or a parameter?
- **Stored data.** Category names live in the database. Do we localize them through keys, or store a translation per language?
- **Error messages.** Do codes from `Cat.Responses` and `Cat.Validators` get localized messages through the localizer? See [Cat.Responses.md](Cat.Responses.md).
- **Finish line.** What must be true before we drop the "in development" badge?

## Questions before building

1. What is left before the module is stable?
2. Which provider do we build first?
3. Where does the culture come from?
4. How do we localize data that sits in the database?
5. Do the validation and error messages go through the localizer?
