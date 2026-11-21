using System;
using System.Collections.Generic;
using Cat.Queries.Abstractions;

namespace Cat.Caching.Abstractions;

/// <summary>
/// Lists the query types that are cached. Nothing is cached by default, also no query.
/// The options are registered as a service, so a test can read <see cref="Rules"/> and check that a query type is not cached.
/// </summary>
public sealed class CatQueryCacheOptions
{
    private readonly Dictionary<Type, CatQueryCacheRule> _rules = new Dictionary<Type, CatQueryCacheRule>();

    /// <summary>
    /// How long an entry lives when the rule of a query type sets no lifetime. The default is 5 minutes.
    /// </summary>
    public TimeSpan DefaultExpiration { get; set; } = TimeSpan.FromMinutes(5);

    /// <summary>
    /// The cached query types and their rules.
    /// </summary>
    public IReadOnlyDictionary<Type, CatQueryCacheRule> Rules => _rules;

    /// <summary>
    /// Caches a query type. Every other query is not cached.
    /// Never cache a query that a write or a price decision depends on, such as a query that prices an order or checks for a duplicate.
    /// </summary>
    /// <typeparam name="TQuery">The query type, which implements <c>ICatQuery&lt;TQueryResult&gt;</c>.</typeparam>
    /// <param name="configure">Sets the lifetime, the tags and the other settings of the query type. Optional.</param>
    /// <returns>The same options, for chaining.</returns>
    /// <exception cref="ArgumentException">The type is not a query.</exception>
    public CatQueryCacheOptions Cache<TQuery>(Action<CatQueryCacheRule<TQuery>>? configure = null)
        where TQuery : class
    {
        if (!IsQuery(typeof(TQuery)))
        {
            throw new ArgumentException($"{typeof(TQuery).Name} is not a query. It must implement ICatQuery<TQueryResult>.");
        }

        var rule = new CatQueryCacheRule<TQuery>();
        configure?.Invoke(rule);
        _rules[typeof(TQuery)] = rule;
        return this;
    }

    private static bool IsQuery(Type type)
    {
        foreach (var contract in type.GetInterfaces())
        {
            if (contract.IsGenericType && contract.GetGenericTypeDefinition() == typeof(ICatQuery<>))
            {
                return true;
            }
        }

        return false;
    }
}
