using System;
using Cat.Resilience.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Cat.Resilience;

/// <summary>
/// Reads the profiles from configuration after the code has set them, so configuration wins over code.
/// </summary>
internal sealed class CatResilienceConfigurationSetup(IServiceProvider serviceProvider) : IPostConfigureOptions<CatResilienceOptions>
{
    /// <inheritdoc />
    public void PostConfigure(string? name, CatResilienceOptions options)
    {
        if (serviceProvider.GetService(typeof(IConfiguration)) is not IConfiguration configuration)
        {
            return;
        }

        foreach (var section in configuration.GetSection(CatResilienceOptions.ConfigurationSection).GetChildren())
        {
            options.AddProfile(section.Key, profile => section.Bind(profile));
        }
    }
}
