using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringMaximumLengthWithFuncValidator(string Name, int MaximumLength);

public class PropertyStringMaximumLengthWithFuncValidator : ICatValidator<TestModelFor_PropertyStringMaximumLengthWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringMaximumLengthWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MaximumLength(t => t.MaximumLength);
        });
    }
}