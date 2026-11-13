using System;

namespace Cat.Sql.Cdc;

/// <summary>
/// What to do when the change tables were cleaned up past the position of the reader, so changes may be lost.
/// </summary>
public enum CatCdcGapBehavior
{
    /// <summary>
    /// Stop reading the table, log an error, count it and report unhealthy. This is the default.
    /// </summary>
    Fail,

    /// <summary>
    /// Log a warning and go on at the oldest change that is still available. The changes in between are lost.
    /// </summary>
    SkipToOldest
}

/// <summary>
/// The settings of the reader. Bind them from the configuration section <c>CatSqlCdc</c>.
/// </summary>
public class CatCdcSettings
{
    /// <summary>
    /// The name of the configuration section.
    /// </summary>
    public const string ConfigurationSectionName = "CatSqlCdc";

    /// <summary>
    /// The connection string of the captured database. The module keeps its position in this database too.
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// How long the reader waits after a poll that found nothing. The default is 1 second.
    /// </summary>
    public TimeSpan PollInterval { get; set; } = TimeSpan.FromSeconds(1);

    /// <summary>
    /// The most changes handed to the sink before the position is saved. The default is 1000.
    /// </summary>
    public int BatchSize { get; set; } = 1000;

    /// <summary>
    /// The schema in the captured database that holds the position table. The default is <c>catcdc</c>.
    /// </summary>
    public string Schema { get; set; } = "catcdc";

    /// <summary>
    /// How long one instance owns a table after it claimed it. A running reader renews the claim on every poll.
    /// If the reader dies, another instance takes over when the lease has run out. The default is 30 seconds.
    /// </summary>
    public TimeSpan ClaimLease { get; set; } = TimeSpan.FromSeconds(30);

    /// <summary>
    /// What to do when the position is older than the oldest available change. The default is <see cref="CatCdcGapBehavior.Fail"/>.
    /// </summary>
    public CatCdcGapBehavior OnRetentionGap { get; set; } = CatCdcGapBehavior.Fail;
}
