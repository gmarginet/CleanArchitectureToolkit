using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Cat.Scheduling.Abstractions;

namespace Cat.Scheduling;

/// <summary>
/// The trace source and the metrics of the scheduler.
/// </summary>
public static class CatSchedulingTelemetry
{
    /// <summary>
    /// The name of the trace source and the meter. Add it to your OpenTelemetry setup to see the runs.
    /// </summary>
    public const string SourceName = "Cat.Scheduling";

    internal static readonly ActivitySource ActivitySource = new ActivitySource(SourceName);

    private static readonly Meter Meter = new Meter(SourceName);
    private static readonly ConcurrentDictionary<string, double> LastRuns = new ConcurrentDictionary<string, double>();

    private static readonly Counter<long> Runs = Meter.CreateCounter<long>(
        "cat.scheduling.runs", description: "The number of finished runs, by job and status.");

    // The reading of the gauge. It is kept so the gauge is not collected.
    // ReSharper disable once UnusedMember.Local
    private static readonly ObservableGauge<double> LastRunGauge = Meter.CreateObservableGauge(
        "cat.scheduling.last_run", ObserveLastRuns, unit: "s",
        description: "When a job last finished, in seconds since 1970 (UTC).");

    internal static void RecordRun(string jobName, CatJobRunStatus status, DateTimeOffset finishedAt)
    {
        Runs.Add(1, new KeyValuePair<string, object?>("job", jobName),
            new KeyValuePair<string, object?>("status", status.ToString()));
        LastRuns[jobName] = finishedAt.ToUnixTimeMilliseconds() / 1000d;
    }

    private static IEnumerable<Measurement<double>> ObserveLastRuns()
    {
        foreach (var pair in LastRuns)
        {
            yield return new Measurement<double>(pair.Value, new KeyValuePair<string, object?>("job", pair.Key));
        }
    }
}
