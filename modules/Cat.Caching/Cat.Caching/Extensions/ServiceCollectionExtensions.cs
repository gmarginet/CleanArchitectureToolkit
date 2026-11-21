using System;
using Cat.Caching.Abstractions;
using Cat.Queries.Abstractions;
using Cat.Users.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Caching.Extensions;

/// <summary>
/// Registration helpers for the query cache.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Caches the query types that you list, in front of the query processor. Nothing is cached by default.
    /// Register the queries module with <c>AddCatQueriesModule</c> first, because the processor is wrapped.
    /// The default cache uses <c>HybridCache</c>. Add an <c>IDistributedCache</c>, such as Redis, to the container to share entries between instances.
    /// A cache of your own replaces the default: register an <see cref="ICatQueryCache"/> after this call.
    /// The cache sits outside the retry of <c>Cat.Resilience</c>, whatever the order of the lines.
    /// Call it once. The options are registered as a service, so a test can check which query types are cached.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configure">Lists the query types, for example <c>options.Cache&lt;CategoryGetListQuery&gt;(rule => rule.Shared())</c>.</param>
    /// <returns>The same service collection, for chaining.</returns>
    /// <exception cref="InvalidOperationException">A query type is listed, but no <c>ICatQueryProcessor</c> is registered yet.</exception>
    public static IServiceCollection AddCatQueryCaching(this IServiceCollection services, Action<CatQueryCacheOptions> configure)
    {
        var options = new CatQueryCacheOptions();
        configure(options);

        if (options.Rules.Count > 0)
        {
            // It throws first when there is no processor, before anything else is registered.
            services.AddCatQueryProcessorWrapper(
                CatQueryProcessorOrder.Caching,
                (provider, inner) => new CatCachingQueryProcessor(
                    inner,
                    provider.GetRequiredService<ICatQueryCache>(),
                    options,
                    provider.GetService<ICatUser>()),
                nameof(AddCatQueryCaching));
        }

        services.AddHybridCache();
        services.TryAddSingleton<ICatQueryCache, CatHybridQueryCache>();
        services.AddSingleton(options);
        return services;
    }
}
