using System;
using System.Collections.Generic;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Checks a property with your own code.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyMustValidatorRule<TModel, TProperty>(
    Func<TProperty, string, List<ICatValidatorError>> predicate
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        predicate.ThrowIfNull(nameof(predicate));

        return predicate(value, fieldName);
    }
}