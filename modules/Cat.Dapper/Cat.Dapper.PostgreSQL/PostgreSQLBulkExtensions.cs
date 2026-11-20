using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Dapper.Abstractions;
using Npgsql;

namespace Cat.Dapper.PostgreSQL;

/// <summary>
/// Bulk insert, update, delete and merge on PostgreSQL, on the connection and the transaction of the session.
/// </summary>
/// <remarks>
/// Rows are objects of the same classes you already use with Dapper. A property name is a column name, and the optional column lists narrow the columns.
/// Table and column names go into the SQL text, so the helpers wrap every name in double quotes, exactly as given, and refuse a name that holds a quote.
/// A quoted name is case sensitive on PostgreSQL. Even so, give the helpers constants of your handler and never user input.
/// The helpers use the transaction of the session when one is running, and none otherwise.
/// A failure without a transaction leaves the batches that were already written.
/// Insert streams the rows with a binary <c>COPY</c>. The .NET type of a property must match the type of the column, such as <see cref="Guid"/> for <c>uuid</c>,
/// <see cref="int"/> for <c>integer</c> and a <see cref="DateTime"/> of kind Utc for <c>timestamptz</c>. An enum is written as its number.
/// Update, delete and merge fill a temporary table with <c>COPY</c> and run one statement that joins it to the target.
/// </remarks>
public static class PostgreSQLBulkExtensions
{
    /// <summary>
    /// Copies the rows into the table with a binary <c>COPY</c>. Generated values, such as an identity, are not returned.
    /// </summary>
    /// <typeparam name="T">The row class. Its property names are the column names.</typeparam>
    /// <param name="session">The session to run on.</param>
    /// <param name="rows">The rows to insert. They are streamed, never copied into a table in memory.</param>
    /// <param name="table">The target table, such as <c>public.Orders</c>.</param>
    /// <param name="columns">The columns to copy, or <c>null</c> for every public property. A column that is generated always, such as an identity, cannot be in the list.</param>
    /// <param name="batchSize">The number of rows in one <c>COPY</c>. 0 sends them all in one.</param>
    /// <param name="timeoutSeconds">The timeout of the copy in seconds, or <c>null</c> for the default. 0 means no timeout.</param>
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
        BulkPlan.Require(session, rows, table);
        var selected = BulkColumns.Select(typeof(T), columns, nameof(columns));
        ValidateColumns(selected);
        PostgreSQLBulkSql.QuoteName(table);
        if (BulkPlan.IsEmpty(rows)) return 0;

        var (connection, transaction) = await GetNpgsqlAsync(session, cancellationToken).ConfigureAwait(false);
        using var source = new EnumerableRowSource<T>(rows, selected);
        return await CopyAsync(connection, source, table, selected.Select(c => c.Name).ToList(), batchSize, timeoutSeconds, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Copies the rows of a reader into the table with a binary <c>COPY</c>. The column names of the reader are the column names of the table.
    /// </summary>
    /// <param name="session">The session to run on.</param>
    /// <param name="rows">The reader to copy from. The method does not close it.</param>
    /// <param name="table">The target table, such as <c>public.Orders</c>.</param>
    /// <param name="batchSize">The number of rows in one <c>COPY</c>. 0 sends them all in one.</param>
    /// <param name="timeoutSeconds">The timeout of the copy in seconds, or <c>null</c> for the default. 0 means no timeout.</param>
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
        PostgreSQLBulkSql.QuoteName(table);

        var names = new List<string>();
        for (var i = 0; i < rows.FieldCount; i++) names.Add(rows.GetName(i));
        foreach (var name in names) PostgreSQLBulkSql.QuoteColumn(name);

        var (connection, _) = await GetNpgsqlAsync(session, cancellationToken).ConfigureAwait(false);
        using var source = new ReaderRowSource(rows);
        return await CopyAsync(connection, source, table, names, batchSize, timeoutSeconds, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Updates the rows of the table that match the given rows on the key columns.
    /// </summary>
    /// <typeparam name="T">The row class. Its property names are the column names.</typeparam>
    /// <param name="session">The session to run on.</param>
    /// <param name="rows">The rows with the new values.</param>
    /// <param name="table">The target table, such as <c>public.Orders</c>.</param>
    /// <param name="keyColumns">The columns that identify a row.</param>
    /// <param name="updateColumns">The columns to change, or <c>null</c> for every property that is not a key column.</param>
    /// <param name="batchSize">The number of rows in one <c>COPY</c> to the temporary table. 0 sends them all in one.</param>
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
        BulkPlan.Require(session, rows, table);
        var plan = BulkPlan.Plan(typeof(T), keyColumns, updateColumns, false, ValidateColumn);
        PostgreSQLBulkSql.QuoteName(table);
        if (BulkPlan.IsEmpty(rows)) return 0;

        var staged = plan.Keys.Concat(plan.Update).ToList();
        return await RunStagedAsync(session, rows, staged, table, batchSize, timeoutSeconds, cancellationToken,
            staging => PostgreSQLBulkSql.BuildUpdate(staging, table, plan.KeyNames, plan.UpdateNames),
            async command => await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);
    }

    /// <summary>
    /// Deletes the rows of the table that match the given rows on the key columns. It covers a composite key.
    /// </summary>
    /// <typeparam name="T">The row class. Its property names are the column names.</typeparam>
    /// <param name="session">The session to run on.</param>
    /// <param name="rows">The rows to delete. Only the key columns are read.</param>
    /// <param name="table">The target table, such as <c>public.Orders</c>.</param>
    /// <param name="keyColumns">The columns that identify a row.</param>
    /// <param name="batchSize">The number of rows in one <c>COPY</c> to the temporary table. 0 sends them all in one.</param>
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
        BulkPlan.Require(session, rows, table);
        if (keyColumns is null) throw new ArgumentNullException(nameof(keyColumns));
        var keys = BulkColumns.Select(typeof(T), keyColumns, nameof(keyColumns));
        ValidateColumns(keys);
        PostgreSQLBulkSql.QuoteName(table);
        if (BulkPlan.IsEmpty(rows)) return 0;

        var keyNames = keys.Select(k => k.Name).ToList();
        return await RunStagedAsync(session, rows, keys, table, batchSize, timeoutSeconds, cancellationToken,
            staging => PostgreSQLBulkSql.BuildDelete(staging, table, keyNames),
            async command => await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);
    }

    /// <summary>
    /// Deletes the rows of the table whose key column holds one of the given values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key values, such as <c>Guid</c> or <c>int</c>. It must match the type of the column.</typeparam>
    /// <param name="session">The session to run on.</param>
    /// <param name="keys">The key values of the rows to delete.</param>
    /// <param name="table">The target table, such as <c>public.Orders</c>.</param>
    /// <param name="keyColumn">The name of the key column.</param>
    /// <param name="batchSize">The number of rows in one <c>COPY</c> to the temporary table. 0 sends them all in one.</param>
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
        BulkPlan.Require(session, keys, table);
        if (keyColumn is null) throw new ArgumentNullException(nameof(keyColumn));
        PostgreSQLBulkSql.QuoteColumn(keyColumn);
        PostgreSQLBulkSql.QuoteName(table);
        if (BulkPlan.IsEmpty(keys)) return 0;

        var column = BulkPlan.ValueColumn<TKey>(keyColumn);
        return await RunStagedAsync(session, keys, new[] { column }, table, batchSize, timeoutSeconds, cancellationToken,
            staging => PostgreSQLBulkSql.BuildDelete(staging, table, new[] { keyColumn }),
            async command => await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);
    }

    /// <summary>
    /// Updates the rows that exist and inserts the rows that do not, with one <c>INSERT ... ON CONFLICT DO UPDATE</c> statement.
    /// Rows that are missing from the given set are left alone.
    /// </summary>
    /// <remarks>
    /// The key columns need a unique constraint or a unique index, because <c>ON CONFLICT</c> uses it.
    /// The given rows must not hold the same key twice, because PostgreSQL refuses to change a row twice in one statement.
    /// Every public property of the row class is a column that is inserted. A column that is generated always, such as an identity, cannot be a property, so give the key values yourself, such as a <c>Guid</c>.
    /// </remarks>
    /// <typeparam name="T">The row class. Its property names are the column names.</typeparam>
    /// <param name="session">The session to run on.</param>
    /// <param name="rows">The rows to merge.</param>
    /// <param name="table">The target table, such as <c>public.Orders</c>.</param>
    /// <param name="keyColumns">The columns that identify a row.</param>
    /// <param name="updateColumns">The columns to change on a match, or <c>null</c> for every property that is not a key column.</param>
    /// <param name="batchSize">The number of rows in one <c>COPY</c> to the temporary table. 0 sends them all in one.</param>
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
        BulkPlan.Require(session, rows, table);
        var plan = BulkPlan.Plan(typeof(T), keyColumns, updateColumns, true, ValidateColumn);
        PostgreSQLBulkSql.QuoteName(table);
        if (BulkPlan.IsEmpty(rows)) return new CatBulkMergeResult(0, 0);

        var all = BulkColumns.ForType(typeof(T));
        var allNames = all.Select(c => c.Name).ToList();
        return await RunStagedAsync(session, rows, all, table, batchSize, timeoutSeconds, cancellationToken,
            staging => PostgreSQLBulkSql.BuildMerge(staging, table, plan.KeyNames, allNames, plan.UpdateNames),
            async command =>
            {
                var inserted = 0;
                var updated = 0;
                using var result = await command.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);
                while (await result.ReadAsync(cancellationToken).ConfigureAwait(false))
                {
                    if (result.GetBoolean(0)) inserted++;
                    else updated++;
                }

                return new CatBulkMergeResult(inserted, updated);
            }).ConfigureAwait(false);
    }

    private static void ValidateColumns(IEnumerable<BulkColumn> columns) => BulkPlan.Validate(columns, ValidateColumn);

    private static void ValidateColumn(string column) => PostgreSQLBulkSql.QuoteColumn(column);

    private static async Task<(NpgsqlConnection, NpgsqlTransaction?)> GetNpgsqlAsync(ICatDbSession session, CancellationToken cancellationToken)
    {
        var connection = await session.GetConnectionAsync(cancellationToken).ConfigureAwait(false);
        if (!(connection is NpgsqlConnection npgsqlConnection))
        {
            throw new InvalidOperationException("The bulk operations need an NpgsqlConnection, and the session gives a " + connection.GetType().Name + ".");
        }

        return (npgsqlConnection, session.Transaction as NpgsqlTransaction);
    }

    /// <summary>
    /// Writes the rows with one or more binary <c>COPY</c> operations. A new <c>COPY</c> starts after every <paramref name="batchSize"/> rows.
    /// </summary>
    private static async Task<int> CopyAsync(
        NpgsqlConnection connection,
        BulkRowSource source,
        string table,
        IReadOnlyList<string> columns,
        int batchSize,
        int? timeoutSeconds,
        CancellationToken cancellationToken)
    {
        var copySql = PostgreSQLBulkSql.BuildCopy(table, columns);
        var total = 0L;
        var more = source.Read();
        while (more)
        {
            using (var importer = await connection.BeginBinaryImportAsync(copySql, cancellationToken).ConfigureAwait(false))
            {
                if (timeoutSeconds.HasValue)
                {
                    importer.Timeout = timeoutSeconds.Value == 0 ? System.Threading.Timeout.InfiniteTimeSpan : TimeSpan.FromSeconds(timeoutSeconds.Value);
                }

                var written = 0;
                while (more && (batchSize <= 0 || written < batchSize))
                {
                    await importer.StartRowAsync(cancellationToken).ConfigureAwait(false);
                    for (var i = 0; i < source.FieldCount; i++)
                    {
                        await ImporterWriter.WriteAsync(importer, source.GetValue(i), cancellationToken).ConfigureAwait(false);
                    }

                    written++;
                    more = source.Read();
                }

                total += (long)await importer.CompleteAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        return (int)Math.Min(total, int.MaxValue);
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
        Func<NpgsqlCommand, Task<TResult>> execute)
    {
        var (connection, transaction) = await GetNpgsqlAsync(session, cancellationToken).ConfigureAwait(false);
        var staging = PostgreSQLBulkSql.NewStagingName();
        var names = stagedColumns.Select(c => c.Name).ToList();

        NpgsqlCommand NewCommand(string sql)
        {
            var command = new NpgsqlCommand(sql, connection, transaction);
            if (timeoutSeconds.HasValue) command.CommandTimeout = timeoutSeconds.Value;
            return command;
        }

        // Inside a transaction the temporary table drops on commit. Without one the module drops it itself.
        var inTransaction = transaction != null;
        using (var create = NewCommand(PostgreSQLBulkSql.BuildCreateStaging(staging, table, names, inTransaction)))
        {
            await create.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        }

        try
        {
            using (var source = new EnumerableRowSource<T>(rows, stagedColumns))
            {
                await CopyAsync(connection, source, staging, names, batchSize, timeoutSeconds, cancellationToken).ConfigureAwait(false);
            }

            using var statement = NewCommand(buildStatement(staging));
            return await execute(statement).ConfigureAwait(false);
        }
        finally
        {
            if (!inTransaction)
            {
                try
                {
                    using var drop = NewCommand(PostgreSQLBulkSql.BuildDropStaging(staging));
                    drop.ExecuteNonQuery();
                }
                catch (DbException)
                {
                    // The original error is the one that matters.
                }
            }
        }
    }
}
