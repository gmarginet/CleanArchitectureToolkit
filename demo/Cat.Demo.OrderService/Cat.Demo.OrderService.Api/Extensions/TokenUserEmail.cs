using Cat.Demo.OrderService.CoreService.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Cat.Demo.OrderService.Api.Extensions;

/// <summary>
/// The email address of the user, read from the <c>email</c> claim of the access token.
/// The rest of the user comes from <c>Cat.Users</c>.
/// </summary>
public class TokenUserEmail(IHttpContextAccessor httpContextAccessor) : IUserEmail
{
    public string Email => httpContextAccessor.HttpContext?.User.FindFirst("email")?.Value ?? string.Empty;
}
