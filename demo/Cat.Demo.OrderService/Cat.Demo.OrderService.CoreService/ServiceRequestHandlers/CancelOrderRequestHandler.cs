using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.Demo.OrderService.CoreService.Extensions;
using Cat.Demo.OrderService.CoreService.Queries;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.EventAggregators.Abstractions;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.Users.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

public class CancelOrderRequestHandler : ICatServiceRequestHandler<CancelOrderRequest>
{
    private readonly ICatQueryProcessor _queryProcessor;
    private readonly ICatEventAggregator _eventAggregator;
    private readonly ICatUser _currentUser;

    public CancelOrderRequestHandler(
        ICatQueryProcessor queryProcessor,
        ICatEventAggregator eventAggregator,
        ICatUser currentUser)
    {
        _queryProcessor = queryProcessor;
        _eventAggregator = eventAggregator;
        _currentUser = currentUser;
    }

    public async Task<ICatResponse> HandleAsync(CancelOrderRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        if (!_currentUser.IsAuthenticated)
        {
            return CatResponse.Unauthorized(OrderErrorDefinitions.NotAuthenticated.CreateCatError());
        }

        // The owner filter makes the orders of other customers come back as not found.
        var response = await _queryProcessor.ProcessAsync(new OrderGetQuery(serviceRequest.OrderId, _currentUser.GetOwnerFilter()), cancellationToken);
        if (!response.IsSucceeded)
        {
            return response;
        }

        var order = response.Value!;
        var statusCode = order.OrderStatus!.Code;

        if (statusCode == OrderStatuses.CancelledCode)
        {
            return CatResponse.Conflict(OrderErrorDefinitions.CannotCancel.CreateCatError(order.OrderNumber, statusCode));
        }

        // The subscribers set the status and release the stock.
        await _eventAggregator.PublishAsync(new OrderCancelledEvent(order.Id, order.OrderNumber, OrderCancelReasons.CancelledByUser), cancellationToken);

        return CatResponse.NoContent();
    }
}
