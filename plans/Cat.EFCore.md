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
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catefcore)
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
`Cat.EFCore` already exists. This phase adds new projects to it: base query and command handlers for Entity Framework Core, and maybe a transaction decorator for commands. Only the new projects are planned.

#### The idea
Two jobs repeat in every service that uses Entity Framework Core.

**Handlers.** In the infrastructure project, every query handler and command handler repeats the same work: get the `DbContext`, read or change entities, save, return a `ICatResponse`. A base class can do the repeating part, so a handler only holds what is special about it.

**Transactions.** Some work must succeed or fail as one unit. A command decorator can open a transaction before the handler runs, commit when the response is a success, and roll back when it fails. The handler does not have to know.

Neither gets a module of its own. They become new projects inside `Cat.EFCore`, next to the entity and model builder projects. A developer picks the projects they need and leaves the rest.

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
- None of the new projects exist yet: `Cat.EFCore.Queries`, `Cat.EFCore.Commands` and `Cat.EFCore.Commands.Decorators`.
- In the demo, three handlers open their own transaction: `OrderCreateCommandHandler` in Orders (the order and the counter, raw SQL), and `StockReserveCommandHandler` and `StockReleaseCommandHandler` in Inventory (conditional updates with raw SQL, and a failed response for out of stock that must undo the lines already reserved). Inventory also catches the unique key errors 2627 and 2601 to make the reserve safe to repeat.

#### Decided
- **Scope.** Base handlers for queries and commands on EF Core, and a transaction decorator for commands. See question 1, which the owner questions.
- **Home.** One module, `Cat.EFCore`, with several projects. A developer picks what they want to use.
- **No separate transactions module.** There is no `Cat.Transactions`. Transactions are part of `Cat.EFCore`.
- **Entities.** The entity base classes stay in `Cat.EFCore.Entities`.
- **Dependencies.** The core never references this module. Only the infrastructure does. Every project references only what it needs.
- **Projects.** `Cat.EFCore.Queries` for query handlers, `Cat.EFCore.Commands` for command handlers and `Cat.EFCore.Commands.Decorators` for the transaction decorator.
- **Shape.** A generic base class per handler kind.
- **DbContext.** The base classes use a generic context type.
- **Tracking.** Queries use `AsNoTracking` by convention. A developer can override it per query type.
- **Demo case.** Saving an order and its lines in one go.

#### What the code says about transactions
These facts were checked for the note of the owner behind question 1.
- **`SaveChanges` is atomic.** EF Core saves all pending changes in one transaction. A handler that changes entities and calls `SaveChanges` once needs no transaction of its own. The Catalog handlers and most Orders handlers work this way.
- **Where `SaveChanges` is not enough.** `ExecuteSql` and `ExecuteUpdate` run at once, outside that transaction, and a handler that calls `SaveChanges` twice makes two units. Three demo handlers need an explicit transaction: `OrderCreateCommandHandler` in Orders, because the counter is raised with raw SQL before the order is saved, and the two stock handlers in Inventory, which use raw SQL for every line. The Inventory reserve also returns a failed response after it changed some lines, so a failed response must roll back when the handler opted in to a transaction.
- **Every command has its own scope.** `CatCommandProcessor` creates a new DI scope for every command it processes. So a command that runs a command, or a workflow that runs several commands, gets a `DbContext` for each. They cannot share a transaction, and "join the outer transaction" does not exist unless something ambient is added, such as `TransactionScope` over several connections. That can escalate to a distributed transaction, which we do not want. To check before it is used.
- **A decorator does not know the context.** A decorator on `ICatCommandHandler<TCommand>` is open over the command, not over the `DbContext`. A service with two contexts needs a decorator per context, or a marker on the command that names the context.
- **An outbox needs no decorator.** A row in the outbox table, added to the same `DbContext` as the entities, is saved by the same `SaveChanges`.

#### Related points, not decided
These follow from the recommendation in question 1, option A.
- **Raw SQL.** The order counter needs it. With option A the base class gives the handler the transaction, so raw SQL and `SaveChanges` run in one unit. No other support seems needed. To check against the demo.
- **Execution strategy.** The retry strategy of EF Core does not mix with developer transactions unless the transaction runs inside the strategy. With option A the base class does that in one place. The demo does not set a retry strategy today.
- **Several databases.** Out of scope. A distributed transaction is not something we want.

#### What to build
The query side can be built now. The decisions cover the project, the shape, the generic context and the tracking default.
- **`Cat.EFCore.Queries`.** A generic base class for query handlers with `AsNoTracking` by default and an override per query type. It references `Cat.Queries`, `Cat.Responses` and EF Core. Open points that do not block it: paging, sorting and projection (question 7). They can come later.
- **`Cat.EFCore.Commands`.** It waits for the answer to question 1. The base class is the same in options A and C. The decision is what it does with `SaveChanges` and the transaction.
- **`Cat.EFCore.Commands.Decorators`.** It waits for the answer to question 1. With option A it is not built.

The projects target the latest stable .NET, because they use EF Core. Check this when the projects are added.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Do we drop the transaction decorator from the first version, and make the command handler the unit of work, as in option A? This is the blocking question. Questions 2, 3, 8 and 11 follow from it, and `Cat.EFCore.Commands.Decorators` waits for it.

The note of the owner: every decorator wraps every handler, so a transaction decorator would put every command in a transaction. But `SaveChanges` is already the unit of work. Is the decorator needed? Is the command handler the unit of work? What if a command runs a command? See "What the code says about transactions" in the description. The demo has three handlers that need an explicit transaction today (`OrderCreateCommandHandler`, `StockReserveCommandHandler` and `StockReleaseCommandHandler`), so the case is real.

Options:
- **A. The command handler is the unit of work, in the base class.** `Cat.EFCore.Commands` has a base class with an abstract method that does the work. The base class calls `SaveChanges` once after a successful response, and saves nothing for a failed one. A handler that needs an explicit transaction opts in, for example with an overridable property. The base class then opens the transaction, runs the work inside the execution strategy of EF Core, and commits on success. It rolls back on a failed response, which the Inventory reserve needs. Cost: no decorator project, and the transaction logic sits in one place that knows the context type. A handler that does not inherit from the base class gets no transaction.
- **B. A transaction decorator, as planned.** It wraps every command handler, or only the commands marked with an attribute or an interface. Cost: the context problem (a decorator is open over the command, not over the `DbContext`), the nesting question for commands that run commands, and a transaction for commands that do not need one. With the marker it is opt-in, and then it only does what option A does with a property.
- **C. Both.** The base class saves once. The decorator exists for the few handlers that need more, and is off unless marked. Cost: two ways to do one thing.

Recommendation: A. It follows from the owner's own conclusion that the handler is the unit of work, and from the scope per command. Leave `Cat.EFCore.Commands.Decorators` out of the first version, and add it when a real case needs a transaction around code that is not a base class handler. A workflow with several commands then stays several units, with the cancel on failure approach of the demo. That is also the way a saga thinks: compensate, not roll back. If the owner agrees, the project name `Cat.EFCore.Commands.Decorators` leaves the Decided list.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Does the command base class call `SaveChanges` once after a success response, and can a developer switch that off? Only relevant with option A of question 1. The Inventory handlers call `SaveChanges` themselves today, in the middle of their own transaction. The options:
- **Always once, no switch.** `SaveChanges` with no pending changes does nothing, so a handler that used `ExecuteUpdate` only pays nothing. Cost: a handler that saves in steps (two `SaveChanges` calls) cannot stop the base class from saving a third time, which is harmless but surprising.
- **Once, with an overridable property to turn it off.** Cost: one more property that most developers never touch.

Recommendation: always once, no switch. Add the switch when a real handler needs it.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
How does a handler ask for an explicit transaction? Only relevant with option A of question 1. The options:
- **An overridable property,** such as `protected virtual bool UseTransaction => false`. Cost: a handler cannot decide at run time, but that is rarely needed.
- **An attribute on the handler class.** Cost: reflection, and the setting is away from the code that needs it.
- **A method call in the handler,** such as `await InTransactionAsync(work)`. Cost: the handler controls where the transaction starts, which is flexible, but the base class can no longer promise a rollback on a failed response.

Recommendation: the overridable property. It matches question 8, where the isolation level is a property too, and it keeps the base class in control of the commit and the rollback.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Which database errors become standard responses, and how does the handler name the response? The standard mapping covers errors such as unique key, foreign key and concurrency. The `DEM-CTL-1000` handler in Catalog is one example. The Inventory reserve catches the SQL Server errors 2627 and 2601 to make a repeated call safe, which is a second example. The options:
- **The handler does it, the base class only offers helpers.** Such as `IsUniqueViolation(exception)`. Cost: every handler writes its own catch.
- **A virtual method that maps an exception to a response.** The base class catches `DbUpdateException` and calls `MapException`, and the handler returns its own `CatErrorDefinition`. Cost: one more method to learn.
- **A declared map.** The handler lists "unique key means this definition". Cost: the most code in the base class, and the handler's special cases (the idempotent reserve is a success, not a failure) do not fit.

Recommendation: the virtual method with the helpers. The Inventory example shows that a developer must be able to turn a unique violation into a success, so a fixed map is too rigid. The SQL Server error numbers live in the helpers, see question 12.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Do we handle optimistic concurrency from the start? It means row versions and a response when two writers collide. It is part of the error mapping in question 4. The options:
- **A conflict response only.** A `DbUpdateConcurrencyException` becomes a failed `Conflict` response, and the caller decides what to do. Cost: no retry.
- **A conflict response plus a retry.** The base class reloads and tries again a set number of times. Cost: a retry changes the meaning of a command, and it needs a rule for what to merge.
- **Not in the first version.** Cost: a developer writes the catch alone.

Recommendation: the conflict response only. A retry decides business rules, so it stays with the developer.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Must the base classes work with database first services and scaffolded contexts that do not use the CAT entity classes? The check is done now: `InventoryDbContext` is a scaffolded `partial class` that inherits from `DbContext` only. So a base class that asks for `TDbContext : DbContext` works for all three demo services. The options:
- **Yes, constrain to `DbContext` only.** Cost: the base class cannot rely on CAT entity features such as audit columns.
- **No, require the CAT entities.** Cost: Inventory cannot use it, and the toolbox rule is broken.

Recommendation: yes. It is the smallest constraint, and it is what the Decided list already says. As proof, convert one Inventory handler to the base class when it is built.
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
Which paging, sorting and filtering do we need, and do we want it here or in `Cat.Queries`? Also: do we want projection to a result type without loading the entity? A paged result type already exists: `ICatPagedList` in `Cat.Responses`. The options:
- **Only the query handler base class now.** Paging comes later. Cost: every handler writes its own `Skip` and `Take`.
- **A paging extension on `IQueryable`** in `Cat.EFCore.Queries`, which returns an `ICatPagedList`. Cost: one more extension class, and it is EF Core specific, which is fine because the project is.
- **A paging concept in `Cat.Queries` too** (a paged query interface). Cost: it grows an abstraction that `Cat.Dapper` must follow as well.

Recommendation: the extension on `IQueryable` in `Cat.EFCore.Queries`, and leave `Cat.Queries` as it is. Sorting and filtering stay in the handler. Projection is plain `Select` and needs no support. This does not block the first build.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
What isolation level is the default, and how can it change per command? Only relevant with option A of question 1. The options:
- **The database default** (`ReadCommitted` on SQL Server), with an overridable property per handler. Cost: none.
- **A stricter default** such as `Serializable`. Cost: deadlocks and slow handlers for work that does not need it.

Recommendation: the database default, with the property. Inventory's conditional updates already stay correct at that level.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Is an outbox part of the first version, and does it live here or in `Cat.Messaging`? The outbox is a table in the service database written by the same `SaveChanges`, a background sender, and inbox IDs on the receiving side. See [Cat.Messaging.md](Cat.Messaging.md), which has the same question, and question 9 in [Cat.Sagas.md](Cat.Sagas.md). Answer it once, in the messaging plan. The options:
- **In `Cat.Messaging`,** as outbox projects next to the bus project. Cost: the outbox projects reference EF Core, so they target the latest .NET.
- **In `Cat.EFCore`.** Cost: `Cat.EFCore` then knows what a message is, which the toolbox rule does not like.
- **Not in the first version.** Cost: a crash between the save and the send can lose a message.

Recommendation: not in the first version of `Cat.EFCore`. It is a messaging concern, and the messaging plan decides it. The base command handler leaves room for it, because a row added to the same context is saved by the same `SaveChanges`.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
How should `Cat.Dapper` and EF Core share a transaction, or is that left to the handler? A Dapper command has its own scope too, so it would need the connection and the transaction of the EF handler passed in. See [Cat.Dapper.md](Cat.Dapper.md), question 2, and answer it once, there. The options:
- **Left to the handler.** The handler passes `DbContext.Database.GetDbConnection()` and the current transaction to Dapper. Cost: every developer writes the same lines.
- **A helper in `Cat.EFCore.Commands`** that exposes the current connection and transaction to the handler. Cost: a small new member on the base class, and Dapper stays unaware of EF Core.
- **A shared connection factory** in both modules. Cost: a new abstraction and a dependency between the two modules.

Recommendation: the helper on the base class. It keeps the modules apart and costs one property.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Does the place order workflow stay several units with the cancel on failure approach, or must it become one transaction? Today the workflow runs the commands for customer, order and payment as separate units, and a failed payment cancels the order with a new command. Payment is a call to another service, so it can never join a database transaction anyway.
- **Stay several units.** Cost: a failed step needs an explicit cancel step, which the demo already has.
- **One transaction.** Cost: it needs an ambient transaction over several scopes, which can escalate to a distributed transaction, and the payment call cannot take part.

Recommendation: stay several units. It follows from question 1 and from the saga idea of compensating instead of rolling back.
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Is SQL Server the only database to test against? Temporal tables already tie the demo to it, and the Inventory handlers use SQL Server error numbers and T-SQL. The options:
- **SQL Server only,** and say so in the module readme. Cost: a developer on PostgreSQL has no tested path.
- **SQL Server plus one more,** such as PostgreSQL in a container. Cost: a second test setup and an error mapping per provider.
- **Provider neutral base classes, SQL Server helpers in a separate project.** Cost: one more project.

Recommendation: SQL Server only for now, with the error number helpers in a clearly named place so another provider can add its own later.
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
How much of the demo handler code moves into the module? Do we start by refactoring the demo handlers, as the Aspire plan does for the API client? The modules come from working code, so the demo is the first user. The options:
- **Refactor first.** Convert `BookSaveCommandHandler` and `OrderCreateCommandHandler` to the new base class in the same change that builds it. Cost: a bigger change.
- **Build the module, then convert the demo.** Cost: the design is not proven by a real use until later.
- **Leave the demo handlers as they are.** Cost: the demo does not show the module.

Recommendation: build the module and convert the demo in the same phase, one handler at a time, so every base class is proven by a real handler. Start with the query side, which is not blocked.
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
Does the module use `Cat.Expressions` for compiled member access? `Cat.Expressions` exists, with a compiled member expression cache. The options:
- **No.** Cost: none, and the module keeps no dependency on it.
- **Yes, for sorting and member selection by name.** Cost: a dependency, only worth it if the module offers sorting by property name (question 7).

Recommendation: no, until question 7 asks for sorting by name. A module must not force another module on the developer.
<!-- region end: Question 14-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->