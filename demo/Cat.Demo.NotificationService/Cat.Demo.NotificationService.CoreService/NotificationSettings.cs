using System.Globalization;

namespace Cat.Demo.NotificationService.CoreService;

/// <summary>The settings of the mails that do not go to a customer.</summary>
/// <param name="AdminEmail">The address of the admin. It gets the low stock report. The configuration key is <c>Notifications:AdminEmail</c>.</param>
/// <param name="AdminCulture">The language of the mails to the admin, such as <c>en</c>. The configuration key is <c>Notifications:AdminCulture</c>.</param>
public record NotificationSettings(string AdminEmail, string AdminCulture = NotificationSettings.DefaultAdminCulture)
{
    /// <summary>The address when the configuration gives none.</summary>
    public const string DefaultAdminEmail = "admin@example.com";

    /// <summary>The language when the configuration gives none.</summary>
    public const string DefaultAdminCulture = "en";

    /// <summary>
    /// Sets <c>CurrentCulture</c> and <c>CurrentUICulture</c> to the culture of the admin, until the result is disposed.
    /// A mail to the admin must not follow the language of the message that caused it. A message from the order of a Dutch
    /// customer would otherwise give the admin a Dutch mail. The culture of an async handler does not leak back to the listener.
    /// </summary>
    public System.IDisposable UseAdminCulture()
    {
        var previousCulture = CultureInfo.CurrentCulture;
        var previousUICulture = CultureInfo.CurrentUICulture;
        var culture = CultureInfo.GetCultureInfo(AdminCulture);
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
        return new Restore(previousCulture, previousUICulture);
    }

    private sealed class Restore(CultureInfo culture, CultureInfo uiCulture) : System.IDisposable
    {
        public void Dispose()
        {
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = uiCulture;
        }
    }
}
