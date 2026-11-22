using Cat.EventAggregators.Abstractions;
using ServiceName.CoreService.Events;

namespace ServiceName.CoreService.EventSubscribers;

/// <summary>
/// Handles <see cref="ItemNameEvent"/>. It subscribes itself, so register it as a singleton and resolve it once at startup.
/// The aggregator holds a subscriber weakly, so something must keep a reference to it.
/// </summary>
public class ItemNameSubscriber : ICatHandleEvent<ItemNameEvent>
{
    public ItemNameSubscriber(ICatEventAggregator eventAggregator)
    {
        eventAggregator.Subscribe(this);
    }

    public Task HandleEventAsync(ItemNameEvent @event, CancellationToken cancellationToken = default)
    {
        // Do the work for the event here.
        return Task.CompletedTask;
    }
}
