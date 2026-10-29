using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringMinimumLengthWithFuncValidator(string Name, int MinimumLength);

public class PropertyStringMinimumLengthWithFuncValidator : ICatValidator<TestModelFor_PropertyStringMinimumLengthWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringMinimumLengthWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MinimumLength(t => t.MinimumLength);
        });
    }
}