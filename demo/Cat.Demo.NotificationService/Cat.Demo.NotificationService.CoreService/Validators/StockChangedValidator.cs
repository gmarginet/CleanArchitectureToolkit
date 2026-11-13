using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.NotificationService.CoreService.Validators;

/// <summary>
/// Rejects a malformed <see cref="StockChanged"/> message, such as one without an ISBN or with a negative quantity.
/// A rejected message answers <c>BadRequest</c> and is dead lettered, because sending it again gives the same answer.
/// It does not decide whether a change is a drop. That is the job of the handler, because a change that is no drop is correct input.
/// </summary>
public class StockChangedValidator : ICatValidator<StockChanged>
{
    public void Build(ICatValidatorBuilder<StockChanged> validator)
    {
        validator.AddPropertyRules(m => m.Isbn, b =>
        {
            b.NotEmpty();
            b.ExactLength(13);
        });

        validator.AddPropertyRules(m => m.WarehouseId, b => b.GreaterThan(0));
        validator.AddPropertyRules(m => m.Limit, b => b.GreaterThan(0));
        validator.AddPropertyRules(m => m.OldQuantity, b => b.GreaterThanOrEqualTo(0));
        validator.AddPropertyRules(m => m.NewQuantity, b => b.GreaterThanOrEqualTo(0));
    }
}
