using Cat.Demo.OrderService.CoreService.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Cat.Demo.OrderService.Api.Extensions;

/// <summary>
/// The current user, read from the claims of the access token.
/// The gateway and this service both validate the token. This class only reads it.
/// </summary>
public class TokenCurrentUser(IHttpContextAccessor httpContextAccessor) : ICurrentUser
{
    private System.Security.Claims.ClaimsPrincipal? Principal => httpContextAccessor.HttpContext?.User;

    public bool IsAuthenticated => Principal?.Identity?.IsAuthenticated == true;
    public string UserId => Principal?.FindFirst("sub")?.Value ?? string.Empty;
    public string Name => Principal?.FindFirst("name")?.Value ?? Principal?.FindFirst("preferred_username")?.Value ?? string.Empty;
    public string Email => Principal?.FindFirst("email")?.Value ?? string.Empty;
    public bool IsAdmin => Principal?.IsInRole("admin") == true;
}
