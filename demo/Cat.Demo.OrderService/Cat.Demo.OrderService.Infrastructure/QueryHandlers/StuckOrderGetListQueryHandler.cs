using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Queries;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.EFCore.Queries;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.OrderService.Infrastructure.QueryHandlers;

public class StuckOrderGetListQueryHandler(OrderDbContext dbContext)
    : CatEfQueryHandlerBase<OrderDbContext, StuckOrderGetListQuery, IList<Order>>(dbContext)
{
    public override async Task<ICatResponse<IList<Order>>> HandleAsync(StuckOrderGetListQuery query, CancellationToken cancellationToken = default)
    {
        var orders = await Set<Order>()
            .Where(x => x.OrderStatusId == OrderStatuses.PendingId && x.PlacedAt < query.PlacedBefore)
            .OrderBy(x => x.PlacedAt)
            .ToListAsync(cancellationToken);

        return CatResponse.Ok<IList<Order>>(orders);
    }
}
