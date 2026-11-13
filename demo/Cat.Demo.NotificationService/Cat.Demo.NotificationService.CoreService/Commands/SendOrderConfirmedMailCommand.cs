using System;
using Cat.Commands.Abstractions;

namespace Cat.Demo.NotificationService.CoreService.Commands;

/// <summary>
/// Sends the confirmation mail of an order. An order that already got this mail is not mailed again.
/// </summary>
public record SendOrderConfirmedMailCommand(
    Guid OrderId,
    string OrderNumber,
    decimal Total,
    string CustomerName,
    string CustomerEmail) : ICatCommand;
