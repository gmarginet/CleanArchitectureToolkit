using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.CatalogService.CoreService.Validators;

public class CategorySaveRequestValidator : ICatValidator<CategorySaveRequest>
{
    public void Build(ICatValidatorBuilder<CategorySaveRequest> validator)
    {
        validator.AddPropertyRules(m => m.Category, b =>
        {
            b.Validate();
        });
    }
}
