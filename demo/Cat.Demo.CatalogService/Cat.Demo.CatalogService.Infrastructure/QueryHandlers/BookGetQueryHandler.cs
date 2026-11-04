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

public class BookGetQueryHandler : ICatQueryHandler<BookGetQuery, Book>
{
    private readonly CatalogDbContext _dbContext;

    public BookGetQueryHandler(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICatResponse<Book>> HandleAsync(BookGetQuery query, CancellationToken cancellationToken = default)
    {
        var book = await _dbContext.Books
            .AsNoTracking()
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
