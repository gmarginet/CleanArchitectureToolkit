using System;
using System.Collections.Generic;
using System.Linq;

namespace Cat.Dapper.PostgreSQL;

/// <summary>
/// Builds the SQL text of the bulk operations. Every table and column name goes through <see cref="QuoteName"/>.
/// </summary>
internal static class PostgreSQLBulkSql
{
    internal const string InsertedColumn = "Inserted";

    /// <summary>
    /// Wraps a table or column name in double quotes, exactly as given. PostgreSQL treats a quoted name as case sensitive.
    /// A table name may have up to three parts, such as <c>public.Orders</c>.
    /// </summary>
    internal static string QuoteName(string name)
    {
        if (name is null) throw new ArgumentNullException(nameof(name));

        var parts = name.Split('.');
        if (parts.Length > 3) throw new ArgumentException($"The name '{name}' has more than three parts.", nameof(name));

        var quoted = new string[parts.Length];
        for (var i = 0; i < parts.Length; i++)
        {
            var part = parts[i].Trim();
            if (part.Length == 0) throw new ArgumentException($"The name '{name}' has an empty part.", nameof(name));
            if (part.IndexOf('"') >= 0) throw new ArgumentException($"The name '{name}' holds a double quote.", nameof(name));
            quoted[i] = "\"" + part + "\"";
        }

        return string.Join(".", quoted);
    }

    /// <summary>
    /// A column name has one part, so a dot is a mistake.
    /// </summary>
    internal static string QuoteColumn(string column)
    {
        if (column is null) throw new ArgumentNullException(nameof(column));
        if (column.IndexOf('.') >= 0) throw new ArgumentException($"The column name '{column}' holds a dot.", nameof(column));
        return QuoteName(column);
    }

    internal static string NewStagingName() => "catbulk_" + Guid.NewGuid().ToString("N");

    /// <summary>
    /// An empty temporary table with only the given columns. The types come from the target table, and no identity or default is copied.
    /// Inside a transaction the table drops on commit.
    /// </summary>
    internal static string BuildCreateStaging(string staging, string table, IEnumerable<string> columns, bool dropOnCommit) =>
        $"CREATE TEMP TABLE {QuoteName(staging)}{(dropOnCommit ? " ON COMMIT DROP" : string.Empty)} AS SELECT {ColumnList(columns, null)} FROM {QuoteName(table)} WITH NO DATA;";

    internal static string BuildDropStaging(string staging) => $"DROP TABLE IF EXISTS {QuoteName(staging)};";

    internal static string BuildCopy(string table, IEnumerable<string> columns) =>
        $"COPY {QuoteName(table)} ({ColumnList(columns, null)}) FROM STDIN (FORMAT BINARY)";

    internal static string BuildUpdate(string staging, string table, IReadOnlyList<string> keys, IReadOnlyList<string> updateColumns)
    {
        var sets = string.Join(", ", updateColumns.Select(c => $"{QuoteColumn(c)} = s.{QuoteColumn(c)}"));
        return $"UPDATE {QuoteName(table)} AS t SET {sets} FROM {QuoteName(staging)} AS s WHERE {JoinOn(keys)};";
    }

    internal static string BuildDelete(string staging, string table, IReadOnlyList<string> keys) =>
        $"DELETE FROM {QuoteName(table)} AS t USING {QuoteName(staging)} AS s WHERE {JoinOn(keys)};";

    /// <summary>
    /// An insert that updates the row when the keys already exist. It returns one row for each inserted or updated row,
    /// with a flag that says whether the row was inserted. The key columns need a unique constraint or a unique index.
    /// </summary>
    internal static string BuildMerge(string staging, string table, IReadOnlyList<string> keys, IReadOnlyList<string> allColumns, IReadOnlyList<string> updateColumns)
    {
        var conflict = updateColumns.Count > 0
            ? "DO UPDATE SET " + string.Join(", ", updateColumns.Select(c => $"{QuoteColumn(c)} = EXCLUDED.{QuoteColumn(c)}"))
            : "DO NOTHING";

        return $"INSERT INTO {QuoteName(table)} ({ColumnList(allColumns, null)}) " +
               $"SELECT {ColumnList(allColumns, "s")} FROM {QuoteName(staging)} AS s " +
               $"ON CONFLICT ({ColumnList(keys, null)}) {conflict} " +
               $"RETURNING (xmax = 0) AS {QuoteName(InsertedColumn)};";
    }

    private static string JoinOn(IEnumerable<string> keys) =>
        string.Join(" AND ", keys.Select(k => $"t.{QuoteColumn(k)} = s.{QuoteColumn(k)}"));

    private static string ColumnList(IEnumerable<string> columns, string? alias) =>
        string.Join(", ", columns.Select(c => (alias is null ? string.Empty : alias + ".") + QuoteColumn(c)));
}
