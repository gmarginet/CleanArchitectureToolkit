namespace Cat.Demo.OrderService.CoreService.Abstractions;

/// <summary>
/// The email address of the user who makes the current call.
/// <c>ICatUser</c> has no email, so the demo asks for it here. The Api project fills it from the token.
/// </summary>
public interface IUserEmail
{
    /// <summary>The <c>email</c> claim of the user. Empty when the user has none.</summary>
    string Email { get; }
}
