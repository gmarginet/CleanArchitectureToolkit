using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cat.Api.Gateway.Verification;

/// <summary>
/// Makes a service accept only the calls that come from the gateway.
/// </summary>
/// <remarks>
/// <para>
/// Register the check with <see cref="AddCatGatewayVerification(IServiceCollection, IConfiguration)"/> and switch
/// it on for the whole service with <see cref="UseCatGatewayOnly"/>:
/// </para>
/// <code>
/// builder.Services.AddCatGatewayVerification(builder.Configuration);
/// var app = builder.Build();
/// app.UseCatGatewayOnly();
/// </code>
/// <para>
/// A request without a valid assertion gets a 401 answer. Mark an endpoint that must stay reachable without the
/// gateway, such as a health check, with <see cref="AllowDirectAccess{TBuilder}"/>.
/// </para>
/// <para>
/// Prefer an authorization policy for finer control. The scheme name is
/// <see cref="CatGatewayVerificationDefaults.AuthenticationScheme"/>.
/// </para>
/// </remarks>
public static class CatGatewayVerificationExtensions
{
    /// <summary>
    /// Registers the check. It reads the <c>CatGatewayVerification</c> section of the configuration.
    /// </summary>
    /// <param name="services">The service collection of the service.</param>
    /// <param name="configuration">The configuration of the service.</param>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddCatGatewayVerification(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration is null) throw new ArgumentNullException(nameof(configuration));

        return services.AddCatGatewayVerification(options =>
            configuration.GetSection(CatGatewayVerificationOptions.SectionName).Bind(options));
    }

    /// <summary>
    /// Registers the check with settings from code.
    /// </summary>
    /// <param name="services">The service collection of the service.</param>
    /// <param name="configure">Sets the options.</param>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddCatGatewayVerification(
        this IServiceCollection services,
        Action<CatGatewayVerificationOptions> configure)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));
        if (configure is null) throw new ArgumentNullException(nameof(configure));

        const string scheme = CatGatewayVerificationDefaults.AuthenticationScheme;

        services.AddHttpClient(CatGatewayKeyProvider.HttpClientName);
        services.TryAddSingleton(TimeProvider.System);
        services.AddOptions<CatGatewayVerificationOptions>(scheme)
            .Configure(configure)
            .Validate(o => !string.IsNullOrWhiteSpace(o.Audience),
                "CatGatewayVerification: Audience is required. Use the name of this service as the gateway knows it.")
            .Validate(o => !string.IsNullOrWhiteSpace(o.JwksAddress) || o.PublicKeyPems.Length > 0,
                "CatGatewayVerification: set JwksAddress, PublicKeyPems or both, so the service knows the keys of the gateway.")
            .Validate(o => o.JwksAddress is null || Uri.TryCreate(o.JwksAddress, UriKind.Absolute, out _),
                "CatGatewayVerification: JwksAddress is not an absolute address.")
            .ValidateOnStart();

        services.TryAddSingleton(sp => new CatGatewayKeyProvider(
            sp.GetRequiredService<IOptionsMonitor<CatGatewayVerificationOptions>>().Get(scheme),
            sp.GetRequiredService<System.Net.Http.IHttpClientFactory>(),
            sp.GetRequiredService<TimeProvider>(),
            sp.GetRequiredService<ILogger<CatGatewayKeyProvider>>()));

        services.AddAuthentication()
            .AddScheme<CatGatewayVerificationOptions, CatGatewayAssertionHandler>(scheme, null);

        return services;
    }

    /// <summary>
    /// Rejects every request that has no valid gateway assertion, except for endpoints that allow direct access.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <returns>The same application builder.</returns>
    /// <remarks>
    /// Call it after routing, so the middleware can see the endpoint. A <c>WebApplication</c> routes first on its own.
    /// </remarks>
    public static IApplicationBuilder UseCatGatewayOnly(this IApplicationBuilder app)
    {
        if (app is null) throw new ArgumentNullException(nameof(app));

        return app.Use(async (context, next) =>
        {
            if (context.GetEndpoint()?.Metadata.GetMetadata<IAllowDirectAccessMetadata>() is not null)
            {
                await next(context);
                return;
            }

            var result = await context.AuthenticateAsync(CatGatewayVerificationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await next(context);
        });
    }

    /// <summary>
    /// Lets an endpoint skip the gateway check, so a caller can reach it without the gateway.
    /// </summary>
    /// <typeparam name="TBuilder">The type of the endpoint convention builder.</typeparam>
    /// <param name="builder">The endpoint convention builder.</param>
    /// <returns>The same builder.</returns>
    public static TBuilder AllowDirectAccess<TBuilder>(this TBuilder builder)
        where TBuilder : Microsoft.AspNetCore.Builder.IEndpointConventionBuilder
    {
        if (builder is null) throw new ArgumentNullException(nameof(builder));

        builder.Add(endpoint => endpoint.Metadata.Add(new AllowDirectAccessMetadata()));
        return builder;
    }

    private sealed class AllowDirectAccessMetadata : IAllowDirectAccessMetadata
    {
    }
}

/// <summary>
/// Marks an endpoint that does not need the gateway assertion.
/// </summary>
public interface IAllowDirectAccessMetadata
{
}

/// <summary>
/// The names of the gateway check.
/// </summary>
public static class CatGatewayVerificationDefaults
{
    /// <summary>
    /// The name of the authentication scheme that checks the gateway assertion.
    /// </summary>
    public const string AuthenticationScheme = "CatGatewayAssertion";
}
