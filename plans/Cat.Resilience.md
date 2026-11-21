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

# Plans for `Cat.Resilience` <!-- omit in toc -->  

<!-- region start: FirstStableVersion-->
**First stable version:** not reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 2](#phase-2)
<!-- region end: Phases-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
A retry and circuit breaker around a whole command or query, for a developer who wants it on a whole handler.

#### Background
- `AddDecorator` of `Cat.Decorators` wraps every closed type of an open generic service type, so a decorator wraps every handler. A decorator runs inside the scope of the handler. See the [module readme of Cat.Decorators](../modules/Cat.Decorators/README.md).
- A handler that wrote to the database and failed leaves its tracked entities in the `DbContext` of its scope. A retry in the same scope runs on that context.
- `CatCommandProcessor` and `CatQueryProcessor` open a new scope for every call. `ICatCurrentScopeCommandProcessor` runs in the current scope on purpose, see the [module readme of Cat.EventProcessor](../modules/Cat.EventProcessor/README.md).
- A failed message handler is delivered again by the bus, so a retry inside a message handler multiplies with the deliveries of the bus.

#### Decided
- **Later, not in the first version.** The phase is built only when a real case needs it (owner, 2026-11-21).
- **Opt in per type.** The retry only acts for the request types a developer lists, such as `options.Retry<GetPriceQuery>()`. Nothing is retried by default, also no query. Every other handler is called once. It is the same pattern as `UseInbox` of `Cat.EventProcessor` (owner, 2026-11-21).
- **A fresh scope for every try.** A retry never runs on the scope of the try that failed (owner, 2026-11-21).
- **Around the processors.** The retry wraps `ICatCommandProcessor` and `ICatQueryProcessor` in the container. For a listed type, every try calls the inner processor again, which opens a new scope. Every other type passes straight through. It is not a decorator of `Cat.Decorators`, and `Cat.Decorators` stays unchanged. `ICatCurrentScopeCommandProcessor` gets no retry, and the module readme says why (owner, 2026-11-21).
- **Which failures count.** The same table as the event processor, see "What happens to a message" in the [module readme of Cat.EventProcessor](../modules/Cat.EventProcessor/README.md). `InternalServerError` and an exception are tried again. `BadRequest`, `NotFound`, `Conflict`, `Forbidden` and `Unauthorized` come back at once. An override per type changes the table, like `FailureOverrides` of the event processor (owner, 2026-11-21).
- **Retry on retry.** The module readme states one layer per call: the client profile for HTTP, the retry around the processor for a whole handler with no HTTP retry inside. It shows the example of a retried command whose client also retries, and the multiplication by the deliveries of the bus. The module does not detect it and adds no marker (owner, 2026-11-21).
- **Registration order.** The retry replaces the single scoped registration of `ICatCommandProcessor` and of `ICatQueryProcessor` with a wrapper that builds the original processor as its inner one. `Cat.Decorators` is not used, because it only wraps open generic types. The setup throws an `InvalidOperationException` at once when a listed command type has no command processor registered yet, or a listed query type no query processor. The check runs per kind, so a developer who lists only queries needs only `Cat.Queries`. The message names the call that is missing. A unit test with `FakeCommandProcessor` or `FakeQueryProcessor` gets no retry, and the module readme says so (owner, 2026-11-21).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
The owner decided that this phase is built only when a real case needs a retry around a whole handler. Is there such a case now?
- Yes: name the case, and the phase is built.
- No: the phase stays here until a case shows up.

Recommendation: No. Nothing in the demo or the modules needs it today, and a retry around a whole handler multiplies with the retries of the client and the bus.
<!-- region end: Question 1-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->
