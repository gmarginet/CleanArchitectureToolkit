using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.InventoryService.CoreService;
using Cat.Demo.InventoryService.CoreService.Commands;
using Cat.Demo.InventoryService.Infrastructure.DataAccess;
using Cat.EFCore.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.InventoryService.Infrastructure.CommandHandlers;

/// <summary>
/// Sets <c>ConfirmedAt</c> on the reservations of an order that have none yet. A repeated message finds nothing to update and succeeds,
/// so the handler is safe to run twice and needs no inbox. An order number without any reservation fails with <c>NotFound</c>.
/// The column comes from <c>003-reservation-confirmed.sql</c>. One SQL command updates all reservations of the order with the clock of the database.
/// </summary>
public class StockReservationConfirmCommandHandler(InventoryDbContext dbContext)
    : CatEfCommandHandlerBase<InventoryDbContext, StockReservationConfirmCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(StockReservationConfirmCommand command, CancellationToken cancellationToken = default)
    {
        var updated = await DbContext.Database.ExecuteSqlAsync(
            $"UPDATE dbo.StockReservation SET ConfirmedAt = SYSUTCDATETIME() WHERE OrderNumber = {command.OrderNumber} AND ConfirmedAt IS NULL",
            cancellationToken);

        if (updated == 0 && !await DbContext.StockReservations.AnyAsync(x => x.OrderNumber == command.OrderNumber, cancellationToken))
        {
            return CatResponse.NotFound(InventoryErrorDefinitions.UnknownOrder.CreateCatError(command.OrderNumber));
        }

        return CatResponse.Ok();
    }
}
