using Cat.FluentWorkflows.Abstractions;
using Cat.Responses;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Tests.Steps;

public class FailAndContinueStep : CatStepBody
{
    public FailAndContinueStep(ILogger<FailAndContinueStep> logger) : base(logger)
    {
    }

    protected override ICatWorkflowResponse Run()
    {
        return CatWorkflowResponse.Failed(CatStepExecutionResult.Continue, CatError.Create("X-3", "failed but continues"));
    }
}
