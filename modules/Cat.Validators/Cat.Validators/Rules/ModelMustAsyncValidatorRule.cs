using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Checks the whole model with your own async code.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
internal class ModelMustAsyncValidatorRule<TModel>(
    Func<TModel, CancellationToken, Task<List<ICatValidatorError>>> predicate
) : CatValidatorModelRuleAsyncBase<TModel>
    where TModel : class
{
    public override async Task<List<ICatValidatorError>> ValidateAsync(TModel model, CancellationToken ct)
    {
        return await predicate.ThrowIfNull(nameof(predicate))(model, ct);
    }
}