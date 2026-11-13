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

    /// <summary>The name of the customer who placed the order. Notifications greets the customer with it.</summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>The email address of the customer. Notifications sends the confirmation mail to it. Empty when the customer has none.</summary>
    public string CustomerEmail { get; set; } = string.Empty;
}
