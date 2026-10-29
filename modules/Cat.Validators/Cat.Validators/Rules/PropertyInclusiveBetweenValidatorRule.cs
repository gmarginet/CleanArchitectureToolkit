using System;
using System.Collections.Generic;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the value is between the bounds, bounds included.
/// Fails with <see cref="CatValidatorErrorDefinitions.InclusiveBetween"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyInclusiveBetweenValidatorRule<TModel, TProperty>(
    TProperty lowerBound,
    TProperty upperBound
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IComparable<TProperty>, IComparable
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        lowerBound.ThrowIfNull(nameof(lowerBound));
        upperBound.ThrowIfNull(nameof(upperBound));
        lowerBound.ThrowIfGreaterThanOrEqualTo(upperBound, nameof(lowerBound), nameof(upperBound));

        if (value.CompareTo(lowerBound) >= 0 && value.CompareTo(upperBound) <= 0)
            return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.InclusiveBetween.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.InclusiveBetween.Message,
                lowerBound,
                upperBound,
                value
            )
        );
    }
}