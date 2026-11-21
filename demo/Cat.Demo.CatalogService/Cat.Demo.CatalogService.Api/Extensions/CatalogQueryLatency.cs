using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.CatalogService.Api.Extensions;

/// <summary>
/// Demo only. Makes the two cached queries slow, so a miss is slow and a hit is instant. The handlers stay as they are.
/// </summary>
public static class CatalogQueryLatency
{
    /// <summary>
    /// Waits <paramref name="latency"/> before the two cached queries run. Does nothing when the latency is zero.
    /// The wrapper sits inside the cache, so a hit never waits. Register the queries module first.
    /// </summary>
    public static IServiceCollection AddCatalogQueryLatency(this IServiceCollection services, TimeSpan latency)
    {
        if (latency <= TimeSpan.Zero)
        {
            return services;
        }

        // 150 is between the cache (100) and the retry (200), see CatQueryProcessorOrder.
        return services.AddCatQueryProcessorWrapper(
            150,
            (_, inner) => new LatencyQueryProcessor(inner, latency),
            nameof(AddCatalogQueryLatency));
    }

    private sealed class LatencyQueryProcessor(ICatQueryProcessor inner, TimeSpan latency) : ICatQueryProcessor
    {
        public async Task<ICatResponse<TQueryResult>> ProcessAsync<TQueryResult>(
            ICatQuery<TQueryResult> catQuery, CancellationToken cancellationToken = default)
        {
            if (IsCached(catQuery))
            {
                await Task.Delay(latency, cancellationToken);
            }

            return await inner.ProcessAsync(catQuery, cancellationToken);
        }

        public ICatResponse<TQueryResult> Process<TQueryResult>(ICatQuery<TQueryResult> catQuery)
        {
            if (IsCached(catQuery))
            {
                Task.Delay(latency).GetAwaiter().GetResult();
            }

            return inner.Process(catQuery);
        }

        private static bool IsCached<TQueryResult>(ICatQuery<TQueryResult> catQuery)
        {
            return catQuery is CategoryGetListQuery or BookSearchQuery;
        }
    }
}
