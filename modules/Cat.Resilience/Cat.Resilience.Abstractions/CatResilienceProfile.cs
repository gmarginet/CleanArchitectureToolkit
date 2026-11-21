namespace Cat.Resilience.Abstractions;

/// <summary>
/// The names of the two profiles that every service has.
/// A developer adds more profiles by name, in configuration or in code.
/// </summary>
public static class CatResilienceProfile
{
    /// <summary>
    /// The profile for calls to our own services.
    /// Its defaults match the standard resilience handler of Microsoft.
    /// </summary>
    public const string Internal = "Internal";

    /// <summary>
    /// The profile for calls to an outside provider.
    /// It retries an unsafe method only when the request carries an idempotency key, and it follows the <c>Retry-After</c> header.
    /// </summary>
    public const string External = "External";
}
