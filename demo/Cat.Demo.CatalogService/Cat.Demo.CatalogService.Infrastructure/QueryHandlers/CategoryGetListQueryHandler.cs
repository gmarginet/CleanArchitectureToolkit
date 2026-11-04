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

public class CategoryGetListQueryHandler : ICatQueryHandler<CategoryGetListQuery, IList<Category>>
{
    private readonly CatalogDbContext _dbContext;

    public CategoryGetListQueryHandler(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICatResponse<IList<Category>>> HandleAsync(CategoryGetListQuery query, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Categories
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);

        return CatResponse.Ok<IList<Category>>(result);
    }
}
