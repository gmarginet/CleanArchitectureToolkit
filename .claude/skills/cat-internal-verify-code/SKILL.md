---
name: cat-internal-verify-code
description: Build and test the solution with Cake, then check the diff of the regenerated namespaces pages. Use at the end of a task, after changing code, XML docs, the documentation generator or a module readme.
allowed-tools: Bash(dotnet cake:*), PowerShell(dotnet cake:*), PowerShell(git status:*), PowerShell(git diff:*)
---

# Verify the toolkit

Run the standard checks and report what you find. Do not commit.

## Steps
1. Run `dotnet cake --target=Build --configuration=Debug`. The `Debug` build regenerates the markdown in `modules/*/namespaces/`. The default `Release` build does not.
2. Run `dotnet cake --target=Test`. It builds and tests `Release`, so it also checks that the `Release` build passes.
3. Check what the build regenerated: `git status --short modules` and `git diff --stat -- modules`.
4. For each changed page in `modules/*/namespaces/`, read the diff and decide if it matches the change you made.
5. Report the result.

## Rules
- Never edit the files in `modules/*/namespaces/` by hand or with a script. They are generated.
- To change them, change the XML docs in the code, the generator (`tools/Cat.DefaultDocumentationPlugin/`) or the template, then build again.
- If a page changed and you did not expect it, say so. Do not revert it silently.

## Changing the generator
The build loads the generator as a committed binary from `resources/defaultDocumentationPlugins/`. Use this when you change `tools/Cat.DefaultDocumentationPlugin/`.
1. Run `tools\Cat.DefaultDocumentationPlugin\BuildAndDeployPlugin.cmd`. A change in the generator only takes effect after this.
2. Run the build of the steps above, with `--configuration=Debug`. A plain `dotnet cake --target=Build` builds `Release` and does not regenerate the pages.
3. Check the diff of the regenerated pages and confirm that the change is what you expect.
4. Commit the change to `tools/`, the updated DLLs and the regenerated pages together.

## Report
- Build: passed or failed. On failure, give the first errors with file and line.
- Tests: number passed, failed and skipped. On failure, name the failing tests and the message.
- Generated pages: which pages changed, and whether each change is expected.
- Anything you skipped, and why.
