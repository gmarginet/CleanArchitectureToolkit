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

public class BookSearchQueryHandler : ICatQueryHandler<BookSearchQuery, IList<Book>>
{
    private readonly CatalogDbContext _dbContext;

    public BookSearchQueryHandler(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICatResponse<IList<Book>>> HandleAsync(BookSearchQuery query, CancellationToken cancellationToken = default)
    {
        var books = _dbContext.Books
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.BookPrice)
            .AsQueryable();

        if (query.CategoryId is not null)
        {
            books = books.Where(x => x.CategoryId == query.CategoryId);
        }

        if (!string.IsNullOrWhiteSpace(query.Text))
        {
            var text = query.Text.Trim();
            books = books.Where(x => x.Title.Contains(text) || x.Author.Contains(text) || x.Isbn == text);
        }

        var result = await books.OrderBy(x => x.Title).ToListAsync(cancellationToken);
        return CatResponse.Ok<IList<Book>>(result);
    }
}
