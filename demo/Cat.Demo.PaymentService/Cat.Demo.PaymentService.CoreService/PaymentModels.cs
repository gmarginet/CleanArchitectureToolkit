namespace Cat.Demo.PaymentService.CoreService;

/// <summary>A request to take a payment. The order number says which order the money is for.</summary>
public record ChargeRequest(string OrderNumber, decimal Amount);

/// <summary>
/// The answer to a charge. <see cref="Status"/> is <see cref="ChargeStatuses.Approved"/> or <see cref="ChargeStatuses.Declined"/>.
/// A decline is an answer, not an error.
/// </summary>
public record ChargeResponse(string Status, string? Reference);

/// <summary>The two statuses of a charge.</summary>
public static class ChargeStatuses
{
    public const string Approved = "approved";

    public const string Declined = "declined";
}

/// <summary>A request to give the money of an order back.</summary>
public record RefundRequest(string OrderNumber);

/// <summary>
/// The answer to a refund. <see cref="Status"/> is <see cref="RefundStatuses.Refunded"/>, or
/// <see cref="RefundStatuses.NothingToRefund"/> when there was no approved payment to give back.
/// </summary>
public record RefundResponse(string Status);

/// <summary>The two statuses of a refund.</summary>
public static class RefundStatuses
{
    public const string Refunded = "refunded";

    public const string NothingToRefund = "nothing_to_refund";
}

/// <summary>The outcome of a charge: either an answer, or a failure that was switched on on purpose.</summary>
public record ChargeOutcome(ChargeResponse? Response, bool Failed)
{
    public static ChargeOutcome Answer(ChargeResponse response) => new(response, false);

    public static ChargeOutcome Failure() => new(null, true);
}

/// <summary>The outcome of a refund: either an answer, or a failure that was switched on on purpose.</summary>
public record RefundOutcome(RefundResponse? Response, bool Failed)
{
    public static RefundOutcome Answer(RefundResponse response) => new(response, false);

    public static RefundOutcome Failure() => new(null, true);
}
