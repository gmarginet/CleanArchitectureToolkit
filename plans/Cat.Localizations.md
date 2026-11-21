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

<!-- region start: FirstStableVersion-->
**First stable version:** not reached
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
A new module, `Cat.Localizations`, that translates the reference data an admin creates, such as category names. Fixed texts such as mails use `IStringLocalizer` from .NET, and the module adds nothing for them.

#### What we want to build
- A translation table: one row per entity, field, language and text, next to the default text in the entity.
- A helper to read an entity with the text in the language of the user, and to save its translations.
- Integration tests in `integrationtests/` on SQL Server and PostgreSQL, with the containers of `Cat.IntegrationTesting`.
- The demo uses the module for category names, and `IStringLocalizer` for the mails of Notifications, in English and Dutch. See [Demo.md](Demo.md#phase-10).

#### Background
From the demo:
- The web client is a React 19 app with no translation library. The order page shows the raw status code, such as `Pending`.
- `Category.Name` and `Book.Title` in Catalog are single strings. An admin creates categories in the admin part.
- Catalog uses EF Core through `Cat.EFCore`, on SQL Server.
- Catalog caches the category list with `Cat.Caching`. To check when building: a translated list needs the culture in its cache key.
- The mails of Notifications are built in code, in English, by `OrderConfirmedMailBuilder`, `StockDropMailBuilder` and `LowStockReportMailBuilder`. A mail is sent from a message handler or a scheduled job, so there is no request and no user language.
- No project in the repository uses `IStringLocalizer` or request localization yet.

From the other plans:
- The owner decided in the Responses plan that localization is not the responsibility of `Cat.Responses`, and that `Cat.Responses` does not change because of it.
- An optional part of a module plugs in through a bridge project and a narrow interface, as `Cat.EventProcessor.Inbox` and `Cat.Scheduling.Resilience` do, see the [module readme of Cat.Inbox](../modules/Cat.Inbox/README.md#skip-a-repeated-bus-message) and the [module readme of Cat.Scheduling](../modules/Cat.Scheduling/README.md#retry-a-failed-run).
- A message carries a `CorrelationId` already. The trace context of a message that goes through the outbox is carried by `Cat.Outbox`, see the [module readme of Cat.Outbox](../modules/Cat.Outbox/README.md#keep-the-trace-of-the-caller).
- The toolkit is in alpha and the demo is the only user, so a breaking change is allowed (owner, 2026-11-21).

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.

#### Decided
- **The demo waits for this phase.** Demo phase 10 starts when this phase is built, see [Demo.md](Demo.md#phase-10).
- **Scope.** The module localizes the texts the server makes. The screens of a client are out of scope, because a client such as the React app uses its own translation library. A client translates a code it gets from the server, such as an order status, itself (owner, 2026-11-21).
- **Book titles are not translated.** A title belongs to one edition of a book, and an edition in another language is another book with its own ISBN (owner, 2026-11-21).
- **No lookup contract of our own.** Fixed texts use `IStringLocalizer` and resx files from .NET. A Cat contract on top would only pass the calls through. The module ships no provider for fixed texts (owner, 2026-11-21).
- **The culture comes from `CultureInfo.CurrentUICulture`.** That is what `IStringLocalizer` reads. ASP.NET Core request localization sets it per request, and background work gets it from the message (owner, 2026-11-21).
- **Reference data goes in a translation table.** The admin keeps the name and its translations in one place, a new language needs no schema change, and the default text in the entity stays the fallback (owner, 2026-11-21).
- **The data part is this module.** It is not a feature of `Cat.EFCore`, and not only a pattern in the module readme (owner, 2026-11-21).
- **The culture travels as a message property.** `Cat.Messaging` carries the culture of the sender, like the `CorrelationId`, and the listener of `Cat.EventProcessor` sets `CurrentUICulture` for the handler. A developer gets it without this module, so it is planned in [Cat.Messaging.md](Cat.Messaging.md#phase-1) and not here (owner, 2026-11-21).
- **Two projects.** `Cat.Localizations.Abstractions` on `netstandard2.0` holds the base of a translation entity and the marker of a translatable entity, so a data models project such as `Catalog.DataModels` references no EF Core, as with `Cat.EFCore.Entities`. `Cat.Localizations.EFCore` on `net10.0;net11.0` holds the table mapping and the helpers to read and save the translations. It is plain EF Core, so it runs on SQL Server and PostgreSQL. Dapper projects can follow when a developer needs them (owner, 2026-11-21).
- **The default culture is plain .NET.** Work without a request or a message, such as the nightly low stock report, uses `CultureInfo.DefaultThreadCurrentUICulture` and `CultureInfo.DefaultThreadCurrentCulture`, set once in `Program.cs`. They apply to every thread with no culture of its own, so a scheduled job and a message without a culture get them too. The toolkit adds no setting, and the module readme shows the line. The demo sets `en` in Notifications (owner, 2026-11-21).
- **A missing translation gives the default text.** When an entity has no translation in the language of the user, the helper returns the default text of the entity and writes a log line on the `Debug` level with the entity, the field and the language. A missing translation is a normal state while an admin works, so it is no warning (owner, 2026-11-21).
- **Error codes are not localized on the server.** The server returns the code from `Cat.Responses` or `Cat.Validators` with its English message, and the client translates the code, as it does for an order status. No bridge in `Cat.Minimal.Api`. A bridge with `IStringLocalizer` can still be added later without a change to `Cat.Responses` (owner, 2026-11-21).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->

<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->
