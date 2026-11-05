using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Queries;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.OrderService.Infrastructure.QueryHandlers;

public class OrderGetQueryHandler : ICatQueryHandler<OrderGetQuery, Order>
{
    private readonly OrderDbContext _dbContext;

    public OrderGetQueryHandler(OrderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICatResponse<Order>> HandleAsync(OrderGetQuery query, CancellationToken cancellationToken = default)
    {
        var order = await _dbContext.Orders
            .AsNoTracking()
            .Include(x => x.OrderStatus)
            .Include(x => x.Lines)
            .Where(x => x.Id == query.OrderId)
            .Where(x => query.CustomerExternalId == null || x.Customer!.ExternalId == query.CustomerExternalId)
            .FirstOrDefaultAsync(cancellationToken);

        return order is null
            ? CatResponse.NotFound<Order>(
                CatError.Create(
                    CatGeneralErrorDefinitions.ResourceNotFound.Code,
                    CatGeneralErrorDefinitions.ResourceNotFound.Message,
                    "Order",
                    query.OrderId))
            : CatResponse.Ok(order);
    }
}
