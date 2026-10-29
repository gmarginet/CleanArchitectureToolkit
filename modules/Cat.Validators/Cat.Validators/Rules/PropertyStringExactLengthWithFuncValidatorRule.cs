using System;
using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the text has exactly the length taken from the model. A <c>null</c> string passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.ExactLength"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
internal class PropertyStringExactLengthWithFuncValidatorRule<TModel>(
    Func<TModel, int> exactLengthFunc
) : CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(string value, string fieldName, TModel model)
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (value is null) return CatValidatorResult.Valid();

        var exactLength = exactLengthFunc(model);

        var length = value.Length;

        if (length == exactLength) return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.ExactLength.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.ExactLength.Message,
                exactLength,
                length
            )
        );
    }
}