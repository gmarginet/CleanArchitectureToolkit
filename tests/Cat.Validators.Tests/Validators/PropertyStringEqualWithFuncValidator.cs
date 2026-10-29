using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringEqualWithFuncValidator(string Name, string ExpectedName);

public class PropertyStringEqualWithFuncValidator : ICatValidator<TestModelFor_PropertyStringEqualWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringEqualWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.Equal(t => t.ExpectedName);
        });
    }
}