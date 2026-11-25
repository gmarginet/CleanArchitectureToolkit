# Releasing the toolkit

This page is for the owner. It is not part of the published site.

One tag makes one release. All modules share the version of the tag.

## What a tag does

Push a tag that starts with `v`, such as `v1.0.0-rc.1`. The build workflow `.github/workflows/build.yml` then runs these jobs in order:

1. **Integration tests.** Needs Docker, which the runner has.
2. **Release.** Runs the tests, packs and publishes every package to nuget.org. MinVer reads the tag, so the package version is the tag without the `v`.
3. **Unlist old versions.** Unlists the pre-release versions on nuget.org that a tag has replaced, see [Unlisting old versions](#unlisting-old-versions). Runs next to the GitHub release, so a failure here never blocks it.
4. **GitHub release.** Creates the release on the homepage with `gh release create`.

## Rules for a tag

- **Format:** `v` plus a semantic version, such as `v1.0.0-rc.1` or `v1.0.0`.
- **Pre-release:** a version with a dash is marked pre-release on GitHub, so it never shows as the latest release.
- **`skip-ci`:** the workflow ignores this word in the message of the tagged commit. A tag always tests and publishes.
- **Pull requests:** they only run the tests.
- **Normal pushes to `master`:** they run the tests and publish nothing. Only a tag publishes packages and creates a GitHub release. A pre-release tag, such as `v1.1.0-alpha.1`, is how you publish an alpha.

## What the release contains

- **Title:** the tag.
- **Intro:** `.github/release-intro.md`. `{version}` is replaced by the version. Change the file to change the text.
- **Changes:** the commit subjects since the previous `v` tag, without the `(skip-pub)` ending that older commits have. The first tag has no previous tag, so it has no list. GitHub's generated notes list only pull requests, and the owner commits to `master` directly, so the workflow builds the list from commits.
- **Full changelog:** a link to the comparison with the previous tag.
- **Assets:** only the two source archives that GitHub adds to every release. The packages stay on nuget.org.

## Unlisting old versions

nuget.org only unlists. A package stays available for an exact version reference.

- **The rule:** a pre-release version goes when a tag has a higher stage and a higher version. The stages go alpha, rc, stable.
  - **An alpha tag, such as `v1.1.0-alpha.1`:** unlists nothing.
  - **An rc tag, such as `v1.1.0-rc.1`:** unlists the alphas that are lower than the tag.
  - **A stable tag, such as `v1.1.0`:** unlists the alphas and the rcs that are lower than the tag.
  - **A newer line stays:** `1.2.0-alpha.1` is not touched by `v1.1.0`, because its version is higher.
  - **Stable versions** are never unlisted by the rule.
- **Every tag counts:** a tag run applies the rule for every `v` tag, not only its own. A run that stopped at the quota, or a later tag of a lower stage, never leaves old work behind. Example: `v1.1.0` has a backlog, `1.1.1-alpha.1` exists, and `v1.1.1-rc.1` is tagged. The run unlists `1.1.1-alpha.1`, the `1.1.0` alphas and the `1.1.0` rcs.
- **Script:** `.github/scripts/Unlist-OldPrereleases.ps1`. It finds the packages with the search API (owner and the id prefix `gmarginet.Cat.`) and reads the `listed` flag from the registration data. `-Tag` takes the tag versions for the rule, `-Version` takes one version to unlist in every package that has it.
- **Key:** the job logs in with `NuGet/login`, like the release job. The trusted publishing policy on nuget.org has the scope All, which includes unlist. No extra secret.
- **Time limit:** the temporary key lasts one hour, so the script stops after 50 minutes. The script only looks at versions that are still listed, so each run continues where the last one stopped.
- **Quota:** nuget.org allows about 250 unlist calls per hour. The script waits one second after every call (`-DelayMilliseconds`) and stops without a failure at the first quota error. A run that starts less than an hour after a big one finds the quota mostly used up and does only a few. Wait an hour or more between manual runs.
- **Warning at the quota:** a stop at the quota, or at the time limit, shows as a yellow warning on the run page, with how many versions are left. The run stays green. The run page also has a short summary with the numbers unlisted, failed and left.
- **Dry run:** `.\.github\scripts\Unlist-OldPrereleases.ps1 -Owner gmarginet -Tag 1.1.0 -DryRun` shows what the rule would unlist, needs no key and also prints every listed version once, with the number of packages that have it.
- **A run from your own machine:** set `NUGET_API_KEY` to a key with the unlist scope and run the script without `-DryRun`.
- **Normal pushes to `master`:** no unlisting, and no publishing.

## Cut a release

1. Check that the last run of the build workflow on `master` is green.
2. Create the tag on the commit to release: `git tag v1.0.0-rc.1`.
3. Push the tag: `git push origin v1.0.0-rc.1`. Pushing is the owner's step.
4. Watch the workflow. After the third job the release is on the homepage.

## Unlist by hand

Use this to work off a backlog that one run could not finish, or to unlist one version. A manual run runs no tests and publishes nothing.

1. Open the Actions tab of the repository, pick the workflow "Publish CAT nuget packages" and choose **Run workflow** on `master`. Do not pick "Publish CAT GitHub Pages". It also has a **Run workflow** button, but it only publishes the site again and has no dropdown.
2. Choose the `mode`:
   - **`cleanup`:** the rule of a tag run. Leave `version` empty to apply it for every `v` tag. Type a version, such as `1.1.0`, to apply it as if only that tag existed.
   - **`single`:** unlists exactly the version in `version`, in every package that has it. It can be an alpha, an rc or a stable version. `version` is required.
3. Leave **dry_run** ticked for the first run. The log then lists what would go, and every listed version once with its number of packages, such as `1.0.0-rc.1 (105 packages)`. A version that only one package has shows up too. When no package lists the typed version, the run fails and prints that list.
4. Untick **dry_run** and run again to unlist for real.
5. Wait for the job "Unlist the old pre-release packages on nuget.org". The other jobs are skipped.
6. Read the end of the log. `Done. Unlisted N versions, 0 failed.` is a good run. A warning that the quota is exceeded is normal and stops the run without a failure. Wait an hour or more, then run again.

A script that starts the run has to pass the box as unticked: `gh workflow run build.yml --ref master -f mode=cleanup -f dry_run=false`.

The run uses the same temporary key as a tag run, so no API key is needed. The trusted publishing policy on nuget.org is bound to `build.yml`, which is why the manual run lives in that file. When `NuGet/login` fails, check the workflow file name in that policy.

## Fix a failed release

- **A job failed before the release was created:** fix the cause, delete the tag with `git push origin :refs/tags/v1.0.0-rc.1` and `git tag -d v1.0.0-rc.1`, then tag again.
- **The packages are published but the release failed:** run the failed job again from the Actions page. NuGet skips packages that exist already.
- **A wrong release text:** edit the release on GitHub, or change the intro and recreate the release.
