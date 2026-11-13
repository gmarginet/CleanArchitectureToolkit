namespace Cat.Scheduling.Abstractions;

/// <summary>
/// Why a caller did or did not get the claim of a job.
/// </summary>
public enum CatJobClaimStatus
{
    /// <summary>
    /// The caller got the claim and runs the job.
    /// </summary>
    Claimed = 0,

    /// <summary>
    /// Another instance claimed this due time. The caller does nothing.
    /// </summary>
    TakenByOther = 1,

    /// <summary>
    /// The previous run is still busy and the job does not allow overlap. The caller skips the run and logs a warning.
    /// </summary>
    Busy = 2
}
