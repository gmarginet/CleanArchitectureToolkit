using System;
using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the value is greater than the given value.
/// Fails with <see cref="CatValidatorErrorDefinitions.GreaterThan"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyGreaterThanValidatorRule<TModel, TProperty>(
    TProperty valueToCompare
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IComparable<TProperty>, IComparable
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        if (value.CompareTo(valueToCompare) > 0) return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.GreaterThan.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.GreaterThan.Message,
                valueToCompare
            )
        );
    }
}