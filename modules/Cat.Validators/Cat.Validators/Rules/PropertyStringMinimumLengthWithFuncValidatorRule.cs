using System;
using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the text is not shorter than the minimum taken from the model. A <c>null</c> string passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.MinimumLength"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
internal class PropertyStringMinimumLengthWithFuncValidatorRule<TModel>(
    Func<TModel, int> minimumLengthFunc
) : CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(string value, string fieldName, TModel model)
    {
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