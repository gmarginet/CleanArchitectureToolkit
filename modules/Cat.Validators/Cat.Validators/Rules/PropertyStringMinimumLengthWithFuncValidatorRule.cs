using System;
using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the text is not shorter than the minimum taken from the model. A <c>null</c> string passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.MinimumLength"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property, a string or a sequence of characters.</typeparam>
internal class PropertyStringMinimumLengthWithFuncValidatorRule<TModel, TProperty>(
    Func<TModel, int> minimumLengthFunc
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IEnumerable<char>?
{
    protected override List<ICatValidatorError> Validate(TProperty property, string fieldName, TModel model)
    {
        var value = property.AsText();

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (value is null) return CatValidatorResult.Valid();

        var minimumLength = minimumLengthFunc(model);

        var length = value.Length;

        if (length >= minimumLength) return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.MinimumLength.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.MinimumLength.Message,
                minimumLength,
                length
            )
        );
    }
}