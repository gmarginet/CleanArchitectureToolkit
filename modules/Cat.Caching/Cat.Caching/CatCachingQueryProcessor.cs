using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Cat.Caching.Abstractions;
using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;
using Cat.Users.Abstractions;

namespace Cat.Caching;

/// <summary>
/// Wraps the query processor. A listed query type is answered from the cache, so a hit skips the new scope and the handler.
/// Every other type passes straight through.
/// Only a successful response is stored. A <c>NotFound</c> is stored too when the rule asks for it. Every other failure is never stored.
/// </summary>
internal sealed class CatCachingQueryProcessor(
    ICatQueryProcessor inner,
    ICatQueryCache cache,
    CatQueryCacheOptions options,
    ICatUser? user) : ICatQueryProcessor
{
    /// <inheritdoc />
    public async Task<ICatResponse<TQueryResult>> ProcessAsync<TQueryResult>(ICatQuery<TQueryResult> catQuery,
        CancellationToken cancellationToken = default)
    {
        var queryType = catQuery.GetType();
        if (!options.Rules.TryGetValue(queryType, out var rule))
        {
            return await inner.ProcessAsync(catQuery, cancellationToken).ConfigureAwait(false);
        }

        var key = CatQueryCacheKeys.Build(catQuery, rule, user?.UserId);

        // A value that HybridCache sees as immutable is shared. Every other value is copied on a hit.
        return CatImmutableTypes.IsImmutable(typeof(TQueryResult))
            ? await RunAsync<TQueryResult, ImmutableCachedQueryResponse<TQueryResult>>(catQuery, queryType.Name, key, rule, cancellationToken).ConfigureAwait(false)
            : await RunAsync<TQueryResult, MutableCachedQueryResponse<TQueryResult>>(catQuery, queryType.Name, key, rule, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public ICatResponse<TQueryResult> Process<TQueryResult>(ICatQuery<TQueryResult> catQuery)
    {
        return options.Rules.ContainsKey(catQuery.GetType())
            ? Task.Run(() => ProcessAsync(catQuery)).GetAwaiter().GetResult()
            : inner.Process(catQuery);
    }

    private async Task<ICatResponse<TQueryResult>> RunAsync<TQueryResult, TCached>(
        ICatQuery<TQueryResult> catQuery,
        string queryName,
        string key,
        CatQueryCacheRule rule,
        CancellationToken cancellationToken)
        where TCached : CachedQueryResponse<TQueryResult>, new()
    {
        // Set when the query really ran. A call that gets its answer from the cache, or from a call that is already running, is a hit.
        var ran = false;
        // The factory of HybridCache can run on a thread that does not carry the culture of the caller. The query must see the same culture as without the cache.
        var culture = CultureInfo.CurrentCulture;
        var uiCulture = CultureInfo.CurrentUICulture;
        var entryOptions = CreateEntryOptions(rule, rule.Expiration ?? options.DefaultExpiration);

        try
        {
            TCached cached;
            if (rule.NotFoundExpiration == null)
            {
                cached = await cache.GetOrCreateAsync<TCached>(key, async token =>
                {
                    ran = true;
                    CultureInfo.CurrentCulture = culture;
                    CultureInfo.CurrentUICulture = uiCulture;
                    var response = await inner.ProcessAsync(catQuery, token).ConfigureAwait(false);
                    return response.IsSucceeded
                        ? CachedQueryResponse<TQueryResult>.From<TCached>(response)
                        : throw new CatCacheBypassException<TQueryResult>(response);
                }, entryOptions, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                var notFoundOptions = CreateEntryOptions(rule, rule.NotFoundExpiration.Value);
                cached = await cache.GetOrCreateAsync<TCached>(key, async token =>
                {
                    // The main entry has no value. Ask the entry of a NotFound first, and run the query only when it is empty too.
                    TCached notFound;
                    try
                    {
                        notFound = await cache.GetOrCreateAsync<TCached>(key + ":notfound", async notFoundToken =>
                        {
                            ran = true;
                            CultureInfo.CurrentCulture = culture;
                            CultureInfo.CurrentUICulture = uiCulture;
                            var response = await inner.ProcessAsync(catQuery, notFoundToken).ConfigureAwait(false);
                            return CachedQueryResponse<TQueryResult>.IsNotFound(response)
                                ? CachedQueryResponse<TQueryResult>.From<TCached>(response)
                                : throw new CatCacheBypassException<TQueryResult>(response);
                        }, notFoundOptions, token).ConfigureAwait(false);
                    }
                    catch (CatCacheBypassException<TQueryResult> bypass) when (bypass.Response.IsSucceeded)
                    {
                        // A success belongs in the main entry. Any other failure goes on to the caller and is not stored.
                        return CachedQueryResponse<TQueryResult>.From<TCached>(bypass.Response);
                    }

                    throw new CatCacheBypassException<TQueryResult>(notFound.ToResponse());
                }, entryOptions, cancellationToken).ConfigureAwait(false);
            }

            CatCachingTelemetry.Record(queryName, hit: !ran);
            return cached.ToResponse();
        }
        catch (CatCacheBypassException<TQueryResult> bypass)
        {
            // A response that is not stored: a failure, or a NotFound that came from its own entry.
            CatCachingTelemetry.Record(queryName, hit: !ran);
            return bypass.Response;
        }
    }

    private static CatQueryCacheEntryOptions CreateEntryOptions(CatQueryCacheRule rule, TimeSpan expiration)
    {
        var local = rule.LocalExpiration;
        return new CatQueryCacheEntryOptions
        {
            Expiration = expiration,
            LocalExpiration = local != null && local.Value < expiration ? local : null,
            Tags = rule.Tags
        };
    }

    /// <summary>
    /// Carries a response that must not be stored out of the factory of the cache. A cache does not store a factory that throws.
    /// </summary>
    private sealed class CatCacheBypassException<TQueryResult>(ICatResponse<TQueryResult> response)
        : Exception("The response is not stored in the cache.")
    {
        public ICatResponse<TQueryResult> Response { get; } = response;
    }
}
