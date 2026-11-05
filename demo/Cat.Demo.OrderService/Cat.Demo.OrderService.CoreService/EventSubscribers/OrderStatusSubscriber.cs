using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.EventAggregators.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.OrderService.CoreService.EventSubscribers;

/// <summary>
/// Sets the status of an order when it is confirmed or cancelled.
/// The aggregator holds this subscriber for the life of the app, so it opens its own scope for the database work.
/// </summary>
public class OrderStatusSubscriber :
    ICatHandleEvent<OrderConfirmedEvent>,
    ICatHandleEvent<OrderCancelledEvent>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public OrderStatusSubscriber(ICatEventAggregator eventAggregator, IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        eventAggregator.Subscribe(this);
    }

    public Task HandleEventAsync(OrderConfirmedEvent @event, CancellationToken cancellationToken = default)
        => SetStatusAsync(@event.OrderId, OrderStatuses.ConfirmedCode, cancellationToken);

    public Task HandleEventAsync(OrderCancelledEvent @event, CancellationToken cancellationToken = default)
        => SetStatusAsync(@event.OrderId, OrderStatuses.CancelledCode, cancellationToken);

    private async Task SetStatusAsync(Guid orderId, string statusCode, CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var commandProcessor = scope.ServiceProvider.GetRequiredService<ICatCommandProcessor>();

        var response = await commandProcessor.ProcessAsync(new OrderSetStatusCommand(orderId, statusCode), cancellationToken);
        if (!response.IsSucceeded)
        {
            throw new InvalidOperationException($"Setting the status of order {orderId} to {statusCode} failed with a {response.Type} response.");
        }
    }
}
