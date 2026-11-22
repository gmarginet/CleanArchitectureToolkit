using Cat.Demo.NotificationService.CoreService.Abstractions;
using Cat.Demo.NotificationService.CoreService.Commands;
using Microsoft.Extensions.Localization;

namespace Cat.Demo.NotificationService.CoreService;

/// <summary>
/// Builds the order confirmed mail in the current UI culture. The total is formatted with the current culture,
/// so a Dutch mail shows <c>EUR 12,50</c>.
/// </summary>
public class OrderConfirmedMailBuilder(IStringLocalizer<MailTexts> localizer)
{
    public OutgoingMail Build(SendOrderConfirmedMailCommand command)
    {
        var name = string.IsNullOrWhiteSpace(command.CustomerName) ? localizer["OrderConfirmed.UnnamedCustomer"].Value : command.CustomerName;

        return new OutgoingMail(
            command.CustomerEmail,
            localizer["OrderConfirmed.Subject", command.OrderNumber],
            localizer["OrderConfirmed.Body", name, command.OrderNumber, command.Total]);
    }
}
