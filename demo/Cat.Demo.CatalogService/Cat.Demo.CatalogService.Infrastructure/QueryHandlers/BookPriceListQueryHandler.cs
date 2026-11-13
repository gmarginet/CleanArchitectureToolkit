using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Demo.CatalogService.Infrastructure.DataAccess;
using Cat.EFCore.Queries;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.CatalogService.Infrastructure.QueryHandlers;

public class BookPriceListQueryHandler(CatalogDbContext dbContext)
    : CatEfQueryHandlerBase<CatalogDbContext, BookPriceListQuery, IList<BookPriceInfo>>(dbContext)
{
    public override async Task<ICatResponse<IList<BookPriceInfo>>> HandleAsync(BookPriceListQuery query, CancellationToken cancellationToken = default)
    {
        var prices = await Set<BookPrice>()
            .Where(x => query.BookIds.Contains(x.BookId))
            .Join(Set<Book>(), price => price.BookId, book => book.Id, (price, book) => new BookPriceInfo(book.Id, book.Isbn, price.Amount))
            .ToListAsync(cancellationToken);

        return CatResponse.Ok<IList<BookPriceInfo>>(prices);
    }
}
