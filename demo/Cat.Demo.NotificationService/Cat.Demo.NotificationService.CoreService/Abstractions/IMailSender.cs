using System.Threading;
using System.Threading.Tasks;

namespace Cat.Demo.NotificationService.CoreService.Abstractions;

/// <summary>Sends a mail. The Infrastructure project sends it over SMTP, and the tests use a fake.</summary>
public interface IMailSender
{
    Task SendAsync(OutgoingMail mail, CancellationToken cancellationToken = default);
}

/// <summary>A plain text mail to one recipient.</summary>
public record OutgoingMail(string To, string Subject, string Body);
