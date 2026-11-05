using System;
using System.Collections;
using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the number of items is between the minimum and the maximum, both included. A <c>null</c> collection passes.
/// Throws when the minimum is greater than the maximum.
/// Fails with <see cref="CatValidatorErrorDefinitions.CountBetween"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the collection.</typeparam>
internal class PropertyCountBetweenValidatorRule<TModel, TProperty>(
    Func<TModel, int> minFunc,
    Func<TModel, int> maxFunc
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IEnumerable?
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        if (value is null) return CatValidatorResult.Valid();

        var min = minFunc(model);
        var max = maxFunc(model);

        if (min > max)
            throw new ArgumentException($"'{nameof(min)}' ({min}) cannot be greater than '{nameof(max)}' ({max}).", nameof(min));

        var count = CollectionCount.Of(value);

        if (count >= min && count <= max) return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.CountBetween.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.CountBetween.Message,
                min,
                max,
                count
            )
        );
    }
}
