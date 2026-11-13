using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Scheduling.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.Users.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.Scheduling;

/// <summary>
/// Default <see cref="ICatJobRunner"/>. The scheduler uses it for every run too, so a run from a development endpoint
/// behaves like a run at a due time.
/// </summary>
internal sealed class CatJobRunner : ICatJobRunner
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ICatJobRegistry _registry;
    private readonly CatSchedulerSettings _settings;
    private readonly TimeProvider _timeProvider;
    private readonly ILogger<CatJobRunner> _logger;

    /// <summary>
    /// Creates the runner.
    /// </summary>
    /// <param name="scopeFactory">Opens a scope for every attempt, because the service request processor is scoped.</param>
    /// <param name="registry">Holds the declared jobs.</param>
    /// <param name="settings">Holds the name of the system user.</param>
    /// <param name="timeProvider">The clock, for the wait between retries.</param>
    /// <param name="logger">Logs the outcome of every attempt.</param>
    public CatJobRunner(IServiceScopeFactory scopeFactory, ICatJobRegistry registry, CatSchedulerSettings settings,
        TimeProvider timeProvider, ILogger<CatJobRunner> logger)
    {
        _scopeFactory = scopeFactory;
        _registry = registry;
        _settings = settings;
        _timeProvider = timeProvider;
        _logger = logger;
    }

    /// <inheritdoc />
    public Task<CatJobRunResult> RunAsync(string jobName, CancellationToken cancellationToken = default)
    {
        var job = _registry.Jobs.FirstOrDefault(candidate => string.Equals(candidate.Name, jobName, StringComparison.OrdinalIgnoreCase));
        if (job == null)
        {
            throw new ArgumentException($"There is no job named {jobName}.", nameof(jobName));
        }

        return RunAsync(job, cancellationToken);
    }

    /// <summary>
    /// Runs a job, with its retries, and traces and counts the run.
    /// </summary>
    /// <param name="job">The job to run.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The outcome after the last retry.</returns>
    public async Task<CatJobRunResult> RunAsync(CatJobRegistration job, CancellationToken cancellationToken)
    {
        using var activity = CatSchedulingTelemetry.ActivitySource.StartActivity("Cat.Scheduling.Run " + job.Name);
        activity?.SetTag("cat.scheduling.job", job.Name);

        var options = job.Options;
        var attempts = 0;
        string? errorCode;
        while (true)
        {
            attempts++;
            errorCode = await AttemptAsync(job, attempts, cancellationToken).ConfigureAwait(false);
            if (errorCode == null || attempts > options.MaxRetries)
            {
                break;
            }

            var factor = options.GrowingRetryDelay ? 1L << Math.Min(attempts - 1, 20) : 1L;
            await TimeProviderDelay.WaitAsync(_timeProvider, TimeSpan.FromTicks(options.RetryDelay.Ticks * factor), cancellationToken)
                .ConfigureAwait(false);
        }

        var status = errorCode == null ? CatJobRunStatus.Succeeded : CatJobRunStatus.Failed;
        activity?.SetTag("cat.scheduling.attempts", attempts);
        if (errorCode != null)
        {
            activity?.SetStatus(ActivityStatusCode.Error, errorCode);
        }

        CatSchedulingTelemetry.RecordRun(job.Name, status, _timeProvider.GetUtcNow());
        return new CatJobRunResult(status, errorCode, attempts);
    }

    private async Task<string?> AttemptAsync(CatJobRegistration job, int attempt, CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();

        // Background work has no HTTP request, so the job runs as a named system user and ICatUser always has a value.
        var accessor = scope.ServiceProvider.GetService<ICatUserAccessor>();
        if (accessor != null)
        {
            accessor.User = CatUser.System(_settings.SystemUserName);
        }

        try
        {
            var processor = scope.ServiceProvider.GetRequiredService<ICatServiceRequestProcessor>();
            var response = await processor.ProcessAsync(job.RequestFactory(), cancellationToken).ConfigureAwait(false);
            if (response.IsSucceeded)
            {
                _logger.LogInformation("Job {Job} succeeded on attempt {Attempt}.", job.Name, attempt);
                return null;
            }

            var codes = string.Join(", ", response.ErrorList.Select(error => error.Code));
            _logger.LogWarning("Job {Job} failed on attempt {Attempt} with the response {ErrorCodes}.", job.Name, attempt, codes);
            return response.ErrorList.Count > 0 ? response.ErrorList[0].Code : "Failed";
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Job {Job} threw on attempt {Attempt}.", job.Name, attempt);
            return exception.GetType().Name;
        }
    }
}
