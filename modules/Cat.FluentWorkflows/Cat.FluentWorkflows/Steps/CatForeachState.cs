using Cat.FluentWorkflows.Abstractions;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// The default state for the steps inside a foreach. It holds the current item and the state of the workflow around the loop.
/// </summary>
/// <typeparam name="TCollection">The type of the items in the collection.</typeparam>
/// <typeparam name="TWorkflowState">The state of the workflow around the loop.</typeparam>
public class CatForeachState<TCollection, TWorkflowState> : ICatForeachState<TCollection, TWorkflowState>, ICatWorkflowState<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <inheritdoc />
    public TCollection CurrentItem { get; set; } = default!;

    /// <inheritdoc />
    public TWorkflowState ParentWorkflowState { get; set; } = null!;
}