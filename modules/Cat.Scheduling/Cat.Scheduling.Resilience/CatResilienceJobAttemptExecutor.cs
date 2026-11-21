using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Resilience.Abstractions;
using Cat.Scheduling.Abstractions;

namespace Cat.Scheduling.Resilience;

/// <summary>
/// Runs every try of a job inside the pipeline of its resilience profile.
/// A try that says it can be retried becomes an exception inside the pipeline, so the profile retries it
/// and counts it for its circuit breaker. After the last retry the result of the last try comes back.
/// </summary>
internal sealed class CatResilienceJobAttemptExecutor(
    ICatResiliencePipelines pipelines,
    CatSchedulingResilienceOptions options) : ICatJobAttemptExecutor
{
    /// <inheritdoc />
    public async Task<CatJobAttemptResult> ExecuteAsync(string jobName,
        Func<CancellationToken, Task<CatJobAttemptResult>> attempt, CancellationToken cancellationToken)
    {
        var profile = options.JobProfiles.TryGetValue(jobName, out var jobProfile) ? jobProfile : options.DefaultProfile;
        var pipeline = pipelines.Get(profile);

        try
        {
            return await pipeline.ExecuteAsync(async token =>
            {
                var result = await attempt(token).ConfigureAwait(false);
                if (result.CanRetry)
                {
                    throw new RetryableAttemptException(result);
                }

                return result;
            }, cancellationToken).ConfigureAwait(false);
        }
        catch (RetryableAttemptException exception)
        {
            return exception.Result;
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (Exception exception)
        {
            // The pipeline itself said no, for example because its circuit is open or a try timed out.
            return CatJobAttemptResult.Failed(exception.GetType().Name, false);
        }
    }

    private sealed class RetryableAttemptException(CatJobAttemptResult result) : Exception("The try of the job failed and can be retried.")
    {
        public CatJobAttemptResult Result { get; } = result;
    }
}
