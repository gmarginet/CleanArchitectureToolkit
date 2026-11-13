using System;
using Cat.EFCore.Entities;

namespace Cat.Demo.NotificationService.DataModels.Entities;

/// <summary>
/// A mail that Notifications has sent. The pair of <see cref="OrderId"/> and <see cref="Kind"/> is unique,
/// so a message that arrives twice sends one mail.
/// </summary>
public class SentMail : CatEntityBase
{
    /// <summary>The order the mail is about.</summary>
    public Guid OrderId { get; set; }

    /// <summary>The kind of mail, one of the codes in <see cref="MailKinds"/>.</summary>
    public required string Kind { get; set; }

    public required string Recipient { get; set; }
    public required string Subject { get; set; }
    public DateTime SentAt { get; set; }
}
