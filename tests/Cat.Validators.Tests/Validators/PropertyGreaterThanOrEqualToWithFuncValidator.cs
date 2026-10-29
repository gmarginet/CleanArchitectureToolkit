using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyGreaterThanOrEqualToWithFuncValidator(int Discount, int LowestDiscount);

public class PropertyGreaterThanOrEqualToWithFuncValidator : ICatValidator<TestModelFor_PropertyGreaterThanOrEqualToWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyGreaterThanOrEqualToWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.GreaterThanOrEqualTo(t => t.LowestDiscount);
        });
    }
}