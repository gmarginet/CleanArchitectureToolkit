using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

namespace Cat.Dapper.SqlServer;

/// <summary>
/// Streams the rows of an enumerable to <c>SqlBulkCopy</c> one at a time, so the rows are never copied into a table in memory.
/// </summary>
internal sealed class BulkDataReader<T> : DbDataReader
{
    private readonly IEnumerator<T> _rows;
    private readonly IReadOnlyList<BulkColumn> _columns;
    private bool _closed;

    internal BulkDataReader(IEnumerable<T> rows, IReadOnlyList<BulkColumn> columns)
    {
        _rows = rows.GetEnumerator();
        _columns = columns;
    }

    /// <summary>
    /// The number of rows that were read so far.
    /// </summary>
    internal int RowCount { get; private set; }

    public override int FieldCount => _columns.Count;

    public override bool HasRows => true;

    public override bool IsClosed => _closed;

    public override int Depth => 0;

    public override int RecordsAffected => -1;

    public override object this[int ordinal] => GetValue(ordinal);

    public override object this[string name] => GetValue(GetOrdinal(name));

    public override bool Read()
    {
        if (_closed || !_rows.MoveNext()) return false;
        RowCount++;
        return true;
    }

    public override bool NextResult() => false;

    public override string GetName(int ordinal) => _columns[ordinal].Name;

    public override int GetOrdinal(string name)
    {
        for (var i = 0; i < _columns.Count; i++)
        {
            if (string.Equals(_columns[i].Name, name, StringComparison.OrdinalIgnoreCase)) return i;
        }

        throw new IndexOutOfRangeException(name);
    }

    public override Type GetFieldType(int ordinal) => _columns[ordinal].FieldType;

    public override string GetDataTypeName(int ordinal) => _columns[ordinal].FieldType.Name;

    public override object GetValue(int ordinal) => _columns[ordinal].Getter(_rows.Current!) ?? DBNull.Value;

    public override int GetValues(object[] values)
    {
        var count = Math.Min(values.Length, _columns.Count);
        for (var i = 0; i < count; i++) values[i] = GetValue(i);
        return count;
    }

    public override bool IsDBNull(int ordinal) => GetValue(ordinal) is DBNull;

    public override bool GetBoolean(int ordinal) => (bool)GetValue(ordinal);

    public override byte GetByte(int ordinal) => (byte)GetValue(ordinal);

    public override char GetChar(int ordinal) => (char)GetValue(ordinal);

    public override DateTime GetDateTime(int ordinal) => (DateTime)GetValue(ordinal);

    public override decimal GetDecimal(int ordinal) => (decimal)GetValue(ordinal);

    public override double GetDouble(int ordinal) => (double)GetValue(ordinal);

    public override float GetFloat(int ordinal) => (float)GetValue(ordinal);

    public override Guid GetGuid(int ordinal) => (Guid)GetValue(ordinal);

    public override short GetInt16(int ordinal) => (short)GetValue(ordinal);

    public override int GetInt32(int ordinal) => (int)GetValue(ordinal);

    public override long GetInt64(int ordinal) => (long)GetValue(ordinal);

    public override string GetString(int ordinal) => (string)GetValue(ordinal);

    public override long GetBytes(int ordinal, long dataOffset, byte[]? buffer, int bufferOffset, int length) =>
        throw new NotSupportedException();

    public override long GetChars(int ordinal, long dataOffset, char[]? buffer, int bufferOffset, int length) =>
        throw new NotSupportedException();

    public override IEnumerator GetEnumerator() => throw new NotSupportedException();

    public override void Close()
    {
        _closed = true;
        _rows.Dispose();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing) Close();
        base.Dispose(disposing);
    }
}
