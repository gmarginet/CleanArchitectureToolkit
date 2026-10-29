using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using Cat.Expressions.Abstractions;
using Cat.Validators.Abstractions;

namespace Cat.Validators;

/// <summary>
/// Default <see cref="ICatValidatorPropertyRuleBuilder{TModel,TProperty}"/>.
/// Hands each new rule the property expression, the expression cache and the processor.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
public class CatValidatorPropertyRuleBuilder<TModel, TProperty>(
    ConcurrentQueue<ICatValidatorModelRule<TModel>> rules,
    Expression<Func<TModel, TProperty>> propertyExpression,
    ICatCompiledMemberExpressionCache<TModel> compiledMemberExpressionCache,
    CatValidatorProcessor validatorProcessor,
    bool validatorRequired = true
) : ICatValidatorPropertyRuleBuilder<TModel, TProperty>
    where TModel : class
{
    /// <summary>
    /// Adds a rule for the property.
    /// </summary>
    /// <typeparam name="TRule">The type of the rule.</typeparam>
    /// <param name="newRule">The rule to add. It must derive from <see cref="CatValidatorPropertyRuleAsyncBase{TModel,TProperty}"/>.</param>
    /// <returns>A builder for the rule options, like a condition or a custom message.</returns>
    /// <exception cref="ArgumentException">The rule doesn't derive from <see cref="CatValidatorPropertyRuleAsyncBase{TModel,TProperty}"/>.</exception>
    public ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> AddPropertyRule<TRule>(TRule newRule)
        where TRule : class, ICatValidatorPropertyRule<TModel, TProperty>
    {
        if (newRule is not CatValidatorPropertyRuleAsyncBase<TModel, TProperty> rule)
            throw new ArgumentException($"Rule {typeof(TRule).Name} is not a valid property rule");
        
        rule.PropertyExpression = propertyExpression;
        rule.CompiledMemberExpressionCache = compiledMemberExpressionCache;
        rule.ValidatorProcessor = validatorProcessor;
        rule.ValidatorRequired = validatorRequired;
        
        rules.Enqueue(rule);
        return new CatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>(newRule);
    }
}