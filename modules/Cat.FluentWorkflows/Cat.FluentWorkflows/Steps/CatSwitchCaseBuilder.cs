using System;
using System.Collections.Generic;
using Cat.FluentWorkflows.Abstractions;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Default <see cref="ICatSwitchCaseBuilder{TWorkflowState, TSwitchValue}"/>.
/// Collects the cases and the default case of a switch step.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
/// <typeparam name="TSwitchValue">The type of the value being switched on.</typeparam>
public class CatSwitchCaseBuilder<TWorkflowState, TSwitchValue> : ICatSwitchCaseBuilder<TWorkflowState, TSwitchValue>
    where TSwitchValue : struct
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    internal Action<CatWorkflowBuilder<TWorkflowState>>? BuildDefaultCase { get; set; }
    internal Dictionary<TSwitchValue, Action<CatWorkflowBuilder<TWorkflowState>>> BuildCases { get; } = new();
    private List<TSwitchValue> UnAssignedSwitchValues { get; } = [];

    /// <inheritdoc />
    public void Default(Action<ICatWorkflowBuilder<TWorkflowState>> defaultCaseBuilder)
    {
        BuildDefaultCase = defaultCaseBuilder;
    }

    /// <inheritdoc />
    public void Case(TSwitchValue testValue)
    {
        if (BuildCases.ContainsKey(testValue) || UnAssignedSwitchValues.Contains(testValue))
        {
            throw new Exception($"Case with value '{testValue}' is already defined.");
        }

        UnAssignedSwitchValues.Add(testValue);
    }

    /// <inheritdoc />
    public void Case(TSwitchValue testValue, Action<ICatWorkflowBuilder<TWorkflowState>> caseBuilder)
    {
        if (BuildCases.ContainsKey(testValue))
        {
            throw new Exception($"Case with value '{testValue}' is already defined.");
        }

        if (UnAssignedSwitchValues.Count > 0)
        {
            foreach (var unAssignedSwitchValue in UnAssignedSwitchValues)
            {
                BuildCases.Add(unAssignedSwitchValue, caseBuilder);
            }
            UnAssignedSwitchValues.Clear();
        }

        BuildCases.Add(testValue, caseBuilder);
    }
}
