using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyIntegerNotEqualValidator(int StreetNumber);

public class PropertyIntegerNotEqualValidator: ICatValidator<TestModelFor_PropertyIntegerNotEqualValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyIntegerNotEqualValidator> validator)
    {
        validator.AddPropertyRules(t => t.StreetNumber, b =>
        {
            b.NotEqual(10);
        });
    }
}