using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringNotEmptyValidator(string Name);

public class PropertyStringNotEmptyValidator : ICatValidator<TestModelFor_PropertyStringNotEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringNotEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.NotEmpty();
        });
    }
}