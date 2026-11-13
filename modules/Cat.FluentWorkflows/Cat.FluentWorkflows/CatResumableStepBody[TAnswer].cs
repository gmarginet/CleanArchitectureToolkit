using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows;

/// <summary>
/// Base class for a step that waits for an answer. Implement <see cref="CatStepBodyAsync.RunAsync"/> to start the work and return
/// <see cref="CatWorkflowResponse.Suspended()"/>. Implement <see cref="ResumeAsync(TAnswer, CancellationToken)"/> to finish the step with the answer.
/// Give the step a name with <c>Named</c> when you add it, so a checkpoint and a resume can point at it.
/// </summary>
/// <typeparam name="TAnswer">The type of the answer. A resume with an answer of another type fails.</typeparam>
public abstract class CatResumableStepBody<TAnswer> : CatStepBodyAsync, ICatResumableStepBody
{
    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="logger">The logger the step can use.</param>
    protected CatResumableStepBody(ILogger logger) : base(logger)
    {
    }

    /// <summary>
    /// Finishes the step with the answer. The outputs of the step are copied into the state after it returns.
    /// </summary>
    /// <param name="answer">The answer that was given to <c>ResumeAsync</c> of the workflow processor.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A response with the result for the step processor. It can suspend again.</returns>
    protected abstract Task<ICatWorkflowResponse> ResumeAsync(TAnswer answer, CancellationToken cancellationToken);

    /// <inheritdoc />
    /// <exception cref="CatWorkflowResumeException">The answer is not a <typeparamref name="TAnswer"/>.</exception>
    Task<ICatWorkflowResponse> ICatResumableStepBody.ResumeAsync(object? answer, CancellationToken cancellationToken)
    {
        if (answer is TAnswer typed)
        {
            return ResumeAsync(typed, cancellationToken);
        }

        if (answer == null && default(TAnswer) == null)
        {
            return ResumeAsync(default!, cancellationToken);
        }

        throw new CatWorkflowResumeException(
            $"The step {GetType().Name} expects an answer of type {typeof(TAnswer).Name}, but got {answer?.GetType().Name ?? "null"}.");
    }
}
