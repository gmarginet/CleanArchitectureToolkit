using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringLengthInvalidValidator(string Name);

public class PropertyStringLengthInvalidValidator : ICatValidator<TestModelFor_PropertyStringLengthInvalidValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringLengthInvalidValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.Length(20, 10); // min > max, invalid on purpose
        });
    }
}
