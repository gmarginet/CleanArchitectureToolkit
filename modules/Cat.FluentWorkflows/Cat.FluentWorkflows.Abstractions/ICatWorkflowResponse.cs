using System.Collections.Generic;
using Cat.Responses.Abstractions;

namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// The outcome of a step or a workflow: what to do next, and the errors if something failed.
/// </summary>
public interface ICatWorkflowResponse
{
    /// <summary>
    /// What the step processor does next.
    /// </summary>
    CatStepExecutionResult WorkflowResult { get; }

    /// <summary>
    /// The errors. The list is empty when nothing failed.
    /// </summary>
    IReadOnlyList<ICatError> ErrorList { get; }

    /// <summary>
    /// Changes the result and keeps the errors.
    /// </summary>
    /// <param name="workflowResult">The new result.</param>
    /// <returns>The same response.</returns>
    ICatWorkflowResponse ChangeWorkflowResult(CatStepExecutionResult workflowResult);
}