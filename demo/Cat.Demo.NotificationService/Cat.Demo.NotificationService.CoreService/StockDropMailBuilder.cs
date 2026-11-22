using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.NotificationService.CoreService.Abstractions;
using Microsoft.Extensions.Localization;

namespace Cat.Demo.NotificationService.CoreService;

/// <summary>Builds the mail for a stock item that just dropped below the limit, in the current UI culture.</summary>
public class StockDropMailBuilder(IStringLocalizer<MailTexts> localizer)
{
    public OutgoingMail Build(string adminEmail, StockChanged change)
    {
        return new OutgoingMail(
            adminEmail,
            localizer["StockDrop.Subject", change.Isbn],
            localizer["StockDrop.Body", change.Isbn, change.WarehouseId, change.NewQuantity!, change.Limit]);
    }
}
