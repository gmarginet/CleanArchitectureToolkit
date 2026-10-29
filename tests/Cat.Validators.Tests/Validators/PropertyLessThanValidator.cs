using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyLessThanValidator(int Discount);

public class PropertyLessThanValidator : ICatValidator<TestModelFor_PropertyLessThanValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyLessThanValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.LessThan(10);
        });
    }
}