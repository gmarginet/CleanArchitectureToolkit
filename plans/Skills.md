# Plans for the CAT skills

Claude Code skills for the developers who use the toolkit, shipped as a plugin that another Claude user can install.  
Status: not started. This is not a module. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Opinion: why it fits and what the risks are](#opinion-why-it-fits-and-what-the-risks-are)
- [How to publish them](#how-to-publish-them)
- [Where they live in the repository](#where-they-live-in-the-repository)
- [Possible skills](#possible-skills)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

The repository already has skills in `.claude/skills/`, but they are for the people who work on CAT itself. This plan is about skills for the people who use CAT in their own projects.

A skill for a developer teaches Claude the CAT conventions inside the developer's repository, for example "add a command with its handler, validator and test". The developer picks the skills they need, as they pick modules.

## What we already know

From the repository:

- `.claude/skills/` holds the maintainer skills, such as `new-module`, `module-plan`, `docs-check` and `git-commit`. They are listed in `.claude/skills/README.md`.
- The root readme describes the conventions a skill would teach: the service project structure, the `Abstractions` split, handler registration, `ICatResponse` and error codes.
- [Cat.Templates.md](Cat.Templates.md) plans `dotnet new` templates for the project structure. A scaffold skill overlaps with it.
- `docs-check` checks all markdown in the repository, and `pages.yml` builds the GitHub Pages site from the markdown.
- `skip-pub` goes at the end of a commit subject when no code in `modules/` changed. Files under `plugins/` would not be published as NuGet packages.

## Opinion: why it fits and what the risks are

This is the opinion I gave when you asked about the idea. It is not a decision.

Why it fits:

- CAT has strong conventions. A skill that scaffolds a handler, a validator and a test teaches Claude those conventions in the developer's own repository.
- It matches the toolbox idea. Each skill covers one module, and a developer installs only what they use.

Risks:

- **Drift.** A skill that copies API details goes stale when a module changes. Keep the skills about workflow and conventions, and link to the module readmes for the API.
- **Versions.** Skills and NuGet packages are versioned separately. A plugin version note per module release would help.
- **Names.** The maintainer skills in `.claude/skills/` could clash with consumer skills of similar names. Consumer skills need a prefix such as `cat-`. `cat-verify` is already a maintainer skill, so check every name.

## How to publish them

I wrote this from memory. Check the current plugin docs for the exact manifest fields before the build.

The usual route is a Claude Code plugin in a marketplace:

- **Marketplace.** A `.claude-plugin/marketplace.json` in a GitHub repository. A user runs `/plugin marketplace add <owner>/<repo>`, then `/plugin install <plugin>@<marketplace>`. Updates come through the same commands.
- **Plugin.** A folder with `.claude-plugin/plugin.json` and a `skills/<name>/SKILL.md` per skill. It can also hold commands, hooks and an MCP config later.
- **Fallback.** The user copies a skill folder into `.claude/skills/` in their project or into `~/.claude/skills/`. It is simple, but has no updates.

My recommendation was the plugin and marketplace route, starting with one plugin that holds all the skills, because the skills are small. One plugin per module would match the toolbox idea better but costs more to maintain.

## Where they live in the repository

Keep them out of `.claude/skills/`, which is for people working on CAT. A proposal:

```
.claude-plugin/marketplace.json
plugins/cat/.claude-plugin/plugin.json
plugins/cat/skills/cat-add-command/SKILL.md
plugins/cat/skills/...
```

Things to check when we build it:

- **Markdown checks.** `docs-check` and the skills overview rule in `CLAUDE.md` need to cover the new folder, or exclude it on purpose.
- **Pages site.** `pages.yml` builds the Jekyll site from the markdown. Decide whether the skill files should appear there.
- **Commit messages.** A commit that only touches `plugins/` gets ` (skip-pub)`.

## Possible skills

Ideas only. None of them is decided. The names are suggestions.

**Start**

- `cat-new-service`: scaffold a service with the project structure of the root readme. It overlaps with `Cat.Templates`, so decide which one owns it.
- `cat-add-module`: add a module to a service, with the right packages, the registration call and the project references. It keeps the core on the abstractions.

**Daily work**

- `cat-add-command`: a command, its handler, a validator and a unit test.
- `cat-add-query`: a query, its handler and a unit test.
- `cat-add-service-request`: a service request with its handler, for use cases that call several commands or queries.
- `cat-add-endpoint`: map a service request to a minimal API endpoint, with the response types listed.
- `cat-add-validator`: validation rules for a request, with codes and messages.
- `cat-add-workflow`: a workflow with its state and steps.
- `cat-add-event`: an event and its subscriber with the event aggregator.
- `cat-add-decorator`: an open generic decorator and its registration, in the right order. See [Cat.Decorators.md](Cat.Decorators.md).

**Data**

- `cat-add-entity`: an entity on the `Cat.EFCore` base classes, with its configuration and migration.
- `cat-error-codes`: define error codes with a prefix and keep them unique. See [Cat.Responses.md](Cat.Responses.md).

**Check and migrate**

- `cat-review`: check a service against the conventions: references, registration, response handling.
- `cat-upgrade`: help move to a new version of a module, using the release notes.

**Later, when the modules exist**

- Skills for the planned modules, such as messaging, sagas, scheduling and authorization. They wait for the modules.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Idea | Create skills for the developers who use the toolkit. Plan them here and list them in the root readme under `Other future things`. |

### Open

- **One plugin or several.** One plugin for all skills is simple. One plugin per module matches the toolbox idea and costs more to maintain.
- **First skills.** Which ones come first? My suggestion is scaffold a service, add a command or query with its handler and test, and add a validator.
- **Overlap with `Cat.Templates`.** Who scaffolds a new service, the template or the skill?
- **Folder and name.** `plugins/cat/` and the marketplace name are a proposal. Names need a prefix to avoid clashes with the maintainer skills.
- **Drift.** How do we keep the skills true when a module changes? Link to the readmes, add a check, or review the skills at every release?
- **Versions.** Does the plugin version follow the module versions, or does it have its own?
- **Markdown checks.** Does `docs-check` cover `plugins/`, and does the Pages site show it?
- **Plugin docs.** The publishing steps above come from memory and must be checked.
- **Where it is documented.** A short chapter in the root readme for developers, once the first skill exists.

## Questions before building

1. One plugin for all skills, or one per module?
2. Which skills do we build first?
3. Do the skills or `Cat.Templates` scaffold a new service?
4. What do we call the plugin and the marketplace, and which prefix do the skills get?
5. How do we keep the skills in step with the modules?
6. Does the plugin have its own version, or does it follow the modules?
7. Should the skill files appear on the Pages site?
8. Do we write a plan for each skill, or only one for the whole idea?
