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

# Plans for `Demo` <!-- omit in toc -->  

<!-- region start: FirstStableVersion-->
**First stable version:** reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 10](#phase-10)
<!-- region end: Phases-->

<!-- region start: Phase 10-->
## Phase 10

### Description
<!-- region start: PhaseDescription-->
#### Goal
Languages. The demo works in more than one language: the client has a language selector, and the mails are translated. The services use `IStringLocalizer` for fixed texts and `Cat.Localizations` for category names, and the client translates its own screens.

#### Background
- The owner moved this out of phase 2, the Notifications service. The client has no language support, so everything is in English, and translated mails alone would not show.
- `Cat.Localizations` translates reference data such as category names. Fixed texts such as mails use `IStringLocalizer` from .NET. The screens of the client are out of its scope. Its open points are in [Cat.Localizations.md](Cat.Localizations.md#phase-1).

#### What exists today
- The client and the mails of Notifications are in English.
- The web client is a React 19 app with no translation library. The order page shows the raw status code, such as `Pending`.
- Category names are a single string in `Category.Name`. Book titles stay in one language, see the Decided list of [Cat.Localizations.md](Cat.Localizations.md#phase-1).

#### Needs
- Phase 1 of the module plan [Cat.Localizations.md](Cat.Localizations.md#phase-1), answered and built.
- Phase 1 of the module plan [Cat.Messaging.md](Cat.Messaging.md#phase-1), for the culture on a message, answered and built.

#### Done when
A user picks a language in the client, and the order confirmed mail arrives in that language.

#### Decided
- **Scope.** The phase supports translated mails and a client where the user selects the language.
- **Languages.** Two: English as the default language and Dutch as the extra language. Two prove the mechanism, and a third adds work and nothing to learn.
- **The mail finds the language in the message.** `Cat.Messaging` carries the culture of the sender as a message property, and the listener sets it for the handler, so `OrderConfirmed` gets no field of its own. See [Cat.Messaging.md](Cat.Messaging.md#phase-1) (owner, 2026-11-21).
- **The client sends the language in `Accept-Language`.** The middleware in `src/api/client.ts` that sets `Authorization` also sets `Accept-Language` to the language the user picked. The gateway runs on YARP, which passes the header on as it is. Each service calls `UseRequestLocalization` with `en` and `nl`. Before the user picks a language, the language of the browser applies (owner, 2026-11-21).
- **The client keeps the choice in local storage.** The first default is the language of the browser. The choice does not follow the user to another device, which is fine for the demo (owner, 2026-11-21).
- **The client translates with `react-i18next`.** One JSON file per language, such as `locales/en.json` and `locales/nl.json`, holds the texts of the screens and the codes from the server, such as the order status and the error codes. A missing key falls back to English. Numbers and dates are formatted with `Intl` through i18next (owner, 2026-11-21).
- **Category names are shown in Dutch.** Catalog gets the translation table of `Cat.Localizations`, with `Cat.Localizations.Abstractions` in `DataModels` and `Cat.Localizations.EFCore` in `Infrastructure`. The category list query reads the name in the language of the request, and the cached list has the culture in its key. The admin screen gets a field for the Dutch name. A category without a Dutch name shows its English name. Categories are the only reference data in the demo, so they are the only place to show the module (owner, 2026-11-21).
- **A mail is one resx entry for the subject and one for the body.** The builders of Notifications read them with `IStringLocalizer` and fill the placeholders, such as `localizer["OrderConfirmed.Body", name, number, total]`. Each entry has a resx comment that says what `{0}`, `{1}` and so on hold. The low stock report has one more entry for a single line of its list. The total is formatted with the current culture, such as `{2:N2}`, so a Dutch mail shows `EUR 12,50`. A missing Dutch entry falls back to the English resx (owner, 2026-11-21).
- **Admin mails use `AdminCulture` from the settings.** It sits next to `AdminEmail` in the settings of Notifications. A handler that mails the admin, such as the stock drop mail and the nightly low stock report, sets `CurrentUICulture` and `CurrentCulture` to it before it builds the mail. Without it, a `StockChanged` message from the order of a Dutch customer would give the admin a Dutch mail. The culture set inside an async handler does not leak back to the listener (owner, 2026-11-21).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->

<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 10-->
