using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyLessThanOrEqualToValidator(int Discount);

public class PropertyLessThanOrEqualToValidator : ICatValidator<TestModelFor_PropertyLessThanOrEqualToValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyLessThanOrEqualToValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.LessThanOrEqualTo(10);
        });
    }
}