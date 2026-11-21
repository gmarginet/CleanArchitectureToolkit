using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Caching.Abstractions;
using Microsoft.Extensions.Caching.Hybrid;

namespace Cat.Caching;

/// <summary>
/// The default <see cref="ICatQueryCache"/>. It uses <c>HybridCache</c>, so a developer gets a memory level and, with an
/// <c>IDistributedCache</c> in the container, a shared level. <c>HybridCache</c> runs one factory call per key on one instance.
/// </summary>
internal sealed class CatHybridQueryCache(HybridCache cache) : ICatQueryCache
{
    /// <inheritdoc />
    public async Task<T> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, Task<T>> factory,
        CatQueryCacheEntryOptions options,
        CancellationToken cancellationToken = default)
    {
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = options.Expiration,
            LocalCacheExpiration = options.LocalExpiration ?? options.Expiration
        };

        return await cache.GetOrCreateAsync(
            key,
            token => new ValueTask<T>(factory(token)),
            entryOptions,
            options.Tags,
            cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public Task RemoveByTagAsync(string tag, CancellationToken cancellationToken = default)
        => cache.RemoveByTagAsync(tag, cancellationToken).AsTask();
}
