using Cat.EventProcessor.Abstractions;
using Cat.Users.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Cat.EventProcessor.Authorization.Extensions;

/// <summary>
/// Registration helpers for the authorization of messages.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the message authorizer. It validates the token of a message with the JWT bearer options of the service,
    /// so register the scheme with <c>AddAuthentication().AddJwtBearer()</c>, also when the service has no HTTP authentication.
    /// It also registers ASP.NET Core authorization, the users module and a check of the policy names at startup.
    /// Define the policies with <c>AddAuthorization</c>. Register it after <c>AddCatEventProcessor</c>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configure">Changes the settings of the authorization of messages.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatEventProcessorAuthorization(this IServiceCollection services,
        Action<CatMessageAuthorizationOptions>? configure = null)
    {
        var options = services.AddOptions<CatMessageAuthorizationOptions>();
        if (configure != null)
        {
            options.Configure(configure);
        }

        services.AddLogging();
        services.AddAuthorizationCore();
        services.AddCatUsers();
        services.TryAddScoped<CatMessageTokenValidator>();
        services.TryAddScoped<ICatMessageAuthorizer, CatMessageAuthorizer>();
        services.AddSingleton<IHostedService, AuthorizationStartupCheck>();

        return services;
    }
}
