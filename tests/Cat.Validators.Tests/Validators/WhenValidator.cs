using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_WhenValidator(int Value, bool ShouldValidate);

public class WhenValidator : ICatValidator<TestModelFor_WhenValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_WhenValidator> validator)
    {
        validator.AddPropertyRules(t => t.Value, b =>
        {
            b.GreaterThan(0).When(t => t.ShouldValidate);
        });
    }
}
