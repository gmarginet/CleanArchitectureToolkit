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

# Plans for Cat.FluentWorkflows

Future work in the existing `Cat.FluentWorkflows` module: suspend and resume, and maybe parallel branches.  
Status: not started. `Cat.FluentWorkflows` itself exists. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Today a workflow runs from the first step to the last in one go, in memory. Two things are missing for longer processes.

**Suspend and resume.** A step says "stop here, continue when the answer arrives". The engine reports a suspended workflow, and a later call picks it up at the saved position. The saga work needs this. It is generic, so it also allows a pause and resume in tests.

**Parallel branches.** Some processes wait for two answers at once, such as payment and stock. The engine has no way to run branches side by side.

The suspend change must live in the engine, because a new module cannot stop the recursion of the parent containers in a way that can be resumed. The storage, correlation and messaging around it do not belong here. They are planned in [Cat.Sagas](Cat.Sagas.md).

## What we already know

From the saga plan ([Cat.Sagas.md](Cat.Sagas.md)):

- The saga plan read the engine and lists the change: a `Suspend` value in `CatStepExecutionResult`, step addresses, a checkpoint, `ResumeAsync` on `ICatWorkflowProcessor`, a resumable step body and container support for `If`, `Switch`, `While`, `Foreach` and the sub-workflow step.
- The workflow is rebuilt on every run, so a resume can rebuild the same step tree and walk to the saved position.
- A changed workflow can break the saved address. The saga plan lists mitigations such as step names and a version number.
- The engine has no parallel branches today. The saga plan asks whether they are out of scope for the first version.
- The saga plan proposes the order: the engine change first, fully tested in memory.

From the module:

- The module has the projects `Cat.FluentWorkflows.Abstractions`, `Cat.FluentWorkflows`, `Cat.FluentWorkflows.Commands` and `Cat.FluentWorkflows.Queries`.
- It has the steps `If`, `Switch`, `While`, `Foreach`, `Break`, `BreakIf`, `Log`, inline action and function steps, and a sub-workflow step.
- It traces workflows with the activity source `Cat.FluentWorkFlows`.

From the demo:

- The place order workflow in Orders uses an `if` for out of stock and a `foreach` over the order lines. See [Demo.md](Demo.md).
- A failed payment cancels the order with a new command today. A saga style payment over messages comes later.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Home of suspend and resume | The engine, `Cat.FluentWorkflows`. Storage and messaging go in a separate module. See [Cat.Sagas.md](Cat.Sagas.md). |

### Open

- **Scope of the first build.** Only suspend and resume, or also parallel branches? The saga plan leans to leaving parallel branches out.
- **Parallel branches.** If they come: a `Parallel` step with several branches, or a wait for several messages? What happens when one branch fails or suspends?
- **Breaking change.** A new value at the end of `CatStepExecutionResult` breaks nothing by itself. Does a custom container step need changes?
- **Versioning.** How do we protect stored instances when the workflow changes? Step names, a version number, or a loud failure on a mismatch?
- **Naming.** The activity source is `Cat.FluentWorkFlows`, with a capital F in `WorkFlows`, while the module is `Cat.FluentWorkflows`. Do we keep it? Renaming breaks anyone who filters on the name.

## Questions before building

1. Do suspend and resume ship before the saga module, as the saga plan proposes?
2. Are parallel branches in the first version or out?
3. How should a changed workflow behave for stored instances?
4. Do we keep the activity source name `Cat.FluentWorkFlows`?
5. Which steps and containers must support suspend in the first version?
