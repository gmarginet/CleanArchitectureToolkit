using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.CatalogService.CoreService.Validators;

public class CategoryEditModelValidator : ICatValidator<CategoryEditModel>
{
    public void Build(ICatValidatorBuilder<CategoryEditModel> validator)
    {
        validator.AddPropertyRules(m => m.Name, b =>
        {
            b.NotEmpty();
            b.MaximumLength(100);
        });

        validator.AddPropertyRules(m => m.NameNl, b =>
        {
            b.MaximumLength(100);
        });
    }
}
