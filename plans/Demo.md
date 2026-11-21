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
- [Phase 9](#phase-9)
- [Phase 10](#phase-10)
- [Phase 13](#phase-13)
<!-- region end: Phases-->

<!-- region start: Phase 9-->
## Phase 9

### Description
<!-- region start: PhaseDescription-->
#### Goal
Show `Cat.Caching`: cached catalog queries.

#### What exists today
- `Cat.Caching` does not exist yet. Its plan is [Cat.Caching.md](Cat.Caching.md).

#### Needs
Phase 1 of the module plan [Cat.Caching.md](Cat.Caching.md#phase-1), built first.

#### Done when
The demo uses the module, and the readme says where.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 15-->
#### Question 15
Which Catalog queries does the demo cache? The Catalog queries are `BookGetQuery`, `BookSearchQuery`, `CategoryGetListQuery`, `BookPriceListQuery` and `CheckIsbnExistsQuery`. None of them uses the user. `BookPriceListQuery` prices an order in Orders, and `CheckIsbnExistsQuery` refuses a duplicate ISBN, so a stale answer of those two is a real bug, see question 19 of [Cat.Caching.md](Cat.Caching.md#phase-1). The options:
- **`CategoryGetListQuery` only.** The categories hardly ever change. Cost: the effect is small, because the web client asks for the list once.
- **`CategoryGetListQuery` and `BookSearchQuery`.** The search runs on every visit to the shop. Cost: a book that an admin changes shows up late in the search.
- **Also `BookGetQuery`.** Cost: the same delay on the page of one book, and more entries.

Recommendation: `CategoryGetListQuery` and `BookSearchQuery`. They are the reads that repeat most, and the demo readme names `BookPriceListQuery` and `CheckIsbnExistsQuery` as the queries it does not cache, and why.
<!-- region end: Question 15-->

<!-- region start: Question 16-->
#### Question 16
What does the demo show after an admin saves a book that a cached search holds? It depends on question 3 of [Cat.Caching.md](Cat.Caching.md#phase-1), short lifetimes or tags. The options:
- **The old result until the lifetime ends,** with a step in the demo readme that shows the delay. Cost: the demo shows stale data on purpose.
- **`BookSaveCommandHandler` clears the tag of the search,** so the next search is fresh. Cost: it needs tags in the first version of the module.

Recommendation: follow question 3 of the module. With short lifetimes, show the delay and say why it is fine for a shop. With tags, clear the tag in `BookSaveCommandHandler`, which is the better showcase.
<!-- region end: Question 16-->

<!-- region start: Question 9-->
#### Question 9
Is there a query in the demo that we know is slow, or do we pick one to show the effect? The options:
- **Use `BookSearchQuery` or the category list** in Catalog, which reads a lot and changes little. Cost: it is not slow on a small demo database.
- **Add a delay on purpose** in a development setting, like the payment failure switches. Cost: a fake slowness, but the effect is visible.

Recommendation: a cached category or book list, with the hit and miss metric of the module as the proof in the dashboard. No fake delay is needed if the metric shows the hits.
<!-- region end: Question 9-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 9-->

<!-- region start: Phase 10-->
## Phase 10

### Description
<!-- region start: PhaseDescription-->
#### Goal
Languages. The demo works in more than one language: the client has a language selector, and the mails are translated. `Cat.Localizations` provides the texts of the server, and the client translates its own screens.

#### Background
- The owner moved this out of phase 2, the Notifications service. The client has no language support, so everything is in English, and translated mails alone would not show.
- `Cat.Localizations` localizes the texts the server makes, such as mails and category names. The screens of the client are out of its scope. Its open points are in [Cat.Localizations.md](Cat.Localizations.md#phase-1).

#### What exists today
- The client and the mails of Notifications are in English.
- The web client is a React 19 app with no translation library. The order page shows the raw status code, such as `Pending`.
- Category names are a single string in `Category.Name`. Book titles stay in one language, see the Decided list of [Cat.Localizations.md](Cat.Localizations.md#phase-1).

#### Needs
Phase 1 of the module plan [Cat.Localizations.md](Cat.Localizations.md#phase-1), answered and built.

#### Done when
A user picks a language in the client, and the order confirmed mail arrives in that language.

#### Decided
- **Scope.** The phase supports translated mails and a client where the user selects the language.
- **Languages.** Two: English as the default language and Dutch as the extra language. Two prove the mechanism, and a third adds work and nothing to learn.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 12-->
#### Question 12
How does the mail find the language of the customer? The `OrderConfirmed` message carries no language today.
- **The language in the message.** Orders puts the language of the request in `OrderConfirmed`. Cost: the message grows a field, and Orders must know the language.
- **A stored preference per user.** Notifications or another service keeps the language of each user. Cost: a place to store it. It also works for mails that no request triggers, such as the nightly jobs.
- **Always English for jobs, the request language for mails.** Cost: two rules.

Recommendation: the language in the message. The message is already the only link between the services, and it needs no new storage.
Answer this question together with question 7 of [Cat.Localizations.md](Cat.Localizations.md#phase-1). If that question chooses the property on the message, it answers this question too.
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
How does the client tell the services which language it wants?
- **The `Accept-Language` header,** sent by the client on every call and passed on by the gateway. Cost: the services must read it, and the gateway must not drop it.
- **A claim in the token.** Cost: a change needs a new login, and it ties the language to Keycloak.
- **A query parameter.** Cost: every call and every generated client method carries it.

Recommendation: the `Accept-Language` header. It is the standard way, and a service needs no extra contract.
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
Does the client remember the language choice, and where?
- **In the browser,** in local storage. Cost: the choice is lost on another device.
- **In the user profile of Keycloak.** Cost: more setup, and a call to save it.
- **Not at all.** The client starts in the language of the browser. Cost: a user picks the language again after each visit.

Recommendation: local storage, with the browser language as the first default. It is the smallest step.
<!-- region end: Question 14-->
<!-- region start: Question 17-->
#### Question 17
How does the React client translate its own screens? `Cat.Localizations` does not cover client screens. The options:
- **`react-i18next`,** with a JSON file per language in the client. Cost: one more package in the client, but it is the common choice and handles plurals and formats.
- **A small dictionary of our own,** a JSON file per language and a hook. Cost: plurals, dates and numbers by hand.

Recommendation: `react-i18next`. A developer who looks at the demo sees the usual way, and the client translates the status codes from the server with it too.
<!-- region end: Question 17-->

<!-- region start: Question 18-->
#### Question 18
Does the demo show category names in Dutch? It depends on question 4 of [Cat.Localizations.md](Cat.Localizations.md#phase-1). The options:
- **Yes.** The admin part gets a field for the Dutch name, and the shop shows the name in the language of the user. Cost: a schema change in Catalog and a change in the admin screen.
- **No, only the mails and the client screens.** Cost: the data part of the module is not shown.

Recommendation: yes, if the module gets a data part. Categories are the one piece of reference data in the demo, so they are the only place to show it.
<!-- region end: Question 18-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 10-->

<!-- region start: Phase 13-->
## Phase 13

### Description
<!-- region start: PhaseDescription-->
#### Goal
The PostgreSQL showcase. The Notifications service moves from SQL Server to PostgreSQL, and shows that the modules work on another database.

#### Background
- A showcase on PostgreSQL needs the Npgsql EF Core provider. The demo is on EF Core 11. The provider has no stable release for EF Core 11 yet. The latest is `11.0.0-rc.3`, pinned to a release candidate of EF Core 11. The facts were read on 2026-11-19 from nuget.org through a web search, and nobody has tested them against this code. Check the NuGet page before pinning a version.
- The Aspire client package for PostgreSQL, `Aspire.Npgsql.EntityFrameworkCore.PostgreSQL`, depends on Npgsql 10.0.3 or higher. Nobody has tested it with Npgsql 11.
- The demo stays on `net11.0` and EF Core 11, while the modules support .NET 10 and EF Core 10 as well, see the target framework rule in `CLAUDE.md`. The PostgreSQL project of the modules is built and proved on EF Core 10 and EF Core 11.
- `Cat.Db.Errors` has checks for SQL Server and MySQL, see the [module readme of Cat.Db.Errors](../modules/Cat.Db.Errors/README.md). The PostgreSQL checks are built in `Cat.Db.Errors.PostgreSQL`, see the same readme. Notifications needs them when a handler maps a database error, to check when building.
- The module work that is left is in [Cat.EFCore.md](Cat.EFCore.md), for a provider neutral `Cat.EFCore.Extensions`.
- Temporal tables and `Cat.Sql.Cdc` are SQL Server only. The PostgreSQL service must not use them.

#### What exists today
- Every service runs on SQL Server, and the AppHost starts it with `AddSqlServer`.
- The outbox, the inbox and the scheduler claim store are plain EF Core code. The integration tests of [Cat.IntegrationTesting](../modules/Cat.IntegrationTesting/README.md) run them on a real PostgreSQL 17 and pass.

#### Needs
- A stable Npgsql EF Core provider for EF Core 11, with an Aspire PostgreSQL package that accepts it.

#### Done when
Notifications runs on a PostgreSQL container that the AppHost starts. The outbox, the inbox and the scheduler claim store work there, and the readme says where the demo uses PostgreSQL.

#### Decided
- **Database.** PostgreSQL is the second database of the showcase, and not MySQL (owner, 2026-11-20).
- **Provider.** The demo waits for a stable Npgsql provider for EF Core 11, so the Aspire integration stays. A release candidate is not used (owner, 2026-11-20).
- **Which service.** Notifications moves to PostgreSQL after it is built on SQL Server.
- **Entities.** Notifications uses the CAT base entities and `ConfigureCatEntity`, with no temporal tables and no raw SQL Server code. The move waits for the neutral `Cat.EFCore.Extensions` of [Cat.EFCore.md](Cat.EFCore.md), and that change must keep these calls source compatible.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 13-->
