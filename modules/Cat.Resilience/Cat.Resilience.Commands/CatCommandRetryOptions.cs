using System;
using System.Collections.Generic;
using Cat.Commands.Abstractions;
using Cat.Resilience.Abstractions;

namespace Cat.Resilience.Commands;

/// <summary>
/// Lists the command types that are retried. Nothing is retried by default.
/// </summary>
public sealed class CatCommandRetryOptions
{
    private readonly Dictionary<Type, CatRetryRule> _rules = new Dictionary<Type, CatRetryRule>();

    /// <summary>
    /// Retries a command type through a resilience profile. Every other command is called once.
    /// </summary>
    /// <typeparam name="TCommand">The command type, an <see cref="ICatCommand"/> or an <c>ICatCommand&lt;TResult&gt;</c>.</typeparam>
    /// <param name="profile">The name of the profile. The default is <see cref="CatResilienceProfile.Internal"/>.</param>
    /// <param name="configure">Changes which failed responses are tried again. Optional.</param>
    /// <returns>The same options, for chaining.</returns>
    /// <exception cref="ArgumentException">The type is not a command.</exception>
    public CatCommandRetryOptions Retry<TCommand>(string profile = CatResilienceProfile.Internal, Action<CatRetryRule>? configure = null)
        where TCommand : class
    {
        if (!IsCommand(typeof(TCommand)))
        {
            throw new ArgumentException($"{typeof(TCommand).Name} is not a command. It must implement ICatCommand or ICatCommand<TResult>.");
        }

        var rule = new CatRetryRule(profile);
        configure?.Invoke(rule);
        _rules[typeof(TCommand)] = rule;
        return this;
    }

    internal bool HasRules => _rules.Count > 0;

    internal bool TryGetRule(Type commandType, out CatRetryRule rule) => _rules.TryGetValue(commandType, out rule!);

    private static bool IsCommand(Type type)
    {
        if (typeof(ICatCommand).IsAssignableFrom(type))
        {
            return true;
        }

        foreach (var contract in type.GetInterfaces())
        {
            if (contract.IsGenericType && contract.GetGenericTypeDefinition() == typeof(ICatCommand<>))
            {
                return true;
            }
        }

        return false;
    }
}
