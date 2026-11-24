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
<!-- no overview row-->
<!-- region end: TemplateSkill-->

# Plans for `Cat.Release` <!-- omit in toc -->  

<!-- region start: FirstStableVersion-->
**First stable version:** not reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 1](#phase-1)
- [Phase 2](#phase-2)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
Publish to nuget.org only for a tag. A push to `master` publishes nothing.

#### Why
- Every push to `master` publishes an alpha build, so thousands of alpha versions piled up on nuget.org.
- nuget.org allows about 270 unlist calls per run, so the cleanup of that backlog takes many manual runs (see `.github/RELEASING.md`).
- With a tag for every release, the number of pre-release versions stays small.

#### Decided
- The owner chose to build and publish only on tags. This plan covers the whole repository, so it has no row in the repo overview. The owner decided this.
- An alpha release is a tag too, such as `v1.1.0-alpha.1`. The tag filter `v*` in `.github/workflows/build.yml` already accepts it.
- Without a tag, MinVer still gives a build an alpha version. The owner sees no problem in that, because nothing is published for it. The workflow looks for a tag to decide whether to publish.
- A push to `master` still runs the tests, with no publish.
- The change waits until the backlog of old alpha and in-between rc versions on nuget.org is unlisted. The dry run of `.github/scripts/Unlist-OldPrereleases.ps1` must list nothing first.

#### What changes
- `build.yml`: the `release` job runs the `Test` target for a push to `master` and for a pull request, and the `Publish` target only when the ref is a `v` tag. The `NuGet login` step follows the same condition.
- `.github/RELEASING.md` describes the new rule.
- The `skip-pub` word in commit messages no longer has an effect on publishing. The `cat-internal-commit` skill and `CLAUDE.md` mention it, so both change in the same step. Check what else mentions it with `git grep`.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
Make the unlist script simpler, and add a way to unlist everything below a version by hand.

#### Needs
- [Phase 1](#phase-1): with tags only, there are no in-between builds anymore, so the script no longer needs to recognize them.

#### Decided
- The owner chose one rule for a tag run: unlist every pre-release version of a lower stage than the tag. The stages go alpha, rc, stable.
  - An alpha tag unlists nothing.
  - An rc tag unlists the alphas.
  - A stable tag unlists the alphas and the rcs.
  - A version only goes when its version number is lower than the tag version too. A tag of an older line never touches a newer one.
- Stable versions are never unlisted by the script.
- The script keeps its name `Unlist-OldPrereleases.ps1`, and it stays in the workflow. The owner wants to keep the script.
- A manual way to unlist everything below a certain version stays, next to the automatic rule. The automatic rule is the habit, and the manual way is for the backlog and for mistakes.
- The change waits until the backlog is unlisted, because the new script no longer recognizes the in-between rc builds such as `1.0.0-rc.1.6`.

#### What changes
- `Unlist-OldPrereleases.ps1`: the patterns for in-between builds go, and so do `-IncludeTaggedRc` and `-Keep`. A `-Below` parameter takes a version.
- `build.yml`: the manual run asks for a version and has a dry run box, instead of the `after` choice. With the box checked it only lists what would go. The tag run passes the tag.
- `.github/RELEASING.md` describes the rule and the manual way.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->
