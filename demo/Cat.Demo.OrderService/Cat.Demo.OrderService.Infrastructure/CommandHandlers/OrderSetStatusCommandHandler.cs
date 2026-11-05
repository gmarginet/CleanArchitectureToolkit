using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

public class OrderSetStatusCommandHandler : ICatCommandHandler<OrderSetStatusCommand>
{
    private readonly OrderDbContext _dbContext;

    public OrderSetStatusCommandHandler(OrderDbContext dbContext)
    {
        _dbContext = dbContext;
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
        await _dbContext.SaveChangesAsync(cancellationToken);
        return CatResponse.Ok();
    }
}
