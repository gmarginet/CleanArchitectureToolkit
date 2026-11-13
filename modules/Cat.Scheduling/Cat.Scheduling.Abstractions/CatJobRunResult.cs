namespace Cat.Scheduling.Abstractions;

/// <summary>
/// The outcome of a run of a job, after the last retry.
/// </summary>
public class CatJobRunResult
{
    /// <summary>
    /// Creates a result.
    /// </summary>
    /// <param name="status">Succeeded or failed.</param>
    /// <param name="errorCode">The code of the first error of a failed response, or the exception type name. <c>null</c> when it succeeded.</param>
    /// <param name="attempts">The number of times the service request ran, at least 1.</param>
    public CatJobRunResult(CatJobRunStatus status, string? errorCode, int attempts)
    {
        Status = status;
        ErrorCode = errorCode;
        Attempts = attempts;
    }

    /// <summary>
    /// Succeeded or failed.
    /// </summary>
    public CatJobRunStatus Status { get; }

    /// <summary>
    /// The code of the first error of a failed response, or the exception type name. <c>null</c> when it succeeded.
    /// </summary>
    public string? ErrorCode { get; }

    /// <summary>
    /// The number of times the service request ran, at least 1.
    /// </summary>
    public int Attempts { get; }
}
