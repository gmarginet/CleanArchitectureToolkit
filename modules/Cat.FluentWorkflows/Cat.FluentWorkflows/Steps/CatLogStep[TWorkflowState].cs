using System;
using Cat.FluentWorkflows.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Built-in step behind <c>Log</c> and the level specific log methods. It writes one log entry and continues.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public class CatLogStep<TWorkflowState> : CatStepBody<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="logger">Receives the log entry.</param>
    public CatLogStep(
        ILogger<CatLogStep<TWorkflowState>> logger)
        : base(logger)
    {
    }

    /// <summary>
    /// The level to log at.
    /// </summary>
    public LogLevel LogLevel { get; set; }

    /// <summary>
    /// The message template.
    /// </summary>
    public string Message { get; set; } = null!;

    /// <summary>
    /// Gets the values for the placeholders from the workflow state.
    /// </summary>
    public Func<TWorkflowState, object[]> GetArgs { get; set; } = null!;

    /// <inheritdoc />
    protected override ICatWorkflowResponse Run()
    {
        Logger.Log(LogLevel, Message, GetArgs(WorkflowState));
            
        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}