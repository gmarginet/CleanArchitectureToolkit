namespace Cat.Demo.OrderService.CoreService.Events;

/// <summary>The reasons an order gets canceled.</summary>
public static class OrderCancelReasons
{
    public const string OutOfStock = "OutOfStock";
    public const string StockUnavailable = "StockUnavailable";
    public const string PaymentDeclined = "PaymentDeclined";
    public const string PaymentUnavailable = "PaymentUnavailable";
    public const string CancelledByUser = "CancelledByUser";

    /// <summary>The caller gave up while the order was being placed, for example a gateway timeout.</summary>
    public const string RequestCancelled = "RequestCancelled";
}
