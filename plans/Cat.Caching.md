<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: .. -->
<link href="../resources/styles/style.css" rel="stylesheet" />
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-plan skill to update this plan.-->
<!-- region end: TemplateSkill-->

# Plans for `Cat.Caching` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catcaching)
<!-- region end: StatusBadge-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
- [Phase 1](#phase-1)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
A new module, `Cat.Caching`, with caching for queries. The first use is the Catalog queries in the demo.

#### The idea
Many reads ask the same question again and again. A book list, a category list. A cache in front of the handler can answer and skip the database. If the cache is a decorator, the query handler stays as it is, because the decorator wraps it. Whether it is a decorator is still open, see question 16.

#### Background
From the module conventions:
- `Cat.Queries` runs handlers through decorators from `Cat.Decorators`. A decorator is an open generic class that wraps `ICatQueryHandler<,>`. The module already ships a logging decorator you switch on only when you need it.
- A query is a plain type that holds the data the handler needs. A query handler returns an `ICatResponse` with the result.
- Decorators are applied in an order. If the cache is a decorator, its place relative to logging and tracing needs a decision.

From the demo plan:
- Cached catalog queries are the demo case. Catalog is mostly reads, with a small admin part.
- Authorization in Orders is a filter in the query: the queries get the external id of the customer, or none for an admin. A cached answer for one user must never reach another user.
- `Cat.Responses` outcomes include errors. A failed response should not be cached by default.
- Writes go through commands. A command that changes a book makes a cached book list stale.

From the architecture:
- Services run as several containers. An in-memory cache differs per instance.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- `Cat.Queries` and `Cat.Decorators` exist, with the logging decorator for queries as the example of an optional decorator.
- Nothing in the modules or the demo caches query results yet.

#### Decided
- **First use.** The Catalog queries in the demo.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Which cache do we use as the default: memory, distributed or `HybridCache`? This is the blocking question. Questions 3, 6, 13 and 14 follow from it. A swap must be possible, whichever we pick. The options:
- **`IMemoryCache`.** Simple, fast, no extra setup. Cost: one cache per instance, no stampede protection, and no sharing across the containers of a service.
- **`IDistributedCache`.** Shared across instances (Redis, SQL Server). Cost: every hit is a network call, and values must be serialized to bytes.
- **`HybridCache` (from .NET).** A memory cache in front of an optional distributed one, with stampede protection and tags built in. Cost: a newer API (check the tag invalidation support of the version we target), and it ties the module to the latest .NET and `Microsoft.Extensions.Caching.Hybrid`.
- **Our own small `ICatQueryCache` abstraction** with a `HybridCache` implementation as the default. Cost: one more abstraction, but the swap is easy and the module stays free of one cache type.

Recommendation: the small abstraction in `Cat.Caching.Abstractions`, with `Cat.Caching` using `HybridCache` as the default. A developer without a distributed cache gets the memory part, and with one gets sharing. It also answers questions 6 and 14 for free.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
How should a query say it may be cached? The options:
- **An attribute on the query type,** such as `[CatCached(Minutes = 5)]`. Cost: the query (in `Contracts` or core) depends on this module.
- **A marker interface,** such as `ICatCachedQuery`. Cost: the same dependency.
- **A registration,** such as `AddCachedQuery<BookSearchQuery>(TimeSpan.FromMinutes(5))`. Cost: the rule is far from the query, but the core stays free of caching.

Recommendation: the registration, because the toolbox rule says a core only references abstractions and a developer picks modules. The settings (question 12) go with it.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Do commands invalidate the cache, or do we only use short lifetimes? The options:
- **Short lifetimes only.** Cost: stale data for up to the lifetime, but nothing else to build.
- **Tags,** where a cached query lists tags (`"books"`) and a command or an event subscriber clears a tag. Cost: needs tag support in the cache (see question 1) and discipline to tag.
- **Key prefixes.** Cost: not every cache can clear by prefix.

Recommendation: short lifetimes in the first version, and tags in the second, through an `ICatQueryCache.RemoveByTagAsync`. Catalog is mostly reads, so staleness of a few minutes is fine for the demo.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
How do we guarantee that per user results do not leak? The options:
- **The key always includes the user,** from `ICatUser`, unless a query is marked as shared. Cost: more cache entries, and a dependency on `Cat.Users.Abstractions`.
- **The key never includes the user,** and the developer marks queries that vary. Cost: a leak if a developer forgets.
- **The key includes the user for queries that carry a user id,** because the query holds the external customer id (as in Orders). Cost: it relies on the query design.

Recommendation: safe by default: include the user in the key, and make the registration say `Shared()` for queries such as the Catalog lists. A mistake then shows up as a lower hit rate, not as a data leak.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Should failed responses ever be cached? The options:
- **Never.** Only a successful response is stored. Cost: a missing item is looked up every time.
- **Only `NotFound`,** with a short lifetime. Cost: a stale "not found" after the item is created.
- **A setting per query.**

Recommendation: never, by default, with the per query setting left for later. Writes are rare in Catalog, and a stale "not found" is a worse failure than a repeated lookup.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Do we need to support several instances in the first version? Services run as several containers, and an in-memory cache differs per instance. The options:
- **Yes, through a distributed second level** (see question 1). Cost: a Redis or SQL cache to run, also in the demo.
- **No, memory only,** and say so in the readme. Cost: instances can show different data for a short time.

Recommendation: no, memory only in the first version, with the swap point ready. Short lifetimes (question 3) keep the difference small, and the demo has no Redis.
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
If the cache is a decorator (question 16), where does it sit in the decorator order, relative to logging and validation? Cat.Decorators has numbers for tracing, logging and validation only. The options in short:
- **After validation, before the handler.** Invalid and unauthorized requests never reach the cache. Cost: none.
- **Before an authorization check.** Cost: a cached answer reaches a user who may not read it.

Recommendation: after validation, and after an authorization check if there is one.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
Do we want hit and miss metrics from day one, and does that depend on `Cat.Telemetry`? The options:
- **Yes, through `System.Diagnostics.Metrics`** with a source name `Cat.Caching`. No dependency on `Cat.Telemetry`, because the Aspire dashboard and OpenTelemetry pick it up. Cost: a small meter class.
- **No, later.** Cost: a developer cannot tell whether the cache works.
- **Debug log lines with the key.** Cost: noise, and keys can hold personal data.

Recommendation: the metrics from day one, with no dependency on `Cat.Telemetry`, and the key in a debug log only. It is the same approach that `Cat.Messaging` takes for dead letters.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Is there a query in the demo that we know is slow, or do we pick one to show the effect? The options:
- **Use `BookSearchQuery` or the category list** in Catalog, which reads a lot and changes little. Cost: it is not slow on a small demo database.
- **Add a delay on purpose** in a development setting, like the payment failure switches. Cost: a fake slowness, but the effect is visible.

Recommendation: a cached category or book list, with the hit and miss metric (question 8) as the proof in the dashboard. No fake delay is needed if the metric shows the hits.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Do we ever want to cache service requests, or only queries? The options:
- **Queries only.** A query is read only by definition. Cost: a service request that only reads, such as `BookPriceListRequest`, cannot be cached.
- **Also service requests** that are marked. Cost: a request can have side effects, so a cache could hide them.

Recommendation: queries only. A service request is the unit of work and may change state, and the handler can call a cached query inside.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
How is the cache key built from a query? The options:
- **Serialize the query** (JSON). Cost: slower, and it depends on the serializer.
- **Record equality / `ToString` of a record.** Cost: only fine for simple records.
- **The query supplies its own key** through an interface. Cost: the query depends on this module.
- **A key function in the registration.** Cost: one more lambda per cached query.

Recommendation: serialize with `System.Text.Json` by default, because every query is a plain type, and allow a key function in the registration for the rare query where that is not right. The key then also includes the query type name.
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Is the expiry absolute or sliding? Is it set per query? The options:
- **Absolute,** set per query in the registration, with a default for the rest. Cost: a hot item still expires.
- **Sliding.** Cost: a hot item can live for ever and go stale.
- **Both settings.**

Recommendation: absolute, set in the registration (question 2), with a module default of a few minutes. Sliding is rarely right for data that changes.
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
Does the cache hand out the same object, or a copy? Results are mutable classes today. The options:
- **The same object (memory cache).** Fast. Cost: a caller who changes the result changes it for everyone.
- **A copy** (serialized, as a distributed cache does). Cost: slower and more allocations.

Recommendation: follow the cache. With `HybridCache` the result is serialized for the distributed level, but the memory level can hand out the same instance, and the readme must say "results from the cache are read only". Make it a rule, not a copy.
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
Many requests can ask for the same missing key at once. Does the module protect against that stampede? The options:
- **Yes, through `HybridCache`,** which runs one factory call per key. Cost: none beyond question 1.
- **Our own lock per key.** Cost: more code, and a lock per instance only.
- **No.** Cost: a burst of identical queries hits the database after an expiry.

Recommendation: yes, through `HybridCache` as in question 1. This is one of the reasons to prefer it.
<!-- region end: Question 14-->

<!-- region start: Question 15-->
#### Question 15
HTTP output caching in `Cat.Minimal.Api` is a different layer. Is that out of scope? The options:
- **Out of scope.** A developer uses the ASP.NET Core output caching directly. Cost: none.
- **A helper in `Cat.Minimal.Api`** to switch it on per endpoint. Cost: it belongs in another module, and the user dependent rules must be handled again.

Recommendation: out of scope. It is a different module's job and ASP.NET Core already has it.
<!-- region end: Question 15-->
<!-- region start: Question 16-->
#### Question 16
Is a decorator the way to apply caching? The owner is not sure, for the same reason as the inbox of `Cat.EventProcessor`: a decorator wraps every handler of a service type, so it is all or nothing. Question 7 assumes a decorator, so look at it again after this answer. The options:
- **A. A decorator with a lookup per query type.** It wraps every query handler and passes the query on when the type has no cache setting. Cost: every handler is wrapped, and the decorator needs a number in the order of `Cat.Decorators`.
- **B. A decorator that a developer switches on per query type.** It needs a condition in `Cat.Decorators`. Cost: a change in another module.
- **C. No decorator. The handler asks a cache service.** Cost: the handler code changes, but the cache call is visible and testable without a pipeline.
- **D. A cache around the handler, set up in the registration of the handler.** Cost: a new way to register handlers, in `Cat.Queries`.

Recommendation: A, as question 7 assumes, because the handler stays as it is and only the queries with a setting are cached. This is the owner's call, and the discussion stays open.
<!-- region end: Question 16-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->