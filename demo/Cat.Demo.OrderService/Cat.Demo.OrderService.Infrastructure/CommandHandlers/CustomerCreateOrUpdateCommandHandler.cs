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

public class CustomerCreateOrUpdateCommandHandler(OrderDbContext dbContext)
    : CatEfCommandHandlerBase<OrderDbContext, CustomerCreateOrUpdateCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(CustomerCreateOrUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var customer = await DbContext.Customers
            .FirstOrDefaultAsync(x => x.ExternalId == command.ExternalId, cancellationToken);

        if (customer is null)
        {
            customer = new Customer { ExternalId = command.ExternalId, Name = command.Name, Email = command.Email };
            DbContext.Customers.Add(customer);

            try
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException)
            {
                // Another call of the same user created the customer at the same moment. Use that one.
                DbContext.Entry(customer).State = EntityState.Detached;
                customer = await DbContext.Customers.FirstAsync(x => x.ExternalId == command.ExternalId, cancellationToken);
            }
        }
        else if (customer.Name != command.Name || customer.Email != command.Email)
        {
            customer.Name = command.Name;
            customer.Email = command.Email;
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        command.CustomerId = customer.Id;
        return CatResponse.Ok();
    }
}
