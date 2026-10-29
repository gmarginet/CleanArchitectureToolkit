using System.Text.RegularExpressions;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
// ReSharper disable RedundantArgumentDefaultValue
public record TestModelFor_PropertyStringMatchesRegexWithPatternAndOptionsValidator(string Name);

public class PropertyStringMatchesRegexWithPatternAndOptionsValidator : ICatValidator<TestModelFor_PropertyStringMatchesRegexWithPatternAndOptionsValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringMatchesRegexWithPatternAndOptionsValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MatchesRegex("^[jJ][oO][hH][nN]", RegexOptions.None);
        });
    }
}