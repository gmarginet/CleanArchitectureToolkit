using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

/// <summary>
/// Deletes the counters of earlier days and creates the counter of today.
/// Running it again changes nothing. If an order creates today's row at the same moment, that row stays.
/// </summary>
public class OrderCountersCleanUpCommandHandler : ICatCommandHandler<OrderCountersCleanUpCommand>
{
    private readonly OrderDbContext _dbContext;
    private readonly TimeProvider _timeProvider;

    public OrderCountersCleanUpCommandHandler(OrderDbContext dbContext, TimeProvider timeProvider)
    {
        _dbContext = dbContext;
        _timeProvider = timeProvider;
    }

    public async Task<ICatResponse> HandleAsync(OrderCountersCleanUpCommand command, CancellationToken cancellationToken = default)
    {
        var today = DateOnly.FromDateTime(_timeProvider.GetUtcNow().UtcDateTime);

        await _dbContext.DailyOrderCounters
            .Where(x => x.Date < today)
            .ExecuteDeleteAsync(cancellationToken);

        if (!await _dbContext.DailyOrderCounters.AnyAsync(x => x.Date == today, cancellationToken))
        {
            var counter = new DailyOrderCounter { Date = today, LastNumber = 0 };
            _dbContext.DailyOrderCounters.Add(counter);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException)
            {
                // An order created the row of today at the same moment. That row is what we want.
                _dbContext.Entry(counter).State = EntityState.Detached;
            }
        }

        return CatResponse.Ok();
    }
}
