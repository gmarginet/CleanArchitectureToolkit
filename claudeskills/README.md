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

# Cat.ClaudeSkills <!-- omit in toc -->

Claude Code skills for the developers who use the toolkit. Each skill teaches Claude one task in your own repository, such as adding a command with its handler, validator and test, and follows the conventions of the toolkit. The skills ship as one plugin, `cat`, in the marketplace `cat-toolkit`.

## Table of contents <!-- omit in toc -->
- [Install](#install)
- [How a skill works](#how-a-skill-works)
- [The skills](#the-skills)
- [Test the skills](#test-the-skills)
- [Keep the skills up to date](#keep-the-skills-up-to-date)
- [Without the plugin](#without-the-plugin)
- [Why it is built this way](#why-it-is-built-this-way)

## Install
Add the marketplace once, then install the plugin:

```
/plugin marketplace add gmarginet/CleanArchitectureToolkit
/plugin install cat@cat-toolkit
```

Adding the marketplace clones the whole repository. A sparse clone takes only the plugin:

```
/plugin marketplace add gmarginet/CleanArchitectureToolkit --sparse .claude-plugin claudeskills
```

Most skills create their files with the `dotnet new` templates of the template pack. When the templates are not installed, a skill stops and shows the command. It runs the command only when you say yes:

```
dotnet new install gmarginet.Cat.Templates
```

## How a skill works
- **Templates write the files.** A skill creates its files with a template of the [template pack](../templates/README.md). It does what a template cannot: it picks the project, changes existing files such as a registration, adds a test, runs the build and explains the next step. A skill never writes a file that a template writes. A skill for a module without a template changes the existing files of the service and writes code as the readme of the module shows.
- **The readme of the module is the truth.** Every NuGet package of the toolkit holds the readme of its module. A skill reads the CAT version from the project, `CatVersion` in `Directory.Packages.Cat.props`, and reads the readme of that version from the NuGet cache, in `~/.nuget/packages/gmarginet.<module>/<version>/README.md`. A solution that references a module as a project has the readme in the module folder, `modules/<Module>/README.md`. When a skill and a readme disagree, Claude follows the readme. A developer on an older version gets the usage of that version.
- **Few names.** A skill holds the workflow and as few names of the toolkit as possible, so it does not go stale when a module changes.
- **One skill, one task.** A skill covers one task. It names the next skill to use, such as `cat-add-endpoint` after `cat-add-service-request`.

## The skills

| Skill | What it does | Uses |
|-------|--------------|------|
| `cat-new-system` | Creates a whole system with an AppHost, `ServiceDefaults`, a gateway and a first service. | `cat-system` |
| `cat-new-service` | Creates a service, in a new solution or in an existing one, and explains the next steps. | `cat-service` |
| `cat-add-module` | Adds a module to a service with its packages, references and registration. | |
| `cat-add-command` | Adds a command with its handler, a validator and a test. | `cat-command`, `cat-validator` |
| `cat-add-query` | Adds a query with its handler and a test. | `cat-query` |
| `cat-add-service-request` | Adds a service request with its handler and a test. | `cat-service-request` |
| `cat-add-endpoint` | Maps a service request to a minimal API endpoint. | |
| `cat-add-validator` | Adds the validation rules of a request. | `cat-validator` |
| `cat-add-workflow` | Adds a workflow with its state and steps. | `cat-workflow` |
| `cat-add-event` | Adds an in-process event and its subscriber. | `cat-event` |
| `cat-add-decorator` | Adds an open generic decorator with its registration and order number. | `cat-decorator` |
| `cat-add-entity` | Adds an entity, or a table in a database first service. | `cat-entity`, `cat-table` |
| `cat-error-codes` | Defines error codes with a prefix and keeps them unique. | `cat-error-definitions` |
| `cat-review` | Checks a service against the conventions and reports what is wrong. | |
| `cat-upgrade` | Moves a solution to a new version by comparing the readmes of two versions. | |
| `cat-add-message` | Declares a message and sends it with `Cat.Messaging`. | `cat-message` |
| `cat-add-message-handler` | Adds the handler of a received message with `Cat.EventProcessor`. | `cat-message-handler` |
| `cat-add-saga` | Adds a saga with its messages, workflow and test with `Cat.Sagas`. | `cat-saga` |
| `cat-add-job` | Adds a scheduled job with `Cat.Scheduling`. | |
| `cat-use-user` | Reads the user in a handler and sets it in a worker with `Cat.Users`. | |
| `cat-add-inbox` | Skips a repeated webhook or message with `Cat.Inbox`. | |
| `cat-add-outbox` | Turns the outbox on with `Cat.Outbox`. | |
| `cat-add-resilience` | Puts a profile on an `HttpClient`, or retries a whole command or query, with `Cat.Resilience`. | |
| `cat-add-telemetry` | Adds an own source, meter or exporter with `Cat.Telemetry`. | |
| `cat-cache-query` | Caches a query and clears it with a tag with `Cat.Caching`. | |
| `cat-add-translation` | Adds translated texts to an entity with `Cat.Localizations`. | |
| `cat-add-dapper-handler` | Adds a query or command handler that uses Dapper with `Cat.Dapper`. | `cat-dapper-query`, `cat-dapper-command` |
| `cat-add-api-client` | Creates the client of a service and registers it in the service that calls it with `Cat.Api.Client`. | `cat-api-client` |
| `cat-add-cdc` | Maps a SQL Server table to a message with `Cat.Sql.Cdc`. | |
| `cat-add-gateway` | Sets up a gateway host with `Cat.Api.Gateway`. | `cat-gateway` |

## Test the skills
`claudeskills/evals/` holds one case for each skill, for `claude plugin eval`. A case describes a task on an assumed service, and a judge scores the plan of action that Claude gives. A second grader checks that the skill was loaded. The command runs every case with and without the plugin, so the score shows what the plugin adds. It costs tokens, so run it by hand before a release of the plugin and not on every push:

```
claude plugin eval claudeskills --no-publish --runs 1
```

The cases build nothing. They show that a skill fires and gives the right plan. That the files a skill writes build is checked by `dotnet cake --target=TemplateTest`, because the files come from the templates.

## Keep the skills up to date
The plugin has its own version in `claudeskills/.claude-plugin/plugin.json`. It does not follow the version of the modules. Claude Code updates the plugin when that version changes, so a change to a skill reaches you with the next version of the plugin. Update it with `/plugin marketplace update cat-toolkit` and `/plugin update cat@cat-toolkit`.

## Without the plugin
Copy the folder of a skill from `claudeskills/skills/` into `.claude/skills/` in your project, or into `~/.claude/skills/`. It works the same, but it gets no updates.

## Why it is built this way
The decisions behind the plugin, for the owner and for anyone who changes it.
- **One plugin for all skills.** Claude loads a skill only when its description matches, so an unused skill costs almost nothing. The plugin can be split later if it grows too big.
- **Skills use the templates.** A skill never writes a file by hand when a `dotnet new` template of the [template pack](../templates/README.md) can write it. A developer without Claude can use the templates alone. A skill does what a template cannot: pick the project and the folder, change a line in an existing file, add the test, run the build and explain the next step. When the templates are not installed, the skill stops and shows the install command, and runs it only when the developer says yes.
- **No template for a job or for the tests of a module.** The files of a job are a service request and its handler, which the service request template creates with a test. The tests of caching, the inbox, the outbox, translations and the user come from the "Tests" chapter of each module readme, and those examples run as tests in the module test projects.
- **The module readme is the truth.** A skill holds the workflow and as few API names as possible. It reads the readme of the module version the project uses: `modules/<Module>/README.md` for a project reference, and the readme packed into the NuGet package for a package reference. When a skill and the readme disagree, Claude follows the readme. A check in the docs check fails when a name in a skill is not in the generated `namespaces` pages.
- **The plugin has its own version.** It is raised by hand when a skill changes and does not follow the version of the modules, so a change to a skill needs no module release. It stays `0.1.0` until the first `v` tag exists.
- **Every skill was tried on a throwaway service.** Each skill ran on a service made with the `cat-service` or `cat-system` template, so wrong template names, missing packages and wrong namespaces showed up in a build. Fixes went back into the skills.
- **The evals build nothing.** They show that a skill fires and gives the right plan. A build check inside `claude plugin eval` needs shell tools, which need a sandbox that native Windows does not have. That the files a skill writes build is checked by `dotnet cake --target=TemplateTest`.
- **The whole repository is cloned.** A developer who adds the marketplace clones the repository, which is public and small. One repository keeps a module and its skill in step. The sparse command in "Install" limits the clone.
