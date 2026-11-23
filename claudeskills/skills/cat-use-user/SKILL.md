---
name: cat-use-user
description: Read the current user in a handler, and set the user in a worker, with Cat.Users. Use when the developer needs who is calling, the user id or roles in a handler, a user for a background job, or says "use the user".
---

# Use the user

`Cat.Users` gives a handler the user of the call through `ICatUser`, an abstraction in `Cat.Users.Abstractions`.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Register the module", "Use the user in a handler", "Set the user in a worker", "Change the claim names", "Share the role claim with JWT bearer" and "Tests" in the readme of `Cat.Users`. The readme is `modules/Cat.Users/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.users/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.

## Steps
1. Ask where the user is needed: a handler of a request, or a worker such as a job or a message handler.
2. Add `Cat.Users.Abstractions` to the core service and `Cat.Users` to the `Api` project when they are missing, and register the module. See `cat-add-module`.
3. In a handler, take `ICatUser` through the constructor, as "Use the user in a handler" shows. The core service references only the abstraction.
4. In a worker that has no caller, set the user as "Set the user in a worker" shows. A job already runs as the system user, see `cat-add-job`.
5. When the identity provider uses other claim names, change them as "Change the claim names" says. Share the role claim with JWT bearer when the service checks roles that way.
6. Add a test that gives the handler a user, as the readme shows.
7. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- Never read the claims from the HTTP context in the core service. Use `ICatUser`.
- Check what the user may do in the handler or in a policy, and not by trusting a value that the caller sent.
