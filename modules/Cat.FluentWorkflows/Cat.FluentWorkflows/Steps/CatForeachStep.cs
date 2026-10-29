using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Built-in step behind <c>Foreach</c>. It runs its inner steps once for every item of the collection,
/// on one shared foreach state. A BreakFromLoop or BreakCascade stops the loop. A BreakCascade also ends the workflow.
/// The errors of every item are kept.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow around the loop.</typeparam>
/// <typeparam name="TCollection">The type of the items.</typeparam>
/// <typeparam name="TForeachState">The state of the inner steps.</typeparam>
public class CatForeachStep<TWorkflowState, TCollection, TForeachState> : CatStepBodyAsync<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    where TForeachState : class, ICatForeachState<TCollection, TWorkflowState>, ICatWorkflowState<TForeachState>
{
    private readonly ILogger<CatForeachStep<TWorkflowState, TCollection, TForeachState>> _logger;
    private readonly ICatStepProcessor _catStepProcessor;

    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="catStepProcessor">Runs the inner steps.</param>
    /// <param name="logger">The logger the step can use.</param>
    public CatForeachStep(
        ICatStepProcessor catStepProcessor,
        ILogger<CatForeachStep<TWorkflowState, TCollection, TForeachState>> logger)
        : base(logger)
    {
        _catStepProcessor = catStepProcessor;
        _logger = logger;
    }

    /// <summary>
    /// Gets the collection from the workflow state.
    /// </summary>
    public Func<TWorkflowState, IEnumerable<TCollection>> Collection { get; set; } = null!;

    /// <summary>
    /// Holds the inner steps.
    /// </summary>
    public CatWorkflowBuilder<TForeachState> Builder { get; set; } = null!;

    /// <inheritdoc />
    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        var foreachState = CreateForeachState();
        foreachState.ParentWorkflowState = WorkflowState;

        var result = CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
        var errors = new List<ICatError>();
        foreach (var item in Collection(WorkflowState))
        {
            foreachState.CurrentItem = item;

            result = await _catStepProcessor.RunStepsAsync<TForeachState>(Builder, foreachState, cancellationToken);
            errors.AddRange(result.ErrorList);

            if (result.WorkflowResult == CatStepExecutionResult.ContinueLoop)
            {
                continue;
            }

            if (result.WorkflowResult == CatStepExecutionResult.BreakFromLoop || result.WorkflowResult == CatStepExecutionResult.BreakCascade)
            {
                break;
            }
        }

        var loopResult = result.WorkflowResult == CatStepExecutionResult.BreakCascade
            ? result.ChangeWorkflowResult(CatStepExecutionResult.BreakCascade)
            : result.ChangeWorkflowResult(CatStepExecutionResult.Continue);

        return CatWorkflowResponse.WithErrors(loopResult, errors);
    }

    /// <summary>
    /// Creates the state of the loop. When the state type is an interface, as in the simple foreach, the default state class is used.
    /// </summary>
    private static TForeachState CreateForeachState()
    {
        return typeof(TForeachState).IsInterface
            ? (TForeachState)(object)new CatForeachState<TCollection, TWorkflowState>()
            : (TForeachState)Activator.CreateInstance(typeof(TForeachState))!;
    }
}