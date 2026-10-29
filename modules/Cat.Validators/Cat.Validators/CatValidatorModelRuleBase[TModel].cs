using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Validators.Abstractions;

namespace Cat.Validators;

/// <summary>
/// Base class for a model rule that works synchronously.
/// Derive from it when you write your own rule and implement <see cref="Validate"/>.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
public abstract class CatValidatorModelRuleBase<TModel>
    : CatValidatorModelRuleAsyncBase<TModel>
    where TModel : class
{
    /// <inheritdoc />
    public override Task<List<ICatValidatorError>> ValidateAsync(TModel model, CancellationToken ct)
    {
        return Task.FromResult(Validate(model));
    }

    /// <summary>
    /// Runs the rule.
    /// </summary>
    /// <param name="model">The model to check.</param>
    /// <returns>The failures found. Return <see cref="CatValidatorResult.Valid"/> when the model is valid.</returns>
    protected abstract List<ICatValidatorError> Validate(TModel model);
}