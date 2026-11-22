using Cat.EFCore.Queries;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;
using ServiceName.CoreService;
using ServiceName.CoreService.Queries;
using ServiceName.DataModels.Entities;
using ServiceName.Infrastructure.DataAccess;

namespace ServiceName.Infrastructure.QueryHandlers;

public class ExampleGetQueryHandler(ServiceShortDbContext dbContext)
    : CatEfQueryHandlerBase<ServiceShortDbContext, ExampleGetQuery, ExampleItem>(dbContext)
{
    public override async Task<ICatResponse<ExampleItem>> HandleAsync(ExampleGetQuery query, CancellationToken cancellationToken = default)
    {
        var item = await Set<ExampleItem>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == query.ExampleId, cancellationToken);

        return item is null
            ? CatResponse.NotFound<ExampleItem>(CatError.Create(
                ServiceShortErrorDefinitions.ExampleNotFound.Code,
                ServiceShortErrorDefinitions.ExampleNotFound.Message,
                "ExampleId",
                query.ExampleId))
            : CatResponse.Ok(item);
    }
}
