using System.Diagnostics.Metrics;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cat.Messaging.AzureServiceBus;

/// <summary>
/// Reads the dead letter counts on an interval and publishes them as the gauge <c>cat.messaging.dead_letters</c>
/// on the meter <c>Cat.Messaging</c>. A dashboard that listens to the meter, such as the Aspire dashboard, shows it.
/// </summary>
internal sealed class DeadLetterMetricsService : BackgroundService
{
    /// <summary>
    /// The name of the meter.
    /// </summary>
    public const string MeterName = "Cat.Messaging";

    private readonly ServiceBusAdministrationClient _admin;
    private readonly IOptions<CatDeadLetterMetricsOptions> _options;
    private readonly ILogger<DeadLetterMetricsService> _logger;
    private readonly Meter _meter = new(MeterName);
    private volatile IReadOnlyDictionary<string, long> _counts = new Dictionary<string, long>();

    /// <summary>
    /// Creates the service.
    /// </summary>
    /// <param name="admin">The administration client that reads the counts.</param>
    /// <param name="options">The entities to watch.</param>
    /// <param name="logger">The logger.</param>
    public DeadLetterMetricsService(ServiceBusAdministrationClient admin, IOptions<CatDeadLetterMetricsOptions> options, ILogger<DeadLetterMetricsService> logger)
    {
        _admin = admin;
        _options = options;
        _logger = logger;

        _meter.CreateObservableGauge(
            "cat.messaging.dead_letters",
            () => _counts.Select(count => new Measurement<long>(count.Value, new KeyValuePair<string, object?>("entity", count.Key))),
            unit: "{message}",
            description: "The number of dead letter messages per queue or subscription.");
    }

    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _counts = await ReadCountsAsync(stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                break;
            }
            catch (Exception exception)
            {
                _logger.LogWarning(exception, "Reading the dead letter counts failed. The last counts stay.");
            }

            try
            {
                await Task.Delay(_options.Value.PollInterval, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }
    }

    private async Task<IReadOnlyDictionary<string, long>> ReadCountsAsync(CancellationToken cancellationToken)
    {
        var counts = new Dictionary<string, long>();

        foreach (var queue in _options.Value.Queues)
        {
            var properties = await _admin.GetQueueRuntimePropertiesAsync(queue, cancellationToken);
            counts[$"queue:{queue}"] = properties.Value.DeadLetterMessageCount;
        }

        foreach (var (topic, subscription) in _options.Value.Subscriptions)
        {
            var properties = await _admin.GetSubscriptionRuntimePropertiesAsync(topic, subscription, cancellationToken);
            counts[$"subscription:{topic}/{subscription}"] = properties.Value.DeadLetterMessageCount;
        }

        return counts;
    }

    /// <inheritdoc />
    public override void Dispose()
    {
        _meter.Dispose();
        base.Dispose();
    }
}
