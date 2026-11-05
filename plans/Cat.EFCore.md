# Plans for Cat.EFCore

New projects in the existing `Cat.EFCore` module: base query and command handlers for Entity Framework Core, and a transaction decorator for commands.  
Status: not started. `Cat.EFCore` itself exists. Only the new projects are planned. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Two jobs repeat in every service that uses Entity Framework Core.

**Handlers.** In the infrastructure project, every query handler and command handler repeats the same work: get the `DbContext`, read or change entities, save, return an `ICatResponse`. A base class can do the repeating part, so a handler only holds what is special about it.

**Transactions.** Some work must succeed or fail as one unit. A command decorator can open a transaction before the handler runs, commit when the response is a success, and roll back when it fails. The handler does not have to know.

Neither gets a module of its own. They become new projects inside `Cat.EFCore`, next to the entity and model builder projects. A developer picks the projects they need and leaves the rest.

## What we already know

From the root readme:

- The infrastructure project holds the query handlers, the command handlers, the data access code and the registration extension method.
- The core only knows the abstractions of `Cat.Queries` and `Cat.Commands`. The infrastructure implements the handlers.
- The core knows nothing about the database.
- The entities live in `DataModels`. We suggest Mapperly for mapping, and CAT has no mapping module.

From the existing modules:

- `Cat.EFCore` already exists. It has `Cat.EFCore.Entities` (base classes for regular, temporal and reference data) and `Cat.EFCore.Extensions` (model builder extensions). It has no dependencies on other CAT modules.
- `Cat.Queries` and `Cat.Commands` define the handler interfaces and the processors. Handlers are registered by scanning assemblies and run through decorators from `Cat.Decorators`. The command module ships a logging decorator you switch on when you need it.
- A command returns no data, only the outcome as an `ICatResponse`. A failed response is the normal way to say something went wrong, so a transaction decorator has two signals: a failed response and an exception.

From the demo:

- Catalog has query handlers such as `BookSearchQueryHandler` and `BookGetQueryHandler`, and a command handler `BookSaveCommandHandler`.
- Orders has handlers for customers, orders, payments and the daily counter. `OrderCreateCommandHandler` increases the counter with raw SQL and saves the order and its lines in one transaction. If saving fails, the counter rolls back too. This is the demo case for transactions.
- The place order workflow runs several commands one after the other: customer, order, payment. They are separate units today. A failed payment cancels the order with a new command and does not roll back.
- The Catalog save handler catches the unique index error and returns a failed response with `CAT-CTL-1000`. That is a common pattern a base class could offer.
- The demo registers its `DbContext` with a connection string and applies migrations at startup in `Development`.
- Inventory is database first. Its handlers would use a scaffolded `DbContext` that does not inherit the CAT entity classes.

From the saga plan:

- A saga must save its state and send a message as one unit. A crash between the save and the send makes it hang. The outbox pattern solves it, and the plan expects it to live with the transactions. Without the outbox, the timeout is the safety net.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Scope | Base handlers for queries and commands on EF Core, and a transaction decorator for commands. |
| Home | One module, `Cat.EFCore`, with several projects. Handlers and transactions are new projects next to `Cat.EFCore.Entities` and `Cat.EFCore.Extensions`. A developer picks what they want to use. |
| No separate transactions module | There is no `Cat.Transactions`. Transactions are part of `Cat.EFCore`. |
| Entities | The entity base classes stay in `Cat.EFCore.Entities`. |
| Dependencies | The core never references this module. Only the infrastructure does. |
| Demo case | Saving an order and its lines in one go. |

### Open

**Structure**

- **Project split.** Which new projects? For example `Cat.EFCore.Handlers` for the base classes and `Cat.EFCore.Transactions` for the decorator. Do the abstractions get their own project, as in the other modules?
- **Dependencies.** The handler project needs `Cat.Queries` and `Cat.Commands`. Does the transaction project need only `Cat.Commands` and `Cat.Decorators`?

**Handlers**

- **Shape.** A generic base class per handler kind, helper methods, or an `ICatDbContext` abstraction?
- **DbContext.** One context per service, injected. Does the base class need to know the type, or does it work with a generic context type?
- **Queries.** `AsNoTracking` by default? Paging, sorting and filtering helpers? Projection to a result type without loading the entity?
- **Commands.** Does the base class call `SaveChanges`? What if a workflow runs several commands that should be one unit?
- **Errors.** Standard mapping from database errors to responses: unique key, foreign key, concurrency. The `CAT-CTL-1000` handler in Catalog is the first example.
- **Concurrency.** Row versions and the retry or conflict response.
- **Raw SQL.** The order counter needs it. Is there a supported way?
- **Database first.** Does it work with scaffolded contexts that do not use the CAT entity classes?
- **Expressions.** Does it use `Cat.Expressions` for compiled member access?

**Transactions**

- **Technology.** A `DbContext` transaction, `TransactionScope`, or an abstraction over both? Since the module is EF Core only, the `DbContext` transaction is the likely default.
- **Scope.** One command, one service request, or one workflow? A decorator on service requests would cover the whole use case. The idea says commands.
- **Nesting.** A command that sends a command. Join the outer transaction, or open a new one?
- **Failure rule.** Commit on a success response, roll back on a failed response or an exception? What about a response with warnings?
- **Several databases.** Out of scope? A distributed transaction is not something we want.
- **Isolation level.** A default, and a way to change it per command.
- **Execution strategy.** EF Core's retry strategy for transient errors does not mix with user transactions unless wrapped.
- **Outbox.** A table in the service database, a background sender, and inbox ids on the receiving side. Does it belong in a project of this module or in `Cat.Messaging`?
- **Dapper.** Can `Cat.Dapper` commands join the same transaction?
- **Opt in.** Does every command get a transaction, or only the marked ones?

## Questions before building

1. Which projects do we add to `Cat.EFCore`, and what do we call them?
2. What do you like better for the handlers: a base class to inherit, or a few helper methods to call?
3. Should a command handler save changes, or does something else, like the transaction decorator, do it?
4. Which database errors should become standard responses?
5. Must it work with database first services and scaffolded contexts?
6. Which paging, sorting and filtering do we need, and do we want it here or in `Cat.Queries`?
7. Do we handle optimistic concurrency from the start?
8. Should the unit of a transaction be a command, a service request or a workflow?
9. Should a failed response always roll back?
10. Do we mark commands that need a transaction, or give all of them one?
11. Is an outbox part of the first version, and does it live here or in `Cat.Messaging`?
12. How should `Cat.Dapper` and EF Core share a transaction?
13. Do you want the place order workflow to become one transaction in the demo, or is the cancel on failure approach fine?
14. What isolation level do you want as the default?
15. Is SQL Server the only database to test against? Temporal tables already tie the demo to it.
16. How much of the demo handler code should move into the module? Do we start by refactoring the demo handlers, as the Aspire plan does for the API client?
