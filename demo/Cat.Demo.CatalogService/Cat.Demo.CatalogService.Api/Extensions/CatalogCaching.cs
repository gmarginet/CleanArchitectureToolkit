using System.Globalization;
using Cat.Caching.Extensions;
using Cat.Demo.CatalogService.CoreService;
using Cat.Demo.CatalogService.CoreService.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.CatalogService.Api.Extensions;

public static class CatalogCaching
{
    /// <summary>
    /// Caches two queries. Every user gets the same answer in a language, so both are shared and have the culture in the key. Prices and the ISBN check are not cached,
    /// because a stale answer of either is a real bug. The save clears the books tag.
    /// Register the queries module first.
    /// </summary>
    public static IServiceCollection AddCatalogQueryCaching(this IServiceCollection services)
    {
        return services.AddCatQueryCaching(options =>
        {
            // Both answers hold category names in the language of the request, so the culture is part of the key.
            options.Cache<CategoryGetListQuery>(rule => rule.Shared().Tag(CatalogCacheTags.Categories).Key(_ => CultureInfo.CurrentUICulture.Name));
            options.Cache<BookSearchQuery>(rule => rule.Shared().Tag(CatalogCacheTags.Books)
                .Key(query => $"{CultureInfo.CurrentUICulture.Name}|{query.Text}|{query.CategoryId}"));
        });
    }
}
