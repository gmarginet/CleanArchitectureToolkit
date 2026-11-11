using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.Contracts.Messages;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Messaging.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

/// <summary>
/// Sets the status of an order. When the order becomes confirmed, it also publishes the <see cref="OrderConfirmed"/> message.
/// With the outbox on, the sender stores the message in the same context, so the one <c>SaveChanges</c> saves the status and the message together.
/// </summary>
public class OrderSetStatusCommandHandler : ICatCommandHandler<OrderSetStatusCommand>
{
    private readonly OrderDbContext _dbContext;
    private readonly ICatMessageSender _messageSender;

    public OrderSetStatusCommandHandler(OrderDbContext dbContext, ICatMessageSender messageSender)
    {
        _dbContext = dbContext;
        _messageSender = messageSender;
    }

    public async Task<ICatResponse> HandleAsync(OrderSetStatusCommand command, CancellationToken cancellationToken = default)
    {
        var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == command.OrderId, cancellationToken);
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
            await _messageSender.PublishAsync(
                new OrderConfirmed { OrderId = order.Id, OrderNumber = order.OrderNumber, Total = order.Total },
                cancellationToken: cancellationToken);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
        return CatResponse.Ok();
    }
}
