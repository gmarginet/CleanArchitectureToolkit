using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the text matches a regular expression taken from the model. A <c>null</c> string passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.MatchesRegex"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
internal class PropertyStringMatchesRegexWithFuncValidatorRule<TModel>(
    Func<TModel, Regex> regexFunc
) : CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(string value, string fieldName, TModel model)
    {
        regexFunc.ThrowIfNull(nameof(regexFunc));

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (value is null) return CatValidatorResult.Valid();

        var regex = regexFunc(model);

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