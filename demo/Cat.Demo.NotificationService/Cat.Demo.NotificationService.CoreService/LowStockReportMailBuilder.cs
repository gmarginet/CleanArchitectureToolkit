using System.Linq;
using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.NotificationService.CoreService.Abstractions;
using Microsoft.Extensions.Localization;

namespace Cat.Demo.NotificationService.CoreService;

/// <summary>Builds the low stock report mail, in the current UI culture.</summary>
public class LowStockReportMailBuilder(IStringLocalizer<MailTexts> localizer)
{
    public OutgoingMail Build(string adminEmail, LowStockReport report)
    {
        var lines = string.Join(
            "\n",
            report.Lines.Select(line => localizer["LowStockReport.Line", line.Isbn, line.Warehouse, line.QuantityOnHand].Value));

        var subject = report.Lines.Count == 1
            ? localizer["LowStockReport.Subject.One"]
            : localizer["LowStockReport.Subject.Many", report.Lines.Count];

        return new OutgoingMail(adminEmail, subject, localizer["LowStockReport.Body", report.Limit, lines]);
    }
}
