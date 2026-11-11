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

# Plans for `Cat.Dapper` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catdapper)
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
A new module, `Cat.Dapper`, with base query and command handlers for Dapper, including bulk operations.

#### The idea
Entity Framework Core is a good fit for writes and for entity graphs. For a fast read-only overview, for stored procedures and views, and for bulk loads, plain SQL with Dapper is simpler and quicker.

`Cat.Dapper` gives the same handler style as the other modules, with Dapper underneath. A query handler runs a SQL statement and returns a result. A command handler runs a statement or a bulk operation.

#### Background
From the readme:
- The infrastructure project holds the query and command handlers and the data access code. The core only knows the handler abstractions.
- A service that uses a database first approach has an optional `DataAccessTooling` project that scaffolds the entities and the context.
- `DataModels` also holds query result classes, for results that do not match an entity, such as an overview over several entities. These fit Dapper well.

From the demo plan:
- Dapper is in the demo for fast read-only order overview queries, next to EF Core for writes.
- Inventory is database first. The database often exists already, with its own tables, views and stored procedures. The plan says that suits Dapper, so Inventory can read through Dapper next to the scaffolded EF Core model.
- The AppHost runs SQL scripts to create the inventory database.

From the existing modules:
- `Cat.Queries` and `Cat.Commands` define the handler interfaces, the processors and the decorators.
- `Cat.EFCore` is about entity configuration, and it has no part in Dapper work.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- Nothing in the modules or the demo uses Dapper. The demo plan says Inventory uses the EF Core scaffold only for now, and Dapper waits for this module.

#### Decided
- **Scope.** Query and command handlers with Dapper, and bulk operations.
- **Place in the demo.** Read-only order overviews, and the Inventory service.
- **Dependencies.** The core never references this module.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 5-->
#### Question 5
Do we build this before or after the `Cat.EFCore` handler projects, so the two share a design? This is the blocking question. Several others (2, 7, 13) are about the same design points as in [Cat.EFCore.md](Cat.EFCore.md). The options:
- **After `Cat.EFCore.Queries` and `Cat.EFCore.Commands`.** Dapper copies the proven base class shape, the error mapping and the paging helper. Cost: this module waits.
- **At the same time.** One design for both. Cost: two moving targets, and the EF Core questions are still open.
- **Before.** Cost: it sets the shape that EF Core must follow, which is the wrong way round since EF Core is the main path.

Recommendation: after. The query side of `Cat.EFCore` can be built now (see its plan), so the wait is short, and Dapper then follows a shape that is already tested.
<!-- region end: Question 5-->

<!-- region start: Question 1-->
#### Question 1
Is SQL Server the only database for now? Bulk operations differ per database. The options:
- **SQL Server only,** one project `Cat.Dapper`, and say so in the readme. Cost: a developer on another database has no bulk path.
- **A split, `Cat.Dapper` plus `Cat.Dapper.SqlServer`.** The neutral project holds the handlers, and the SQL Server project holds the bulk code. Cost: one more project now, but it leaves room for another database.

Recommendation: the split. It follows the rule that a provider gets its own project, as in `Cat.Messaging.AzureServiceBus`, and the neutral part costs almost nothing. The bulk code goes in the SQL Server project.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Should Dapper and EF Core be able to share one connection and one transaction? In Orders, a command through EF Core and a query through Dapper may need the same transaction. This is the same point as question 10 in [Cat.EFCore.md](Cat.EFCore.md). Answer it once, there. The options:
- **Left to the handler.** The handler takes the connection and the transaction from the EF Core `DbContext` and passes them to Dapper. Cost: every developer writes the same lines.
- **A helper in `Cat.EFCore.Commands`** that exposes the current connection and transaction. Cost: a small member on the base class.
- **A connection factory in this module** that both can use. Cost: a new abstraction, and a dependency between the two modules.

Recommendation: the helper on the EF Core base class. It keeps the modules apart. Dapper handlers then accept an optional connection and transaction.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Where does the SQL text live? The options:
- **Strings in the handler.** Cost: long queries are hard to read in C#, but there is no extra file.
- **Embedded `.sql` files** next to the handler. Cost: a file per query and a loader, but a developer gets syntax help in the editor.
- **Constants next to the query,** in the same class. Cost: the same as strings, with a name.

Recommendation: constants (raw string literals) in the handler class for short queries. The module offers no loader in the first version. `StockReserveCommandHandler` in the demo already does this with a raw string constant.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Which bulk operations do we need first, and how are they done? The options for the first operation:
- **Bulk insert with `SqlBulkCopy`.** Fastest for large loads. Cost: SQL Server only (see question 1) and it needs a `DataTable` or a reader.
- **Table valued parameters.** Good for medium sizes and for update or merge by key. Cost: a table type in the database for each shape.
- **Batched statements.** Works on every database. Cost: slower for large sets.

Recommendation: start with bulk insert through `SqlBulkCopy` in `Cat.Dapper.SqlServer`, and leave update, delete and merge until the demo needs them. "Bulk" means a few thousand rows or more, where the single statement path is too slow. The demo has no bulk case yet, so the first real use should decide the rest.
<!-- region end: Question 4-->

<!-- region start: Question 6-->
#### Question 6
Does the demo order overview query already exist as a need, or do we start with Inventory? The options:
- **Start with the order overview in Orders.** It is the read-only case in the demo plan. Cost: the overview is not built yet, so a new query is needed first.
- **Start with Inventory.** It exists, and it already writes raw SQL through EF Core in the handlers. Cost: Inventory is mostly commands with conditional updates, which do not need Dapper much.

Recommendation: the order overview, as a query. Inventory's raw SQL is a command with a transaction, which EF Core handles well (see [Cat.EFCore.md](Cat.EFCore.md)). A read-only overview over several tables shows Dapper at its best.
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
Should the module offer paging helpers for queries? A paged result type already exists (`ICatPagedList` in `Cat.Responses`). The options:
- **Yes,** a helper that adds `OFFSET` and `FETCH` and a count. Cost: SQL Server specific syntax, so it goes in the SQL Server project.
- **No,** the query writes its own paging. Cost: every query repeats it.

Recommendation: yes, one helper in `Cat.Dapper.SqlServer` that returns an `ICatPagedList`, and the same shape as the paging question 7 in [Cat.EFCore.md](Cat.EFCore.md) so the two modules feel alike.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
How do we test the SQL itself, and against which database? The unit tests of the core use fake processors. The options:
- **A local SQL Server,** the developer already has. Cost: the tests only run where one exists.
- **A container,** for example Testcontainers. Cost: Docker is needed to run the tests, and they are slower. The demo already needs Docker for the AppHost.
- **Not at all.** Cost: the SQL is only proven by the demo.

Recommendation: a container for the SQL tests of this module, in a test project that can be skipped when there is no Docker. Integration testing is out of scope for `Cat.UnitTesting`, so these tests live in the repository test project of this module only.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Which Dapper version and which extensions, if any, are acceptable as dependencies? The options:
- **Dapper only.** Cost: no help with things like bulk or dynamic SQL.
- **Dapper plus one extension** such as `Dapper.Contrib` or `Dapper.AOT`. Cost: more dependencies to keep up to date, and some are not actively maintained.

Recommendation: Dapper only, the current stable version. Check that it targets `netstandard2.0` (it does in recent versions, to verify when the project is added) so the neutral project can keep the target framework rule.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Is there a naming convention for the result classes in `DataModels`? The readme says `DataModels` also holds result classes. The options:
- **A suffix per kind,** such as `OrderOverviewRow` for Dapper results and `OrderEntity` for entities. Cost: a convention to document.
- **No convention.** Cost: a reader cannot tell a result class from an entity.

Recommendation: a suffix, `Row` for a result class of a query. It is short, and the readme gets one more line.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Dapper maps columns by name. How do we deal with `Guid`, UTC dates and column naming conventions? The options:
- **The developer handles it** with aliases in the SQL and type handlers of their own. Cost: the same code in every service.
- **Ready type handlers in the module,** for example a UTC `DateTime` handler and the underscore to PascalCase rule (`MatchNamesWithUnderscores`). Cost: global settings, because Dapper type handlers are static, which can surprise a developer.

Recommendation: the developer handles it for now, and the readme lists the two usual traps (UTC dates, and static type handlers). Add ready handlers only if the demo needs one, since Dapper's settings are global and a toolbox module must not change a global behind a developer's back.
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Do results map straight to the `DataModels` result classes? The options:
- **Yes.** The query handler returns the result class straight from Dapper. Cost: the result class must match the column names (question 11).
- **Through an extra mapping step** such as Mapperly. Cost: one more class per query.

Recommendation: yes, straight. A result class exists to match a query, so a second mapping adds work for nothing.
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
Do the Dapper handlers use the same standard mapping of database errors to responses as the EF Core handlers? The mapping is question 4 in [Cat.EFCore.md](Cat.EFCore.md). The options:
- **Yes, one shared helper.** A small project such as `Cat.Sql.Errors` that both use. Cost: one more project, and it must not reference EF Core.
- **Each module its own.** Cost: two copies of the SQL Server error numbers.

Recommendation: wait for the EF Core answer. The SQL Server error number helpers should be in one place that both modules can reference. If they end up in `Cat.EFCore` they are no use to Dapper, so a neutral place is the better outcome.
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
Parameters are always used. Do we offer a guard against string concatenation? The options:
- **No guard.** Cost: a developer can still build SQL with interpolation.
- **An analyzer or a method signature that takes a constant string only.** For example a parameter marked `[StringSyntax]` or an analyzer that flags interpolation. Cost: more to build and to maintain.
- **Document it.** Cost: nobody enforces it.

Recommendation: document it with an example of the safe way, and make the handler methods take the SQL as a plain `string` together with a parameters object. A real guard is an analyzer, which is a separate piece of work to put on a later list.
<!-- region end: Question 14-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->