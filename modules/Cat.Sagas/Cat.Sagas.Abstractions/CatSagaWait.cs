using System;

namespace Cat.Sagas.Abstractions;

/// <summary>
/// One open wait of an instance: a wait step that sent its request and has no answer yet.
/// An instance with a parallel step can have several.
/// </summary>
public class CatSagaWait
{
    /// <summary>
    /// The name of the wait step. A wait step needs a name that is unique in the whole workflow, because an answer and a timeout point at it.
    /// </summary>
    public string StepName { get; set; } = string.Empty;

    /// <summary>
    /// The id of this wait. A timeout carries it, so a timeout of an earlier wait never fires a later one.
    /// </summary>
    public Guid WaitId { get; set; }

    /// <summary>
    /// The assembly qualified name of the type of answer the step waits for. An answer finds its step by this type.
    /// </summary>
    public string AnswerType { get; set; } = string.Empty;

    /// <summary>
    /// The moment the wait times out, or null when it has no timeout.
    /// </summary>
    public DateTimeOffset? TimeoutAt { get; set; }
}
