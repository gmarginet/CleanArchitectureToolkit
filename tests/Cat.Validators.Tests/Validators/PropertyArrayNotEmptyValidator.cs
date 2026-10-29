using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyArrayNotEmptyValidator(string[] Names);

public class PropertyArrayNotEmptyValidator : ICatValidator<TestModelFor_PropertyArrayNotEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyArrayNotEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Names, b =>
        {
            b.NotEmpty();
        });
    }
}