using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Validators.Abstractions;

namespace Cat.Validators;

/// <summary>
/// Base class for a property rule that works synchronously.
/// Derive from it when you write your own rule and implement <see cref="Validate"/>.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
public abstract class CatValidatorPropertyRuleBase<TModel, TProperty>
    : CatValidatorPropertyRuleAsyncBase<TModel, TProperty>
    where TModel : class
{
    /// <inheritdoc />
    protected override Task<List<ICatValidatorError>> ValidateAsync(TProperty value, string fieldName, TModel model, CancellationToken ct)
    {
        return Task.FromResult(Validate(value, fieldName, model));
    }
	
    /// <summary>
    /// Runs the rule against the property value.
    /// </summary>
    /// <param name="value">The value of the property.</param>
    /// <param name="fieldName">The name of the property.</param>
    /// <param name="model">The model that owns the property.</param>
    /// <returns>The failures found. Return <see cref="CatValidatorResult.Valid"/> when the value is valid.</returns>
    protected abstract List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model);
}