using System;
using System.Collections.Generic;

namespace Cat.Resilience.Abstractions;

/// <summary>
/// All resilience profiles by name. It always holds <see cref="CatResilienceProfile.Internal"/> and
/// <see cref="CatResilienceProfile.External"/> with their code defaults.
/// Configuration under <c>Cat:Resilience:Profiles:{name}</c> wins over code.
/// </summary>
public sealed class CatResilienceOptions
{
    /// <summary>
    /// The configuration section that holds the profiles.
    /// </summary>
    public const string ConfigurationSection = "Cat:Resilience:Profiles";

    /// <summary>
    /// Initializes the options with the two default profiles.
    /// </summary>
    public CatResilienceOptions()
    {
        Profiles = new Dictionary<string, CatResilienceProfileOptions>(StringComparer.OrdinalIgnoreCase)
        {
            [CatResilienceProfile.Internal] = new(),
            [CatResilienceProfile.External] = CreateExternalDefaults()
        };
    }

    /// <summary>
    /// Gets the profiles by name. The name is not case sensitive.
    /// </summary>
    public IDictionary<string, CatResilienceProfileOptions> Profiles { get; }

    /// <summary>
    /// Adds a profile, or changes the profile of that name when it exists. A new profile starts with the defaults of the
    /// <see cref="CatResilienceProfile.Internal"/> profile.
    /// </summary>
    /// <param name="name">The name of the profile.</param>
    /// <param name="configure">Changes the settings of the profile.</param>
    /// <returns>The same options, for chaining.</returns>
    public CatResilienceOptions AddProfile(string name, Action<CatResilienceProfileOptions> configure)
    {
        if (!Profiles.TryGetValue(name, out var profile))
        {
            profile = new CatResilienceProfileOptions();
            Profiles[name] = profile;
        }

        configure(profile);
        return this;
    }

    private static CatResilienceProfileOptions CreateExternalDefaults() => new()
    {
        TotalTimeout = new CatTimeoutOptions { Timeout = TimeSpan.FromSeconds(60) },
        AttemptTimeout = new CatTimeoutOptions { Timeout = TimeSpan.FromSeconds(15) },
        Retry = new CatRetryOptions
        {
            MaxRetryAttempts = 2,
            Delay = TimeSpan.FromSeconds(1),
            UseRetryAfterHeader = true,
            RequireIdempotencyKeyForUnsafeMethods = true
        },
        CircuitBreaker = new CatCircuitBreakerOptions
        {
            FailureRatio = 0.5,
            MinimumThroughput = 10,
            SamplingDuration = TimeSpan.FromSeconds(60),
            BreakDuration = TimeSpan.FromSeconds(30)
        }
    };
}
