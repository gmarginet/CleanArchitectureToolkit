using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Scheduling.Abstractions;

/// <summary>
/// Runs the tries of a job. A developer registers an implementation to add a retry, such as the one of
/// <c>Cat.Scheduling.Resilience</c>. Without one, a job runs once and waits for its next due time when it fails.
/// </summary>
public interface ICatJobAttemptExecutor
{
    /// <summary>
    /// Calls <paramref name="attempt"/> once or more, as the implementation decides, and returns the result of the last call.
    /// Every call is a whole try, with its own scope and its own system user.
    /// </summary>
    /// <param name="jobName">The name of the job.</param>
    /// <param name="attempt">Runs one try. A result with <see cref="CatJobAttemptResult.CanRetry"/> says that a new try can help.</param>
    /// <param name="cancellationToken">Cancels the work.</param>
    /// <returns>The result of the last try.</returns>
    Task<CatJobAttemptResult> ExecuteAsync(string jobName,
        Func<CancellationToken, Task<CatJobAttemptResult>> attempt, CancellationToken cancellationToken);
}
