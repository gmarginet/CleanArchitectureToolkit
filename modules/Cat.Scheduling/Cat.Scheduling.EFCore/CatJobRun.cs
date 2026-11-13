using Cat.Scheduling.Abstractions;

namespace Cat.Scheduling.EFCore;

/// <summary>
/// One row of the job run table: the claim and the outcome of a run of a job at a due time.
/// The job name and the due time together are the key, so a second claim for the same due time fails.
/// All times are UTC.
/// </summary>
public class CatJobRun
{
    /// <summary>
    /// The name of the job.
    /// </summary>
    public string JobName { get; set; } = string.Empty;

    /// <summary>
    /// The due time the run is for.
    /// </summary>
    public DateTime DueTime { get; set; }

    /// <summary>
    /// Running, succeeded or failed.
    /// </summary>
    public CatJobRunStatus Status { get; set; }

    /// <summary>
    /// When the run started.
    /// </summary>
    public DateTime StartedAt { get; set; }

    /// <summary>
    /// When the run ended. <c>null</c> while it runs.
    /// </summary>
    public DateTime? FinishedAt { get; set; }

    /// <summary>
    /// The code of the first error of a failed run. <c>null</c> when it did not fail.
    /// </summary>
    public string? ErrorCode { get; set; }

    /// <summary>
    /// The number of times the service request ran, with the retries.
    /// </summary>
    public int Attempts { get; set; }
}
