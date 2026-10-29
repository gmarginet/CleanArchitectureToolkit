using System;
using System.Collections.Generic;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the text length is between the minimum and the maximum. A <c>null</c> string passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.Length"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
internal class PropertyStringLengthValidatorRule<TModel>(
    int min,
    int max
) : CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(string value, string fieldName, TModel model)
    {
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