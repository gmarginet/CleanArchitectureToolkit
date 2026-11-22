<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: .. -->
<link href="../resources/styles/style.css" rel="stylesheet" />
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-plan skill to update this plan.-->
<!-- region end: TemplateSkill-->

# Plans for `Cat.ClaudeSkills` <!-- omit in toc -->  

<!-- region start: FirstStableVersion-->
**First stable version:** not reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 1](#phase-1)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
Claude Code skills for the developers who use the toolkit, shipped as a plugin that another developer can install. This is not a module.

#### The idea
The repository already has skills in `.claude/skills/`, but they are for the owner of the toolkit. This plan is about skills for the developers who use CAT in their own projects.

A skill for a developer teaches Claude the CAT conventions inside the repository of the developer, for example "add a command with its handler, validator and test". The developer picks the skills they need, as they pick modules. A skill creates its files through a `dotnet new` template of [Cat.Templates.md](Cat.Templates.md#phase-1), and does the rest itself.

#### Needs
Phase 1 of the plan [Cat.Templates.md](Cat.Templates.md#phase-1), built first.

#### Background
From the repository:
- `.claude/skills/` holds the skills for the owner, such as `cat-internal-create-module`, `cat-internal-create-module-readme`, `cat-internal-verify-docs` and `cat-internal-commit`. They are listed in `.claude/skills/README.md`.
- The readme describes the conventions a skill would teach: the service project structure, the `Abstractions` split, handler registration, `ICatResponse` and error codes.
- [Cat.Templates.md](Cat.Templates.md#phase-1) plans `dotnet new` templates for a service and for the single parts of a service.
- `cat-internal-verify-docs` checks all markdown in the repository, and `pages.yml` builds the GitHub Pages site from the markdown.
- `skip-pub` goes at the end of a commit subject when no code in `modules/` changed. Files under `plugins/` would not be published as NuGet packages.

#### What exists today
- No skill for developers exists yet. The folders `plugins/` and `.claude-plugin/` do not exist.
- The readme lists the idea in the repo overview, as `Cat.ClaudeSkills` with the type Tooling and the status New.
- The skills in `.claude/skills/` are all for the owner, and all 16 of them use the `cat-internal-` prefix now.
- The repository has a `_plugins` folder. It belongs to the Jekyll site and is not related to this plan.

#### Why it fits and what the risks are
This is the opinion Claude gave when the owner asked about the idea. It is not a decision.

Why it fits:
- CAT has strong conventions. A skill that scaffolds a handler, a validator and a test teaches Claude those conventions in the repository of the developer.
- It matches the toolbox idea. Each skill covers one module, and a developer installs only what they use.

Risks:
- **Drift.** A skill that copies API details goes stale when a module changes. Keep the skills about workflow and conventions, and link to the module readmes for the API. The files themselves come from the templates, which the build tests.
- **Versions.** Skills and NuGet packages are versioned separately. A plugin version note per module release would help.
- **Names.** The skills for the owner in `.claude/skills/` could clash with skills for developers of similar names. The prefixes keep them apart.

#### How to publish them
Claude wrote this from memory. Check the current plugin docs for the exact manifest fields before the build.

The usual route is a Claude Code plugin in a marketplace:
- **Marketplace.** A `.claude-plugin/marketplace.json` in a GitHub repository. A developer runs `/plugin marketplace add <owner>/<repo>`, then `/plugin install <plugin>@<marketplace>`. Updates come through the same commands.
- **Plugin.** A folder with `.claude-plugin/plugin.json` and a `skills/<name>/SKILL.md` per skill. It can also hold commands, hooks and an MCP config later.
- **Fallback.** The developer copies a skill folder into `.claude/skills/` in their project or into `~/.claude/skills/`. It is simple, but has no updates.

The recommendation of Claude was the plugin and marketplace route, starting with one plugin that holds all the skills, because the skills are small. One plugin per module would match the toolbox idea better but costs more to maintain.

#### Where they live in the repository
Keep them out of `.claude/skills/`, which is for the owner. A proposal:

```
.claude-plugin/marketplace.json
plugins/cat/.claude-plugin/plugin.json
plugins/cat/skills/cat-add-command/SKILL.md
plugins/cat/skills/...
```

Things to check when we build it:
- **Markdown checks.** `cat-internal-verify-docs` and the skills overview rule in `CLAUDE.md` need to cover the new folder, or exclude it on purpose.
- **Pages site.** `pages.yml` builds the Jekyll site from the markdown. Decide whether the skill files should appear there.
- **Commit messages.** A commit that only touches `plugins/` gets ` (skip-pub)`.
- **Plugin docs.** Claude reads the current Claude Code plugin docs (manifest fields, marketplace file, install commands) at the start of the build and corrects this plan, because the publishing steps above come from memory.
- **Plugin tests.** Whether `claude plugin eval` can run an eval suite for the skills of the plugin, see question 12.

#### Possible skills
Ideas only. None of them is decided. The names are suggestions.

**Start**
- `cat-new-service`: run the service template of `Cat.Templates`, then explain the next steps, such as the AppHost line and the first module to add.
- `cat-add-module`: add a module to a service, with the right packages, the registration call and the project references. It keeps the core on the abstractions.

**Daily work**
- `cat-add-command`: a command, its handler, a validator and a unit test.
- `cat-add-query`: a query, its handler and a unit test.
- `cat-add-service-request`: a service request with its handler, for use cases that call several commands or queries.
- `cat-add-endpoint`: map a service request to a minimal API endpoint, with the response types listed.
- `cat-add-validator`: validation rules for a request, with codes and messages.
- `cat-add-workflow`: a workflow with its state and steps.
- `cat-add-event`: an event and its subscriber with the event aggregator.
- `cat-add-decorator`: an open generic decorator and its registration, with its order number. See [Decorator order](../modules/Cat.Decorators/README.md#decorator-order).

**Data**
- `cat-add-entity`: an entity on the `Cat.EFCore` base classes, with its configuration and migration, for SQL Server or PostgreSQL.
- `cat-error-codes`: define error codes with a prefix and keep them unique. See [the error code convention](../modules/Cat.Responses/README.md#the-error-code-convention).

**Check and migrate**
- `cat-review`: check a service against the conventions: references, registration, response handling.
- `cat-upgrade`: help move to a new version of a module, using the release notes.

**Later, when the modules exist**
- Skills for messaging, sagas, scheduling and authorization.
- Skills for `Cat.Inbox`, `Cat.Outbox`, `Cat.Resilience`, `Cat.Telemetry`, `Cat.Caching` and `Cat.Localizations`.
- These modules all exist now, so the skills can come after the daily work skills.

#### Decided
- **Idea.** Create skills for the developers who use the toolkit. Plan them here and list them in the repo overview of the readme.
- **Skill prefix.** Skills for the owner of the toolkit start with `cat-internal-`. Skills for developers who use the toolkit start with `cat-`. All existing skills for the owner already use `cat-internal-`.
- **The skills use the templates.** Every file that a skill creates comes from a `dotnet new` template of [Cat.Templates.md](Cat.Templates.md#phase-1), a service template or an item template. A skill does what a template cannot: pick the project and the folder, change existing files such as the registration in `Program.cs`, add the test, run the build and explain the next step (owner, 2026-11-21).
- **Who scaffolds a new service.** The service template creates the structure, and `cat-new-service` runs it. Until the template exists, the skill is not built (owner, 2026-11-21).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->

<!-- region start: Question 1-->
#### Question 1
Do we use one plugin for all skills, or one per module? The options:
- **One plugin for all skills.** Simple to publish and to update, and the skills are small. Cost: a developer gets skills for modules they do not use.
- **One plugin per module.** Matches the toolbox idea. Cost: more manifests, more versions, more to maintain.
- **One plugin with the skills grouped, and the module name in each skill name.** Cost: the same as one plugin, but Claude only loads a skill when its words match.

Recommendation: one plugin for all skills. A skill is loaded by its description, so an unused skill costs almost nothing, and one plugin is far simpler to ship. Split later if the plugin grows too big.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Which skills do we build first? The options:
- **The suggestion:** scaffold a service, add a command or query with its handler and test, and add a validator.
- **Only the daily work skills** (`cat-add-command`, `cat-add-query`, `cat-add-validator`). Cost: no start skill, but they need only their item templates, not the service template.
- **The check skill first** (`cat-review`). Cost: it depends on conventions being stable.

Recommendation: the daily work skills first: `cat-add-command`, `cat-add-query` and `cat-add-validator`. All three modules exist and are documented, and each needs only its item template of [Cat.Templates.md](Cat.Templates.md#phase-1). Add `cat-new-service` with the service template. The way a command returns a result is decided now, see [Get a result from a command](../modules/Cat.Commands/README.md#get-a-result-from-a-command). `cat-add-command` teaches caller supplied IDs first, a query after the command second, and the typed command third.
<!-- region end: Question 2-->

<!-- region start: Question 4-->
#### Question 4
What do we call the plugin and the marketplace, and which folder do they use? `plugins/cat/` and the marketplace name are a proposal. The skill prefix is decided. The options:
- **Plugin `cat`, marketplace `cat-toolkit`,** in `plugins/cat/` and `.claude-plugin/marketplace.json`. A developer types `/plugin install cat@cat-toolkit`. Cost: none.
- **Plugin `cleanarchitecturetoolkit`.** Cost: long to type.

Recommendation: plugin `cat`, marketplace `cat-toolkit`. It is short, it matches the skill prefix `cat-`, and it matches the proposed folder.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
How do we keep the skills true when a module changes? The options:
- **Link to the module readmes** and put only the workflow in the skill. Cost: nothing to maintain, but Claude must read the readme.
- **A check** in `cat-internal-verify-docs` that looks for names (types, methods) in the skills and fails when one no longer exists. Cost: a script to build.
- **A review at every release.** Cost: easy to forget.

Recommendation: link to the readmes as the rule, and add the name check later when the first skills exist. It is the cheapest way that does not depend on memory.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Does the plugin have its own version, or does it follow the module versions? The modules are versioned by MinVer from the git tags. The options:
- **Its own version** in `plugin.json`, raised by hand. Cost: a number to remember.
- **Follow the module versions,** the same tag. Cost: the plugin changes with every release, even when no skill changed, and a skill change would need a module release.

Recommendation: its own version, and a note per module release when a skill needs to change. The two change at different speeds, and `plugins/` does not publish a NuGet package (a commit that touches only it gets `skip-pub`).
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
Does `cat-internal-verify-docs` cover `plugins/`, and should the skill files appear on the Pages site? The options:
- **Check the files, and keep them off the Pages site.** The skills are for Claude, not for a reader. Cost: a rule in the Jekyll config to exclude the folder.
- **Check and show them.** Cost: pages that a reader may find confusing, but they also show what the skills do.
- **Neither.** Cost: broken links in skills are not found.

Recommendation: check the files, and exclude them from the site. A short chapter in the readme for developers (question 9) is the place where people read about the skills.
<!-- region end: Question 7-->

<!-- region start: Question 9-->
#### Question 9
Where is it documented? The options:
- **A short chapter in the readme for developers,** once the first skill exists, with the install commands. Cost: one chapter.
- **A readme inside `plugins/cat/`.** Cost: it is not linked from the repo overview, so people miss it.

Recommendation: a chapter in the readme (it also links from the Cat.ClaudeSkills row), and a short readme in `plugins/cat/` that points to it. Do it when the first skill is built, since the repo overview must only describe what exists.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Do we write a plan for each skill, or only one for the whole idea? The options:
- **One plan for the whole idea** (this one), with a phase per group of skills. Cost: the plan grows.
- **A plan per skill.** Cost: a lot of small files, and the repo overview has only one row for them, `Cat.ClaudeSkills`.

Recommendation: one plan with a phase per group (start, daily work, data, check). A skill is small, and the readme row says Cat.ClaudeSkills only once.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
What does a skill do when the templates are not installed? For example, a developer asks for a new command, and `dotnet new list cat-` shows nothing. The options:
- **Stop and show the install command,** `dotnet new install Cat.Templates`, then go on after the developer ran it. Cost: one extra step the first time.
- **Install the templates itself.** Cost: Claude installs a package on the machine of the developer without asking.
- **Write the files without a template.** Cost: the files drift from the templates, which is what the decision wants to avoid.

Recommendation: stop and show the install command. The developer stays in control of what gets installed, and the files always come from the template.
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
How do we test that a skill does what it says? For example, that `cat-add-command` adds the handler, the registration and the test, and that the service still builds. The options:
- **An eval suite of the plugin,** run with `claude plugin eval`, that runs each skill on a service made from the service template and checks the result. Cost: a suite to write and runs that cost tokens. Whether the command fits is still to check.
- **A manual check at release.** Cost: easy to forget.
- **Only the build test of the templates.** Cost: it tests the files, not what the skill does with them.

Recommendation: the eval suite, on a service made from the service template, run before a release of the plugin. The templates are then tested by the build, and the skills by the eval suite.
<!-- region end: Question 12-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->