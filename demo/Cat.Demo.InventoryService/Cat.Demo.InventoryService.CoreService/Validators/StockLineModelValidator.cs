using Cat.Demo.InventoryService.Contracts.Models;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.InventoryService.CoreService.Validators;

public class StockLineModelValidator : ICatValidator<StockLineModel>
{
    public void Build(ICatValidatorBuilder<StockLineModel> validator)
    {
        validator.AddPropertyRules(m => m.Isbn, b =>
        {
            b.NotEmpty();
            b.ExactLength(13);
        });

        validator.AddPropertyRules(m => m.Quantity, b =>
        {
            b.GreaterThan(0);
        });
    }
}
