using Cat.Responses;

namespace Cat.Demo.OrderService.CoreService;

public static class OrderErrorDefinitions
{
    private const string OrderErrorCodePrefix = "CAT-ORD-";

    public static readonly CatErrorDefinition DailyLimitReached = CatErrorDefinition.Create($"{OrderErrorCodePrefix}1000", "No more orders can be placed today. The limit is {Limit} orders a day.");

    public static readonly CatErrorDefinition PriceUnavailable = CatErrorDefinition.Create($"{OrderErrorCodePrefix}1001", "The price of book {BookId} is not available.");

    public static readonly CatErrorDefinition OutOfStock = CatErrorDefinition.Create($"{OrderErrorCodePrefix}1002", "Book {BookId} is out of stock. Order {OrderNumber} was cancelled.");

    public static readonly CatErrorDefinition PaymentDeclined = CatErrorDefinition.Create($"{OrderErrorCodePrefix}1003", "The payment of order {OrderNumber} was declined. The order was cancelled.");

    public static readonly CatErrorDefinition CannotCancel = CatErrorDefinition.Create($"{OrderErrorCodePrefix}1004", "Order {OrderNumber} has status {Status} and cannot be cancelled.");

    public static readonly CatErrorDefinition PaymentUnavailable = CatErrorDefinition.Create($"{OrderErrorCodePrefix}1006", "The payment service is not available. Order {OrderNumber} was cancelled. Try again later.");

    public static readonly CatErrorDefinition StockUnavailable = CatErrorDefinition.Create($"{OrderErrorCodePrefix}1007", "The inventory service is not available. Order {OrderNumber} was cancelled. Try again later.");

    public static readonly CatErrorDefinition NotAuthenticated = CatErrorDefinition.Create($"{OrderErrorCodePrefix}1005", "You must be logged in to do this.");
}
