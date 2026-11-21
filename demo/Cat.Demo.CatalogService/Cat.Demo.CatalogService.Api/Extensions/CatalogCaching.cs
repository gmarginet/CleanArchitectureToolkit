using Cat.Caching.Extensions;
using Cat.Demo.CatalogService.CoreService;
using Cat.Demo.CatalogService.CoreService.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.CatalogService.Api.Extensions;

public static class CatalogCaching
{
    /// <summary>
    /// Caches two queries. Every user gets the same answer, so both are shared. Prices and the ISBN check are not cached,
    /// because a stale answer of either is a real bug. The save clears the books tag.
    /// Register the queries module first.
    /// </summary>
    public static IServiceCollection AddCatalogQueryCaching(this IServiceCollection services)
    {
        return services.AddCatQueryCaching(options =>
        {
            options.Cache<CategoryGetListQuery>(rule => rule.Shared());
            options.Cache<BookSearchQuery>(rule => rule.Shared().Tag(CatalogCacheTags.Books));
        });
    }
}
