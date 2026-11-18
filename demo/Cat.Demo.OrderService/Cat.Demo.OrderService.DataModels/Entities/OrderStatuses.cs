using System;

namespace Cat.Demo.OrderService.DataModels.Entities;

/// <summary>The fixed order statuses. The ids are constants, so no code needs to look a status up by its code.</summary>
public static class OrderStatuses
{
    public const string PendingCode = "Pending";
    public const string ConfirmedCode = "Confirmed";
    public const string CancelledCode = "Cancelled";
    public const string ShippedCode = "Shipped";

    public static readonly Guid PendingId = new("0f1c2a10-0000-4000-8000-000000000001");
    public static readonly Guid ConfirmedId = new("0f1c2a10-0000-4000-8000-000000000002");
    public static readonly Guid CancelledId = new("0f1c2a10-0000-4000-8000-000000000003");
    public static readonly Guid ShippedId = new("0f1c2a10-0000-4000-8000-000000000004");

    /// <summary>
    /// Tells whether an order with this status can be cancelled. Only a Pending or a Confirmed order can.
    /// A new status stays non-cancellable until it is added here.
    /// </summary>
    public static bool CanCancel(string code) => code is PendingCode or ConfirmedCode;

    /// <summary>Gets the id of a status code.</summary>
    public static Guid GetId(string code) => code switch
    {
        PendingCode => PendingId,
        ConfirmedCode => ConfirmedId,
        CancelledCode => CancelledId,
        ShippedCode => ShippedId,
        _ => throw new ArgumentOutOfRangeException(nameof(code), code, "Unknown order status code.")
    };
}
