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

# Plans for `Skills` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-skills)
<!-- region end: StatusBadge-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
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

A skill for a developer teaches Claude the CAT conventions inside the repository of the developer, for example "add a command with its handler, validator and test". The developer picks the skills they need, as they pick modules.

#### Background
From the repository:
- `.claude/skills/` holds the skills for the owner, such as `cat-internal-create-module`, `cat-internal-create-module-readme`, `cat-internal-verify-docs` and `cat-internal-commit`. They are listed in `.claude/skills/README.md`.
- The readme describes the conventions a skill would teach: the service project structure, the `Abstractions` split, handler registration, `ICatResponse` and error codes.
- [Cat.Templates.md](Cat.Templates.md) plans `dotnet new` templates for the project structure. A scaffold skill overlaps with it.
- `cat-internal-verify-docs` checks all markdown in the repository, and `pages.yml` builds the GitHub Pages site from the markdown.
- `skip-pub` goes at the end of a commit subject when no code in `modules/` changed. Files under `plugins/` would not be published as NuGet packages.

#### What exists today
- No skill for developers exists yet. The folders `plugins/` and `.claude-plugin/` do not exist.
- The readme lists the idea in the repo overview, as `Cat.Skills` with the type Tooling and the status New.
- The skills in `.claude/skills/` are all for the owner, and all 15 of them use the `cat-internal-` prefix now.
- The repository has a `_plugins` folder. It belongs to the Jekyll site and is not related to this plan.

#### Why it fits and what the risks are
This is the opinion Claude gave when the owner asked about the idea. It is not a decision.

Why it fits:
- CAT has strong conventions. A skill that scaffolds a handler, a validator and a test teaches Claude those conventions in the repository of the developer.
- It matches the toolbox idea. Each skill covers one module, and a developer installs only what they use.

Risks:
- **Drift.** A skill that copies API details goes stale when a module changes. Keep the skills about workflow and conventions, and link to the module readmes for the API.
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

#### Possible skills
Ideas only. None of them is decided. The names are suggestions.

**Start**
- `cat-new-service`: scaffold a service with the project structure of the readme. It overlaps with `Cat.Templates`, so decide which one owns it.
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
- `cat-error-codes`: define error codes with a prefix and keep them unique. See [the error code convention](../modules/Cat.Responses/README.md#the-error-code-convention).

**Check and migrate**
- `cat-review`: check a service against the conventions: references, registration, response handling.
- `cat-upgrade`: help move to a new version of a module, using the release notes.

**Later, when the modules exist**
- Skills for the planned modules, such as messaging, sagas, scheduling and authorization. They wait for the modules.

#### Decided
- **Idea.** Create skills for the developers who use the toolkit. Plan them here and list them in the repo overview of the readme.
- **Skill prefix.** Skills for the owner of the toolkit start with `cat-internal-`. Skills for developers who use the toolkit start with `cat-`. All existing skills for the owner already use `cat-internal-`.
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
- **Only the daily work skills** (`cat-add-command`, `cat-add-query`, `cat-add-validator`). Cost: no start skill, but they do not depend on the template (question 3).
- **The check skill first** (`cat-review`). Cost: it depends on conventions being stable.

Recommendation: the daily work skills first: `cat-add-command`, `cat-add-query` and `cat-add-validator`. All three modules exist and are documented, and nothing blocks them. Add `cat-new-service` when question 3 is answered. The way a command returns a result is decided now, see [Get a result from a command](../modules/Cat.Commands/README.md#get-a-result-from-a-command). `cat-add-command` teaches caller supplied IDs first, a query after the command second, and the typed command third.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Who scaffolds a new service, the template or the skill? See [Cat.Templates.md](Cat.Templates.md). This is the blocking question for the first skills, because `cat-new-service` depends on it. The options:
- **The `dotnet new` template creates the structure,** and the skill only teaches Claude to use it (and to add things after). Cost: a developer needs the template installed, and Claude needs the template to exist.
- **The skill creates the structure** from the readme's service project structure. Cost: it drifts from the template, and Claude generates files that a template would give exactly.
- **Both,** with the skill calling the template when it is installed. Cost: two paths to test.

Recommendation: the template creates the structure, and the skill uses it. A template gives the same result every time, and the skill adds the Claude side (what to do next, which module to add). Until the template exists, the skill is not built.
<!-- region end: Question 3-->

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

<!-- region start: Question 8-->
#### Question 8
The publishing steps above come from memory. Do we check them against the current plugin docs before the build? The options:
- **Yes, Claude reads the current Claude Code plugin docs** (manifest fields, marketplace file, install commands) at the start of the build and corrects this plan. Cost: a little time.
- **No, build from memory and fix errors later.** Cost: a plugin that does not install.

Recommendation: yes. It costs little, and a wrong manifest means the first developer to try it fails. This is not an owner decision, so it can be done when the build starts.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Where is it documented? The options:
- **A short chapter in the readme for developers,** once the first skill exists, with the install commands. Cost: one chapter.
- **A readme inside `plugins/cat/`.** Cost: it is not linked from the repo overview, so people miss it.

Recommendation: a chapter in the readme (it also links from the Cat.Skills row), and a short readme in `plugins/cat/` that points to it. Do it when the first skill is built, since the repo overview must only describe what exists.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Do we write a plan for each skill, or only one for the whole idea? The options:
- **One plan for the whole idea** (this one), with a phase per group of skills. Cost: the plan grows.
- **A plan per skill.** Cost: a lot of small files, and `Skills.md` is the only plan linked from a repo overview row.

Recommendation: one plan with a phase per group (start, daily work, data, check). A skill is small, and the readme row says Cat.Skills only once.
<!-- region end: Question 10-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->