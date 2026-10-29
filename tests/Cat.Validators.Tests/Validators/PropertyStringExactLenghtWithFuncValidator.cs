using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringExactLenghtWithFuncValidator(string Name, int ExpectedLength);

public class PropertyStringExactLenghtWithFuncValidator : ICatValidator<TestModelFor_PropertyStringExactLenghtWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringExactLenghtWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.ExactLength(t => t.ExpectedLength);
        });
    }
}