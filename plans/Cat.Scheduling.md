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

# Plans for `Cat.Scheduling` <!-- omit in toc -->  

<!-- region start: FirstStableVersion-->
**First stable version:** reached
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
Retry of a failed scheduled run through `Cat.Resilience`.

#### Needs
Phase 1 of the module plan [Cat.Resilience.md](Cat.Resilience.md#phase-1), built first.

#### Decided
- **Retry.** Retry of a failed run goes through `Cat.Resilience`, see [Cat.Resilience.md](Cat.Resilience.md). Today the module has a small retry setting per job, see the [module readme](../modules/Cat.Scheduling/README.md#retry-a-failed-run).
- **A bridge with a pipeline of phase 1.** `CatJobRunner` gets one narrow interface of its own around one try, as the receiver of `Cat.EventProcessor` has for `ICatMessageAuthorizer`. A bridge project `Cat.Scheduling.Resilience` runs the whole try, with its new scope and its system user, inside the named pipeline of the job, from the pipelines for one call of [Cat.Resilience.md](Cat.Resilience.md#phase-1). It retries the same failures as the table of [Cat.Resilience.md](Cat.Resilience.md#phase-2): `InternalServerError` and an exception, never `BadRequest`, `NotFound`, `Conflict`, `Forbidden` or `Unauthorized`. `Cat.Scheduling` never references `Cat.Resilience`. The retry around the processors of phase 2 does not reach a job, because the runner uses `ICatServiceRequestProcessor` (owner, 2026-11-21).
- **The retry setting goes away.** `MaxRetries`, `RetryDelay` and `GrowingRetryDelay` and the loop of `CatJobRunner` are removed. A job gets its retry only from the bridge. A job without the bridge runs once, and its next run is its second chance. The span and the meter `Cat.Scheduling` still show a failed run. The module readme says so in "Retry a failed run". A breaking change is allowed while the toolkit is in alpha (owner, 2026-11-21).

#### Background
- `CatJobRunner` runs a job through `ICatServiceRequestProcessor`. Every try opens a new scope and sets the system user in it.
- Today every failure is tried again, also `BadRequest`, with `MaxRetries`, `RetryDelay` and `GrowingRetryDelay` per job. The tries are on the span as `cat.scheduling.attempts`.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->