using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Db.Errors.SqlServer;
using Cat.Demo.OrderService.CoreService;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.EFCore.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

/// <summary>
/// Creates an order. In one transaction it takes the next order counter of the UTC day and saves the order.
/// The counter row is increased and read back in one SQL statement, so two orders at the same moment never get the same number.
/// If saving the order fails, the transaction rolls back and the counter goes back with it.
/// </summary>
public class OrderCreateCommandHandler(OrderDbContext dbContext)
    : CatEfCommandHandlerBase<OrderDbContext, OrderCreateCommand, OrderCreated>(dbContext)
{
    /// <summary>The order number has four digits for the counter.</summary>
    public const int DailyLimit = 9999;

    private const int MaximumAttempts = 3;

    public override async Task<ICatResponse<OrderCreated>> HandleAsync(OrderCreateCommand command, CancellationToken cancellationToken = default)
    {
        var today = DateOnly.FromDateTime(command.PlacedAt);

        await using var transaction = await DbContext.Database.BeginTransactionAsync(cancellationToken);

        var counter = await TakeNextCounterAsync(today, cancellationToken);
        if (counter > DailyLimit)
        {
            // Leaving the method without a commit rolls the counter back.
            return CatResponse.BadRequest<OrderCreated>(OrderErrorDefinitions.DailyLimitReached.CreateCatError(DailyLimit));
        }

        var order = new Order
        {
            Id = command.OrderId,
            OrderNumber = $"{today:yyyyMMdd}-{counter:0000}",
            CustomerId = command.CustomerId,
            OrderStatusId = OrderStatuses.PendingId,
            PlacedAt = command.PlacedAt,
            Total = command.Total,
            Lines =
            [
                .. command.Lines.Select(x => new OrderLine { BookId = x.BookId, Quantity = x.Quantity, UnitPrice = x.UnitPrice })
            ]
        };

        DbContext.Orders.Add(order);
        await DbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return CatResponse.Ok(new OrderCreated(order.Id, order.OrderNumber));
    }

    private async Task<int> TakeNextCounterAsync(DateOnly today, CancellationToken cancellationToken)
    {
        for (var attempt = 0; attempt < MaximumAttempts; attempt++)
        {
            // The UPDATE locks the row until the transaction ends. A second order waits here and then reads the next value.
            var updated = await IncrementAsync(today, cancellationToken);
            if (updated is { } counter)
            {
                return counter;
            }

            // The first order of the day. If another order inserts the row at the same moment, the unique key stops one
            // of them. That one goes around again and increases the row.
            try
            {
                await DbContext.Database.ExecuteSqlAsync(
                    $"INSERT INTO dbo.DailyOrderCounter (Id, [Date], LastNumber) VALUES ({Guid.NewGuid()}, {today}, 1)",
                    cancellationToken);
                return 1;
            }
            catch (Exception ex) when (ex.IsUniqueViolation())
            {
            }
        }

        throw new InvalidOperationException("Could not take an order counter after several attempts.");
    }

    private async Task<int?> IncrementAsync(DateOnly today, CancellationToken cancellationToken)
    {
        var connection = DbContext.Database.GetDbConnection();
        await using var dbCommand = connection.CreateCommand();
        dbCommand.Transaction = DbContext.Database.CurrentTransaction!.GetDbTransaction();
        dbCommand.CommandText =
            "UPDATE dbo.DailyOrderCounter SET LastNumber = LastNumber + 1 OUTPUT INSERTED.LastNumber WHERE [Date] = @date";

        var parameter = dbCommand.CreateParameter();
        parameter.ParameterName = "@date";
        parameter.DbType = DbType.Date;
        parameter.Value = today.ToDateTime(TimeOnly.MinValue);
        dbCommand.Parameters.Add(parameter);

        var result = await dbCommand.ExecuteScalarAsync(cancellationToken);
        return result is null or DBNull ? null : Convert.ToInt32(result);
    }
}
