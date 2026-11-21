using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Cat.Responses.Abstractions;

namespace Cat.ServiceRequests.Decorators.ActivitySource;

/// <summary>
/// The names and the metrics of the service request decorator.
/// Add <see cref="SourceName"/> to your OpenTelemetry setup, for traces and for metrics, to see the calls.
/// </summary>
public static class CatServiceRequestsTelemetry
{
    /// <summary>
    /// The name of the trace source and the meter.
    /// </summary>
    public const string SourceName = "Cat.ServiceRequests";

    /// <summary>
    /// The tag of a span that holds the name of the service request type.
    /// </summary>
    public const string TypeTag = "cat.service_requests.type";

    internal const string ExceptionOutcome = "exception";

    private static readonly Meter Meter = new Meter(SourceName);

    private static readonly Counter<long> Calls = Meter.CreateCounter<long>(
        "cat.service_requests.calls", description: "The number of handled service requests, by type and outcome.");

    private static readonly Histogram<double> Duration = Meter.CreateHistogram<double>(
        "cat.service_requests.duration", unit: "s", description: "How long a service request took, by type and outcome.");

    internal static string OutcomeOf(ICatResponse response) => response.IsSucceeded ? "success" : "failed";

    internal static void Record(string type, string outcome, long startTimestamp)
    {
        var seconds = (Stopwatch.GetTimestamp() - startTimestamp) / (double)Stopwatch.Frequency;
        var typeTag = new KeyValuePair<string, object?>("type", type);
        var outcomeTag = new KeyValuePair<string, object?>("outcome", outcome);
        Calls.Add(1, typeTag, outcomeTag);
        Duration.Record(seconds, typeTag, outcomeTag);
    }
}
