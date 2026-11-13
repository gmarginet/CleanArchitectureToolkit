using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Built-in step behind <c>Switch</c>. It runs the steps of the case that matches the value.
/// With no match it runs the default case. With no default case either it does nothing and continues.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
/// <typeparam name="TSwitchValue">The type of the value being switched on.</typeparam>
public class CatSwitchStep<TWorkflowState, TSwitchValue> : CatContainerStepBody<TWorkflowState>
    where TSwitchValue : struct
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    private readonly ICatStepProcessor _catStepProcessor;

    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="catStepProcessor">Runs the steps of a case.</param>
    /// <param name="logger">The logger the step can use.</param>
    public CatSwitchStep(
        ICatStepProcessor catStepProcessor,
        ILogger<CatSwitchStep<TWorkflowState, TSwitchValue>> logger)
        : base(logger)
    {
        _catStepProcessor = catStepProcessor;
    }

    /// <summary>
    /// Gets the value to switch on from the workflow state.
    /// </summary>
    public Func<TWorkflowState, TSwitchValue> SwitchValue { get; internal set; } = null!;

    /// <summary>
    /// Holds the steps to run when no case matches, or <c>null</c> for none.
    /// </summary>
    public CatWorkflowBuilder<TWorkflowState>? DefaultCaseBuilder { get; internal set; } = null!;

    /// <summary>
    /// Holds the steps of each case, by the value it matches.
    /// </summary>
    public Dictionary<TSwitchValue, CatWorkflowBuilder<TWorkflowState>> CaseBuilders { get; internal set; } = new();

    /// <inheritdoc />
    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        var resuming = SavedFrame != null;
        CatWorkflowBuilder<TWorkflowState>? builder;
        string branch;
        string? caseValue = null;

        if (resuming)
        {
            branch = SavedFrame!.Branch ?? string.Empty;
            caseValue = SavedFrame.CaseValue;
            builder = FindSavedBuilder(branch, caseValue);
        }
        else
        {
            var switchValue = SwitchValue(WorkflowState);
            caseValue = switchValue.ToString();

            if (CaseBuilders.TryGetValue(switchValue, out var caseBuilder))
            {
                branch = CatCheckpointBranches.Case;
                builder = caseBuilder;
            }
            else
            {
                branch = CatCheckpointBranches.Default;
                builder = DefaultCaseBuilder;
            }
        }

        if (builder is null)
        {
            return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
        }

        var result = await RunChildStepsAsync(_catStepProcessor, builder, WorkflowState, resuming, cancellationToken);

        return result.WorkflowResult == CatStepExecutionResult.Suspend
            ? Suspended(result, frame =>
            {
                frame.Branch = branch;
                frame.CaseValue = caseValue;
            })
            : result;
    }

    private CatWorkflowBuilder<TWorkflowState> FindSavedBuilder(string branch, string? caseValue)
    {
        if (branch == CatCheckpointBranches.Default)
        {
            return DefaultCaseBuilder
                   ?? throw new CatWorkflowResumeException("The checkpoint holds the default case of a switch, but the workflow has no default case.");
        }

        foreach (var pair in CaseBuilders)
        {
            if (pair.Key.ToString() == caseValue)
            {
                return pair.Value;
            }
        }

        throw new CatWorkflowResumeException($"The checkpoint holds the case '{caseValue}' of a switch, but the workflow has no such case.");
    }
}
