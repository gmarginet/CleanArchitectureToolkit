# Releasing the toolkit

This page is for the owner. It is not part of the published site.

One tag makes one release. All modules share the version of the tag.

## What a tag does

Push a tag that starts with `v`, such as `v1.0.0-rc.1`. The build workflow `.github/workflows/build.yml` then runs these jobs in order:

1. **Integration tests.** Needs Docker, which the runner has.
2. **Release.** Runs the tests, packs and publishes every package to nuget.org. MinVer reads the tag, so the package version is the tag without the `v`.
3. **GitHub release.** Creates the release on the homepage with `gh release create`.

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

## Cut a release

1. Check that the last run of the build workflow on `master` is green.
2. Create the tag on the commit to release: `git tag v1.0.0-rc.1`.
3. Push the tag: `git push origin v1.0.0-rc.1`. Pushing is the owner's step.
4. Watch the workflow. After the third job the release is on the homepage.

## Fix a failed release

- **A job failed before the release was created:** fix the cause, delete the tag with `git push origin :refs/tags/v1.0.0-rc.1` and `git tag -d v1.0.0-rc.1`, then tag again.
- **The packages are published but the release failed:** run the failed job again from the Actions page. NuGet skips packages that exist already.
- **A wrong release text:** edit the release on GitHub, or change the intro and recreate the release.
