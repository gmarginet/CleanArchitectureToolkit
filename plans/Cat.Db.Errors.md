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

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
- [Phase 1](#phase-1)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
A new module, `Cat.Db.Errors`, with helpers that recognize database errors by their number, so `Cat.EFCore` and `Cat.Dapper` share one copy. The first project is `Cat.Db.Errors.SqlServer`. Other databases follow later, such as `Cat.Db.Errors.MySql`.

#### Background
From [Cat.EFCore.md](Cat.EFCore.md):
- The handler maps database errors to responses. The base class only offers helpers, such as `IsUniqueViolation(exception)`.
- Inventory catches the SQL Server errors 2627 and 2601 to make a repeated reserve safe, and Catalog catches the unique index error and returns `DEM-CTL-1000`.

From [Cat.Dapper.md](Cat.Dapper.md):
- `Cat.Dapper.SqlServer` needs the same helpers. It must not reference an EF Core project, and `Cat.EFCore` must not reference a Dapper project.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- The error numbers are written inline in the Inventory handlers of the demo.

#### Decided
- **Name.** The module is `Cat.Db.Errors`, and its projects are `Cat.Db.Errors.SqlServer` and later `Cat.Db.Errors.MySql`.
- **Place.** A module of its own, so neither `Cat.EFCore` nor `Cat.Dapper` has to reference the other. Both reference this module.
- **Content.** The error number helpers, one project per database. `Cat.Db.Errors.SqlServer` comes first and `Cat.Db.Errors.MySql` is wanted later.
- **Dependencies.** The module references no EF Core and no Dapper.
- **Target.** `netstandard2.0` if the helpers need no more. Check this when the project is added.
- **First version.** The common set of helpers: unique key violation (2627 and 2601), foreign key violation (547), deadlock (1205) and a timeout check.
- **Reading the number.** `Cat.Db.Errors.SqlServer` references `Microsoft.Data.SqlClient` and checks `SqlException.Number`, so the check is typed and not done by reflection.

#### Still to check while building
- Which SQL Server client package and version the demo and EF Core use, so the module references the same one.
- The error numbers, and which number the timeout check looks at.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->