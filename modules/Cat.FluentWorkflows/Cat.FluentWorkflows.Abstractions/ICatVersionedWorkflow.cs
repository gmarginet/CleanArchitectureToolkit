namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Implement this on a workflow that can suspend, to give it a version. A workflow without it has version 0.
/// Raise the version when you add, remove or reorder steps. A resume of a checkpoint with another version fails.
/// </summary>
public interface ICatVersionedWorkflow
{
    /// <summary>
    /// The version of the workflow.
    /// </summary>
    int Version { get; }
}
