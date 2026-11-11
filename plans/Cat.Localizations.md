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

# Plans for `Cat.Localizations` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catlocalizations)
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
`Cat.Localizations` already exists and is marked in development. This phase finishes the module and uses it in the demo.

#### What exists today
- `Cat.Localizations.Abstractions` holds `ICatLocalizer`. It is a contract to look up a localized string by key, so the rest of the app does not depend on one provider.
- `Cat.Localizations` holds the no-op localizer and the module registration `AddCatNoLocalizationLocalizer`.
- The no-op localizer returns the key itself. It fills in placeholders when the key contains them, in the order of the arguments.
- The module readme shows how to write your own `ICatLocalizer`.
- The readme marks the module as in development.

#### What we want to build
- A real provider, so the module is useful beyond the no-op localizer. Which one comes first is open (see question 2). Each provider is a project that a developer can pick or skip.
- The demo uses the module for category names, order statuses and email texts in a few languages. See [Demo.md](Demo.md).
  - Category names are plain text today, because the module is not used yet.

#### Decided
- The demo waits until the module is stable. See [Demo.md](Demo.md).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
What is left before the module is stable? In other words, what must be true before we drop the "in development" badge?
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Which real implementation do we ship or document first: resource files, `IStringLocalizer` from ASP.NET Core, or a database? Each one is a project a developer can pick or skip.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Where does the current culture come from: the request, the user, or a parameter?
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Category names live in the database. How do we localize data that sits in the database: through keys, or by storing a translation per language?
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Do the codes from `Cat.Responses` and `Cat.Validators` get localized messages through the localizer? See [Cat.Responses.md](Cat.Responses.md).
<!-- region end: Question 5-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->