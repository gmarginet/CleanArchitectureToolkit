using System;

namespace Cat.Scheduling.Abstractions;

/// <summary>
/// The settings of one scheduled job. The code sets them when it declares the job.
/// The configuration section <c>CatScheduling:Jobs:&lt;job name&gt;</c> wins, so whoever runs the service
/// can change a cron expression or switch a job off per environment without a build.
/// </summary>
public class CatJobOptions
{
    /// <summary>
    /// The cron expression. Five fields (minute, hour, day of month, month, day of week) or six when the first field holds seconds.
    /// </summary>
    public string Cron { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the time zone the cron expression is read in, as <see cref="TimeZoneInfo.FindSystemTimeZoneById"/> knows it.
    /// The default is <c>UTC</c>. When daylight saving makes a local time happen twice the job runs once, and when a local time
    /// does not happen the job runs at the first moment after the gap.
    /// </summary>
    public string TimeZoneId { get; set; } = "UTC";

    /// <summary>
    /// Switches the job off when <c>false</c>. A job that is off never runs, but <see cref="ICatJobRunner"/> can still run it at once.
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// What the job does at startup when a due time passed. The default is <see cref="CatMissedRunBehavior.RunOnce"/>.
    /// The service request of the job must be safe to run more than once.
    /// </summary>
    public CatMissedRunBehavior MissedRuns { get; set; } = CatMissedRunBehavior.RunOnce;

    /// <summary>
    /// Lets a new run start while the previous run is still busy. The default is <c>false</c>: the new run is skipped and a warning is logged.
    /// </summary>
    public bool AllowOverlap { get; set; }

    /// <summary>
    /// The time after which a run that never finished counts as dead, for example because its instance crashed.
    /// A dead run no longer blocks the next one. The default is one hour.
    /// </summary>
    public TimeSpan DeadAfter { get; set; } = TimeSpan.FromHours(1);

    /// <summary>
    /// The number of times a failed run is tried again. The default is 0: a failed run waits for the next due time.
    /// A retry is a new attempt for the same due time. It uses the same claim, so two instances never retry the same job together.
    /// </summary>
    public int MaxRetries { get; set; }

    /// <summary>
    /// The wait before a retry. The default is 30 seconds.
    /// </summary>
    public TimeSpan RetryDelay { get; set; } = TimeSpan.FromSeconds(30);

    /// <summary>
    /// Doubles the wait with every retry when <c>true</c>. The default is <c>false</c>.
    /// </summary>
    public bool GrowingRetryDelay { get; set; }
}
