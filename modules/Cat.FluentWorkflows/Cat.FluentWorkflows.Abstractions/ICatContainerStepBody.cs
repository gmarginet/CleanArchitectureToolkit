namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Marks a step body that runs other steps, such as an if or a loop. Derive from <c>CatContainerStepBody</c> instead of implementing this yourself.
/// </summary>
public interface ICatContainerStepBody
{
    /// <summary>
    /// The saved frame of this step when the workflow is being resumed, otherwise <c>null</c>.
    /// The step processor sets it before the step runs.
    /// </summary>
    CatResumeInfo? Resume { get; set; }
}
