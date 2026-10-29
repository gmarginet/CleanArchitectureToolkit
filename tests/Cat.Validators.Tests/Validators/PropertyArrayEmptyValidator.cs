using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyArrayEmptyValidator(string[] Names);

public class PropertyArrayEmptyValidator : ICatValidator<TestModelFor_PropertyArrayEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyArrayEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Names, b =>
        {
            b.Empty();
        });
    }
}