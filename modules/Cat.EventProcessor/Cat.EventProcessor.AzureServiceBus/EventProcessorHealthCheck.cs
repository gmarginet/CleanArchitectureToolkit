using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cat.EventProcessor.AzureServiceBus;

/// <summary>
/// Health check of the listeners. It is unhealthy when a listener has stopped, for example after a fatal error,
/// and degraded for a minute after a listener reported an error while it keeps processing. The Azure SDK restarts the connection by itself.
/// </summary>
internal sealed class EventProcessorHealthCheck : IHealthCheck
{
    private static readonly TimeSpan DegradedWindow = TimeSpan.FromMinutes(1);

    private readonly ListenerStatus _status;

    /// <summary>
    /// Creates the health check.
    /// </summary>
    /// <param name="status">The state of the listeners.</param>
    public EventProcessorHealthCheck(ListenerStatus status)
    {
        _status = status;
    }

    /// <inheritdoc />
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var stopped = _status.StoppedCount;
        if (stopped > 0)
        {
            return Task.FromResult(HealthCheckResult.Unhealthy($"{stopped} of {_status.Count} listeners are not processing messages."));
        }

        if (_status.LastError is { } lastError && DateTimeOffset.UtcNow - lastError < DegradedWindow)
        {
            return Task.FromResult(HealthCheckResult.Degraded("A listener reported an error in the last minute."));
        }

        return Task.FromResult(HealthCheckResult.Healthy($"{_status.Count} listeners are processing messages."));
    }
}
