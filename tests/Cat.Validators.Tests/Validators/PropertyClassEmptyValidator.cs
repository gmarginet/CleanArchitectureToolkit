using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyClassEmptyValidator(TestSubModelFor_PropertyClassEmptyValidator? Address);

public record TestSubModelFor_PropertyClassEmptyValidator(string Street, int StreetNumber);

public class PropertyIntegerClassValidator : ICatValidator<TestModelFor_PropertyClassEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyClassEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Address, b =>
        {
            b.Empty();
        });
    }
}