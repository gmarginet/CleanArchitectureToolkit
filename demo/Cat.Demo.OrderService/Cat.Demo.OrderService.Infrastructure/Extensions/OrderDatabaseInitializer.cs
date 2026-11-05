using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.OrderService.Infrastructure.Extensions;

public static class OrderDatabaseInitializer
{
    /// <summary>
    /// Applies the migrations and adds the order statuses that are missing.
    /// Call it in development only.
    /// </summary>
    public static async Task InitializeOrderDatabaseAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();

        await dbContext.Database.MigrateAsync(cancellationToken);

        var existing = await dbContext.OrderStatuses.Select(x => x.Code).ToListAsync(cancellationToken);

        foreach (var code in new[] { OrderStatuses.PendingCode, OrderStatuses.ConfirmedCode, OrderStatuses.CancelledCode })
        {
            if (!existing.Contains(code))
            {
                dbContext.OrderStatuses.Add(new OrderStatus { Id = OrderStatuses.GetId(code), Code = code });
            }
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
