using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the text matches the regular expression. A <c>null</c> string passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.MatchesRegex"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
internal class PropertyStringMatchesRegexValidatorRule<TModel>(
    Regex regex
) : CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(string value, string fieldName, TModel model)
    {
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