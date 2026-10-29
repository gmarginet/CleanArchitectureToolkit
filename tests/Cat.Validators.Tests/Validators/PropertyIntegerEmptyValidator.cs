using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyIntegerEmptyValidator(int StreetNumber);

public class PropertyIntegerEmptyValidator : ICatValidator<TestModelFor_PropertyIntegerEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyIntegerEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.StreetNumber, b =>
        {
            b.Empty();
        });
    }
}