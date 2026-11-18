using System;
using Cat.EFCore.Entities;

namespace Cat.Demo.OrderService.DataModels.Entities;

public class Payment : CatEntityBase
{
    public const string ApprovedStatus = "Approved";
    public const string DeclinedStatus = "Declined";

    /// <summary>The order was cancelled and Payment was asked for the money back. It has not answered yet.</summary>
    public const string RefundPendingStatus = "RefundPending";

    /// <summary>Payment gave the money back.</summary>
    public const string RefundedStatus = "Refunded";

    public Guid OrderId { get; set; }

    /// <summary>The amount in euro.</summary>
    public decimal Amount { get; set; }

    public required string Status { get; set; }

    /// <summary>The moment the payment was taken. Empty when the payment was declined.</summary>
    public DateTime? PaidAt { get; set; }
}
