using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cat.Users.JwtBearer.Extensions;

/// <summary>
/// Registration helpers for the JWT bearer part of the users module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Sets the role claim type of the token validation to <see cref="CatUsersOptions.RoleClaimType"/>.
    /// A role policy such as <c>RequireRole</c> and <see cref="Abstractions.ICatUser.IsInRole(string)"/> then read the same claim.
    /// The setting runs after the other settings of the scheme, so it wins over a role claim type set in <c>AddJwtBearer</c>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="authenticationScheme">The name of the JWT bearer scheme. The default is <c>Bearer</c>.</param>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddCatUsersJwtBearer(this IServiceCollection services,
        string authenticationScheme = JwtBearerDefaults.AuthenticationScheme)
    {
        services.AddOptions<JwtBearerOptions>(authenticationScheme)
            .PostConfigure<IOptions<CatUsersOptions>>((jwtOptions, users) =>
                jwtOptions.TokenValidationParameters.RoleClaimType = users.Value.RoleClaimType);
        return services;
    }
}
