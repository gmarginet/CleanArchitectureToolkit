using Cat.Commands.Abstractions;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Commands.Steps;

namespace Cat.FluentWorkflows.Commands;

/// <summary>
/// The command step for the workflow builder.
/// </summary>
public static class CatWorkflowBuilderExtensions
{
    /// <summary>
    /// Adds a step that processes a command.
    /// The command is created with its parameterless constructor. Fill it with <c>Input</c>, like <c>.Input(s =&gt; s.Name, step =&gt; step.Command.Name)</c>.
    /// A failed command ends the workflow with BreakCascade and the errors of the command.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <typeparam name="TCommand">The command to process.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <returns>A builder to connect the step to the state with <c>Input</c> and <c>Output</c>.</returns>
    public static ICatStepBuilder<TWorkflowState, CatProcessCommandStep<TCommand>> ProcessCommand<TWorkflowState, TCommand>(this ICatWorkflowBuilder<TWorkflowState> builder)
        where TCommand : class, ICatCommand
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatProcessCommandStep<TCommand>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatProcessCommandStep<TCommand>>(workflowStep);

        builder.WorkflowSteps.Add(workflowStep);
        return stepBuilder;
    }
}