using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringMaximumLengthValidator(string Name);

public class PropertyStringMaximumLengthValidator : ICatValidator<TestModelFor_PropertyStringMaximumLengthValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringMaximumLengthValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MaximumLength(10);
        });
    }
}