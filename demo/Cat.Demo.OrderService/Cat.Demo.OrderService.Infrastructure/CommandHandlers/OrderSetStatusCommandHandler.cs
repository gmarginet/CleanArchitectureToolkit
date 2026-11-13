using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.Contracts.Messages;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Messaging.Abstractions;
using Cat.EFCore.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

/// <summary>
/// Sets the status of an order. When the order becomes confirmed, it also publishes the <see cref="OrderConfirmed"/> message.
/// With the outbox on, the sender stores the message in the same context, so the one <c>SaveChanges</c> saves the status and the message together.
/// </summary>
public class OrderSetStatusCommandHandler(OrderDbContext dbContext, ICatMessageSender messageSender)
    : CatEfCommandHandlerBase<OrderDbContext, OrderSetStatusCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(OrderSetStatusCommand command, CancellationToken cancellationToken = default)
    {
        var order = await DbContext.Orders.FirstOrDefaultAsync(x => x.Id == command.OrderId, cancellationToken);
        if (order is null)
        {
            return CatResponse.NotFound(
                CatError.Create(
                    CatGeneralErrorDefinitions.ResourceNotFound.Code,
                    CatGeneralErrorDefinitions.ResourceNotFound.Message,
                    "Order",
                    command.OrderId));
        }

        order.OrderStatusId = OrderStatuses.GetId(command.StatusCode);

        if (command.StatusCode == OrderStatuses.ConfirmedCode)
        {
            await messageSender.PublishAsync(
                new OrderConfirmed { OrderId = order.Id, OrderNumber = order.OrderNumber, Total = order.Total },
                cancellationToken: cancellationToken);
        }

        await DbContext.SaveChangesAsync(cancellationToken);
        return CatResponse.Ok();
    }
}
