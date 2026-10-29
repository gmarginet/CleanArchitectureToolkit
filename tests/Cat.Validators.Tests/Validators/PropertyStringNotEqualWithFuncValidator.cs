using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringNotEqualWithFuncValidator(string Name, string WrongName);

public class PropertyStringNotEqualWithFuncValidator : ICatValidator<TestModelFor_PropertyStringNotEqualWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringNotEqualWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.NotEqual(t => t.WrongName);
        });
    }
}