using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.EFCore.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

public class PaymentSaveCommandHandler(OrderDbContext dbContext, TimeProvider timeProvider)
    : CatEfCommandHandlerBase<OrderDbContext, PaymentSaveCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(PaymentSaveCommand command, CancellationToken cancellationToken = default)
    {
        DbContext.Payments.Add(new Payment
        {
            OrderId = command.OrderId,
            Amount = command.Amount,
            Status = command.Approved ? Payment.ApprovedStatus : Payment.DeclinedStatus,
            PaidAt = command.Approved ? timeProvider.GetUtcNow().UtcDateTime : null
        });

        await DbContext.SaveChangesAsync(cancellationToken);
        return CatResponse.Ok();
    }
}
