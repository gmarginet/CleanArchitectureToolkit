using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Responses;
using Cat.UnitTesting.Commands;

namespace Cat.Demo.OrderService.CoreService.Tests;

/// <summary>
/// The answers that the real handlers of Orders give, set up on a <see cref="FakeCommandProcessor"/>.
/// The fake itself stays dumb, so the demo decides these ids here.
/// </summary>
public static class OrderCommandDefaults
{
    /// <summary>The order id that <c>NewState</c> in the workflow tests puts in the state.</summary>
    public static readonly Guid NewOrderId = Guid.Parse("11111111-1111-1111-1111-111111111111");

    public const string NewOrderNumber = "20261105-0001";

    /// <summary>The customer id the fake hands out.</summary>
    public static readonly Guid CustomerId = Guid.Parse("22222222-2222-2222-2222-222222222222");

    /// <summary>
    /// Sets the customer id on a customer command and answers an order with its number, as the real handlers do.
    /// A test can replace either answer afterwards with <c>Respond</c>.
    /// </summary>
    public static FakeCommandProcessor Apply(this FakeCommandProcessor commands)
    {
        return commands
            .Respond<CustomerCreateOrUpdateCommand>(customer =>
            {
                customer.CustomerId = CustomerId;
                return CatResponse.Ok();
            })
            .Respond<OrderCreateCommand, OrderCreated>(order => CatResponse.Ok(new OrderCreated(order.OrderId, NewOrderNumber)));
    }
}
