using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Demo.CatalogService.Infrastructure.DataAccess;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.CatalogService.Infrastructure.QueryHandlers;

public class CheckIsbnExistsQueryHandler : ICatQueryHandler<CheckIsbnExistsQuery, bool>
{
    private readonly CatalogDbContext _dbContext;

    public CheckIsbnExistsQueryHandler(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICatResponse<bool>> HandleAsync(CheckIsbnExistsQuery query, CancellationToken cancellationToken = default)
    {
        var exists = await _dbContext.Books
            .AsNoTracking()
            .AnyAsync(x => x.Isbn == query.Isbn && x.Id != query.ExcludeBookId, cancellationToken);

        return CatResponse.Ok(exists);
    }
}
