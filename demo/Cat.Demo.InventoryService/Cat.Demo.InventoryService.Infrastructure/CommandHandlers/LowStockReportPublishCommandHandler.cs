using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.InventoryService.CoreService.Commands;
using Cat.Demo.InventoryService.Infrastructure.DataAccess;
using Cat.EFCore.Commands;
using Cat.Messaging.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.InventoryService.Infrastructure.CommandHandlers;

/// <summary>
/// Reads the stock items below the limit and publishes them as one <see cref="LowStockReport"/>. It reads only, so it needs no outbox.
/// A run that fails after the read publishes nothing, and the scheduler can run the job again.
/// </summary>
public class LowStockReportPublishCommandHandler(InventoryDbContext dbContext, ICatMessageSender messageSender)
    : CatEfCommandHandlerBase<InventoryDbContext, LowStockReportPublishCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(LowStockReportPublishCommand command, CancellationToken cancellationToken = default)
    {
        var lines = await DbContext.StockItems
            .Where(x => x.QuantityOnHand < command.Limit)
            .OrderBy(x => x.QuantityOnHand)
            .ThenBy(x => x.Isbn)
            .Select(x => new LowStockLine { Isbn = x.Isbn, Warehouse = x.Warehouse.Name, QuantityOnHand = x.QuantityOnHand })
            .ToListAsync(cancellationToken);

        if (lines.Count > 0)
        {
            await messageSender.PublishAsync(new LowStockReport { Limit = command.Limit, Lines = lines }, cancellationToken: cancellationToken);
        }

        return CatResponse.Ok();
    }
}
