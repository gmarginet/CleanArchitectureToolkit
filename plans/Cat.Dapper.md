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

<!-- region start: FirstStableVersion-->
**First stable version:** reached
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
The bulk operations of `Cat.Dapper.PostgreSQL`: insert, update, delete and merge, next to the ones of `Cat.Dapper.SqlServer`.

#### What exists today
- `Cat.Dapper.SqlServer` has `BulkInsertAsync`, `BulkUpdateAsync`, `BulkDeleteAsync` and `BulkMergeAsync` on `ICatDbSession`, see the [module readme](../modules/Cat.Dapper/README.md). They use `SqlBulkCopy`, a temporary staging table and one `MERGE` statement.
- `Cat.Dapper.PostgreSQL` has the connection factory and the paging helper only. It targets `net10.0` and `net11.0` and uses the Npgsql driver.
- The code that maps the properties of a row class to columns (`BulkColumns`) and the result class `CatBulkMergeResult` are in the SQL Server project. The reader that streams the rows to `SqlBulkCopy` is SQL Server specific.
- Npgsql has a binary `COPY` import (`BeginBinaryImportAsync`) that streams rows to the server. This is the PostgreSQL counterpart of `SqlBulkCopy` (to check when building).

#### Decided
- **A new phase.** The PostgreSQL project gets bulk operations (owner, 2026-11-20).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Do the decisions of the SQL Server bulk operations carry over? They are: a list of objects as the rows, plus an `IDataReader` overload for insert and no `DataTable`; the table name as a string and the property name as the column name, with an optional column list; every name wrapped in quotes and refused when it holds a quote; the transaction of the session when one runs; optional `batchSize` and `timeoutSeconds` arguments; update by key columns with an optional list of columns to change; delete by objects or by a list of single values; merge that updates and inserts and never deletes; and the counts as the result. Unit tests of the generated SQL text only, because the container tests belong to `Cat.IntegrationTesting`. The options:
- **Carry over all of them.** The same method names and arguments, in the namespace `Cat.Dapper.PostgreSQL`, so a developer who changes the database changes a `using`. Cost: nothing extra, but a PostgreSQL detail may not fit, see the questions below.
- **Carry over what fits and decide the rest again.** Cost: the two databases can drift apart.

Recommendation: carry over all of them, and let the questions below cover only where PostgreSQL differs.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Where does the code live that both databases share? `BulkColumns` (the properties of a row class, read once per type) and `CatBulkMergeResult` are in `Cat.Dapper.SqlServer` today. The options:
- **Copy them into the PostgreSQL project.** Cost: two copies, and two result classes with the same name in two namespaces, so code that moves between the databases changes the type too.
- **Move them to the neutral `Cat.Dapper` project.** `BulkColumns` becomes internal with `InternalsVisibleTo` for the provider projects, and `CatBulkMergeResult` becomes public there. Cost: `CatBulkMergeResult` changes namespace, which breaks a developer who already uses it from `Cat.Dapper.SqlServer`. The bulk operations are new, so the break is small, to check against what is published.
- **Move them to `Cat.Dapper.Abstractions`.** Cost: the abstractions project gets a result class that only the bulk operations use.

Recommendation: move both to the neutral `Cat.Dapper` project, and do it now while the bulk operations are new.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
How are table and column names written on PostgreSQL? Quoted names are case sensitive there, and an unquoted name is folded to lowercase. EF Core and Npgsql quote names as the model gives them, so a table is `"Orders"`, and a project that uses snake case has `"order_id"`. The SQL Server rule, a property name is the column name, does not fit a snake case database. The options:
- **Exactly as given.** The module quotes the name as it is, and a property name is the column name. A developer with snake case columns passes a column list with the real names, and the properties are matched by name without regard to case. Cost: a snake case database needs a mapping that the module does not have.
- **A mapping from property to column.** The developer passes pairs, such as `("OrderId", "order_id")`. Cost: more to write, and a different argument than on SQL Server.
- **A naming function.** One setting for the whole database that turns a property name into a column name. Cost: global state.

Recommendation: exactly as given, the same as SQL Server, and look at the mapping again when a developer needs it. The demo showcase uses the names of the model.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
How does bulk insert work on PostgreSQL? The options:
- **Binary `COPY`.** `BeginBinaryImportAsync` with `COPY ... FROM STDIN (FORMAT BINARY)`. Rows stream to the server. Cost: each value must be written with the right .NET type, so an enum is written as its number and a null as a null.
- **Text `COPY`.** Cost: slower and the values go through text conversion.
- **`INSERT ... SELECT FROM unnest(...)` with array parameters.** Cost: slower for large sets, and every column is one array in memory.

Recommendation: binary `COPY`. It is the fastest and the counterpart of `SqlBulkCopy`. The number of copied rows comes from the importer.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
How do update and delete get the rows to the server? The options:
- **A temporary table filled with `COPY`.** `CREATE TEMP TABLE ... (LIKE target)`, then one `UPDATE ... FROM` or `DELETE ... USING` that joins on the keys. Cost: the temporary table must be dropped. It drops on commit inside a transaction, and the module drops it itself when there is none. Gain: the same shape as SQL Server, a composite key works, and `LIKE` does not copy an identity.
- **Array parameters with `unnest`.** One statement, no temporary table. Cost: a list of arrays in memory, and a statement that grows with the number of columns.

Recommendation: the temporary table with `COPY`, the same as SQL Server, so one design runs on both.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
How does bulk merge work, and which PostgreSQL versions does it need? The options:
- **`INSERT ... ON CONFLICT (keys) DO UPDATE`.** Available for years. Cost: it needs a unique constraint or unique index on the key columns, and the numbers of inserted and updated rows need a trick, `RETURNING (xmax = 0)`, to check when building.
- **The `MERGE` statement.** New in PostgreSQL 15, and `RETURNING` with `merge_action()` comes in PostgreSQL 17. Cost: a higher minimum version of the server. Gain: the same shape as SQL Server.

Recommendation: `ON CONFLICT`, with updates and inserts only. It runs on older servers and it is the usual way. The readme states that the key columns need a unique constraint. Check the counts and the concurrent behaviour in a test.
<!-- region end: Question 6-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->
