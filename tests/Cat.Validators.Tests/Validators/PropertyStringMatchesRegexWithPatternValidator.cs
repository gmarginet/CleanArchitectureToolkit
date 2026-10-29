using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringMatchesRegexWithPatternValidator(string Name);

public class PropertyStringMatchesRegexWithPatternValidator : ICatValidator<TestModelFor_PropertyStringMatchesRegexWithPatternValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringMatchesRegexWithPatternValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MatchesRegex("^[jJ][oO][hH][nN]");
        });
    }
}