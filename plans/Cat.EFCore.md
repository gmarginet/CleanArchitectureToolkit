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
Make `Cat.EFCore.Extensions` provider neutral, and add what MySQL needs. It is one of the module plans of the MySQL showcase in [Phase 13 of the demo](Demo.md#phase-13).

#### What exists today
- `Cat.EFCore.Extensions` is not neutral, although its name says so. It references `Microsoft.EntityFrameworkCore.SqlServer`, and it gives `Cat.EFCore.Extensions.SqlServer` access to its internals.
- `ConfigureCatEntity` calls `IsClustered(false)` on the primary key `Id`, `UseIdentityColumn()` on `SequenceId` and `IsClustered()` on the unique index of `SequenceId`. `ConfigureCatReferenceEntity` calls `IsClustered(false)` too. When no schema is known, the schema falls back to `dbo`.
- The temporal projects, `Cat.EFCore.Entities.SqlServer` and `Cat.EFCore.Extensions.SqlServer`, are SQL Server only. MySQL has no temporal tables, so they get no MySQL version.
- The outbox, the inbox and the scheduler claim store use plain EF Core, with `HasMaxLength`, `HasIndex` and `ExecuteUpdate`. They make no provider call, and nobody has run them on MySQL.
- The demo services call `ConfigureCatEntity` and `ConfigureCatTemporalEntity`.

#### Needs
A stable Pomelo for EF Core 11 to prove the result on MySQL, see [Phase 13 of the demo](Demo.md#phase-13). The module plan [Cat.Db.Errors.md](Cat.Db.Errors.md) does not block this plan.

#### Done when
A developer can use the base entities on SQL Server and on MySQL and the project of one database does not pull in the provider package of the other. The module readme says how, and the tests cover both shapes.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
How does `Cat.EFCore.Extensions` become provider neutral? The options:
- **Move the SQL Server calls into `Cat.EFCore.Extensions.SqlServer`** and add `Cat.EFCore.Extensions.MySql`. The neutral project keeps the shared part. A developer calls the method of the project of their database. Cost: a breaking change, because `ConfigureCatEntity` moves for every developer who uses it today.
- **One method that checks the provider at run time.** Cost: the neutral project still references every provider package, which is the thing this plan removes.
- **A neutral method with a hook that each provider project fills.** Cost: more types, for one place that differs.

Recommendation: the first option, with the same method names in the provider projects, so a developer only changes a reference and a `using`. The demo then changes the same way.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
What shape does the base entity get on MySQL? The entity has a `Guid` key `Id` and a unique `SequenceId` that the database generates. A MySQL table is always clustered on its primary key, so a non-clustered key is not possible. An auto increment column must be a key or the first column of an index. The options:
- **The same shape.** `Id` stays the primary key and `SequenceId` is an auto increment column with a unique index. Cost: the random `Guid` is the clustered key, so inserts land all over the table, and that costs speed on a large table.
- **`SequenceId` as the primary key on MySQL and `Id` as a unique index.** Cost: the two databases differ in shape, and the rest of the module and the generated clients must not depend on which one is the key.

Recommendation: the same shape. The goal is one entity that works on both databases, and a demo table of mails is small. The readme states the cost for a large table.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Does the module accept a breaking change? It is Stable today, and the first option of Question 1 moves methods. The options:
- **Accept it** and describe the change in the module readme. Cost: every developer who uses `ConfigureCatEntity` has to change a reference.
- **Keep the old methods in `Cat.EFCore.Extensions` for a while, marked obsolete.** Cost: the project keeps its reference to the SQL Server provider until they go.

Recommendation: accept it. The old methods would keep the one reference this plan wants to remove, and the module has few users while it is young. The owner knows the real number of users.
<!-- region end: Question 3-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->
