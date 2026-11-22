namespace Cat.Demo.NotificationService.CoreService;

/// <summary>
/// The marker of the texts of the mails. <c>IStringLocalizer&lt;MailTexts&gt;</c> reads <c>MailTexts.resx</c> and <c>MailTexts.nl.resx</c>.
/// A text that has no Dutch entry falls back to the English one.
/// </summary>
public sealed class MailTexts;
