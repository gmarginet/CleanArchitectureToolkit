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

public class BookGetQueryHandler(CatalogDbContext dbContext)
    : CatEfQueryHandlerBase<CatalogDbContext, BookGetQuery, Book>(dbContext)
{
    public override async Task<ICatResponse<Book>> HandleAsync(BookGetQuery query, CancellationToken cancellationToken = default)
    {
        var book = await Set<Book>()
            .Include(x => x.Category)
            .Include(x => x.BookPrice)
            .FirstOrDefaultAsync(x => x.Id == query.BookId, cancellationToken);

        return book is null
            ? CatResponse.NotFound<Book>(
                CatError.Create(
                    CatGeneralErrorDefinitions.ResourceNotFound.Code,
                    CatGeneralErrorDefinitions.ResourceNotFound.Message,
                    "Book",
                    query.BookId))
            : CatResponse.Ok(book);
    }
}
