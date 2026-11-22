namespace Cat.Messaging.Abstractions;

/// <summary>
/// The names of the properties that the toolkit puts on a message.
/// </summary>
public static class CatMessageProperties
{
    /// <summary>
    /// The property with the token of the sender. The value is <c>Bearer</c>, a space and the token, as in HTTP.
    /// </summary>
    public const string Authorization = "Authorization";

    /// <summary>
    /// The property with the culture of the sender, as a culture name such as <c>nl-BE</c>.
    /// The sender takes it from <c>CultureInfo.CurrentUICulture</c>. A message without it comes from a sender on the invariant culture.
    /// </summary>
    public const string Culture = "Culture";
}
