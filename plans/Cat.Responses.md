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

# Plans for `Cat.Responses` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![READY TO START BUILDING](https://img.shields.io/badge/Status-READY%20TO%20START%20BUILDING-green)](#plans-for-catresponses)
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
`Cat.Responses` already exists. This phase settles how we name error codes, then rolls the convention out: the demo codes, the README examples, the lists of codes and the convention text in the README.

#### The problem
Every failed response carries errors with a stable code. Clients match on the code, not on the text. The modules define codes and the demo services define their own, and so far nothing says how a service should choose a prefix. A clear convention keeps codes unique and tells a developer what to do.

#### What exists today
From the module READMEs:
- `Cat.Validators` uses the prefix `CAT-VAL-` and says to give your own codes a prefix of your own, like `APP-`, so they do not clash with `CAT-VAL-` or `CAT-GEN-`.
- `Cat.ServiceRequests` returns `CAT-GEN-1001` for an unexpected response.
- `Cat.Responses` has the failed types `BadRequest`, `Unauthorized`, `Forbidden`, `NotFound`, `Conflict` and `InternalServerError`.
- `Cat.Minimal.Api` shows `CAT-DEM-1000` as an example code in its readme.

From the demo:
- Catalog uses the prefix `CAT-CTL-` in `CatalogErrorDefinitions`.
- Orders uses the prefix `CAT-ORD-` in `OrderErrorDefinitions`.
- Both demo prefixes start with `CAT-`, the same start as the module codes. This is the opposite of the advice in the `Cat.Validators` readme.

#### Decided
- **Advice for your own codes.** Use a prefix of your own, as the `Cat.Validators` README says. Module codes use `CAT-` with a short area name.
- **Convention.** The pattern is `<APPLICATION>-<AREA>-<number>`. `<APPLICATION>` and `<AREA>` are 3 uppercase characters each.
- **Module codes.** `CAT` is the `<APPLICATION>` part. The `<AREA>` part is a 3 letter acronym or abbreviation of the module name, such as `GEN` and `VAL`.
- **Demo codes.** `DEM` is the `<APPLICATION>` part. The `<AREA>` part is a 3 letter acronym or abbreviation of the service name, such as `CTL`, `ORD` and `INV`. This settles the question on the demo prefixes: they change from `CAT-` to `DEM-`.
- **Own codes.** A developer is not obliged to follow the convention. Every valid string is allowed.
- **Lists of codes.** Every module README lists the error codes the module can return. The demo README lists all the errors of the demo services.
- **Where codes are defined.** Every module has a single place where its error codes are defined, like `CatValidatorErrorDefinitions` in `Cat.Validators`. How a developer defines their own codes is theirs to decide.
- **Demo files.** The demo follows the same rule with one definitions class per service, with the prefix `DEM-<AREA>`: `DEM-CTL`, `DEM-ORD` and `DEM-INV`. The services stay independent and share no project.
- **Helper.** A second `CatErrorDefinition.Create` overload takes the prefix, the number and the message and builds the code, for example `Create("DEM-ORD", 1001, "...")`. It does not check the shape of the prefix, because the free choice of the developer is decided. `CatGeneralErrorDefinitions` and `CatValidatorErrorDefinitions` use it too. Their codes do not change.
- **Area clashes.** There is no table of area abbreviations. The `cat-internal-verify-code` skill checks that two modules do not use the same area. At the end of a code change it lists the area of every error definitions class in `modules/` and fails when two modules share one. The `cat-internal-create-module` skill points to that check when it picks the area of a new module.
- **Numbers.** There are no ranges for kinds of errors. In CAT the numbers start at 1000 and count up, and a number is unique within the module, so unique within the prefix. The demo follows the same rules. A developer is not obliged to use the code or the number this way.
- **Localization.** Localization is not the responsibility of `Cat.Responses`, and `Cat.Responses` does not change because of it. How the messages are localized is designed with `Cat.Localizations`.

#### What to build
What is decided is a convention, a helper, documentation and a check in a skill. The work, in order:
1. **Add the helper.** A second `CatErrorDefinition.Create` overload in `Cat.Responses` that takes the prefix, the number and the message and builds the code, without a check of the prefix. Move `CatGeneralErrorDefinitions` and `CatValidatorErrorDefinitions` to it, and check that the tests that compare their codes still pass. Add tests for the overload.
2. **Rename the demo codes.** `CAT-CTL-`, `CAT-ORD-` and `CAT-INV-` become `DEM-CTL-`, `DEM-ORD-` and `DEM-INV-`. This touches the three `*ErrorDefinitions` classes, the `.http` files, the unit tests of Orders, the web client tests, `tests/Cat.Api.Client.Tests` (they use the codes as sample data), `demo/README.md` and `plans/Demo.md`. Search with `git grep` for every old prefix.
3. **Change the example codes in the module READMEs.** `CAT-DEM-1000` in `Cat.Responses` and `Cat.Minimal.Api` clashes with the convention, because `DEM` is now an application. The short examples `ORD-1001` and `ORD-1002` in `Cat.Responses` and `Cat.FluentWorkflows` do not follow it either. Use `DEM-ORD-1001` style codes.
4. **Add the error code lists.** `Cat.Responses` already has a table for `CAT-GEN-`. `Cat.Validators` documents `CAT-VAL-1000` to `CAT-VAL-1020` in its README, check that all of them are in a list. `Cat.ServiceRequests` and `Cat.Api.Client` only return `CAT-GEN-1001`, so they point to the `Cat.Responses` list. `Cat.Commands` and `Cat.Queries` say that the application defines the codes, so they need no list.
5. **Write the convention in the `Cat.Responses` README.**
6. **List the demo errors in `demo/README.md`**, one table per service, built from the three definition classes.
7. **Add the area check to the `cat-internal-verify-code` skill**, and a pointer to it in the `cat-internal-create-module` skill. Update the table and the entries in `.claude/skills/README.md` in the same change.

The `cat-internal-create-module-readme` and `cat-internal-create-demo-readme` skills cover the README work. Do the helper (step 1) and the rename (step 2) each in their own commit, before the documentation.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->