using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.EventAggregators.Abstractions;

/// <summary>
/// Publishes events to subscribers that implement <see cref="ICatHandleEvent{TEvent}"/> for the event's type.
/// </summary>
public interface ICatEventAggregator
{
    /// <summary>
    /// Checks whether any live subscriber currently handles the given event type.
    /// </summary>
    /// <param name="eventType">The event type to check for.</param>
    /// <returns><c>true</c> if at least one live subscriber handles the event type, otherwise <c>false</c>.</returns>
    bool HasSubscribersForEvent(Type eventType);

    /// <summary>
    /// Registers a subscriber so it receives events for every <see cref="ICatHandleEvent{TEvent}"/> it implements.
    /// </summary>
    /// <param name="subscriber">The subscriber instance to register. It's held by a weak reference, so it won't be kept alive by the aggregator.</param>
    void Subscribe(object subscriber);

    /// <summary>
    /// Removes a previously registered subscriber so it stops receiving events.
    /// </summary>
    /// <param name="subscriber">The subscriber instance to remove.</param>
    void Unsubscribe(object subscriber);

    /// <summary>
    /// Publishes an event to every live subscriber that handles its type, and waits for all handlers to complete.
    /// </summary>
    /// <param name="event">The event instance to publish.</param>
    /// <param name="cancellationToken">A token to cancel the publish operation.</param>
    Task PublishAsync(object @event, CancellationToken cancellationToken = default);
}