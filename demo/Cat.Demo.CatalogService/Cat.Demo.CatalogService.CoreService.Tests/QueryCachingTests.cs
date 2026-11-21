using Cat.Caching.Abstractions;
using Cat.Demo.CatalogService.Api.Extensions;
using Cat.Demo.CatalogService.CoreService;
using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Demo.CatalogService.Infrastructure.QueryHandlers;
using Cat.Queries.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.CatalogService.CoreService.Tests;

/// <summary>
/// Checks which Catalog queries are cached, with the real registration of the service. A stale answer of the price list
/// or the ISBN check is a real bug, so a test stops anyone from caching them by accident.
/// </summary>
[TestFixture]
public class QueryCachingTests
{
    private CatQueryCacheOptions _options = null!;

    [SetUp]
    public void SetUp()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddCatQueriesModule(typeof(BookGetQueryHandler));
        services.AddCatalogQueryCaching();

        using var provider = services.BuildServiceProvider();
        _options = provider.GetRequiredService<CatQueryCacheOptions>();
    }

    [Test]
    public void TheCategoryListAndTheBookSearchAreCached()
    {
        Assert.That(_options.Rules.ContainsKey(typeof(CategoryGetListQuery)), Is.True);
        Assert.That(_options.Rules.ContainsKey(typeof(BookSearchQuery)), Is.True);
    }

    [Test]
    public void ThePriceListIsNeverCached()
    {
        Assert.That(_options.Rules.ContainsKey(typeof(BookPriceListQuery)), Is.False);
    }

    [Test]
    public void TheIsbnCheckIsNeverCached()
    {
        Assert.That(_options.Rules.ContainsKey(typeof(CheckIsbnExistsQuery)), Is.False);
    }

    [Test]
    public void OnlyTheTwoListedQueriesAreCached()
    {
        Assert.That(_options.Rules, Has.Count.EqualTo(2));
    }
}
