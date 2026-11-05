# Plans for Cat.Caching

A caching decorator for queries.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Many reads ask the same question again and again. A book list, a category list. A decorator can answer from a cache and skip the database. The query handler stays as it is, because the decorator wraps it.

## What we already know

From the module conventions:

- `Cat.Queries` runs handlers through decorators from `Cat.Decorators`. A decorator is an open generic class that wraps `ICatQueryHandler<,>`. The module already ships a logging decorator you switch on only when you need it.
- A query is a plain type that holds the data the handler needs. A query handler returns an `ICatResponse` with the result.
- Decorators are applied in an order. Cache placement relative to logging and tracing needs a decision.

From the demo plan:

- Cached catalog queries are the demo case. Catalog is mostly reads, with a small admin part.
- Authorization in Orders is a filter in the query: the queries get the external id of the customer, or none for an admin. A cached answer for one user must never reach another user.
- `Cat.Responses` outcomes include errors. A failed response should not be cached by default.
- Writes go through commands. A command that changes a book makes a cached book list stale.

From the architecture:

- Services run as several containers. An in-memory cache differs per instance.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Place | A decorator on query handlers. |
| First use | The Catalog queries in the demo. |

### Open

- **Cache technology.** `IMemoryCache`, `IDistributedCache`, or `HybridCache` from .NET? Which one is the default, and is it swappable?
- **Opt in.** Which queries are cached? An attribute on the query type, a registration, or an interface?
- **Key.** How is the cache key built from a query? Serialize the query, use record equality, or let the query supply its own key?
- **Lifetime.** Absolute or sliding expiry? Set per query?
- **Invalidation.** How does a command clear what it made stale? Tags, key prefixes, or nothing but short lifetimes?
- **Per user.** How does the key vary by user, role or tenant? A safe default is needed, so nothing leaks between users.
- **What is stored.** Only successful responses? A cached "not found"?
- **Size and copies.** Does the cache hand out the same object, or a copy? Results are mutable classes today.
- **Stampede.** Many requests for the same missing key at once. Does the module protect against it?
- **Visibility.** Metrics for hits and misses, and a way to see the key in logs.
- **Overlap.** HTTP output caching in `Cat.Minimal.Api` is a different layer. Is that out of scope?

## Questions before building

1. Which cache do you want as the default: memory, distributed or `HybridCache`?
2. How should a query say it may be cached?
3. Do commands invalidate the cache, or do we only use short lifetimes?
4. How do we guarantee that per user results do not leak?
5. Should failed responses ever be cached?
6. Do we need to support several instances in the first version?
7. Where in the decorator order does the cache sit, relative to logging and validation?
8. Do we want hit and miss metrics from day one, and does that depend on `Cat.Telemetry`?
9. Is there a query in the demo that we know is slow, or do we pick one to show the effect?
10. Do we ever want to cache service requests, or only queries?
