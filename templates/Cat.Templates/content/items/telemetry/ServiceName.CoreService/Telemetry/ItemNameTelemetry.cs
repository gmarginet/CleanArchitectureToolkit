using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace ServiceName.CoreService.Telemetry;

/// <summary>
/// Holds the source and the meter of ItemName. Register it as a singleton and give it to the handlers that trace or measure.
/// Add <see cref="Name"/> where the service calls AddCatTelemetry, with AddSource for the traces and AddMeter for the metrics.
/// Without that nothing is exported.
/// </summary>
public sealed class ItemNameTelemetry : IDisposable
{
    /// <summary>The name of the source and of the meter.</summary>
    public const string Name = "ServiceName.ItemName";

    private readonly Meter _meter = new(Name);
    private readonly Counter<long> _calls;

    public ItemNameTelemetry()
    {
        _calls = _meter.CreateCounter<long>("calls", description: "The number of calls, by outcome.");
    }

    /// <summary>The source of the spans of ItemName.</summary>
    public ActivitySource Source { get; } = new(Name);

    /// <summary>Starts a span. It is null while nothing listens, so use the result with a null check.</summary>
    public Activity? StartActivity(string name) => Source.StartActivity(name);

    /// <summary>Counts one call. Keep the outcome to a few fixed values, such as success and failed.</summary>
    public void CountCall(string outcome) => _calls.Add(1, new KeyValuePair<string, object?>("outcome", outcome));

    public void Dispose()
    {
        Source.Dispose();
        _meter.Dispose();
    }
}
