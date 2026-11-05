using System;
using Cat.Commands.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Commands;

/// <summary>
/// Saves the outcome of the payment of an order. A declined payment is saved too, without a paid date.
/// It is a class with a parameterless constructor, because a workflow step creates it and fills it.
/// </summary>
public class PaymentSaveCommand : ICatCommand
{
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public bool Approved { get; set; }
}
