using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringEqualValidator(string Name);

public class PropertyStringEqualValidator : ICatValidator<TestModelFor_PropertyStringEqualValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringEqualValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.Equal("John Doe");
        });
    }
}