using Cat.Responses;

namespace Cat.Demo.PaymentService.CoreService;

public static class PaymentErrorDefinitions
{
    private const string PaymentErrorCodePrefix = "DEM-PAY";

    public static readonly CatErrorDefinition InvalidRequest = CatErrorDefinition.Create(PaymentErrorCodePrefix, 1000, "An order number and an amount above zero are required.");

    public static readonly CatErrorDefinition Failing = CatErrorDefinition.Create(PaymentErrorCodePrefix, 1001, "The payment service is failing on purpose. The payment of order {OrderNumber} was not answered.");
}
