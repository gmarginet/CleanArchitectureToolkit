using System;
using System.Collections.Generic;
using Cat.Demo.CatalogService.Infrastructure.Extensions;
using Cat.Localizations.Abstractions;
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

public class CategoryGetListQueryHandler(CatalogDbContext dbContext, ICatTranslator translator)
    : CatEfQueryHandlerBase<CatalogDbContext, CategoryGetListQuery, IList<Category>>(dbContext)
{
    public override async Task<ICatResponse<IList<Category>>> HandleAsync(CategoryGetListQuery query, CancellationToken cancellationToken = default)
    {
        var result = await Set<Category>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        // The name comes in the language of the request, so the order is by the translated name.
        await translator.TranslateNamesAsync(result, cancellationToken);
        result = result.OrderBy(x => x.Name, StringComparer.CurrentCultureIgnoreCase).ToList();

        return CatResponse.Ok<IList<Category>>(result);
    }
}
