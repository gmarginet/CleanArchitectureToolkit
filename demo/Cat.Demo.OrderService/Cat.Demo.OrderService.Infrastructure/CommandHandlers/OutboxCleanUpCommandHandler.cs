using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.EFCore.Commands;
using Cat.Outbox.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

/// <summary>
/// Deletes the outbox rows that were sent before the time limit. The store deletes at once, so the handler
/// does not save. Running it again changes nothing.
/// </summary>
public class OutboxCleanUpCommandHandler(OrderDbContext dbContext, ICatOutboxStore outboxStore)
    : CatEfCommandHandlerBase<OrderDbContext, OutboxCleanUpCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(OutboxCleanUpCommand command, CancellationToken cancellationToken = default)
    {
        await outboxStore.DeleteOlderThanAsync(command.SentBefore, cancellationToken);

        return CatResponse.Ok();
    }
}
