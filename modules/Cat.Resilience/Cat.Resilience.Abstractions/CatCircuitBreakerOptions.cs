using System;

namespace Cat.Resilience.Abstractions;

/// <summary>
/// Settings of the circuit breaker of a profile.
/// </summary>
public sealed class CatCircuitBreakerOptions
{
    /// <summary>
    /// Gets or sets the share of failed calls, from 0 to 1, that opens the circuit. The default is 0.1.
    /// </summary>
    public double FailureRatio { get; set; } = 0.1;

    /// <summary>
    /// Gets or sets how many calls must happen in the sampling duration before the circuit may open. The default is 100.
    /// </summary>
    public int MinimumThroughput { get; set; } = 100;

    /// <summary>
    /// Gets or sets the period in which the failures are counted. The default is 30 seconds.
    /// </summary>
    public TimeSpan SamplingDuration { get; set; } = TimeSpan.FromSeconds(30);

    /// <summary>
    /// Gets or sets how long the circuit stays open before it lets a test call through. The default is 5 seconds.
    /// </summary>
    public TimeSpan BreakDuration { get; set; } = TimeSpan.FromSeconds(5);
}
