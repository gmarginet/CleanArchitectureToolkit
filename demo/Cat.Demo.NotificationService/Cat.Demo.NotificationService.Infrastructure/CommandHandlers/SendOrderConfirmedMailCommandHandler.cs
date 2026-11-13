using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.NotificationService.CoreService;
using Cat.Demo.NotificationService.CoreService.Abstractions;
using Cat.Demo.NotificationService.CoreService.Commands;
using Cat.Demo.NotificationService.DataModels.Entities;
using Cat.Demo.NotificationService.Infrastructure.DataAccess;
using Cat.EFCore.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.NotificationService.Infrastructure.CommandHandlers;

/// <summary>
/// Sends the confirmation mail of an order and remembers it in <c>SentMail</c>.
/// A repeated message finds the row and sends nothing, so the handling is idempotent.
/// The mail goes out before the row is saved. A crash in between sends the mail twice at worst, and never loses it.
/// </summary>
public class SendOrderConfirmedMailCommandHandler(
    NotificationDbContext dbContext,
    IMailSender mailSender,
    TimeProvider timeProvider)
    : CatEfCommandHandlerBase<NotificationDbContext, SendOrderConfirmedMailCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(SendOrderConfirmedMailCommand command, CancellationToken cancellationToken = default)
    {
        var alreadySent = await DbContext.SentMails.AnyAsync(
            x => x.OrderId == command.OrderId && x.Kind == MailKinds.OrderConfirmed,
            cancellationToken);
        if (alreadySent)
        {
            return CatResponse.Ok();
        }

        var mail = OrderConfirmedMailBuilder.Build(command);
        await mailSender.SendAsync(mail, cancellationToken);

        DbContext.SentMails.Add(new SentMail
        {
            OrderId = command.OrderId,
            Kind = MailKinds.OrderConfirmed,
            Recipient = mail.To,
            Subject = mail.Subject,
            SentAt = timeProvider.GetUtcNow().UtcDateTime
        });
        await DbContext.SaveChangesAsync(cancellationToken);

        return CatResponse.Ok();
    }
}
