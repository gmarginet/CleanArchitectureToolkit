using System.Collections.Generic;
using Cat.Responses;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
// ReSharper disable NotAccessedPositionalProperty.Global
public record TestModelFor_PropertyMustWithPropertyValidator(string FirstName, string LastName, string FullName);

public class PropertyMustWithPropertyValidator : ICatValidator<TestModelFor_PropertyMustWithPropertyValidator>
{
    public static readonly CatErrorDefinition Error = CatErrorDefinition.Create("CAT-TST-2001", "The field {FieldNAme} has value {Value} but it must be equal to 'John Doe'.");

    public void Build(ICatValidatorBuilder<TestModelFor_PropertyMustWithPropertyValidator> validator)
    {
        validator.AddPropertyRules(t => t.FullName, b =>
        {
            b.Must(FullNameRule);
        });
    }

    private static List<ICatValidatorError> FullNameRule(string value, string fieldName)
    {
        return value == "John Doe"
            ? CatValidatorResult.Valid()
            : CatValidatorResult.Invalid(
                CatValidatorError.Create(
                    code: Error.Code,
                    fieldName: fieldName,
                    message: Error.Message,
                    value
                )
            );
    }
}