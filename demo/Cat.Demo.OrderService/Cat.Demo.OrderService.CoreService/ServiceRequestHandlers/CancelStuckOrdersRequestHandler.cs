using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.Demo.OrderService.CoreService.Queries;
using Cat.EventAggregators.Abstractions;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

/// <summary>
/// Cancels the orders that stay Pending longer than <see cref="MaxPendingTime"/>. It covers what the place order handler cannot,
/// such as a crash of the service in the middle of the workflow. A cancel publishes the same event as every other cancel,
/// so the subscribers set the status and release the stock.
/// </summary>
public class CancelStuckOrdersRequestHandler : ICatServiceRequestHandler<CancelStuckOrdersRequest>
{
    /// <summary>The time an order may stay Pending. It is longer than the slowest normal order.</summary>
    public static readonly TimeSpan MaxPendingTime = TimeSpan.FromMinutes(15);

    private readonly ICatQueryProcessor _queryProcessor;
    private readonly ICatEventAggregator _eventAggregator;
    private readonly TimeProvider _timeProvider;

    public CancelStuckOrdersRequestHandler(
        ICatQueryProcessor queryProcessor,
        ICatEventAggregator eventAggregator,
        TimeProvider timeProvider)
    {
        _queryProcessor = queryProcessor;
        _eventAggregator = eventAggregator;
        _timeProvider = timeProvider;
    }

    public async Task<ICatResponse> HandleAsync(CancelStuckOrdersRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var placedBefore = _timeProvider.GetUtcNow().UtcDateTime - MaxPendingTime;

        var response = await _queryProcessor.ProcessAsync(new StuckOrderGetListQuery(placedBefore), cancellationToken);
        if (!response.IsSucceeded)
        {
            return response;
        }

        foreach (var order in response.Value!)
        {
            await _eventAggregator.PublishAsync(new OrderCancelledEvent(order.Id, order.OrderNumber, OrderCancelReasons.PendingTooLong), cancellationToken);
        }

        return CatResponse.NoContent();
    }
}
