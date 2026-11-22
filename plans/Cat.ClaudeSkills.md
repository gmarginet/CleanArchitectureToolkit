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
- [Phase 2](#phase-2)
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
- `skip-pub` goes at the end of a commit subject when no code in `modules/` changed. Files under `claudeskills/` would not be published as NuGet packages.

#### What exists today
- No skill for developers exists yet. The folders `claudeskills/` and `.claude-plugin/` do not exist.
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
- **Versions.** Skills and NuGet packages are versioned separately. See the decisions on the plugin version and the packed readme.
- **Names.** The skills for the owner in `.claude/skills/` could clash with skills for developers of similar names. The prefixes keep them apart.

#### How to publish them
From the Claude Code plugin docs (checked 2026-11-22):
- **Marketplace.** A `.claude-plugin/marketplace.json` in a GitHub repository. A developer runs `/plugin marketplace add <owner>/<repo>`, then `/plugin install <plugin>@<marketplace>`. Updates come through the same commands.
- **No upload step.** The repository is the marketplace. A push to `master` publishes the change, and developers get it when the `version` in `plugin.json` changes. `build.yml` has nothing to upload, and `skip-pub` does not hold the skills back, because it only stops the NuGet packages.
- **What a developer downloads.** `/plugin marketplace add` clones the whole repository, under `marketplaces/<name>/` on the machine of the developer. Installing the plugin copies only the plugin folder, here `claudeskills/`, into `cache/<marketplace>/<plugin>/<version>/`. The developer can limit the clone with `--sparse`, such as `--sparse .claude-plugin claudeskills`. The git history of the repository is about 11 MB today.
- **Validation.** `claude plugin validate <path>` checks the JSON, the required fields, the names and the `plugin.json` of each plugin with a relative source. `--strict` turns warnings into failures, for CI. Exit code 0 means passed, 1 failed. It does not check that a relative source folder exists.
- **Plugin.** A folder with `.claude-plugin/plugin.json` and a `skills/<name>/SKILL.md` per skill. It can also hold commands, hooks and an MCP config later.
- **Fallback.** The developer copies a skill folder into `.claude/skills/` in their project or into `~/.claude/skills/`. It is simple, but has no updates.

The skills ship as one plugin, see Decided.

#### Where they live in the repository
Keep them out of `.claude/skills/`, which is for the owner. The folders, see Decided:

```
.claude-plugin/marketplace.json        (points to ./claudeskills)
claudeskills/README.md
claudeskills/.claude-plugin/plugin.json
claudeskills/skills/cat-add-command/SKILL.md
claudeskills/skills/...
```

Things to check when we build it:
- **Commit messages.** A commit that only touches `claudeskills/` gets ` (skip-pub)`.
- **Plugin docs.** Claude reads the current Claude Code plugin docs (manifest fields, marketplace file, install commands) at the start of the build and corrects this plan, because the publishing steps above come from memory.

#### Skills
Phase 1 builds every skill on this list, with these names (owner, 2026-11-22).

**Start**
- `cat-new-service`: run the service template of `Cat.Templates`, then explain the next steps, such as the AppHost line and the first module to add.
- `cat-add-module`: add a module to a service, with the right packages, the registration call and the project references. It keeps the core on the abstractions.

**Daily work**
- `cat-add-command`: a command, its handler, a validator and a unit test. It follows the order in [Get a result from a command](../modules/Cat.Commands/README.md#get-a-result-from-a-command): IDs the caller supplies first, a query after the command second, the typed command third.
- `cat-add-query`: a query, its handler and a unit test.
- `cat-add-service-request`: a service request with its handler, for use cases that call several commands or queries.
- `cat-add-endpoint`: map a service request to a minimal API endpoint, with the response types listed.
- `cat-add-validator`: validation rules for a request, with codes and messages.
- `cat-add-workflow`: a workflow with its state and steps.
- `cat-add-event`: an event and its subscriber with the event aggregator.
- `cat-add-decorator`: an open generic decorator and its registration, with its order number. See [Decorator order](../modules/Cat.Decorators/README.md#decorator-order).

**Data**
- `cat-add-entity`: an entity on the `Cat.EFCore` base classes, with its configuration and migration, for SQL Server or PostgreSQL.
- **Tables in a database first service.** There are no migrations. `cat-add-entity` adds a table file with the `cat-table` template to the SQL project, or to the scripts folder on PostgreSQL. After the developer deploys, it runs the scaffold for the entity, as Inventory does in the demo. The tables of the inbox, the outbox and the scheduler come the same way (owner, 2026-11-22).
- `cat-error-codes`: define error codes with a prefix and keep them unique. See [the error code convention](../modules/Cat.Responses/README.md#the-error-code-convention).

**Check and migrate**
- `cat-review`: check a service against the conventions: references, registration, response handling.
- `cat-upgrade`: help move to a new version of a module. The repository has no release notes, so the skill compares the packed module readme of the old and the new version in the NuGet cache and updates the code to the new usage. A change that the readme does not show is missed, and that is accepted (owner, 2026-11-22).

**More modules**
- `cat-add-message`: declare a message and send it with `Cat.Messaging`, through the outbox when the service has one.
- `cat-add-message-handler`: a message type, its handler, the registration and the subscription with `Cat.EventProcessor`.
- `cat-add-saga`: the messages, the workflow, the instance store and the test of a saga with `Cat.Sagas`.
- `cat-add-job`: a scheduled job, its configuration and its test with `Cat.Scheduling`.
- `cat-use-user`: read the user in a handler, and set it in a worker, with `Cat.Users`.
- `cat-add-inbox`: skip a repeated webhook or bus message with `Cat.Inbox`, with the store and the cleanup.
- `cat-add-outbox`: turn the outbox on with `Cat.Outbox`, with the cleanup.
- `cat-add-resilience`: put a profile on an `HttpClient`, or retry a whole command or query, with `Cat.Resilience`.
- `cat-add-telemetry`: add an own source, meter or exporter with `Cat.Telemetry`.
- `cat-cache-query`: cache a query and clear it with a tag with `Cat.Caching`.
- `cat-add-translation`: mark an entity, map its table and read a text with `Cat.Localizations`.
- `cat-add-dapper-handler`: a query or command handler with `Cat.Dapper`, with the SQL in a `.sql` file.
- `cat-add-api-client`: generate and register the client of another service with `Cat.Api.Client`.
- `cat-add-cdc`: map a table to a message with `Cat.Sql.Cdc`. SQL Server only, as the module is.
- `cat-add-gateway`: set up a gateway host and describe the services with `Cat.Api.Gateway`, for a developer who does not use the solution template.

#### Decided
- **Idea.** Create skills for the developers who use the toolkit. Plan them here and list them in the repo overview of the readme.
- **Skill prefix.** Skills for the owner of the toolkit start with `cat-internal-`. Skills for developers who use the toolkit start with `cat-`. All existing skills for the owner already use `cat-internal-`.
- **The skills use the templates.** Every file that a skill creates comes from a `dotnet new` template of [Cat.Templates.md](Cat.Templates.md#phase-1), a service template or an item template. A skill does what a template cannot: pick the project and the folder, change existing files such as the registration in `Program.cs`, add the test, run the build and explain the next step (owner, 2026-11-21).
- **Who scaffolds a new service.** The service template creates the structure, and `cat-new-service` runs it. Until the template exists, the skill is not built (owner, 2026-11-21).
- **One plugin for all skills.** Every skill for developers goes in one plugin, not one per module. Claude loads a skill only when its description matches, so an unused skill costs almost nothing. The plugin can be split later if it grows too big (owner, 2026-11-22).
- **No build order by template.** [Cat.Templates.md](Cat.Templates.md#phase-1) is built first and holds every template the skills need. This plan builds every skill it plans, not a first group (owner, 2026-11-22).
- **Scope of phase 1.** Phase 1 builds every skill in the list of skills, the group "More modules" too (owner, 2026-11-22).
- **Skills of the group "More modules".** One skill per module for the main task its module readme describes, as listed. `Cat.Dapper`, `Cat.Api.Client`, `Cat.Sql.Cdc` and `Cat.Api.Gateway` get one too, so every module has a skill (owner, 2026-11-22).
- **A skill for the solution template.** The skill that runs the solution template of [Cat.Templates.md](Cat.Templates.md#phase-2) belongs to [phase 2](#phase-2) (owner, 2026-11-22).
- **One plan.** This plan covers every skill for developers, with no plan per skill. Its phases follow the phases of [Cat.Templates.md](Cat.Templates.md#phase-1): phase 1 holds the skills for the service template and the item templates, phase 2 the skill for the solution template (owner, 2026-11-22).
- **Names and folders.** The plugin is `cat` in `claudeskills/`, with its `plugin.json` in `claudeskills/.claude-plugin/` and the skills in `claudeskills/skills/`. The marketplace is `cat-toolkit` in `.claude-plugin/marketplace.json` in the root of the repository, and points to `./claudeskills`. A developer installs it with `/plugin install cat@cat-toolkit` (owner, 2026-11-22). The plugin docs allow a relative source that starts with `./`, resolved from the folder that holds `.claude-plugin/`, so `"source": "./claudeskills"` works. The `name` of the entry in `marketplace.json` must match the `name` in `plugin.json` (checked 2026-11-22).
- **Keep the skills true.** A skill holds the workflow and as few API names as possible (owner, 2026-11-22):
  - **The readme of the package.** Phase 1 packs the module readme into each NuGet package, next to `README_NUGET.md`, with one change in `Directory.Build.props`. A skill reads the CAT version from the project of the developer and reads the module readme of that version from the NuGet cache. So the API always matches the package, and a skill needs no version of its own.
  - **A module referenced as a project.** For a `ProjectReference`, such as the demo has to `modules/Cat.Commands/`, there is no package in the NuGet cache. The skill follows the reference and reads the `README.md` of the module folder, such as `modules/Cat.Commands/README.md`. For a `PackageReference` it reads the packed readme. So the readme always matches the code that is built (owner, 2026-11-22).
  - **Links in the packed readme.** The relative links, such as those to the `namespaces` pages, do not work in the packed copy. That is accepted, because the usage chapters show the code a skill needs, and Claude can read the public API from the DLL. The `namespaces` pages can be packed later if the eval suite shows that Claude misses API details.
  - **The readme wins.** Every skill says that when the skill and the packed module readme disagree, Claude follows the readme. A developer on an older CAT version then gets the API of that version.
  - **A name check.** Phase 1 adds a check to `cat-internal-verify-docs` that fails when a backticked name in a skill, such as `AddCatCommands`, is not in the generated `namespaces` pages. It has a list of names to skip, such as `Program.cs`.
- **Plugin version.** The plugin has its own version in `plugin.json`, raised by hand when a skill changes. It does not follow the CAT version, so a change to the skills needs no module release (owner, 2026-11-22). From the plugin docs: a set `version` pins every developer to the cached copy until the string changes, so a skill change without a new version reaches nobody (checked 2026-11-22).
- **A warning for the version.** Phase 1 adds a rule to `cat-internal-commit`. When `claudeskills/skills/` differs from `origin/master` and the `version` in `plugin.json` does not, the end report of the commit says so and asks whether to raise it before the push. Several skill commits can share one raise (owner, 2026-11-22).
- **Validation before the commit.** Phase 1 adds a second rule to `cat-internal-commit`. When a commit touches `.claude-plugin/` or `claudeskills/`, the skill runs `claude plugin validate . --strict` and does not commit that block when it fails. So a broken manifest never reaches `master`, also when only the version changed. `build.yml` gets no step for it, because a failure there comes after the push is live (owner, 2026-11-22).
- **Docs check and Pages site.** `cat-internal-verify-docs` checks the markdown in `claudeskills/`. The Pages site leaves the skill files out, with `claudeskills/skills` in the `exclude` list of `_config.yml`, and shows `claudeskills/README.md`. Jekyll already skips folders that start with a dot, such as `.claude-plugin/`. People read about the skills in that readme, not in the skill files (owner, 2026-11-22).
- **Documentation.** `claudeskills/README.md` holds everything about the skills: the install commands, a table of the skills and how each one works. The `Cat.ClaudeSkills` row in the repo overview of the readme links to it with a Read more link, as a module row links to its module readme. It is written when phase 1 is built, because the readme describes only what exists (owner, 2026-11-22).
- **The skills table rule.** `CLAUDE.md` gets its own rule: a change to a skill in `claudeskills/skills/` updates its row in `claudeskills/README.md` in the same change. The skills for developers stay out of `.claude/skills/README.md` and the skills table of `CLAUDE.md`, which are for the owner. `cat-internal-verify-docs` checks the rows (owner, 2026-11-22).
- **The clone of the marketplace.** A developer who adds the marketplace clones the whole repository, and that is accepted: the repository is public and small, and one repository keeps a module and its skill in step. `claudeskills/README.md` shows the sparse command next to the normal one, `/plugin marketplace add gmarginet/CleanArchitectureToolkit --sparse .claude-plugin claudeskills` (owner, 2026-11-22).
- **Templates not installed.** When `dotnet new list cat-` shows nothing, the skill stops and shows the install command of the template pack. Claude runs it only when the developer says yes, then goes on. A skill never writes a file without its template (owner, 2026-11-22).
- **The plugin in this repository.** `.claude/settings.json` declares the marketplace with `extraKnownMarketplaces`, with a `directory` source, and enables the plugin with `"cat@cat-toolkit": true` in `enabledPlugins`. Every session in the repository, such as work on the demo, then has the skills. The plugin loads in place, so an edit to a skill works after `/reload-plugins` (owner, 2026-11-22). From the plugin docs: it applies after the folder is trusted, and it may need `claude plugin install cat@cat-toolkit --scope project` once per machine. To check before the build: whether a relative `path` resolves from the repository.
- **Skill tests.** An eval suite of the plugin, run with `claude plugin eval`. Each skill runs on a service made with `cat-service`, and the suite checks the files and that `dotnet build` and `dotnet test` pass. The owner runs it by hand before a release of the plugin, not on every push, to keep the token cost down (owner, 2026-11-22). To check before the build: the format of the eval suite.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
A skill that creates a whole system with the solution template of [Cat.Templates.md](Cat.Templates.md#phase-2), as the demo is.

#### Needs
- The solution template, see [Cat.Templates.md](Cat.Templates.md#phase-2).
- The plugin and the skills of [phase 1](#phase-1).

#### Background
- The solution template creates an AppHost, `ServiceDefaults`, a YARP gateway and a first service made with `cat-service`, see [Cat.Templates.md](Cat.Templates.md#phase-2).

#### Decided
- **A skill for the solution template.** It runs the solution template and goes in the plugin of [phase 1](#phase-1) (owner, 2026-11-22).
- **Name.** The skill is `cat-new-system`. It pairs with `cat-new-service`: one creates a whole system, the other adds a service to it (owner, 2026-11-22).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->