# Publishing rules

## Skip-pub
A push to `master` runs `.github/workflows/build.yml`. A commit message that contains `skip-pub` makes it run the tests only, without publishing the NuGet packages.

- Add ` (skip-pub)` at the end of the subject line when the commit changes no code in `modules/`.
- Code in `modules/` is every file under `modules/` that is not markdown: C# files, project files, json and ddlinks. Generated pages and readmes (`*.md`) are not code.
- The script also counts build files as code, because they can change the packages: `Directory.Build.props`, `Directory.Build.targets`, `Directory.Packages.props`, `build.cake`, `global.json`, `dotnet-tools.json`, anything in `tools/` or `templates/` and the workflows in `.github/workflows`. A commit with those gets no suffix.
- Demo code (`demo/`), tests (`tests/`), plans, resources and `.claude` are not published, so a commit that only touches them gets ` (skip-pub)`.
- The rule is per commit, not per session. Decide it for each commit from what is staged.
- Never add `skip-ci`. It would also skip the tests of the build workflow.
- The workflow looks for the text `skip-pub` anywhere in the whole message, subject and body. A commit that must publish never contains that text at all, not even in a sentence such as "this commit has no skip-pub". The same goes for `skip-ci`.
- The build workflow reads only the newest commit of a push. Commits below it do not matter for the publish. A push whose newest commit has ` (skip-pub)` publishes nothing, even when older commits in that push changed code.

## Empty commit
The owner can ask for an empty commit, for example to make a push publish.
- Use `git commit --allow-empty`. Stage nothing, and skip the staged check, because the script has nothing to look at.
- The subject says why, in plain words, such as `Publish the alpha packages`.
- The suffix follows the reason. A commit that is meant to publish has no ` (skip-pub)`. Say in the body that it is empty on purpose, and keep the words `skip-pub` and `skip-ci` out of the body, see [Skip-pub](#skip-pub).
- It is a publishing commit, so the rule "Stop after a publishing commit" of the `SKILL.md` applies.
