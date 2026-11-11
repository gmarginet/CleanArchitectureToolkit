---
name: cat-internal-verify-code
description: Build and test the solution with Cake, check the diff of the regenerated namespaces pages, and check that no two modules share an error code area. Use at the end of a task, after changing code, XML docs, the documentation generator or a module readme.
allowed-tools: Bash(dotnet cake:*), PowerShell(dotnet cake:*), PowerShell(git status:*), PowerShell(git diff:*)
---

# Verify the toolkit

Run the standard checks and report what you find. Do not commit.

## Steps
1. Run `dotnet cake --target=Build --configuration=Debug`. The `Debug` build regenerates the markdown in `modules/*/namespaces/`. The default `Release` build does not.
2. Run `dotnet cake --target=Test`. It builds and tests `Release`, so it also checks that the `Release` build passes.
3. Check what the build regenerated: `git status --short modules` and `git diff --stat -- modules`.
4. For each changed page in `modules/*/namespaces/`, read the diff and decide if it matches the change you made.
5. Check the error code areas, see [Error code areas](#error-code-areas).
6. Report the result.

## Rules
- Never edit the files in `modules/*/namespaces/` by hand or with a script. They are generated.
- To change them, change the XML docs in the code, the generator (`tools/Cat.DefaultDocumentationPlugin/`) or the template, then build again.
- If a page changed and you did not expect it, say so. Do not revert it silently.

## Error code areas
A CAT error code is `<APPLICATION>-<AREA>-<number>`, like `CAT-VAL-1001`, and the area is a 3 letter acronym of the module. Two modules must never share an area, or two different errors get one code. There is no table of areas. This check is how a clash is found.

```
powershell.exe -NoProfile -ExecutionPolicy Bypass -File .claude/skills/cat-internal-verify-code/check-error-areas.ps1
```

- A module keeps its codes in one class, and that class holds the prefix in a constant whose name ends with `ErrorCodePrefix`, like `private const string ValidatorErrorCodePrefix = "CAT-VAL";`. The script finds those constants in `modules/`. It skips `bin`, `obj` and the generated `namespaces` folders.
- It prints every prefix with its module and exits with 1 when two modules use the same prefix. It warns about a prefix that is not `CAT-` followed by 3 uppercase letters.
- A clash is an error to fix, not to report only. Pick another area for the module that came last.
- A module whose constant does not end with `ErrorCodePrefix` is not seen. Name it that way.

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
- Error code areas: passed, or which modules share a prefix.
- Anything you skipped, and why.
