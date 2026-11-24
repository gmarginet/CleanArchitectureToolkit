using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the text has exactly the given length. A <c>null</c> string passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.ExactLength"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property, a string or a sequence of characters.</typeparam>
internal class PropertyStringExactLengthValidatorRule<TModel, TProperty>(
    int exactLength
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IEnumerable<char>?
{
    protected override List<ICatValidatorError> Validate(TProperty property, string fieldName, TModel model)
    {
        var value = property.AsText();

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (value is null) return CatValidatorResult.Valid();

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