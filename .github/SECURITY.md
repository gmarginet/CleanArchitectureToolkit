# Security policy

## Report a security problem

Please do not open a public issue or a discussion for a security problem. Use private reporting instead:

1. Open the [Security tab](https://github.com/gmarginet/CleanArchitectureToolkit/security) of the repository.
2. Choose **Report a vulnerability**.
3. Describe the problem. Only the owner and you can read the report.

A good report has:
- the module and the package version
- what an attacker can do, and under which conditions
- the smallest code that shows it

The owner answers in the report. When the problem is confirmed, the fix ships in a new version, and a security advisory names the versions that are affected. You can get credit in the advisory when you want it.

## Supported versions

Until version 1.0.0 is out, only the latest version of the packages gets a fix. Move to the latest version first, and check whether the problem is still there.

## What counts

A problem in the code of a module counts, such as a way around a validation or a user that gets a role they should not have. A problem in the demo app counts only when a developer is likely to copy the code. A problem in a package that a module depends on belongs to that package. Report it there, and tell the owner when CAT is affected.
