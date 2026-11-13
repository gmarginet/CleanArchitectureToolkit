using System.Threading;
using Cat.Users.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Cat.Users;

/// <summary>
/// Holds the user of the current scope.
/// A user that was set wins, also in a scope that is created further down the same async call chain. Without one, an authenticated HTTP request gives a user built from its claims, and everything else is anonymous.
/// </summary>
public class CatUserAccessor : ICatUserAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly CatUsersOptions _options;
    // Flows with the async call chain, so a scope that is created further down (such as the one of the
    // service request processor) sees the user that was set above it.
    private static readonly AsyncLocal<ICatUser?> Flowing = new AsyncLocal<ICatUser?>();
    private ICatUser? _user;

    /// <summary>
    /// Creates the accessor.
    /// </summary>
    /// <param name="httpContextAccessor">Gives the HTTP request of the scope, when there is one.</param>
    /// <param name="options">The names of the claims.</param>
    public CatUserAccessor(IHttpContextAccessor httpContextAccessor, IOptions<CatUsersOptions> options)
    {
        _httpContextAccessor = httpContextAccessor;
        _options = options.Value;
    }

    /// <inheritdoc />
    public ICatUser User
    {
        get
        {
            var set = _user ?? Flowing.Value;
            if (set != null)
            {
                return set;
            }

            var principal = _httpContextAccessor.HttpContext?.User;
            return principal?.Identity?.IsAuthenticated == true
                ? new CatClaimsUser(principal, _options)
                : CatUser.Anonymous;
        }
        set
        {
            _user = value;
            Flowing.Value = value;
        }
    }
}
