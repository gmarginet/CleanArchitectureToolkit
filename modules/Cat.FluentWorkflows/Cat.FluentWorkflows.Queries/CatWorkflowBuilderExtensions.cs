using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Queries.Steps;
using Cat.Queries.Abstractions;

namespace Cat.FluentWorkflows.Queries;

/// <summary>
/// The query step for the workflow builder.
/// </summary>
public static class CatWorkflowBuilderExtensions
{
    /// <summary>
    /// Adds a step that processes a query.
    /// The query is created with its parameterless constructor. Fill it with <c>Input</c>, like <c>.Input(s =&gt; s.Id, step =&gt; step.Query.Id)</c>.
    /// Read the result with <c>Output</c>, like <c>.Output(step =&gt; step.Response!.Value, s =&gt; s.Todo)</c>.
    /// A failed query ends the workflow with BreakCascade and the errors of the query.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <typeparam name="TQuery">The query to process.</typeparam>
    /// <typeparam name="TResult">The type of the data the query returns.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <returns>A builder to connect the step to the state with <c>Input</c> and <c>Output</c>.</returns>
    public static ICatStepBuilder<TWorkflowState, CatProcessQueryStep<TQuery, TResult>> ProcessQuery<TWorkflowState, TQuery, TResult>(this ICatWorkflowBuilder<TWorkflowState> builder)
        where TQuery : class, ICatQuery<TResult>
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatProcessQueryStep<TQuery, TResult>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatProcessQueryStep<TQuery, TResult>>(workflowStep);

        builder.WorkflowSteps.Add(workflowStep);
        return stepBuilder;
    }
}