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

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catscheduling)
<!-- region end: StatusBadge-->

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

#### Decided
- **Retry.** Retry of a failed run goes through `Cat.Resilience`, see [Cat.Resilience.md](Cat.Resilience.md). The module has a small retry setting per job already, see the [module readme](../modules/Cat.Scheduling/README.md#retry-a-failed-run).
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 14-->
#### Question 14
What happens to the retry setting of the module when the retry goes through `Cat.Resilience`? The options:
- **The setting goes away.** A job gets its retry from the decorator of `Cat.Resilience`. Cost: a breaking change in the settings of the module, which is fine while it is in alpha.
- **The setting stays** as a short way to switch the decorator on for a job. Cost: two ways to do one thing.

Recommendation: the setting goes away. Two retry concepts in one module is what the owner wanted to avoid, and breaking changes are not an issue yet.
<!-- region end: Question 14-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->