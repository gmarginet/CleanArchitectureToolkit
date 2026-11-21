using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Demo.OrderService.CoreService.Messages;
using Cat.EFCore.Commands;
using Cat.Messaging.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

/// <summary>
/// Marks an approved payment as <c>RefundPending</c> and sends the <see cref="RefundPayment"/> message.
/// With the outbox on, the sender stores the message in the same context, so the one <c>SaveChanges</c> saves the status and the message together.
/// </summary>
public class PaymentRefundRequestCommandHandler(OrderDbContext dbContext, ICatMessageSender messageSender)
    : CatEfCommandHandlerBase<OrderDbContext, PaymentRefundRequestCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(PaymentRefundRequestCommand command, CancellationToken cancellationToken = default)
    {
        var payment = await DbContext.Payments.FirstOrDefaultAsync(x => x.OrderId == command.OrderId, cancellationToken);
        if (payment is null || payment.Status != Payment.ApprovedStatus)
        {
            return CatResponse.Ok();
        }

        payment.Status = Payment.RefundPendingStatus;

        await messageSender.SendAsync(new RefundPayment { OrderNumber = command.OrderNumber }, cancellationToken: cancellationToken);

        await DbContext.SaveChangesAsync(cancellationToken);
        return CatResponse.Ok();
    }
}
