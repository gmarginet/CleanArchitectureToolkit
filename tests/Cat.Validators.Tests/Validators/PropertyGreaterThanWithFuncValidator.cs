using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyGreaterThanWithFuncValidator(int Discount, int LowestDiscount);

public class PropertyGreaterThanWithFuncValidator : ICatValidator<TestModelFor_PropertyGreaterThanWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyGreaterThanWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.GreaterThan(t => t.LowestDiscount);
        });
    }
}