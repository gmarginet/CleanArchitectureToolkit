using System;
using System.Collections.Generic;
using Cat.Extensions.Objects;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the text length is between the minimum and the maximum. A <c>null</c> string passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.Length"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property, a string or a sequence of characters.</typeparam>
internal class PropertyStringLengthValidatorRule<TModel, TProperty>(
    int min,
    int max
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IEnumerable<char>?
{
    protected override List<ICatValidatorError> Validate(TProperty property, string fieldName, TModel model)
    {
        var value = property.AsText();

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (value is null) return CatValidatorResult.Valid();

        min.ThrowIfGreaterThanOrEqualTo(max, nameof(min), nameof(max));

        var length = value.Length;

        if (length >= min && (length <= max || max == -1))
            return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.Length.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.Length.Message,
                min,
                max,
                length
            )
        );
    }
}