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

<!-- region start: FirstStableVersion-->
**First stable version:** reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 1](#phase-1)
- [Phase 2](#phase-2)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
Make `Cat.EFCore.Extensions` provider neutral. Phase 2 adds MySQL on top of it.

#### What exists today
- `Cat.EFCore.Extensions` is not neutral, although its name says so. It references `Microsoft.EntityFrameworkCore.SqlServer`, and it gives `Cat.EFCore.Extensions.SqlServer` access to its internals.
- `ConfigureCatEntity` calls `IsClustered(false)` on the primary key `Id`, `UseIdentityColumn()` on `SequenceId` and `IsClustered()` on the unique index of `SequenceId`. `ConfigureCatReferenceEntity` calls `IsClustered(false)` too. When no schema is known, the schema falls back to `dbo`.
- The demo services call `ConfigureCatEntity` and `ConfigureCatTemporalEntity`.

#### Decided
- **How it becomes neutral.** The SQL Server calls move into `Cat.EFCore.Extensions.SqlServer`. The neutral `Cat.EFCore.Extensions` project keeps the shared part and references no provider package. A developer calls the method of the project of their database. The provider projects use the same method names, so a developer only changes a reference and a `using`. The demo changes the same way. The move is a breaking change, because `ConfigureCatEntity` moves for every developer who uses it today.
- **A breaking change is accepted.** The module is Stable, and the change is described in the module readme. Every developer who uses `ConfigureCatEntity` changes a reference. The old methods do not stay in `Cat.EFCore.Extensions` as obsolete methods, because they would keep the one reference this plan removes.

#### Done when
`Cat.EFCore.Extensions` references no provider package, and a developer on SQL Server keeps the same base entities. The project of one database does not pull in the provider package of another. The module readme says how, and the tests cover it.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
Add MySQL to the module, on top of the provider neutral `Cat.EFCore.Extensions` of phase 1. It is one of the module plans of the MySQL showcase in [Phase 13 of the demo](Demo.md#phase-13).

#### What exists today
- The temporal projects, `Cat.EFCore.Entities.SqlServer` and `Cat.EFCore.Extensions.SqlServer`, are SQL Server only. MySQL has no temporal tables, so they get no MySQL version.
- The outbox, the inbox and the scheduler claim store use plain EF Core, with `HasMaxLength`, `HasIndex` and `ExecuteUpdate`. They make no provider call, and nobody has run them on MySQL.

#### Needs
- [Phase 1](#phase-1) of this plan.
- A stable Pomelo for EF Core 11 to prove the result on MySQL, see [Phase 13 of the demo](Demo.md#phase-13).
#### Decided
- **A MySQL project.** `Cat.EFCore.Extensions.MySql` is added next to `Cat.EFCore.Extensions.SqlServer`, with the same method names, as decided for phase 1.
- **The shape on MySQL.** `SequenceId` is the primary key and `Id` is a unique key. It gives MySQL the same physical design that SQL Server has today: the table is clustered on the increasing number, and the GUID sits in an index of its own, so every index stays small on a big table. The decision is for a big database, and the demo is no argument. Consequences: the two databases differ in shape, and the rest of the module and the generated clients must not depend on which column is the key. `Id` is an alternate key (`HasAlternateKey`) and not only an index, so a foreign key that points at `Id` keeps working, to check when building. `ConfigureCatReferenceEntity` stays as it is, because someone else owns those tables. `Find(guid)` does not work on MySQL, see the lookup methods below. The module readme states the differences. Check how Pomelo stores a `Guid` by default.
- **Lookup methods.** `FindByIdAsync(Guid id)` and `FindBySequenceIdAsync(int sequenceId)` are extension methods on `DbSet<TEntity>` for entities that derive from `CatEntityBase`. Both exist on both databases, so the same code runs on SQL Server and on MySQL. They live in the neutral `Cat.EFCore.Extensions`, not in the provider projects, because the neutral project needs one implementation only and works on any provider. The method reads the primary key from the EF Core model. When the requested column is the key it calls `Find`, and otherwise it looks in the change tracker first and then queries. They cannot be named `Find`, because an instance method wins over an extension method and `set.Find(guid)` always binds to the built-in one, so a test proves this when building. The built-in `Find` stays, and a developer can still call it with the wrong key on a database where the column is not the key. The module readme says to use the new methods. Check the cost of reading the model at run time in a test.

#### Done when
A developer can use the base entities on SQL Server and on MySQL. The module readme says how, and the tests cover both shapes.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->
