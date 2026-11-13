using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.EventAggregators.Abstractions;

namespace Cat.UnitTesting.EventAggregators;

/// <summary>
/// An event aggregator for unit tests of code that publishes events. It records what is published and who subscribes,
/// and it calls no subscriber. To test the subscribers too, use the real aggregator with a <see cref="RecordingSubscriber{TEvent}"/>.
/// </summary>
public class FakeEventAggregator : ICatEventAggregator
{
    /// <summary>
    /// Every event that was published, in order.
    /// </summary>
    public List<object> Published { get; } = new List<object>();

    /// <summary>
    /// Every subscriber that is subscribed now, in the order of the calls.
    /// </summary>
    public List<object> Subscribers { get; } = new List<object>();

    /// <summary>
    /// Gives the published events of one type, in order.
    /// </summary>
    /// <typeparam name="T">The event type.</typeparam>
    /// <returns>The events of this type.</returns>
    public IEnumerable<T> Of<T>() => Published.OfType<T>();

    /// <summary>
    /// Clears the published events and the subscribers.
    /// </summary>
    public void Reset()
    {
        Published.Clear();
        Subscribers.Clear();
    }

    /// <inheritdoc />
    public bool HasSubscribersForEvent(Type eventType)
    {
        var handler = typeof(ICatHandleEvent<>).MakeGenericType(eventType);
        return Subscribers.Any(subscriber => handler.IsInstanceOfType(subscriber));
    }

    /// <inheritdoc />
    public void Subscribe(object subscriber) => Subscribers.Add(subscriber);

    /// <inheritdoc />
    public void Unsubscribe(object subscriber) => Subscribers.Remove(subscriber);

    /// <inheritdoc />
    public Task PublishAsync(object @event, CancellationToken cancellationToken = default)
    {
        Published.Add(@event);
        return Task.CompletedTask;
    }
}
