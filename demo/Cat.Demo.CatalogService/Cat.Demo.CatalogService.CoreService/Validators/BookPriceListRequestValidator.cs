using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.CatalogService.CoreService.Validators;

public class BookPriceListRequestValidator : ICatValidator<BookPriceListRequest>
{
    /// <summary>The most books one call can ask for. 100 ids fit in a url of about 5 KB, below the 8 KB limit many proxies use.</summary>
    public const int MaximumBooks = 100;

    public void Build(ICatValidatorBuilder<BookPriceListRequest> validator)
    {
        validator.AddPropertyRules(m => m.BookIds, b =>
        {
            b.NotEmpty();
            b.MaximumCount(MaximumBooks);
        });
    }
}
