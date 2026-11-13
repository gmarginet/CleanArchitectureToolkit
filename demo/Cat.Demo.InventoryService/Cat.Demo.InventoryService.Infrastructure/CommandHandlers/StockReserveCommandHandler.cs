using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Db.Errors.SqlServer;
using Cat.Demo.InventoryService.CoreService;
using Cat.Demo.InventoryService.CoreService.Commands;
using Cat.Demo.InventoryService.Infrastructure.DataAccess;
using Cat.Demo.InventoryService.Infrastructure.Entities;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.InventoryService.Infrastructure.CommandHandlers;

/// <summary>
/// Reserves the stock of an order. Every line is one conditional update, so the stock cannot go below zero,
/// even when two orders ask for the last copies at the same moment. The lines share one transaction:
/// when one book is out of stock, nothing is reserved. The order number is the idempotency key.
/// </summary>
public class StockReserveCommandHandler : ICatCommandHandler<StockReserveCommand>
{
    // The update takes the first stock item of the book that has enough copies, and tells us which one it was.
    private const string TakeStockSql = """
        WITH candidate AS
        (
            SELECT TOP (1) Id, QuantityOnHand
            FROM dbo.StockItem
            WHERE Isbn = @isbn AND QuantityOnHand >= @quantity
            ORDER BY Id
        )
        UPDATE candidate
        SET QuantityOnHand = QuantityOnHand - @quantity, @stockItemId = Id
        """;

    private readonly InventoryDbContext _dbContext;

    public StockReserveCommandHandler(InventoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICatResponse> HandleAsync(StockReserveCommand command, CancellationToken cancellationToken = default)
    {
        if (await _dbContext.StockReservations.AnyAsync(x => x.OrderNumber == command.OrderNumber, cancellationToken))
        {
            return CatResponse.Ok();
        }

        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            // The same order of books in every transaction keeps two orders from waiting on each other.
            foreach (var line in command.Lines.OrderBy(x => x.Isbn, System.StringComparer.Ordinal))
            {
                var stockItemId = await TakeStockAsync(line, cancellationToken);
                if (stockItemId is null)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return await NoStockAsync(line, command.OrderNumber, cancellationToken);
                }

                _dbContext.StockReservations.Add(new StockReservation
                {
                    StockItemId = stockItemId.Value,
                    OrderNumber = command.OrderNumber,
                    Quantity = line.Quantity
                });
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return CatResponse.Ok();
        }
        catch (DbUpdateException ex) when (ex.IsUniqueViolation())
        {
            // The same order was reserved twice at the same moment. The unique key stopped the second one,
            // and its transaction rolls back, so the first reservation stands.
            return CatResponse.Ok();
        }
    }

    private async Task<int?> TakeStockAsync(StockLine line, CancellationToken cancellationToken)
    {
        var stockItemId = new SqlParameter("@stockItemId", SqlDbType.Int) { Direction = ParameterDirection.Output };

        await _dbContext.Database.ExecuteSqlRawAsync(
            TakeStockSql,
            [new SqlParameter("@isbn", line.Isbn), new SqlParameter("@quantity", line.Quantity), stockItemId],
            cancellationToken);

        return stockItemId.Value is int id ? id : null;
    }

    private async Task<ICatResponse> NoStockAsync(StockLine line, string orderNumber, CancellationToken cancellationToken)
    {
        var known = await _dbContext.StockItems.AnyAsync(x => x.Isbn == line.Isbn, cancellationToken);

        return known
            ? CatResponse.Conflict(InventoryErrorDefinitions.OutOfStock.CreateCatError(line.Isbn, orderNumber))
            : CatResponse.NotFound(InventoryErrorDefinitions.UnknownBook.CreateCatError(line.Isbn, orderNumber));
    }
}
