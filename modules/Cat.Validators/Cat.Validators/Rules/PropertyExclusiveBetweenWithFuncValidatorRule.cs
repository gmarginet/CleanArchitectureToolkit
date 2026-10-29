using System;
using System.Collections.Generic;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the value is greater than the lower bound and less than the upper bound.
/// Both bounds come from the model.
/// Fails with <see cref="CatValidatorErrorDefinitions.ExclusiveBetween"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyExclusiveBetweenWithFuncValidatorRule<TModel, TProperty>(
    Func<TModel, TProperty> lowerBoundFunc,
    Func<TModel, TProperty> upperBoundFunc
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IComparable<TProperty>, IComparable
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        lowerBoundFunc.ThrowIfNull(nameof(lowerBoundFunc));
        upperBoundFunc.ThrowIfNull(nameof(upperBoundFunc));

        var lowerBound = lowerBoundFunc(model);
        var upperBound = upperBoundFunc(model);

        lowerBound.ThrowIfGreaterThanOrEqualTo(upperBound, nameof(lowerBound), nameof(upperBound));

        if (value.CompareTo(lowerBound) > 0 && value.CompareTo(upperBound) < 0)
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