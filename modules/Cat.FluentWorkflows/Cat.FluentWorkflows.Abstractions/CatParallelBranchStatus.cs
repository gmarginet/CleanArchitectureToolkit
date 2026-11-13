namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// What happened to a branch of a parallel step.
/// </summary>
public enum CatParallelBranchStatus
{
    /// <summary>
    /// The branch did not start yet. This happens with <see cref="CatParallelRule.FailFast"/> after an earlier branch suspended.
    /// </summary>
    NotStarted,

    /// <summary>
    /// The branch waits for an answer.
    /// </summary>
    Suspended,

    /// <summary>
    /// The branch finished.
    /// </summary>
    Done,

    /// <summary>
    /// The branch ended with a <see cref="CatStepExecutionResult.BreakCascade"/>.
    /// </summary>
    Failed
}
