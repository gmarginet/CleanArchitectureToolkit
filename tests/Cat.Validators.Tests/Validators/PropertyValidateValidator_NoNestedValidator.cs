using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
// ReSharper disable NotAccessedPositionalProperty.Global
// TestSubModelFor_PropertyValidateValidator_NoValidator deliberately has no ICatValidator<T>
// registered, used to test that Validate() throws when the nested type has none, unless validatorRequired is false.
public record TestSubModelFor_PropertyValidateValidator_NoValidator(string Street);

public record TestModelFor_PropertyValidateValidator_NoNestedValidator(string Name, TestSubModelFor_PropertyValidateValidator_NoValidator Address);

public class PropertyValidateValidator_NoNestedValidator : ICatValidator<TestModelFor_PropertyValidateValidator_NoNestedValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyValidateValidator_NoNestedValidator> validator)
    {
        validator.AddPropertyRules(t => t.Address, b =>
        {
            b.Validate();
        });
    }
}
