using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.ServiceDefaults;

/// <summary>
/// Token validation for the demo services. Each service checks the token again, because the gateway forwards it unchanged.
/// </summary>
public static class AuthenticationExtensions
{
    /// <summary>The policy for the users who may manage the catalog.</summary>
    public const string AdminPolicy = "admin";

    /// <summary>
    /// Adds JWT bearer authentication when <c>Authentication:Authority</c> is set. The AppHost sets it.
    /// Without an authority a plain <c>dotnet run</c> keeps working, with no login.
    /// </summary>
    /// <returns>True when authentication is on.</returns>
    public static bool AddDemoJwtAuthentication(this WebApplicationBuilder builder)
    {
        var authority = builder.Configuration["Authentication:Authority"];
        if (string.IsNullOrWhiteSpace(authority))
        {
            return false;
        }

        var audience = builder.Configuration["Authentication:Audience"] ?? "cat-gateway";

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = authority;
                options.Audience = audience;
                options.RequireHttpsMetadata = false;
                options.MapInboundClaims = false;
                options.TokenValidationParameters.NameClaimType = "preferred_username";
                options.TokenValidationParameters.RoleClaimType = "roles";
            });

        builder.Services.AddAuthorizationBuilder()
            .AddPolicy(AdminPolicy, policy => policy.RequireRole("admin"));

        return true;
    }
}
