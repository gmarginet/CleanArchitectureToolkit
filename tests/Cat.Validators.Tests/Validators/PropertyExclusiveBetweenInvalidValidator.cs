using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyExclusiveBetweenInvalidValidator(int Value);

public class PropertyExclusiveBetweenInvalidValidator : ICatValidator<TestModelFor_PropertyExclusiveBetweenInvalidValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyExclusiveBetweenInvalidValidator> validator)
    {
        validator.AddPropertyRules(t => t.Value, b =>
        {
            b.ExclusiveBetween(20, 10); // lowerBound > upperBound, invalid on purpose
        });
    }
}
