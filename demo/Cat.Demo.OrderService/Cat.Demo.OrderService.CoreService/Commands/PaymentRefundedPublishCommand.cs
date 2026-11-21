using System;
using Cat.Commands.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Commands;

/// <summary>
/// Publishes <c>PaymentRefunded</c>, the answer of the payment provider to a <c>RefundPayment</c> request.
/// <paramref name="Refunded"/> is false when the provider had no approved payment to give back.
/// </summary>
public record PaymentRefundedPublishCommand(Guid CorrelationId, string OrderNumber, bool Refunded) : ICatCommand;
