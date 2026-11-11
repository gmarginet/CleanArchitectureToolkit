using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.InventoryService.CoreService;
using Cat.Demo.InventoryService.CoreService.Commands;
using Cat.Demo.InventoryService.Infrastructure.DataAccess;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.InventoryService.Infrastructure.CommandHandlers;

/// <summary>
/// Sets <c>ConfirmedAt</c> on the reservations of an order that have none yet. A repeated message finds nothing to update and succeeds,
/// so the handler is safe to run twice and needs no inbox. An order number without any reservation fails with <c>NotFound</c>.
/// The column comes from <c>003-reservation-confirmed.sql</c>, so the handler uses SQL and not the scaffolded entity.
/// </summary>
public class StockReservationConfirmCommandHandler : ICatCommandHandler<StockReservationConfirmCommand>
{
    private readonly InventoryDbContext _dbContext;

    public StockReservationConfirmCommandHandler(InventoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICatResponse> HandleAsync(StockReservationConfirmCommand command, CancellationToken cancellationToken = default)
    {
        var updated = await _dbContext.Database.ExecuteSqlAsync(
            $"UPDATE dbo.StockReservation SET ConfirmedAt = SYSUTCDATETIME() WHERE OrderNumber = {command.OrderNumber} AND ConfirmedAt IS NULL",
            cancellationToken);

        if (updated == 0 && !await _dbContext.StockReservations.AnyAsync(x => x.OrderNumber == command.OrderNumber, cancellationToken))
        {
            return CatResponse.NotFound(InventoryErrorDefinitions.UnknownOrder.CreateCatError(command.OrderNumber));
        }

        return CatResponse.Ok();
    }
}
