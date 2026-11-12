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
[![READY TO START BUILDING](https://img.shields.io/badge/Status-READY%20TO%20START%20BUILDING-green)](#plans-for-catfluentworkflows)
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
`Cat.FluentWorkflows` already exists. This phase adds suspend and resume to the engine, and parallel branches. Longer processes need both.

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
- A changed workflow can break the saved address. The saga plan lists mitigations such as step names and a version number, see the decisions below.
- The engine change comes first, fully tested in memory, before any saga code.

#### Parallel branches
Some processes wait for two answers at once, such as payment and stock. The engine has no way to run branches side by side. A `Parallel` step with several branches is in this phase. What happens when one branch fails or suspends is the choice of the developer, see Decided.

#### Where it lives
The suspend change must live in the engine, because a new module cannot stop the recursion of the parent containers in a way that can be resumed. The storage, correlation and messaging around it do not belong here. They are planned in [Cat.Sagas.md](Cat.Sagas.md).

#### Decided
- The home of suspend and resume is the engine, `Cat.FluentWorkflows`. Storage and messaging go in a separate module. See [Cat.Sagas.md](Cat.Sagas.md).
- **Order.** Suspend and resume ship before the saga module. They are built and tested in memory first.
- **Changed workflows.** Both checks. A workflow has a version number, and a resume with another version fails clearly. Step names are optional. Names are checked when they exist, and the index path is checked when they do not. Side by side versions are not part of this phase.
- **Parallel branches.** A `Parallel` step with several branches is in this phase.
- **Failing or suspending branches.** The developer chooses the rule. It is a parameter on the `Parallel` step, with three rules on offer: fail fast, wait for all, and suspend until all branches are done or one fails. Fail fast is the default.
- **Running branches.** Code steps of the branches run one after another, in a fixed order. Branches that are suspended wait in parallel. The demo case, waiting for payment and stock at once, is about waiting, so there are no races on the workflow context.
- **Custom containers.** A public base class for containers gives a developer who writes a custom container the frame handling for free.
- **Activity source.** The name `Cat.FluentWorkFlows` is renamed to `Cat.FluentWorkflows` now, while the packages are alpha. The module readme and `CatWorkFlowActivitySource` change with it, and the change goes in the release notes.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->