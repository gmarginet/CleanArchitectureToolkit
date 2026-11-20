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
- [Phase 3](#phase-3)
- [Phase 4](#phase-4)
<!-- region end: Phases-->

<!-- region start: Phase 3-->
## Phase 3

### Description
<!-- region start: PhaseDescription-->
#### Goal
The bulk operations of `Cat.Dapper.SqlServer`.

#### Decided
- **Operations.** Bulk insert, update, delete and merge, all four from the start. The demo does not have to use them, because it is a showcase and not every feature of a module is in it.
- **Place.** `Cat.Dapper.SqlServer`, because the bulk code is specific to SQL Server (see the [module readme](../modules/Cat.Dapper/README.md) for the projects).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 9-->
#### Question 9
What does the developer pass as the rows of a bulk call? The options:
- **A list of objects.** `IEnumerable<T>`, the same result classes the developer already uses with Dapper. The module reads the properties. Cost: the module builds the reader or the `DataTable` itself, with reflection that it should build once per type and keep.
- **A `DataTable`.** Cost: the developer builds a table by hand, and it holds all rows in memory.
- **An `IDataReader`.** Cost: only fits a developer who already has a reader, such as a copy from one database to another.

Recommendation: a list of objects as the main way, and an `IDataReader` as a second overload, because `SqlBulkCopy` streams from a reader and a reader fits a big copy without holding every row in memory. Leave the `DataTable` out. It adds nothing a list does not give.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
How does the developer name the table and the columns, and how is the name kept safe? A table and a column name goes into the SQL text, so a parameter cannot protect it. The options for the mapping:
- **By convention.** The table name is passed as a string, and a property name is the column name. A column list can override this. Cost: a property that is not a column needs a way to be skipped.
- **With attributes on the class.** `[Table]` and `[Column]` of `System.ComponentModel.DataAnnotations.Schema`. Cost: an attribute on the result class, and a class that already has them for Entity Framework Core would be read twice.
- **A mapping object.** The developer builds it once per type, with a table, the columns and the keys. Cost: the most to write.

And for the safety of the name:
- **Quote it.** The module wraps every name in brackets and refuses a name that holds a bracket. Cost: none worth the name.

Recommendation: the convention with an optional column list, and the quoting always. A bulk call then reads `BulkInsertAsync(rows, "dbo.Orders")`. The mapping object is more than a showcase needs.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
For update, delete and merge, how do the rows reach the database before the statement runs? The statement needs the keys and the new values on the server. The options:
- **A temporary staging table.** The module creates `#table` on the connection of the session, fills it with `SqlBulkCopy`, runs one set-based statement that joins it to the target, and drops it. Cost: the types of the staging columns come from the target table, so an identity column needs care. Check this when building. The session keeps one connection for the whole scope, so the temporary table stays visible between the calls.
- **Table valued parameters.** Cost: a table type in the database for each shape, which the module cannot create for the developer without a migration.
- **Batched statements.** One statement with parameters for each batch. Cost: SQL Server allows 2100 parameters in one request, so a large set takes many round trips, and it is the slow path that a bulk call is meant to avoid.

Recommendation: the staging table. It needs nothing in the database, it reuses the `SqlBulkCopy` path of the insert, and the target gets one statement for all rows.
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
How do the bulk calls take part in the transaction of the session, and how is a big set cut up? `SqlBulkCopy` needs a `SqlTransaction` and a `SqlConnection`, and the session gives a `DbTransaction` and a `DbConnection`. The options for the transaction:
- **Use the transaction of the session when one is running, and none otherwise.** Cost: without a transaction, a failure in the middle leaves the batches that were already written.
- **Always use one.** The module starts a transaction when none runs, commits it and starts nothing when one exists. Cost: a bulk call that the developer did not expect to be atomic holds a lock longer.

And for the size of a batch and the timeout:
- **Settings on the call with a default.** A `BatchSize` and a `Timeout` as optional arguments. Cost: two more arguments.
- **No settings.** Cost: a developer with a very large set cannot tune it.

Recommendation: use the transaction of the session when one runs, and none otherwise, so the developer decides and the module does not hide a transaction. Add the batch size and timeout as optional arguments, because a bulk load is where a developer needs them.
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
Bulk insert: how is it done, and what comes back? The options for the technique:
- **`SqlBulkCopy` straight into the target table.** Fastest for large loads. Cost: SQL Server only.
- **Through the staging table of question 11, then `INSERT ... SELECT`.** Cost: a second copy of the rows, slower, but it can fill generated values.

And for the generated values, such as an identity column or a default:
- **Not returned.** `SqlBulkCopy` does not hand back generated identities. The call returns the number of copied rows. Cost: a developer who needs the new ids has to read them afterwards.
- **Returned with `OUTPUT`.** Only possible with the staging table. Cost: the slower path.

Recommendation: `SqlBulkCopy` straight into the target, returning the row count. A developer who needs generated ids gives the key values themselves, such as a `Guid`.
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
Bulk update: which columns identify a row, and which columns change? The options:
- **The developer names both.** A list of key columns and a list of columns to update. Cost: two lists to pass.
- **The keys only, and every other mapped column changes.** Cost: a developer cannot leave a column such as `CreatedAt` out without a skip rule.
- **The keys from the primary key of the table.** The module reads it from the database. Cost: one more query, and a table without a primary key has no way in.

Recommendation: the developer names the key columns, and the columns to update default to every other mapped column, with an optional list to narrow them. The call returns the number of changed rows.
<!-- region end: Question 14-->

<!-- region start: Question 15-->
#### Question 15
Bulk delete: what identifies the rows to delete? The options:
- **The key columns of the given rows, one key or several.** The rows go to the staging table and the delete joins on all key columns. Cost: the developer passes objects where an id alone would be enough.
- **A list of single values for a single key column.** `BulkDeleteAsync(ids, "dbo.Orders", "Id")`. Cost: a table with a composite key is not covered.

Recommendation: the first option, because it covers a composite key, and add the second as a short overload for a list of single values. The call returns the number of deleted rows.
<!-- region end: Question 15-->

<!-- region start: Question 16-->
#### Question 16
Bulk merge, which means update the rows that exist and insert the ones that do not: how is it done, and which actions does it have? The options for the technique:
- **The `MERGE` statement with `HOLDLOCK`.** One statement for all rows, joined to the staging table. Cost: `MERGE` is known for edge cases on SQL Server, and it needs `HOLDLOCK` to be safe when two callers run at the same time. Check this when building.
- **An `UPDATE` followed by an `INSERT` of the rows that were not updated.** Cost: two statements, and the same care for concurrency, but the statements are plain and easy to read.

And for the actions:
- **Update the matches and insert the rest.** Cost: a row that exists in the target and not in the given set stays.
- **Also delete the rows the given set does not hold.** `WHEN NOT MATCHED BY SOURCE THEN DELETE`. Cost: a call that deletes a whole table when the given set is empty, which is dangerous as a default.

Recommendation: the `MERGE` with `HOLDLOCK`, or the `UPDATE` and `INSERT` if the building shows trouble, with the update and insert actions only. The delete of rows that are missing from the set is not part of a merge here, because a bulk delete exists for it. The call returns the number of inserted and the number of updated rows.
<!-- region end: Question 16-->

<!-- region start: Question 17-->
#### Question 17
How do we prove the bulk operations? The module decided it has no tests of the SQL itself and that the demo proves the SQL. The bulk operations are not in the demo, and the SQL of an update, delete or merge is the part that goes wrong. The options:
- **Unit tests of the generated SQL text only.** No database. Cost: it does not prove that the statements run.
- **Tests against a real SQL Server in a container.** Cost: Docker for every developer and for the build workflow, and a slower test run.
- **A small use in the demo anyway.** Cost: the demo gets a case it does not need.

`Cat.Dapper.MySql` (built) has unit tests only, because it has no bulk operations and its paging is not proven on a real MySQL. `Cat.Dapper.PostgreSQL` of [phase 4](#phase-4) starts the same way. When this question chooses containers, add a MySQL and a PostgreSQL container to the same test project, so the build gets a container once and not per database.

Recommendation: the unit tests of the generated SQL text, plus the tests against a container for the four operations only, kept in one test project, so the part that is easiest to get wrong runs against the real database. Check what the build workflow supports before you decide.
<!-- region end: Question 17-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 3-->

<!-- region start: Phase 4-->
## Phase 4

### Description
<!-- region start: PhaseDescription-->
#### Goal
PostgreSQL support for `Cat.Dapper`, next to SQL Server and MySQL. The second database of the demo showcase is PostgreSQL, see [Phase 13 of the demo](Demo.md#phase-13).

#### What exists today
- `Cat.Dapper.SqlServer` and `Cat.Dapper.MySql` each hold a connection factory and a paging helper, and each references the error checks of its database. Both target `netstandard2.0`.
- `Cat.Dapper.MySql` references `Cat.Db.Errors.MySql`, so MySQL support is complete only with both projects.
- The driver is the Npgsql ADO.NET package. This phase does not need the Npgsql EF Core provider, so it does not wait for EF Core 11.

#### Needs
- `Cat.Db.Errors.PostgreSQL`, the PostgreSQL error checks that the project references, see [Cat.Db.Errors.md](Cat.Db.Errors.md#phase-1).

#### Decided
- **A new project.** `Cat.Dapper.PostgreSQL` is added next to `Cat.Dapper.SqlServer` and `Cat.Dapper.MySql` (owner, 2026-11-20).
- **MySQL stays.** `Cat.Dapper.MySql` and `Cat.Db.Errors.MySql` are kept (owner, 2026-11-20).
- **Target framework.** `net10.0;net11.0`. The rule is `netstandard2.0` if the packages allow it, and otherwise `net10.0;net11.0` (owner, 2026-11-20). Npgsql 10.0.3 targets `net8.0`, `net9.0` and `net10.0` only, read on nuget.org on 2026-11-20, so `netstandard2.0` is not possible. The version of Npgsql for `net11.0` is to check.

#### Done when
A developer can register `Cat.Dapper` on PostgreSQL, page a result and ask an exception what happened, with the same check names as on the other two databases. The module readme says how.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 4-->
