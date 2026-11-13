namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// The saved state of one branch of a parallel step.
/// </summary>
public class CatParallelBranchFrame
{
    /// <summary>
    /// What happened to the branch.
    /// </summary>
    public CatParallelBranchStatus Status { get; set; }

    /// <summary>
    /// The position inside the branch. It is set only while the branch is <see cref="CatParallelBranchStatus.Suspended"/>.
    /// </summary>
    public CatCheckpointFrame? Frame { get; set; }
}
