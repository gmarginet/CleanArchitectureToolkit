using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Responses;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_ModelMustAsyncValidator(string FirstName, string LastName, string FullName);

public class ModelMustAsyncValidator : ICatValidator<TestModelFor_ModelMustAsyncValidator>
{
    public static readonly CatErrorDefinition Error = CatErrorDefinition.Create("CAT-TST-2004", "The field {FieldName} has value {FullName} but it must be equal to '{FirstName} {LastName}'.");

    public void Build(ICatValidatorBuilder<TestModelFor_ModelMustAsyncValidator> validator)
    {
        validator.AddRules(b =>
        {
            b.MustAsync(FullNameRule);
        });
    }

    private static async Task<List<ICatValidatorError>> FullNameRule(TestModelFor_ModelMustAsyncValidator model, CancellationToken ct)
    {
        return await CheckFullName(model)
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

    private static Task<bool> CheckFullName(TestModelFor_ModelMustAsyncValidator model)
    {
        return Task.FromResult(model.FullName == $"{model.FirstName} {model.LastName}");
    }
}