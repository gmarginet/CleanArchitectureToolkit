using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Demo.CatalogService.Infrastructure.DataAccess;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.CatalogService.Infrastructure.QueryHandlers;

public class BookPriceListQueryHandler : ICatQueryHandler<BookPriceListQuery, IList<BookPriceInfo>>
{
    private readonly CatalogDbContext _dbContext;

    public BookPriceListQueryHandler(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICatResponse<IList<BookPriceInfo>>> HandleAsync(BookPriceListQuery query, CancellationToken cancellationToken = default)
    {
        var prices = await _dbContext.BookPrices
            .AsNoTracking()
            .Where(x => query.BookIds.Contains(x.BookId))
            .Join(_dbContext.Books, price => price.BookId, book => book.Id, (price, book) => new BookPriceInfo(book.Id, book.Isbn, price.Amount))
            .ToListAsync(cancellationToken);

        return CatResponse.Ok<IList<BookPriceInfo>>(prices);
    }
}
