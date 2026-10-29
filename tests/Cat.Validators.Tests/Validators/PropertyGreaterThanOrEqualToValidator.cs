using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyGreaterThanOrEqualToValidator(int Discount);

public class PropertyGreaterThanOrEqualToValidator : ICatValidator<TestModelFor_PropertyGreaterThanOrEqualToValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyGreaterThanOrEqualToValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.GreaterThanOrEqualTo(10);
        });
    }
}