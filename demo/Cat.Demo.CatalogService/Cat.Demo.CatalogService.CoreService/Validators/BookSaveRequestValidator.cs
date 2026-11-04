using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.CatalogService.CoreService.Validators;

public class BookSaveRequestValidator : ICatValidator<BookSaveRequest>
{
    public void Build(ICatValidatorBuilder<BookSaveRequest> validator)
    {
        validator.AddPropertyRules(m => m.Book, b =>
        {
            b.Validate();
        });
    }
}
