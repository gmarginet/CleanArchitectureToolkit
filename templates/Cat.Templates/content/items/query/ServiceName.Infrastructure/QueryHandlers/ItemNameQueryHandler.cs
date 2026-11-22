using Cat.EFCore.Queries;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;
using RESULT_NAMESPACE;
using ServiceName.CoreService.Queries;
using ServiceName.Infrastructure.DataAccess;

namespace ServiceName.Infrastructure.QueryHandlers;

/// <summary>Handles <see cref="ItemNameQuery"/>. It reads one row by its id. Add an error definition for the missing row.</summary>
public class ItemNameQueryHandler(ServiceShortDbContext dbContext)
    : CatEfQueryHandlerBase<ServiceShortDbContext, ItemNameQuery, ResultEntity>(dbContext)
{
    public override async Task<ICatResponse<ResultEntity>> HandleAsync(ItemNameQuery query, CancellationToken cancellationToken = default)
    {
        var item = await Set<ResultEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

        return item is null
            ? CatResponse.NotFound<ResultEntity>()
            : CatResponse.Ok(item);
    }
}
