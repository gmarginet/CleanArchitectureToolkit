using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.OrderService.CoreService.Validators;

public class PlaceOrderRequestValidator : ICatValidator<PlaceOrderRequest>
{
    public void Build(ICatValidatorBuilder<PlaceOrderRequest> validator)
    {
        validator.AddPropertyRules(m => m.Order, b =>
        {
            b.NotNull();
            b.Validate();
        });
    }
}
