using System.Collections.Generic;
using Cat.FluentWorkflows.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.FluentWorkflows;

/// <summary>
/// Default <see cref="ICatWorkflowResponse"/>. Create one with <see cref="Succeeded"/> or <see cref="Failed(CatStepExecutionResult, ICatError[])"/>.
/// </summary>
public class CatWorkflowResponse : ICatWorkflowResponse
{
    internal CatWorkflowResponse(CatStepExecutionResult workflowResult)
    {
        WorkflowResult = workflowResult;
        ErrorList = [];
    }
    
    internal CatWorkflowResponse(CatStepExecutionResult workflowResult, IReadOnlyList<ICatError> errorList)
    {
        WorkflowResult = workflowResult;
        ErrorList = errorList;
    }

    /// <inheritdoc />
    public CatStepExecutionResult WorkflowResult { get; private set; }

    /// <inheritdoc />
    public IReadOnlyList<ICatError> ErrorList { get; private set; }

    /// <inheritdoc />
    public ICatWorkflowResponse ChangeWorkflowResult(CatStepExecutionResult workflowResult)
    {
        WorkflowResult = workflowResult;
        return this;
    }

    /// <summary>
    /// Gives a response all the errors that were collected on the way.
    /// </summary>
    /// <param name="last">The response of the last step. Its result is kept.</param>
    /// <param name="allErrors">Every error collected, including the ones of <paramref name="last"/>.</param>
    /// <returns><paramref name="last"/> when it already holds all the errors, otherwise a response with all of them.</returns>
    internal static ICatWorkflowResponse WithErrors(ICatWorkflowResponse last, List<ICatError> allErrors)
    {
        return allErrors.Count == last.ErrorList.Count
            ? last
            : new CatWorkflowResponse(last.WorkflowResult, allErrors);
    }

    /// <summary>
    /// Creates a response for a step that worked.
    /// </summary>
    /// <param name="workflowResult">What the step processor does next.</param>
    /// <returns>The response, without errors.</returns>
    public static ICatWorkflowResponse Succeeded(CatStepExecutionResult workflowResult)
        => new CatWorkflowResponse(workflowResult);

    /// <summary>
    /// Creates a response for a step that failed.
    /// Use <see cref="CatStepExecutionResult.BreakCascade"/> as the result to end the workflow on the failure.
    /// With any other result the workflow goes on, and the errors are still part of the final response.
    /// </summary>
    /// <param name="workflowResult">What the step processor does next.</param>
    /// <param name="errorList">The errors.</param>
    /// <returns>The response, with the errors.</returns>
    public static ICatWorkflowResponse Failed(CatStepExecutionResult workflowResult, params ICatError[] errorList)
        => new CatWorkflowResponse(workflowResult, errorList);

    /// <summary>
    /// Creates a response for a step that failed.
    /// Use <see cref="CatStepExecutionResult.BreakCascade"/> as the result to end the workflow on the failure.
    /// With any other result the workflow goes on, and the errors are still part of the final response.
    /// </summary>
    /// <param name="workflowResult">What the step processor does next.</param>
    /// <param name="errorList">The errors.</param>
    /// <returns>The response, with the errors.</returns>
    public static ICatWorkflowResponse Failed(CatStepExecutionResult workflowResult, IReadOnlyList<ICatError> errorList)
        => new CatWorkflowResponse(workflowResult, errorList);
}