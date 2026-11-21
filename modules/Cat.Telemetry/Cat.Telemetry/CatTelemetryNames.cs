using System.Collections.Generic;

namespace Cat.Telemetry;

/// <summary>
/// The names of the activity sources and the meters of the CAT modules.
/// The name of a module is also the name of its source and its meter.
/// A module does not depend on <c>Cat.Telemetry</c>, so these constants repeat what the modules publish.
/// </summary>
public static class CatTelemetryNames
{
    /// <summary>The source of the workflow processor of <c>Cat.FluentWorkflows</c>.</summary>
    public const string FluentWorkflows = "Cat.FluentWorkflows";

    /// <summary>The meter of <c>Cat.Messaging</c>, with the number of dead letter messages.</summary>
    public const string Messaging = "Cat.Messaging";

    /// <summary>The source and the meter of <c>Cat.Scheduling</c>.</summary>
    public const string Scheduling = "Cat.Scheduling";

    /// <summary>The source and the meter of the service request decorator of <c>Cat.ServiceRequests</c>.</summary>
    public const string ServiceRequests = "Cat.ServiceRequests";

    /// <summary>The meter of <c>Cat.Sql.Cdc</c>.</summary>
    public const string SqlCdc = "Cat.Sql.Cdc";

    /// <summary>
    /// The meter of Polly, which <c>Cat.Resilience</c> uses. Its name is outside the naming scheme of the CAT modules,
    /// because the module has no meter of its own.
    /// </summary>
    public const string Polly = "Polly";

    /// <summary>
    /// The tag of a span or a log scope that holds the correlation id of a request or a message.
    /// </summary>
    public const string CorrelationIdTag = "cat.correlation_id";

    /// <summary>
    /// Every source and meter above that belongs to a CAT module. <c>AddCatTelemetry</c> adds them to the traces and to the metrics.
    /// A name that a module does not use for one of the two is harmless there.
    /// </summary>
    public static IReadOnlyList<string> Modules { get; } = new[]
    {
        FluentWorkflows, Messaging, Scheduling, ServiceRequests, SqlCdc
    };
}
