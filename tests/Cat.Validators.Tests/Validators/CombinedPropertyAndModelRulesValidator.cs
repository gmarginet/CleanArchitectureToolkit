using System.Collections.Generic;
using Cat.Responses;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_CombinedPropertyAndModelRulesValidator(string FirstName, string LastName, string FullName);

public class CombinedPropertyAndModelRulesValidator : ICatValidator<TestModelFor_CombinedPropertyAndModelRulesValidator>
{
    public static readonly CatErrorDefinition Error = CatErrorDefinition.Create("CAT-TST-2007", "{FieldName} mismatch");

    public void Build(ICatValidatorBuilder<TestModelFor_CombinedPropertyAndModelRulesValidator> validator)
    {
        validator.AddPropertyRules(t => t.FirstName, b =>
        {
            b.NotEmpty();
        });

        validator.AddRules(b =>
        {
            b.Must(FullNameRule);
        });
    }

    private static List<ICatValidatorError> FullNameRule(TestModelFor_CombinedPropertyAndModelRulesValidator model)
    {
        return model.FullName == $"{model.FirstName} {model.LastName}"
            ? CatValidatorResult.Valid()
            : CatValidatorResult.Invalid(
                CatValidatorError.Create(
                    code: Error.Code,
                    fieldName: "FullName",
                    message: Error.Message
                    )
            );
    }
}
