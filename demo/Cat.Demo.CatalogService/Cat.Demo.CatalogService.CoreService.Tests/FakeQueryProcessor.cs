using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.Tests;

/// <summary>
/// A query processor for tests. It answers the ISBN check without a database.
/// </summary>
public class FakeQueryProcessor : ICatQueryProcessor
{
    /// <summary>The answer to the ISBN check.</summary>
    public bool IsbnExists { get; set; }

    /// <summary>Makes the ISBN check fail with an internal server error.</summary>
    public bool FailLookup { get; set; }

    /// <summary>Every ISBN check that was asked for.</summary>
    public List<CheckIsbnExistsQuery> IsbnQueries { get; } = [];

    /// <summary>Every query that was processed, in order.</summary>
    public List<object> Queries { get; } = [];

    private readonly Dictionary<Type, object> _responses = [];

    /// <summary>Sets the response for a query type.</summary>
    public void Setup<TQuery, TQueryResult>(ICatResponse<TQueryResult> response)
        where TQuery : ICatQuery<TQueryResult>
    {
        _responses[typeof(TQuery)] = response;
    }

    public void Reset()
    {
        IsbnExists = false;
        FailLookup = false;
        IsbnQueries.Clear();
        Queries.Clear();
        _responses.Clear();
    }

    public Task<ICatResponse<TQueryResult>> ProcessAsync<TQueryResult>(ICatQuery<TQueryResult> catQuery, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Process(catQuery));
    }

    public ICatResponse<TQueryResult> Process<TQueryResult>(ICatQuery<TQueryResult> catQuery)
    {
        Queries.Add(catQuery);

        if (catQuery is not CheckIsbnExistsQuery isbnQuery)
        {
            if (_responses.TryGetValue(catQuery.GetType(), out var configured))
            {
                return (ICatResponse<TQueryResult>)configured;
            }

            throw new NotSupportedException($"The fake has no response for {catQuery.GetType().Name}.");
        }

        IsbnQueries.Add(isbnQuery);

        ICatResponse<bool> response = FailLookup
            ? CatResponse.InternalServerError<bool>()
            : CatResponse.Ok(IsbnExists);

        return (ICatResponse<TQueryResult>)response;
    }
}
