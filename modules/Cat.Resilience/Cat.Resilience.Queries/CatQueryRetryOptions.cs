using System;
using System.Collections.Generic;
using Cat.Queries.Abstractions;
using Cat.Resilience.Abstractions;

namespace Cat.Resilience.Queries;

/// <summary>
/// Lists the query types that are retried. Nothing is retried by default, also no query.
/// </summary>
public sealed class CatQueryRetryOptions
{
    private readonly Dictionary<Type, CatRetryRule> _rules = new Dictionary<Type, CatRetryRule>();

    /// <summary>
    /// Retries a query type through a resilience profile. Every other query is called once.
    /// </summary>
    /// <typeparam name="TQuery">The query type, which implements <c>ICatQuery&lt;TQueryResult&gt;</c>.</typeparam>
    /// <param name="profile">The name of the profile. The default is <see cref="CatResilienceProfile.Internal"/>.</param>
    /// <param name="configure">Changes which failed responses are tried again. Optional.</param>
    /// <returns>The same options, for chaining.</returns>
    /// <exception cref="ArgumentException">The type is not a query.</exception>
    public CatQueryRetryOptions Retry<TQuery>(string profile = CatResilienceProfile.Internal, Action<CatRetryRule>? configure = null)
        where TQuery : class
    {
        if (!IsQuery(typeof(TQuery)))
        {
            throw new ArgumentException($"{typeof(TQuery).Name} is not a query. It must implement ICatQuery<TQueryResult>.");
        }

        var rule = new CatRetryRule(profile);
        configure?.Invoke(rule);
        _rules[typeof(TQuery)] = rule;
        return this;
    }

    internal bool HasRules => _rules.Count > 0;

    internal bool TryGetRule(Type queryType, out CatRetryRule rule) => _rules.TryGetValue(queryType, out rule!);

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
