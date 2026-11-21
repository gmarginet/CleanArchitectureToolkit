using System.Collections.Generic;

namespace Cat.Telemetry;

/// <summary>
/// The settings of <c>AddCatTelemetry</c>. They come from the configuration section <see cref="SectionName"/>,
/// and the callback of the call can change them.
/// </summary>
public class CatTelemetryOptions
{
    /// <summary>
    /// The configuration section: <c>Cat:Telemetry</c>.
    /// </summary>
    public const string SectionName = "Cat:Telemetry";

    /// <summary>
    /// The paths whose requests are left out of the traces, such as the health endpoints.
    /// A path matches itself and everything below it. When it is <c>null</c>, which is the default, the paths are
    /// <see cref="DefaultIgnoredPaths"/>. A list in the configuration or in the callback replaces them, and an empty list ignores nothing.
    /// </summary>
    public string[]? IgnoredPaths { get; set; }

    /// <summary>
    /// The name of the service in the traces. When empty, the name of the application is used.
    /// </summary>
    public string? ServiceName { get; set; }

    /// <summary>
    /// The paths that are ignored when <see cref="IgnoredPaths"/> is not set: <c>/health</c> and <c>/alive</c>.
    /// </summary>
    public static IReadOnlyList<string> DefaultIgnoredPaths { get; } = new[] { "/health", "/alive" };

    internal IReadOnlyList<string> EffectiveIgnoredPaths() => IgnoredPaths ?? DefaultIgnoredPaths;
}
