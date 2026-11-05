using System.Collections.Generic;
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

public class OrderGetListQueryHandler : ICatQueryHandler<OrderGetListQuery, IList<Order>>
{
    private readonly OrderDbContext _dbContext;

    public OrderGetListQueryHandler(OrderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICatResponse<IList<Order>>> HandleAsync(OrderGetListQuery query, CancellationToken cancellationToken = default)
    {
        var orders = await _dbContext.Orders
            .AsNoTracking()
            .Include(x => x.OrderStatus)
            .Where(x => query.CustomerExternalId == null || x.Customer!.ExternalId == query.CustomerExternalId)
            .OrderByDescending(x => x.PlacedAt)
            .ToListAsync(cancellationToken);

        return CatResponse.Ok<IList<Order>>(orders);
    }
}
