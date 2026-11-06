using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.EventAggregators.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.OrderService.CoreService.EventSubscribers;

/// <summary>
/// Gives the reserved stock back when an order is cancelled.
/// Releasing an order that never reserved anything does nothing, so an out of stock cancel is fine too.
/// A cancel because Inventory did not answer skips the release. Inventory is out of reach, so the call would only make the customer wait.
/// </summary>
public class StockReleaseSubscriber : ICatHandleEvent<OrderCancelledEvent>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public StockReleaseSubscriber(ICatEventAggregator eventAggregator, IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        eventAggregator.Subscribe(this);
    }

    public async Task HandleEventAsync(OrderCancelledEvent @event, CancellationToken cancellationToken = default)
    {
        if (@event.Reason == OrderCancelReasons.StockUnavailable)
        {
            return;
        }

        using var scope = _scopeFactory.CreateScope();
        var stockReservation = scope.ServiceProvider.GetRequiredService<IStockReservation>();

        await stockReservation.ReleaseAsync(@event.OrderNumber, cancellationToken);
    }
}
