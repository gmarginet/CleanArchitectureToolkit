using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Scheduling.Abstractions;

/// <summary>
/// Makes sure that only one instance of a service runs a job at a due time, and remembers how every run ended.
/// The module ships a store in memory, for a service with one instance. The optional EF Core project keeps the claims
/// in the database of the service. Write your own store, for example on a blob lease, and register it before the module.
/// </summary>
public interface ICatJobClaimStore
{
    /// <summary>
    /// Tries to claim the job for a due time. Exactly one caller gets <see cref="CatJobClaimStatus.Claimed"/> for the same job and due time.
    /// </summary>
    /// <param name="jobName">The name of the job.</param>
    /// <param name="dueTime">The due time to claim.</param>
    /// <param name="now">The current time.</param>
    /// <param name="allowOverlap">When <c>false</c> and a run that started less than <paramref name="deadAfter"/> ago has not finished, the result is <see cref="CatJobClaimStatus.Busy"/>.</param>
    /// <param name="deadAfter">The time after which a run that never finished counts as dead.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The outcome of the request for the claim.</returns>
    Task<CatJobClaimResult> TryClaimAsync(string jobName, DateTimeOffset dueTime, DateTimeOffset now, bool allowOverlap,
        TimeSpan deadAfter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Records how a claimed run ended.
    /// </summary>
    /// <param name="claim">The claim of the run.</param>
    /// <param name="result">The outcome of the run.</param>
    /// <param name="finishedAt">When the run ended.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that completes when the outcome is recorded.</returns>
    Task CompleteAsync(CatJobClaim claim, CatJobRunResult result, DateTimeOffset finishedAt, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the latest due time that was claimed for a job. The scheduler uses it at startup to find missed runs.
    /// </summary>
    /// <param name="jobName">The name of the job.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The latest claimed due time, or <c>null</c> when the job never ran.</returns>
    Task<DateTimeOffset?> GetLastDueTimeAsync(string jobName, CancellationToken cancellationToken = default);
}
