namespace Cat.Demo.OrderService.CoreService.Abstractions;

/// <summary>
/// The user who makes the current call. The business logic only knows this interface, never the HTTP context.
/// The Api project implements it.
/// </summary>
public interface ICurrentUser
{
    /// <summary>True when the call comes from a known user.</summary>
    bool IsAuthenticated { get; }

    /// <summary>The <c>sub</c> claim of the user. Empty when the user is not authenticated.</summary>
    string UserId { get; }

    string Name { get; }
    string Email { get; }

    /// <summary>True when the user may see and cancel the orders of every customer.</summary>
    bool IsAdmin { get; }
}
