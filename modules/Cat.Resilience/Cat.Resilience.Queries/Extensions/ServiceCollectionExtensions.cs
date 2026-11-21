using System;
using Cat.Queries.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Cat.Resilience.Abstractions;

namespace Cat.Resilience.Queries.Extensions;

/// <summary>
/// Registration helpers for the retry around the query processor.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Retries the query types that you list, through a resilience profile, with a fresh scope for every try.
    /// Register the queries module with <c>AddCatQueriesModule</c> and the resilience module with <c>AddCatResilienceModule</c> first,
    /// because the processor is wrapped and the pipelines come from there.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configure">Lists the query types, for example <c>options.Retry&lt;GetPriceQuery&gt;()</c>.</param>
    /// <returns>The same service collection, for chaining.</returns>
    /// <exception cref="InvalidOperationException">A query type is listed, but no <c>ICatQueryProcessor</c> is registered yet.</exception>
    public static IServiceCollection AddCatQueryRetry(this IServiceCollection services, Action<CatQueryRetryOptions> configure)
    {
        var options = new CatQueryRetryOptions();
        configure(options);

        if (!options.HasRules)
        {
            return services;
        }

        // The retry sits inside a cache of Cat.Caching, whatever the order of the lines. The place comes from CatQueryProcessorOrder.
        return services.AddCatQueryProcessorWrapper(
            CatQueryProcessorOrder.Retry,
            (provider, inner) => new CatRetryQueryProcessor(inner, provider.GetRequiredService<ICatResiliencePipelines>(), options),
            nameof(AddCatQueryRetry));
    }
}
