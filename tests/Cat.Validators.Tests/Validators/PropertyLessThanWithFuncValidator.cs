using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyLessThanWithFuncValidator(int Discount, int HighestDiscount);

public class PropertyLessThanWithFuncValidator : ICatValidator<TestModelFor_PropertyLessThanWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyLessThanWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.LessThan(t => t.HighestDiscount);
        });
    }
}