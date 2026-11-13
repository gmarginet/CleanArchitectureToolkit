using System.Collections.Generic;
using Cat.Scheduling.Abstractions;

namespace Cat.Scheduling;

/// <summary>
/// Default <see cref="ICatJobRegistry"/>.
/// </summary>
internal sealed class JobRegistry : ICatJobRegistry
{
    /// <summary>
    /// Creates the registry.
    /// </summary>
    /// <param name="jobs">The declared jobs.</param>
    public JobRegistry(IReadOnlyList<CatJobRegistration> jobs)
    {
        Jobs = jobs;
    }

    /// <inheritdoc />
    public IReadOnlyList<CatJobRegistration> Jobs { get; }
}
