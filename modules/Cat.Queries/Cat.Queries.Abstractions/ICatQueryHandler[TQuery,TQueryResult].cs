using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.Queries.Abstractions;

/// <summary>
/// Handles one kind of query.
/// Implement it once per query type. The module finds and registers it for you.
/// </summary>
/// <typeparam name="TQuery">The query this handler can answer.</typeparam>
/// <typeparam name="TQueryResult">The type of the data the handler returns.</typeparam>
public interface ICatQueryHandler<in TQuery, TQueryResult>
    where TQuery : class, ICatQuery<TQueryResult>
{
    /// <summary>
    /// Runs the query.
    /// </summary>
    /// <param name="query">The query to handle.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A response with the data when it succeeded, or the errors when it failed.</returns>
    Task<ICatResponse<TQueryResult>> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}
