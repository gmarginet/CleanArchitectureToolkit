using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.NotificationService.CoreService.Abstractions;

namespace Cat.Demo.NotificationService.CoreService;

/// <summary>Builds the text of the mail for a stock item that just dropped below the limit. The mails are in English.</summary>
public static class StockDropMailBuilder
{
    public static OutgoingMail Build(string adminEmail, StockChanged change)
    {
        var body = $"Hello,\n\n"
                   + $"The stock of ISBN {change.Isbn} in warehouse {change.WarehouseId} dropped to {change.NewQuantity}. The limit is {change.Limit}.\n\n"
                   + "Please order more copies.";

        return new OutgoingMail(adminEmail, $"Low stock: ISBN {change.Isbn}", body);
    }
}
