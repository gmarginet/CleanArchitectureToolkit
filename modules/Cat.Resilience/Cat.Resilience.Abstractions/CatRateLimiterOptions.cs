namespace Cat.Resilience.Abstractions;

/// <summary>
/// Settings of the rate limiter of a profile. It limits the calls that run at the same time.
/// </summary>
public sealed class CatRateLimiterOptions
{
    /// <summary>
    /// Gets or sets how many calls may run at the same time. The default is 1000.
    /// </summary>
    public int PermitLimit { get; set; } = 1000;

    /// <summary>
    /// Gets or sets how many calls may wait for a free place. The default is 0, so a call over the limit fails at once.
    /// </summary>
    public int QueueLimit { get; set; }
}
