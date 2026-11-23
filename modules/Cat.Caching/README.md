<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: ../.. -->
<link href="../../resources/styles/style.css" rel="stylesheet" />
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
            <img src='../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-module-readme skill to update this readme.-->
<!-- region end: TemplateSkill-->

# Cat.Caching <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Caching answers a query from a cache, so the handler and the database stay quiet for a question that was asked a minute ago. A book list or a category list is the typical case.

You list the query types you want cached. Nothing is cached by default. The cache wraps the query processor, so the query and its handler stay as they are.

The default cache is `HybridCache` from Microsoft, a memory cache with an optional shared level, such as Redis. The module is plain .NET. It never references Aspire.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Cache a query](#cache-a-query)
  - [What the key holds](#what-the-key-holds)
  - [How long an entry lives](#how-long-an-entry-lives)
  - [Clear entries with a tag](#clear-entries-with-a-tag)
  - [Failed responses](#failed-responses)
  - [Results from the cache](#results-from-the-cache)
  - [Several instances](#several-instances)
  - [A cache of your own](#a-cache-of-your-own)
  - [What to never cache](#what-to-never-cache)
  - [Together with the retry](#together-with-the-retry)
  - [Metrics](#metrics)
  - [Tests](#tests)
  - [What the module does not do](#what-the-module-does-not-do)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Caching)](#nuget-packages)

| Package | Role | Targets | Install | Downloads |
|---------|------|---------|---------|-----------|
| [Cat.Caching.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Caching.Abstractions/) | Contracts | netstandard2.0 | `dotnet add package gmarginet.Cat.Caching.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Caching.Abstractions)](https://www.nuget.org/packages/gmarginet.Cat.Caching.Abstractions/) |
| [Cat.Caching](https://www.nuget.org/packages/gmarginet.Cat.Caching/) | Implementation | netstandard2.0 | `dotnet add package gmarginet.Cat.Caching` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Caching)](https://www.nuget.org/packages/gmarginet.Cat.Caching/) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Caching.Abstractions](namespaces/Cat.Caching.Abstractions/index.md) | The cache contract and the settings that list which query types are cached. |
| [Cat.Caching](namespaces/Cat.Caching/index.md) | The cache around the query processor, the default cache on `HybridCache` and the metrics. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

| Module | Why Cat.Caching needs it |
|--------|--------------------------|
| [Cat.Queries](../Cat.Queries/README.md) | The cache wraps the query processor. It also uses the shared registration of wrappers in `Cat.Queries.Abstractions`. |
| [Cat.Responses](../Cat.Responses/README.md) | The cache stores the outcome and the value of a response, and builds the response again on a hit. |
| [Cat.Users](../Cat.Users/README.md) | Only `Cat.Users.Abstractions`, for `ICatUser`, which puts the user in the key. You do not need the rest of the module. |

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Cache a query
Register the queries module first, then list the query types. The call throws an `InvalidOperationException` at once when no query processor is registered, and the message names the missing call.

```csharp
services.AddCatQueriesModule(typeof(BookGetQueryHandler));
services.AddCatQueryCaching(options =>
{
    options.Cache<CategoryGetListQuery>(rule => rule.Shared());
    options.Cache<BookSearchQuery>(rule => rule.Shared().Tag("books"));
});
```

A call for a listed type is answered from the cache. A hit skips the new scope and the handler. A call for any other type passes straight through. Call `AddCatQueryCaching` once.

### What the key holds
The key holds the query type name and a hash of the user and the serialized query. The hash keeps personal data out of the key, also in a shared cache. The key never goes into a log or a metric tag.

- **The user.** By default every user gets an own entry, so one user never gets the answer of another. `Shared()` lets every user share one entry. Use it only for a query that gives every user the same answer. A forgotten `Shared()` costs memory and a lower hit rate, and never leaks data.
- **No `ICatUser`.** A service without a registered user works too. All its calls count as one anonymous user.
- **The query.** The query is serialized with `System.Text.Json`. For a query that cannot be serialized, such as one with a delegate, the first call throws an `InvalidOperationException` that names the query type. Give the type a key function instead:

```csharp
options.Cache<BookSearchQuery>(rule => rule.Key(query => $"{query.CategoryId}|{query.Text?.Trim().ToLowerInvariant()}"));
```

The function must return the same text for queries that give the same answer, and a different text otherwise.

### How long an entry lives
The expiry is absolute. An entry lives for `DefaultExpiration` from the moment it is stored, which is 5 minutes. A rule can set its own.

```csharp
services.AddCatQueryCaching(options =>
{
    options.DefaultExpiration = TimeSpan.FromMinutes(10);
    options.Cache<CategoryGetListQuery>(rule => rule.Expires(TimeSpan.FromHours(1)).ExpiresLocally(TimeSpan.FromMinutes(1)));
});
```

`ExpiresLocally` sets how long the memory level keeps an entry. A shorter time bounds how long another instance serves an entry that was removed, see [Several instances](#several-instances).

There is no sliding expiry, because `HybridCache` has none, and a hot entry that never expires goes stale. Bring [a cache of your own](#a-cache-of-your-own) if you need it.

### Clear entries with a tag
Give the entries of a query type a tag, and clear the tag in the code that changes the data. The module forces nothing: you call `RemoveByTagAsync` where it fits, such as in a command handler or an event subscriber.

```csharp
public static class CatalogCacheTags
{
    public const string Books = "books";
}

options.Cache<BookSearchQuery>(rule => rule.Shared().Tag(CatalogCacheTags.Books));

public class BookSaveCommandHandler(ICatQueryCache cache, /* ... */) : ICatCommandHandler<BookSaveCommand>
{
    public async Task<ICatResponse> HandleAsync(BookSaveCommand command, CancellationToken cancellationToken = default)
    {
        // Save the book, then clear the searches.
        await cache.RemoveByTagAsync(CatalogCacheTags.Books, cancellationToken);
        return CatResponse.Ok();
    }
}
```

Keep the tag name in one constant. A typo in one place gives a stale answer and no error.

### Failed responses
A failed response is never stored by default, so an error is never served from the cache. Only a success is stored: `Ok`, `Created`, `NoContent` and `Accepted`.

A missing item is looked up on every call. Cache a `NotFound` too when that costs too much:

```csharp
options.Cache<BookGetQuery>(rule => rule.CacheNotFound(TimeSpan.FromSeconds(30)));
```

- A `NotFound` has its own lifetime. After the item is created, the old `NotFound` stays until that time ends or its tag is cleared.
- No other failure is stored, also not with this setting. A timeout, a validation error and an unauthorized answer are always run again.
- A cached `NotFound` keeps its errors as code and message. The arguments of an error come back as text, not as the original objects.

### Results from the cache
`HybridCache` decides if a hit gives the same object or a copy. The module follows it and adds no copy logic of its own.

- **A normal result is copied.** A mutable class, a list, or any type that is not marked immutable. A caller that changes the result changes only its own copy. This is the default, and it needs nothing from you.
- **An immutable result is shared.** A `string`, a value type, or a sealed class marked `[ImmutableObject(true)]`. Every hit gives the same instance, which is faster. Marking a type this way is a promise that nobody changes it. A caller that breaks the promise changes the result for everyone.

```csharp
[ImmutableObject(true)]
public sealed record CategorySummary(Guid Id, string Name);
```

### Several instances
A service that runs in several containers has one memory cache per container. The module supports a shared level as a setup and ships no code for it. `HybridCache` uses the `IDistributedCache` in the container, so add the one you run:

```csharp
services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:6379");
services.AddCatQueryCaching(options => options.Cache<CategoryGetListQuery>(rule => rule.Shared()));
```

What to expect:
- **A burst of the same miss.** `HybridCache` runs the query once per key on one instance, and the other calls of that instance wait for the answer. With three containers the database can see up to three calls.
- **A cleared tag.** The tag is removed on the instance that clears it and in the shared level. Another instance that holds the entry in its memory keeps serving it until its local lifetime ends. Set `ExpiresLocally` on the rules where that delay matters.

### A cache of your own
Implement `ICatQueryCache` to replace the default, for example for sliding expiry or another store. The interface has two methods: `GetOrCreateAsync`, which also owns the rule that a burst of calls for one missing key runs the query once, and `RemoveByTagAsync`. Register your implementation after `AddCatQueryCaching`.

```csharp
services.AddCatQueryCaching(options => options.Cache<CategoryGetListQuery>(rule => rule.Shared()));
services.AddSingleton<ICatQueryCache, MyQueryCache>();
```

The factory of `GetOrCreateAsync` throws when a response must not be stored. Your cache must not store the result of a factory that throws, and must let the exception go to the caller.

### What to never cache
Never cache a query that a write or a price decision depends on. A stale `BookPriceListQuery` lets an order be placed at an old price. A stale `CheckIsbnExistsQuery` lets a validator accept a duplicate ISBN. Opt in per type already keeps such a query out until someone lists it on purpose.

The options are registered as a service, so a team can enforce the rule with a test over the list of cached query types:

```csharp
var rules = provider.GetRequiredService<CatQueryCacheOptions>().Rules;

Assert.That(rules.ContainsKey(typeof(BookPriceListQuery)), Is.False);
Assert.That(rules.ContainsKey(typeof(CheckIsbnExistsQuery)), Is.False);
```

### Together with the retry
The cache and the retry of [Cat.Resilience](../Cat.Resilience/README.md#retry-a-whole-command-or-query) both wrap the query processor. The cache is always outside the retry, whatever the order of your registration lines. A hit answers at once and never starts a retry. A miss goes to the retry.

Both modules register their wrapper with `AddCatQueryProcessorWrapper` of `Cat.Queries.Abstractions`, and the numbers in `CatQueryProcessorOrder` decide the place. A wrapper of your own can use a number in between, such as 150.

### Metrics
The module has a meter named `Cat.Caching` with two counters: `cat.caching.hits` and `cat.caching.misses`. The tag `query` holds the short name of the query type. A call that waits for a call that is already running counts as a hit.

`AddCatTelemetry` of [Cat.Telemetry](../Cat.Telemetry/README.md) exports the meter without a line from you. `Cat.Caching` itself has no dependency on `Cat.Telemetry`. The name is repeated in `CatTelemetryNames`, so keep the two equal if you change one.

### Tests
A unit test that uses `FakeQueryProcessor` of `Cat.UnitTesting` gets no cache, because the fake replaces the processor. Test the cache with a real query processor and a real `AddCatQueryCaching`, as the tests of the module do.

Register your own queries module, the caching with the rule of the query, and a counter in place of the real data source. The default key holds the user, so the provider also needs an `ICatUser`, or the rule uses `Shared()`.

```csharp
var services = new ServiceCollection();
services.AddSingleton(probe);                  // counts how often the handler runs
services.AddScoped<ICatUser>(_ => new FakeUser());
services.AddCatQueriesModule(typeof(BookListQueryHandler));
services.AddCatQueryCaching(options => options.Cache<BookListQuery>(rule => rule.Tag("books")));
using var provider = services.BuildServiceProvider();

using var scope = provider.CreateScope();
var processor = scope.ServiceProvider.GetRequiredService<ICatQueryProcessor>();
```

Two checks cover a cached query. The second call must not reach the handler, and clearing the tag, as your command handler does, makes the next call run the handler again.

```csharp
await processor.ProcessAsync(new BookListQuery());
await processor.ProcessAsync(new BookListQuery());
Assert.That(probe.Calls, Is.EqualTo(1));

await provider.GetRequiredService<ICatQueryCache>().RemoveByTagAsync("books");
await processor.ProcessAsync(new BookListQuery());
Assert.That(probe.Calls, Is.EqualTo(2));
```

`ReadmeExampleTests` of this module holds this example. `QueryCachingTests` holds more cases, such as the key per user, the lifetime and a failed response.

### What the module does not do
- **Commands and service requests.** Only queries are cached. A service request that only reads calls a query that can be cached.
- **HTTP output caching.** Use the output caching of ASP.NET Core directly.
- **Sliding expiry.** See [How long an entry lives](#how-long-an-entry-lives).
<!-- region end: Usage-->
