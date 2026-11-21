using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Messages;

/// <summary>
/// Asks the payment service to give the money of a cancelled order back. Orders sends it through its outbox, and it goes to a queue.
/// The payment service copies the correlation id into its answer, <see cref="PaymentRefunded"/>.
/// </summary>
public class RefundPayment : CatCommandMessage, ICatServiceRequest
{
    /// <summary>The order number. It is the idempotency key: the same number is never refunded twice.</summary>
    public string OrderNumber { get; set; } = string.Empty;
}
