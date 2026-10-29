using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyIntegerEqualWithFuncValidator(int StreetNumber, int ExpectedNumber);

public class PropertyIntegerEqualWithFuncValidator : ICatValidator<TestModelFor_PropertyIntegerEqualWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyIntegerEqualWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.StreetNumber, b =>
        {
            b.Equal(t => t.ExpectedNumber);
        });
    }
}