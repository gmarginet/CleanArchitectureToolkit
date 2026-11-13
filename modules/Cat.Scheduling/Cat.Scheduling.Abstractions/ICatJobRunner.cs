using System.Threading;
using System.Threading.Tasks;

namespace Cat.Scheduling.Abstractions;

/// <summary>
/// Runs a declared job at once, the same way the scheduler runs it at a due time.
/// Use it to test a job without waiting for the schedule, for example from a development endpoint.
/// It sends the service request as the system user of the scheduler, retries as the job says and traces the run.
/// It does not use the claim store, so it runs whatever the other instances do.
/// </summary>
public interface ICatJobRunner
{
    /// <summary>
    /// Runs the job and waits for the outcome. A job that is switched off can be run too.
    /// </summary>
    /// <param name="jobName">The name of the job.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The outcome after the last retry.</returns>
    /// <exception cref="System.ArgumentException">There is no job with that name.</exception>
    Task<CatJobRunResult> RunAsync(string jobName, CancellationToken cancellationToken = default);
}
