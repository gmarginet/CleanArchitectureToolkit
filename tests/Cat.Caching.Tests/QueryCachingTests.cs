using System.Diagnostics.Metrics;
using System.Globalization;
using Cat.Caching.Abstractions;
using Cat.Caching.Extensions;
using Cat.Queries.Abstractions;
using Cat.Queries.Extensions;
using Cat.Resilience.Abstractions;
using Cat.Resilience.Extensions;
using Cat.Resilience.Queries;
using Cat.Resilience.Queries.Extensions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Users.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Caching.Tests;

[TestFixture]
public class QueryCachingTests
{
    private Probe _probe = null!;

    [SetUp]
    public void SetUp() => _probe = new Probe();

    private ServiceProvider Build(Action<CatQueryCacheOptions> caching, bool withUser = true)
    {
        var services = new ServiceCollection();
        services.AddSingleton(_probe);
        if (withUser)
        {
            services.AddScoped<UserHolder>();
            services.AddScoped<ICatUser>(provider => provider.GetRequiredService<UserHolder>().User ?? new TestUser(string.Empty));
        }

        services.AddCatQueriesModule(typeof(Probe));
        services.AddCatQueryCaching(caching);
        return services.BuildServiceProvider();
    }

    private static ICatQueryProcessor ProcessorOf(IServiceProvider provider, string? userId = null)
    {
        var scope = provider.CreateScope();
        if (userId != null)
        {
            scope.ServiceProvider.GetRequiredService<UserHolder>().User = new TestUser(userId);
        }

        return scope.ServiceProvider.GetRequiredService<ICatQueryProcessor>();
    }

    [Test]
    public async Task Unlisted_PassesStraightThrough()
    {
        using var provider = Build(options => options.Cache<StringQuery>());
        var processor = ProcessorOf(provider);

        await processor.ProcessAsync(new OtherStringQuery("a"));
        await processor.ProcessAsync(new OtherStringQuery("a"));

        Assert.That(_probe.Calls, Is.EqualTo(2));
    }

    [Test]
    public async Task Listed_TheSecondCallIsAHit()
    {
        using var provider = Build(options => options.Cache<StringQuery>());
        var processor = ProcessorOf(provider);

        var first = await processor.ProcessAsync(new StringQuery("a"));
        var second = await processor.ProcessAsync(new StringQuery("a"));

        Assert.That(_probe.Calls, Is.EqualTo(1));
        Assert.That(first.Value, Is.EqualTo("v1"));
        Assert.That(second.IsSucceeded, Is.True);
        Assert.That(second.Value, Is.EqualTo("v1"));
    }

    [Test]
    public async Task Listed_TheHandlerSeesTheCultureOfTheCaller()
    {
        _probe.RespondString = _ => CatResponse.Ok(CultureInfo.CurrentUICulture.Name);
        using var provider = Build(options => options.Cache<StringQuery>(rule => rule.Key(query => $"{CultureInfo.CurrentUICulture.Name}|{query.Name}")));
        var processor = ProcessorOf(provider);
        var before = CultureInfo.CurrentUICulture;

        try
        {
            CultureInfo.CurrentUICulture = new CultureInfo("nl");
            var result = await processor.ProcessAsync(new StringQuery("a"));

            Assert.That(result.Value, Is.EqualTo("nl"));
        }
        finally
        {
            CultureInfo.CurrentUICulture = before;
        }
    }

    [Test]
    public async Task Listed_DifferentQueryValuesGetDifferentEntries()
    {
        using var provider = Build(options => options.Cache<StringQuery>());
        var processor = ProcessorOf(provider);

        var a = await processor.ProcessAsync(new StringQuery("a"));
        var b = await processor.ProcessAsync(new StringQuery("b"));

        Assert.That(_probe.Calls, Is.EqualTo(2));
        Assert.That(a.Value, Is.Not.EqualTo(b.Value));
    }

    [Test]
    public void Listed_Process_UsesTheCacheToo()
    {
        using var provider = Build(options => options.Cache<StringQuery>());
        var processor = ProcessorOf(provider);

        processor.Process(new StringQuery("a"));
        var second = processor.Process(new StringQuery("a"));

        Assert.That(_probe.Calls, Is.EqualTo(1));
        Assert.That(second.Value, Is.EqualTo("v1"));
    }

    [Test]
    public async Task EveryCallOfAValueTypeResultIsStoredAndRead()
    {
        using var provider = Build(options => options.Cache<NumberQuery>());
        var processor = ProcessorOf(provider);

        await processor.ProcessAsync(new NumberQuery());
        var second = await processor.ProcessAsync(new NumberQuery());

        Assert.That(_probe.Calls, Is.EqualTo(1));
        Assert.That(second.Value, Is.EqualTo(1));
    }

    #region Users

    [Test]
    public async Task User_EachUserGetsAnOwnEntry()
    {
        using var provider = Build(options => options.Cache<StringQuery>());

        var alice = await ProcessorOf(provider, "alice").ProcessAsync(new StringQuery("a"));
        var bob = await ProcessorOf(provider, "bob").ProcessAsync(new StringQuery("a"));
        var aliceAgain = await ProcessorOf(provider, "alice").ProcessAsync(new StringQuery("a"));

        Assert.That(_probe.Calls, Is.EqualTo(2));
        Assert.That(alice.Value, Is.Not.EqualTo(bob.Value));
        Assert.That(aliceAgain.Value, Is.EqualTo(alice.Value));
    }

    [Test]
    public async Task Shared_EveryUserGetsTheSameEntry()
    {
        using var provider = Build(options => options.Cache<StringQuery>(rule => rule.Shared()));

        await ProcessorOf(provider, "alice").ProcessAsync(new StringQuery("a"));
        var bob = await ProcessorOf(provider, "bob").ProcessAsync(new StringQuery("a"));

        Assert.That(_probe.Calls, Is.EqualTo(1));
        Assert.That(bob.Value, Is.EqualTo("v1"));
    }

    [Test]
    public async Task NoUserRegistered_ItStillWorks()
    {
        using var provider = Build(options => options.Cache<StringQuery>(), withUser: false);
        var processor = ProcessorOf(provider);

        await processor.ProcessAsync(new StringQuery("a"));
        await processor.ProcessAsync(new StringQuery("a"));

        Assert.That(_probe.Calls, Is.EqualTo(1));
    }

    #endregion

    #region Failures

    [Test]
    public async Task AFailedResponse_IsNotStored()
    {
        _probe.RespondString = call => call == 1
            ? CatResponse.InternalServerError<string>(CatError.Create("TST-500", "Boom"))
            : CatResponse.Ok($"v{call}");
        using var provider = Build(options => options.Cache<StringQuery>());
        var processor = ProcessorOf(provider);

        var first = await processor.ProcessAsync(new StringQuery("a"));
        var second = await processor.ProcessAsync(new StringQuery("a"));
        var third = await processor.ProcessAsync(new StringQuery("a"));

        Assert.That(first.IsFailed, Is.True);
        Assert.That(first.ErrorList.Single().Code, Is.EqualTo("TST-500"));
        Assert.That(second.Value, Is.EqualTo("v2"));
        Assert.That(third.Value, Is.EqualTo("v2"));
        Assert.That(_probe.Calls, Is.EqualTo(2));
    }

    [Test]
    public async Task ANotFound_IsNotStoredByDefault()
    {
        _probe.RespondString = _ => CatResponse.NotFound<string>(CatError.Create("TST-404", "Missing"));
        using var provider = Build(options => options.Cache<StringQuery>());
        var processor = ProcessorOf(provider);

        await processor.ProcessAsync(new StringQuery("a"));
        await processor.ProcessAsync(new StringQuery("a"));

        Assert.That(_probe.Calls, Is.EqualTo(2));
    }

    [Test]
    public async Task CacheNotFound_StoresTheNotFoundWithItsErrors()
    {
        _probe.RespondString = _ => CatResponse.NotFound<string>(CatError.Create("TST-404", "Book {0} is missing", "abc"));
        using var provider = Build(options => options.Cache<StringQuery>(rule => rule.CacheNotFound(TimeSpan.FromMinutes(1))));
        var processor = ProcessorOf(provider);

        await processor.ProcessAsync(new StringQuery("a"));
        var second = await processor.ProcessAsync(new StringQuery("a"));
        var third = await processor.ProcessAsync(new StringQuery("a"));

        Assert.That(_probe.Calls, Is.EqualTo(1));
        Assert.That(second.Type, Is.InstanceOf<CatResponseType.Failed.NotFound>());
        Assert.That(second.ErrorList.Single().Code, Is.EqualTo("TST-404"));
        Assert.That(second.ErrorList.Single().Message, Is.EqualTo("Book {0} is missing"));
        Assert.That(second.ErrorList.Single().Arguments.Single()?.ToString(), Is.EqualTo("abc"));
        Assert.That(third.IsFailed, Is.True);
    }

    [Test]
    public async Task CacheNotFound_ASuccessIsStoredInTheMainEntry()
    {
        using var provider = Build(options => options.Cache<StringQuery>(rule => rule.CacheNotFound(TimeSpan.FromMinutes(1))));
        var processor = ProcessorOf(provider);

        await processor.ProcessAsync(new StringQuery("a"));
        var second = await processor.ProcessAsync(new StringQuery("a"));

        Assert.That(_probe.Calls, Is.EqualTo(1));
        Assert.That(second.Value, Is.EqualTo("v1"));
    }

    [Test]
    public async Task CacheNotFound_AnotherFailureIsNeverStored()
    {
        _probe.RespondString = call => call == 1
            ? CatResponse.Unauthorized<string>(CatError.Create("TST-401", "No"))
            : CatResponse.Ok($"v{call}");
        using var provider = Build(options => options.Cache<StringQuery>(rule => rule.CacheNotFound(TimeSpan.FromMinutes(1))));
        var processor = ProcessorOf(provider);

        var first = await processor.ProcessAsync(new StringQuery("a"));
        var second = await processor.ProcessAsync(new StringQuery("a"));

        Assert.That(first.Type, Is.InstanceOf<CatResponseType.Failed.Unauthorized>());
        Assert.That(second.Value, Is.EqualTo("v2"));
        Assert.That(_probe.Calls, Is.EqualTo(2));
    }

    [Test]
    public async Task CacheNotFound_AfterTheTagIsRemovedTheItemCanBeFound()
    {
        _probe.RespondString = call => call == 1 ? CatResponse.NotFound<string>(CatError.Create("TST-404", "Missing")) : CatResponse.Ok($"v{call}");
        using var provider = Build(options => options.Cache<StringQuery>(rule => rule.CacheNotFound(TimeSpan.FromMinutes(1)).Tag("books")));
        var processor = ProcessorOf(provider);

        await processor.ProcessAsync(new StringQuery("a"));
        await provider.GetRequiredService<ICatQueryCache>().RemoveByTagAsync("books");
        var second = await processor.ProcessAsync(new StringQuery("a"));

        Assert.That(second.IsSucceeded, Is.True);
        Assert.That(second.Value, Is.EqualTo("v2"));
    }

    #endregion

    #region Tags

    [Test]
    public async Task RemoveByTag_TheNextCallRunsTheQueryAgain()
    {
        using var provider = Build(options => options.Cache<StringQuery>(rule => rule.Tag("books")));
        var processor = ProcessorOf(provider);

        await processor.ProcessAsync(new StringQuery("a"));
        await provider.GetRequiredService<ICatQueryCache>().RemoveByTagAsync("books");
        var second = await processor.ProcessAsync(new StringQuery("a"));

        Assert.That(_probe.Calls, Is.EqualTo(2));
        Assert.That(second.Value, Is.EqualTo("v2"));
    }

    [Test]
    public async Task RemoveByTag_AnotherTagKeepsTheEntry()
    {
        using var provider = Build(options => options.Cache<StringQuery>(rule => rule.Tag("books")));
        var processor = ProcessorOf(provider);

        await processor.ProcessAsync(new StringQuery("a"));
        await provider.GetRequiredService<ICatQueryCache>().RemoveByTagAsync("categories");
        await processor.ProcessAsync(new StringQuery("a"));

        Assert.That(_probe.Calls, Is.EqualTo(1));
    }

    #endregion

    #region Same object or copy

    [Test]
    public async Task AMutableResult_IsCopiedOnEveryHit()
    {
        using var provider = Build(options => options.Cache<ListQuery>());
        var processor = ProcessorOf(provider);

        var first = await processor.ProcessAsync(new ListQuery("a"));
        var second = await processor.ProcessAsync(new ListQuery("a"));
        second.Value.Add("changed");
        var third = await processor.ProcessAsync(new ListQuery("a"));

        Assert.That(_probe.Calls, Is.EqualTo(1));
        Assert.That(second.Value, Is.Not.SameAs(third.Value));
        Assert.That(third.Value, Is.EqualTo(new[] { "v1" }));
        Assert.That(first.Value, Is.EqualTo(new[] { "v1" }));
    }

    [Test]
    public async Task AnImmutableResult_IsTheSameInstanceOnEveryHit()
    {
        using var provider = Build(options => options.Cache<ImmutableQuery>());
        var processor = ProcessorOf(provider);

        var first = await processor.ProcessAsync(new ImmutableQuery());
        var second = await processor.ProcessAsync(new ImmutableQuery());
        var third = await processor.ProcessAsync(new ImmutableQuery());

        Assert.That(_probe.Calls, Is.EqualTo(1));
        Assert.That(second.Value, Is.SameAs(third.Value));
        Assert.That(first.Value.Value, Is.EqualTo("v1"));
    }

    #endregion

    #region Keys

    [Test]
    public async Task KeyFunction_QueriesWithTheSameKeyShareAnEntry()
    {
        using var provider = Build(options => options.Cache<StringQuery>(rule => rule.Key(query => query.Name.ToLowerInvariant())));
        var processor = ProcessorOf(provider);

        await processor.ProcessAsync(new StringQuery("ABC"));
        await processor.ProcessAsync(new StringQuery("abc"));

        Assert.That(_probe.Calls, Is.EqualTo(1));
    }

    [Test]
    public async Task AQueryThatCannotBeSerialized_ThrowsAMessageThatNamesTheTypeAndTheFix()
    {
        using var provider = Build(options => options.Cache<BadKeyQuery>());
        var processor = ProcessorOf(provider);

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => processor.ProcessAsync(new BadKeyQuery(() => { })));

        Assert.That(exception!.Message, Does.Contain(nameof(BadKeyQuery)));
        Assert.That(exception.Message, Does.Contain("key function"));
    }

    [Test]
    public async Task AQueryThatCannotBeSerialized_WorksWithAKeyFunction()
    {
        using var provider = Build(options => options.Cache<BadKeyQuery>(rule => rule.Key(_ => "fixed")));
        var processor = ProcessorOf(provider);

        await processor.ProcessAsync(new BadKeyQuery(() => { }));
        await processor.ProcessAsync(new BadKeyQuery(() => { }));

        Assert.That(_probe.Calls, Is.EqualTo(1));
    }

    #endregion

    #region Registration

    [Test]
    public void AddCatQueryCaching_AListedTypeAndNoProcessor_Throws()
    {
        var services = new ServiceCollection();

        var exception = Assert.Throws<InvalidOperationException>(() => services.AddCatQueryCaching(options => options.Cache<StringQuery>()));

        Assert.That(exception!.Message, Does.Contain("AddCatQueriesModule"));
        Assert.That(exception.Message, Does.Contain("AddCatQueryCaching"));
    }

    [Test]
    public void Cache_ATypeThatIsNotAQuery_Throws()
    {
        var options = new CatQueryCacheOptions();

        Assert.That(() => options.Cache<string>(), Throws.ArgumentException);
    }

    [Test]
    public void Rules_ACacheOfYourOwnReplacesTheDefault()
    {
        var services = new ServiceCollection();
        services.AddSingleton(_probe);
        services.AddCatQueriesModule(typeof(Probe));
        services.AddCatQueryCaching(options => options.Cache<StringQuery>());
        services.AddSingleton<ICatQueryCache, NoCache>();
        using var provider = services.BuildServiceProvider();

        Assert.That(provider.GetRequiredService<ICatQueryCache>(), Is.TypeOf<NoCache>());
    }

    [Test]
    public void Rules_TheOptionsAreReadableSoATeamCanTestWhichQueriesAreCached()
    {
        using var provider = Build(options =>
        {
            options.Cache<StringQuery>();
            options.Cache<ListQuery>();
        });

        var rules = provider.GetRequiredService<CatQueryCacheOptions>().Rules;

        Assert.That(rules.Keys, Is.EquivalentTo(new[] { typeof(StringQuery), typeof(ListQuery) }));
        Assert.That(rules.ContainsKey(typeof(OtherStringQuery)), Is.False);
    }

    [Test]
    public void Rule_ALifetimeOfZero_Throws()
    {
        var options = new CatQueryCacheOptions();

        Assert.That(() => options.Cache<StringQuery>(rule => rule.Expires(TimeSpan.Zero)), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => options.Cache<StringQuery>(rule => rule.CacheNotFound(TimeSpan.Zero)), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => options.Cache<StringQuery>(rule => rule.Tag("")), Throws.ArgumentException);
    }

    [Test]
    public void Rule_TheLifetimeComesFromTheRuleOrTheDefault()
    {
        var options = new CatQueryCacheOptions();
        options.Cache<StringQuery>(rule => rule.Expires(TimeSpan.FromSeconds(30)).ExpiresLocally(TimeSpan.FromSeconds(5)));
        options.Cache<ListQuery>();

        Assert.That(options.DefaultExpiration, Is.EqualTo(TimeSpan.FromMinutes(5)));
        Assert.That(options.Rules[typeof(StringQuery)].Expiration, Is.EqualTo(TimeSpan.FromSeconds(30)));
        Assert.That(options.Rules[typeof(StringQuery)].LocalExpiration, Is.EqualTo(TimeSpan.FromSeconds(5)));
        Assert.That(options.Rules[typeof(ListQuery)].Expiration, Is.Null);
    }

    #endregion

    #region Order with the retry

    [TestCase(true)]
    [TestCase(false)]
    public async Task TheCacheIsOutsideTheRetry_WhateverTheOrderOfTheLines(bool cacheFirst)
    {
        var attempts = 0;
        _probe.RespondString = _ =>
        {
            attempts++;
            return attempts < 2 ? CatResponse.InternalServerError<string>(CatError.Create("TST-500", "Boom")) : CatResponse.Ok("done");
        };

        var services = new ServiceCollection();
        services.AddSingleton(_probe);
        services.AddCatResilienceModule(options =>
        {
            foreach (var profile in options.Profiles.Values)
            {
                profile.Retry.Delay = TimeSpan.Zero;
                profile.Retry.UseJitter = false;
                profile.Retry.BackoffType = CatBackoffType.Constant;
                profile.Retry.MaxRetryAttempts = 2;
            }
        });
        services.AddCatQueriesModule(typeof(Probe));
        if (cacheFirst)
        {
            services.AddCatQueryCaching(options => options.Cache<StringQuery>());
            services.AddCatQueryRetry(options => options.Retry<StringQuery>());
        }
        else
        {
            services.AddCatQueryRetry(options => options.Retry<StringQuery>());
            services.AddCatQueryCaching(options => options.Cache<StringQuery>());
        }

        using var provider = services.BuildServiceProvider();
        var processor = ProcessorOf(provider);

        var first = await processor.ProcessAsync(new StringQuery("a"));
        var second = await processor.ProcessAsync(new StringQuery("a"));

        Assert.That(processor, Is.TypeOf<CatCachingQueryProcessor>());
        Assert.That(first.Value, Is.EqualTo("done"));
        Assert.That(second.Value, Is.EqualTo("done"));
        Assert.That(_probe.Calls, Is.EqualTo(2));
    }

    #endregion

    #region Metrics

    [Test]
    public async Task Metrics_AMissAndAHitAreCountedWithTheShortQueryName()
    {
        var measurements = new List<(string Instrument, string? Query, long Value)>();
        using var listener = new MeterListener();
        listener.InstrumentPublished = (instrument, meterListener) =>
        {
            if (instrument.Meter.Name == CatCachingTelemetry.MeterName)
            {
                meterListener.EnableMeasurementEvents(instrument);
            }
        };
        listener.SetMeasurementEventCallback<long>((instrument, value, tags, _) =>
        {
            string? query = null;
            foreach (var tag in tags)
            {
                if (tag.Key == "query")
                {
                    query = tag.Value?.ToString();
                }
            }

            lock (measurements)
            {
                measurements.Add((instrument.Name, query, value));
            }
        });
        listener.Start();

        using var provider = Build(options => options.Cache<StringQuery>());
        var processor = ProcessorOf(provider);

        await processor.ProcessAsync(new StringQuery("secret-value"));
        await processor.ProcessAsync(new StringQuery("secret-value"));

        List<(string Instrument, string? Query, long Value)> seen;
        lock (measurements)
        {
            seen = measurements.ToList();
        }

        Assert.That(seen, Is.EquivalentTo(new[]
        {
            ("cat.caching.misses", (string?)nameof(StringQuery), 1L),
            ("cat.caching.hits", (string?)nameof(StringQuery), 1L)
        }));
        Assert.That(seen.Select(item => item.Query), Has.None.Contains("secret-value"));
    }

    #endregion

    private sealed class NoCache : ICatQueryCache
    {
        public Task<T> GetOrCreateAsync<T>(string key, Func<CancellationToken, Task<T>> factory, CatQueryCacheEntryOptions options,
            CancellationToken cancellationToken = default) => factory(cancellationToken);

        public Task RemoveByTagAsync(string tag, CancellationToken cancellationToken = default) => Task.CompletedTask;
    }
}
