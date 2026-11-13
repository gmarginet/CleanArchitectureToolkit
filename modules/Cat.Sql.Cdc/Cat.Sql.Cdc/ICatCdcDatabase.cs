using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Sql.Cdc.Abstractions;

namespace Cat.Sql.Cdc;

/// <summary>
/// Everything the reader needs from the database: the change tables, the position and the claim.
/// </summary>
internal interface ICatCdcDatabase
{
    /// <summary>
    /// Creates the schema and the position table when they are missing, and the row of the capture instance.
    /// </summary>
    Task EnsureCreatedAsync(string captureInstance, CancellationToken cancellationToken);

    /// <summary>
    /// Takes the table for <paramref name="owner"/>, or renews the claim it already has.
    /// </summary>
    /// <returns><c>true</c> when the owner holds the claim now.</returns>
    Task<bool> TryClaimAsync(string captureInstance, string owner, TimeSpan lease, CancellationToken cancellationToken);

    Task<CatCdcPosition?> GetPositionAsync(string captureInstance, CancellationToken cancellationToken);

    /// <summary>
    /// Saves the position, only while the owner still holds the claim.
    /// </summary>
    /// <returns><c>false</c> when the owner lost the claim.</returns>
    Task<bool> SavePositionAsync(string captureInstance, string owner, CatCdcPosition position, CancellationToken cancellationToken);

    /// <summary>
    /// The oldest LSN that is still in the change table, or <c>null</c> when the capture instance does not exist.
    /// </summary>
    Task<byte[]?> GetMinLsnAsync(string captureInstance, CancellationToken cancellationToken);

    /// <summary>
    /// The newest LSN the capture process has handled, or <c>null</c> when it has handled nothing yet.
    /// </summary>
    Task<byte[]?> GetMaxLsnAsync(CancellationToken cancellationToken);

    /// <summary>
    /// The key columns of the capture instance, in order.
    /// </summary>
    Task<IReadOnlyList<string>> GetKeyColumnsAsync(string captureInstance, CancellationToken cancellationToken);

    /// <summary>
    /// Reads the changes after the position, up to <paramref name="toLsn"/>, with at most <paramref name="batchSize"/> changes.
    /// </summary>
    Task<IReadOnlyList<CatChange>> ReadChangesAsync(string captureInstance, CatCdcPosition after, byte[] toLsn, int batchSize,
        IReadOnlyList<string> keyColumns, CancellationToken cancellationToken);
}
