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

public class CategoryGetListQueryHandler(CatalogDbContext dbContext)
    : CatEfQueryHandlerBase<CatalogDbContext, CategoryGetListQuery, IList<Category>>(dbContext)
{
    public override async Task<ICatResponse<IList<Category>>> HandleAsync(CategoryGetListQuery query, CancellationToken cancellationToken = default)
    {
        var result = await Set<Category>()
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);

        return CatResponse.Ok<IList<Category>>(result);
    }
}
