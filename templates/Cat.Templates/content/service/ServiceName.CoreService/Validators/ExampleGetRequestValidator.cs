using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;
using ServiceName.Contracts.ServiceRequests;

namespace ServiceName.CoreService.Validators;

public class ExampleGetRequestValidator : ICatValidator<ExampleGetRequest>
{
    public void Build(ICatValidatorBuilder<ExampleGetRequest> validator)
    {
        validator.AddPropertyRules(m => m.ExampleId, b =>
        {
            b.NotEmpty();
        });
    }
}
