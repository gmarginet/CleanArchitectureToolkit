namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// The saved position of a suspended workflow. It is a plain class, so you can serialize it with the serializer you like.
/// The engine never serializes it. Save it next to the workflow state, and give both to <c>ResumeAsync</c> later.
/// </summary>
public class CatWorkflowCheckpoint
{
    /// <summary>
    /// The version of the workflow when it suspended, see <see cref="ICatVersionedWorkflow"/>.
    /// A resume with a workflow of another version fails.
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// The position in the first list of steps. A container step holds the position inside itself in <see cref="CatCheckpointFrame.Child"/>.
    /// </summary>
    public CatCheckpointFrame Frame { get; set; } = new();
}
