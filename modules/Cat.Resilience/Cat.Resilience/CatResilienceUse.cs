namespace Cat.Resilience;

/// <summary>
/// Notes that a client refers to a profile, so the startup check can fail on a name that does not exist.
/// </summary>
internal sealed class CatResilienceUse(string profileName)
{
    /// <summary>
    /// Gets the name of the profile that a client refers to.
    /// </summary>
    public string ProfileName { get; } = profileName;
}
