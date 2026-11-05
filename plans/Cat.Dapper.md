# Plans for Cat.Dapper

Base query and command handlers for Dapper, including bulk operations.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Entity Framework Core is a good fit for writes and for entity graphs. For a fast read-only overview, for stored procedures and views, and for bulk loads, plain SQL with Dapper is simpler and quicker.

`Cat.Dapper` gives the same handler style as the other modules, with Dapper underneath. A query handler runs a SQL statement and returns a result. A command handler runs a statement or a bulk operation.

## What we already know

From the root readme:

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

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Scope | Query and command handlers with Dapper, and bulk operations. |
| Place in the demo | Read-only order overviews, and the Inventory service. |
| Dependencies | The core never references this module. |

### Open

- **Database support.** SQL Server only, or other databases too? Bulk operations differ per database. A split like `Cat.Dapper` plus `Cat.Dapper.SqlServer` is possible.
- **Connection.** Who creates and owns the connection? A factory, or the connection of the EF Core `DbContext`?
- **Shared transaction.** In Orders, a command through EF Core and a query through Dapper may need the same transaction. How do they share it?
- **Where the SQL lives.** Strings in the handler, embedded `.sql` files or constants next to the query?
- **Bulk.** `SqlBulkCopy`, table-valued parameters or batched statements? What size is "bulk" for us?
- **Mapping.** Dapper maps columns by name. How do we deal with `Guid`, UTC dates and column naming conventions?
- **Result types.** Do results map straight to the `DataModels` result classes?
- **Errors.** The same standard mapping of database errors to responses as the EF Core handlers?
- **Safety.** Parameters always. Do we offer a guard against string concatenation?
- **Tests.** The unit tests of the core use fake processors. How do we test the SQL itself, and against which database?

## Questions before building

1. Is SQL Server the only database for now?
2. Should Dapper and EF Core be able to share one connection and one transaction?
3. Where do you want the SQL text to live?
4. Which bulk operations do you need first: insert, update, delete or merge?
5. Do we build this before or after the `Cat.EFCore` handler projects, so the two share a design?
6. Does the demo order overview query already exist as a need, or do we start with Inventory?
7. Should the module offer paging helpers for queries?
8. How do we want to test the SQL: a local SQL Server, a container, or not at all?
9. Which Dapper version and which extensions, if any, are acceptable as dependencies?
10. Is there a naming convention for the result classes in `DataModels`?
