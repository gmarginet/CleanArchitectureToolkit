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
