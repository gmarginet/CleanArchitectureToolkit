using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.PaymentService.Contracts.Messages;

/// <summary>
/// The answer to <see cref="RefundPayment"/>. <see cref="Refunded"/> is false when there was no approved payment to give back.
/// </summary>
public class PaymentRefunded : CatEventMessage, ICatServiceRequest
{
    public string OrderNumber { get; set; } = string.Empty;

    public bool Refunded { get; set; }
}
