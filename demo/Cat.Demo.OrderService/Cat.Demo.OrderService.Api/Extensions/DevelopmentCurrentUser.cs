using System;
using System.Collections.Generic;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Cat.Demo.OrderService.Api.Extensions;

/// <summary>
/// A stand-in for the real current user, for <c>Development</c> only.
/// It picks one of three demo users with the <c>X-Demo-User</c> header and falls back to alice.
/// The real implementation reads the claims of the access token, once Keycloak and the gateway are in place.
/// </summary>
public class DevelopmentCurrentUser : ICurrentUser
{
    public const string HeaderName = "X-Demo-User";

    private static readonly Dictionary<string, DemoUser> Users = new(StringComparer.OrdinalIgnoreCase)
    {
        ["alice"] = new("alice", "Alice Jansen", "alice@example.com", false),
        ["bob"] = new("bob", "Bob de Vries", "bob@example.com", false),
        ["admin"] = new("admin", "Admin", "admin@example.com", true)
    };

    private readonly DemoUser _user;

    public DevelopmentCurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        var requested = httpContextAccessor.HttpContext?.Request.Headers[HeaderName].ToString();
        _user = requested is { Length: > 0 } && Users.TryGetValue(requested, out var user)
            ? user
            : Users["alice"];
    }

    public bool IsAuthenticated => true;
    public string UserId => _user.UserId;
    public string Name => _user.Name;
    public string Email => _user.Email;
    public bool IsAdmin => _user.IsAdmin;

    private sealed record DemoUser(string UserId, string Name, string Email, bool IsAdmin);
}
