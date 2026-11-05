using System;

namespace Cat.Demo.OrderService.CoreService.Events;

/// <summary>The stock is reserved and the payment is taken.</summary>
public record OrderConfirmedEvent(Guid OrderId, string OrderNumber, decimal Total) : IOrderEvent;
