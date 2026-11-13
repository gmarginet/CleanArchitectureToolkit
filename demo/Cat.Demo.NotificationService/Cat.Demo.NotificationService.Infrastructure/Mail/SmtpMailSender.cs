using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.NotificationService.CoreService.Abstractions;
using Microsoft.Extensions.Configuration;

namespace Cat.Demo.NotificationService.Infrastructure.Mail;

/// <summary>
/// Sends the mail over SMTP. The AppHost points it at the Mailpit container, which keeps every mail in a web inbox.
/// The settings are <c>Smtp:Host</c>, <c>Smtp:Port</c> and <c>Smtp:From</c>.
/// </summary>
public class SmtpMailSender(IConfiguration configuration) : IMailSender
{
    public async Task SendAsync(OutgoingMail mail, CancellationToken cancellationToken = default)
    {
        var host = configuration["Smtp:Host"] ?? "localhost";
        var port = int.TryParse(configuration["Smtp:Port"], out var parsed) ? parsed : 1025;
        var from = configuration["Smtp:From"] ?? "bookshop@cat-demo.example";

        using var client = new SmtpClient(host, port);
        using var message = new MailMessage(from, mail.To, mail.Subject, mail.Body);
        await client.SendMailAsync(message, cancellationToken);
    }
}
