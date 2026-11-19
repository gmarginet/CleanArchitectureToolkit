using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.EFCore.Commands;
using Cat.EventProcessor.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

/// <summary>
/// Deletes the inbox rows that were handled before the time limit. The store deletes at once, so the handler
/// does not save. Running it again changes nothing.
/// </summary>
public class InboxCleanUpCommandHandler(OrderDbContext dbContext, ICatInboxStore inboxStore)
    : CatEfCommandHandlerBase<OrderDbContext, InboxCleanUpCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(InboxCleanUpCommand command, CancellationToken cancellationToken = default)
    {
        await inboxStore.DeleteOlderThanAsync(command.HandledBefore, cancellationToken);

        return CatResponse.Ok();
    }
}
