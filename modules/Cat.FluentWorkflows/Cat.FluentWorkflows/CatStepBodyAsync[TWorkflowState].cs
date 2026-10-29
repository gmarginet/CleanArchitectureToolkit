using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows;

/// <summary>
/// Base class for a step that works asynchronously and reads or writes the workflow state directly.
/// Implement <see cref="CatStepBodyAsync.RunAsync"/> and use <see cref="WorkflowState"/>.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public abstract class CatStepBodyAsync<TWorkflowState> : CatStepBodyAsync, ICatStepBodyWithState<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="logger">The logger the step can use.</param>
    protected CatStepBodyAsync(ILogger logger) : base(logger)
    {
    }

    /// <inheritdoc />
    public TWorkflowState WorkflowState { get; set; } = null!;
}