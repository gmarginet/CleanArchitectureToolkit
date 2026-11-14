using Cat.FluentWorkflows;
using Cat.FluentWorkflows.Abstractions;
using Cat.Messaging.Abstractions;
using Cat.Sagas.Steps;

namespace Cat.Sagas.Extensions;

/// <summary>
/// The wait step for the workflow builder.
/// </summary>
public static class CatWorkflowBuilderExtensions
{
    /// <summary>
    /// Adds a step that sends a request message and waits for the answer. The workflow stops here and its state is saved.
    /// When the answer arrives, the workflow goes on with the step after this one.
    /// The request is created with its parameterless constructor. Fill it with <c>Input</c>, like <c>.Input(s =&gt; s.OrderId, step =&gt; step.Request.OrderId)</c>.
    /// Read the answer with <c>Output</c>, like <c>.Output(step =&gt; step.Answer, s =&gt; s.Payment)</c>.
    /// The saga puts its instance id in the <c>CorrelationId</c> of the request. The other service must copy it into its answer.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <typeparam name="TRequest">The request message to send.</typeparam>
    /// <typeparam name="TAnswer">The answer to wait for.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="name">The name of the step. A step that waits needs a name that does not change, because the saved position points at it.</param>
    /// <returns>A builder to connect the step to the state with <c>Input</c> and <c>Output</c>.</returns>
    public static ICatStepBuilder<TWorkflowState, CatSendAndWaitStep<TRequest, TAnswer>> SendAndWait<TWorkflowState, TRequest, TAnswer>(
        this ICatWorkflowBuilder<TWorkflowState> builder, string name)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
        where TRequest : class, ICatMessage
        where TAnswer : class
    {
        var workflowStep = new CatWorkflowStep<CatSendAndWaitStep<TRequest, TAnswer>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatSendAndWaitStep<TRequest, TAnswer>>(workflowStep);

        builder.WorkflowSteps.Add(workflowStep);
        return stepBuilder.Named(name);
    }
}
