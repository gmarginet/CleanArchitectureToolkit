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

# Plans for `Cat.EFCore` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![READY TO START BUILDING](https://img.shields.io/badge/Status-READY%20TO%20START%20BUILDING-green)](#plans-for-catefcore)
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
`Cat.EFCore` already exists. This phase adds new projects to it: base query and command handlers for Entity Framework Core, and a project with the SQL Server specific parts. Only the new projects are planned.

#### The idea
Two jobs repeat in every service that uses Entity Framework Core.

**Handlers.** In the infrastructure project, every query handler and command handler repeats the same work: get the `DbContext`, read or change entities, save, return a `ICatResponse`. A base class can do the repeating part, so a handler only holds what is special about it.

**Transactions.** Some work must succeed or fail as one unit. The handler decides. The command base class gives it the `DbContext`, and the developer starts a transaction or calls `SaveChanges` when needed. A command decorator that does it for the handler was the first idea. It is dropped.

The handlers become new projects inside `Cat.EFCore`, next to the entity and model builder projects. A developer picks the projects they need and leaves the rest.

#### Background
From the readme:
- The infrastructure project holds the query handlers, the command handlers, the data access code and the registration extension method.
- The core only knows the abstractions of `Cat.Queries` and `Cat.Commands`. The infrastructure implements the handlers.
- The core knows nothing about the database.
- The entities live in `DataModels`. We suggest `Mapperly` for mapping, and CAT has no mapping module.

From the existing modules:
- `Cat.Queries` and `Cat.Commands` define the handler interfaces and the processors. Handlers are registered by scanning assemblies and run through decorators from `Cat.Decorators`. The command module ships a logging decorator you switch on when you need it.
- A command returns an `ICatResponse`, or an `ICatResponse<TResult>` for a typed command. A failed response is the normal way to say something went wrong, so a transaction decorator has two signals: a failed response and an exception. A decorator for commands has to cover both handler shapes, `ICatCommandHandler<TCommand>` and `ICatCommandHandler<TCommand, TResult>`.

From the demo:
- Catalog has query handlers such as `BookSearchQueryHandler` and `BookGetQueryHandler`, and a command handler `BookSaveCommandHandler`.
- Orders has handlers for customers, orders, payments and the daily counter. `OrderCreateCommandHandler` increases the counter with raw SQL and saves the order and its lines in one transaction. If saving fails, the counter rolls back too. This is the demo case for transactions.
- The place order workflow runs several commands one after the other: customer, order, payment. They are separate units today. A failed payment cancels the order with a new command and does not roll back.
- The Catalog save handler catches the unique index error and returns a failed response with `DEM-CTL-1000`. That is a common pattern a base class could offer.
- The demo registers its `DbContext` with a connection string and applies migrations at startup in `Development`.
- Inventory is database first. Its handlers would use a scaffolded `DbContext` that does not inherit the CAT entity classes.

From the saga plan:
- A saga must save its state and send a message as one unit. A crash between the save and the send makes it hang. The outbox pattern solves it, and the plan expects it to live with the transactions. Without the outbox, the timeout is the safety net.

#### What exists today
- `Cat.EFCore` has `Cat.EFCore.Entities` (base classes for regular, temporal and reference data) and `Cat.EFCore.Extensions` (model builder extensions). It has no dependencies on other CAT modules.
- None of the new projects exist yet: `Cat.EFCore.Queries`, `Cat.EFCore.Commands`, `Cat.EFCore.Extensions.SqlServer` and `Cat.EFCore.Entities.SqlServer`.
- In the demo, three handlers open their own transaction: `OrderCreateCommandHandler` in Orders (the order and the counter, raw SQL), and `StockReserveCommandHandler` and `StockReleaseCommandHandler` in Inventory (conditional updates with raw SQL, and a failed response for out of stock that must undo the lines already reserved). Inventory also catches the unique key errors 2627 and 2601 to make the reserve safe to repeat.

#### Decided
- **Scope.** Base handlers for queries and commands on EF Core. There is no transaction decorator for commands. The project `Cat.EFCore.Commands.Decorators` is not built. It can come back when a real case needs a transaction around code that is not a base class handler.
- **Command base class.** It only provides the `DbContext`. The developer decides when to start a transaction and when to call `SaveChanges`. The base class does neither, so it has no `SaveChanges` rule, no transaction property and no isolation level.
- **Errors.** The handler maps database errors to responses. The base class only offers helpers, such as `IsUniqueViolation(exception)`. The SQL Server error numbers live in the SQL Server project.
- **Concurrency.** The developer's choice. The base class may offer helper methods and nothing more. No automatic conflict response and no retry.
- **Context type.** The base classes constrain the context to `DbContext` only, so scaffolded contexts of database first services work. `InventoryDbContext` inherits from `DbContext` only. As proof, one Inventory handler is converted to the base class when it is built.
- **Paging.** A paging extension on `IQueryable` in `Cat.EFCore.Queries` that returns an `ICatPagedList`. `Cat.Queries` stays as it is. Sorting and filtering stay in the handler, and projection is a plain `Select`.
- **Databases.** The base classes are provider neutral. The SQL Server specific parts live in two separate projects, `Cat.EFCore.Extensions.SqlServer` (references EF Core, holds the extension methods for temporal tables) and `Cat.EFCore.Entities.SqlServer` (`netstandard2.0`, holds the base class for temporal tables). The base class and extension methods for temporal tables move there from `Cat.EFCore.Entities` and `Cat.EFCore.Extensions`. The SQL Server error number helpers are not in these projects, they live in `Cat.Db.Errors.SqlServer`, see [Cat.Dapper.md](Cat.Dapper.md).
- **Demo.** The module is built and the demo handlers are converted in the same phase, one handler at a time, so every base class is proven by a real handler. The query side starts first, since it is not blocked.
- **Sharing a transaction with Dapper.** Settled in [Cat.Dapper.md](Cat.Dapper.md), question 2. The developer has an easy way to start a transaction, and the mechanism that shares the connection is still open there. If it needs a factory that builds a `DbContext` from a shared connection, that factory lives in this module.
- **Place order workflow.** It stays several units, with the cancel on failure approach. Payment is a call to another service and can never join a database transaction. Every command still has its own scope.
- **Cat.Expressions.** Not used. Sorting and filtering stay in the handler, so nothing needs compiled member access.
- **Who changed a row.** Temporal tables answer what a value was and when. A developer who also wants to see who did it adds a `LastUpdatedBy` type of column. `Cat.Auditing` was dropped for this reason. The demo fills the column in the command handler from `ICatUser`, see [Demo.md](Demo.md). A `SaveChanges` interceptor that does it is not decided.
- **Temporal properties.** `CatTemporalEntityBase` has the two period properties `ValidFrom` and `ValidUntil`, mapped with `HasPeriodStart` and `HasPeriodEnd`. The move to the SQL Server projects follows with this phase.
- **Home.** One module, `Cat.EFCore`, with several projects. A developer picks what they want to use.
- **No separate transactions module.** There is no `Cat.Transactions`. Transactions are part of `Cat.EFCore`.
- **Entities.** The entity base classes stay in `Cat.EFCore.Entities`.
- **Dependencies.** The core never references this module. Only the infrastructure does. Every project references only what it needs.
- **Projects.** `Cat.EFCore.Queries` for query handlers and `Cat.EFCore.Commands` for command handlers, plus the two SQL Server projects named under Databases.
- **Shape.** A generic base class per handler kind.
- **DbContext.** The base classes use a generic context type.
- **Tracking.** Queries use `AsNoTracking` by convention. A developer can override it per query type.
- **Demo case.** Saving an order and its lines in one go.
- **Outbox.** Not in this module. It lives in `Cat.Messaging`, as `Cat.Messaging.Outbox` and `Cat.Messaging.Outbox.EFCore`, see [Cat.Messaging.md](../modules/Cat.Messaging/README.md). The base command handler leaves room for it, because a row added to the same context is saved by the same `SaveChanges`.

#### What the code says about transactions
These facts were checked for the note of the owner about the transaction decorator.
- **`SaveChanges` is atomic.** EF Core saves all pending changes in one transaction. A handler that changes entities and calls `SaveChanges` once needs no transaction of its own. The Catalog handlers and most Orders handlers work this way.
- **Where `SaveChanges` is not enough.** `ExecuteSql` and `ExecuteUpdate` run at once, outside that transaction, and a handler that calls `SaveChanges` twice makes two units. Three demo handlers need an explicit transaction: `OrderCreateCommandHandler` in Orders, because the counter is raised with raw SQL before the order is saved, and the two stock handlers in Inventory, which use raw SQL for every line. The Inventory reserve also returns a failed response after it changed some lines, so a failed response must roll back when the handler opted in to a transaction.
- **Every command has its own scope.** `CatCommandProcessor` creates a new DI scope for every command it processes. So a command that runs a command, or a workflow that runs several commands, gets a `DbContext` for each. They cannot share a transaction, and "join the outer transaction" does not exist unless something ambient is added, such as `TransactionScope` over several connections. That can escalate to a distributed transaction, which we do not want. To check before it is used.
- **A decorator does not know the context.** A decorator on `ICatCommandHandler<TCommand>` is open over the command, not over the `DbContext`. A service with two contexts needs a decorator per context, or a marker on the command that names the context.
- **An outbox needs no decorator.** A row in the outbox table, added to the same `DbContext` as the entities, is saved by the same `SaveChanges`.

#### Related points, not decided
The base class does not open transactions, so these points are left to the developer.
- **Raw SQL.** The order counter needs it. The developer starts the transaction, so raw SQL and `SaveChanges` can run in one unit. To check against the demo.
- **Execution strategy.** The retry strategy of EF Core does not mix with developer transactions unless the transaction runs inside the strategy. The module does not handle it. The demo does not set a retry strategy today.
- **Several databases.** Out of scope. A distributed transaction is not something we want.

#### What to build
The query side can be built now. The decisions cover the project, the shape, the generic context, the tracking default and paging.
- **`Cat.EFCore.Queries`.** A generic base class for query handlers with `AsNoTracking` by default and an override per query type, and the paging extension. It references `Cat.Queries`, `Cat.Responses` and EF Core.
- **`Cat.EFCore.Commands`.** A generic base class for command handlers that provides the `DbContext`, plus helpers for database errors and concurrency.
- **The SQL Server projects.** `Cat.EFCore.Entities.SqlServer` and `Cat.EFCore.Extensions.SqlServer`, with the temporal base class and extension methods that move from the existing projects. The error number helpers come from `Cat.Db.Errors.SqlServer`.
- **`Cat.EFCore.Commands.Decorators`.** Not built.

The projects target the latest stable .NET, because they use EF Core. Check this when the projects are added.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->