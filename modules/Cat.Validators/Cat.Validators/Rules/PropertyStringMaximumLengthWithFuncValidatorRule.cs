using System;
using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the text is not longer than the maximum taken from the model. A <c>null</c> string passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.MaximumLength"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property, a string or a sequence of characters.</typeparam>
internal class PropertyStringMaximumLengthWithFuncValidatorRule<TModel, TProperty>(
    Func<TModel, int> maximumLengthFunc
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IEnumerable<char>?
{
    protected override List<ICatValidatorError> Validate(TProperty property, string fieldName, TModel model)
    {
        var value = property.AsText();

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (value is null) return CatValidatorResult.Valid();

        var maximumLength = maximumLengthFunc(model);

        var length = value.Length;

        if (length <= maximumLength) return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.MaximumLength.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.MaximumLength.Message,
                maximumLength,
                length
            )
        );
    }
}