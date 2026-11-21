using System;
using System.Collections.Generic;
using Cat.Resilience.Abstractions;

namespace Cat.Scheduling.Resilience;

/// <summary>
/// Says which resilience profile runs the tries of a job.
/// </summary>
public sealed class CatSchedulingResilienceOptions
{
    /// <summary>
    /// Gets or sets the profile for every job that has no profile of its own.
    /// The default is <see cref="CatResilienceProfile.Internal"/>.
    /// </summary>
    public string DefaultProfile { get; set; } = CatResilienceProfile.Internal;

    /// <summary>
    /// Gets the profile of a job by job name. The job name is not case sensitive.
    /// </summary>
    public IDictionary<string, string> JobProfiles { get; } =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
}
