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

public class CustomerCreateOrUpdateCommandHandler : ICatCommandHandler<CustomerCreateOrUpdateCommand>
{
    private readonly OrderDbContext _dbContext;

    public CustomerCreateOrUpdateCommandHandler(OrderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICatResponse> HandleAsync(CustomerCreateOrUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var customer = await _dbContext.Customers
            .FirstOrDefaultAsync(x => x.ExternalId == command.ExternalId, cancellationToken);

        if (customer is null)
        {
            customer = new Customer { ExternalId = command.ExternalId, Name = command.Name, Email = command.Email };
            _dbContext.Customers.Add(customer);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException)
            {
                // Another call of the same user created the customer at the same moment. Use that one.
                _dbContext.Entry(customer).State = EntityState.Detached;
                customer = await _dbContext.Customers.FirstAsync(x => x.ExternalId == command.ExternalId, cancellationToken);
            }
        }
        else if (customer.Name != command.Name || customer.Email != command.Email)
        {
            customer.Name = command.Name;
            customer.Email = command.Email;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        command.CustomerId = customer.Id;
        return CatResponse.Ok();
    }
}
