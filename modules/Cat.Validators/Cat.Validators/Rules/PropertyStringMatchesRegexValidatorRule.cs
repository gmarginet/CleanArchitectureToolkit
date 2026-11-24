using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Cat.Extensions.Objects;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the text matches the regular expression. A <c>null</c> string passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.MatchesRegex"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property, a string or a sequence of characters.</typeparam>
internal class PropertyStringMatchesRegexValidatorRule<TModel, TProperty>(
    Regex regex
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IEnumerable<char>?
{
    protected override List<ICatValidatorError> Validate(TProperty property, string fieldName, TModel model)
    {
        var value = property.AsText();

        regex.ThrowIfNull(nameof(regex));

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (value is null) return CatValidatorResult.Valid();

        if (regex.IsMatch(value)) return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.MatchesRegex.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.MatchesRegex.Message,
                regex.ToString()
            )
        );
    }
}