using System;
using System.Collections.Concurrent;
using Cat.Validators.Abstractions;

namespace Cat.Validators;

/// <summary>
/// Default <see cref="ICatValidatorModelRuleBuilder{TModel}"/>.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
public class CatValidatorModelRuleBuilder<TModel>(
    ConcurrentQueue<ICatValidatorModelRule<TModel>> rules
) : ICatValidatorModelRuleBuilder<TModel>
    where TModel : class
{
    /// <summary>
    /// Adds a rule to the validator.
    /// </summary>
    /// <typeparam name="TRule">The type of the rule.</typeparam>
    /// <param name="newRule">The rule to add. It must derive from <see cref="CatValidatorModelRuleAsyncBase{TModel}"/>.</param>
    /// <exception cref="ArgumentException">The rule doesn't derive from <see cref="CatValidatorModelRuleAsyncBase{TModel}"/>.</exception>
    public void AddRule<TRule>(TRule newRule)
        where TRule : class, ICatValidatorModelRule<TModel>
    {
        if (newRule is not CatValidatorModelRuleAsyncBase<TModel> rule)
            throw new ArgumentException($"Rule {typeof(TRule).Name} is not a valid model rule");
        
        rules.Enqueue(rule);
    }
}