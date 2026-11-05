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
        using var scope = _scopeFactory.CreateScope();
        var stockReservation = scope.ServiceProvider.GetRequiredService<IStockReservation>();

        await stockReservation.ReleaseAsync(@event.OrderNumber, cancellationToken);
    }
}
