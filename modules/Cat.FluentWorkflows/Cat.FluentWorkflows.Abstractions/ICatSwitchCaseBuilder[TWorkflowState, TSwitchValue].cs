using System;

namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Describes the cases of a switch step.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
/// <typeparam name="TSwitchValue">The type of the value being switched on.</typeparam>
public interface ICatSwitchCaseBuilder<TWorkflowState, TSwitchValue>
    where TSwitchValue : struct
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// Adds the steps to run when no case matches.
    /// </summary>
    /// <param name="defaultCaseBuilder">Adds the steps.</param>
    void Default(Action<ICatWorkflowBuilder<TWorkflowState>> defaultCaseBuilder);

    /// <summary>
    /// Adds a case without steps of its own. It runs the steps of the next case that has some, like a fall through.
    /// </summary>
    /// <param name="testValue">The value to match.</param>
    /// <exception cref="Exception">The value is already used by another case.</exception>
    void Case(TSwitchValue testValue);

    /// <summary>
    /// Adds a case with its steps.
    /// </summary>
    /// <param name="testValue">The value to match.</param>
    /// <param name="caseBuilder">Adds the steps.</param>
    /// <exception cref="Exception">The value is already used by another case.</exception>
    void Case(TSwitchValue testValue, Action<ICatWorkflowBuilder<TWorkflowState>> caseBuilder);
}