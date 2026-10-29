using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyIntegerEqualValidator(int StreetNumber);

public class PropertyIntegerEqualValidator : ICatValidator<TestModelFor_PropertyIntegerEqualValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyIntegerEqualValidator> validator)
    {
        validator.AddPropertyRules(t => t.StreetNumber, b =>
        {
            b.Equal(10);
        });
    }
}