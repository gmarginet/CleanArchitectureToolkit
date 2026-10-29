using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyGreaterThanValidator(int Discount);

public class PropertyGreaterThanValidator : ICatValidator<TestModelFor_PropertyGreaterThanValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyGreaterThanValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.GreaterThan(10);
        });
    }
}