using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Responses;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyMustAsyncWithPropertyValidator(string FirstName, string LastName, string FullName);

public class PropertyMustAsyncWithPropertyValidator : ICatValidator<TestModelFor_PropertyMustAsyncWithPropertyValidator>
{
    public static readonly CatErrorDefinition Error = CatErrorDefinition.Create("CAT-TST-2000", "The field {FieldName} has value {Value} but it must be equal to 'John Doe'.");

    public void Build(ICatValidatorBuilder<TestModelFor_PropertyMustAsyncWithPropertyValidator> validator)
    {
        validator.AddPropertyRules(t => t.FullName, b =>
        {
            b.MustAsync(FullNameRule);
        });
    }

    private static async Task<List<ICatValidatorError>> FullNameRule(string value, string fieldName, CancellationToken ct)
    {
        return await CheckFullName(value)
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
    
    private static Task<bool> CheckFullName(string value)
    {
        return Task.FromResult(value == "John Doe");
    }
}