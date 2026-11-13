using System.Globalization;
using Cat.Demo.NotificationService.CoreService.Abstractions;
using Cat.Demo.NotificationService.CoreService.Commands;

namespace Cat.Demo.NotificationService.CoreService;

/// <summary>Builds the text of the order confirmed mail. The mails are in English.</summary>
public static class OrderConfirmedMailBuilder
{
    public static OutgoingMail Build(SendOrderConfirmedMailCommand command)
    {
        var name = string.IsNullOrWhiteSpace(command.CustomerName) ? "customer" : command.CustomerName;
        var total = command.Total.ToString("0.00", CultureInfo.InvariantCulture);

        var body =
            $"Hello {name},\n\n" +
            $"Your order {command.OrderNumber} is confirmed. The stock is reserved and the payment is taken.\n" +
            $"The total is EUR {total}.\n\n" +
            "Thank you for ordering at the Cat bookshop.";

        return new OutgoingMail(command.CustomerEmail, $"Your order {command.OrderNumber} is confirmed", body);
    }
}
