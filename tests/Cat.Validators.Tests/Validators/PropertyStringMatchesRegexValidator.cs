using System.Text.RegularExpressions;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringMatchesRegexValidator(string Name);

public partial class PropertyStringMatchesRegexValidator : ICatValidator<TestModelFor_PropertyStringMatchesRegexValidator>
{
    [GeneratedRegex("^[jJ][oO][hH][nN]")]
    private static partial Regex Regex();

    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringMatchesRegexValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MatchesRegex(Regex());
        });
    }
}