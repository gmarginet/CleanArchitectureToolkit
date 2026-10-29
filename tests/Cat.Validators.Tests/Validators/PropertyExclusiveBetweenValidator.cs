using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyExclusiveBetweenValidator(int Discount);

public class PropertyExclusiveBetweenValidator : ICatValidator<TestModelFor_PropertyExclusiveBetweenValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyExclusiveBetweenValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.ExclusiveBetween(10, 20);
        });
    }
}