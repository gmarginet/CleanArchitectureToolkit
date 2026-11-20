using System;
using System.Collections.Generic;
using System.Linq;
using Cat.Dapper.Abstractions;

namespace Cat.Dapper;

/// <summary>
/// The columns of an update, a delete or a merge: the key columns and the columns to change.
/// </summary>
internal sealed class ColumnPlan
{
    internal ColumnPlan(IReadOnlyList<BulkColumn> keys, IReadOnlyList<BulkColumn> update)
    {
        Keys = keys;
        Update = update;
        KeyNames = keys.Select(c => c.Name).ToList();
        UpdateNames = update.Select(c => c.Name).ToList();
    }

    internal IReadOnlyList<BulkColumn> Keys { get; }

    internal IReadOnlyList<BulkColumn> Update { get; }

    internal IReadOnlyList<string> KeyNames { get; }

    internal IReadOnlyList<string> UpdateNames { get; }
}

/// <summary>
/// The checks and the column choices that the bulk operations of every database share.
/// </summary>
internal static class BulkPlan
{
    /// <summary>
    /// Chooses the key columns and the columns to change. Every column goes through <paramref name="validateColumn"/>,
    /// which is the check of the database for a name that is safe to put in the SQL text.
    /// </summary>
    internal static ColumnPlan Plan(
        Type type,
        IEnumerable<string> keyColumns,
        IEnumerable<string>? updateColumns,
        bool allowNoUpdate,
        Action<string> validateColumn)
    {
        if (keyColumns is null) throw new ArgumentNullException(nameof(keyColumns));
        var keys = BulkColumns.Select(type, keyColumns, nameof(keyColumns));
        Validate(keys, validateColumn);

        IReadOnlyList<BulkColumn> update;
        if (updateColumns is null)
        {
            update = BulkColumns.ForType(type).Where(c => !keys.Contains(c)).ToList();
        }
        else
        {
            update = BulkColumns.Select(type, updateColumns, nameof(updateColumns));
            if (update.Any(keys.Contains)) throw new ArgumentException("A key column cannot be an update column.", nameof(updateColumns));
        }

        Validate(update, validateColumn);
        if (update.Count == 0 && !allowNoUpdate)
        {
            throw new ArgumentException("There is no column to update. Every property is a key column.", nameof(updateColumns));
        }

        return new ColumnPlan(keys, update);
    }

    internal static void Validate(IEnumerable<BulkColumn> columns, Action<string> validateColumn)
    {
        foreach (var column in columns) validateColumn(column.Name);
    }

    internal static void Require<T>(ICatDbSession session, IEnumerable<T> rows, string table)
    {
        if (session is null) throw new ArgumentNullException(nameof(session));
        if (rows is null) throw new ArgumentNullException(nameof(rows));
        if (table is null) throw new ArgumentNullException(nameof(table));
    }

    /// <summary>
    /// True when the rows are a collection that is known to be empty. An enumerable that cannot tell is never empty here.
    /// </summary>
    internal static bool IsEmpty<T>(IEnumerable<T> rows) =>
        rows is ICollection<T> { Count: 0 } || rows is IReadOnlyCollection<T> { Count: 0 };

    /// <summary>
    /// The column for a list of single values, such as the ids of a bulk delete.
    /// </summary>
    internal static BulkColumn ValueColumn<TKey>(string name)
    {
        var type = Nullable.GetUnderlyingType(typeof(TKey)) ?? typeof(TKey);
        if (type.IsEnum) type = Enum.GetUnderlyingType(type);
        return new BulkColumn(name, type, value => value);
    }
}
