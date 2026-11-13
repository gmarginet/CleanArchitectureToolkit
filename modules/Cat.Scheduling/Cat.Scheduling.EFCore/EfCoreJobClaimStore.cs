using Cat.Scheduling.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Scheduling.EFCore;

/// <summary>
/// <see cref="ICatJobClaimStore"/> on a <c>DbContext</c> of the service.
/// The unique key on the job name and the due time decides which instance gets the claim:
/// the instance whose insert succeeds runs the job.
/// </summary>
/// <typeparam name="TDbContext">The context that holds the job run table, see <see cref="ModelBuilderExtensions.AddCatScheduling"/>.</typeparam>
internal sealed class EfCoreJobClaimStore<TDbContext> : ICatJobClaimStore
    where TDbContext : DbContext
{
    private readonly IServiceScopeFactory _scopeFactory;

    /// <summary>
    /// Creates the store.
    /// </summary>
    /// <param name="scopeFactory">Opens a scope for every call. The scheduler is a singleton and the context is scoped.</param>
    public EfCoreJobClaimStore(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    /// <inheritdoc />
    public async Task<CatJobClaimResult> TryClaimAsync(string jobName, DateTimeOffset dueTime, DateTimeOffset now, bool allowOverlap,
        TimeSpan deadAfter, CancellationToken cancellationToken = default)
    {
        var due = dueTime.UtcDateTime;
        var started = now.UtcDateTime;

        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TDbContext>();
            var runs = context.Set<CatJobRun>();

            if (await runs.AsNoTracking().AnyAsync(row => row.JobName == jobName && row.DueTime == due, cancellationToken).ConfigureAwait(false))
            {
                return CatJobClaimResult.TakenByOther();
            }

            if (!allowOverlap)
            {
                var deadBefore = (now - deadAfter).UtcDateTime;
                var busy = await runs.AsNoTracking()
                    .AnyAsync(row => row.JobName == jobName && row.Status == CatJobRunStatus.Running && row.StartedAt > deadBefore, cancellationToken)
                    .ConfigureAwait(false);
                if (busy)
                {
                    return CatJobClaimResult.Busy();
                }
            }

            runs.Add(new CatJobRun { JobName = jobName, DueTime = due, Status = CatJobRunStatus.Running, StartedAt = started });
            try
            {
                await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (DbUpdateException)
            {
                // Another instance inserted the row between the check and the insert. The unique key stopped this one.
                // The code asks the database again, so it does not depend on one database provider for the error number.
                if (await ExistsAsync(jobName, due, cancellationToken).ConfigureAwait(false))
                {
                    return CatJobClaimResult.TakenByOther();
                }

                throw;
            }
        }

        return CatJobClaimResult.Claimed(new CatJobClaim(jobName, dueTime, now));
    }

    /// <inheritdoc />
    public async Task CompleteAsync(CatJobClaim claim, CatJobRunResult result, DateTimeOffset finishedAt, CancellationToken cancellationToken = default)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        var due = claim.DueTime.UtcDateTime;
        var row = await context.Set<CatJobRun>().FirstOrDefaultAsync(candidate => candidate.JobName == claim.JobName && candidate.DueTime == due, cancellationToken)
            .ConfigureAwait(false);
        if (row == null)
        {
            return;
        }

        row.Status = result.Status;
        row.ErrorCode = result.ErrorCode;
        row.Attempts = result.Attempts;
        row.FinishedAt = finishedAt.UtcDateTime;
        await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<DateTimeOffset?> GetLastDueTimeAsync(string jobName, CancellationToken cancellationToken = default)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        var last = await context.Set<CatJobRun>().AsNoTracking()
            .Where(row => row.JobName == jobName)
            .OrderByDescending(row => row.DueTime)
            .Select(row => (DateTime?)row.DueTime)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);

        return last.HasValue ? new DateTimeOffset(DateTime.SpecifyKind(last.Value, DateTimeKind.Utc)) : null;
    }

    private async Task<bool> ExistsAsync(string jobName, DateTime due, CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TDbContext>();
        return await context.Set<CatJobRun>().AsNoTracking()
            .AnyAsync(row => row.JobName == jobName && row.DueTime == due, cancellationToken)
            .ConfigureAwait(false);
    }
}
