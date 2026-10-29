using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
// ReSharper disable NotAccessedPositionalProperty.Global
public record TestModelFor_PropertyValidateValidator(string Name, TestSubModelFor_PropertyValidateValidator? Address);

public record TestSubModelFor_PropertyValidateValidator(string Street, int Number);

public class TestSubModelFor_PropertyValidateValidator_Validator : ICatValidator<TestSubModelFor_PropertyValidateValidator>
{
    public void Build(ICatValidatorBuilder<TestSubModelFor_PropertyValidateValidator> validator)
    {
        validator.AddPropertyRules(t => t.Street, b =>
        {
            b.NotEmpty();
        });
        validator.AddPropertyRules(t => t.Number, b =>
        {
            b.GreaterThan(0);
        });
    }
}

public class PropertyValidateValidator : ICatValidator<TestModelFor_PropertyValidateValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyValidateValidator> validator)
    {
        validator.AddPropertyRules(t => t.Address, b =>
        {
            b.Validate();
        });
    }
}
