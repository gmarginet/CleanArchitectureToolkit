namespace Cat.Demo.OrderService.CoreService.Events;

/// <summary>The reasons an order gets canceled.</summary>
public static class OrderCancelReasons
{
    public const string OutOfStock = "OutOfStock";
    public const string PaymentDeclined = "PaymentDeclined";
    public const string CancelledByUser = "CancelledByUser";
}
