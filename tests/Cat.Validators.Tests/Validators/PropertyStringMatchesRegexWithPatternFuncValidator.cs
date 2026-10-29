using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringMatchesRegexWithPatternFuncValidator(string Name, string RegexPattern);

public class PropertyStringMatchesRegexWithPatternFuncValidator : ICatValidator<TestModelFor_PropertyStringMatchesRegexWithPatternFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringMatchesRegexWithPatternFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MatchesRegex(t => t.RegexPattern);
        });
    }
}