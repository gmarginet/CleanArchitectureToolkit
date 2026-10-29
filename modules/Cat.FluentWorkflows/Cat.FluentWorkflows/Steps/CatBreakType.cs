namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// The kinds of break a break step can make.
/// </summary>
public enum CatBreakType
{
    /// <summary>
    /// Ends the workflow and every workflow around it.
    /// </summary>
    BreakCascade,

    /// <summary>
    /// Ends the current workflow only.
    /// </summary>
    BreakFromCurrentFlowOnly,

    /// <summary>
    /// Leaves the nearest loop.
    /// </summary>
    BreakFromLoop
}