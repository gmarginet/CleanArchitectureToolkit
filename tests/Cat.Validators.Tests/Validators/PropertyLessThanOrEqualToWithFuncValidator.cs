using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyLessThanOrEqualToWithFuncValidator(int Discount, int HighestDiscount);

public class PropertyLessThanOrEqualToWithFuncValidator : ICatValidator<TestModelFor_PropertyLessThanOrEqualToWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyLessThanOrEqualToWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.LessThanOrEqualTo(t => t.HighestDiscount);
        });
    }
}