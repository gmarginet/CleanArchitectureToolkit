using System;

namespace Cat.Demo.OrderService.CoreService.Events;

/// <summary>The order was canceled. <paramref name="Reason"/> is one of the codes in <see cref="OrderCancelReasons"/>.</summary>
public record OrderCancelledEvent(Guid OrderId, string OrderNumber, string Reason) : IOrderEvent;
