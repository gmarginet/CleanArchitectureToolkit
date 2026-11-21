using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Caching.Abstractions;

/// <summary>
/// The cache behind the query cache of <c>Cat.Caching</c>. The default implementation uses <c>HybridCache</c>.
/// Implement it to bring an own cache, for example one with sliding expiry, and register it before or after <c>AddCatQueryCaching</c>.
/// The last registration wins.
/// </summary>
public interface ICatQueryCache
{
    /// <summary>
    /// Returns the value of a key. When the cache has none, it calls the factory and stores the result.
    /// A burst of calls for the same missing key should run the factory once. The default implementation does that per instance.
    /// When the factory throws, nothing is stored and the exception goes to the caller.
    /// </summary>
    /// <typeparam name="T">The type of the stored value.</typeparam>
    /// <param name="key">The key of the entry. It never holds the plain query or the user.</param>
    /// <param name="factory">Creates the value when the cache has none.</param>
    /// <param name="options">How long the entry lives and which tags it gets.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The cached or the new value.</returns>
    Task<T> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, Task<T>> factory,
        CatQueryCacheEntryOptions options,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes every entry that has the tag.
    /// A cache that is spread over several instances may keep the entry in the memory of the other instances
    /// until its local lifetime ends.
    /// </summary>
    /// <param name="tag">The tag to remove, as listed in the registration of the query type.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that finishes when the tag is removed.</returns>
    Task RemoveByTagAsync(string tag, CancellationToken cancellationToken = default);
}
