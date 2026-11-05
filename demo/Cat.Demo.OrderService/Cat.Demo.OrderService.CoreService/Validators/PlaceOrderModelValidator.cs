using Cat.Demo.OrderService.Contracts.Models;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.OrderService.CoreService.Validators;

public class PlaceOrderModelValidator : ICatValidator<PlaceOrderModel>
{
    /// <summary>The most lines one order can have. It stays below the 100 books Catalog prices in one call.</summary>
    public const int MaximumLines = 50;

    public void Build(ICatValidatorBuilder<PlaceOrderModel> validator)
    {
        validator.AddPropertyRules(m => m.Lines, b =>
        {
            b.NotEmpty();
            b.MaximumCount(MaximumLines);
            b.ValidateEnumerable();
        });
    }
}
