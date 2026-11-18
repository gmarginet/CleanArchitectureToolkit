using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.EventAggregators.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.OrderService.CoreService.EventSubscribers;

/// <summary>
/// Asks Payment for a refund when an order is cancelled. The command only acts on an approved payment,
/// so an order that was cancelled before it was paid, or after a decline, gets no refund.
/// The cancel does not wait for the answer. The payment shows <c>RefundPending</c> until Payment answers.
/// </summary>
public class PaymentRefundSubscriber : ICatHandleEvent<OrderCancelledEvent>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public PaymentRefundSubscriber(ICatEventAggregator eventAggregator, IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        eventAggregator.Subscribe(this);
    }

    public async Task HandleEventAsync(OrderCancelledEvent @event, CancellationToken cancellationToken = default)
    {
        using var scope = _scopeFactory.CreateScope();
        var commandProcessor = scope.ServiceProvider.GetRequiredService<ICatCommandProcessor>();

        var response = await commandProcessor.ProcessAsync(new PaymentRefundRequestCommand(@event.OrderId, @event.OrderNumber), cancellationToken);
        if (!response.IsSucceeded)
        {
            throw new InvalidOperationException($"Asking for the refund of order {@event.OrderNumber} failed with a {response.Type} response.");
        }
    }
}
