using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.EFCore.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.OrderService.Infrastructure.CommandHandlers;

public class PaymentRefundedSaveCommandHandler(OrderDbContext dbContext)
    : CatEfCommandHandlerBase<OrderDbContext, PaymentRefundedSaveCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(PaymentRefundedSaveCommand command, CancellationToken cancellationToken = default)
    {
        var order = await DbContext.Orders.Include(x => x.Payment).FirstOrDefaultAsync(x => x.OrderNumber == command.OrderNumber, cancellationToken);
        if (order?.Payment is null)
        {
            return CatResponse.NotFound(
                CatError.Create(
                    CatGeneralErrorDefinitions.ResourceNotFound.Code,
                    CatGeneralErrorDefinitions.ResourceNotFound.Message,
                    "Payment",
                    command.OrderNumber));
        }

        order.Payment.Status = Payment.RefundedStatus;

        await DbContext.SaveChangesAsync(cancellationToken);
        return CatResponse.Ok();
    }
}
