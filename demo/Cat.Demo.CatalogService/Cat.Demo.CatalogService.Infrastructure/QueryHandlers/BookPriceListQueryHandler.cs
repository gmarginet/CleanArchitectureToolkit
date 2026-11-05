using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Demo.CatalogService.Infrastructure.DataAccess;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.CatalogService.Infrastructure.QueryHandlers;

public class BookPriceListQueryHandler : ICatQueryHandler<BookPriceListQuery, IList<BookPrice>>
{
    private readonly CatalogDbContext _dbContext;

    public BookPriceListQueryHandler(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICatResponse<IList<BookPrice>>> HandleAsync(BookPriceListQuery query, CancellationToken cancellationToken = default)
    {
        var prices = await _dbContext.BookPrices
            .AsNoTracking()
            .Where(x => query.BookIds.Contains(x.BookId))
            .ToListAsync(cancellationToken);

        return CatResponse.Ok<IList<BookPrice>>(prices);
    }
}
