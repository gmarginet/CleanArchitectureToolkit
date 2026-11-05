using System;

namespace Cat.Demo.OrderService.CoreService.Events;

/// <summary>The base of all order events. A subscriber of this type receives every order event.</summary>
public interface IOrderEvent
{
    Guid OrderId { get; }
    string OrderNumber { get; }
}
