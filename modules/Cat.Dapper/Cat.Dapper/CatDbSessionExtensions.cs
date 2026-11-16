using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Dapper.Abstractions;
using Dapper;

namespace Cat.Dapper;

/// <summary>
/// Runs plain SQL on a <see cref="ICatDbSession"/> with Dapper. Every method opens the connection when it is needed
/// and takes part in the transaction of the session, if one is running.
/// </summary>
/// <remarks>
/// Pass values only through <c>param</c>, never by building the SQL text from user input. Dapper sends them as parameters.
/// </remarks>
public static class CatDbSessionExtensions
{
    /// <summary>
    /// Runs a query and returns every row.
    /// </summary>
    /// <typeparam name="T">The result class. Dapper maps the columns to its properties by name.</typeparam>
    /// <param name="session">The session to run the SQL on.</param>
    /// <param name="sql">The SQL text.</param>
    /// <param name="param">An object whose properties are the parameters of the SQL, or <c>null</c>.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The rows, in the order the database returned them.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/> or <paramref name="sql"/> is <c>null</c>.</exception>
    public static async Task<IReadOnlyList<T>> QueryAsync<T>(this ICatDbSession session, string sql, object? param = null, CancellationToken cancellationToken = default)
    {
        var (connection, command) = await PrepareAsync(session, sql, param, cancellationToken).ConfigureAwait(false);
        var rows = await connection.QueryAsync<T>(command).ConfigureAwait(false);
        return rows.AsList();
    }

    /// <summary>
    /// Runs a query and returns the first row, or the default value when there is none.
    /// </summary>
    /// <typeparam name="T">The result class.</typeparam>
    /// <param name="session">The session to run the SQL on.</param>
    /// <param name="sql">The SQL text.</param>
    /// <param name="param">An object whose properties are the parameters of the SQL, or <c>null</c>.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The first row, or <c>default</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/> or <paramref name="sql"/> is <c>null</c>.</exception>
    public static async Task<T?> QueryFirstOrDefaultAsync<T>(this ICatDbSession session, string sql, object? param = null, CancellationToken cancellationToken = default)
    {
        var (connection, command) = await PrepareAsync(session, sql, param, cancellationToken).ConfigureAwait(false);
        return await connection.QueryFirstOrDefaultAsync<T>(command).ConfigureAwait(false);
    }

    /// <summary>
    /// Runs a query that has to return zero or one row.
    /// </summary>
    /// <typeparam name="T">The result class.</typeparam>
    /// <param name="session">The session to run the SQL on.</param>
    /// <param name="sql">The SQL text.</param>
    /// <param name="param">An object whose properties are the parameters of the SQL, or <c>null</c>.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The row, or <c>default</c> when there is none.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/> or <paramref name="sql"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the query returns more than one row.</exception>
    public static async Task<T?> QuerySingleOrDefaultAsync<T>(this ICatDbSession session, string sql, object? param = null, CancellationToken cancellationToken = default)
    {
        var (connection, command) = await PrepareAsync(session, sql, param, cancellationToken).ConfigureAwait(false);
        return await connection.QuerySingleOrDefaultAsync<T>(command).ConfigureAwait(false);
    }

    /// <summary>
    /// Runs a statement that returns no rows, such as an insert, an update or a stored procedure.
    /// </summary>
    /// <param name="session">The session to run the SQL on.</param>
    /// <param name="sql">The SQL text.</param>
    /// <param name="param">An object whose properties are the parameters of the SQL, or <c>null</c>.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The number of rows the statement changed.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/> or <paramref name="sql"/> is <c>null</c>.</exception>
    public static async Task<int> ExecuteAsync(this ICatDbSession session, string sql, object? param = null, CancellationToken cancellationToken = default)
    {
        var (connection, command) = await PrepareAsync(session, sql, param, cancellationToken).ConfigureAwait(false);
        return await connection.ExecuteAsync(command).ConfigureAwait(false);
    }

    /// <summary>
    /// Runs a statement and returns the first column of the first row, such as a count or a new id.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="session">The session to run the SQL on.</param>
    /// <param name="sql">The SQL text.</param>
    /// <param name="param">An object whose properties are the parameters of the SQL, or <c>null</c>.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/> or <paramref name="sql"/> is <c>null</c>.</exception>
    public static async Task<T?> ExecuteScalarAsync<T>(this ICatDbSession session, string sql, object? param = null, CancellationToken cancellationToken = default)
    {
        var (connection, command) = await PrepareAsync(session, sql, param, cancellationToken).ConfigureAwait(false);
        return await connection.ExecuteScalarAsync<T>(command).ConfigureAwait(false);
    }

    /// <summary>
    /// Builds the Dapper command for a piece of SQL, with the transaction of the session. Use it to call Dapper directly,
    /// for example for <c>QueryMultipleAsync</c>.
    /// </summary>
    /// <param name="session">The session to run the SQL on.</param>
    /// <param name="sql">The SQL text.</param>
    /// <param name="param">An object whose properties are the parameters of the SQL, or <c>null</c>.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The open connection of the session, and the command to run on it.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/> or <paramref name="sql"/> is <c>null</c>.</exception>
    public static async Task<(System.Data.Common.DbConnection Connection, CommandDefinition Command)> PrepareAsync(
        this ICatDbSession session,
        string sql,
        object? param = null,
        CancellationToken cancellationToken = default)
    {
        if (session is null) throw new ArgumentNullException(nameof(session));
        if (sql is null) throw new ArgumentNullException(nameof(sql));

        var connection = await session.GetConnectionAsync(cancellationToken).ConfigureAwait(false);
        var command = new CommandDefinition(sql, param, session.Transaction, cancellationToken: cancellationToken);
        return (connection, command);
    }
}
