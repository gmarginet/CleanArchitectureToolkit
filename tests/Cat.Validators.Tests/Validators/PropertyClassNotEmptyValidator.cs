using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyClassNotEmptyValidator(TestSubModelFor_PropertyClassNotEmptyValidator? Address);

public record TestSubModelFor_PropertyClassNotEmptyValidator(string Street, int StreetNumber);

public class PropertyClassNotEmptyValidator : ICatValidator<TestModelFor_PropertyClassNotEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyClassNotEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Address, b =>
        {
            b.NotEmpty();
        });
    }
}