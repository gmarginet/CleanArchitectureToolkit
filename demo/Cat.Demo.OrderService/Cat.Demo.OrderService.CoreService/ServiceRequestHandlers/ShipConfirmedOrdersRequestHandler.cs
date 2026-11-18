using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Queries;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

/// <summary>
/// Ships the orders that have been Confirmed for at least <see cref="ShipAfter"/>. Once an order is shipped, the customer can no longer cancel it.
/// </summary>
public class ShipConfirmedOrdersRequestHandler : ICatServiceRequestHandler<ShipConfirmedOrdersRequest>
{
    /// <summary>The time an order stays Confirmed before it is shipped.</summary>
    public static readonly TimeSpan ShipAfter = TimeSpan.FromMinutes(5);

    private readonly ICatQueryProcessor _queryProcessor;
    private readonly ICatCommandProcessor _commandProcessor;
    private readonly TimeProvider _timeProvider;

    public ShipConfirmedOrdersRequestHandler(
        ICatQueryProcessor queryProcessor,
        ICatCommandProcessor commandProcessor,
        TimeProvider timeProvider)
    {
        _queryProcessor = queryProcessor;
        _commandProcessor = commandProcessor;
        _timeProvider = timeProvider;
    }

    public async Task<ICatResponse> HandleAsync(ShipConfirmedOrdersRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var confirmedBefore = _timeProvider.GetUtcNow().UtcDateTime - ShipAfter;

        var response = await _queryProcessor.ProcessAsync(new ShippableOrderGetListQuery(confirmedBefore), cancellationToken);
        if (!response.IsSucceeded)
        {
            return response;
        }

        foreach (var order in response.Value!)
        {
            var setStatus = await _commandProcessor.ProcessAsync(new OrderSetStatusCommand(order.Id, OrderStatuses.ShippedCode), cancellationToken);
            if (!setStatus.IsSucceeded)
            {
                return setStatus;
            }
        }

        return CatResponse.NoContent();
    }
}
