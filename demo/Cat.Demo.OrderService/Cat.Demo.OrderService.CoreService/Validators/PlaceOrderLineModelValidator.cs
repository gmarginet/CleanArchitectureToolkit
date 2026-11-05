using Cat.Demo.OrderService.Contracts.Models;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.OrderService.CoreService.Validators;

public class PlaceOrderLineModelValidator : ICatValidator<PlaceOrderLineModel>
{
    public const int MaximumQuantity = 99;

    public void Build(ICatValidatorBuilder<PlaceOrderLineModel> validator)
    {
        validator.AddPropertyRules(m => m.BookId, b =>
        {
            b.NotEmpty();
        });

        validator.AddPropertyRules(m => m.Quantity, b =>
        {
            b.InclusiveBetween(1, MaximumQuantity);
        });
    }
}
