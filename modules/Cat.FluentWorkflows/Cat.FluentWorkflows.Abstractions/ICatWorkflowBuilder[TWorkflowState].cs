using System.Collections.Generic;

namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Collects the steps of a workflow. You get one in <see cref="ICatWorkflow{TWorkflowState}.Build"/>.
/// The steps themselves are extension methods in <c>Cat.FluentWorkflows.Extensions</c>.
/// Each one adds a step to <see cref="WorkflowSteps"/>, and the steps run in the order they were added.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public interface ICatWorkflowBuilder<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// The steps added so far.
    /// </summary>
    List<ICatWorkflowStep> WorkflowSteps { get; }
}
