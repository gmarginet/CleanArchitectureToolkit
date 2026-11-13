using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;

namespace Cat.UnitTesting.Queries;

/// <summary>
/// A query processor for unit tests. It records every query and returns what the test says.
/// A query without a set up response throws, because a fake cannot guess the data.
/// </summary>
public class FakeQueryProcessor : ICatQueryProcessor
{
    private readonly Dictionary<Type, Func<object, object>> _responses = new Dictionary<Type, Func<object, object>>();

    /// <summary>
    /// Every query that was processed, in order.
    /// </summary>
    public List<object> Queries { get; } = new List<object>();

    /// <summary>
    /// Sets the response for a query type.
    /// </summary>
    /// <typeparam name="TQuery">The query type.</typeparam>
    /// <typeparam name="TQueryResult">The type of the data the query returns.</typeparam>
    /// <param name="response">The response every query of this type gets.</param>
    /// <returns>The fake, so calls can be chained.</returns>
    public FakeQueryProcessor Respond<TQuery, TQueryResult>(ICatResponse<TQueryResult> response)
        where TQuery : ICatQuery<TQueryResult>
    {
        return Respond<TQuery, TQueryResult>(_ => response);
    }

    /// <summary>
    /// Sets the response for a query type, built from the query.
    /// </summary>
    /// <typeparam name="TQuery">The query type.</typeparam>
    /// <typeparam name="TQueryResult">The type of the data the query returns.</typeparam>
    /// <param name="respond">Builds the response from the query.</param>
    /// <returns>The fake, so calls can be chained.</returns>
    public FakeQueryProcessor Respond<TQuery, TQueryResult>(Func<TQuery, ICatResponse<TQueryResult>> respond)
        where TQuery : ICatQuery<TQueryResult>
    {
        _responses[typeof(TQuery)] = query => respond((TQuery)query);
        return this;
    }

    /// <summary>
    /// Gives the processed queries of one type, in order.
    /// </summary>
    /// <typeparam name="T">The query type.</typeparam>
    /// <returns>The queries of this type.</returns>
    public IEnumerable<T> Of<T>() => Queries.OfType<T>();

    /// <summary>
    /// Clears the recorded queries and the set up responses.
    /// </summary>
    public void Reset()
    {
        Queries.Clear();
        _responses.Clear();
    }

    /// <inheritdoc />
    public Task<ICatResponse<TQueryResult>> ProcessAsync<TQueryResult>(ICatQuery<TQueryResult> catQuery, CancellationToken cancellationToken = default)
        => Task.FromResult(Process(catQuery));

    /// <inheritdoc />
    public ICatResponse<TQueryResult> Process<TQueryResult>(ICatQuery<TQueryResult> catQuery)
    {
        Queries.Add(catQuery);

        return _responses.TryGetValue(catQuery.GetType(), out var respond)
            ? (ICatResponse<TQueryResult>)respond(catQuery)
            : throw new NotSupportedException($"No response is set up for {catQuery.GetType().Name}. Call Respond first.");
    }
}
