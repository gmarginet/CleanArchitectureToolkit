using System;
using System.Collections.Generic;
using Cat.Responses.Abstractions;

namespace Cat.Resilience.Commands;

/// <summary>
/// Says how one command type is retried: through which profile, and which failed responses count as a reason to try again.
/// </summary>
public sealed class CatRetryRule
{
    private readonly HashSet<string> _retryOn = new HashSet<string>(StringComparer.Ordinal)
    {
        typeof(CatResponseType.Failed.InternalServerError).Name
    };

    internal CatRetryRule(string profile)
    {
        Profile = profile;
    }

    /// <summary>
    /// Gets the name of the resilience profile that runs the tries.
    /// </summary>
    public string Profile { get; }

    /// <summary>
    /// Tries again on this failed response type too. The default is <c>InternalServerError</c> only,
    /// the same table as the event processor.
    /// </summary>
    /// <typeparam name="TFailure">The failed response type, such as <see cref="CatResponseType.Failed.Conflict"/>.</typeparam>
    /// <returns>The same rule, for chaining.</returns>
    public CatRetryRule RetryOn<TFailure>() where TFailure : CatResponseType.Failed
    {
        _retryOn.Add(typeof(TFailure).Name);
        return this;
    }

    /// <summary>
    /// Never tries again on this failed response type, and returns the response at once.
    /// </summary>
    /// <typeparam name="TFailure">The failed response type, such as <see cref="CatResponseType.Failed.InternalServerError"/>.</typeparam>
    /// <returns>The same rule, for chaining.</returns>
    public CatRetryRule NeverRetryOn<TFailure>() where TFailure : CatResponseType.Failed
    {
        _retryOn.Remove(typeof(TFailure).Name);
        return this;
    }

    internal bool ShouldRetry(ICatResponse response)
    {
        return !response.IsSucceeded && _retryOn.Contains(response.Type.GetType().Name);
    }
}
