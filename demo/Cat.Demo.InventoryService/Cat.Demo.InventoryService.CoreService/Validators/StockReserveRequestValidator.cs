using Cat.Demo.InventoryService.Contracts.ServiceRequests;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.InventoryService.CoreService.Validators;

public class StockReserveRequestValidator : ICatValidator<StockReserveRequest>
{
    public void Build(ICatValidatorBuilder<StockReserveRequest> validator)
    {
        validator.AddPropertyRules(m => m.Reservation, b =>
        {
            b.NotNull();
            b.Validate();
        });
    }
}
