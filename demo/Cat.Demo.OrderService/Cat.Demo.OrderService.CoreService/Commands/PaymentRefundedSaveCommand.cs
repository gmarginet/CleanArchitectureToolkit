using Cat.Commands.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Commands;

/// <summary>Saves that Payment gave the money of an order back. The payment of the order gets the status <c>Refunded</c>.</summary>
public record PaymentRefundedSaveCommand(string OrderNumber) : ICatCommand;
