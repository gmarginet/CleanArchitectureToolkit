using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringLengthValidator(string Name);

public class PropertyStringLengthValidator : ICatValidator<TestModelFor_PropertyStringLengthValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringLengthValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.Length(10, 20);
        });
    }
}