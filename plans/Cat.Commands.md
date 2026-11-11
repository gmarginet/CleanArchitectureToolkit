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

# Plans for `Cat.Commands` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![READY TO START BUILDING](https://img.shields.io/badge/Status-READY%20TO%20START%20BUILDING-green)](#plans-for-catcommands)
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
`Cat.Commands` already exists. This phase settles one question: may a command carry a result? Then it changes the README and the demo to match, and adds a typed command to the module.

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
- **Typed command.** `Cat.Commands` gets a typed command, `ICatCommand<TResult>`, handled by `ICatCommandHandler<TCommand, TResult>`, which returns an `ICatResponse<TResult>`. It has the same shape as `ICatQuery<TResult>` in `Cat.Queries`.
- **Three ways in the README.** The README documents them in this order:
  1. Caller supplied IDs as the default.
  2. A query after the command, when the database hands out a value. It works well with caller supplied IDs, because the caller already knows the ID to ask for. The README says when it fits.
  3. The typed command, for the cases that need the result right away.
- **Limit for the typed command.** A rule in the README: the result holds only what the command made or decided, such as an ID, a number or a time. It is never a read model. It is the responsibility of the developer to follow it, and the developer team checks it in its own code reviews. There is no code that enforces it.
- **The demo.** The order number comes from the database, so the caller cannot supply it. The demo shows the typed command, which returns an `OrderCreated` record.
  - The demo IDs are GUIDs. The entity base creates the ID when the object is constructed, so the caller knows the order ID before the command runs.
  - `PlacedAt` is also set before the command runs, so the caller supplies it too.
  - So the command only has to return the order number. The record also holds the `OrderId`, as good practice. It does not hold `PlacedAt`.
- **Result properties.** They are not documented, and the demo stops using them.

#### What to build
The module is built in two steps.

**Step 1, the typed command in the module.** The work:
- `ICatCommand<TResult>`, `ICatCommandHandler<TCommand, TResult>` and the processor methods for it in `Cat.Commands.Abstractions`.
- The handler lookup in `CatCommandProcessor`, and the logging decorator for the typed handler.
- A `ProcessCommand` overload in `Cat.FluentWorkflows` that exposes the result of the response. Check this in the module first.
- Tests for each.

**Step 2, the README and the demo.**
- Rewrite the README chapter on results with the three ways in the order above, and the rule for the typed command.
- Change the demo: `OrderCreateCommand` becomes a typed command that returns `OrderCreated`, and the workflow step uses the result instead of copying the properties out with `Output`. Today `OrderCreateCommand` has the result properties `OrderId`, `OrderNumber` and `PlacedAt`, and those go away. `OrderCreated` holds `OrderId` and `OrderNumber`. The demo needs step 1 first.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->

<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->