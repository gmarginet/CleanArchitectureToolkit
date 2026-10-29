using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_MultipleWhenValidator(int Value, bool FlagA, bool FlagB);

public class MultipleWhenValidator : ICatValidator<TestModelFor_MultipleWhenValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_MultipleWhenValidator> validator)
    {
        validator.AddPropertyRules(t => t.Value, b =>
        {
            b.GreaterThan(0)
                .When(t => t.FlagA)
                .When(t => t.FlagB);
        });
    }
}
