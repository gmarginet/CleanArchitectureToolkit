using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Cat.EventAggregators.Abstractions;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;

namespace Cat.EventAggregators;

/// <summary>
/// Default in-memory implementation of <see cref="ICatEventAggregator"/>. Tracks subscribers through weak
/// references, so a subscriber doesn't need to unsubscribe to be garbage collected.
/// </summary>
internal class CatEventAggregator : ICatEventAggregator
{
    private readonly List<Subscription> _subscriptions = [];

    /// <inheritdoc />
    public bool HasSubscribersForEvent(Type eventType)
    {
        var eventTypInfo = eventType.GetTypeInfo();
        lock (_subscriptions)
        {
            return _subscriptions.Any(x => x.Handles(eventTypInfo) && x.IsDead is false);
        }
    }

    /// <inheritdoc />
    public void Subscribe(object subscriber)
    {
        subscriber.ThrowIfNull(nameof(subscriber));

        lock (_subscriptions)
        {
            //Check if the subscriber is already subscribed
            if (_subscriptions.Any(x => x.Matches(subscriber))) return;

            var subscription = new Subscription(subscriber);
            if (subscription.HasEventHandlers is false) return;

            _subscriptions.Add(subscription);
        }
    }

    /// <inheritdoc />
    public void Unsubscribe(object subscriber)
    {
        subscriber.ThrowIfNull(nameof(subscriber));

        lock (_subscriptions)
        {
            var subscription = _subscriptions.SingleOrDefault(x => x.Matches(subscriber));
            if (subscription is null) return;

            _subscriptions.Remove(subscription);
        }
    }

    /// <inheritdoc />
    public async Task PublishAsync(object @event, CancellationToken cancellationToken = default)
    {
        @event.ThrowIfNull(nameof(@event));
        
        var eventType = @event.GetType();
        
        Subscription[] subscriptions;
        lock (_subscriptions)
        {
            subscriptions = _subscriptions
                .Where(x => x.Handles(eventType) && x.IsDead is false)
                .ToArray();
        }
        
        var handleEventTasks = subscriptions
            .SelectMany(x => x.HandleEvent(@event, cancellationToken))
            .ToList();
        if (handleEventTasks.Count == 0) return;
        
        await Task.WhenAll(handleEventTasks);

        lock (_subscriptions)
        {
            _subscriptions.RemoveAll(x => x.IsDead);
        }
    }

    /// <summary>
    /// Tracks one subscriber's live reference and the <see cref="ICatHandleEvent{TEvent}"/> handler methods it implements.
    /// </summary>
    private class Subscription
    {
        private readonly WeakReference _subscriberReference;
        private readonly Dictionary<TypeInfo, MethodInfo> _eventHandlers = [];

        /// <summary>
        /// Inspects the subscriber's implemented interfaces and caches its <see cref="ICatHandleEvent{TEvent}"/> handler methods, keyed by event type.
        /// </summary>
        /// <param name="subscriber">The subscriber instance to track. It's held by a weak reference.</param>
        public Subscription(object subscriber)
        {
            _subscriberReference = new WeakReference(subscriber);
            
            var interfaces = subscriber
                .GetType()
                .GetTypeInfo()
                .ImplementedInterfaces
                .Where(x => x.GetTypeInfo().IsGenericType && x.GetGenericTypeDefinition() == typeof(ICatHandleEvent<>));

            foreach (var @interface in interfaces)
            {
                var eventType = @interface.GetTypeInfo().GenericTypeArguments[0];
                if (eventType is null) continue;
                
                var handleMethod = @interface.GetRuntimeMethod("HandleEventAsync", [eventType, typeof(CancellationToken)]);
                if (handleMethod is null) continue;
                
                var eventTypeInfo = eventType.GetTypeInfo();
                if (eventTypeInfo is null) continue;
                
                _eventHandlers.Add(eventTypeInfo, handleMethod);
            }
        }
        
        /// <summary>
        /// <c>true</c> if the subscriber has been garbage collected.
        /// </summary>
        public bool IsDead => _subscriberReference.Target is null;

        /// <summary>
        /// <c>true</c> if the subscriber implements at least one <see cref="ICatHandleEvent{TEvent}"/> handler.
        /// </summary>
        public bool HasEventHandlers => _eventHandlers.Count > 0;

        /// <summary>
        /// Checks whether this subscription tracks the given subscriber instance.
        /// </summary>
        /// <param name="instance">The instance to compare by reference.</param>
        /// <returns><c>true</c> if <paramref name="instance"/> is the tracked subscriber.</returns>
        public bool Matches(object instance)
        {
            return object.ReferenceEquals(_subscriberReference.Target, instance);
        }

        /// <summary>
        /// Checks whether the subscriber handles the given event type.
        /// </summary>
        /// <param name="eventType">The event type to check for.</param>
        /// <returns><c>true</c> if the subscriber has a handler assignable from <paramref name="eventType"/>.</returns>
        public bool Handles(Type eventType)
        {
            var eventTypeInfo = eventType.GetTypeInfo();
            if (eventTypeInfo is null) return false;

            return _eventHandlers.Any(x => x.Key.IsAssignableFrom(eventTypeInfo));
        }

        /// <summary>
        /// Invokes every handler the subscriber has for the event's type.
        /// </summary>
        /// <param name="event">The event instance to dispatch.</param>
        /// <param name="cancellationToken">A token to cancel the handling operation.</param>
        /// <returns>The tasks returned by each matching handler, or an empty list if the subscriber is dead or has no matching handler.</returns>
        public IList<Task> HandleEvent(object @event, CancellationToken cancellationToken)
        {
            var eventTypeInfo = @event.GetType().GetTypeInfo();
            if (eventTypeInfo is null) return [];
            
            var subscriber = _subscriberReference.Target;
            if (subscriber is null) return [];
            
            return _eventHandlers
                .Where(h => h.Key.IsAssignableFrom(eventTypeInfo))
                .Select(x => InvokeHandler(x.Value, subscriber, @event, cancellationToken))
                .ToList();
        }

        /// <summary>
        /// Calls one handler. When the handler throws before it returns a task, the exception comes back as a failed task.
        /// That way the other handlers still run, and the caller gets the original exception, not a <see cref="TargetInvocationException"/>.
        /// </summary>
        /// <param name="method">The handler method.</param>
        /// <param name="subscriber">The subscriber that owns the method.</param>
        /// <param name="event">The event instance to dispatch.</param>
        /// <param name="cancellationToken">A token to cancel the handling operation.</param>
        /// <returns>The task of the handler.</returns>
        private static Task InvokeHandler(MethodInfo method, object subscriber, object @event, CancellationToken cancellationToken)
        {
            try
            {
                return (Task)method.Invoke(subscriber, [@event, cancellationToken])!;
            }
            catch (TargetInvocationException exception) when (exception.InnerException is not null)
            {
                return Task.FromException(exception.InnerException);
            }
        }
    }
}