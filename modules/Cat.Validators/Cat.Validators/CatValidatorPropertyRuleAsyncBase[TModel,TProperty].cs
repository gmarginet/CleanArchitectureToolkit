using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Cat.Expression.Extensions;
using Cat.Expressions.Abstractions;
using Cat.Expressions.Extensions;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators;

/// <summary>
/// Base class for a property rule that needs async work.
/// Derive from it when you write your own rule. Use <see cref="CatValidatorPropertyRuleBase{TModel,TProperty}"/> for sync work.
/// The builder fills in the property expression, the cache and the processor when you add the rule.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
public abstract class CatValidatorPropertyRuleAsyncBase<TModel, TProperty>
    : CatValidatorModelRuleAsyncBase<TModel>, ICatValidatorPropertyRule<TModel, TProperty>
    where TModel : class
{
    /// <summary>
    /// Picks the property the rule checks.
    /// </summary>
    public Expression<Func<TModel, TProperty>>? PropertyExpression { get; set; }

    /// <summary>
    /// Reads the property value from the model.
    /// </summary>
    public ICatCompiledMemberExpressionCache<TModel>? CompiledMemberExpressionCache { get; set; }

    /// <summary>
    /// The processor that runs nested validators.
    /// </summary>
    public CatValidatorProcessor? ValidatorProcessor { get; set; }

    /// <summary>
    /// Whether nested validators must exist. It follows the <c>validatorRequired</c> flag of the top level call.
    /// </summary>
    public bool ValidatorRequired { get; set; } = true;

    /// <inheritdoc />
    public string? ErrorCode { get; set; }

    /// <inheritdoc />
    public string? FieldName { get; set; }

    /// <inheritdoc />
    public string? ErrorMessage { get; set; }

    /// <inheritdoc />
    public override async Task<List<ICatValidatorError>> ValidateAsync(TModel model, CancellationToken ct)
    {
        PropertyExpression.ThrowIfNull(nameof(PropertyExpression));
        CompiledMemberExpressionCache.ThrowIfNull(nameof(CompiledMemberExpressionCache));
        ValidatorProcessor.ThrowIfNull(nameof(ValidatorProcessor));
		
        var memberInfo = PropertyExpression.GetMemberInfo();
        var fieldName = memberInfo?.Name ?? "Unknown FieldName";
        var getValue = CompiledMemberExpressionCache.GetOrAdd(PropertyExpression, memberInfo);
        var value = getValue(model);
    
        return await ValidateAsync(value, fieldName, model, ct);
    }
	
    /// <summary>
    /// Runs the rule against the property value.
    /// </summary>
    /// <param name="value">The value of the property.</param>
    /// <param name="fieldName">The name of the property.</param>
    /// <param name="model">The model that owns the property.</param>
    /// <param name="ct">Token to cancel the work.</param>
    /// <returns>The failures found. Return <see cref="CatValidatorResult.Valid"/> when the value is valid.</returns>
    protected abstract Task<List<ICatValidatorError>> ValidateAsync(TProperty value, string fieldName, TModel model, CancellationToken ct);
}