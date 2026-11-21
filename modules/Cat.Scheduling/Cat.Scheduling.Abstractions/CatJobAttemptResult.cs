namespace Cat.Scheduling.Abstractions;

/// <summary>
/// The outcome of one try of a job, and whether a failed try is worth trying again.
/// </summary>
public sealed class CatJobAttemptResult
{
    private CatJobAttemptResult(string? errorCode, bool canRetry)
    {
        ErrorCode = errorCode;
        CanRetry = canRetry;
    }

    /// <summary>
    /// Gets the result of a try that succeeded.
    /// </summary>
    public static CatJobAttemptResult Succeeded { get; } = new CatJobAttemptResult(null, false);

    /// <summary>
    /// Gets the code of the first error of a failed response, or the exception type name. <c>null</c> when the try succeeded.
    /// </summary>
    public string? ErrorCode { get; }

    /// <summary>
    /// Gets whether a new try can help. It is <c>true</c> for an <c>InternalServerError</c> response and for an exception,
    /// and <c>false</c> for every other failed response, such as <c>BadRequest</c> or <c>NotFound</c>.
    /// </summary>
    public bool CanRetry { get; }

    /// <summary>
    /// Creates the result of a try that failed.
    /// </summary>
    /// <param name="errorCode">The code of the first error, or the exception type name.</param>
    /// <param name="canRetry">Whether a new try can help.</param>
    /// <returns>The result.</returns>
    public static CatJobAttemptResult Failed(string errorCode, bool canRetry) => new CatJobAttemptResult(errorCode, canRetry);
}
