using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyNotNullValidator(string? Name);

public class PropertyNotNullValidator : ICatValidator<TestModelFor_PropertyNotNullValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyNotNullValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.NotNull();
        });
    }
}