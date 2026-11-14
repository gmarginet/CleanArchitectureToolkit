using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.PaymentService.Contracts.Messages;

/// <summary>
/// Asks the payment service to take a payment. Orders sends it from the wait step of the place order saga, and it goes to a queue.
/// The correlation id is the id of the saga instance. The payment service copies it into its answer, <see cref="PaymentProcessed"/>.
/// </summary>
public class TakePayment : CatCommandMessage, ICatServiceRequest
{
    /// <summary>The order number. It is the idempotency key: the same number is never charged twice.</summary>
    public string OrderNumber { get; set; } = string.Empty;

    public decimal Amount { get; set; }
}
