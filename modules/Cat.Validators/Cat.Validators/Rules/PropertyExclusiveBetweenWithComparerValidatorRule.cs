using System;
using System.Collections.Generic;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the value is greater than the lower bound and less than the upper bound, using your own comparer.
/// Fails with <see cref="CatValidatorErrorDefinitions.ExclusiveBetween"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyExclusiveBetweenWithComparerValidatorRule<TModel, TProperty>(
    TProperty lowerBound,
    TProperty upperBound,
    IComparer<TProperty> comparer
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IComparable<TProperty>, IComparable
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        lowerBound.ThrowIfNull(nameof(lowerBound));
        upperBound.ThrowIfNull(nameof(upperBound));
        comparer.ThrowIfNull(nameof(comparer));
        lowerBound.ThrowIfGreaterThanOrEqualTo(upperBound, comparer, nameof(lowerBound), nameof(upperBound));

        if (comparer.Compare(value, lowerBound) > 0 && comparer.Compare(value, upperBound) < 0)
            return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.ExclusiveBetween.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.ExclusiveBetween.Message,
                lowerBound,
                upperBound,
                value
            )
        );
    }
}