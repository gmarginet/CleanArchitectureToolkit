using System.Text.RegularExpressions;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringMatchesRegexWithFuncValidator(string Name, Regex Regex);

public class PropertyStringMatchesRegexWithFuncValidator : ICatValidator<TestModelFor_PropertyStringMatchesRegexWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringMatchesRegexWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MatchesRegex(t => t.Regex);
        });
    }
}