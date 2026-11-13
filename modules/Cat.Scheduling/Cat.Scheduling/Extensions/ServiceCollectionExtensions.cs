using System;
using Cat.Scheduling.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Scheduling.Extensions;

/// <summary>
/// Registration helpers for the scheduler.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// The configuration section that holds the settings per job, in the form
    /// <c>CatScheduling:Jobs:clean-up-order-counters:Cron</c>.
    /// </summary>
    public const string ConfigurationSectionName = "CatScheduling:Jobs";

    /// <summary>
    /// Registers the scheduler, the jobs the service declares and the runner. The scheduler starts with the host.
    /// The settings per job come from the code. The configuration wins, so whoever runs the service can change a cron expression
    /// or switch a job off without a build. A cron expression or a time zone that is not valid throws here, so the service fails at startup.
    /// Register the service request module too. The claim store is in memory unless you register another one, such as
    /// the EF Core store of <c>Cat.Scheduling.EFCore</c>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configuration">The configuration of the service.</param>
    /// <param name="declare">Declares the jobs.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatScheduling(this IServiceCollection services,
        IConfiguration configuration,
        Action<CatSchedulerBuilder> declare)
    {
        var builder = new CatSchedulerBuilder();
        declare(builder);

        foreach (var registration in builder.Registrations)
        {
            configuration.GetSection(ConfigurationSectionName).GetSection(registration.Name).Bind(registration.Options);
            CronSchedule.Create(registration.Name, registration.Options);
        }

        services.AddSingleton<ICatJobRegistry>(new JobRegistry(builder.Registrations));
        services.AddSingleton(new CatSchedulerSettings(builder.SystemUserName));
        services.TryAddSingleton(TimeProvider.System);
        services.TryAddSingleton<ICatJobClaimStore, InMemoryJobClaimStore>();
        services.AddSingleton<CatJobRunner>();
        services.AddSingleton<ICatJobRunner>(provider => provider.GetRequiredService<CatJobRunner>());
        services.AddHostedService<CatSchedulerService>();

        return services;
    }
}
