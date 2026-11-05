using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

/// <summary>
/// Creates an order. In one transaction it takes the next order counter of the UTC day and saves the order.
/// The counter row is increased and read back in one SQL statement, so two orders at the same moment never get the same number.
/// If saving the order fails, the transaction rolls back and the counter goes back with it.
/// </summary>
public class OrderCreateCommandHandler : ICatCommandHandler<OrderCreateCommand>
{
    /// <summary>The order number has four digits for the counter.</summary>
    public const int DailyLimit = 9999;

    private const int UniqueKeyViolation = 2627;
    private const int UniqueIndexViolation = 2601;
    private const int MaximumAttempts = 3;

    private readonly OrderDbContext _dbContext;
    private readonly TimeProvider _timeProvider;

    public OrderCreateCommandHandler(OrderDbContext dbContext, TimeProvider timeProvider)
    {
        _dbContext = dbContext;
        _timeProvider = timeProvider;
    }

    public async Task<ICatResponse> HandleAsync(OrderCreateCommand command, CancellationToken cancellationToken = default)
    {
        var now = _timeProvider.GetUtcNow().UtcDateTime;
        var today = DateOnly.FromDateTime(now);

        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        var counter = await TakeNextCounterAsync(today, cancellationToken);
        if (counter > DailyLimit)
        {
            // Leaving the method without a commit rolls the counter back.
            return CatResponse.BadRequest(OrderErrorDefinitions.DailyLimitReached.CreateCatError(DailyLimit));
        }

        var order = new Order
        {
            OrderNumber = $"{today:yyyyMMdd}-{counter:0000}",
            CustomerId = command.CustomerId,
            OrderStatusId = OrderStatuses.PendingId,
            PlacedAt = now,
            Total = command.Total,
            Lines =
            [
                .. command.Lines.Select(x => new OrderLine { BookId = x.BookId, Quantity = x.Quantity, UnitPrice = x.UnitPrice })
            ]
        };

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        command.OrderId = order.Id;
        command.OrderNumber = order.OrderNumber;
        command.PlacedAt = order.PlacedAt;
        return CatResponse.Ok();
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
                await _dbContext.Database.ExecuteSqlAsync(
                    $"INSERT INTO dbo.DailyOrderCounter (Id, [Date], LastNumber) VALUES ({Guid.NewGuid()}, {today}, 1)",
                    cancellationToken);
                return 1;
            }
            catch (SqlException ex) when (ex.Number is UniqueKeyViolation or UniqueIndexViolation)
            {
            }
        }

        throw new InvalidOperationException("Could not take an order counter after several attempts.");
    }

    private async Task<int?> IncrementAsync(DateOnly today, CancellationToken cancellationToken)
    {
        var connection = _dbContext.Database.GetDbConnection();
        await using var dbCommand = connection.CreateCommand();
        dbCommand.Transaction = _dbContext.Database.CurrentTransaction!.GetDbTransaction();
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
