using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Scheduling.Abstractions;

namespace Cat.Scheduling;

/// <summary>
/// <see cref="ICatJobClaimStore"/> in memory. It is right for a service with one instance.
/// The claims are gone after a restart, so a missed run cannot be found at startup.
/// </summary>
internal sealed class InMemoryJobClaimStore : ICatJobClaimStore
{
    private readonly object _lock = new object();
    private readonly Dictionary<string, Run> _runs = new Dictionary<string, Run>(StringComparer.Ordinal);

    /// <inheritdoc />
    public Task<CatJobClaimResult> TryClaimAsync(string jobName, DateTimeOffset dueTime, DateTimeOffset now, bool allowOverlap,
        TimeSpan deadAfter, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            if (_runs.ContainsKey(Key(jobName, dueTime)))
            {
                return Task.FromResult(CatJobClaimResult.TakenByOther());
            }

            if (!allowOverlap)
            {
                foreach (var run in _runs.Values)
                {
                    if (run.JobName == jobName && run.Status == CatJobRunStatus.Running && run.StartedAt > now - deadAfter)
                    {
                        return Task.FromResult(CatJobClaimResult.Busy());
                    }
                }
            }

            _runs[Key(jobName, dueTime)] = new Run(jobName, dueTime, now);
            return Task.FromResult(CatJobClaimResult.Claimed(new CatJobClaim(jobName, dueTime, now)));
        }
    }

    /// <inheritdoc />
    public Task CompleteAsync(CatJobClaim claim, CatJobRunResult result, DateTimeOffset finishedAt, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            if (_runs.TryGetValue(Key(claim.JobName, claim.DueTime), out var run))
            {
                run.Status = result.Status;
            }
        }

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task<DateTimeOffset?> GetLastDueTimeAsync(string jobName, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            DateTimeOffset? last = null;
            foreach (var run in _runs.Values)
            {
                if (run.JobName == jobName && (last == null || run.DueTime > last))
                {
                    last = run.DueTime;
                }
            }

            return Task.FromResult(last);
        }
    }

    private static string Key(string jobName, DateTimeOffset dueTime) => jobName + "|" + dueTime.UtcTicks;

    private sealed class Run
    {
        public Run(string jobName, DateTimeOffset dueTime, DateTimeOffset startedAt)
        {
            JobName = jobName;
            DueTime = dueTime;
            StartedAt = startedAt;
        }

        public string JobName { get; }

        public DateTimeOffset DueTime { get; }

        public DateTimeOffset StartedAt { get; }

        public CatJobRunStatus Status { get; set; } = CatJobRunStatus.Running;
    }
}
