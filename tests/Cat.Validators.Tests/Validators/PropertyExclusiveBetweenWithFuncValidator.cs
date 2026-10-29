using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyExclusiveBetweenWithFuncValidator(int Discount, int MinDiscount, int MaxDiscount);

public class PropertyExclusiveBetweenWithFuncValidator : ICatValidator<TestModelFor_PropertyExclusiveBetweenWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyExclusiveBetweenWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.ExclusiveBetween(t => t.MinDiscount, t => t.MaxDiscount);
        });
    }
}