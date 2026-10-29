using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using Cat.Expressions.Abstractions;
using Cat.Validators.Abstractions;

namespace Cat.Validators;

/// <summary>
/// Default <see cref="ICatValidatorBuilder{TModel}"/>.
/// Gathers the rules of one validator run.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
internal class CatValidatorBuilder<TModel>(
    ICatCompiledMemberExpressionCache<TModel> compiledMemberExpressionCache,
    CatValidatorProcessor validatorProcessor,
    bool validatorRequired = true
) : ICatValidatorBuilder<TModel>
    where TModel : class
{
    /// <summary>
    /// The rules added so far.
    /// </summary>
    public ConcurrentQueue<ICatValidatorModelRule<TModel>> Rules { get; } = new();

    /// <inheritdoc />
    public ICatValidatorBuilder<TModel> AddRules(Action<ICatValidatorModelRuleBuilder<TModel>> build)
    {
        var ruleBuilder = new CatValidatorModelRuleBuilder<TModel>(Rules);
        build(ruleBuilder);
        return this;
    }

    /// <inheritdoc />
    public ICatValidatorBuilder<TModel> AddPropertyRules<TProperty>(Expression<Func<TModel, TProperty>> expression,
        Action<ICatValidatorPropertyRuleBuilder<TModel, TProperty>> build)
    {
        var ruleBuilder = new CatValidatorPropertyRuleBuilder<TModel, TProperty>(Rules, expression, compiledMemberExpressionCache, validatorProcessor, validatorRequired);
        build(ruleBuilder);
        return this;
    }
}