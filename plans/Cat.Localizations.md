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
A new module, `Cat.Localizations`, that gives the texts a server makes in the language of the user: fixed texts such as mails, and reference data such as category names.

#### What we want to build
- A contract to look up a localized string by key, so the rest of an app does not depend on one provider. The shape of the contract is open and follows from questions 2 and 3.
- A real provider, so the module is useful from the start. Which one comes first is open (see question 2). Each provider is a project that a developer can pick or skip.
- A way to localize reference data that an admin creates, such as categories, see questions 4 and 10.
- The demo uses the module for the mails of Notifications and for category names, in English and Dutch. See [Demo.md](Demo.md#phase-10).

#### Background
From the demo:
- The web client is a React 19 app with no translation library. The order page shows the raw status code, such as `Pending`.
- `Category.Name` and `Book.Title` in Catalog are single strings. An admin creates categories in the admin part.
- The mails of Notifications are built in code, in English, by `OrderConfirmedMailBuilder`, `StockDropMailBuilder` and `LowStockReportMailBuilder`. A mail is sent from a message handler or a scheduled job, so there is no request and no user language.
- No project in the repository uses `IStringLocalizer` or request localization yet.

From the other plans:
- The owner decided in the Responses plan that localization is not the responsibility of `Cat.Responses`, and that `Cat.Responses` does not change because of it.
- An optional part of a module plugs in through a bridge project and a narrow interface, as `Cat.EventProcessor.Inbox` and `Cat.Scheduling.Resilience` do, see [Cat.Inbox.md](Cat.Inbox.md#phase-1) and [Cat.Scheduling.md](Cat.Scheduling.md#phase-2).
- A message carries a `CorrelationId` already. The trace context of a message is carried by `Cat.Outbox`, see [Cat.Outbox.md](Cat.Outbox.md#phase-2).
- The toolkit is in alpha and the demo is the only user, so a breaking change is allowed (owner, 2026-11-21).

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- To check when building: whether `Microsoft.Extensions.Localization` has a `netstandard2.0` build.

#### Decided
- **The demo waits for this phase.** Demo phase 10 starts when this phase is built, see [Demo.md](Demo.md#phase-10).
- **Scope.** The module localizes the texts the server makes: fixed texts such as mails and messages, and reference data such as category names. The screens of a client are out of scope, because a client such as the React app uses its own translation library. A client translates a code it gets from the server, such as an order status, itself (owner, 2026-11-21).
- **Book titles are not translated.** A title belongs to one edition of a book, and an edition in another language is another book with its own ISBN (owner, 2026-11-21).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->

<!-- region start: Question 2-->
#### Question 2
Which real provider do we ship or document first? This is the blocking question, and questions 3 and 4 depend on it. Each provider is its own project, so a developer can pick it or skip it.
- **Resource files (`.resx`) through a small adapter.** Familiar to most .NET developers, works offline, and a translator can edit the files. Cost: strings are compiled in, so a change needs a deploy.
- **`IStringLocalizer` from ASP.NET Core.** One adapter project over what the framework already has, so the developer gets all its sources. Cost: it pulls in `Microsoft.Extensions.Localization`. Whether that package has a `netstandard2.0` build is still to check, see the target framework rule in `CLAUDE.md`.
- **A database provider.** Strings can change without a deploy, and it fits data that lives in the database (question 4). Cost: the most work, a schema and caching, and a choice between `Cat.EFCore` and `Cat.Dapper`.
- **Only a contract, and document how to write your own provider.** Cost: the module is a contract and nothing else, so it gives a developer little.

Recommendation: the `IStringLocalizer` adapter first. It is the smallest project, it reuses what developers already know, and it covers resx files too. The database provider can follow when the demo needs it.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Where does the current culture come from? The options:
- **The provider reads `CultureInfo.CurrentUICulture`.** The host sets it per request (ASP.NET Core request localization does this) and the contract stays as it is. Cost: it is implicit, and background work such as a message handler must set the culture by hand.
- **An `ICatCultureProvider` in `Cat.Localizations.Abstractions`.** The provider asks it, and the developer can plug in the request, the user profile or a fixed value. Cost: one more interface and a default implementation.
- **A culture parameter on every call.** Explicit. Cost: it clutters every call site.

Recommendation: start with `CurrentUICulture`, because it is the .NET convention and needs no new type. The contract then has no culture parameter. Add the culture provider when the demo needs the user profile, for example in the Notifications service, which sends texts without a request.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
How do we localize reference data that an admin creates, such as categories? Book titles are not translated, see the Decided list. The options:
- **Keys.** The database stores a key such as `category.fantasy`, and the localizer turns it into text. Cost: an admin who creates a category must also add a translation entry somewhere else, outside the database.
- **A translation table.** One table with the entity, the field, the language and the text, next to the default text in the entity. Cost: a schema change in the demo, a join or a second query on a read, and database code with its PostgreSQL counterpart and integration tests.
- **A column per language.** Cost: a schema change for every new language.

Recommendation: the translation table. The admin keeps the name and its translations in one place, a new language needs no schema change, and the default text in the entity stays the fallback.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Do the error codes from `Cat.Responses` and `Cat.Validators` get localized messages through the localizer? The owner decided in the Responses plan that localization is not the responsibility of `Cat.Responses` and that `Cat.Responses` does not change because of it, so the second option below is out. The options:
- **No.** The server returns the code and an English message, and the client picks the text from the code. Cost: every client needs its own table of messages.
- **Yes, in `Cat.Responses`.** The message is looked up by the code as the key. Cost: it couples `Cat.Responses` to this module, which the toolbox rule does not like.
- **Yes, only in the Api layer, through a bridge.** `Cat.Minimal.Api` gets a narrow interface of its own for the message of an error code, and a bridge project such as `Cat.Minimal.Api.Localizations` implements it with the localizer. `Cat.Responses` stays as it is. Cost: one more project and one interface.

Recommendation: the Api layer through a bridge, once there is a real provider (question 2). `Cat.Minimal.Api` then forces nothing on a developer. Park it until then.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Which projects does the module get, and which target frameworks? The options:
- **`Cat.Localizations.Abstractions` plus one project per provider.** The abstractions hold the contract on `netstandard2.0`. Each provider is a project, such as `Cat.Localizations.StringLocalizer`, and the data part of question 10 is its own project. Cost: a few small projects.
- **One project, `Cat.Localizations`, with the contract and the first provider.** Cost: a core that needs the contract references the provider too.

Recommendation: the abstractions plus one project per provider, so a core only references the abstractions. A provider targets `netstandard2.0` when its packages allow it, and `net10.0;net11.0` when not.
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
How does the language travel with a message? A message handler has no request, so it does not know the language of the user who started the work. For example, Notifications builds the order confirmed mail from the `OrderConfirmed` message. See also question 12 of [Demo.md](Demo.md#phase-10). The options:
- **`Cat.Messaging` carries the culture of the sender** as a message property, like the `CorrelationId`, and the listener of `Cat.EventProcessor` sets `CurrentUICulture` for the handler. Cost: a property on every message, and a change in two modules.
- **A field in the message type,** chosen per message by the developer. Cost: every message that needs it repeats the field, and the handler sets the culture by hand.
- **A stored preference per user,** looked up by the handler. Cost: a place to store it, and a lookup per message.

Recommendation: `Cat.Messaging` carries the culture as a property, and the listener sets it. It is the same pattern as the correlation id and works for every message without code. A message through the outbox keeps it, because the outbox stores the whole message.
Answer this question together with question 12 of [Demo.md](Demo.md#phase-10). If this question chooses the property on the message, it answers that question too.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
Which language does work without a request or a message use, such as a scheduled job? For example, the nightly low stock report of Notifications. The options:
- **A default culture in the settings** of the module, such as `Cat:Localizations:DefaultCulture`, also used as the fallback of question 9. Cost: one setting.
- **The culture of the host,** as .NET sets it. Cost: it depends on the container image, which is often the invariant culture.

Recommendation: a default culture in the settings. A job then always gets the same language, whatever the container runs on.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
What happens when a text has no translation in the language of the user? For example, a new key has an English text and no Dutch text yet. The options:
- **Fall back to the default language and log a warning** with the key and the language. Cost: a log line per missing text.
- **Return the key.** Cost: the user sees `mail.order.confirmed.subject`.
- **Throw.** Cost: a mail is not sent because of one missing word.

Recommendation: fall back to the default language and log a warning. The user gets a readable text, and the warning shows what is still missing, as the inbox does for a call without an id.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Where does the data part live, if question 4 chooses a translation table? The options:
- **A project in this module,** such as `Cat.Localizations.EFCore`, with the table and a helper to read an entity with its translation. Cost: the module gets database code, with a PostgreSQL counterpart and integration tests in `integrationtests/`.
- **In `Cat.EFCore`,** as a pattern for localized fields. Cost: `Cat.EFCore` grows a feature about languages, and a developer who wants localized data needs both modules anyway.
- **Only a pattern in the module readme,** and the developer builds the table. Cost: every developer writes the same table and the same query.

Recommendation: a project in this module. The localization of data and of fixed texts is then one module with one default language and one fallback. The project is plain EF Core, so PostgreSQL needs no separate code, but it gets the integration tests on both databases.
<!-- region end: Question 10-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->