using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyNullValidator(string? Name);

public class PropertyNullValidator : ICatValidator<TestModelFor_PropertyNullValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyNullValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.Null();
        });
    }
}