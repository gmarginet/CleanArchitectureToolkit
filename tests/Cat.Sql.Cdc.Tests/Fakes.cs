using Cat.Messaging.Abstractions;
using Cat.Sql.Cdc.Abstractions;

namespace Cat.Sql.Cdc.Tests;

internal static class Lsn
{
    // Makes a 10 byte value that sorts by the number.
    public static byte[] Of(int number)
    {
        var bytes = new byte[10];
        bytes[9] = (byte)number;
        bytes[8] = (byte)(number >> 8);
        return bytes;
    }
}

internal sealed class FakeCdcDatabase : ICatCdcDatabase
{
    public List<CatChange> Changes { get; } = [];
    public byte[]? Min { get; set; } = Lsn.Of(1);
    public byte[]? Max { get; set; } = Lsn.Of(100);
    public CatCdcPosition? Position { get; set; }
    public bool ClaimAvailable { get; set; } = true;
    public bool SaveSucceeds { get; set; } = true;
    public List<CatCdcPosition> Saved { get; } = [];
    public int Initialized { get; private set; }

    public Task EnsureCreatedAsync(string captureInstance, CancellationToken cancellationToken)
    {
        Initialized++;
        return Task.CompletedTask;
    }

    public Task<bool> TryClaimAsync(string captureInstance, string owner, TimeSpan lease, CancellationToken cancellationToken)
        => Task.FromResult(ClaimAvailable);

    public Task<CatCdcPosition?> GetPositionAsync(string captureInstance, CancellationToken cancellationToken)
        => Task.FromResult(Position);

    public Task<bool> SavePositionAsync(string captureInstance, string owner, CatCdcPosition position, CancellationToken cancellationToken)
    {
        if (!SaveSucceeds)
        {
            return Task.FromResult(false);
        }

        Position = position;
        Saved.Add(position);
        return Task.FromResult(true);
    }

    public Task<byte[]?> GetMinLsnAsync(string captureInstance, CancellationToken cancellationToken) => Task.FromResult(Min);

    public Task<byte[]?> GetMaxLsnAsync(CancellationToken cancellationToken) => Task.FromResult(Max);

    public Task<IReadOnlyList<string>> GetKeyColumnsAsync(string captureInstance, CancellationToken cancellationToken)
        => Task.FromResult<IReadOnlyList<string>>(["Id"]);

    public Task<IReadOnlyList<CatChange>> ReadChangesAsync(string captureInstance, CatCdcPosition after, byte[] toLsn, int batchSize,
        IReadOnlyList<string> keyColumns, CancellationToken cancellationToken)
    {
        var result = Changes
            .Where(c => CatCdcBinary.Compare(c.Lsn, after.Lsn) > 0
                        || (CatCdcBinary.Compare(c.Lsn, after.Lsn) == 0 && (after.SequenceValue == null || CatCdcBinary.Compare(c.SequenceValue, after.SequenceValue) > 0)))
            .Where(c => CatCdcBinary.Compare(c.Lsn, toLsn) <= 0)
            .Take(batchSize)
            .ToList();
        return Task.FromResult<IReadOnlyList<CatChange>>(result);
    }
}

internal sealed class RecordingSink : ICatChangeSink
{
    public List<(CatChange Change, object Message)> Received { get; } = [];
    public Exception? FailWith { get; set; }

    public Task SendAsync(CatChange change, object message, CancellationToken cancellationToken = default)
    {
        if (FailWith != null)
        {
            throw FailWith;
        }

        Received.Add((change, message));
        return Task.CompletedTask;
    }
}

internal sealed class RecordingSender : ICatMessageSender
{
    public List<ICatEventMessage> Published { get; } = [];

    public Task PublishAsync(ICatEventMessage message, DateTimeOffset? scheduledAt = null, CancellationToken cancellationToken = default)
    {
        Published.Add(message);
        return Task.CompletedTask;
    }

    public Task SendAsync(ICatCommandMessage message, DateTimeOffset? scheduledAt = null, CancellationToken cancellationToken = default)
        => throw new NotSupportedException();
}
