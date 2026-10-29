using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyIntegerNotEmptyValidator(int StreetNumber);

public class PropertyIntegerNotEmptyValidator : ICatValidator<TestModelFor_PropertyIntegerNotEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyIntegerNotEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.StreetNumber, b =>
        {
            b.NotEmpty();
        });
    }
}