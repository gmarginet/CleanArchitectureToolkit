using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.Responses;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record RunFuncFailedFlowState : ICatWorkflowState<RunFuncFailedFlowState>
{
    public List<string> Trace { get; } = [];
}

public class RunFuncFailedFlow : ICatWorkflow<RunFuncFailedFlowState>
{
    public void Build(ICatWorkflowBuilder<RunFuncFailedFlowState> builder)
    {
        builder.Run(s =>
        {
            s.Trace.Add("f1");
            return CatResponse.BadRequest<CatStepExecutionResult>(CatError.Create("X-1", "bad"));
        });
        builder.Run(s => s.Trace.Add("after"));
    }
}
