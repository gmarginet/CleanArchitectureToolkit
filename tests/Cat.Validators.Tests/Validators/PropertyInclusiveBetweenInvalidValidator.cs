using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyInclusiveBetweenInvalidValidator(int Value);

public class PropertyInclusiveBetweenInvalidValidator : ICatValidator<TestModelFor_PropertyInclusiveBetweenInvalidValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyInclusiveBetweenInvalidValidator> validator)
    {
        validator.AddPropertyRules(t => t.Value, b =>
        {
            b.InclusiveBetween(20, 10); // lowerBound > upperBound, invalid on purpose
        });
    }
}
