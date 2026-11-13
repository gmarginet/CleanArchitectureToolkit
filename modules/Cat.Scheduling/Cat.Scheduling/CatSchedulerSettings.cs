namespace Cat.Scheduling;

/// <summary>
/// The settings that are not per job.
/// </summary>
internal sealed class CatSchedulerSettings
{
    /// <summary>
    /// Creates the settings.
    /// </summary>
    /// <param name="systemUserName">The name of the system user every job runs as.</param>
    public CatSchedulerSettings(string systemUserName)
    {
        SystemUserName = systemUserName;
    }

    /// <summary>
    /// The name of the system user every job runs as.
    /// </summary>
    public string SystemUserName { get; }
}
