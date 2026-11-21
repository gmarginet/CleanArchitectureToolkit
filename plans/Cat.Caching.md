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

<!-- region start: FirstStableVersion-->
**First stable version:** not reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 1](#phase-1)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
A new module, `Cat.Caching`, with caching for queries. The first use is the Catalog queries in the demo.

#### The idea
Many reads ask the same question again and again. A book list, a category list. A cache in front of the query can answer and skip the database. The cache wraps the query processor, so the query handler stays as it is, and only the query types a developer lists are cached.

#### Background
From the module conventions:
- `CatQueryProcessor` opens a new scope for every call and builds the handler with its decorators from `Cat.Decorators`. `Cat.Queries.Decorators.Logging` is the optional logging decorator, switched on with `AddCatQueriesModuleLoggingDecorator`.
- `Cat.Decorators` only wraps open generic types, such as `ICatQueryHandler<,>`. `ICatQueryProcessor` is not generic, and has one scoped registration, `AddScoped<ICatQueryProcessor, CatQueryProcessor>()` in `Cat.Queries`.
- A query is a plain type that holds the data the handler needs. A query handler returns an `ICatResponse` with the result.

From the other plans:
- The retry of [Cat.Resilience.md](Cat.Resilience.md#phase-2) also wraps `ICatQueryProcessor`, for the types a developer lists.
- `Cat.Telemetry` decided that each module owns its meter, named after the module, with short metric tags, and that personal data stays out of tags, see the [module readme of Cat.Telemetry](../modules/Cat.Telemetry/README.md#names-of-the-sources-the-meters-and-the-tags).
- The toolkit is in alpha and the demo is the only user, so a breaking change is allowed (owner, 2026-11-21).

From the demo:
- Cached catalog queries are the demo case. Catalog is mostly reads, with a small admin part.
- The Catalog queries are `BookGetQuery`, `BookSearchQuery`, `CategoryGetListQuery`, `BookPriceListQuery` and `CheckIsbnExistsQuery`. None of them uses the user. The service request handlers call them through `ICatQueryProcessor`.
- Orders asks Catalog for the prices of an order through `BookPriceListRequest`, whose handler calls `BookPriceListQuery`. `BookModelValidator` calls `CheckIsbnExistsQuery` to refuse a duplicate ISBN.
- Authorization in Orders is a filter in the query: the queries get the external id of the customer, or none for an admin. A cached answer for one user must never reach another user.
- `Cat.Responses` outcomes include errors. A failed response should not be cached by default.
- Writes go through commands. A command that changes a book makes a cached book list stale.

From the architecture:
- Services run as several containers. An in-memory cache differs per instance.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- `Cat.Queries`, `Cat.Decorators` and the logging decorator for queries exist.
- Nothing in the modules or the demo caches query results yet.
- `Microsoft.Extensions.Caching.Hybrid` is not in `Directory.Packages.props`.

#### Decided
- **First use.** The Catalog queries in the demo.
- **Around the query processor.** The cache wraps `ICatQueryProcessor` in the container, the same way as the retry of `Cat.Resilience`. For a listed type it answers from the cache, so a hit skips the new scope and the handler. Every other type passes straight through. It is not a decorator of `Cat.Decorators`, and `Cat.Decorators` stays unchanged (owner, 2026-11-21).
- **Opt in per type.** A query is cached only when the registration lists it, such as `options.Cache<CategoryGetListQuery>(...)`. Nothing is cached by default. The query and the core stay free of caching, with no attribute and no marker interface (owner, 2026-11-21).
- **Registration order.** The setup throws an `InvalidOperationException` at once when a listed query type has no query processor registered yet, and the message names the missing call. It is the same rule as in `Cat.Resilience` (owner, 2026-11-21).
- **Metrics.** Hit and miss metrics from day one, on the meter `Cat.Caching` of the module, with short metric tags such as `query`. The cache key never goes into a tag or a log, because a key can hold personal data. No dependency on `Cat.Telemetry` (owner, 2026-11-21).
- **Queries only.** Service requests are not cached. A service request that only reads, such as `BookPriceListRequest`, calls a query that can be cached (owner, 2026-11-21).
- **No HTTP output caching.** Output caching of ASP.NET Core is out of scope, so the module stays about one thing. A developer uses ASP.NET Core directly (owner, 2026-11-21).

#### Follows from the decisions
- A unit test with `FakeQueryProcessor` gets no cache. The module readme says so.
- Integration tests are needed only when the module ships database code of its own, such as a SQL Server second level, see question 6. Such code also gets a PostgreSQL counterpart.
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

Recommendation: absolute, set in the registration of the cached type, with a module default of a few minutes. Sliding is rarely right for data that changes.
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
<!-- region start: Question 17-->
#### Question 17
Which projects does the module get, and which target frameworks? The answer of question 1 decides the packages. The options:
- **`Cat.Caching.Abstractions` and `Cat.Caching`.** The abstractions hold the settings and, if question 1 chooses it, `ICatQueryCache`, on `netstandard2.0`. `Cat.Caching` holds the wrapper and the default cache. Cost: none beyond question 1.
- **One project, `Cat.Caching`.** Cost: a developer who writes an own cache has to reference the whole module.

To check when building: whether `Microsoft.Extensions.Caching.Hybrid` has a `netstandard2.0` build, and which version removes entries by tag. The package goes into both groups of `Directory.Packages.props`.

Recommendation: the abstractions and the module, like the other modules, with `netstandard2.0` for both if the package allows it, and `net10.0;net11.0` for `Cat.Caching` if not.
<!-- region end: Question 17-->

<!-- region start: Question 18-->
#### Question 18
The cache and the retry of `Cat.Resilience` both wrap `ICatQueryProcessor`. Which one sits outside? For example, `BookSearchQuery` is listed for both. The options:
- **The cache outside.** A hit answers at once and never starts a retry. A miss goes to the retry, which calls the processor again for every try. Cost: both modules need one rule for the order, whatever order the developer registers them in.
- **The retry outside.** Cost: a hit runs inside the retry pipeline for nothing, and a retry also asks the cache again.
- **The order of registration decides.** The last one registered is outside. Cost: the behaviour changes when a developer moves a line.

Recommendation: the cache outside, with a fixed rule that does not depend on the order of the lines.
<!-- region end: Question 18-->

<!-- region start: Question 19-->
#### Question 19
Which queries must never be cached, and does the module help to prevent it? A stale `BookPriceListQuery` lets Orders place an order with an old price. A stale `CheckIsbnExistsQuery` lets the validator accept a duplicate ISBN. The options:
- **A rule in the module readme.** Never cache a query that a write or a price decision depends on. Opt in per type already keeps them out by default. Cost: nobody enforces it.
- **A check at startup** against a list of query types that a developer marks as never cached. Cost: a second list to keep, next to the list of cached types.

Recommendation: the rule in the readme, with these two queries as the examples. Opt in per type means a query is only cached when someone lists it on purpose.
<!-- region end: Question 19-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->