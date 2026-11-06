using Cat.Demo.InventoryService.Contracts.Models;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.InventoryService.CoreService.Validators;

public class StockReservationModelValidator : ICatValidator<StockReservationModel>
{
    /// <summary>The length of the order number column in the database.</summary>
    public const int MaximumOrderNumberLength = 20;

    /// <summary>The most lines one order can have. It is the same limit as in Orders.</summary>
    public const int MaximumLines = 50;

    public void Build(ICatValidatorBuilder<StockReservationModel> validator)
    {
        validator.AddPropertyRules(m => m.OrderNumber, b =>
        {
            b.NotEmpty();
            b.MaximumLength(MaximumOrderNumberLength);
        });

        validator.AddPropertyRules(m => m.Lines, b =>
        {
            b.NotEmpty();
            b.MaximumCount(MaximumLines);
            b.ValidateEnumerable();
        });
    }
}
