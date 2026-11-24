# Releasing the toolkit

This page is for the owner. It is not part of the published site.

One tag makes one release. All modules share the version of the tag.

## What a tag does

Push a tag that starts with `v`, such as `v1.0.0-rc.1`. The build workflow `.github/workflows/build.yml` then runs these jobs in order:

1. **Integration tests.** Needs Docker, which the runner has.
2. **Release.** Runs the tests, packs and publishes every package to nuget.org. MinVer reads the tag, so the package version is the tag without the `v`.
3. **Unlist alpha.** Unlists every alpha version of the packages on nuget.org. Runs next to the GitHub release, so a failure here never blocks it.
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

## Unlisting the alpha packages

- **Rule:** every listed version with `-alpha` in it is unlisted on each tag run. Rc and stable versions stay listed. nuget.org only unlists. A package stays available for an exact version reference.
- **Script:** `.github/scripts/Unlist-AlphaPackages.ps1`. It finds the packages with the search API (owner and the id prefix `gmarginet.Cat.`) and reads the `listed` flag from the registration data.
- **Key:** the job logs in with `NuGet/login`, like the release job. The trusted publishing policy on nuget.org has the scope All, which includes unlist. No extra secret.
- **Time limit:** the temporary key lasts one hour, so the script stops after 50 minutes. A big backlog takes several runs. The script only looks at versions that are still listed, so each run continues where the last one stopped.
- **Quota:** nuget.org limits the unlist calls of a key. Without a pause the first run did about 250 and then got `403 (Quota Exceeded)` for the rest. The script now waits one second after every call (`-DelayMilliseconds`) and stops without a failure at the first quota error. The next run does the next batch.
- **The next batch by hand:** open the Actions tab, pick the workflow "Publish CAT nuget packages" and choose **Run workflow** on `master`. A manual run only unlists. It runs no tests and publishes nothing. It uses the same temporary key as a tag run, so no API key is needed. Repeat it until the dry run lists nothing. The trusted publishing policy on nuget.org is bound to `build.yml`, which is why the manual run lives in that file.
- **Dry run:** `.\.github\scripts\Unlist-AlphaPackages.ps1 -Owner gmarginet -DryRun` shows what it would unlist and needs no key.
- **A run from your own machine:** set `NUGET_API_KEY` to a key with the unlist scope and run the script without `-DryRun`.
- **Normal pushes to `master`:** no unlisting. They publish new alpha versions, and these stay listed until the next tag.

## Cut a release

1. Check that the last run of the build workflow on `master` is green.
2. Create the tag on the commit to release: `git tag v1.0.0-rc.1`.
3. Push the tag: `git push origin v1.0.0-rc.1`. Pushing is the owner's step.
4. Watch the workflow. After the third job the release is on the homepage.

## Fix a failed release

- **A job failed before the release was created:** fix the cause, delete the tag with `git push origin :refs/tags/v1.0.0-rc.1` and `git tag -d v1.0.0-rc.1`, then tag again.
- **The packages are published but the release failed:** run the failed job again from the Actions page. NuGet skips packages that exist already.
- **A wrong release text:** edit the release on GitHub, or change the intro and recreate the release.
