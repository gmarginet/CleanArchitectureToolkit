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
- [Phase 3](#phase-3)
<!-- region end: Phases-->

<!-- region start: Phase 3-->
## Phase 3

### Description
<!-- region start: PhaseDescription-->
Work on a `development` branch, so the code on `master` is always the code of the last release. Until the first stable version, that is the last release candidate.

#### Decided
- The owner wants to start using the `development` branch after the tag `v1.0.0-rc.2`, not after the first stable version.
- The owner creates the branch. Claude never creates a branch on its own.
- A release goes through a pull request from `development` to `master`. The owner tags `master` after the merge.
- An urgent fix starts on a `bugfix` branch from `master`, because `development` holds unfinished work.
  - A pull request merges the fix into `master`, and the owner tags the patch release.
  - A second pull request merges `master` back into `development`, so the tags and the fix are on both lines.
- The release pull request is merged with a merge commit, not a squash. The release notes are built from `git log --no-merges`, so they need the single commits.
- A push to `development` runs the tests and publishes nothing, as a push to `master` does.
- The GitHub Pages site is built from `master`, so it matches what developers can install.
- Feature work on `development` stays as direct commits, with no pull request for every change.
- Direct pushes to `master` are blocked with a GitHub ruleset. `master` only changes through a pull request with a green build, and the owner is the one exception who can bypass it in an emergency. The ruleset is set on GitHub, not by a workflow. It is set when the `development` branch starts, after `v1.0.0-rc.2`, so a fix before the first stable version also needs a pull request. A tag is a different ref, so the release tag is not blocked.
- An alpha or rc tag may sit on `development`, such as `v1.2.0-rc.1`. It publishes a pre-release to nuget.org and leaves `master` alone.
- A stable tag may only sit on `master`. The `release` job of `build.yml` gets a step that checks that the tagged commit is part of `master`, for example with `git merge-base --is-ancestor` against `origin/master`, and fails for a stable tag that is not. A ruleset cannot limit a tag to a branch, so the workflow does it. The check can only fail after the tag is pushed. A wrong stable tag is deleted and set again.

#### To check
- Whether the repository can use a ruleset with required checks, and the name of the check that the ruleset requires.
- Whether the trusted publishing policy on nuget.org accepts a tag on `development`, or is bound to `master`.

#### Facts to keep in mind
- `build.yml` and `pages.yml` trigger on a push to `master` only. `build.yml` also runs on a pull request to `master`. It needs `development` as a target too, so the tests run before a release pull request is merged.
- Whether the trusted publishing policy on nuget.org is bound to a branch or a ref is not checked. It is bound to the workflow file `build.yml`, which is an assumption.
- MinVer needs the tags to be reachable from the branch it builds, so `development` must contain the merges back from `master`.
- `CLAUDE.md` says to commit to the branch that is checked out, and that releases are automatic after a push to `master`. Both change with this phase, and `.github/RELEASING.md` too.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 3-->
