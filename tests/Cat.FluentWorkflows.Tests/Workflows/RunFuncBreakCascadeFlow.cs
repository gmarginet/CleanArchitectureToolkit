using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.Responses;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record RunFuncBreakCascadeFlowState : ICatWorkflowState<RunFuncBreakCascadeFlowState>
{
    public List<string> Trace { get; } = [];
}

public class RunFuncBreakCascadeFlow : ICatWorkflow<RunFuncBreakCascadeFlowState>
{
    public void Build(ICatWorkflowBuilder<RunFuncBreakCascadeFlowState> builder)
    {
        builder.Run(s =>
        {
            s.Trace.Add("f1");
            return CatResponse.Ok(CatStepExecutionResult.BreakCascade);
        });
        builder.Run(s => s.Trace.Add("after"));
    }
}
