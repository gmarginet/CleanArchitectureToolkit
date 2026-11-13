using System;
using System.Collections.Generic;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Users.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Cat.Demo.OrderService.Api.Extensions;

/// <summary>
/// A stand-in for the user of a token, for a plain <c>dotnet run</c> without Keycloak.
/// It picks one of three demo users with the <c>X-Demo-User</c> header and falls back to alice.
/// With Keycloak and the gateway in place, <c>Cat.Users</c> builds the <see cref="ICatUser"/> from the token instead.
/// </summary>
public class DevelopmentUser : ICatUser, IUserEmail
{
    public const string HeaderName = "X-Demo-User";

    private static readonly Dictionary<string, DemoUser> Users = new(StringComparer.OrdinalIgnoreCase)
    {
        ["alice"] = new("alice", "Alice Jansen", "alice@example.com", false),
        ["bob"] = new("bob", "Bob de Vries", "bob@example.com", false),
        ["admin"] = new("admin", "Admin", "admin@example.com", true)
    };

    private readonly DemoUser _user;

    public DevelopmentUser(IHttpContextAccessor httpContextAccessor)
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
    public bool IsInRole(string role) => _user.IsAdmin && role == "admin";

    private sealed record DemoUser(string UserId, string Name, string Email, bool IsAdmin);
}
