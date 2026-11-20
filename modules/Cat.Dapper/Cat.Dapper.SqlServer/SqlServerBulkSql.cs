using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Dapper.SqlServer;

/// <summary>
/// Builds the SQL text of the bulk operations. Every table and column name goes through <see cref="QuoteName"/>.
/// </summary>
internal static class SqlServerBulkSql
{
    internal const string ActionColumn = "Action";

    /// <summary>
    /// Wraps a table or column name in brackets. A table name may have up to four parts, such as <c>dbo.Orders</c>.
    /// </summary>
    internal static string QuoteName(string name)
    {
        if (name is null) throw new ArgumentNullException(nameof(name));

        var parts = name.Split('.');
        if (parts.Length > 4) throw new ArgumentException($"The name '{name}' has more than four parts.", nameof(name));

        var quoted = new string[parts.Length];
        for (var i = 0; i < parts.Length; i++)
        {
            var part = parts[i].Trim();
            if (part.Length == 0) throw new ArgumentException($"The name '{name}' has an empty part.", nameof(name));
            if (part.IndexOfAny(new[] { '[', ']' }) >= 0) throw new ArgumentException($"The name '{name}' holds a bracket.", nameof(name));
            quoted[i] = "[" + part + "]";
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

    internal static string NewStagingName() => "#CatBulk_" + Guid.NewGuid().ToString("N");

    /// <summary>
    /// An empty copy of the target with only the given columns. The types come from the target table.
    /// </summary>
    internal static string BuildCreateStaging(string staging, string table, IEnumerable<string> columns) =>
        $"SELECT TOP 0 {ColumnList(columns, null)} INTO {QuoteName(staging)} FROM {QuoteName(table)};";

    internal static string BuildDropStaging(string staging) => $"DROP TABLE IF EXISTS {QuoteName(staging)};";

    internal static string BuildUpdate(string staging, string table, IReadOnlyList<string> keys, IReadOnlyList<string> updateColumns)
    {
        var sets = string.Join(", ", updateColumns.Select(c => $"t.{QuoteColumn(c)} = s.{QuoteColumn(c)}"));
        return $"UPDATE t SET {sets} FROM {QuoteName(table)} AS t INNER JOIN {QuoteName(staging)} AS s ON {JoinOn(keys)};";
    }

    internal static string BuildDelete(string staging, string table, IReadOnlyList<string> keys) =>
        $"DELETE t FROM {QuoteName(table)} AS t INNER JOIN {QuoteName(staging)} AS s ON {JoinOn(keys)};";

    internal static string BuildMerge(string staging, string table, IReadOnlyList<string> keys, IReadOnlyList<string> allColumns, IReadOnlyList<string> updateColumns)
    {
        var sql = new StringBuilder();
        sql.Append($"DECLARE @CatActions TABLE ({QuoteName(ActionColumn)} nvarchar(10) NOT NULL);\n");
        sql.Append($"MERGE {QuoteName(table)} WITH (HOLDLOCK) AS t USING {QuoteName(staging)} AS s ON {JoinOn(keys)}\n");
        if (updateColumns.Count > 0)
        {
            var sets = string.Join(", ", updateColumns.Select(c => $"t.{QuoteColumn(c)} = s.{QuoteColumn(c)}"));
            sql.Append($"WHEN MATCHED THEN UPDATE SET {sets}\n");
        }

        sql.Append($"WHEN NOT MATCHED BY TARGET THEN INSERT ({ColumnList(allColumns, null)}) VALUES ({ColumnList(allColumns, "s")})\n");
        sql.Append("OUTPUT $action INTO @CatActions;\n");
        sql.Append($"SELECT {QuoteName(ActionColumn)}, COUNT(*) FROM @CatActions GROUP BY {QuoteName(ActionColumn)};");
        return sql.ToString();
    }

    private static string JoinOn(IEnumerable<string> keys) =>
        string.Join(" AND ", keys.Select(k => $"t.{QuoteColumn(k)} = s.{QuoteColumn(k)}"));

    private static string ColumnList(IEnumerable<string> columns, string? alias) =>
        string.Join(", ", columns.Select(c => (alias is null ? string.Empty : alias + ".") + QuoteColumn(c)));
}
