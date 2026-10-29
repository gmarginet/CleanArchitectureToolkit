using System.Diagnostics;

namespace Cat.FluentWorkflows.Telemetry;

/// <summary>
/// The activity source for tracing workflows. Add <see cref="ActivitySourceName"/> to your OpenTelemetry setup to collect the traces.
/// </summary>
public class CatWorkFlowActivitySource
{
    /// <summary>
    /// The name of the activity source.
    /// </summary>
    public const string ActivitySourceName = "Cat.FluentWorkFlows";

    /// <summary>
    /// The shared activity source.
    /// </summary>
    public static readonly ActivitySource Instance = new(ActivitySourceName);

    /// <summary>
    /// Starts an activity.
    /// </summary>
    /// <param name="name">The display name of the activity.</param>
    /// <returns>The activity, or <c>null</c> when nobody listens to the source.</returns>
    public static Activity? CreateActivity(string name)
    {
        return Instance.StartActivity(name);
    }
}