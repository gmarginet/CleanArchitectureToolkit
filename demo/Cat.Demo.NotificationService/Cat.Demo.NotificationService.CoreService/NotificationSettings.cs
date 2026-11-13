namespace Cat.Demo.NotificationService.CoreService;

/// <summary>The settings of the mails that do not go to a customer.</summary>
/// <param name="AdminEmail">The address of the admin. It gets the low stock report. The configuration key is <c>Notifications:AdminEmail</c>.</param>
public record NotificationSettings(string AdminEmail)
{
    /// <summary>The address when the configuration gives none.</summary>
    public const string DefaultAdminEmail = "admin@example.com";
}
