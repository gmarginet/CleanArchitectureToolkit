using Cat.EFCore.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;
using ServiceName.CoreService.Commands;
using ServiceName.Infrastructure.DataAccess;

namespace ServiceName.Infrastructure.CommandHandlers;

/// <summary>Handles <see cref="ItemNameCommand"/>. It changes the entities and saves them.</summary>
public class ItemNameCommandHandler(ServiceShortDbContext dbContext)
    : CatEfCommandHandlerBase<ServiceShortDbContext, ItemNameCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(ItemNameCommand command, CancellationToken cancellationToken = default)
    {
        await DbContext.SaveChangesAsync(cancellationToken);

        return CatResponse.Ok();
    }
}
