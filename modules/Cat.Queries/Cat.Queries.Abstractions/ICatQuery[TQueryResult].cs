namespace Cat.Queries.Abstractions;

/// <summary>
/// Marks a query that reads data and returns it in a response.
/// Handle it with <see cref="ICatQueryHandler{TQuery,TQueryResult}"/>.
/// </summary>
/// <typeparam name="TQueryResult">The type of the data the handler returns.</typeparam>
public interface ICatQuery<out TQueryResult>
{
}