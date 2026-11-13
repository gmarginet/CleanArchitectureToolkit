namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Says what a parallel step does when a branch fails or suspends.
/// The branches run one after another in the order they were added. Only the waiting is parallel.
/// </summary>
public enum CatParallelRule
{
    /// <summary>
    /// The first branch that fails or suspends stops the parallel step at once. Later branches do not start.
    /// A failure ends the workflow. A suspend suspends the workflow, and a resume goes on with the later branches.
    /// This is the default.
    /// </summary>
    FailFast,

    /// <summary>
    /// Every branch runs, also after a failure. A suspended branch does not stop the others from running.
    /// The step ends when no branch waits any more. It ends the workflow if a branch failed.
    /// </summary>
    WaitForAll,

    /// <summary>
    /// Every branch runs, and a suspended branch does not stop the others from running.
    /// The first failure stops the parallel step at once and ends the workflow, even when other branches still wait.
    /// Without a failure the step waits until all branches are done.
    /// </summary>
    SuspendUntilAllDone
}
