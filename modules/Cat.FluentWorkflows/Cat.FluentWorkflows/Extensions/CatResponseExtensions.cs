using Cat.FluentWorkflows.Abstractions;
using Cat.Responses.Abstractions;

namespace Cat.FluentWorkflows.Extensions;

/// <summary>
/// Turns a response of a command, a query or a service request into a workflow response.
/// </summary>
public static class CatResponseExtensions
{
    /// <summary>
    /// Turns a response into a workflow response. The errors of a failed response come along.
    /// </summary>
    /// <param name="source">The response to convert.</param>
    /// <param name="workflowResult">The result for the step processor. It is used whether the response succeeded or not.</param>
    /// <returns>The workflow response.</returns>
    public static ICatWorkflowResponse Cast(this ICatResponse source, CatStepExecutionResult workflowResult)
    {
        return source.IsSucceeded
            ? new CatWorkflowResponse(workflowResult)
            : new CatWorkflowResponse(workflowResult, source.ErrorList);
    }

    /// <summary>
    /// Turns a response with a payload into a workflow response. The payload is dropped and the errors of a failed response come along.
    /// </summary>
    /// <typeparam name="TSource">The type of the payload.</typeparam>
    /// <param name="source">The response to convert.</param>
    /// <param name="workflowResult">The result for the step processor. It is used whether the response succeeded or not.</param>
    /// <returns>The workflow response.</returns>
    public static ICatWorkflowResponse Cast<TSource>(this ICatResponse<TSource> source, CatStepExecutionResult workflowResult = CatStepExecutionResult.Continue)
    {
        return source.IsSucceeded
            ? new CatWorkflowResponse(workflowResult)
            : new CatWorkflowResponse(workflowResult, source.ErrorList);
    }
}