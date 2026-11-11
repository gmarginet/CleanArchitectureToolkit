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

# Plans for `Cat.FluentWorkflows` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catfluentworkflows)
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
`Cat.FluentWorkflows` already exists. This phase adds suspend and resume to the engine, and maybe parallel branches. Longer processes need both.

#### What exists today
- The module has the projects `Cat.FluentWorkflows.Abstractions`, `Cat.FluentWorkflows`, `Cat.FluentWorkflows.Commands` and `Cat.FluentWorkflows.Queries`.
- It has the steps `If`, `Switch`, `While`, `Foreach`, `Break`, `BreakIf`, `Log`, inline action and function steps, and a sub-workflow step.
- A workflow runs from the first step to the last in one go, in memory.
- It traces workflows with the activity source `Cat.FluentWorkFlows`.
- The engine has no way to suspend a workflow and no parallel branches.
- The place order workflow in the Orders service of the demo uses an `if` for out of stock and a `foreach` over the order lines. See [Demo.md](Demo.md). A failed payment cancels the order with a new command today. A saga style payment over messages comes later.

#### Suspend and resume
A step says "stop here, continue when the answer arrives". The engine reports a suspended workflow, and a later call picks it up at the saved position.
- The saga work needs this. It is generic, so it also allows a pause and resume in tests.
- The change, as the saga plan lists it after reading the engine:
  - a `Suspend` value in `CatStepExecutionResult`,
  - step addresses and a checkpoint,
  - `ResumeAsync` on `ICatWorkflowProcessor`,
  - a resumable step body,
  - container support for `If`, `Switch`, `While`, `Foreach` and the sub-workflow step.
- The workflow is rebuilt on every run, so a resume can rebuild the same step tree and walk to the saved position.
- A changed workflow can break the saved address. The saga plan lists mitigations such as step names and a version number. See question 3.
- The saga plan proposes the order: the engine change first, fully tested in memory.

#### Parallel branches
Some processes wait for two answers at once, such as payment and stock. The engine has no way to run branches side by side. The saga plan asks whether they are out of scope for the first version. See question 2.

#### Where it lives
The suspend change must live in the engine, because a new module cannot stop the recursion of the parent containers in a way that can be resumed. The storage, correlation and messaging around it do not belong here. They are planned in [Cat.Sagas.md](Cat.Sagas.md).

#### Decided
- The home of suspend and resume is the engine, `Cat.FluentWorkflows`. Storage and messaging go in a separate module. See [Cat.Sagas.md](Cat.Sagas.md).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Do suspend and resume ship before the saga module, as the saga plan proposes? This is the blocking question, and it is the same as question 3 in [Cat.Sagas.md](Cat.Sagas.md). Answer it once, here. The engine change touches every container step (`If`, `Switch`, `While`, `Foreach` and the sub-workflow step), so it needs careful tests. The options:
- **Yes, first.** The engine change is built and tested in memory, before any saga code. It has value by itself, because it allows a pause and resume in tests. Cost: work with no visible use in the demo until the saga module arrives.
- **Together with the saga module.** One piece of work, so the design is proven by a real use. Cost: a bigger change, and a bug in the engine and a bug in the module are harder to tell apart.
- **Not at all.** Sagas then follow option A of the saga plan, short workflows and a status on an entity. Cost: no one recipe from top to bottom, and no open `If` or `Foreach` frames across a wait.

Recommendation: yes, first. It needs no other future module, and the in-memory tests prove it before storage and messaging add their own problems.
<!-- region end: Question 1-->

<!-- region start: Question 3-->
#### Question 3
How should a changed workflow behave for stored instances? It is the same point as questions 4 and 5 in [Cat.Sagas.md](Cat.Sagas.md). The engine owns the step addresses, so answer it here and the saga plan follows. The options:
- **A loud failure on a mismatch.** Every step has an address and a name. On resume the engine checks that the name at the address is the one in the checkpoint, and fails when it is not. Cost: a developer who changes a workflow must finish or drop the old instances first.
- **A version number on the workflow.** The instance remembers the version, and a resume with another version fails clearly. Cost: the developer must raise the number by hand, and forgetting it hides the problem.
- **Both.** The version gives a clear message, and the name check catches a forgotten version. Cost: a little more code and one more concept.
- **Run old and new side by side.** Cost: the developer keeps the old workflow code in the project. This is a big step and no one asked for it.

Recommendation: both, but with explicit step names optional. Names are checked when they exist, and the index path is checked when they do not. Failing clearly is cheap, and side by side versions can wait until a real need shows up.
<!-- region end: Question 3-->

<!-- region start: Question 2-->
#### Question 2
Are parallel branches in the first version, or out? The saga plan leans to leaving them out, see question 7 in [Cat.Sagas.md](Cat.Sagas.md). Answer it once, here. The options:
- **Out of the first version.** The engine only suspends in a straight line. Cost: a process that waits for payment and stock at once must wait for them one after another.
- **In, as a `Parallel` step with several branches.** Reads well in code. Cost: the checkpoint needs a frame per branch, and the rules for one branch failing or suspending while another runs (question 2.1).
- **In, as a wait for several messages.** One suspend, several answers, no parallel code. Cost: a new kind of wait step with its own rules, such as "all" or "any".

Recommendation: out of the first version. Suspend and resume already change every container. Parallel branches double the checkpoint work, and the demo does not need them yet.

##### Question 2.1
Only when parallel branches are in: what happens when one branch fails or suspends while another still runs?
- **Fail fast.** The first failure stops the others and fails the workflow. Cost: running branches are cancelled halfway.
- **Wait for all.** Every branch finishes, then the workflow reports all failures. Cost: slower to fail.
- **Suspend until all branches are done or one fails.** Cost: the most bookkeeping in the checkpoint.

Recommendation: fail fast, because it is the easiest rule to explain. Decide this only if question 2 is yes.
<!-- region end: Question 2-->

<!-- region start: Question 5-->
#### Question 5
Which steps and containers must support suspend in the first version? The description already names `If`, `Switch`, `While`, `Foreach` and the sub-workflow step. A new value at the end of `CatStepExecutionResult` breaks nothing by itself. What is left to decide is the custom container steps of a developer, because those would silently drop a suspend. The options:
- **Only the built-in containers.** A custom container that gets a suspended child fails clearly, with a message that says it does not support suspend. Cost: a developer cannot write a custom container that suspends.
- **A public base class for containers.** A developer who inherits from it gets the frame handling for free. Cost: a new public type to design and keep stable.
- **Treat `Suspend` like `BreakCascade` for every container.** The container passes the result up and loses its own frame. Cost: a resume ends up in the wrong place, which is a silent bug.

Recommendation: only the built-in containers, with a clear failure for any other. It keeps the first version small, and the base class can follow when a developer asks.
<!-- region end: Question 5-->

<!-- region start: Question 4-->
#### Question 4
The activity source is `Cat.FluentWorkFlows`, with a capital F in `WorkFlows`, while the module is `Cat.FluentWorkflows`. Do we keep the name? It is in `CatWorkFlowActivitySource` and in the module readme. Renaming breaks anyone who filters on it. The module is still on alpha packages, so the damage is small today and grows with every user. The options:
- **Rename it to `Cat.FluentWorkflows` now.** Cost: a breaking change for anyone with an OpenTelemetry filter, a line in the release notes, and a change in the readme.
- **Keep it and write it in the readme as it is.** Cost: a permanent odd spelling.
- **Add the new name and keep the old one for a while.** Cost: two sources to maintain, and a duplicate trace unless one is switched off.

Recommendation: rename now, while the packages are alpha. The mistake only gets more expensive later.
<!-- region end: Question 4-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->