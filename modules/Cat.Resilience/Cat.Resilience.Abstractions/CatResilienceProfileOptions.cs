using System;

namespace Cat.Resilience.Abstractions;

/// <summary>
/// The settings of one resilience profile: a rate limiter, a total timeout, a retry, a circuit breaker and a timeout per try.
/// The defaults are those of the <see cref="CatResilienceProfile.Internal"/> profile.
/// </summary>
public sealed class CatResilienceProfileOptions
{
    /// <summary>
    /// Gets or sets the rate limiter. It is the outermost strategy.
    /// </summary>
    public CatRateLimiterOptions RateLimiter { get; set; } = new();

    /// <summary>
    /// Gets or sets the timeout for the whole call, including every retry.
    /// </summary>
    public CatTimeoutOptions TotalTimeout { get; set; } = new() { Timeout = TimeSpan.FromSeconds(30) };

    /// <summary>
    /// Gets or sets the retry.
    /// </summary>
    public CatRetryOptions Retry { get; set; } = new();

    /// <summary>
    /// Gets or sets the circuit breaker. Its state is kept per registered client and per process.
    /// </summary>
    public CatCircuitBreakerOptions CircuitBreaker { get; set; } = new();

    /// <summary>
    /// Gets or sets the timeout for one try.
    /// </summary>
    public CatTimeoutOptions AttemptTimeout { get; set; } = new() { Timeout = TimeSpan.FromSeconds(10) };
}
