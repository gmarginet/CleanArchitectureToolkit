using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyIntegerNotEqualWithFuncValidator(int StreetNumber, int WrongNumber);

public class PropertyIntegerNotEqualWithFuncValidator : ICatValidator<TestModelFor_PropertyIntegerNotEqualWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyIntegerNotEqualWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.StreetNumber, b =>
        {
            b.NotEqual(t => t.WrongNumber);
        });
    }
}