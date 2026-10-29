namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Tells the step processor what to do after a step. Every step returns one inside its workflow response.
/// </summary>
public enum CatStepExecutionResult
{
    /// <summary>
    /// Go on with the next step.
    /// </summary>
    Continue,

    /// <summary>
    /// Stop the current list of steps and tell every level above to stop too.
    /// The workflow ends and returns this result. Use it to end a workflow on a failure.
    /// </summary>
    BreakCascade,

    /// <summary>
    /// Stop the current list of steps. In a workflow it ends that workflow, and its caller goes on as if it succeeded.
    /// In a foreach it ends the current item only.
    /// </summary>
    BreakFromCurrentFlowOnly,

    /// <summary>
    /// Leave the nearest loop, a while or a foreach, and go on with the step after it.
    /// </summary>
    BreakFromLoop,

    /// <summary>
    /// Reserved for loops. The step processor does not stop on it, and no built-in step returns it.
    /// </summary>
    ContinueLoop
}