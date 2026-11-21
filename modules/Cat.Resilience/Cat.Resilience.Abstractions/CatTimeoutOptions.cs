using System;

namespace Cat.Resilience.Abstractions;

/// <summary>
/// A timeout setting, used for the total timeout and for the timeout per try.
/// </summary>
public sealed class CatTimeoutOptions
{
    /// <summary>
    /// Gets or sets the time after which the call is cancelled.
    /// </summary>
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
}
