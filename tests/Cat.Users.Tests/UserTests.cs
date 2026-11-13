using System.Security.Claims;
using Cat.Users.Abstractions;
using Cat.Users.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Users.Tests;

[TestFixture]
public class UserTests
{
    private static ClaimsPrincipal PrincipalOf(params Claim[] claims) =>
        new(new ClaimsIdentity(claims, "test"));

    [Test]
    public void Anonymous_IsNotAuthenticatedAndHasNoRoles()
    {
        var user = CatUser.Anonymous;

        Assert.That(user.IsAuthenticated, Is.False);
        Assert.That(user.UserId, Is.Empty);
        Assert.That(user.IsInRole(CatUser.SystemRole), Is.False);
    }

    [Test]
    public void System_IsAuthenticatedWithTheSystemRole()
    {
        var user = CatUser.System("orders");

        Assert.That(user.IsAuthenticated, Is.True);
        Assert.That(user.UserId, Is.EqualTo("orders"));
        Assert.That(user.IsInRole(CatUser.SystemRole), Is.True);
        Assert.That(user.IsInRole("admin"), Is.False);
    }

    [Test]
    public void ClaimsUser_ReadsIdNameAndRolesFromTheClaims()
    {
        var principal = PrincipalOf(new Claim("sub", "u-1"), new Claim("name", "Alice"), new Claim("roles", "admin"), new Claim("roles", "buyer"));

        var user = new CatClaimsUser(principal, new CatUsersOptions());

        Assert.That(user.IsAuthenticated, Is.True);
        Assert.That(user.UserId, Is.EqualTo("u-1"));
        Assert.That(user.Name, Is.EqualTo("Alice"));
        Assert.That(user.IsInRole("admin"), Is.True);
        Assert.That(user.IsInRole("buyer"), Is.True);
        Assert.That(user.IsInRole("Admin"), Is.False);
    }

    [Test]
    public void ClaimsUser_FallsBackToThePreferredUsernameForTheName()
    {
        var user = new CatClaimsUser(PrincipalOf(new Claim("preferred_username", "alice")), new CatUsersOptions());

        Assert.That(user.Name, Is.EqualTo("alice"));
    }

    [Test]
    public void ClaimsUser_UsesTheConfiguredRoleClaim()
    {
        var principal = PrincipalOf(new Claim("groups", "admin"));

        var user = new CatClaimsUser(principal, new CatUsersOptions { RoleClaimType = "groups" });

        Assert.That(user.IsInRole("admin"), Is.True);
    }

    [Test]
    public void ClaimsUser_IsNotAuthenticatedWithoutAnIdentityType()
    {
        var user = new CatClaimsUser(new ClaimsPrincipal(new ClaimsIdentity()), new CatUsersOptions());

        Assert.That(user.IsAuthenticated, Is.False);
    }

    [Test]
    public void Accessor_GivesTheUserOfTheHttpRequest()
    {
        using var provider = Build(PrincipalOf(new Claim("sub", "u-1"), new Claim("roles", "admin")));
        using var scope = provider.CreateScope();

        var user = scope.ServiceProvider.GetRequiredService<ICatUser>();

        Assert.That(user.UserId, Is.EqualTo("u-1"));
        Assert.That(user.IsInRole("admin"), Is.True);
    }

    [Test]
    public void Accessor_GivesTheAnonymousUserWithoutARequest()
    {
        using var provider = Build(null);
        using var scope = provider.CreateScope();

        var user = scope.ServiceProvider.GetRequiredService<ICatUser>();

        Assert.That(user.IsAuthenticated, Is.False);
    }

    [Test]
    public void Accessor_GivesTheUserThatAWorkerSet()
    {
        using var provider = Build(null);
        using var scope = provider.CreateScope();

        scope.ServiceProvider.GetRequiredService<ICatUserAccessor>().User = CatUser.System("orders");

        Assert.That(scope.ServiceProvider.GetRequiredService<ICatUser>().IsInRole(CatUser.SystemRole), Is.True);
    }

    [Test]
    public async Task Accessor_KeepsTheUsersOfTwoAsyncFlowsApart()
    {
        using var provider = Build(null);

        await Task.Run(() =>
        {
            using var first = provider.CreateScope();
            first.ServiceProvider.GetRequiredService<ICatUserAccessor>().User = CatUser.System("orders");
        });

        using var second = provider.CreateScope();
        Assert.That(second.ServiceProvider.GetRequiredService<ICatUser>().IsAuthenticated, Is.False);
    }

    [Test]
    public void Accessor_AScopeCreatedBelowTheSetterSeesTheUser()
    {
        using var provider = Build(null);
        using var outer = provider.CreateScope();
        outer.ServiceProvider.GetRequiredService<ICatUserAccessor>().User = CatUser.System("orders");

        using var inner = provider.CreateScope();

        Assert.That(inner.ServiceProvider.GetRequiredService<ICatUser>().UserId, Is.EqualTo("orders"));
    }

    private static ServiceProvider Build(ClaimsPrincipal? principal)
    {
        var services = new ServiceCollection();
        services.AddCatUsers();
        if (principal != null)
        {
            services.AddSingleton<IHttpContextAccessor>(new HttpContextAccessor { HttpContext = new DefaultHttpContext { User = principal } });
        }

        return services.BuildServiceProvider();
    }
}
