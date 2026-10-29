using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.Queries.Abstractions;

/// <summary>
/// Single entry point for running queries.
/// It finds the handler for a query, runs it through the registered decorators and returns the response.
/// </summary>
public interface ICatQueryProcessor
{
    /// <summary>
    /// Runs a query.
    /// </summary>
    /// <typeparam name="TQueryResult">The type of the data the query returns.</typeparam>
    /// <param name="catQuery">The query to run.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The response of the handler, with the data when it succeeded.</returns>
    Task<ICatResponse<TQueryResult>> ProcessAsync<TQueryResult>(ICatQuery<TQueryResult> catQuery, CancellationToken cancellationToken = default);

    /// <summary>
    /// Runs a query and blocks until it finishes.
    /// Prefer <see cref="ProcessAsync{TQueryResult}(ICatQuery{TQueryResult}, CancellationToken)"/> when you can.
    /// </summary>
    /// <typeparam name="TQueryResult">The type of the data the query returns.</typeparam>
    /// <param name="catQuery">The query to run.</param>
    /// <returns>The response of the handler, with the data when it succeeded.</returns>
    ICatResponse<TQueryResult> Process<TQueryResult>(ICatQuery<TQueryResult> catQuery);
}
