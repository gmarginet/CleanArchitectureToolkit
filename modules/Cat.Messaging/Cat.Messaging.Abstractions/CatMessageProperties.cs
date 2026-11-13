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
}
