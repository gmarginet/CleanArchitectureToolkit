using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.PaymentService.Contracts.Messages;

/// <summary>
/// The answer to <see cref="TakePayment"/>. A declined payment is an answer too, with <see cref="Approved"/> false.
/// The correlation id is the one of the request, so the saga of Orders finds its instance.
/// </summary>
public class PaymentProcessed : CatEventMessage, ICatServiceRequest
{
    public string OrderNumber { get; set; } = string.Empty;

    public bool Approved { get; set; }

    /// <summary>The reference of the payment. Null when the payment was declined.</summary>
    public string? Reference { get; set; }
}
