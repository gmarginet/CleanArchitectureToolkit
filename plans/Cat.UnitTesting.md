# Plans for Cat.UnitTesting

Helpers for unit tests, like test doubles for processors and responses, in small projects the developer picks from.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

The core service is free of technology, so its unit tests need no database. They replace the query and command processors with test doubles. Every service writes the same doubles again. A shared module saves that work and makes the tests look the same everywhere.

The module is a toolbox of small projects. A fake command processor lives in its own project, a fake query processor in another, and so on. A developer references only the ones they need, so a test project does not pull in fakes for modules it does not use.

## What we already know

From the root readme:

- `ServiceName.CoreService.Tests` holds the unit tests of the business logic. It replaces the queries and commands with test doubles, so no database is needed. It references the `CoreService` project only.

From the demo:

- Both demo services wrote their own `FakeCommandProcessor` and `FakeQueryProcessor`. They are close to each other and not the same:
  - Catalog: one response for every command, and a list of the commands that were processed.
  - Orders: a response per command type, a list of the commands, defaults that fill result properties like the new order id and number, and an `Of<T>()` helper.
- Orders also has `TestDoubles.cs` with fakes for the event aggregator and the other interfaces.
- The tests check workflows, validators, event subscribers, order statuses and the service request handlers.

From the repository:

- Unit tests of the repository use NUnit. `tests/Cat.NUnit` holds a `UnitTestBase` that the module tests share. Today it is a repository test helper and not a package.

From the existing modules:

- `Cat.Responses` has `ICatResponse` and `CatResponse` with succeeded and failed outcomes and errors.
- `Cat.Commands`, `Cat.Queries`, `Cat.ServiceRequests` and `Cat.EventAggregators` each have abstractions with a processor or aggregator interface.
- Tests of the future modules will need fakes for their parts too: messages, the clock and the user (`ICatUser` from `Cat.Authorization.Abstractions`).

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Name | `Cat.UnitTesting`, renamed from `Cat.Testing`. |
| Purpose | Test doubles and helpers for unit tests, such as the core service tests. |
| Structure | Many small projects, each with one fake or helper, such as the fake command processor and the fake query processor. The developer picks what they need. |
| Cat.NUnit | `tests/Cat.NUnit` becomes part of this module in the end. |
| No database | The unit tests never need a database. |

### Open

- **Project names.** One project per fake with its own name, or one project per CAT module that holds the fakes of that module, for example `Cat.UnitTesting.Commands`? The first is the most pick and choose. The second means fewer packages.
- **Dependencies.** A project references only the abstractions of the module it fakes. A fake command processor should not need `Cat.Queries`.
- **Test framework.** `Cat.NUnit` is NUnit specific. The fakes themselves need no framework. Do we keep the framework neutral parts apart from the NUnit parts, for example `Cat.UnitTesting.NUnit`, so other frameworks can follow?
- **Fake processors.** One generic fake that records what it received and returns canned responses per type, with a fallback. That would merge the two demo versions.
- **Defaults.** Orders fills result properties on commands, as a real handler would. Does the module support a hook per type for that?
- **Response asserts.** Helpers to check that a response succeeded, or failed with a certain error code. Do they plug into NUnit constraints, or stand alone?
- **Other doubles.** A fake `ICatUser`, a fake event aggregator, a fake service request processor, and a fake clock with `TimeProvider`.
- **Which first.** Everything with abstractions, or only the main ones first?
- **Moving `Cat.NUnit`.** When does it move, and what happens to the existing module test projects that use it? It is a rename of a project reference, but it touches every test project.
- **Integration tests.** The name says unit tests. Helpers for integration tests, such as a test host with a database, are probably out of scope or a sibling module. The demo plan says some behavior has no automated test because the unit tests do not use a database.
- **Own tests.** Do the fakes need tests of their own?

## Questions before building

1. Do you want one project per fake, or one project per CAT module?
2. Should the framework neutral fakes live apart from the NUnit parts?
3. Do you want one generic fake processor to replace the demo versions?
4. Which doubles do you need first: processors, responses, user, event aggregator or time?
5. Do we add assertion helpers for `ICatResponse`?
6. When does `tests/Cat.NUnit` move into the module, and under which project name?
7. Are integration test helpers out of scope for this module?
8. Do we build this first from the demo test code, as the Aspire plan did for the API client?
9. Do the fakes need to match the real behavior, such as filling ids, or stay dumb on purpose?
10. Who is the audience: users of the toolkit, the repository tests, or both?
