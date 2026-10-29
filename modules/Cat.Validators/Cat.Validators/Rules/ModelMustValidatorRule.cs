using System;
using System.Collections.Generic;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Checks the whole model with your own code.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
internal class ModelMustValidatorRule<TModel>(
    Func<TModel, List<ICatValidatorError>> predicate
) : CatValidatorModelRuleBase<TModel>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(TModel model)
    {
        predicate.ThrowIfNull(nameof(predicate));

        return predicate(model);
    }
}