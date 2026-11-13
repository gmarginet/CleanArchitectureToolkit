using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.NotificationService.CoreService.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.NotificationService.Infrastructure.Mail;

/// <summary>Writes the mail to the log and sends nothing. It is used when the host gives no <c>Smtp:Host</c>.</summary>
public class LogMailSender(ILogger<LogMailSender> logger) : IMailSender
{
    public Task SendAsync(OutgoingMail mail, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Mail to {To}: {Subject}\n{Body}", mail.To, mail.Subject, mail.Body);
        return Task.CompletedTask;
    }
}
