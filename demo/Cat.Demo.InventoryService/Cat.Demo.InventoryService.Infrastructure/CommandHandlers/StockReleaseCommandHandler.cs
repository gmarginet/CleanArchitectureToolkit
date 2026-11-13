using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.InventoryService.CoreService.Commands;
using Cat.Demo.InventoryService.Infrastructure.DataAccess;
using Cat.EFCore.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.InventoryService.Infrastructure.CommandHandlers;

/// <summary>
/// Gives the stock of an order back and removes its reservation. The reservation rows are locked while they are read,
/// so two releases of the same order at the same moment give the stock back once.
/// </summary>
public class StockReleaseCommandHandler(InventoryDbContext dbContext)
    : CatEfCommandHandlerBase<InventoryDbContext, StockReleaseCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(StockReleaseCommand command, CancellationToken cancellationToken = default)
    {
        await using var transaction = await DbContext.Database.BeginTransactionAsync(cancellationToken);

        var reservations = await DbContext.StockReservations
            .FromSql($"SELECT * FROM dbo.StockReservation WITH (UPDLOCK, HOLDLOCK) WHERE OrderNumber = {command.OrderNumber}")
            .ToListAsync(cancellationToken);

        foreach (var reservation in reservations)
        {
            await DbContext.Database.ExecuteSqlAsync(
                $"UPDATE dbo.StockItem SET QuantityOnHand = QuantityOnHand + {reservation.Quantity} WHERE Id = {reservation.StockItemId}",
                cancellationToken);
        }

        DbContext.StockReservations.RemoveRange(reservations);
        await DbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return CatResponse.Ok();
    }
}
