using System.Collections.Generic;

namespace Cat.Scheduling.Abstractions;

/// <summary>
/// Holds the jobs the service declared.
/// </summary>
public interface ICatJobRegistry
{
    /// <summary>
    /// Every declared job.
    /// </summary>
    IReadOnlyList<CatJobRegistration> Jobs { get; }
}
