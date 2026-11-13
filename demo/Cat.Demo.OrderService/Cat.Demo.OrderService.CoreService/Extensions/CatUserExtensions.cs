using Cat.Users.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Extensions;

/// <summary>Demo rules on top of <see cref="ICatUser"/>.</summary>
public static class CatUserExtensions
{
    /// <summary>The role that may see and cancel the orders of every customer.</summary>
    public const string AdminRole = "admin";

    /// <summary>Tells whether the user may see and cancel the orders of every customer.</summary>
    public static bool IsAdmin(this ICatUser user) => user.IsInRole(AdminRole);
}
