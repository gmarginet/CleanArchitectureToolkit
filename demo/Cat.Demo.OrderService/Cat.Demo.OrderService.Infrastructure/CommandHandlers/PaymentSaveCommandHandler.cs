using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

public class PaymentSaveCommandHandler : ICatCommandHandler<PaymentSaveCommand>
{
    private readonly OrderDbContext _dbContext;
    private readonly TimeProvider _timeProvider;

    public PaymentSaveCommandHandler(OrderDbContext dbContext, TimeProvider timeProvider)
    {
        _dbContext = dbContext;
        _timeProvider = timeProvider;
    }

    public async Task<ICatResponse> HandleAsync(PaymentSaveCommand command, CancellationToken cancellationToken = default)
    {
        _dbContext.Payments.Add(new Payment
        {
            OrderId = command.OrderId,
            Amount = command.Amount,
            Status = command.Approved ? Payment.ApprovedStatus : Payment.DeclinedStatus,
            PaidAt = command.Approved ? _timeProvider.GetUtcNow().UtcDateTime : null
        });

        await _dbContext.SaveChangesAsync(cancellationToken);
        return CatResponse.Ok();
    }
}
