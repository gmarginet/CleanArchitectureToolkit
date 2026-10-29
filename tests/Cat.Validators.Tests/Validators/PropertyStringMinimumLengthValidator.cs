using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringMinimumLengthValidator(string Name);

public class PropertyStringMinimumLengthValidator : ICatValidator<TestModelFor_PropertyStringMinimumLengthValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringMinimumLengthValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MinimumLength(10);
        });
    }
}