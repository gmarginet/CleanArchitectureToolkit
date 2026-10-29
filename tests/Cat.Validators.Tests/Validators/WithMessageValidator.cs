using Cat.Responses;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_WithMessageValidator(string Name);

public class WithMessageValidator : ICatValidator<TestModelFor_WithMessageValidator>
{
    public static readonly CatErrorDefinition Error = CatErrorDefinition.Create("CAT-TST-2006", "{FieldName} must be '{ExpectedValue}'");

    public void Build(ICatValidatorBuilder<TestModelFor_WithMessageValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.Equal("John").WithMessage(Error.Message);
        });
    }
}
