using System;

namespace Cat.Demo.OrderService.DataModels.Entities;

/// <summary>The fixed order statuses. The ids are constants, so no code needs to look a status up by its code.</summary>
public static class OrderStatuses
{
    public const string PendingCode = "Pending";
    public const string ConfirmedCode = "Confirmed";
    public const string CancelledCode = "Cancelled";

    public static readonly Guid PendingId = new("0f1c2a10-0000-4000-8000-000000000001");
    public static readonly Guid ConfirmedId = new("0f1c2a10-0000-4000-8000-000000000002");
    public static readonly Guid CancelledId = new("0f1c2a10-0000-4000-8000-000000000003");

    /// <summary>Gets the id of a status code.</summary>
    public static Guid GetId(string code) => code switch
    {
        PendingCode => PendingId,
        ConfirmedCode => ConfirmedId,
        CancelledCode => CancelledId,
        _ => throw new ArgumentOutOfRangeException(nameof(code), code, "Unknown order status code.")
    };
}
