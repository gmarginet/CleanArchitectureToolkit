using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.Responses;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record RunFuncWithLoggerFlowState : ICatWorkflowState<RunFuncWithLoggerFlowState>
{
    public List<string> Trace { get; } = [];
}

public class RunFuncWithLoggerFlow : ICatWorkflow<RunFuncWithLoggerFlowState>
{
    public void Build(ICatWorkflowBuilder<RunFuncWithLoggerFlowState> builder)
    {
        builder.Run((logger, s) =>
        {
            logger.LogInformation("from the func step");
            s.Trace.Add("func");
            return CatResponse.Ok(CatStepExecutionResult.Continue);
        });
        builder.Run(s => s.Trace.Add("after"));
    }
}
