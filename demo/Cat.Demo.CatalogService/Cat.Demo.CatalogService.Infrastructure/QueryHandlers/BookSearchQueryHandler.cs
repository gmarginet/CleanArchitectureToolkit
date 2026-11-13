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

public class BookSearchQueryHandler(CatalogDbContext dbContext)
    : CatEfQueryHandlerBase<CatalogDbContext, BookSearchQuery, IList<Book>>(dbContext)
{
    public override async Task<ICatResponse<IList<Book>>> HandleAsync(BookSearchQuery query, CancellationToken cancellationToken = default)
    {
        IQueryable<Book> books = Set<Book>()
            .Include(x => x.Category)
            .Include(x => x.BookPrice);

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
