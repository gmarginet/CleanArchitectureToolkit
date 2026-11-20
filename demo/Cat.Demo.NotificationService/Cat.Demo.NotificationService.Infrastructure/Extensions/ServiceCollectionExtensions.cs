using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.NotificationService.CoreService;
using Cat.Demo.NotificationService.CoreService.Abstractions;
using Cat.Demo.NotificationService.Infrastructure.DataAccess;
using Cat.Demo.NotificationService.Infrastructure.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Demo.NotificationService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>Registers the notification database context for the given SQL Server connection string.</summary>
    public static IServiceCollection AddCatDemoNotificationDatabase(this IServiceCollection services, string connectionString)
    {
        services.TryAddSingleton(TimeProvider.System);
        services.AddDbContext<NotificationDbContext>(options => options.UseSqlServer(connectionString));
        return services;
    }

    /// <summary>
    /// Registers the mail sender. <see cref="SmtpMailSender"/> sends the mail with the settings <c>Smtp:Host</c> and <c>Smtp:Port</c>,
    /// which the AppHost sets to Mailpit.
    /// </summary>
    public static IServiceCollection AddCatDemoNotificationMail(this IServiceCollection services, IConfiguration configuration)
    {
        // The admin gets the low stock report. The address comes from Notifications:AdminEmail.
        var adminEmail = configuration["Notifications:AdminEmail"];
        services.AddSingleton(new NotificationSettings(
            string.IsNullOrWhiteSpace(adminEmail) ? NotificationSettings.DefaultAdminEmail : adminEmail));

        services.AddSingleton<IMailSender, SmtpMailSender>();

        return services;
    }

    /// <summary>Applies the migrations. Call it in development only.</summary>
    public static async Task InitializeNotificationDatabaseAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<NotificationDbContext>();
        await dbContext.Database.MigrateAsync(cancellationToken);
    }
}
