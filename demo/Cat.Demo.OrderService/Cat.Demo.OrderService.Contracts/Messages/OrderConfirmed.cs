using System;
using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.Contracts.Messages;

/// <summary>
/// Tells the other services that an order is confirmed: the stock is reserved and the payment is taken.
/// Orders publishes it through the outbox. A service that receives it writes a handler for it, as for any service request.
/// </summary>
public class OrderConfirmed : CatEventMessage, ICatServiceRequest
{
    public Guid OrderId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public decimal Total { get; set; }
}
