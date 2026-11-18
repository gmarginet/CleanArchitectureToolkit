namespace Cat.Demo.PaymentService.CoreService;

/// <summary>A request to take a payment. The order number is the idempotency key: the same number is never charged twice.</summary>
public record PaymentRequest(string OrderNumber, decimal Amount);

/// <summary>The answer to a payment request. A declined payment is an answer, not an error.</summary>
public record PaymentResponse(bool Approved, string? Reference);

/// <summary>The outcome of processing: either an answer, or a failure that was switched on on purpose.</summary>
public record PaymentOutcome(PaymentResponse? Response, bool Failed)
{
    public static PaymentOutcome Answer(PaymentResponse response) => new(response, false);

    public static PaymentOutcome Failure() => new(null, true);
}

/// <summary>The outcome of a refund. <see cref="Refunded"/> is false when there was no approved payment to give back.</summary>
public record RefundOutcome(bool Refunded, bool Failed)
{
    public static RefundOutcome Done(bool refunded) => new(refunded, false);

    public static RefundOutcome Failure() => new(false, true);
}
