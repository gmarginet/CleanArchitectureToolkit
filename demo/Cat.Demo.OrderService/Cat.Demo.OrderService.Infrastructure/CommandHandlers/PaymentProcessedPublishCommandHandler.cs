using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Messages;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.EFCore.Commands;
using Cat.Messaging.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

/// <summary>
/// Publishes <see cref="PaymentProcessed"/>. With the outbox on, the sender stores the message in the same context,
/// so the one <c>SaveChanges</c> saves the message together with the inbox row of the <see cref="TakePayment"/> that asked for it.
/// </summary>
public class PaymentProcessedPublishCommandHandler(OrderDbContext dbContext, ICatMessageSender messageSender)
    : CatEfCommandHandlerBase<OrderDbContext, PaymentProcessedPublishCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(PaymentProcessedPublishCommand command, CancellationToken cancellationToken = default)
    {
        await messageSender.PublishAsync(new PaymentProcessed
        {
            CorrelationId = command.CorrelationId,
            OrderNumber = command.OrderNumber,
            Approved = command.Approved,
            Reference = command.Reference
        }, cancellationToken: cancellationToken);

        await DbContext.SaveChangesAsync(cancellationToken);
        return CatResponse.Ok();
    }
}
