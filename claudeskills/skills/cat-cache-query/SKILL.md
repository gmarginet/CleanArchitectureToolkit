---
name: cat-cache-query
description: Cache a query and clear it with a tag using Cat.Caching. Use when the developer wants to cache the result of a query, speed up a read, clear the cache after a change, or says "cache a query".
---

# Cache a query

`Cat.Caching` caches the response of a query. A command clears the entries with a tag.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Cache a query", "What the key holds", "How long an entry lives", "Clear entries with a tag", "What to never cache", "Several instances" and "Tests" in the readme of `Cat.Caching`. The readme is `modules/Cat.Caching/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.caching/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.

## Steps
1. Ask which query to cache and how stale the answer may be. Read "What to never cache" and check the query against it. Say no when it fits there.
2. Add the package and register the queries module first, then `AddCatQueryCaching` once, as "Cache a query" shows. When the service already calls `AddCatQueryCaching`, add to that call and never add a second one.
3. List the query type in the options with `options.Cache<TQuery>(...)`, with the lifetime of "How long an entry lives". Use `Shared()` only when every user gets the same answer, because by default every user has an own entry. A query that cannot be serialized needs a `Key` function.
4. Give the entries a tag, and clear the tag in the code that changes the data, such as a command handler. The module forces nothing, so find the commands that write the same entities and show the developer the list.
5. With more than one instance, read "Several instances". Tell the developer what the cache does there, and which cache the service uses.
6. Add a test as the readme shows: the second call must not reach the handler, and a command must clear the entry.
7. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- Never use `Shared()` for a query whose answer depends on the user. "What the key holds" says what is in the key.
- A cache that is never cleared after a change shows old data. Check every command that touches the data.
