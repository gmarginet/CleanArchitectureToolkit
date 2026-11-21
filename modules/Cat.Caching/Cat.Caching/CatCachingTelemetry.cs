using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Cat.Caching;

/// <summary>
/// The metrics of the query cache. The tag <c>query</c> holds the short name of the query type.
/// The key of an entry never goes into a tag, because a key can hold personal data.
/// </summary>
public static class CatCachingTelemetry
{
    /// <summary>
    /// The name of the meter. <c>AddCatTelemetry</c> of <c>Cat.Telemetry</c> exports it.
    /// </summary>
    public const string MeterName = "Cat.Caching";

    private static readonly Meter Meter = new Meter(MeterName);

    private static readonly Counter<long> Hits = Meter.CreateCounter<long>(
        "cat.caching.hits", description: "The number of cached queries that were answered without running the query, by query type.");

    private static readonly Counter<long> Misses = Meter.CreateCounter<long>(
        "cat.caching.misses", description: "The number of cached queries that ran the query, by query type.");

    internal static void Record(string query, bool hit)
    {
        var tag = new KeyValuePair<string, object?>("query", query);
        if (hit)
        {
            Hits.Add(1, tag);
        }
        else
        {
            Misses.Add(1, tag);
        }
    }
}
