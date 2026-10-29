using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringEmptyValidator(string Name);

public class PropertyStringEmptyValidator : ICatValidator<TestModelFor_PropertyStringEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.Empty();
        });
    }
}