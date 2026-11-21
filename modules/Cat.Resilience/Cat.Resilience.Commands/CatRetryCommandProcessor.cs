using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Resilience.Abstractions;
using Cat.Responses.Abstractions;

namespace Cat.Resilience.Commands;

/// <summary>
/// Wraps the command processor. A listed command type runs inside the pipeline of its profile, and every try calls the inner processor again,
/// which opens a new scope. Every other type passes straight through.
/// A failed response that the rule counts becomes an exception inside the pipeline, so the profile retries it and counts it for its circuit breaker.
/// After the last retry the response of the last try comes back. When the pipeline itself says no, for example because its circuit is open
/// or a try timed out, its exception comes through.
/// </summary>
internal sealed class CatRetryCommandProcessor(
    ICatCommandProcessor inner,
    ICatResiliencePipelines pipelines,
    CatCommandRetryOptions options) : ICatCommandProcessor
{
    /// <inheritdoc />
    public Task<ICatResponse> ProcessAsync(ICatCommand catCommand, CancellationToken cancellationToken = default)
    {
        return options.TryGetRule(catCommand.GetType(), out var rule)
            ? RunAsync(rule, token => inner.ProcessAsync(catCommand, token), cancellationToken)
            : inner.ProcessAsync(catCommand, cancellationToken);
    }

    /// <inheritdoc />
    public ICatResponse Process(ICatCommand catCommand)
    {
        return options.TryGetRule(catCommand.GetType(), out _)
            ? Task.Run(() => ProcessAsync(catCommand)).GetAwaiter().GetResult()
            : inner.Process(catCommand);
    }

    /// <inheritdoc />
    public Task<ICatResponse<TResult>> ProcessAsync<TResult>(ICatCommand<TResult> catCommand, CancellationToken cancellationToken = default)
    {
        return options.TryGetRule(catCommand.GetType(), out var rule)
            ? RunAsync(rule, token => inner.ProcessAsync(catCommand, token), cancellationToken)
            : inner.ProcessAsync(catCommand, cancellationToken);
    }

    /// <inheritdoc />
    public ICatResponse<TResult> Process<TResult>(ICatCommand<TResult> catCommand)
    {
        return options.TryGetRule(catCommand.GetType(), out _)
            ? Task.Run(() => ProcessAsync(catCommand)).GetAwaiter().GetResult()
            : inner.Process(catCommand);
    }

    private async Task<TResponse> RunAsync<TResponse>(CatRetryRule rule, Func<CancellationToken, Task<TResponse>> attempt,
        CancellationToken cancellationToken) where TResponse : ICatResponse
    {
        var pipeline = pipelines.Get(rule.Profile);
        try
        {
            return await pipeline.ExecuteAsync(async token =>
            {
                var response = await attempt(token).ConfigureAwait(false);
                if (rule.ShouldRetry(response))
                {
                    throw new RetryableResponseException<TResponse>(response);
                }

                return response;
            }, cancellationToken).ConfigureAwait(false);
        }
        catch (RetryableResponseException<TResponse> exception)
        {
            return exception.Response;
        }
    }

    private sealed class RetryableResponseException<TResponse>(TResponse response)
        : Exception("The command failed and can be retried.")
    {
        public TResponse Response { get; } = response;
    }
}
