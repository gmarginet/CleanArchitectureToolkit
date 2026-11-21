using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Queries.Abstractions;
using Cat.Resilience.Abstractions;
using Cat.Responses.Abstractions;

namespace Cat.Resilience.Queries;

/// <summary>
/// Wraps the query processor. A listed query type runs inside the pipeline of its profile, and every try calls the inner processor again,
/// which opens a new scope. Every other type passes straight through.
/// A failed response that the rule counts becomes an exception inside the pipeline, so the profile retries it and counts it for its circuit breaker.
/// After the last retry the response of the last try comes back. When the pipeline itself says no, for example because its circuit is open
/// or a try timed out, its exception comes through.
/// </summary>
internal sealed class CatRetryQueryProcessor(
    ICatQueryProcessor inner,
    ICatResiliencePipelines pipelines,
    CatQueryRetryOptions options) : ICatQueryProcessor
{
    /// <inheritdoc />
    public async Task<ICatResponse<TQueryResult>> ProcessAsync<TQueryResult>(ICatQuery<TQueryResult> catQuery,
        CancellationToken cancellationToken = default)
    {
        if (!options.TryGetRule(catQuery.GetType(), out var rule))
        {
            return await inner.ProcessAsync(catQuery, cancellationToken).ConfigureAwait(false);
        }

        var pipeline = pipelines.Get(rule.Profile);
        try
        {
            return await pipeline.ExecuteAsync(async token =>
            {
                var response = await inner.ProcessAsync(catQuery, token).ConfigureAwait(false);
                if (rule.ShouldRetry(response))
                {
                    throw new RetryableResponseException<TQueryResult>(response);
                }

                return response;
            }, cancellationToken).ConfigureAwait(false);
        }
        catch (RetryableResponseException<TQueryResult> exception)
        {
            return exception.Response;
        }
    }

    /// <inheritdoc />
    public ICatResponse<TQueryResult> Process<TQueryResult>(ICatQuery<TQueryResult> catQuery)
    {
        return options.TryGetRule(catQuery.GetType(), out _)
            ? Task.Run(() => ProcessAsync(catQuery)).GetAwaiter().GetResult()
            : inner.Process(catQuery);
    }

    private sealed class RetryableResponseException<TQueryResult>(ICatResponse<TQueryResult> response)
        : Exception("The query failed and can be retried.")
    {
        public ICatResponse<TQueryResult> Response { get; } = response;
    }
}
