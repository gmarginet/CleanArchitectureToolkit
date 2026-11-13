namespace Cat.Scheduling.Abstractions;

/// <summary>
/// The state of one run of a job.
/// </summary>
public enum CatJobRunStatus
{
    /// <summary>
    /// The run started and has not finished.
    /// </summary>
    Running = 0,

    /// <summary>
    /// The service request returned a succeeded response.
    /// </summary>
    Succeeded = 1,

    /// <summary>
    /// The service request returned a failed response or threw an exception, also after the last retry.
    /// </summary>
    Failed = 2
}
