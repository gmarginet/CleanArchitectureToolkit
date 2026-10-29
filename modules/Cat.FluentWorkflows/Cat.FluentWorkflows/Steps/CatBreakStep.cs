using System;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Built-in step behind <c>BreakCascade</c>, <c>BreakFromCurrentFlowOnly</c> and <c>BreakFromLoop</c>.
/// It always breaks the way <see cref="BreakType"/> says.
/// </summary>
public class CatBreakStep : CatStepBody
{
    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="logger">The logger the step can use.</param>
    public CatBreakStep(
        ILogger<CatBreakStep> logger)
        : base(logger)
    {
    }

    /// <summary>
    /// The kind of break to make.
    /// </summary>
    public CatBreakType BreakType { get; set; }

    /// <inheritdoc />
    protected override ICatWorkflowResponse Run()
    {
        return BreakType switch
        {
            CatBreakType.BreakCascade => CatWorkflowResponse.Succeeded(CatStepExecutionResult.BreakCascade),
            CatBreakType.BreakFromCurrentFlowOnly => CatWorkflowResponse.Succeeded(CatStepExecutionResult.BreakFromCurrentFlowOnly),
            CatBreakType.BreakFromLoop => CatWorkflowResponse.Succeeded(CatStepExecutionResult.BreakFromLoop),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}