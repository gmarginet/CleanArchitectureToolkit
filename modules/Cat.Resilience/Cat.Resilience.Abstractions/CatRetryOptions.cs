using System;

namespace Cat.Resilience.Abstractions;

/// <summary>
/// Settings of the retry of a profile.
/// </summary>
public sealed class CatRetryOptions
{
    /// <summary>
    /// Gets or sets how many times a failed call is tried again. The default is 3. Zero switches the retry off.
    /// </summary>
    public int MaxRetryAttempts { get; set; } = 3;

    /// <summary>
    /// Gets or sets the delay before the first retry. The default is 2 seconds.
    /// </summary>
    public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(2);

    /// <summary>
    /// Gets or sets how the delay grows. The default is <see cref="CatBackoffType.Exponential"/>.
    /// </summary>
    public CatBackoffType BackoffType { get; set; } = CatBackoffType.Exponential;

    /// <summary>
    /// Gets or sets whether a random part is added to the delay, so many callers do not retry at the same moment.
    /// The default is true.
    /// </summary>
    public bool UseJitter { get; set; } = true;

    /// <summary>
    /// Gets or sets whether the <c>Retry-After</c> header of a response sets the delay. The default is false.
    /// It has an effect on an HTTP call only.
    /// </summary>
    public bool UseRetryAfterHeader { get; set; }

    /// <summary>
    /// Gets or sets whether a <c>POST</c>, <c>PUT</c>, <c>PATCH</c> or <c>DELETE</c> is retried only when the request carries
    /// the idempotency key header. The default is false.
    /// It has an effect on an HTTP call only.
    /// </summary>
    public bool RequireIdempotencyKeyForUnsafeMethods { get; set; }

    /// <summary>
    /// Gets or sets the name of the idempotency key header. The default is <c>Idempotency-Key</c>.
    /// </summary>
    public string IdempotencyHeaderName { get; set; } = "Idempotency-Key";
}
