using System.Text;
using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.NotificationService.CoreService.Abstractions;

namespace Cat.Demo.NotificationService.CoreService;

/// <summary>Builds the text of the low stock report mail. The mails are in English.</summary>
public static class LowStockReportMailBuilder
{
    public static OutgoingMail Build(string adminEmail, LowStockReport report)
    {
        var body = new StringBuilder();
        body.Append("Hello,\n\n");
        body.Append($"These stock items are below the limit of {report.Limit}:\n\n");

        foreach (var line in report.Lines)
        {
            body.Append($"- ISBN {line.Isbn}, {line.Warehouse}: {line.QuantityOnHand} left\n");
        }

        body.Append("\nPlease order more copies.");

        var subject = report.Lines.Count == 1
            ? "Low stock: 1 item"
            : $"Low stock: {report.Lines.Count} items";

        return new OutgoingMail(adminEmail, subject, body.ToString());
    }
}
