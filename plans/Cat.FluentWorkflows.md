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
Do suspend and resume ship before the saga module, as the saga plan proposes? See [Cat.Sagas.md](Cat.Sagas.md).
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Are parallel branches in the first version, or out? The saga plan leans to leaving them out.

##### Question 2.1
If parallel branches come, do we add a `Parallel` step with several branches, or a wait for several messages? What happens when one branch fails or suspends?
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
How should a changed workflow behave for stored instances? Do we protect them with step names, with a version number, or with a loud failure on a mismatch?
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
The activity source is `Cat.FluentWorkFlows`, with a capital F in `WorkFlows`, while the module is `Cat.FluentWorkflows`. Do we keep the name? Renaming breaks anyone who filters on it.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Which steps and containers must support suspend in the first version? A new value at the end of `CatStepExecutionResult` breaks nothing by itself. Does a custom container step need changes?
<!-- region end: Question 5-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->