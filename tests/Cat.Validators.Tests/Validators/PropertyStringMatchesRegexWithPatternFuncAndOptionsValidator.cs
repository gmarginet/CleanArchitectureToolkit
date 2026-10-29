using System.Text.RegularExpressions;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
// ReSharper disable RedundantArgumentDefaultValue
public record TestModelFor_PropertyStringMatchesRegexWithPatternFuncAndOptionsValidator(string Name, string RegexPattern);

public class PropertyStringMatchesRegexWithPatternFuncAndOptionsValidator : ICatValidator<TestModelFor_PropertyStringMatchesRegexWithPatternFuncAndOptionsValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringMatchesRegexWithPatternFuncAndOptionsValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MatchesRegex(t => t.RegexPattern, RegexOptions.None);
        });
    }
}