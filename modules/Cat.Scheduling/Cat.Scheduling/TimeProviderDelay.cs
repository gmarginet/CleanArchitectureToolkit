using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Scheduling;

/// <summary>
/// Waits on a <see cref="TimeProvider"/>, so a test with a fake clock can move time forward.
/// </summary>
internal static class TimeProviderDelay
{
    // A timer cannot wait longer than about 49 days, so a long wait is split.
    private static readonly TimeSpan LongestWait = TimeSpan.FromDays(7);

    /// <summary>
    /// Waits for the given time. It returns at once when the time is zero or negative.
    /// </summary>
    /// <param name="timeProvider">The clock to wait on.</param>
    /// <param name="delay">How long to wait.</param>
    /// <param name="cancellationToken">Token to cancel the wait.</param>
    /// <returns>A task that completes after the delay.</returns>
    public static async Task WaitAsync(TimeProvider timeProvider, TimeSpan delay, CancellationToken cancellationToken)
    {
        var end = timeProvider.GetUtcNow() + delay;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var remaining = end - timeProvider.GetUtcNow();
            if (remaining <= TimeSpan.Zero)
            {
                return;
            }

            var step = remaining < LongestWait ? remaining : LongestWait;
            await WaitOnceAsync(timeProvider, step, cancellationToken).ConfigureAwait(false);
        }
    }

    private static async Task WaitOnceAsync(TimeProvider timeProvider, TimeSpan step, CancellationToken cancellationToken)
    {
        var completion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var timer = timeProvider.CreateTimer(_ => completion.TrySetResult(true), null, step, Timeout.InfiniteTimeSpan);
        using (cancellationToken.Register(() => completion.TrySetCanceled(cancellationToken)))
        {
            await completion.Task.ConfigureAwait(false);
        }
    }
}
