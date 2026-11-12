using System;
using Cat.Users.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Users.Extensions;

/// <summary>
/// Registration helpers for the users module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="ICatUser"/> and <see cref="ICatUserAccessor"/>, both scoped.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configure">Changes the names of the claims.</param>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddCatUsers(this IServiceCollection services, Action<CatUsersOptions>? configure = null)
    {
        var options = services.AddOptions<CatUsersOptions>();
        if (configure != null)
        {
            options.Configure(configure);
        }

        services.AddHttpContextAccessor();
        services.TryAddScoped<ICatUserAccessor, CatUserAccessor>();
        services.TryAddScoped(provider => provider.GetRequiredService<ICatUserAccessor>().User);
        return services;
    }
}
