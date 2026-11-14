using System;

namespace Cat.Sagas.Abstractions;

/// <summary>
/// The saved record of one saga: the state of the workflow and the place where it waits.
/// A store keeps one record per instance.
/// </summary>
public class CatSagaInstance
{
    /// <summary>
    /// The id of the instance. It is also the correlation id of the messages of the saga, so an answer finds its instance with it.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the saga, as it was registered. It tells the dispatcher which workflow to resume.
    /// </summary>
    public string WorkflowType { get; set; } = string.Empty;

    /// <summary>
    /// The version of the workflow when the instance last suspended, see <c>ICatVersionedWorkflow</c>.
    /// </summary>
    public int WorkflowVersion { get; set; }

    /// <summary>
    /// Where the instance is in its life.
    /// </summary>
    public CatSagaStatus Status { get; set; }

    /// <summary>
    /// The workflow state as JSON.
    /// </summary>
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// The checkpoint of the workflow as JSON. It is empty when the instance is not waiting.
    /// </summary>
    public string? Checkpoint { get; set; }

    /// <summary>
    /// The open waits as JSON, a list of <see cref="CatSagaWait"/>. It is empty when the instance is not waiting.
    /// </summary>
    public string? Waits { get; set; }

    /// <summary>
    /// When the instance was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// When the instance was last saved.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }

    /// <summary>
    /// The number of the saved version. The store raises it on every update and refuses an update that holds an older number.
    /// </summary>
    public long Version { get; set; }
}
