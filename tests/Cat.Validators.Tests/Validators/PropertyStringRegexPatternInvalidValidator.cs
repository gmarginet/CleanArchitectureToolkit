using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringRegexPatternInvalidValidator(string Name);

public class PropertyStringRegexPatternInvalidValidator : ICatValidator<TestModelFor_PropertyStringRegexPatternInvalidValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringRegexPatternInvalidValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MatchesRegex("[unclosed"); // malformed regex, invalid on purpose
        });
    }
}
