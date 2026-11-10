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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-plan skill to update this plan.-->
<!-- region end: TemplateSkill-->

# Plans for `Cat.Commands` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catcommands)
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
`Cat.Commands` already exists. This phase settles one question: may a command carry a result? Then it changes the README and the demo to match, and adds a typed command to the module if the owner wants it.

#### The problem
The module README says a command changes state and returns no data, only the outcome. Use a query to read data.

A real use case pushes against that. When a command creates an order, the caller wants the new order ID, the order number and the time. The demo solves it by putting result properties on the command, which the handler fills in after it runs. That works, but the module does not say it is allowed. We need to decide whether this is a supported pattern, a thing to avoid, or a reason for a change in the module.

#### What exists today
- The README says a command changes state and returns no data, only the outcome. Use `Cat.Queries` to read data.
- A command returns an `ICatResponse`. A failed response is the normal way to say something went wrong.
- The module has one handler shape, `ICatCommandHandler<TCommand>`, in the processor, the abstractions and the logging decorator.
- `Cat.Queries` already has the typed shape, `ICatQuery<TResult>`, so it is the pattern to copy.
- In the demo, `OrderCreateCommand` has the properties `OrderId`, `OrderNumber` and `PlacedAt`, marked "the result. Set by the handler."
  - It is a class with a parameterless constructor, because a workflow step creates it and fills it.
  - The place order workflow needs the order number after the command ran.

#### Decided
- **Current rule.** The README says a command returns no data. Nothing newer is decided.
- **Result properties.** The owner does not want result properties on the command. A developer cannot see what to fill in to run the command.
- **Caller supplied IDs.** This is the preferred way to get an ID. The toolkit still gives developers other options, because not every developer will agree.
- **README.** The README describes the chosen pattern, and the demo says the same.

#### Recommendation for the module
This is a recommendation, not a decision. Support three ways and write them in the README in this order:
1. Caller supplied IDs as the default.
2. A query after the command, when the database hands out a value.
3. The typed command, for the cases that need the result right away, with the rule that it holds only what the command made.

Result properties on the command are not documented, and the demo stops using them. The cost is that the typed command is a real change in the module, see step 2 below.

#### What to build
The module can be built in two steps. Only the typed command needs a decision first.

**Step 1, no module change.** It needs no answer to the open points.
- Rewrite the README chapter on results: caller supplied IDs first, then the query after the command.
- Change the demo: `PlaceOrderState` creates the `OrderId`, `OrderCreateCommand` carries it in, and a query step reads the order number. Today `OrderCreateCommand` has the result properties `OrderId`, `OrderNumber` and `PlacedAt`, and the workflow step copies them out with `Output`. Those go away.
- A query by order ID is new in the Orders core service. Check that the workflow step for a query, `ProcessQuery`, can read it with `Output`, as the `Cat.FluentWorkflows` README says.

**Step 2, the typed command, only when the owner wants it.** The work:
- `ICatCommand<TResult>`, `ICatCommandHandler<TCommand, TResult>` and the processor methods for it in `Cat.Commands.Abstractions`.
- The handler lookup in `CatCommandProcessor`, and the logging decorator for the typed handler.
- A `ProcessCommand` overload in `Cat.FluentWorkflows` that exposes the result of the response. Check this in the module first.
- Tests for each, and the README chapter.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Does `Cat.Commands` get a typed command, or only caller supplied IDs and a query after the command?

A typed command is `ICatCommand<TResult>`, handled by `ICatCommandHandler<TCommand, TResult>`, which returns an `ICatResponse<TResult>`. The owner finds it the cleanest way to stay flexible, but it lets commands read data, which the owner does not like. The risk is a convention problem, not a technical one, since a handler could always read data.

Without a typed command, the toolkit supports caller supplied IDs and a query after the command, and nothing else.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
If `Cat.Commands` gets a typed command, which limit do we use to keep it from becoming a read model?
- **A rule in the README.** The result holds only what the command made or decided: an ID, a number, a time. It is never a read model. Cost: nothing in code, and nobody checks it.
- **A narrow result type.** The README suggests a small record per command, such as `OrderCreated(OrderId, OrderNumber, PlacedAt)`. It reads like the answer of a write. Cost: one more type per command.
- Or both.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Do we document a query after the command as a supported way? The caller sends the command, then a query for the data. It works well together with caller supplied IDs, because the caller already knows the ID to ask for. Cost: a second round trip. There is no answer yet.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Which way does the demo show for the order number? The order number comes from the database, so the caller cannot supply it. The demo has two ways:
1. The workflow creates the `OrderId`, sends the command, and a query step reads the number by that ID. It shows the preferred way.
2. A typed command returns the `OrderCreated` record. It shows the typed command.

Recommendation: 1, because it is the owner's preferred way and it needs no change in the module.
<!-- region end: Question 4-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->