using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Npgsql;

namespace Cat.Dapper.PostgreSQL;

/// <summary>
/// The rows that go to a <c>COPY</c>, one at a time.
/// </summary>
internal abstract class BulkRowSource : IDisposable
{
    internal abstract int FieldCount { get; }

    /// <summary>
    /// Moves to the next row. False when there are no rows left.
    /// </summary>
    internal abstract bool Read();

    internal abstract object? GetValue(int ordinal);

    public virtual void Dispose()
    {
    }
}

/// <summary>
/// Rows from a list of objects, read through the columns of the row class.
/// </summary>
internal sealed class EnumerableRowSource<T> : BulkRowSource
{
    private readonly IEnumerator<T> _rows;
    private readonly IReadOnlyList<BulkColumn> _columns;

    internal EnumerableRowSource(IEnumerable<T> rows, IReadOnlyList<BulkColumn> columns)
    {
        _rows = rows.GetEnumerator();
        _columns = columns;
    }

    internal override int FieldCount => _columns.Count;

    internal override bool Read() => _rows.MoveNext();

    internal override object? GetValue(int ordinal) => _columns[ordinal].Getter(_rows.Current!);

    public override void Dispose() => _rows.Dispose();
}

/// <summary>
/// Rows from a data reader. The source does not close the reader.
/// </summary>
internal sealed class ReaderRowSource : BulkRowSource
{
    private readonly IDataReader _reader;

    internal ReaderRowSource(IDataReader reader) => _reader = reader;

    internal override int FieldCount => _reader.FieldCount;

    internal override bool Read() => _reader.Read();

    internal override object? GetValue(int ordinal) => _reader.IsDBNull(ordinal) ? null : _reader.GetValue(ordinal);
}

/// <summary>
/// Writes a value of any type to a binary importer. The importer picks the PostgreSQL type from the type of the value,
/// so the type of the value must match the type of the column.
/// </summary>
internal static class ImporterWriter
{
    private static readonly ConcurrentDictionary<Type, Func<NpgsqlBinaryImporter, object, CancellationToken, Task>> Writers = new();

    private static readonly MethodInfo WriteTypedMethod =
        typeof(ImporterWriter).GetMethod(nameof(WriteTyped), BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static Task WriteAsync(NpgsqlBinaryImporter importer, object? value, CancellationToken cancellationToken)
    {
        if (value is null || value is DBNull) return importer.WriteNullAsync(cancellationToken);

        var writer = Writers.GetOrAdd(value.GetType(), type =>
            (Func<NpgsqlBinaryImporter, object, CancellationToken, Task>)WriteTypedMethod
                .MakeGenericMethod(type)
                .CreateDelegate(typeof(Func<NpgsqlBinaryImporter, object, CancellationToken, Task>)));
        return writer(importer, value, cancellationToken);
    }

    private static Task WriteTyped<TValue>(NpgsqlBinaryImporter importer, object value, CancellationToken cancellationToken) =>
        importer.WriteAsync((TValue)value, cancellationToken);
}
