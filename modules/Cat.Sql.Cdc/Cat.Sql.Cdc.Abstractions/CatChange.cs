using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Cat.Sql.Cdc.Abstractions;

/// <summary>
/// One captured row change. It is the unit the module hands to the sink: one message per row change.
/// </summary>
public class CatChange
{
    /// <summary>
    /// The capture instance the change comes from, such as <c>dbo_BookPrice</c>.
    /// </summary>
    public string Table { get; set; } = string.Empty;

    /// <summary>
    /// What happened to the row.
    /// </summary>
    public CatChangeOperation Operation { get; set; }

    /// <summary>
    /// The log sequence number of the transaction that made the change. It is 10 bytes.
    /// </summary>
    public byte[] Lsn { get; set; } = Array.Empty<byte>();

    /// <summary>
    /// The sequence value that orders the row changes inside one transaction. It is 10 bytes.
    /// </summary>
    public byte[] SequenceValue { get; set; } = Array.Empty<byte>();

    /// <summary>
    /// When the transaction committed.
    /// </summary>
    public DateTimeOffset TransactionTime { get; set; }

    /// <summary>
    /// The id of the transaction, from <c>cdc.lsn_time_mapping</c>. All changes of one transaction share it.
    /// </summary>
    public byte[] TransactionId { get; set; } = Array.Empty<byte>();

    /// <summary>
    /// The key columns and their values. Empty when the capture instance has no index columns.
    /// </summary>
    public IReadOnlyDictionary<string, object?> Keys { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// The values before the change. It is <c>null</c> for an insert.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? Old { get; set; }

    /// <summary>
    /// The values after the change. It is <c>null</c> for a delete.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? New { get; set; }

    /// <summary>
    /// A stable id for this change, made from the LSN, the sequence value and the operation. The same change always gets the same id,
    /// so a bus can drop a repeat and a receiver can recognize one. The module uses it as the message id.
    /// </summary>
    public Guid MessageId
    {
        get
        {
            var buffer = new byte[Lsn.Length + SequenceValue.Length + 1];
            Buffer.BlockCopy(Lsn, 0, buffer, 0, Lsn.Length);
            Buffer.BlockCopy(SequenceValue, 0, buffer, Lsn.Length, SequenceValue.Length);
            buffer[buffer.Length - 1] = (byte)Operation;

            // MD5 only makes an id of 16 bytes here. It is not used for security.
            using var md5 = MD5.Create();
            return new Guid(md5.ComputeHash(buffer));
        }
    }
}
