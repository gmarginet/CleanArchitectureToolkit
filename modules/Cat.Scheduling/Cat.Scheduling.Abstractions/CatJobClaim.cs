using System;

namespace Cat.Scheduling.Abstractions;

/// <summary>
/// The right to run a job for one due time. The instance that holds it runs the job.
/// </summary>
public class CatJobClaim
{
    /// <summary>
    /// Creates a claim.
    /// </summary>
    /// <param name="jobName">The name of the job.</param>
    /// <param name="dueTime">The due time the claim is for.</param>
    /// <param name="startedAt">When the run started.</param>
    public CatJobClaim(string jobName, DateTimeOffset dueTime, DateTimeOffset startedAt)
    {
        JobName = jobName;
        DueTime = dueTime;
        StartedAt = startedAt;
    }

    /// <summary>
    /// The name of the job.
    /// </summary>
    public string JobName { get; }

    /// <summary>
    /// The due time the claim is for.
    /// </summary>
    public DateTimeOffset DueTime { get; }

    /// <summary>
    /// When the run started.
    /// </summary>
    public DateTimeOffset StartedAt { get; }
}
