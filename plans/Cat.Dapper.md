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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

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
- The module does not exist yet. It is listed under the future modules in the readme.
- Nothing in the modules or the demo uses Dapper. The demo plan says Inventory uses the EF Core scaffold only for now, and Dapper waits for this module.

#### Decided
- **Scope.** Query and command handlers with Dapper, and bulk operations.
- **Place in the demo.** Read-only order overviews, and the Inventory service.
- **Dependencies.** The core never references this module.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Is SQL Server the only database for now? Bulk operations differ per database. A split like `Cat.Dapper` plus `Cat.Dapper.SqlServer` is possible.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Should Dapper and EF Core be able to share one connection and one transaction?

In Orders, a command through EF Core and a query through Dapper may need the same transaction. Who creates and owns the connection: a factory, or the connection of the EF Core `DbContext`? See also [Cat.EFCore.md](Cat.EFCore.md), question 10.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Where does the SQL text live: strings in the handler, embedded `.sql` files or constants next to the query?
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Which bulk operations do we need first: insert, update, delete or merge? Do we use `SqlBulkCopy`, table-valued parameters or batched statements? What size is "bulk" for us?
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Do we build this before or after the `Cat.EFCore` handler projects, so the two share a design?
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Does the demo order overview query already exist as a need, or do we start with Inventory?
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
Should the module offer paging helpers for queries?
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
How do we test the SQL itself, and against which database? The unit tests of the core use fake processors. Options: a local SQL Server, a container, or not at all.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Which Dapper version and which extensions, if any, are acceptable as dependencies?
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Is there a naming convention for the result classes in `DataModels`?
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Dapper maps columns by name. How do we deal with `Guid`, UTC dates and column naming conventions?
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Do results map straight to the `DataModels` result classes?
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
Do the Dapper handlers use the same standard mapping of database errors to responses as the EF Core handlers?
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
Parameters are always used. Do we offer a guard against string concatenation?
<!-- region end: Question 14-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->