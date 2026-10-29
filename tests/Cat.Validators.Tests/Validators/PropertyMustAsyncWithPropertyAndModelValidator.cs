using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Responses;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyMustAsyncWithPropertyAndModelValidator(string FirstName, string LastName, string FullName);

public class PropertyMustAsyncWithPropertyAndModelValidator : ICatValidator<TestModelFor_PropertyMustAsyncWithPropertyAndModelValidator>
{
    public static readonly CatErrorDefinition Error = CatErrorDefinition.Create("CAT-TST-2002", "The field {FieldName} has value {Value} but it must be equal to '{FirstName} {LastName}'.");

    public void Build(ICatValidatorBuilder<TestModelFor_PropertyMustAsyncWithPropertyAndModelValidator> validator)
    {
        validator.AddPropertyRules(t => t.FullName, b =>
        {
            b.MustAsync(FullNameRule);
        });
    }

    private static async Task<List<ICatValidatorError>> FullNameRule(string value, string fieldName, TestModelFor_PropertyMustAsyncWithPropertyAndModelValidator model, CancellationToken ct)
    {
        return await CheckFullName(value, model)
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

    private static Task<bool> CheckFullName(string value, TestModelFor_PropertyMustAsyncWithPropertyAndModelValidator model)
    {
        return Task.FromResult(value == $"{model.FirstName} {model.LastName}");
    }
}