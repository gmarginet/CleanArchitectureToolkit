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

# Plans for `Cat.UnitTesting` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![READY TO START BUILDING](https://img.shields.io/badge/Status-READY%20TO%20START%20BUILDING-green)](#plans-for-catunittesting)
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
A new module, `Cat.UnitTesting`, with helpers for unit tests, like test doubles for processors and responses, in small projects the developer picks from.

#### The idea
The core service is free of technology, so its unit tests need no database. They replace the query and command processors with test doubles. Every service writes the same doubles again. A shared module saves that work and makes the tests look the same everywhere.

The module is a toolbox of small projects. A fake command processor lives in its own project, a fake query processor in another, and so on. A developer references only the ones they need, so a test project does not pull in fakes for modules it does not use.

#### Background
From the readme:
- `ServiceName.CoreService.Tests` holds the unit tests of the business logic. It replaces the queries and commands with test doubles, so no database is needed. It references the `CoreService` project only.

From the demo:
- The demo services wrote their own `FakeCommandProcessor` (Catalog, Inventory and Orders) and `FakeQueryProcessor` (Catalog and Orders). They are close to each other and not the same:
  - Catalog: one response for every command, and a list of the commands that were processed.
  - Orders: a response per command type, a list of the commands, a default answer for the typed create order command that returns the order id and number, and an `Of<T>()` helper.
- Orders also has `TestDoubles.cs` with fakes for the event aggregator and the other interfaces.
- The tests check workflows, validators, event subscribers, order statuses and the service request handlers.

From the repository:
- Unit tests of the repository use NUnit. `tests/Cat.NUnit` holds a `UnitTestBase` that the module tests share. Today it is a repository test helper and not a package.

From the existing modules:
- `Cat.Responses` has `ICatResponse` and `CatResponse` with succeeded and failed outcomes and errors.
- `Cat.Commands`, `Cat.Queries`, `Cat.ServiceRequests` and `Cat.EventAggregators` each have abstractions with a processor or aggregator interface.
- Tests of the future modules will need fakes for their parts too: messages, the clock and the user (`ICatUser` from `Cat.Users.Abstractions`).

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- `tests/Cat.NUnit` targets `net10.0` and references NUnit. It is not packable. 14 repository test projects and the 3 demo `CoreService.Tests` projects (Catalog, Inventory and Orders) reference it.
- The copies of the fakes in the demo test projects exist as the plan says:
  - `FakeCommandProcessor` in Catalog, Inventory and Orders.
  - `FakeQueryProcessor` in Catalog and Orders.
  - `RecordingSubscriber` and `FakeUser` in the Orders `TestDoubles.cs`. `FakeUser` is an `ICatUser` and the demo interface `IUserEmail` in one, with settable properties.
- `FakePriceProvider`, `FakeStockReservation` and `FakePaymentProvider` exist in the Orders test doubles, and also in the Orders `Infrastructure/Fakes` folder. They are demo doubles, not doubles of a CAT interface.
- Two test projects have their own `FakeTime : TimeProvider`: `Cat.Api.Gateway.Tests` and the Payment `CoreService.Tests`. Nothing uses `FakeTimeProvider` of Microsoft yet.

#### Decided
- **Name.** `Cat.UnitTesting`, renamed from `Cat.Testing`.
- **Purpose.** Test doubles and helpers for unit tests, such as the core service tests.
- **Structure.** One project per CAT module. A developer only references the test project of a module they use.
- **Dependencies.** A test project references only the abstractions of the module it fakes. A fake command processor does not need `Cat.Queries`.
- **Test framework.** The framework neutral parts live apart from the NUnit parts, such as `Cat.UnitTesting.NUnit`, so other frameworks can follow.
- **Fake processors.** One generic fake processor per kind. The developer controls and defines the output.
- **Response asserts.** Stand alone if possible, and easy to use from NUnit. If that is not possible, they go in a separate project such as `Cat.UnitTesting.Responses.NUnit`.
- **Which doubles.** At least the ones our own test projects need, and more if possible. The list is in the next chapter.
- **Cat.NUnit.** `tests/Cat.NUnit` becomes part of this module, as soon as possible. The solution is still in alpha, so it moves before the first stable version.
- **No database.** The unit tests never need a database.
- **Integration tests.** Out of scope for now. If integration testing comes, it is a separate module.
- **Own tests.** The fakes have tests of their own.
- **Order of the doubles.** Only what a test needs now, as the list shows. The order is the move of `Cat.NUnit`, then the command and query fakes, then the event ones, then the response asserts. The other doubles follow when the module that owns the interface gets built or a test needs them.
- **Project names.** `Cat.UnitTesting.<Module>` for a fake, such as `Cat.UnitTesting.Commands`, and `Cat.UnitTesting.NUnit` for the base class.
- **Typed commands.** The generic fake has a function overload, `Respond<TCommand>(command => response)`, next to a fixed response. It covers both command shapes.
- **Fakes stay dumb.** A fake returns what the test says. It fills no ids and sets no timestamps.
- **Audience.** Developers who use the toolkit, and the repository tests. The repository tests are the first consumers, as the demo is for the other modules.
- **Cat.UnitTesting.NUnit.** A package that targets the latest stable .NET and holds `UnitTestBase`. The neutral fakes stay on `netstandard2.0`.
- **Clock.** No clock of our own. Tests use `FakeTimeProvider` of Microsoft, and the readme points to it. The two `FakeTime` copies in the test projects are replaced.

#### The list of doubles
Checked in the test projects of the demo and the repository. "Needed now" means one of our test projects has its own copy today.

| Double | Fakes | Project | Needed now | Notes |
|---|---|---|---|---|
| Fake command processor | `ICatCommandProcessor` | `Cat.UnitTesting.Commands` | Yes: Catalog, Inventory and Orders each have one | Records the commands. The response per command type is set by the test. |
| Fake query processor | `ICatQueryProcessor` | `Cat.UnitTesting.Queries` | Yes: Catalog and Orders | Records the queries. The response per query type is set by the test. |
| Fake service request processor | `ICatServiceRequestProcessor` | `Cat.UnitTesting.ServiceRequests` | No, the tests use the real one | Foreseen. For a test of code that sends service requests. |
| Recording event subscriber, fake event aggregator | `ICatHandleEvent<T>`, the aggregator | `Cat.UnitTesting.EventAggregators` | Yes: Orders has `RecordingSubscriber` | Records the events it got. A fake aggregator is foreseen, for a test of code that publishes events. |
| Response asserts | `ICatResponse` | `Cat.UnitTesting.Responses` | Partly: the tests check responses by hand | Succeeded, failed, the type and an error code. Stand alone, with an NUnit part only if needed. |
| Fake workflow and validator processors | `ICatWorkflowProcessor`, `ICatStepProcessor`, `ICatValidatorProcessor` | `Cat.UnitTesting.FluentWorkflows` | Not clear | Foreseen. Check how the workflow tests of Orders set up their steps before deciding. |
| Fake user | `ICatUser` of `Cat.Users.Abstractions` | `Cat.UnitTesting.Authorization` | Yes, as `FakeUser` in Orders, which is an `ICatUser` with the demo interface `IUserEmail` | `Cat.Users` is built. `CatUser` of `Cat.Users.Abstractions` already builds any user by hand, so check whether a fake adds anything before deciding. |
| Fake clock | `TimeProvider` | None | No | .NET has `FakeTimeProvider` in the `Microsoft.Extensions.TimeProvider.Testing` package. Recommendation: do not write our own. Point to it in the readme. |
| Fake message publisher | `Cat.Messaging` | `Cat.UnitTesting.Messaging` | No | Foreseen, waits for the module. |
| Base class with a service provider | `UnitTestBase` | `Cat.UnitTesting.NUnit` | Yes: 14 test projects of the repository and the 3 demo test projects use `Cat.NUnit` | Moves from `tests/Cat.NUnit`. |

The demo has fakes that are not doubles of a CAT interface: `FakePriceProvider`, `FakeStockReservation` and `FakePaymentProvider`. They belong to the demo and stay there.

#### Can the module be built?
Yes, in steps, with no open question blocking the first ones.

1. **Create the module** with the `cat-internal-create-module` skill: the projects `Cat.UnitTesting.Commands` and `Cat.UnitTesting.Queries`, the test project of the module, the solution entries, the readme and the readme row. The module is in the repo overview with the status New now. The row changes to Building and links to the module readme, and the plan stays until the readme says everything.
2. **Move `Cat.NUnit`.** `git mv tests/Cat.NUnit` to the new project `Cat.UnitTesting.NUnit`, and fix the project reference in 14 repository test projects and 3 demo test projects, and in `CleanArchitectureToolkit.slnx`. Search the old name with `git grep`. It touches every test project, so it is a commit of its own.
3. **The command and query fakes**, from the demo versions. Replace the three copies in the demo test projects with the package projects.
4. **The event fakes and the response asserts.**
5. **Own tests** for every fake.
6. **The readme** of the module with a table of the projects, as the other modules have.

The fake user waits for `Cat.Users`, and the messaging fake for `Cat.Messaging`.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->