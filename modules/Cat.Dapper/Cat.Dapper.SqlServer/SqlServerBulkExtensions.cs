using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Dapper.Abstractions;
using Microsoft.Data.SqlClient;

namespace Cat.Dapper.SqlServer;

/// <summary>
/// Bulk insert, update, delete and merge on SQL Server, on the connection and the transaction of the session.
/// </summary>
/// <remarks>
/// Rows are objects of the same classes you already use with Dapper. A property name is a column name, and the optional column lists narrow the columns.
/// Table and column names go into the SQL text, so the helpers wrap every name in brackets and refuse a name that holds a bracket.
/// Even so, give them constants of your handler and never user input.
/// The helpers use the transaction of the session when one is running, and none otherwise.
/// A failure without a transaction leaves the batches that were already written.
/// Update, delete and merge fill a temporary table on the connection with <c>SqlBulkCopy</c>, run one statement that joins it to the target, and drop it.
/// </remarks>
public static class SqlServerBulkExtensions
{
    /// <summary>
    /// Copies the rows into the table with <c>SqlBulkCopy</c>. Generated values, such as an identity, are not returned.
    /// </summary>
    /// <typeparam name="T">The row class. Its property names are the column names.</typeparam>
    /// <param name="session">The session to run on.</param>
    /// <param name="rows">The rows to insert. They are streamed, never copied into a table in memory.</param>
    /// <param name="table">The target table, such as <c>dbo.Orders</c>.</param>
    /// <param name="columns">The columns to copy, or <c>null</c> for every public property.</param>
    /// <param name="batchSize">The number of rows in a batch. 0 sends them all in one batch.</param>
    /// <param name="timeoutSeconds">The timeout of the copy in seconds, or <c>null</c> for the default of 30 seconds. 0 means no timeout.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The number of copied rows.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/>, <paramref name="rows"/> or <paramref name="table"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when a name is not valid, or a column has no property.</exception>
    public static async Task<int> BulkInsertAsync<T>(
        this ICatDbSession session,
        IEnumerable<T> rows,
        string table,
        IEnumerable<string>? columns = null,
        int batchSize = 0,
        int? timeoutSeconds = null,
        CancellationToken cancellationToken = default)
    {
        Require(session, rows, table);
        var selected = BulkColumns.Select(typeof(T), columns, nameof(columns));
        ValidateColumns(selected);
        SqlServerBulkSql.QuoteName(table);
        if (IsEmpty(rows)) return 0;

        var (connection, transaction) = await GetSqlAsync(session, cancellationToken).ConfigureAwait(false);
        using var reader = new BulkDataReader<T>(rows, selected);
        await CopyAsync(connection, transaction, reader, table, selected.Select(c => c.Name), batchSize, timeoutSeconds, cancellationToken)
            .ConfigureAwait(false);
        return reader.RowCount;
    }

    /// <summary>
    /// Copies the rows of a reader into the table with <c>SqlBulkCopy</c>. The column names of the reader are the column names of the table.
    /// </summary>
    /// <param name="session">The session to run on.</param>
    /// <param name="rows">The reader to copy from. The method does not close it.</param>
    /// <param name="table">The target table, such as <c>dbo.Orders</c>.</param>
    /// <param name="batchSize">The number of rows in a batch. 0 sends them all in one batch.</param>
    /// <param name="timeoutSeconds">The timeout of the copy in seconds, or <c>null</c> for the default of 30 seconds. 0 means no timeout.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The number of copied rows.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/>, <paramref name="rows"/> or <paramref name="table"/> is <c>null</c>.</exception>
    public static async Task<int> BulkInsertAsync(
        this ICatDbSession session,
        IDataReader rows,
        string table,
        int batchSize = 0,
        int? timeoutSeconds = null,
        CancellationToken cancellationToken = default)
    {
        if (session is null) throw new ArgumentNullException(nameof(session));
        if (rows is null) throw new ArgumentNullException(nameof(rows));
        if (table is null) throw new ArgumentNullException(nameof(table));
        SqlServerBulkSql.QuoteName(table);

        var names = new List<string>();
        for (var i = 0; i < rows.FieldCount; i++) names.Add(rows.GetName(i));
        foreach (var name in names) SqlServerBulkSql.QuoteColumn(name);

        var (connection, transaction) = await GetSqlAsync(session, cancellationToken).ConfigureAwait(false);
        var copied = 0;
        await CopyAsync(connection, transaction, rows, table, names, batchSize, timeoutSeconds, cancellationToken, c => copied = c)
            .ConfigureAwait(false);
        return copied;
    }

    /// <summary>
    /// Updates the rows of the table that match the given rows on the key columns.
    /// </summary>
    /// <typeparam name="T">The row class. Its property names are the column names.</typeparam>
    /// <param name="session">The session to run on.</param>
    /// <param name="rows">The rows with the new values.</param>
    /// <param name="table">The target table, such as <c>dbo.Orders</c>.</param>
    /// <param name="keyColumns">The columns that identify a row.</param>
    /// <param name="updateColumns">The columns to change, or <c>null</c> for every property that is not a key column.</param>
    /// <param name="batchSize">The number of rows in a batch of the copy to the temporary table. 0 sends them all in one batch.</param>
    /// <param name="timeoutSeconds">The timeout in seconds, or <c>null</c> for the default. 0 means no timeout.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The number of updated rows.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/>, <paramref name="rows"/>, <paramref name="table"/> or <paramref name="keyColumns"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when a name is not valid, a column has no property, or there is nothing to update.</exception>
    public static async Task<int> BulkUpdateAsync<T>(
        this ICatDbSession session,
        IEnumerable<T> rows,
        string table,
        IEnumerable<string> keyColumns,
        IEnumerable<string>? updateColumns = null,
        int batchSize = 0,
        int? timeoutSeconds = null,
        CancellationToken cancellationToken = default)
    {
        Require(session, rows, table);
        var plan = Plan(typeof(T), keyColumns, updateColumns);
        SqlServerBulkSql.QuoteName(table);
        if (IsEmpty(rows)) return 0;

        var staged = plan.Keys.Concat(plan.Update).ToList();
        return await RunStagedAsync(session, rows, staged, table, batchSize, timeoutSeconds, cancellationToken,
            (staging) => SqlServerBulkSql.BuildUpdate(staging, table, plan.KeyNames, plan.UpdateNames),
            async command => await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);
    }

    /// <summary>
    /// Deletes the rows of the table that match the given rows on the key columns. It covers a composite key.
    /// </summary>
    /// <typeparam name="T">The row class. Its property names are the column names.</typeparam>
    /// <param name="session">The session to run on.</param>
    /// <param name="rows">The rows to delete. Only the key columns are read.</param>
    /// <param name="table">The target table, such as <c>dbo.Orders</c>.</param>
    /// <param name="keyColumns">The columns that identify a row.</param>
    /// <param name="batchSize">The number of rows in a batch of the copy to the temporary table. 0 sends them all in one batch.</param>
    /// <param name="timeoutSeconds">The timeout in seconds, or <c>null</c> for the default. 0 means no timeout.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The number of deleted rows.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/>, <paramref name="rows"/>, <paramref name="table"/> or <paramref name="keyColumns"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when a name is not valid or a column has no property.</exception>
    public static async Task<int> BulkDeleteAsync<T>(
        this ICatDbSession session,
        IEnumerable<T> rows,
        string table,
        IEnumerable<string> keyColumns,
        int batchSize = 0,
        int? timeoutSeconds = null,
        CancellationToken cancellationToken = default)
    {
        Require(session, rows, table);
        if (keyColumns is null) throw new ArgumentNullException(nameof(keyColumns));
        var keys = BulkColumns.Select(typeof(T), keyColumns, nameof(keyColumns));
        ValidateColumns(keys);
        SqlServerBulkSql.QuoteName(table);
        if (IsEmpty(rows)) return 0;

        var keyNames = keys.Select(k => k.Name).ToList();
        return await RunStagedAsync(session, rows, keys, table, batchSize, timeoutSeconds, cancellationToken,
            staging => SqlServerBulkSql.BuildDelete(staging, table, keyNames),
            async command => await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);
    }

    /// <summary>
    /// Deletes the rows of the table whose key column holds one of the given values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key values, such as <c>Guid</c> or <c>int</c>.</typeparam>
    /// <param name="session">The session to run on.</param>
    /// <param name="keys">The key values of the rows to delete.</param>
    /// <param name="table">The target table, such as <c>dbo.Orders</c>.</param>
    /// <param name="keyColumn">The name of the key column.</param>
    /// <param name="batchSize">The number of rows in a batch of the copy to the temporary table. 0 sends them all in one batch.</param>
    /// <param name="timeoutSeconds">The timeout in seconds, or <c>null</c> for the default. 0 means no timeout.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The number of deleted rows.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/>, <paramref name="keys"/>, <paramref name="table"/> or <paramref name="keyColumn"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when a name is not valid.</exception>
    public static async Task<int> BulkDeleteAsync<TKey>(
        this ICatDbSession session,
        IEnumerable<TKey> keys,
        string table,
        string keyColumn,
        int batchSize = 0,
        int? timeoutSeconds = null,
        CancellationToken cancellationToken = default)
    {
        Require(session, keys, table);
        if (keyColumn is null) throw new ArgumentNullException(nameof(keyColumn));
        SqlServerBulkSql.QuoteColumn(keyColumn);
        SqlServerBulkSql.QuoteName(table);
        if (IsEmpty(keys)) return 0;

        var column = ValueColumn<TKey>(keyColumn);
        return await RunStagedAsync(session, keys, new[] { column }, table, batchSize, timeoutSeconds, cancellationToken,
            staging => SqlServerBulkSql.BuildDelete(staging, table, new[] { keyColumn }),
            async command => await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);
    }

    /// <summary>
    /// Updates the rows that exist and inserts the rows that do not, with one <c>MERGE</c> statement that holds <c>HOLDLOCK</c>.
    /// Rows that are missing from the given set are left alone.
    /// </summary>
    /// <remarks>
    /// Every public property of the row class is a column that is inserted. A key column that is an identity column needs <c>IDENTITY_INSERT</c>, so give the key values yourself, such as a <c>Guid</c>.
    /// </remarks>
    /// <typeparam name="T">The row class. Its property names are the column names.</typeparam>
    /// <param name="session">The session to run on.</param>
    /// <param name="rows">The rows to merge.</param>
    /// <param name="table">The target table, such as <c>dbo.Orders</c>.</param>
    /// <param name="keyColumns">The columns that identify a row.</param>
    /// <param name="updateColumns">The columns to change on a match, or <c>null</c> for every property that is not a key column.</param>
    /// <param name="batchSize">The number of rows in a batch of the copy to the temporary table. 0 sends them all in one batch.</param>
    /// <param name="timeoutSeconds">The timeout in seconds, or <c>null</c> for the default. 0 means no timeout.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The number of inserted and the number of updated rows.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/>, <paramref name="rows"/>, <paramref name="table"/> or <paramref name="keyColumns"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when a name is not valid or a column has no property.</exception>
    public static async Task<CatBulkMergeResult> BulkMergeAsync<T>(
        this ICatDbSession session,
        IEnumerable<T> rows,
        string table,
        IEnumerable<string> keyColumns,
        IEnumerable<string>? updateColumns = null,
        int batchSize = 0,
        int? timeoutSeconds = null,
        CancellationToken cancellationToken = default)
    {
        Require(session, rows, table);
        var plan = Plan(typeof(T), keyColumns, updateColumns, allowNoUpdate: true);
        SqlServerBulkSql.QuoteName(table);
        if (IsEmpty(rows)) return new CatBulkMergeResult(0, 0);

        var all = BulkColumns.ForType(typeof(T));
        var allNames = all.Select(c => c.Name).ToList();
        return await RunStagedAsync(session, rows, all, table, batchSize, timeoutSeconds, cancellationToken,
            staging => SqlServerBulkSql.BuildMerge(staging, table, plan.KeyNames, allNames, plan.UpdateNames),
            async command =>
            {
                var inserted = 0;
                var updated = 0;
                using var result = await command.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);
                while (await result.ReadAsync(cancellationToken).ConfigureAwait(false))
                {
                    var action = result.GetString(0);
                    var count = result.GetInt32(1);
                    if (action == "INSERT") inserted = count;
                    else if (action == "UPDATE") updated = count;
                }

                return new CatBulkMergeResult(inserted, updated);
            }).ConfigureAwait(false);
    }

    private sealed class ColumnPlan
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

    private static ColumnPlan Plan(Type type, IEnumerable<string> keyColumns, IEnumerable<string>? updateColumns, bool allowNoUpdate = false)
    {
        if (keyColumns is null) throw new ArgumentNullException(nameof(keyColumns));
        var keys = BulkColumns.Select(type, keyColumns, nameof(keyColumns));
        ValidateColumns(keys);

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

        ValidateColumns(update);
        if (update.Count == 0 && !allowNoUpdate)
        {
            throw new ArgumentException("There is no column to update. Every property is a key column.", nameof(updateColumns));
        }

        return new ColumnPlan(keys, update);
    }

    private static void ValidateColumns(IEnumerable<BulkColumn> columns)
    {
        foreach (var column in columns) SqlServerBulkSql.QuoteColumn(column.Name);
    }

    private static void Require<T>(ICatDbSession session, IEnumerable<T> rows, string table)
    {
        if (session is null) throw new ArgumentNullException(nameof(session));
        if (rows is null) throw new ArgumentNullException(nameof(rows));
        if (table is null) throw new ArgumentNullException(nameof(table));
    }

    private static bool IsEmpty<T>(IEnumerable<T> rows) =>
        rows is ICollection<T> { Count: 0 } || rows is IReadOnlyCollection<T> { Count: 0 };

    private static BulkColumn ValueColumn<TKey>(string name)
    {
        var type = Nullable.GetUnderlyingType(typeof(TKey)) ?? typeof(TKey);
        if (type.IsEnum) type = Enum.GetUnderlyingType(type);
        return new BulkColumn(name, type, value => value);
    }

    private static async Task<(SqlConnection, SqlTransaction?)> GetSqlAsync(ICatDbSession session, CancellationToken cancellationToken)
    {
        var connection = await session.GetConnectionAsync(cancellationToken).ConfigureAwait(false);
        if (!(connection is SqlConnection sqlConnection))
        {
            throw new InvalidOperationException("The bulk operations need a SqlConnection, and the session gives a " + connection.GetType().Name + ".");
        }

        return (sqlConnection, session.Transaction as SqlTransaction);
    }

    private static async Task CopyAsync(
        SqlConnection connection,
        SqlTransaction? transaction,
        IDataReader reader,
        string table,
        IEnumerable<string> columns,
        int batchSize,
        int? timeoutSeconds,
        CancellationToken cancellationToken,
        Action<int>? copied = null)
    {
        // KeepIdentity: a staging table keeps the identity property of the target, and the key values must arrive as they are.
        using var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction)
        {
            DestinationTableName = SqlServerBulkSql.QuoteName(table),
            BatchSize = batchSize,
        };
        if (timeoutSeconds.HasValue) bulkCopy.BulkCopyTimeout = timeoutSeconds.Value;
        foreach (var column in columns) bulkCopy.ColumnMappings.Add(column, column);

        await bulkCopy.WriteToServerAsync(reader, cancellationToken).ConfigureAwait(false);
        copied?.Invoke((int)Math.Min(bulkCopy.RowsCopied64, int.MaxValue));
    }

    private static async Task<TResult> RunStagedAsync<T, TResult>(
        ICatDbSession session,
        IEnumerable<T> rows,
        IReadOnlyList<BulkColumn> stagedColumns,
        string table,
        int batchSize,
        int? timeoutSeconds,
        CancellationToken cancellationToken,
        Func<string, string> buildStatement,
        Func<SqlCommand, Task<TResult>> execute)
    {
        var (connection, transaction) = await GetSqlAsync(session, cancellationToken).ConfigureAwait(false);
        var staging = SqlServerBulkSql.NewStagingName();
        var names = stagedColumns.Select(c => c.Name).ToList();

        SqlCommand NewCommand(string sql)
        {
            var command = new SqlCommand(sql, connection, transaction);
            if (timeoutSeconds.HasValue) command.CommandTimeout = timeoutSeconds.Value;
            return command;
        }

        using (var create = NewCommand(SqlServerBulkSql.BuildCreateStaging(staging, table, names)))
        {
            await create.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        }

        try
        {
            using (var reader = new BulkDataReader<T>(rows, stagedColumns))
            {
                await CopyAsync(connection, transaction, reader, staging, names, batchSize, timeoutSeconds, cancellationToken)
                    .ConfigureAwait(false);
            }

            using var statement = NewCommand(buildStatement(staging));
            return await execute(statement).ConfigureAwait(false);
        }
        finally
        {
            try
            {
                using var drop = NewCommand(SqlServerBulkSql.BuildDropStaging(staging));
                drop.ExecuteNonQuery();
            }
            catch (DbException)
            {
                // The original error is the one that matters. A rolled back transaction has already removed the table.
            }
        }
    }
}
