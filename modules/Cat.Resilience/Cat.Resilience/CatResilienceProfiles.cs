using System;
using Cat.Resilience.Abstractions;
using Microsoft.Extensions.Options;

namespace Cat.Resilience;

/// <summary>
/// Looks up the settings of a profile by name.
/// </summary>
internal sealed class CatResilienceProfiles(IOptions<CatResilienceOptions> options)
{
    /// <summary>
    /// Gets the settings of a profile.
    /// </summary>
    /// <exception cref="InvalidOperationException">No profile has that name.</exception>
    public CatResilienceProfileOptions Get(string name)
    {
        if (options.Value.Profiles.TryGetValue(name, out var profile))
        {
            return profile;
        }

        throw new InvalidOperationException(
            $"The resilience profile '{name}' does not exist. Add it in configuration under '{CatResilienceOptions.ConfigurationSection}:{name}' " +
            "or in code with AddCatResilienceModule(options => options.AddProfile(...)).");
    }

    /// <summary>
    /// Tells whether a profile with this name exists.
    /// </summary>
    public bool Exists(string name) => options.Value.Profiles.ContainsKey(name);
}
