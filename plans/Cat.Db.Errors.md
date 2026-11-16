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

<!-- region start: StatusBadge-->
[![READY TO START BUILDING](https://img.shields.io/badge/Status-READY%20TO%20START%20BUILDING-green)](#plans-for-catdberrors)
<!-- region end: StatusBadge-->

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
A MySQL project next to the SQL Server project, so a developer who uses MySQL gets the same checks on a database exception. It is one of the module plans of the MySQL showcase in [Phase 13 of the demo](Demo.md#phase-13).

#### What exists today
- The module has one project, `Cat.Db.Errors.SqlServer`. It reads `SqlException.Number` from `Microsoft.Data.SqlClient` and has the numbers as constants in `CatSqlServerErrorNumbers`. It makes no call to the database.
- The checks are extension methods on `Exception`. They look at the exceptions inside the one you pass, so they work on the `DbUpdateException` of EF Core and on the exception of Dapper. See the [module readme](../modules/Cat.Db.Errors/README.md).
- The tests build a `SqlException` with a factory, so the module needs no database to test.

#### Needs
The MySQL driver that the new project references is MySqlConnector, the driver under Pomelo, which the demo uses. The owner decided the same driver for every module, see the [plan of Cat.Dapper](Cat.Dapper.md). The numbers below are to check against the MySQL documentation before they go into code: 1062 for a duplicate key, 1451 and 1452 for a foreign key, 1213 for a deadlock and 1205 for a lock wait timeout.

#### Decided
- **No neutral shape.** The checks stay extension methods of the project of the database, as today. Code that wants to be database neutral picks a project, and the demo services use the SQL Server one. A neutral `Cat.Db.Errors.Abstractions` with the checks as an interface can come when a showcase needs it.

#### Done when
A `Cat.Db.Errors.MySql` project has the checks that make sense for MySQL, with tests, and the module readme describes it.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->
