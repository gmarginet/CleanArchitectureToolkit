---
name: cat-internal-commit
description: Commit the current changes to Git in logical blocks, with a clear message for each block and " (skip-pub)" at the end of the subject when no code in modules/ changed. Never pushes. Use when the owner asks to commit, and never without being asked.
argument-hint: "[optional hint about how to split or what to say]"
---

# Git commit

Commit what is in the working tree as a series of small logical commits. The rules in CLAUDE.md apply: commit on the branch that is checked out, never create a branch, never push.

Run this skill only when the owner asks for a commit. Asking for the skill is the permission to commit. It is not permission to push.

## Rules
- **Logical blocks.** Several small commits, never one big one. One commit has one reason. A reader of the history should see a step, such as "Add the docs-check skill" or "Rename the Saga plan".
- **Every commit stands on its own.** Links and references in a commit must resolve in that commit. A rename goes with the fixes of its references. A new file goes before or with the file that links to it. Order the commits so that this is true.
- **Skip the publish when there is no code.** A push to `master` publishes NuGet packages. When a commit changes no code in `modules/`, the subject line ends with ` (skip-pub)`. See [Skip-pub](#skip-pub).
- **Stop after a publishing commit.** A commit without ` (skip-pub)` ends the series. Make no more commits, and ask the owner whether to push first. See [Stop after a publishing commit](#stop-after-a-publishing-commit).
- **Empty commit.** Allowed when the owner asks for one. See [Empty commit](#empty-commit).
- **Message.** One subject line in the imperative, plain words, about 72 characters or fewer before the suffix, no full stop. Start with a verb: Add, Fix, Rename, Move, Remove, Update. Match the history: `Add the Orders demo service`, `Move the demo plan to plans and add the saga plan`. Add a short body only when the reason is not obvious. Follow the style rules in CLAUDE.md.
- **Attribution.** End every message with the attribution line that the session instructions give.
- **Nothing generated or private.** Never commit `bin`, `obj`, `node_modules`, `artifacts`, `*.user` files, `desktop.ini` or scratch files. If one is tracked or shows up as new, leave it out and tell the owner.
- **No shortcuts.** Never use `--no-verify`, never skip signing, never amend, rebase or force unless the owner asks. If a hook fails, fix the cause.

## Steps
1. Start from an empty index. `git mv` stages a rename at once, and that would leak into the wrong commit. `git restore --staged .` only unstages and is safe. A rename is found again when you stage both paths of it. Then look at the whole change.
   ```
   powershell.exe -NoProfile -ExecutionPolicy Bypass -File .claude/skills/cat-internal-commit/commit-info.ps1 -Mode Status
   git diff --stat
   ```
   Read the diff of anything you do not recognize. The `Status` mode groups files by area and marks the areas with code.
2. Check the markdown first. If any markdown, heading or file name changed, run the `cat-internal-verify-docs` skill without `-Path` and fix errors. Do not commit broken links.
3. Plan the blocks. Write the list down before you stage anything. See [Splitting](#splitting).
4. For each block, in order. Stop after a block whose subject has no ` (skip-pub)`, see [Stop after a publishing commit](#stop-after-a-publishing-commit):
   1. Stage only its files with `git add -- <paths>`. A renamed file needs both the old path (the deletion) and the new path. Use `git add -A -- <paths>` for that.
   2. Check what is staged.
      ```
      powershell.exe -NoProfile -ExecutionPolicy Bypass -File .claude/skills/cat-internal-commit/commit-info.ps1 -Mode Staged
      git diff --cached --stat
      ```
      It says whether to add ` (skip-pub)`, and warns about files that must not be committed.
   3. Commit with a here-string, so the message keeps its lines.
      ```
      git commit -m @'
      Add the docs-check skill (skip-pub)

      A short body when it helps.

      <attribution line from the session instructions>
      '@
      ```
5. Finish. Run `git log --oneline -n <number of commits>` and `git status --short`. The tree should be clean, except for files you left out on purpose.
6. Report to the owner: the list of commits with their subjects, which ones have ` (skip-pub)`, and anything left uncommitted and why. Remind the owner that nothing was pushed. When the last commit has no ` (skip-pub)`, say that it publishes and ask whether to push.

## Splitting
Group by reason, not by folder. Typical blocks, in a good order:
1. **Tooling and rules.** Skills, `.claude/CLAUDE.md`. One commit per skill, or one for a set of closely related changes.
2. **Renames and moves.** The `git mv` and every reference fixed because of it.
3. **New content.** A new plan, a new module readme section, a new chapter.
4. **Changes to existing content.** A decision recorded in several plans is one block.
5. **Demo code.** One block per service or feature. The matching generated or doc updates can go with it.
6. **Module code.** One block per module and reason. The regenerated pages in `modules/*/namespaces` go with the code change that caused them.
7. **Resources.** A drawing and the text that describes it can go together.

Hints:
- Put the block with code in `modules/` last. It publishes, so it ends the series.
- The readme often holds several topics. Put the file with the block that needs it most, and order the blocks so that links resolve. When one file really holds two separate topics, stage only the hunks you want. `git add -p` is interactive and not supported here. Save `git diff -U0 -- <file>` to the scratchpad, keep only the hunks for this block, and apply it with `git apply --cached --unidiff-zero <patch file>`. Use this only when it clearly makes the history better.
- Do not split so far that a commit is meaningless. Do not merge unrelated work to save time.
- A fix for something you added in this same session belongs in the commit that added it. Fix it before you commit, not in a later commit.

## Skip-pub
A push to `master` runs `.github/workflows/build.yml`. A commit message that contains `skip-pub` makes it run the tests only, without publishing the NuGet packages.

- Add ` (skip-pub)` at the end of the subject line when the commit changes no code in `modules/`.
- Code in `modules/` is every file under `modules/` that is not markdown: C# files, project files, json and ddlinks. Generated pages and readmes (`*.md`) are not code.
- The script also counts build files as code, because they can change the packages: `Directory.Build.props`, `Directory.Build.targets`, `Directory.Packages.props`, `build.cake`, `global.json`, `dotnet-tools.json`, anything in `tools/` and the workflows in `.github/workflows`. A commit with those gets no suffix.
- Demo code (`demo/`), tests (`tests/`), plans, resources and `.claude` are not published, so a commit that only touches them gets ` (skip-pub)`.
- The rule is per commit, not per session. Decide it for each commit from what is staged.
- Never add `skip-ci`. It would also skip the tests of the build workflow.
- The build workflow reads only the newest commit of a push. Commits below it do not matter for the publish. A push whose newest commit has ` (skip-pub)` publishes nothing, even when older commits in that push changed code.

## Empty commit
The owner can ask for an empty commit, for example to make a push publish.
- Use `git commit --allow-empty`. Stage nothing, and skip the staged check, because the script has nothing to look at.
- The subject says why, in plain words, such as `Publish the alpha packages`.
- The suffix follows the reason. A commit that is meant to publish has no ` (skip-pub)`. Say in the body that it is empty on purpose.
- It is a publishing commit, so the next rule applies.

## Stop after a publishing commit
A commit without ` (skip-pub)` makes the next push publish, but only when it is the newest commit of that push. A later commit with ` (skip-pub)` on top would hide it.
1. After a commit without ` (skip-pub)`, stop. Make no more commits, even when changes are left.
2. Tell the owner that this commit publishes, and list what is still uncommitted.
3. Ask whether to push first. The owner pushes. Never push on your own.
4. Continue with the rest only after the owner says so.

## If something is wrong
- Staged the wrong file: `git restore --staged -- <path>`. This is safe.
- Committed too early: tell the owner. Do not rewrite history on your own.
- Not sure whether a change belongs: leave it out of the commit and say so in the report.
