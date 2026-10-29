using System.Collections.Generic;
using Cat.Responses;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyMustWithPropertyAndModelValidator(string FirstName, string LastName, string FullName);

public class PropertyMustWithPropertyAndModelValidator : ICatValidator<TestModelFor_PropertyMustWithPropertyAndModelValidator>
{
    public static readonly CatErrorDefinition Error = CatErrorDefinition.Create("CAT-TST-2003", "The field {FieldName} has value {Value} but it must be equal to '{FirstName} {LastName}'.");

    public void Build(ICatValidatorBuilder<TestModelFor_PropertyMustWithPropertyAndModelValidator> validator)
    {
        validator.AddPropertyRules(t => t.FullName, b =>
        {
            b.Must(FullNameRule);
        });
    }

    private static List<ICatValidatorError> FullNameRule(string value, string fieldName, TestModelFor_PropertyMustWithPropertyAndModelValidator model)
    {
        return model.FullName == $"{model.FirstName} {model.LastName}"
            ? CatValidatorResult.Valid()
            : CatValidatorResult.Invalid(
                CatValidatorError.Create(
                    code: Error.Code,
                    fieldName: fieldName,
                    message: Error.Message,
                    value,
                    model.FirstName,
                    model.LastName
                )
            );
    }
}