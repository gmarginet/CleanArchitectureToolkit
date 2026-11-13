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

public class CheckIsbnExistsQueryHandler(CatalogDbContext dbContext)
    : CatEfQueryHandlerBase<CatalogDbContext, CheckIsbnExistsQuery, bool>(dbContext)
{
    public override async Task<ICatResponse<bool>> HandleAsync(CheckIsbnExistsQuery query, CancellationToken cancellationToken = default)
    {
        var exists = await Set<Book>()
            .AnyAsync(x => x.Isbn == query.Isbn && x.Id != query.ExcludeBookId, cancellationToken);

        return CatResponse.Ok(exists);
    }
}
