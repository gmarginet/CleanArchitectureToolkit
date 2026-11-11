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
`Cat.Localizations` already exists and is marked Building. This phase finishes the module and uses it in the demo.

#### What exists today
- `Cat.Localizations.Abstractions` holds `ICatLocalizer`. It is a contract to look up a localized string by key, so the rest of the app does not depend on one provider.
- `Cat.Localizations` holds the no-op localizer and the module registration `AddCatNoLocalizationLocalizer`.
- The no-op localizer returns the key itself. It fills in placeholders when the key contains them, in the order of the arguments.
- The module readme shows how to write your own `ICatLocalizer`.
- The readme marks the module as Building.

#### What we want to build
- A real provider, so the module is useful beyond the no-op localizer. Which one comes first is open (see question 2). Each provider is a project that a developer can pick or skip.
- The demo uses the module for category names, order statuses and email texts in a few languages. See [Demo.md](Demo.md).
  - Category names are plain text today, because the module is not used yet.

#### Decided
- The demo waits until the module is stable. See [Demo.md](Demo.md).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 2-->
#### Question 2
Which real provider do we ship or document first? This is the blocking question, and questions 1, 3 and 4 depend on it. Each provider is its own project, so a developer can pick it or skip it.
- **Resource files (`.resx`) through a small adapter.** Familiar to most .NET developers, works offline, and a translator can edit the files. Cost: strings are compiled in, so a change needs a deploy.
- **`IStringLocalizer` from ASP.NET Core.** One adapter project over what the framework already has, so the developer gets all its sources. Cost: the project targets the latest .NET instead of `netstandard2.0`, and it pulls in `Microsoft.Extensions.Localization`.
- **A database provider.** Strings can change without a deploy, and it fits data that lives in the database (question 4). Cost: the most work, a schema and caching, and a choice between `Cat.EFCore` and `Cat.Dapper`.
- **Only document how to write your own.** The module readme already shows this. Cost: the module stays a contract plus a no-op.

Recommendation: the `IStringLocalizer` adapter first. It is the smallest project, it reuses what developers already know, and it covers resx files too. The database provider can follow when the demo needs it.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Where does the current culture come from? Today `ICatLocalizer` has no culture parameter, so the provider must find it itself. The options:
- **The provider reads `CultureInfo.CurrentUICulture`.** The host sets it per request (ASP.NET Core request localization does this) and the contract stays as it is. Cost: it is implicit, and background work such as a message handler must set the culture by hand.
- **An `ICatCultureProvider` in `Cat.Localizations.Abstractions`.** The provider asks it, and the developer can plug in the request, the user profile or a fixed value. Cost: one more interface and a default implementation.
- **A culture parameter on every call.** Explicit. Cost: it changes the contract and clutters every call site.

Recommendation: start with `CurrentUICulture`, because it is the .NET convention and needs no new type. Add the culture provider when the demo needs the user profile, for example in the planned Notifications service, which sends texts without a request.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Category names live in the database. How do we localize data that sits in the database? The options:
- **Keys.** The database stores a key such as `category.fantasy`, and the localizer turns it into text. Cost: a new category needs a new translation entry too, which is awkward when an admin creates categories.
- **A translation per language in the database.** A translation table or a column per language. Cost: a schema change in the demo, and the localizer does not help, so it is a pattern for `Cat.EFCore` rather than for this module.
- **Not localized.** Data stays in one language, and only fixed texts (statuses, emails, messages) go through the localizer. Cost: the demo shows less.

Recommendation: keys for fixed lists, like order statuses and reference data, and no localization for free data like book titles. Category names then become reference data, which already fits `Cat.EFCore`. The owner decides, because it also affects `Cat.EFCore`.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Do the error codes from `Cat.Responses` and `Cat.Validators` get localized messages through the localizer? The owner decided in the Responses plan that localization is not the responsibility of `Cat.Responses` and that `Cat.Responses` does not change because of it, so the second option below is out. The options:
- **No.** The server returns the code and an English message, and the client picks the text from the code. Cost: every client needs its own table of messages.
- **Yes, in `Cat.Responses`.** The message is looked up by the code as the key. Cost: it couples `Cat.Responses` to this module, which the toolbox rule does not like.
- **Yes, only in the Api layer.** `Cat.Minimal.Api` translates the messages while it writes the response, and `Cat.Responses` stays as it is. Cost: the Api module gets an optional dependency on the localizer abstractions.

Recommendation: the Api layer option, once there is a real provider (question 2). Park it until then.
<!-- region end: Question 5-->

<!-- region start: Question 1-->
#### Question 1
What must be true before the Building badge goes? Here is a checklist as the exit criteria. Tell Claude what to add or remove:
- At least one real provider is built and tested (question 2).
- The culture rule is written in the module readme (question 3).
- The demo uses the module for at least one text, such as the order statuses.
- Tests exist for the placeholder logic and for the provider.

Recommendation: keep these four. The module readme then holds everything, and the plan can go.
<!-- region end: Question 1-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->