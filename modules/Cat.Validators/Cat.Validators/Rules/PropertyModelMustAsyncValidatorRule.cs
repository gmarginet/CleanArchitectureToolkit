using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Checks a property with your own async code that can also look at the whole model.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyModelMustAsyncValidatorRule<TModel, TProperty>(
    Func<TProperty, string, TModel, CancellationToken, Task<List<ICatValidatorError>>> predicate
) : CatValidatorPropertyRuleAsyncBase<TModel, TProperty>
    where TModel : class
{
    protected override async Task<List<ICatValidatorError>> ValidateAsync(TProperty value, string fieldName, TModel model, CancellationToken ct)
    {
        predicate.ThrowIfNull(nameof(predicate));

        return await predicate(value, fieldName, model, ct);
    }
}