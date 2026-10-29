using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringNotEqualValidator(string Name);

public class PropertyStringNotEqualValidator : ICatValidator<TestModelFor_PropertyStringNotEqualValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringNotEqualValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.NotEqual("John Doe");
        });
    }
}