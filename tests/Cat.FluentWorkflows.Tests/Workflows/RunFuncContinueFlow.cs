using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.Responses;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record RunFuncContinueFlowState : ICatWorkflowState<RunFuncContinueFlowState>
{
    public List<string> Trace { get; } = [];
}

public class RunFuncContinueFlow : ICatWorkflow<RunFuncContinueFlowState>
{
    public void Build(ICatWorkflowBuilder<RunFuncContinueFlowState> builder)
    {
        builder.Run(s =>
        {
            s.Trace.Add("f1");
            return CatResponse.Ok(CatStepExecutionResult.Continue);
        });
        builder.Run(s => s.Trace.Add("after"));
    }
}
