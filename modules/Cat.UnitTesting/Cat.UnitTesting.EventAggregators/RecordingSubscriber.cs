using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.EventAggregators.Abstractions;

namespace Cat.UnitTesting.EventAggregators;

/// <summary>
/// A subscriber that collects every event it gets. Subscribe it to the aggregator that the test uses.
/// Keep a reference to it while it must receive events, because the aggregator holds a subscriber weakly.
/// </summary>
/// <typeparam name="TEvent">The event type to collect. Use an interface or a base type to collect several event types.</typeparam>
public class RecordingSubscriber<TEvent> : ICatHandleEvent<TEvent>
{
    /// <summary>
    /// Every event that was handled, in order.
    /// </summary>
    public List<TEvent> Events { get; } = new List<TEvent>();

    /// <inheritdoc />
    public Task HandleEventAsync(TEvent @event, CancellationToken cancellationToken = default)
    {
        Events.Add(@event);
        return Task.CompletedTask;
    }
}
