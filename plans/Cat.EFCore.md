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
- [Phase 2](#phase-2)
<!-- region end: Phases-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
Add MySQL to the module, on top of the provider neutral `Cat.EFCore.Extensions`. It is one of the module plans of the MySQL showcase in [Phase 13 of the demo](Demo.md#phase-13).

#### What exists today
- The temporal projects, `Cat.EFCore.Entities.SqlServer` and `Cat.EFCore.Extensions.SqlServer`, are SQL Server only. MySQL has no temporal tables, so they get no MySQL version.
- The outbox, the inbox and the scheduler claim store use plain EF Core, with `HasMaxLength`, `HasIndex` and `ExecuteUpdate`. They make no provider call, and nobody has run them on MySQL.

#### Needs
- A stable Pomelo for EF Core 11 to prove the result on MySQL, see [Phase 13 of the demo](Demo.md#phase-13).
#### Decided
- **A MySQL project.** `Cat.EFCore.Extensions.MySql` is added next to `Cat.EFCore.Extensions.SqlServer`, with the same method names. The neutral project holds a shared internal helper that the provider projects reach through `InternalsVisibleTo`, and it sets the save behavior of `SequenceId`. Each provider project adds its own key, identity and index calls.
- **The shape on MySQL.** `SequenceId` is the primary key and `Id` is a unique key. It gives MySQL the same physical design that SQL Server has today: the table is clustered on the increasing number, and the GUID sits in an index of its own, so every index stays small on a big table. The decision is for a big database, and the demo is no argument. Consequences: the two databases differ in shape, and the rest of the module and the generated clients must not depend on which column is the key. `Id` is an alternate key (`HasAlternateKey`) and not only an index, so a foreign key that points at `Id` keeps working, to check when building. The check includes a reference entity of another service: its model uses `Id` as the key, and the foreign key of the other service points at the unique key `Id`, so a test proves that the migration works with Pomelo. The neutral `Configure` sets `SetAfterSaveBehavior(Ignore)` on `SequenceId`, and EF Core may reject that on a property that is part of a key, so a test on MySQL proves it, and the line moves to the SQL Server action when it fails. The summary of `CatReferenceEntityBase.Id` says "non-clustered primary key", which only fits SQL Server, so reword it to say "the key". `ConfigureCatReferenceEntity` gets a MySQL version on the shared helper of the neutral project, with no clustered call, because someone else owns those tables. Whether the MySQL method keeps a schema parameter is decided when the phase starts. `Find(guid)` does not work on MySQL, see the lookup methods below. The module readme states the differences. Check how Pomelo stores a `Guid` by default.
- **Lookup methods.** `FindByIdAsync(Guid id)` and `FindBySequenceIdAsync(int sequenceId)` are extension methods on `DbSet<TEntity>` for entities that derive from `CatEntityBase`. Both exist on both databases, so the same code runs on SQL Server and on MySQL. They live in the neutral `Cat.EFCore.Extensions`, not in the provider projects, because the neutral project needs one implementation only and works on any provider. The method reads the primary key from the EF Core model. When the requested column is the key it calls `Find`, and otherwise it looks in the change tracker first and then queries. They cannot be named `Find`, because an instance method wins over an extension method and `set.Find(guid)` always binds to the built-in one, so a test proves this when building. The built-in `Find` stays, and a developer can still call it with the wrong key on a database where the column is not the key. The module readme says to use the new methods. Check the cost of reading the model at run time in a test.

#### Done when
A developer can use the base entities on SQL Server and on MySQL. The module readme says how, and the tests cover both shapes.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->
