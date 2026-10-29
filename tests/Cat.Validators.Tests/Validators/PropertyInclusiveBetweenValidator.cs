using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyInclusiveBetweenValidator(int Discount);

public class PropertyInclusiveBetweenValidator : ICatValidator<TestModelFor_PropertyInclusiveBetweenValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyInclusiveBetweenValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.InclusiveBetween(10, 20);
        });
    }
}