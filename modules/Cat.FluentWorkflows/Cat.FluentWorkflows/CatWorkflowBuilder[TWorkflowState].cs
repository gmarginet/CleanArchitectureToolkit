using System.Collections.Generic;
using Cat.FluentWorkflows.Abstractions;

namespace Cat.FluentWorkflows;

/// <summary>
/// Default <see cref="ICatWorkflowBuilder{TWorkflowState}"/>.
/// It only holds the steps. The extension methods in <c>Cat.FluentWorkflows.Extensions</c> add them.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public class CatWorkflowBuilder<TWorkflowState> : ICatWorkflowBuilder<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <inheritdoc />
    public List<ICatWorkflowStep> WorkflowSteps { get; } = [];
}
