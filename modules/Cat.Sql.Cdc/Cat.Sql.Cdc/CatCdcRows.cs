using System;
using System.Collections.Generic;
using Cat.Sql.Cdc.Abstractions;

namespace Cat.Sql.Cdc;

/// <summary>
/// The place the reader has come to: everything up to and including this LSN and sequence value is handed over.
/// A <c>null</c> sequence value means the whole LSN is still to be read.
/// </summary>
internal sealed record CatCdcPosition(byte[] Lsn, byte[]? SequenceValue);

/// <summary>
/// A row as it comes out of the change function. Operation 1 is a delete, 2 an insert, 3 the old values of an update and 4 the new values.
/// </summary>
internal sealed class CatCdcRawRow
{
    public byte[] Lsn { get; set; } = Array.Empty<byte>();
    public byte[] SequenceValue { get; set; } = Array.Empty<byte>();
    public int Operation { get; set; }
    public DateTimeOffset TransactionTime { get; set; }
    public byte[] TransactionId { get; set; } = Array.Empty<byte>();
    public Dictionary<string, object?> Values { get; set; } = new();
}

internal static class CatCdcBinary
{
    /// <summary>
    /// Compares two binary values the way SQL Server does, byte by byte from the left.
    /// </summary>
    public static int Compare(byte[] left, byte[] right)
    {
        var length = Math.Min(left.Length, right.Length);
        for (var i = 0; i < length; i++)
        {
            if (left[i] != right[i])
            {
                return left[i] < right[i] ? -1 : 1;
            }
        }

        return left.Length.CompareTo(right.Length);
    }

    public static byte[] Highest(int length)
    {
        var bytes = new byte[length];
        for (var i = 0; i < length; i++)
        {
            bytes[i] = 0xFF;
        }

        return bytes;
    }
}

internal static class CatCdcRowMapper
{
    /// <summary>
    /// Turns raw rows, ordered by LSN and sequence value, into changes. The two rows of an update become one change.
    /// It stops at an update whose second row is missing, so a batch that ends in the middle of one is read again next time.
    /// </summary>
    public static IReadOnlyList<CatChange> ToChanges(string table, IReadOnlyList<CatCdcRawRow> rows, int batchSize, IReadOnlyList<string> keyColumns)
    {
        var changes = new List<CatChange>();
        var index = 0;

        while (index < rows.Count && changes.Count < batchSize)
        {
            var row = rows[index];
            CatChange change;

            switch (row.Operation)
            {
                case 1:
                    change = Create(table, row, CatChangeOperation.Delete, row.Values, null, keyColumns);
                    index++;
                    break;
                case 2:
                    change = Create(table, row, CatChangeOperation.Insert, null, row.Values, keyColumns);
                    index++;
                    break;
                case 3:
                    if (index + 1 >= rows.Count || rows[index + 1].Operation != 4)
                    {
                        return changes;
                    }

                    var after = rows[index + 1];
                    change = Create(table, after, CatChangeOperation.Update, row.Values, after.Values, keyColumns);
                    index += 2;
                    break;
                case 4:
                    // The first row of the pair was handled before. Treat the rest as an update without old values.
                    change = Create(table, row, CatChangeOperation.Update, null, row.Values, keyColumns);
                    index++;
                    break;
                default:
                    throw new InvalidOperationException($"The change table of '{table}' returned the unknown operation {row.Operation}.");
            }

            changes.Add(change);
        }

        return changes;
    }

    private static CatChange Create(string table, CatCdcRawRow row, CatChangeOperation operation,
        IReadOnlyDictionary<string, object?>? old, IReadOnlyDictionary<string, object?>? current, IReadOnlyList<string> keyColumns)
    {
        var source = current ?? old;
        var keys = new Dictionary<string, object?>();
        if (source != null)
        {
            foreach (var column in keyColumns)
            {
                if (source.TryGetValue(column, out var value))
                {
                    keys[column] = value;
                }
            }
        }

        return new CatChange
        {
            Table = table,
            Operation = operation,
            Lsn = row.Lsn,
            SequenceValue = row.SequenceValue,
            TransactionTime = row.TransactionTime,
            TransactionId = row.TransactionId,
            Keys = keys,
            Old = old,
            New = current
        };
    }
}
