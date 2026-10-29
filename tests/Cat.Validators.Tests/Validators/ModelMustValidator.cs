using System.Collections.Generic;
using Cat.Responses;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_ModelMustValidator(string FirstName, string LastName, string FullName);

public class ModelMustValidator : ICatValidator<TestModelFor_ModelMustValidator>
{
    public static readonly CatErrorDefinition Error = CatErrorDefinition.Create("CAT-TST-2005", "The field {FieldName} has value {FullName} but it must be equal to '{FirstName} {LastName}'.");

    public void Build(ICatValidatorBuilder<TestModelFor_ModelMustValidator> validator)
    {
        validator.AddRules(b =>
        {
            b.Must(FullNameRule);
        });
    }

    private static List<ICatValidatorError> FullNameRule(TestModelFor_ModelMustValidator model)
    {
        return model.FullName == $"{model.FirstName} {model.LastName}"
            ? CatValidatorResult.Valid()
            : CatValidatorResult.Invalid(
                CatValidatorError.Create(
                      code: Error.Code,
                      fieldName: "FullName",
                      message: Error.Message,
                      model.FullName,
                      model.FirstName,
                      model.LastName
                  )
              );
    }
}