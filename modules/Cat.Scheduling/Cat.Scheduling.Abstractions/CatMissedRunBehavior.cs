namespace Cat.Scheduling.Abstractions;

/// <summary>
/// What a job does at startup when a due time passed while the service was not running.
/// </summary>
public enum CatMissedRunBehavior
{
    /// <summary>
    /// Run the job once for the latest missed due time. Not once for every missed time.
    /// </summary>
    RunOnce = 0,

    /// <summary>
    /// Do not run the missed due times. The job waits for the next one.
    /// </summary>
    Skip = 1
}
