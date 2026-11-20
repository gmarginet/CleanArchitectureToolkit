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

# Plans for `Cat.Db.Errors` <!-- omit in toc -->  

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
PostgreSQL error checks, in a new project `Cat.Db.Errors.PostgreSQL` next to the SQL Server and MySQL projects. `Cat.Dapper.PostgreSQL` of [Cat.Dapper.md](Cat.Dapper.md#phase-4) references it, and the PostgreSQL showcase of [Phase 13 of the demo](Demo.md#phase-13) can use it.

#### What exists today
- `Cat.Db.Errors.SqlServer` and `Cat.Db.Errors.MySql` recognize an error by its number, with the same check names: `IsUniqueViolation`, `IsForeignKeyViolation`, `IsDeadlock` and `IsTimeout`. See the [module readme](../modules/Cat.Db.Errors/README.md).
- Both projects target `netstandard2.0`, have no calls to the database and reference the driver of their database.
- PostgreSQL reports a five character SQLSTATE code, not a number, such as `23505` for a unique key violation, `23503` for a foreign key violation and `40P01` for a deadlock (to check). Npgsql exposes it as `PostgresException.SqlState` (to check). The driver is the Npgsql ADO.NET package, so this phase does not wait for the Npgsql EF Core provider.

#### Decided
- **A new project.** `Cat.Db.Errors.PostgreSQL` is added next to the other two (owner, 2026-11-20).
- **MySQL stays.** `Cat.Db.Errors.MySql` is kept, because `Cat.Dapper.MySql` references it (owner, 2026-11-20).
- **Target framework.** `net10.0;net11.0`. The rule is `netstandard2.0` if the packages allow it, and otherwise `net10.0;net11.0` (owner, 2026-11-20). Npgsql 10.0.3 targets `net8.0`, `net9.0` and `net10.0` only, read on nuget.org on 2026-11-20, so `netstandard2.0` is not possible. The version of Npgsql for `net11.0` is to check.

#### Done when
A developer can ask an exception for a unique key violation, a foreign key violation, a deadlock and a timeout on PostgreSQL, with the same check names as on the other two databases. The module readme and the tests cover it.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
What do the public constants of the PostgreSQL project look like? The other two projects have `CatSqlServerErrorNumbers` and `CatMySqlErrorNumbers`, with integer constants. A PostgreSQL code is text. The options:
- **`CatPostgreSQLErrorCodes` with string constants.** Cost: a different name from the other two projects. Gain: the name says what the value is.
- **`CatPostgreSQLErrorNumbers` with string constants.** Cost: the name says number for a value that is text. Gain: the same name pattern as the other two.

Recommendation: `CatPostgreSQLErrorCodes`, because a text value called a number misleads a developer. The readme names the difference once.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Which conditions count as a timeout for `IsTimeout`? The MySQL check covers a command timeout and a lock wait timeout. PostgreSQL has no single code for both. A command timeout can arrive as a `TimeoutException` inside the Npgsql exception, or as the code `57014` when the server cancels the statement, and a lock that is not available is `55P03` (to check all three). The options:
- **Cover all three.** Cost: a check that holds three conditions.
- **Cover the command timeout only.** Cost: a lock wait timeout is not recognized, so it differs from the other two projects.

Recommendation: cover all three, so `IsTimeout` means the same on every database. Check each condition against Npgsql when building.
<!-- region end: Question 2-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->
