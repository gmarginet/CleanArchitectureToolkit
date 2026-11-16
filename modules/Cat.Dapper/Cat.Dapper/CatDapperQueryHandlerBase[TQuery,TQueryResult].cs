using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Dapper.Abstractions;
using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;

namespace Cat.Dapper;

/// <summary>
/// Base class for query handlers that read with plain SQL and Dapper.
/// It holds the <see cref="ICatDbSession"/>. Run the SQL with the extension methods of <see cref="CatDbSessionExtensions"/>.
/// </summary>
/// <typeparam name="TQuery">The query this handler can answer.</typeparam>
/// <typeparam name="TQueryResult">The type of the data the handler returns.</typeparam>
public abstract class CatDapperQueryHandlerBase<TQuery, TQueryResult> : ICatQueryHandler<TQuery, TQueryResult>
    where TQuery : class, ICatQuery<TQueryResult>
{
    /// <summary>
    /// Creates the handler.
    /// </summary>
    /// <param name="session">The session to read with.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/> is <c>null</c>.</exception>
    protected CatDapperQueryHandlerBase(ICatDbSession session)
    {
        Session = session ?? throw new ArgumentNullException(nameof(session));
    }

    /// <summary>
    /// The session to read with.
    /// </summary>
    protected ICatDbSession Session { get; }

    /// <inheritdoc />
    public abstract Task<ICatResponse<TQueryResult>> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}
