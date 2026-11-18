using System;
using Cat.Commands.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Commands;

/// <summary>
/// Asks Payment to give the money of a cancelled order back. An approved payment gets the status <c>RefundPending</c>,
/// and the <c>RefundPayment</c> message goes into the outbox in the same save. Any other payment, or no payment, does nothing.
/// </summary>
public record PaymentRefundRequestCommand(Guid OrderId, string OrderNumber) : ICatCommand;
