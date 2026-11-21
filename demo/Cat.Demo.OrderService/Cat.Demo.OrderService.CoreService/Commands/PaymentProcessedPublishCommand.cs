using System;
using Cat.Commands.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Commands;

/// <summary>
/// Publishes <c>PaymentProcessed</c>, the answer of the payment provider to a <c>TakePayment</c> request, for the saga of the order.
/// The correlation id is the one of the request, so the saga finds its instance.
/// </summary>
public record PaymentProcessedPublishCommand(Guid CorrelationId, string OrderNumber, bool Approved, string? Reference) : ICatCommand;
