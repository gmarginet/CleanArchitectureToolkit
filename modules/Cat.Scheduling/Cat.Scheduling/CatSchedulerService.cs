using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Scheduling.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cat.Scheduling;

/// <summary>
/// Hosted service that runs one loop per enabled job. A loop waits for the next due time, claims it and runs the job.
/// </summary>
internal sealed class CatSchedulerService : BackgroundService
{
    // A cron expression that fires every second would give a huge number of missed due times. Stop counting here.
    private const int MaximumMissedCount = 100_000;

    private readonly ICatJobRegistry _registry;
    private readonly ICatJobClaimStore _store;
    private readonly CatJobRunner _runner;
    private readonly TimeProvider _timeProvider;
    private readonly ILogger<CatSchedulerService> _logger;

    /// <summary>
    /// Creates the service.
    /// </summary>
    /// <param name="registry">Holds the declared jobs.</param>
    /// <param name="store">Decides which instance runs a job at a due time.</param>
    /// <param name="runner">Runs a job.</param>
    /// <param name="timeProvider">The clock.</param>
    /// <param name="logger">Logs skipped runs and failures of the scheduler itself.</param>
    public CatSchedulerService(ICatJobRegistry registry, ICatJobClaimStore store, CatJobRunner runner, TimeProvider timeProvider,
        ILogger<CatSchedulerService> logger)
    {
        _registry = registry;
        _store = store;
        _runner = runner;
        _timeProvider = timeProvider;
        _logger = logger;
    }

    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var loops = new List<Task>();
        foreach (var job in _registry.Jobs.Where(candidate => candidate.Options.Enabled))
        {
            var schedule = CronSchedule.Create(job.Name, job.Options);
            loops.Add(Task.Run(() => RunLoopAsync(job, schedule, stoppingToken), stoppingToken));
        }

        try
        {
            await Task.WhenAll(loops).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // The service is stopping.
        }
    }

    private async Task RunLoopAsync(CatJobRegistration job, CronSchedule schedule, CancellationToken cancellationToken)
    {
        // A run does not block the loop, so the next due time still comes while a run is busy.
        // The claim store then decides: skip the new run, or run it too when the job allows overlap.
        var runs = new List<Task>();
        try
        {
            var cursor = _timeProvider.GetUtcNow();

            try
            {
                if (job.Options.MissedRuns == CatMissedRunBehavior.RunOnce)
                {
                    var missed = await FindMissedDueTimeAsync(job, schedule, cursor, cancellationToken).ConfigureAwait(false);
                    if (missed != null)
                    {
                        _logger.LogInformation("Job {Job} missed the due time {DueTime}. It runs once now.", job.Name, missed);
                        runs.Add(ExecuteSafelyAsync(job, missed.Value, cancellationToken));
                    }
                }
            }
            catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(exception, "The scheduler could not check job {Job} for missed runs.", job.Name);
            }

            while (!cancellationToken.IsCancellationRequested)
            {
                var next = schedule.GetNext(cursor);
                if (next == null)
                {
                    _logger.LogWarning("Job {Job} has no next due time. The scheduler stops its loop.", job.Name);
                    return;
                }

                await TimeProviderDelay.WaitAsync(_timeProvider, next.Value - _timeProvider.GetUtcNow(), cancellationToken).ConfigureAwait(false);
                cursor = next.Value;

                runs.RemoveAll(run => run.IsCompleted);
                runs.Add(ExecuteSafelyAsync(job, next.Value, cancellationToken));
            }
        }
        finally
        {
            // The service stops. Let the runs that are busy end, they got the same cancellation token.
            try
            {
                await Task.WhenAll(runs).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // The runs were canceled with the service.
            }
        }
    }

    private async Task ExecuteSafelyAsync(CatJobRegistration job, DateTimeOffset dueTime, CancellationToken cancellationToken)
    {
        try
        {
            await ExecuteDueAsync(job, dueTime, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
        {
            // One bad run must not stop the loop. The next due time still comes.
            _logger.LogError(exception, "The scheduler failed on job {Job} at {DueTime}.", job.Name, dueTime);
        }
    }

    private async Task<DateTimeOffset?> FindMissedDueTimeAsync(CatJobRegistration job, CronSchedule schedule, DateTimeOffset now,
        CancellationToken cancellationToken)
    {
        var last = await _store.GetLastDueTimeAsync(job.Name, cancellationToken).ConfigureAwait(false);
        if (last == null)
        {
            // The job never ran, so nothing was missed. It starts counting from now.
            return null;
        }

        DateTimeOffset? latest = null;
        var cursor = last.Value;
        for (var count = 0; count < MaximumMissedCount; count++)
        {
            var next = schedule.GetNext(cursor);
            if (next == null || next > now)
            {
                break;
            }

            latest = next;
            cursor = next.Value;
        }

        return latest;
    }

    private async Task ExecuteDueAsync(CatJobRegistration job, DateTimeOffset dueTime, CancellationToken cancellationToken)
    {
        var claimResult = await _store.TryClaimAsync(job.Name, dueTime, _timeProvider.GetUtcNow(), job.Options.AllowOverlap,
            job.Options.DeadAfter, cancellationToken).ConfigureAwait(false);

        switch (claimResult.Status)
        {
            case CatJobClaimStatus.TakenByOther:
                _logger.LogDebug("Job {Job} at {DueTime} is run by another instance.", job.Name, dueTime);
                return;
            case CatJobClaimStatus.Busy:
                _logger.LogWarning("Job {Job} at {DueTime} is skipped, because the previous run is still busy.", job.Name, dueTime);
                return;
        }

        var claim = claimResult.Claim!;
        CatJobRunResult result;
        try
        {
            result = await _runner.RunAsync(job, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            // The service stops in the middle of a run. Record it, so the claim does not stay busy until it counts as dead.
            await _store.CompleteAsync(claim, new CatJobRunResult(CatJobRunStatus.Failed, "Canceled", 1), _timeProvider.GetUtcNow(),
                CancellationToken.None).ConfigureAwait(false);
            throw;
        }

        await _store.CompleteAsync(claim, result, _timeProvider.GetUtcNow(), cancellationToken).ConfigureAwait(false);
    }
}
