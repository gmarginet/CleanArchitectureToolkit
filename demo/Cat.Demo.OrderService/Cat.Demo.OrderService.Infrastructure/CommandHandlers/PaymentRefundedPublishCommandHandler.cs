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
/// Publishes <see cref="PaymentRefunded"/>. With the outbox on, the sender stores the message in the same context,
/// so the one <c>SaveChanges</c> saves the message together with the inbox row of the <see cref="RefundPayment"/> that asked for it.
/// </summary>
public class PaymentRefundedPublishCommandHandler(OrderDbContext dbContext, ICatMessageSender messageSender)
    : CatEfCommandHandlerBase<OrderDbContext, PaymentRefundedPublishCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(PaymentRefundedPublishCommand command, CancellationToken cancellationToken = default)
    {
        await messageSender.PublishAsync(new PaymentRefunded
        {
            CorrelationId = command.CorrelationId,
            OrderNumber = command.OrderNumber,
            Refunded = command.Refunded
        }, cancellationToken: cancellationToken);

        await DbContext.SaveChangesAsync(cancellationToken);
        return CatResponse.Ok();
    }
}
