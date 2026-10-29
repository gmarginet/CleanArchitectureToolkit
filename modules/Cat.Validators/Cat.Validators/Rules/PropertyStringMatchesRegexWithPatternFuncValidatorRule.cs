using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.String.Extensions;
using Cat.Strings.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the text matches a regular expression pattern taken from the model. A <c>null</c> string passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.MatchesRegex"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
internal class PropertyStringMatchesRegexWithPatternFuncValidatorRule<TModel>(
    Func<TModel, string> regexPatternFunc,
    RegexOptions options = RegexOptions.None
) : CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(string value, string fieldName, TModel model)
    {
        regexPatternFunc.ThrowIfNull(nameof(regexPatternFunc));

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (value is null) return CatValidatorResult.Valid();

        var regexPattern = regexPatternFunc(model);
        var regex = regexPattern.CreateRegex(options);

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