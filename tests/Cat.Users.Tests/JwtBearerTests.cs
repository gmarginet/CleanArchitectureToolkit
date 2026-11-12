using Cat.Users.Extensions;
using Cat.Users.JwtBearer.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cat.Users.Tests;

[TestFixture]
public class JwtBearerTests
{
    private static string RoleClaimTypeOf(Action<IServiceCollection> configure)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddAuthentication().AddJwtBearer();
        configure(services);
        using var provider = services.BuildServiceProvider();
        return provider.GetRequiredService<IOptionsMonitor<JwtBearerOptions>>()
            .Get(JwtBearerDefaults.AuthenticationScheme).TokenValidationParameters.RoleClaimType;
    }

    [Test]
    public void UsesTheDefaultRoleClaimOfTheModule()
    {
        var roleClaimType = RoleClaimTypeOf(services =>
        {
            services.AddCatUsers();
            services.AddCatUsersJwtBearer();
        });

        Assert.That(roleClaimType, Is.EqualTo("roles"));
    }

    [Test]
    public void UsesTheConfiguredRoleClaimOfTheModule()
    {
        var roleClaimType = RoleClaimTypeOf(services =>
        {
            services.AddCatUsers(options => options.RoleClaimType = "groups");
            services.AddCatUsersJwtBearer();
        });

        Assert.That(roleClaimType, Is.EqualTo("groups"));
    }

    [Test]
    public void WinsOverARoleClaimSetInAddJwtBearer()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddAuthentication().AddJwtBearer(options => options.TokenValidationParameters.RoleClaimType = "other");
        services.AddCatUsers();
        services.AddCatUsersJwtBearer();
        using var provider = services.BuildServiceProvider();

        var roleClaimType = provider.GetRequiredService<IOptionsMonitor<JwtBearerOptions>>()
            .Get(JwtBearerDefaults.AuthenticationScheme).TokenValidationParameters.RoleClaimType;

        Assert.That(roleClaimType, Is.EqualTo("roles"));
    }
}
