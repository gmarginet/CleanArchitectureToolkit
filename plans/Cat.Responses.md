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
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catresponses)
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

#### What to build
What is decided is a convention and documentation. It needs no new design. The helper and the texts wait for the open questions. The work, in order:
1. **Rename the demo codes.** `CAT-CTL-`, `CAT-ORD-` and `CAT-INV-` become `DEM-CTL-`, `DEM-ORD-` and `DEM-INV-`. This touches the three `*ErrorDefinitions` classes, the `.http` files, the unit tests of Orders, the web client tests, `tests/Cat.Api.Client.Tests` (they use the codes as sample data), `demo/README.md` and `plans/Demo.md`. Search with `git grep` for every old prefix.
2. **Change the example codes in the module READMEs.** `CAT-DEM-1000` in `Cat.Responses` and `Cat.Minimal.Api` clashes with the convention, because `DEM` is now an application. The short examples `ORD-1001` and `ORD-1002` in `Cat.Responses` and `Cat.FluentWorkflows` do not follow it either. Use `DEM-ORD-1001` style codes.
3. **Add the error code lists.** `Cat.Responses` already has a table for `CAT-GEN-`. `Cat.Validators` documents `CAT-VAL-1001` to `CAT-VAL-1017` in its README, check that all of them are in a list. `Cat.ServiceRequests` and `Cat.Api.Client` only return `CAT-GEN-1001`, so they point to the `Cat.Responses` list. `Cat.Commands` and `Cat.Queries` say that the application defines the codes, so they need no list.
4. **Write the convention in the `Cat.Responses` README**, with the table of area abbreviations once it is decided.
5. **List the demo errors in `demo/README.md`**, one table per service, built from the three definition classes.

The `cat-internal-create-module-readme` and `cat-internal-create-demo-readme` skills cover the README work. Do the rename (step 1) in its own commit, before the documentation.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Do we reserve number ranges for kinds of errors, or keep counting up from 1000?

The convention names the prefix, not the number. Today every code starts at 1000 and counts up (`CAT-GEN-1001`, `CAT-VAL-1000` to `CAT-VAL-1017`, and the demo codes). The options:
- **No ranges.** Count up from 1000 and never reuse a number. Cost: the number says nothing about the kind of error.
- **Ranges per kind.** For example 1000 for unknown, 1001 and up for rules. Cost: a debate about every new error, and ranges that fill up.

Recommendation: no ranges. The code is only an identifier, and a range invites a debate about every new error. Keep counting up from 1000 and never reuse a number.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Where does the list of taken area abbreviations live?

Three letters run out fast, and two modules can pick the same ones. `Cat.EventAggregators` and `Cat.EventProcessor` could both choose `EVE` or `EVT`, for example. The options:
- **One table in the `Cat.Responses` README.** It has the area, the module and the range in use. Cost: someone must keep it up to date, and a module owner can forget.
- **One table in the plan, until the convention is final.** Cost: the table moves later, and developers cannot see it.
- **No list.** Clashes are found in review. Cost: two modules can pick the same area without anybody noticing.

Recommendation: one table in the `Cat.Responses` README, with the area, the module and the range in use. A module owner adds a row when the module gets its first code.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Do we add a helper for building codes, and which option: a second `Create` overload, a prefix object, or nothing?

All three demo services repeat the same shape. A private constant holds the prefix, and every line builds the code with string interpolation. The options, with what each one costs:
- **Option 1, a second `Create` overload.** The prefix and the number go in as separate arguments, and the code is built for you.

  ```csharp
  public static class OrderErrorDefinitions
  {
      public static readonly CatErrorDefinition PriceUnavailable =
          CatErrorDefinition.Create("DEM-ORD", 1001, "The price of book {BookId} is not available.");
  }
  ```

  It is one method in `Cat.Responses`, with no new type. It can check the shape, 3 + 3 uppercase characters, and fail at startup when a developer types a wrong prefix. The check would also have to allow the free choice of the developer, so it can only warn or must be left out.
- **Option 2, a prefix object.** A small class holds the prefix, and every definition asks it.

  ```csharp
  public static class OrderErrorDefinitions
  {
      private static readonly CatErrorCodePrefix Prefix = new("DEM", "ORD");

      public static readonly CatErrorDefinition PriceUnavailable =
          Prefix.Define(1001, "The price of book {BookId} is not available.");
  }
  ```

  It reads a bit cleaner when a class has many definitions, and the prefix is written once. It costs a new public type.
- **Option 3, nothing.** Keep the private constant. It is two lines per class and everybody understands it.

Recommendation: Option 1. It saves the interpolation, and it is the smallest change. Option 3 is a fair choice, because the gain is small.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Parked, not blocking: do the codes get localized messages through `Cat.Localizations`? The owner decided to wait until it is clearer how `Cat.Localizations` works. This is the same point as question 5 in [Cat.Localizations.md](Cat.Localizations.md), so answer it once, there. Nothing in this phase depends on it, and the rename and the lists of codes can go ahead.
<!-- region end: Question 4-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->