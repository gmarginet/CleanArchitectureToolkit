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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

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
A new module, `Cat.Caching`, with a caching decorator for queries. The first use is the Catalog queries in the demo.

#### The idea
Many reads ask the same question again and again. A book list, a category list. A decorator can answer from a cache and skip the database. The query handler stays as it is, because the decorator wraps it.

#### Background
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

#### What exists today
- The module does not exist yet. It is listed under the future modules in the root README.
- `Cat.Queries` and `Cat.Decorators` exist, with the logging decorator for queries as the example of an optional decorator.
- Nothing in the modules or the demo caches query results yet.

#### Decided
- **Place.** A decorator on query handlers.
- **First use.** The Catalog queries in the demo.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Which cache do we use as the default: memory, distributed or `HybridCache`? That means `IMemoryCache`, `IDistributedCache`, or `HybridCache` from .NET. Is the default swappable?
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
How should a query say it may be cached? Which queries are cached: an attribute on the query type, a registration, or an interface?
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Do commands invalidate the cache, or do we only use short lifetimes? How does a command clear what it made stale: with tags, with key prefixes, or with nothing but short lifetimes?
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
How do we guarantee that per user results do not leak? How does the key vary by user, role or tenant? A safe default is needed, so nothing leaks between users.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Should failed responses ever be cached? Is only a successful response stored, and what about a cached "not found"?
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Do we need to support several instances in the first version? Services run as several containers, and an in-memory cache differs per instance.
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
Where in the decorator order does the cache sit, relative to logging and validation? See [Cat.Decorators.md](Cat.Decorators.md), where the proposed default order puts caching after validation.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
Do we want hit and miss metrics from day one, and does that depend on `Cat.Telemetry`? Visibility also means a way to see the key in the logs.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Is there a query in the demo that we know is slow, or do we pick one to show the effect?
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Do we ever want to cache service requests, or only queries?
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
How is the cache key built from a query? We can serialize the query, use record equality, or let the query supply its own key.
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Is the expiry absolute or sliding? Is it set per query?
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
Does the cache hand out the same object, or a copy? Results are mutable classes today.
<!-- region end: Question 13-->

<!-- region start: Question 14-->
#### Question 14
Many requests can ask for the same missing key at once. Does the module protect against that stampede?
<!-- region end: Question 14-->

<!-- region start: Question 15-->
#### Question 15
HTTP output caching in `Cat.Minimal.Api` is a different layer. Is that out of scope?
<!-- region end: Question 15-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->