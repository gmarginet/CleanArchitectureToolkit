using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Sql.Cdc.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Sql.Cdc;

/// <summary>
/// Reads one capture instance. One call of <see cref="PollAsync"/> is one round: claim, read, hand over, save the position.
/// The position is saved after the changes were handed to the sink, so a crash in between repeats them (at least once).
/// </summary>
internal sealed class CatCdcTableReader
{
    private readonly CatCdcTable _table;
    private readonly ICatCdcDatabase _database;
    private readonly ICatChangeSink _sink;
    private readonly CatCdcSettings _settings;
    private readonly ILogger _logger;
    private readonly string _owner;
    private IReadOnlyList<string>? _keyColumns;

    public CatCdcTableReader(CatCdcTable table, ICatCdcDatabase database, ICatChangeSink sink, CatCdcSettings settings, string owner, ILogger logger)
    {
        _table = table;
        _database = database;
        _sink = sink;
        _settings = settings;
        _owner = owner;
        _logger = logger;
    }

    public string Name => _table.CaptureInstance;

    public Task InitializeAsync(CancellationToken cancellationToken)
    {
        return _database.EnsureCreatedAsync(Name, cancellationToken);
    }

    /// <summary>
    /// Does one round.
    /// </summary>
    /// <returns>The number of changes handed to the sink, or -1 when another instance holds the claim.</returns>
    /// <exception cref="CatCdcGapException">The position is older than the oldest change, and the setting says to fail.</exception>
    public async Task<int> PollAsync(CancellationToken cancellationToken)
    {
        if (!await _database.TryClaimAsync(Name, _owner, _settings.ClaimLease, cancellationToken).ConfigureAwait(false))
        {
            return -1;
        }

        var min = await _database.GetMinLsnAsync(Name, cancellationToken).ConfigureAwait(false)
                  ?? throw new InvalidOperationException($"The capture instance '{Name}' does not exist. Enable change data capture for the table first.");
        var max = await _database.GetMaxLsnAsync(cancellationToken).ConfigureAwait(false);
        if (max == null)
        {
            return 0;
        }

        var position = await _database.GetPositionAsync(Name, cancellationToken).ConfigureAwait(false);
        if (position == null)
        {
            // The first start reads everything the change table still holds.
            position = new CatCdcPosition(min, null);
        }
        else if (CatCdcBinary.Compare(position.Lsn, min) < 0)
        {
            if (_settings.OnRetentionGap == CatCdcGapBehavior.Fail)
            {
                throw new CatCdcGapException(
                    $"The change table of '{Name}' was cleaned up past the position of the reader, so changes may be lost. Set OnRetentionGap to SkipToOldest to go on.");
            }

            _logger.LogWarning("The change table of {Table} was cleaned up past the position of the reader. Changes are lost. It goes on at the oldest change.", Name);
            CatSqlCdcTelemetry.RecordError(Name, "gap");
            position = new CatCdcPosition(min, null);
        }

        _keyColumns ??= await _database.GetKeyColumnsAsync(Name, cancellationToken).ConfigureAwait(false);
        var changes = await _database.ReadChangesAsync(Name, position, max, _settings.BatchSize, _keyColumns, cancellationToken).ConfigureAwait(false);

        if (changes.Count == 0)
        {
            // Nothing for this table up to the newest LSN. Move the position there, so the clean-up of the
            // change table is not taken for a gap when the table stays quiet for a long time.
            await SaveAsync(new CatCdcPosition(max, CatCdcBinary.Highest(max.Length)), cancellationToken).ConfigureAwait(false);
            return 0;
        }

        foreach (var change in changes)
        {
            var message = _table.Map(change);
            await _sink.SendAsync(change, message, cancellationToken).ConfigureAwait(false);
            CatSqlCdcTelemetry.RecordChange(Name, change.Operation);
        }

        var last = changes[changes.Count - 1];
        await SaveAsync(new CatCdcPosition(last.Lsn, last.SequenceValue), cancellationToken).ConfigureAwait(false);

        return changes.Count;
    }

    private async Task SaveAsync(CatCdcPosition position, CancellationToken cancellationToken)
    {
        if (!await _database.SavePositionAsync(Name, _owner, position, cancellationToken).ConfigureAwait(false))
        {
            throw new InvalidOperationException($"The claim on '{Name}' was lost before the position could be saved. The changes may be sent again.");
        }
    }
}
