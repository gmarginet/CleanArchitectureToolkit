---
name: cat-add-resilience
description: Put a resilience profile on an HttpClient, or retry a whole command or query, with Cat.Resilience. Use when the developer needs retries, timeouts or a circuit breaker for calls to another service, or says "add resilience".
---

# Add resilience

`Cat.Resilience` gives an `HttpClient` a profile with a retry, a timeout and a circuit breaker.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Put a profile on an HttpClient", "The two profiles", "Add or change a profile", "Retry an unsafe method", "Protect one call that is not HTTP" and "Retry a whole command or query" in the readme of `Cat.Resilience`. The readme is `modules/Cat.Resilience/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.resilience/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.

## Steps
1. Ask what needs the protection: an `HttpClient`, a call that is not HTTP, or a whole command or query.
2. Add the package and register the module as the readme shows. A service with Aspire may get resilience from its `ServiceDefaults` already, through `ConfigureHttpClientDefaults` and `AddCatResilience`, and a service without Aspire makes that call in its `Program`, as the chapter "Without Aspire" says. Search for `AddCatResilience` first, and never add a second one.
3. For an `HttpClient` that has no profile yet, put the profile on its registration. A client made with `Cat.Api.Client` is such a client, see `cat-add-api-client`. Pick one of the two profiles, and change one only when the developer says why.
4. A method that is not safe to repeat, such as a POST, is not retried by default. Turn it on as "Retry an unsafe method" says, and only when the call is idempotent. Ask the developer.
5. For a whole command or query, add `Cat.Resilience.Commands` or `Cat.Resilience.Queries` and list the types that get a retry, as "Retry a whole command or query" shows. It is off by default, so use it only when the whole handler is safe to run again.
6. Add a test as the chapter "Tests" shows.
7. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- Never retry a call that is not idempotent without the developer saying it is safe.
- Do not stack a retry on a retry, such as a profile on the client and a retry on the command above it. Say so when the service has both.
