# Releasing the toolkit

This page is for the owner. It is not part of the published site.

One tag makes one release. All modules share the version of the tag.

## What a tag does

Push a tag that starts with `v`, such as `v1.0.0-rc.1`. The build workflow `.github/workflows/build.yml` then runs these jobs in order:

1. **Integration tests.** Needs Docker, which the runner has.
2. **Release.** Runs the tests, packs and publishes every package to nuget.org. MinVer reads the tag, so the package version is the tag without the `v`.
3. **Unlist old pre-releases.** Unlists the alpha versions and the in-between rc builds of the packages on nuget.org, see [Unlisting the old pre-releases](#unlisting-the-old-pre-releases). Runs next to the GitHub release, so a failure here never blocks it.
4. **GitHub release.** Creates the release on the homepage with `gh release create`.

## Rules for a tag

- **Format:** `v` plus a semantic version, such as `v1.0.0-rc.1` or `v1.0.0`.
- **Pre-release:** a version with a dash is marked pre-release on GitHub, so it never shows as the latest release.
- **`skip-ci` and `skip-pub`:** the workflow ignores both words in the message of the tagged commit. A tag always tests and publishes.
- **Pull requests:** they only run the tests, as before.
- **Normal pushes to `master`:** they still publish packages with a pre-release version. They create no GitHub release.

## What the release contains

- **Title:** the tag.
- **Intro:** `.github/release-intro.md`. `{version}` is replaced by the version. Change the file to change the text.
- **Changes:** the commit subjects since the previous `v` tag, without the `(skip-pub)` ending. The first tag has no previous tag, so it has no list. GitHub's generated notes list only pull requests, and the owner commits to `master` directly, so the workflow builds the list from commits.
- **Full changelog:** a link to the comparison with the previous tag.
- **Assets:** only the two source archives that GitHub adds to every release. The packages stay on nuget.org.

## Unlisting the old pre-releases

- **Rule:** every tag leaves only the tagged versions listed. nuget.org only unlists. A package stays available for an exact version reference.
  - **Any tag:** unlists every alpha version and every in-between rc build, such as `1.0.0-rc.1.6`. These are the builds of the pushes to `master` after a tag. The tagged versions, such as `1.0.0-rc.1`, stay listed. The version the tag just published is never unlisted.
  - **A stable tag, such as `v1.0.0`:** also unlists the tagged rc versions. Only stable versions are left.
- **Script:** `.github/scripts/Unlist-OldPrereleases.ps1`. It finds the packages with the search API (owner and the id prefix `gmarginet.Cat.`) and reads the `listed` flag from the registration data.
- **Key:** the job logs in with `NuGet/login`, like the release job. The trusted publishing policy on nuget.org has the scope All, which includes unlist. No extra secret.
- **Time limit:** the temporary key lasts one hour, so the script stops after 50 minutes. A big backlog takes several runs. The script only looks at versions that are still listed, so each run continues where the last one stopped.
- **Quota:** nuget.org limits the unlist calls of a key. Without a pause the first run did about 250 and then got `403 (Quota Exceeded)` for the rest. The script now waits one second after every call (`-DelayMilliseconds`) and stops without a failure at the first quota error. The next run does the next batch.
- **The next batch by hand:** see [Unlist the next batch](#unlist-the-next-batch). It needs no API key.
- **Dry run:** `.\.github\scripts\Unlist-OldPrereleases.ps1 -Owner gmarginet -DryRun` shows what it would unlist and needs no key. Add `-IncludeTaggedRc` to see the list after a stable release.
- **A run from your own machine:** set `NUGET_API_KEY` to a key with the unlist scope and run the script without `-DryRun`.
- **Normal pushes to `master`:** no unlisting. After a tag they publish in-between builds such as `1.0.0-rc.1.6`, and these stay listed until the next tag. After a stable tag they publish alpha versions, such as `1.0.1-alpha.0.3`, which also stay listed until the next tag.

## Cut a release

1. Check that the last run of the build workflow on `master` is green.
2. Create the tag on the commit to release: `git tag v1.0.0-rc.1`.
3. Push the tag: `git push origin v1.0.0-rc.1`. Pushing is the owner's step.
4. Watch the workflow. After the third job the release is on the homepage.

## Unlist the next batch

Use this to work off the backlog of old pre-release versions without a new tag. Each run unlists about 250 versions and stops at the quota of nuget.org.

1. Count what is left: `.\.github\scripts\Unlist-OldPrereleases.ps1 -Owner gmarginet -DryRun`. It prints one `Would unlist` line for each version.
2. Open the Actions tab of the repository, pick the workflow "Publish CAT nuget packages" and choose **Run workflow** on `master`.
3. Choose what the cleanup follows. `pre-release` is right until the first stable release. After `v1.0.0` choose `stable`, which also unlists the tagged rc versions.
4. Wait for the job "Unlist the old pre-release packages on nuget.org". The other jobs are skipped. A manual run runs no tests and publishes nothing.
5. Read the end of the log. `Done. Unlisted N versions, 0 failed.` is a good run. A warning that the quota is exceeded is normal and stops the run without a failure.
6. Repeat from step 2 until the dry run lists nothing. Tagged rc versions stay listed until you choose `stable`, and stable versions always stay listed.

The run uses the same temporary key as a tag run, so no API key is needed. The trusted publishing policy on nuget.org is bound to `build.yml`, which is why the manual run lives in that file. When `NuGet/login` fails, check the workflow file name in that policy.

## Fix a failed release

- **A job failed before the release was created:** fix the cause, delete the tag with `git push origin :refs/tags/v1.0.0-rc.1` and `git tag -d v1.0.0-rc.1`, then tag again.
- **The packages are published but the release failed:** run the failed job again from the Actions page. NuGet skips packages that exist already.
- **A wrong release text:** edit the release on GitHub, or change the intro and recreate the release.
