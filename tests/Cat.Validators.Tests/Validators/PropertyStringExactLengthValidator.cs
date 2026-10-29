using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringExactLengthValidator(string Name);

public class PropertyStringExactLengthValidator : ICatValidator<TestModelFor_PropertyStringExactLengthValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringExactLengthValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.ExactLength(10);
        });
    }
}