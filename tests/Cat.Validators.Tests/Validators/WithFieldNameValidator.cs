using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_WithFieldNameValidator(string? Name);

public class WithFieldNameValidator : ICatValidator<TestModelFor_WithFieldNameValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_WithFieldNameValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.NotNull().WithFieldName("CustomName");
        });
    }
}
