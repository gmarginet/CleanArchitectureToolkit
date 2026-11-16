using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Dapper.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Dapper;

namespace Cat.Dapper.SqlServer;

/// <summary>
/// Paging with plain SQL on SQL Server, with the same result as the paging of <c>Cat.EFCore.Queries</c>.
/// </summary>
public static class SqlServerPagingExtensions
{
    /// <summary>
    /// Counts all rows, then reads one page of them, in one round trip to the database.
    /// </summary>
    /// <remarks>
    /// Give the statement without an <c>ORDER BY</c>, because the helper wraps it to count the rows and adds the order itself.
    /// Every column needs a name of its own, and the statement may not start with <c>WITH</c>.
    /// Pass values through <paramref name="param"/>. The <paramref name="sql"/> and <paramref name="orderBy"/> are added to the SQL text as they are,
    /// so they must be constants of the handler and never come from user input.
    /// </remarks>
    /// <typeparam name="T">The result class. Dapper maps the columns to its properties by name.</typeparam>
    /// <param name="session">The session to run the SQL on.</param>
    /// <param name="sql">A <c>SELECT</c> statement without an <c>ORDER BY</c>.</param>
    /// <param name="orderBy">The columns to sort on, such as <c>CreatedAt DESC, Id</c>. Make the order unique, otherwise the pages have no stable order.</param>
    /// <param name="pageNumber">The number of the page to read. The first page is 1.</param>
    /// <param name="pageSize">The maximum number of rows on a page.</param>
    /// <param name="param">An object whose properties are the parameters of the SQL, or <c>null</c>.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The page, with the total row count of the whole statement.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/>, <paramref name="sql"/> or <paramref name="orderBy"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="pageNumber"/> or <paramref name="pageSize"/> is less than 1.</exception>
    public static async Task<ICatPagedList<T>> QueryPagedAsync<T>(
        this ICatDbSession session,
        string sql,
        string orderBy,
        int pageNumber,
        int pageSize,
        object? param = null,
        CancellationToken cancellationToken = default)
    {
        if (session is null) throw new ArgumentNullException(nameof(session));
        if (sql is null) throw new ArgumentNullException(nameof(sql));
        if (orderBy is null) throw new ArgumentNullException(nameof(orderBy));
        if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber));
        if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

        var parameters = new DynamicParameters(param);
        parameters.Add(SkipParameter, CalculateSkip(pageNumber, pageSize));
        parameters.Add(TakeParameter, pageSize);

        var (connection, command) = await session
            .PrepareAsync(BuildSql(sql, orderBy), parameters, cancellationToken)
            .ConfigureAwait(false);

        using var reader = await connection.QueryMultipleAsync(command).ConfigureAwait(false);
        var total = await reader.ReadSingleAsync<int>().ConfigureAwait(false);
        var items = (await reader.ReadAsync<T>().ConfigureAwait(false)).AsList();

        return new CatPagedList<T>(items, pageNumber, pageSize, total);
    }

    internal const string SkipParameter = "CatSkip";

    internal const string TakeParameter = "CatTake";

    // A page far past the end gives an empty page. The long keeps a huge page number from overflowing.
    internal static int CalculateSkip(int pageNumber, int pageSize) =>
        (int)Math.Min((long)(pageNumber - 1) * pageSize, int.MaxValue);

    internal static string BuildSql(string sql, string orderBy) =>
        $"SELECT COUNT(*) FROM ({sql}) AS CatCount;\n" +
        $"{sql}\nORDER BY {orderBy}\nOFFSET @{SkipParameter} ROWS FETCH NEXT @{TakeParameter} ROWS ONLY;";
}
