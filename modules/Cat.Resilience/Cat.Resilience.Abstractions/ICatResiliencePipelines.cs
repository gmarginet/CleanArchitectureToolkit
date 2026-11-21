namespace Cat.Resilience.Abstractions;

/// <summary>
/// Gives the pipeline of a named resilience profile, for a call that is not HTTP.
/// </summary>
public interface ICatResiliencePipelines
{
    /// <summary>
    /// Gets the pipeline of a profile. Every call with the same name returns the same pipeline, with the same circuit breaker state.
    /// </summary>
    /// <param name="profileName">The name of the profile, such as <see cref="CatResilienceProfile.External"/>.</param>
    /// <returns>The pipeline.</returns>
    /// <exception cref="System.InvalidOperationException">No profile has that name.</exception>
    ICatResiliencePipeline Get(string profileName);
}
