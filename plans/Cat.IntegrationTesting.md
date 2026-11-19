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

# Plans for `Cat.IntegrationTesting` <!-- omit in toc -->  

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
Integration tests that run on a real SQL Server in a container, for the modules and for the demo, and that stay apart from the unit tests. The demo shows how a developer writes them.

#### What exists today
- `dotnet cake --target=Test` runs every `*.Tests.csproj` under `tests/` and `demo/`, see `build.cake`.
- `.github/workflows/build.yml` runs on `ubuntu-latest` and calls Cake. To check: that Docker is available on that runner, so a container can start in the workflow.
- `tests/Cat.Messaging.Tests/EmulatorTests.cs` is the only test that needs the AppHost. It uses a test category and runs on demand, see the `cat-internal-run-apphost` skill.
- `Cat.UnitTesting` holds the helpers for unit tests, in small projects a developer picks from.
- `tests/Cat.Sagas.Tests` runs the saga, the outbox and the inbox on SQLite in memory. The test `DeleteOlderThan_DeletesOnlyTheRowsHandledBeforeTheLimit` in `OutboxAndInboxTests.cs` is one of them. SQLite cannot compare a `DateTimeOffset` in SQL, so the test context in `EfCoreSagaStoreTests.cs` maps `HandledAt` to a number. The SQL that runs there is not the SQL that SQL Server runs.

#### Decided
- Integration tests run on a real SQL Server in a container.
- They cover the modules and the demo, and they are a showcase in the demo.
- They do not run with the unit tests.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
How do the integration tests stay apart from the unit tests? The options:
- **A different project name,** such as `*.IntegrationTests.csproj`, in the same `tests/` and `demo/` folders. The `Test` target only picks `*.Tests.csproj`, so these projects never run with it. A new Cake target, such as `IntegrationTest`, runs them. Cost: one more target and one more workflow step.
- **A category in the same project,** such as `[Category("Integration")]` with a filter, like the emulator tests. Cost: the project still starts with the unit tests unless every call has a filter, and a forgotten filter makes every local run need Docker.
- **A separate solution folder or repository.** Cost: more to maintain, and a weaker showcase.

Recommendation: the different project name with its own Cake target. It cannot run by accident, and the workflow decides when it runs. The workflow can run it as a separate step or job, and publishing can depend only on the unit tests.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Does this need a module, like `Cat.UnitTesting`? The options:
- **No module, a test project per place.** Each project references a container package such as Testcontainers and starts its own SQL Server. Cost: every project repeats the start code, and a container per project is slow.
- **A module, such as `Cat.IntegrationTesting.SqlServer`.** It holds a shared container fixture and a database per test run. Cost: a new module to build and document. A developer gets it for their own services too.
- **The demo first, a module later.** Build the first integration tests in the demo and extract the module when two places need the same fixture. Cost: some moving of code later.

Recommendation: the demo first, a module later. It forces nothing on other modules, and it avoids designing a module before we know what it needs.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
What happens to the SQLite test `DeleteOlderThan_DeletesOnlyTheRowsHandledBeforeTheLimit` in `Cat.Sagas.Tests`? The options:
- **Keep it.** It passes today and proves the filter logic and the `ExecuteDelete` call. Cost: the test-only conversion, and it does not prove the SQL Server translation.
- **Move it to the integration tests when they exist.** Remove the test-only conversion with it. Cost: until then nothing tests the cleanup in the test run, and only the live test of the demo covers it.
- **Remove it now and add the test to this plan.** Cost: the same gap as the second option, starting today.

Recommendation: keep it until the integration tests exist, then move it and remove the conversion. The test passes and covers the filter logic, and there is no gain in an empty gap in between.
<!-- region end: Question 3-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->
