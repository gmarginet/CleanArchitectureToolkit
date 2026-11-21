using System.Diagnostics;
using Cat.EventProcessor.Abstractions;

namespace Cat.EventProcessor;

/// <summary>
/// The trace source of the event processor.
/// </summary>
public static class CatEventProcessorTelemetry
{
    /// <summary>
    /// The name of the trace source. Add it to your OpenTelemetry setup to see the handling of a message
    /// as a span in the trace of the service that sent it.
    /// </summary>
    public const string SourceName = "Cat.EventProcessor";

    /// <summary>
    /// The property of a message that holds the W3C <c>traceparent</c> of the code that sent it.
    /// </summary>
    public const string DiagnosticIdProperty = "Diagnostic-Id";

    private static readonly ActivitySource ActivitySource = new ActivitySource(SourceName);

    /// <summary>
    /// Starts the activity of the handling of a message, with the activity of the sender as its parent.
    /// Returns null when nobody listens to the source, or when the current activity already belongs to the trace of the sender,
    /// for example because the SDK of the broker started it.
    /// </summary>
    internal static Activity? StartReceive(string messageTypeName, CatIncomingMessage message)
    {
        var parent = default(ActivityContext);
        var hasParent = message.Properties.TryGetValue(DiagnosticIdProperty, out var diagnosticId)
            && ActivityContext.TryParse(diagnosticId, null, out parent);

        if (hasParent && Activity.Current != null && Activity.Current.TraceId == parent.TraceId)
        {
            return null;
        }

        var name = "Cat.EventProcessor.Receive " + messageTypeName;
        var activity = hasParent
            ? ActivitySource.StartActivity(name, ActivityKind.Consumer, parent)
            : ActivitySource.StartActivity(name, ActivityKind.Consumer);
        activity?.SetTag("messaging.message.id", message.MessageId);
        return activity;
    }
}
