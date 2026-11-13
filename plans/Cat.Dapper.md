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
[![READY TO START BUILDING](https://img.shields.io/badge/Status-READY%20TO%20START%20BUILDING-green)](#plans-for-catdapper)
<!-- region end: StatusBadge-->

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
A new module, `Cat.Dapper`, with base query and command handlers for Dapper.

#### The idea
Entity Framework Core is a good fit for writes and for entity graphs. For a fast read-only overview, for stored procedures and views, and for bulk loads, plain SQL with Dapper is simpler and quicker.

`Cat.Dapper` gives the same handler style as the other modules, with Dapper underneath. A query handler runs a SQL statement and returns a result. A command handler runs a statement. Bulk operations come in phase 2.

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
- **Scope.** Query and command handlers with Dapper. Bulk operations and embedded SQL files are phase 2.
- **Place in the demo.** Read-only order overviews, and the Inventory service. The first case is the order overview query in Orders.
- **Dependencies.** The core never references this module.
- **Order of work.** Built after `Cat.EFCore.Queries` and `Cat.EFCore.Commands`, so Dapper copies a proven shape for the base classes and the paging helper. The base classes of `Cat.EFCore` have no error helpers. The handler uses the ones in `Cat.Db.Errors.SqlServer`, and Dapper does the same.
- **Projects.** `Cat.Dapper.Abstractions` with the connection factory and the session, a neutral `Cat.Dapper` with the handlers, and `Cat.Dapper.SqlServer` for everything SQL Server specific, such as the paging helper.
- **SQL text.** In the first version the SQL lives in constants (raw string literals) in the handler class, and the module offers no loader. `StockReserveCommandHandler` in the demo already does this.
- **Paging.** One helper in `Cat.Dapper.SqlServer` that returns an `ICatPagedList`, with the same shape as the paging helper of `Cat.EFCore.Queries`, see the [module readme of Cat.EFCore](../modules/Cat.EFCore/README.md).
- **Dependencies of the module.** Dapper only, the current stable version. Check when the project is added that it targets `netstandard2.0`, so the neutral project can keep the target framework rule.
- **Connection and transaction.** Two layers. A singleton connection factory, registered with the connection string, creates a `DbConnection`. A scoped session, one per handler, takes one connection from the factory and opens it on first use, so the handler never opens it. The session offers `BeginTransactionAsync`. The handler commits explicitly, and a transaction that is not committed rolls back when the scope ends. The factory and the session live in `Cat.Dapper.Abstractions`, so `Cat.EFCore` or a service can use them without the Dapper implementation. `Cat.Dapper` stays neutral, and a database adds its own project, such as `Cat.Dapper.SqlServer` and later `Cat.Dapper.MySql`. A service that also uses EF Core can build its `DbContext` on the connection of the session.
- **Testing the SQL.** The module has no tests of the SQL itself, so no container and no in memory database. The SQL is proven by the demo. The handlers can still be unit tested in the services with the fakes of `Cat.UnitTesting`.
- **Error numbers.** The SQL Server error number helpers live in `Cat.Db.Errors.SqlServer`, which both `Cat.EFCore` and `Cat.Dapper.SqlServer` reference. It belongs to a module of its own, `Cat.Db.Errors`, see the [module readme of Cat.Db.Errors](../modules/Cat.Db.Errors/README.md). A MySql project follows when MySql is planned.
- **Result classes.** The readme recommends a suffix for the result classes in `DataModels`, and the demo uses `Row`. The module does not enforce a name. It is the developer's choice.
- **Column mapping.** The developer handles `Guid`, UTC dates and column names, with aliases in the SQL and type handlers of their own. The module readme lists the two usual traps, UTC dates and static type handlers. A ready handler is added only when the demo needs one, since Dapper settings are global.
- **Result mapping.** The query handler returns the result class straight from Dapper, with no extra mapping step.
- **SQL injection.** The module readme documents the safe way with an example. The handler methods take the SQL as a plain `string` and a parameters object. An analyzer that flags string concatenation is not part of this plan.
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
Embedded `.sql` files as a second place for the SQL text, and the bulk operations of `Cat.Dapper.SqlServer`.

#### Decided
- **Embedded SQL files.** The developer chooses between constants in the handler class and embedded `.sql` files next to the handler. The module offers a loader for the embedded files. Phase 1 has constants only, see phase 1.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 4-->
#### Question 4
Which bulk operations do we need first, and how are they done? The options for the first operation:
- **Bulk insert with `SqlBulkCopy`.** Fastest for large loads. Cost: SQL Server only (it lives in `Cat.Dapper.SqlServer`, see phase 1) and it needs a `DataTable` or a reader.
- **Table valued parameters.** Good for medium sizes and for update or merge by key. Cost: a table type in the database for each shape.
- **Batched statements.** Works on every database. Cost: slower for large sets.

Recommendation: start with bulk insert through `SqlBulkCopy` in `Cat.Dapper.SqlServer`, and leave update, delete and merge until the demo needs them. "Bulk" means a few thousand rows or more, where the single statement path is too slow. The demo has no bulk case yet, so the first real use should decide the rest.

##### Answer 4
Move this to phase 2
<!-- region end: Question 4-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->