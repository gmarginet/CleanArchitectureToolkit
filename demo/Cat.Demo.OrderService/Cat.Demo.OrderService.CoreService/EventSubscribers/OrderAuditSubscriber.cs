using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.EventAggregators.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.OrderService.CoreService.EventSubscribers;

/// <summary>
/// Writes an audit line for every order event. It subscribes to the base type, so it receives all of them.
/// Later the Auditing module takes over this job.
/// </summary>
public class OrderAuditSubscriber : ICatHandleEvent<IOrderEvent>
{
    private readonly ILogger<OrderAuditSubscriber> _logger;

    public OrderAuditSubscriber(ICatEventAggregator eventAggregator, ILogger<OrderAuditSubscriber> logger)
    {
        _logger = logger;
        eventAggregator.Subscribe(this);
    }

    public Task HandleEventAsync(IOrderEvent @event, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Audit: {EventName} for order {OrderNumber} ({OrderId}). {Event}", @event.GetType().Name, @event.OrderNumber, @event.OrderId, @event);
        return Task.CompletedTask;
    }
}
