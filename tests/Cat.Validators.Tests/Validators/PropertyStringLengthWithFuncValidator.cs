using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringLengthWithFuncValidator(string Name, int MinLength, int MaxLength);

public class PropertyStringLengthWithFuncValidator : ICatValidator<TestModelFor_PropertyStringLengthWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringLengthWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.Length(t => t.MinLength, t => t.MaxLength);
        });
    }
}