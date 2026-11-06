using Cat.Demo.InventoryService.Contracts.ServiceRequests;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.InventoryService.CoreService.Validators;

public class StockReleaseRequestValidator : ICatValidator<StockReleaseRequest>
{
    public void Build(ICatValidatorBuilder<StockReleaseRequest> validator)
    {
        validator.AddPropertyRules(m => m.OrderNumber, b =>
        {
            b.NotEmpty();
            b.MaximumLength(StockReservationModelValidator.MaximumOrderNumberLength);
        });
    }
}
