using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Tests.Steps;

public class DoubleStep : CatStepBody
{
    public DoubleStep(ILogger<DoubleStep> logger) : base(logger)
    {
    }

    public int Value { get; set; }

    public int Result { get; private set; }

    protected override ICatWorkflowResponse Run()
    {
        Result = Value * 2;
        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}
