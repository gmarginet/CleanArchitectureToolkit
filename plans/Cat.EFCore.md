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
Add PostgreSQL to the module, on top of the provider neutral `Cat.EFCore.Extensions`. It is one of the module plans of the PostgreSQL showcase in [Phase 13 of the demo](Demo.md#phase-13).

#### What exists today
- The temporal projects, `Cat.EFCore.Entities.SqlServer` and `Cat.EFCore.Extensions.SqlServer`, are SQL Server only. PostgreSQL has no built in temporal tables (to check), so they get no PostgreSQL version.
- The outbox, the inbox and the scheduler claim store use plain EF Core, with `HasMaxLength`, `HasIndex` and `ExecuteUpdate`. They make no provider call, and nobody has run them on PostgreSQL.

#### Needs
- A stable Npgsql EF Core provider for EF Core 11, to prove the result on PostgreSQL on .NET 11, see [Phase 13 of the demo](Demo.md#phase-13). The owner decided to wait for the stable version and not to use a release candidate. The provider for EF Core 10 is stable (to check on nuget.org), see question 2.

#### Decided
- **Both versions.** The PostgreSQL project supports EF Core 10 and EF Core 11, like the rest of the module (owner, 2026-11-20).
- **A PostgreSQL project.** `Cat.EFCore.Extensions.PostgreSQL` is added next to `Cat.EFCore.Extensions.SqlServer`, with the same method names. The neutral project holds a shared internal helper that the provider projects reach through `InternalsVisibleTo`, and it sets the save behavior of `SequenceId`. Each provider project adds its own key, identity and index calls.
- **The summary of `CatReferenceEntityBase.Id`.** It says "non-clustered primary key", which only fits SQL Server, so reword it to say "the key".
- **The reference entity.** `ConfigureCatReferenceEntity` gets a PostgreSQL version on the shared helper of the neutral project, with no clustered call, because someone else owns those tables. Whether the PostgreSQL method keeps a schema parameter is decided when the phase starts.
- **Lookup methods.** `FindByIdAsync(Guid id)` and `FindBySequenceIdAsync(int sequenceId)` are extension methods on `DbSet<TEntity>` for entities that derive from `CatEntityBase`. Both exist on both databases, so the same code runs on SQL Server and on PostgreSQL. They live in the neutral `Cat.EFCore.Extensions`, not in the provider projects, because the neutral project needs one implementation only and works on any provider. The method reads the primary key from the EF Core model. When the requested column is the key it calls `Find`, and otherwise it looks in the change tracker first and then queries. They cannot be named `Find`, because an instance method wins over an extension method and `set.Find(guid)` always binds to the built-in one, so a test proves this when building. The built-in `Find` stays, and a developer can still call it with the wrong key on a database where the column is not the key. The module readme says to use the new methods. Check the cost of reading the model at run time in a test.

#### Done when
A developer can use the base entities on SQL Server and on PostgreSQL, on EF Core 10 and on EF Core 11. The module readme says how, and the tests cover both shapes.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Which column is the primary key on PostgreSQL? The earlier decision for the second database was written for MySQL. It made `SequenceId` the primary key and `Id` a unique key, so the table is clustered on the increasing number and every index stays small on a big table. PostgreSQL does not cluster a table on its primary key. It stores rows in a heap, so that reason does not hold. The options:
- **The same shape as SQL Server.** `SequenceId` is the primary key and `Id` is an alternate key (`HasAlternateKey`). Cost: no physical gain on PostgreSQL, and a unique index on the GUID that exists anyway. Gain: one shape on every database, so the rest of the module and the generated clients never depend on which column is the key.
- **`Id` is the primary key and `SequenceId` a unique identity column.** `Find(guid)` then works on PostgreSQL. Cost: the two databases differ in shape, and the GUID keeps the random order of its index unless the provider generates sequential values, to check for Npgsql.

The first option comes with checks, carried over from the MySQL decision:
- A foreign key that points at `Id` keeps working through the alternate key, to check when building. The check includes a reference entity of another service: its model uses `Id` as the key, and the foreign key of the other service points at the unique key `Id`, so a test proves that the migration works with Npgsql.
- The neutral `Configure` sets `SetAfterSaveBehavior(Ignore)` on `SequenceId`, and EF Core may reject that on a property that is part of a key, so a test on PostgreSQL proves it, and the line moves to the SQL Server action when it fails.
- `Find(guid)` does not work on PostgreSQL, see the lookup methods.
- Check how Npgsql stores a `Guid`. It should be the native `uuid` type (to check).
- The module readme states the differences between the databases.

Recommendation: the same shape as SQL Server. PostgreSQL gains nothing from the other shape, one shape keeps the shared helper simple, and the lookup methods already hide which column is the key.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Does the PostgreSQL project wait for the Npgsql provider of EF Core 11? The provider of EF Core 10 is stable (to check), and the one of EF Core 11 has no stable release yet. The options:
- **Build for `net10.0` now, and add `net11.0` when the provider is stable.** The project targets `net10.0` only for a while. Cost: the module has no PostgreSQL proof on EF Core 11 until then. Gain: the module work does not wait for a release without a date, and only the demo waits, because it stays on `net11.0`.
- **Wait for both.** Cost: the whole phase waits for the provider of EF Core 11.

Recommendation: build for `net10.0` now. The module and its tests get a real PostgreSQL early, and the second target framework is a project file change when the provider arrives. The demo showcase still waits, as decided in [Phase 13 of the demo](Demo.md#phase-13).
<!-- region end: Question 2-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->
