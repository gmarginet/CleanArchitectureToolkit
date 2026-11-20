---
name: cat-internal-verify-code
description: Build and test the solution with Cake, check the diff of the regenerated namespaces pages, check that no two modules share an error code area, and check that database code has its integration tests and its PostgreSQL counterpart. Use at the end of a task, after changing code, XML docs or the documentation generator.
allowed-tools: Bash(dotnet cake:*), PowerShell(dotnet cake:*), PowerShell(powershell.exe -NoProfile -ExecutionPolicy Bypass -File .claude/skills/cat-internal-verify-code/*), PowerShell(git status:*), PowerShell(git diff:*)
---

# Verify the toolkit

Run the standard checks and report what you find. Do not commit.

## Steps
Run Cake through [run-cake.ps1](run-cake.ps1). It writes the full log to the scratchpad and prints only the errors, the warning count and the test totals. Read the log only when the summary is not enough.

```
powershell.exe -NoProfile -ExecutionPolicy Bypass -File .claude/skills/cat-internal-verify-code/run-cake.ps1 -Target Build -Configuration Debug -LogDir <scratchpad path>
powershell.exe -NoProfile -ExecutionPolicy Bypass -File .claude/skills/cat-internal-verify-code/run-cake.ps1 -Target Test -LogDir <scratchpad path>
```

1. Run the `Build` target with `-Configuration Debug`. The `Debug` build regenerates the markdown in `modules/*/namespaces/`. The default `Release` build does not.
2. Run the `Test` target. It builds and tests `Release`, so it also checks that the `Release` build passes.
3. Check what the build regenerated: `git status --short modules` and `git diff --stat -- modules`.
4. For each changed page in `modules/*/namespaces/`, read the diff and decide if it matches the change you made.
5. Check the error code areas, see [Error code areas](#error-code-areas).
6. Check the database code, see [Database code](#database-code).
7. Report the result.

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

## Database code
Use this when the change adds or changes database code in `modules/`, such as SQL text, a `DbContext` store, a bulk or paging extension or an error check.
1. Check that an integration test in `integrationtests/` covers it on a real database. A project that only holds a `DbContext` or a session needs none.
2. Check that SQL Server code has its PostgreSQL counterpart, unless PostgreSQL has no such feature.
3. Add what is missing, or name it in the report when the owner has to decide.
4. Run the integration tests. They need Docker, and run `aspire ps` first, because the `Build` they depend on is the default `Release`.

```
powershell.exe -NoProfile -ExecutionPolicy Bypass -File .claude/skills/cat-internal-verify-code/run-cake.ps1 -Target IntegrationTest -LogDir <scratchpad path>
```

## Changing the generator
The build loads the generator as a committed binary from `resources/defaultDocumentationPlugins/`. Use this when you change `tools/Cat.DefaultDocumentationPlugin/`.
1. Run `tools\Cat.DefaultDocumentationPlugin\BuildAndDeployPlugin.cmd`. A change in the generator only takes effect after this.
2. Run the `Build` target of the steps above, with `-Configuration Debug`. Without it the build is `Release` and does not regenerate the pages.
3. Check the diff of the regenerated pages and confirm that the change is what you expect.
4. Commit the change to `tools/`, the updated DLLs and the regenerated pages together.

## Report
- Build: passed or failed. On failure, give the first errors with file and line.
- Tests: number passed, failed and skipped. On failure, name the failing tests and the message.
- Generated pages: which pages changed, and whether each change is expected.
- Error code areas: passed, or which modules share a prefix.
- Database code: the integration test totals, and any code without an integration test or a PostgreSQL counterpart.
- Anything you skipped, and why.
