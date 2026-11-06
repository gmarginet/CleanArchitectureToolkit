using System;
using System.Threading.RateLimiting;
using Cat.Api.Gateway.Assertion;
using Cat.Api.Gateway.Configuration;
using Cat.Api.Gateway.Middleware;
using Cat.Api.Gateway.Transforms;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.Transforms.Builder;

namespace Cat.Api.Gateway;

/// <summary>
/// Sets up a gateway in a host project, in three calls.
/// </summary>
/// <remarks>
/// <para>
/// A host project calls <see cref="AddCatApiGateway"/> on the services, <see cref="UseCatApiGateway"/> on the
/// application and <see cref="MapCatApiGateway"/> on the endpoints:
/// </para>
/// <code>
/// builder.Services.AddCatApiGateway(builder.Configuration);
/// var app = builder.Build();
/// app.UseCatApiGateway();
/// app.MapCatApiGateway();
/// app.Run();
/// </code>
/// <para>
/// The gateway is secure by default. Every endpoint needs a valid token, unless a service lists it as anonymous.
/// This also goes for every other endpoint that you map in the host, so mark an endpoint like a health check
/// with <c>AllowAnonymous</c>.
/// </para>
/// </remarks>
public static class CatApiGatewayExtensions
{
    private const string CorsPolicyName = "CatGateway";

    /// <summary>
    /// Registers the gateway. It reads the <c>CatGateway</c> section of the configuration.
    /// </summary>
    /// <param name="services">The service collection of the host.</param>
    /// <param name="configuration">The configuration of the host.</param>
    /// <returns>
    /// The YARP builder. Use it to add what the host needs, such as service discovery or routes from a plain
    /// YARP configuration section.
    /// </returns>
    public static IReverseProxyBuilder AddCatApiGateway(this IServiceCollection services, IConfiguration configuration)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));
        if (configuration is null) throw new ArgumentNullException(nameof(configuration));

        var section = configuration.GetSection(CatGatewayOptions.SectionName);
        var startup = section.Get<CatGatewayOptions>() ?? new CatGatewayOptions();

        AddAuthentication(services, startup);
        AddRateLimiting(services, startup.RateLimit);
        AddCors(services, startup.Cors);

        services.TryAddSingleton(sp => new CatGatewaySigningKeys(
            startup.Assertion,
            sp.GetRequiredService<IHostEnvironment>(),
            sp.GetRequiredService<ILogger<CatGatewaySigningKeys>>()));
        services.TryAddSingleton(sp => new CatGatewayConfigurationProvider(
            section,
            sp.GetRequiredService<CatGatewaySigningKeys>().HasKey,
            sp.GetRequiredService<ILogger<CatGatewayConfigurationProvider>>()));
        services.AddSingleton<IProxyConfigProvider>(sp => sp.GetRequiredService<CatGatewayConfigurationProvider>());
        services.AddSingleton<ITransformProvider, CatGatewayTransformProvider>();

        return services.AddReverseProxy();
    }

    /// <summary>
    /// Adds the middleware of the gateway: the correlation id, the request log, the request limits, the rate limit,
    /// CORS, authentication and authorization, in that order.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <returns>The same application builder.</returns>
    /// <remarks>
    /// Call it after <c>UseRouting</c> when you use an application builder that does not add routing itself. A
    /// <c>WebApplication</c> does.
    /// </remarks>
    public static IApplicationBuilder UseCatApiGateway(this IApplicationBuilder app)
    {
        if (app is null) throw new ArgumentNullException(nameof(app));

        var startup = app.ApplicationServices.GetRequiredService<CatGatewayConfigurationProvider>().Options;

        app.UseMiddleware<CorrelationIdMiddleware>();
        app.UseMiddleware<RequestLoggingMiddleware>();
        app.UseMiddleware<RequestLimitsMiddleware>();
        if (startup.RateLimit.Enabled) app.UseRateLimiter();
        if (startup.Cors.AllowedOrigins.Length > 0) app.UseCors(CorsPolicyName);
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }

    /// <summary>
    /// Maps the reverse proxy, and the endpoint that publishes the public keys of the gateway assertion when the
    /// gateway has a signing key.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder.</param>
    /// <returns>The convention builder of the reverse proxy.</returns>
    public static ReverseProxyConventionBuilder MapCatApiGateway(this IEndpointRouteBuilder endpoints)
    {
        if (endpoints is null) throw new ArgumentNullException(nameof(endpoints));

        var signingKeys = endpoints.ServiceProvider.GetRequiredService<CatGatewaySigningKeys>();
        if (signingKeys.HasKey)
        {
            var path = endpoints.ServiceProvider.GetRequiredService<CatGatewayConfigurationProvider>().Options.Assertion.JwksPath;
            endpoints.MapGet(path, (HttpContext context) =>
                {
                    context.Response.Headers.CacheControl = "public, max-age=300";
                    return Results.Content(signingKeys.GetJwks(), "application/json");
                })
                .AllowAnonymous()
                .ExcludeFromDescription();
        }

        return endpoints.MapReverseProxy();
    }

    private static void AddAuthentication(IServiceCollection services, CatGatewayOptions startup)
    {
        var authentication = startup.Authentication;
        var authorization = services.AddAuthorizationBuilder();

        if (string.IsNullOrWhiteSpace(authentication.Authority))
        {
            // Without an identity provider no token can be valid, so an endpoint that needs one stays closed.
            services.AddAuthentication();
            authorization.SetFallbackPolicy(new AuthorizationPolicyBuilder().RequireAssertion(_ => false).Build());
            return;
        }

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = authentication.Authority;
                options.Audience = authentication.Audience;
                options.RequireHttpsMetadata = authentication.RequireHttpsMetadata;
                options.MapInboundClaims = false;
            });

        authorization.SetFallbackPolicy(new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser()
            .Build());
    }

    private static void AddRateLimiting(IServiceCollection services, CatGatewayRateLimitOptions options)
    {
        if (!options.Enabled) return;

        services.AddRateLimiter(limiter =>
        {
            limiter.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            limiter.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
                RateLimitPartition.GetFixedWindowLimiter(
                    context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                    _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = options.PermitLimit,
                        Window = options.Window,
                        QueueLimit = 0,
                        AutoReplenishment = true
                    }));
        });
    }

    private static void AddCors(IServiceCollection services, CatGatewayCorsOptions options)
    {
        if (options.AllowedOrigins.Length == 0) return;

        services.AddCors(cors => cors.AddPolicy(CorsPolicyName, policy =>
        {
            if (options.AllowedOrigins is ["*"]) policy.AllowAnyOrigin();
            else policy.WithOrigins(options.AllowedOrigins);

            if (options.AllowedMethods.Length == 0) policy.AllowAnyMethod();
            else policy.WithMethods(options.AllowedMethods);

            if (options.AllowedHeaders.Length == 0) policy.AllowAnyHeader();
            else policy.WithHeaders(options.AllowedHeaders);

            if (options.AllowCredentials) policy.AllowCredentials();
        }));
    }
}
