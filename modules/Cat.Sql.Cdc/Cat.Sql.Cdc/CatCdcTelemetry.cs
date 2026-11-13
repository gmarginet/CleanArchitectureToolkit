using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Cat.Sql.Cdc.Abstractions;

namespace Cat.Sql.Cdc;

/// <summary>
/// The meter of the module. Add <see cref="SourceName"/> to your OpenTelemetry setup to collect the metrics.
/// </summary>
public static class CatSqlCdcTelemetry
{
    /// <summary>
    /// The name of the meter.
    /// </summary>
    public const string SourceName = "Cat.Sql.Cdc";

    private static readonly Meter Meter = new(SourceName);

    private static readonly Counter<long> Changes = Meter.CreateCounter<long>(
        "cat.sql.cdc.changes", description: "The number of changes handed to the sink, by table and operation.");

    private static readonly Counter<long> Errors = Meter.CreateCounter<long>(
        "cat.sql.cdc.errors", description: "The number of failed polls, by table and kind. The kind gap means changes may be lost.");

    internal static void RecordChange(string table, CatChangeOperation operation)
    {
        Changes.Add(1, new KeyValuePair<string, object?>("table", table), new KeyValuePair<string, object?>("operation", operation.ToString()));
    }

    internal static void RecordError(string table, string kind)
    {
        Errors.Add(1, new KeyValuePair<string, object?>("table", table), new KeyValuePair<string, object?>("kind", kind));
    }
}
