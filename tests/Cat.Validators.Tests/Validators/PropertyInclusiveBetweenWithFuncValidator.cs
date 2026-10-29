using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyInclusiveBetweenWithFuncValidator(int Discount, int MinDiscount, int MaxDiscount);

public class PropertyInclusiveBetweenWithFuncValidator : ICatValidator<TestModelFor_PropertyInclusiveBetweenWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyInclusiveBetweenWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.InclusiveBetween(t => t.MinDiscount, t => t.MaxDiscount);
        });
    }
}