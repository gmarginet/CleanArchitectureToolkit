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
- [Phase 3](#phase-3)
<!-- region end: Phases-->

<!-- region start: Phase 3-->
## Phase 3

### Description
<!-- region start: PhaseDescription-->
#### Goal
Add `net11.0` to `Cat.EFCore.Extensions.PostgreSQL` and prove the PostgreSQL support on EF Core 11. It is one of the module plans of the PostgreSQL showcase in [Phase 13 of the demo](Demo.md#phase-13).

#### What exists today
- `Cat.EFCore.Extensions.PostgreSQL` is built for `net10.0` with the Npgsql provider 10.0.3, see the [module readme](../modules/Cat.EFCore/README.md). The base entities, the lookup methods and the model shape tests run on EF Core 10.
- The outbox, the inbox and the scheduler claim store use plain EF Core, with `HasMaxLength`, `HasIndex` and `ExecuteUpdate`. They make no provider call, and nobody has run them on PostgreSQL. The tests that run them on a real PostgreSQL belong to [Cat.IntegrationTesting.md](Cat.IntegrationTesting.md#phase-1).
- The test project `Cat.EFCore.PostgreSQL.Tests` targets `net10.0` only, because the Npgsql provider 10.0.3 needs EF Core 10.

#### Needs
- A stable Npgsql EF Core provider for EF Core 11. The latest release is `11.0.0-rc.3`, and the owner decided to wait for the stable version and not to use a release candidate.

#### Decided
- **Both versions.** The PostgreSQL project supports EF Core 10 and EF Core 11, like the rest of the module (owner, 2026-11-20).
- **Build order.** `net10.0` came first, and `net11.0` is added when the Npgsql provider for EF Core 11 is stable (owner, 2026-11-20). The demo showcase waits for it, see [Phase 13 of the demo](Demo.md#phase-13).

#### Done when
`Cat.EFCore.Extensions.PostgreSQL` targets `net10.0` and `net11.0`, and its tests run on both. The package versions of the provider per target framework are in `Directory.Packages.props`. The module readme drops the note that the project targets `net10.0` only.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 3-->
