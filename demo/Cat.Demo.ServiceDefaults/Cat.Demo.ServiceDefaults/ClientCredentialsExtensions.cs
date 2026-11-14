using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Demo.ServiceDefaults;

/// <summary>
/// Registers the client credentials token of a demo service.
/// </summary>
public static class ClientCredentialsExtensions
{
    /// <summary>
    /// Registers the client credentials token of the service, for work that has no user, such as the jobs of the Scheduler
    /// or the answer to a message. It needs <c>Authentication:Authority</c>, <c>Authentication:ClientId</c> and
    /// <c>Authentication:ClientSecret</c> in the configuration (the AppHost sets them).
    /// Without one of them nothing is registered, and such work goes out without a token.
    /// </summary>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddDemoClientCredentials(this IServiceCollection services, IConfiguration configuration)
    {
        var authority = configuration["Authentication:Authority"];
        var clientId = configuration["Authentication:ClientId"];
        var clientSecret = configuration["Authentication:ClientSecret"];
        if (string.IsNullOrWhiteSpace(authority) || string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
        {
            return services;
        }

        services.TryAddSingleton(TimeProvider.System);
        services.AddHttpClient(ClientCredentialsTokenProvider.HttpClientName);
        services.TryAddSingleton(new ClientCredentialsSettings($"{authority.TrimEnd('/')}/protocol/openid-connect/token", clientId, clientSecret));
        services.TryAddSingleton<IClientTokenProvider, ClientCredentialsTokenProvider>();
        return services;
    }

    /// <summary>
    /// Registers <see cref="DemoMessageTokenProvider"/>, so the messages of the service carry a token.
    /// Call <see cref="AddDemoClientCredentials"/> too, or the messages without a request go out without a token.
    /// </summary>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddDemoMessageTokens(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.TryAddSingleton<Cat.Messaging.Abstractions.ICatTokenProvider, DemoMessageTokenProvider>();
        return services;
    }
}
