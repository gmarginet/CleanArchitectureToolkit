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

public class ShippableOrderGetListQueryHandler(OrderDbContext dbContext)
    : CatEfQueryHandlerBase<OrderDbContext, ShippableOrderGetListQuery, IList<Order>>(dbContext)
{
    public override async Task<ICatResponse<IList<Order>>> HandleAsync(ShippableOrderGetListQuery query, CancellationToken cancellationToken = default)
    {
        var orders = await Set<Order>()
            .Where(x => x.OrderStatusId == OrderStatuses.ConfirmedId && x.ConfirmedAt < query.ConfirmedBefore)
            .OrderBy(x => x.ConfirmedAt)
            .ToListAsync(cancellationToken);

        return CatResponse.Ok<IList<Order>>(orders);
    }
}
